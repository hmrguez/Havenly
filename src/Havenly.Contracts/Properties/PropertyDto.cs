namespace Havenly.Contracts.Properties;

public class PropertyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int NumberOfRooms { get; set; }
    public int NumberOfBathrooms { get; set; }
    public int SquareFootage { get; set; }
    public int Price { get; set; }
    public bool IsAvailable { get; set; }
    public Guid OwnerId { get; set; }
    public Guid AmenityId { get; set; }
    public Guid LeaseId { get; set; }
    public Guid TenantId { get; set; }
}