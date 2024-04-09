Entities:

- Tenant
- User
- Owner
- Property
- Lease
- Amenity
- Address

## 1st phase

- Tenant
    - User
    - Lease(s)

- Owner
    - User
    - Property(s)

- Property
    - Address
    - Amenity(s)
    - Owner

- Lease
    - Tenant
    - Property

- Amenity
    - Property(s)

## 2nd phase

- Owner
    - UserId
    - PropertyId(s)

- Property
    - AmenityId(s)
    - OwnerId
    - Address

- Lease
    - Tenant
        - UserId
    - PropertyId
