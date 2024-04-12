// src/Havenly.Api/Leases/LeaseQuery.cs

using Havenly.Application.Leases;
using Havenly.Contracts.Leases;
using MapsterMapper;

namespace Havenly.Api.Leases;

[ExtendObjectType("Query")]
public class LeaseQuery
{
    private readonly ILeaseService _leaseService;
    private readonly IMapper _mapper;

    public LeaseQuery(IMapper mapper, ILeaseService leaseService)
    {
        _mapper = mapper;
        _leaseService = leaseService;
    }

    public async Task<LeaseDto> GetLease(Guid leaseId)
    {
        var lease = await _leaseService.GetLease(leaseId);

        if (lease == null)
            throw new Exception("Lease not found");

        return _mapper.Map<LeaseDto>(lease);
    }
}