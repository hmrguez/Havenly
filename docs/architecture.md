# Havenly Architecture Breakdown

## Phase 1 (pitch and requirement extraction)

### Idea (pitch from the client)

Okay, imagine this: you're swamped with managing all your properties. Keeping track of rent payments, maintenance
requests, and tenant information is a messy mix of spreadsheets, emails, and scattered notes. You need a way to
streamline everything.

Picture an app on your phone that acts as your all-in-one property management assistant. Here's what it could do:

* **Property Central:** A dashboard where all your properties are listed. You can see which units are occupied, track
  rent due, and check which maintenance jobs are pending.
* **Tenant Hub:** A place to store tenant details, payment history, and have a chat feature to send them messages or
  rent reminders.
* **Fix-It Fast:**  Tenants can snap a picture of a leaky pipe, describe the issue, and it gets added to a work order
  list. You can quickly assign it to your plumber or handyman.
* **Money Matters:** The app tracks income and expenses for each property. Come tax season, all your data is neatly
  organized and ready for your accountant.

**Growing Your Reach**

If this app makes your life easier, other landlords are probably going to want it too! We could add features like:

* **Finding New Tenants:** The app connects to popular rental sites where you can easily advertise your vacancies.
* **Tenant Screening:** You can quickly run background and credit checks on potential renters directly through the app.

### Return questions

- **Scalability**: How many properties and tenants are we talking about? And if the app goes public how many users will
  it
  have?
    - A/ I right now have 2 buildings each with 30 units, but I plan to expand more. And imagine I have 10 different
      friends with somewhat the same capacity, so the app needs to withstand that kind of data

- **Security**: How sensitive is the data? What kind of security measures do we need to take?
    - A/ Properties are in a public record but what my clients pay isn't, so the main point in security need to be the
      leases details and my clients personal info.

- **Integration**: Are there any existing tools or services that the app should connect to?
    - A/ If the app could connect to `Zillow` or `Realtor.com` to advertise my vacancies that would be great. Also in
      the future I don't see why this couldn't also work for real state agents, so integrate with tools like `Idealista`
      or `Rentals.ca` to see available properties to buy or rent.

### Functional requirements

- The app must be able to register landlords, properties, tenants and create leases

- Each tenant should be able to pay the rent via the app

- Each tenant should be able to create maintenance tickets and track them using the app

- Each landlord should be able to manage their properties, check their status (rented, occupied, ...), expenses,
  revenues, history, ...

- The app should track rent payments and warn both tenant and landlord when rent is overdue or close to it

- The app should be able to connect to tools like Zillow or Realtor.com to see potential new properties for landlords

### Non functional requirements:

- The app should be able to withstand thousands of users (between landlords and tenants), as well as thousands of
  property and lease data

- The app should be able to guarantee privacy and security of both landlord and tenant details, above all payment
  information

- The app should feel responsive enough, under half a second between opening and main dashboard (assuming user's already
  logged in), even with a cellphone connection

- The app should have an intuitive design, because it might be used for people from all backgrounds and generations

- The app should be resistant to failure, no data can be lost at any point if we are talking about other people's money

## Phase 2 (architecture design)

### Overview

The vision for our application is a three-pronged approach, each prong representing a different facet of our user
interface and backend logic.

Firstly, we have our web frontend. This will be a sleek, intuitive interface that can be accessed from any web browser.
It will be built using modern web technologies to ensure a responsive and engaging user experience. To deliver this web
application to our users, we'll be utilizing `AWS CloudFront`. CloudFront is a fast content delivery network (CDN)
service that securely delivers data, videos, applications, and APIs to users globally with low latency and high transfer
speeds. This means our web application will be readily accessible to users around the world, providing them with a fast
and seamless experience. We will store the website related files in an `S3` bucket and let Cloudfront pick them up from
there

Secondly, we have our mobile application. This will be a native app, available for download from the App Store for iOS
users and the Play Store for Android users. The mobile app will provide the same core functionality as the web
application, but in a format that's optimized for mobile devices. This ensures that our users can manage their
properties on the go, right from the palm of their hand.

