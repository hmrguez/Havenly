using Domain.Aggregates;
using Havenly.Application.Leases;
using Havenly.Contracts.Leases;
using MapsterMapper;

namespace Havenly.Api.Leases;


[ExtendObjectType("Mutation")]
public class LeaseMutation
{
    private readonly ILeaseService _leaseService;
    private readonly IMapper _mapper;

    public LeaseMutation(IMapper mapper, ILeaseService leaseService)
    {
        _mapper = mapper;
        _leaseService = leaseService;
    }

    public async Task<Guid> CreateFromScratch(CreateLeaseTenantDto dto)
    {
        var createdLease = await _leaseService.CreateFromScratch(dto);
        return createdLease;
    }

    public async Task<Guid> CreateLease(LeaseDto leaseDto)
    {
        var lease = _mapper.Map<Lease>(leaseDto);
        var createdLease = await _leaseService.CreateLease(lease);
        return createdLease;
    }

    public async Task<Guid> RenewLease(Guid leaseId)
    {
        var renewedLease = await _leaseService.RenewLease(leaseId);
        return renewedLease;
    }

    public async Task<Guid> TerminateLease(Guid leaseId)
    {
        var terminatedLease = await _leaseService.TerminateLease(leaseId);
        return terminatedLease;
    }

    public async Task<Guid> UpdateLease(LeaseDto leaseDto)
    {
        var lease = _mapper.Map<Lease>(leaseDto);
        var updatedLease = await _leaseService.UpdateLease(lease);
        return updatedLease;
    }
}