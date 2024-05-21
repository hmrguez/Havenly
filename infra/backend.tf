provider "aws" {
  region = "us-east-1"
}

# VPC Configuration
resource "aws_vpc" "main" {
  cidr_block = "10.0.0.0/16"
  enable_dns_support   = true
  enable_dns_hostnames = true
  tags = {
    Name = "MainVPC"
  }
}

# Subnets for EKS Nodes
resource "aws_subnet" "eks_subnets" {
  count                   = 2
  vpc_id                  = aws_vpc.main.id
  cidr_block              = "10.0.${count.index + 1}.0/24"
  availability_zone       = element(aws_availability_zones.available.names, count.index)
  map_public_ip_on_launch = false

  tags = {
    Name = "EKS-${count.index}"
  }
}

# Internet Gateway
resource "aws_internet_gateway" "igw" {
  vpc_id = aws_vpc.main.id
}

# Route Table for Private Subnet
resource "aws_route_table" "private" {
  vpc_id = aws_vpc.main.id

  tags = {
    Name = "PrivateRouteTable"
  }
}

# EKS Cluster
module "eks" {
  source          = "terraform-aws-modules/eks/aws"
  version         = "~> 17.1.0"
  cluster_name    = "havenly-cluster"
  cluster_version = "1.22"
  subnets         = aws_subnet.eks_subnets.*.id
  vpc_id          = aws_vpc.main.id

  node_groups = {
    eks_nodes = {
      desired_capacity = 2
      max_capacity     = 10
      min_capacity     = 1

      instance_type = "m5.large"
      key_name      = "havenly-keypair"
    }
  }
}

# RDS Instance for PostgreSQL
resource "aws_db_instance" "postgresql" {
  allocated_storage    = 20
  storage_type         = "gp2"
  engine               = "postgres"
  engine_version       = "13.4"
  instance_class       = "db.t3.medium"
  name                 = "havenly-postgres"
  username             = "admin"
  password             = "securepassword"
  parameter_group_name = "default.postgres13.4"
  vpc_security_group_ids = [aws_security_group.rds_sg.id]
  subnet_group_name   = "havenly-subnet-group"
}

# Security Group for RDS
resource "aws_security_group" "rds_sg" {
  name        = "RDS-SG"
  description = "Allow inbound traffic to RDS"
  vpc_id      = aws_vpc.main.id

  ingress {
    from_port   = 5432
    to_port     = 5432
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

# Availability Zones
data "aws_availability_zones" "available" {}

output "cluster_endpoint" {
  value = module.eks.cluster_endpoint
}

output "cluster_identity_oidc_issuer" {
  value = module.eks.cluster_identity_oidc_issuer
}

output "db_instance_endpoint" {
  value = aws_db_instance.postgresql.endpoint
}