Lastly, we have our backend. This is where the magic happens. Our backend will be composed of Docker containers running
on `Amazon Elastic Kubernetes Service (EKS)`. EKS is a managed container service that makes it easy to deploy, manage,
and scale containerized applications using Kubernetes. By using `Docker`, we can ensure that our application runs in the
same way regardless of the environment, leading to fewer surprises and easier debugging. `Kubernetes`, on the other
hand, helps us manage and orchestrate these containers, handling tasks like load balancing and distribution, health
monitoring, and scaling.

We'll use a relational `PostgreSQL` database managed by AWS RDS for our standard structured data (personal information,
payment information, property information, etc.) and we'll store other unstructured data in `S3` buckets. These both
services are managed mostly by AWS which means they'll do most of the scaling for us.

In summary, our architecture is designed to be robust, scalable, and user-friendly. By leveraging powerful technologies
like AWS CloudFront, Docker, and EKS, we can ensure that our application is not only performant and reliable but also
capable of serving a large and globally distributed user base.

### Technical Detail

On a more technical note. For our backend app we'll use the design pattern know as `Modular Monolith`
using `Domain Driven Design`, which is ideal for this kind of app and the fact that this is a rather small team. On the
contrary of Microservices, this means there will be one single app to deploy, but it will coded in separate Modules, to
have a clear separation between bounded concepts and prevent technical debt preventing us to scale at a reasonable pace.
This also means that when giving out tasks there will be a more "Module-focused" approach, meaning that we will start
with an MVP with the basic modules and then expand around it. It will be coded using ASP.NET, the defacto-standard Web
technology used by Microsoft. It leverages the C# programming language, and we choose it because it's fast, robust and
reliable, and provides de object-oriented tools necessary to work on a complex domain such as this one.

The backend will consist on a `GraphQL` api. The reason for this is simple. When going mobile, it's often easy to find
that the entities (objects) get scaled too much as the app scales, which means if it's not handled properly client will
end up received a lot of data that he doesn't use and GraphQL solves that by only asking for as much information as the
immediate request requires.

Our web frontend will be built using `Angular`, as it is a well-rounded tool for building elegant and enterprise-grade
websites and is a tool the team is already quite well versed on.

Since the web app will already be built using Angular a suggestion to build the Android and iOS app would be `Ionic`,
which is a native mobile app development framework built on top of Angular. It's performant and harnesses the tools and
technologies that our website will use.

### Security Deep Dive

Security is a paramount concern for our application, given the sensitive nature of the data we handle. We have
implemented several measures to ensure the integrity and confidentiality of our users' data.

**Data Encryption**

All data, both at rest and in transit, is encrypted. For data at rest, we use AWS's built-in encryption services. For
data in transit, we use HTTPS with TLS (Transport Layer Security), ensuring that all data sent between the client and
our servers is encrypted and secure.

**Authentication and Authorization**

We use `JWT (JSON Web Tokens)` for authentication. When a user logs in, they are issued a token, which they must then
include in the header of their HTTP requests. This token allows us to verify the identity of the user making the
request.

For authorization, we use `role-based access control (RBAC)`. Each user is assigned a role, and each role has
permissions that determine what actions the user can perform. This ensures that users can only access the data and
functionality that they are authorized to use.

**Container Security**

Our Docker containers running on EKS are also secured. We follow the **principle of least privilege**, meaning each
container only has the permissions it needs to perform its function and no more. We also regularly update our containers
to ensure they have the latest security patches. Permissions which will be granted only by `AWS IAM`, which will
guarantee another layer of security

**Database Security**

Our PostgreSQL database is managed by `AWS RDS`, which provides several built-in security features. These include
network isolation using `Amazon VPC`, encryption at rest using keys you create and control
through `AWS Key Management Service (KMS)`, and encryption of data in transit using SSL.

**Code Security**

We follow best practices for secure coding to prevent common security vulnerabilities. This includes input validation to
prevent `SQL injection`, using parameterized queries to interact with the database, and escaping output to prevent
`cross-site scripting (XSS)` attacks.

**Monitoring and Logging**

We use `AWS CloudWatch` for monitoring and logging. This allows us to detect any unusual activity or potential security
threats and respond to them quickly.

In summary, we take a multi-layered approach to security, ensuring that every aspect of our application is protected. We
are committed to maintaining the highest level of security to protect our users' data.