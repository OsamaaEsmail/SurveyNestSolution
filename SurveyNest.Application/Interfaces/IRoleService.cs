

using SurveyNest.Application.DtoContracts.Roles;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
    Task<Result<RoleDetailResponse>> GetAsync(string Id, CancellationToken cancellationToken = default);

    Task<Result<RoleDetailResponse>> AddAsync(RoleRequest request, CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(string id, RoleRequest request, CancellationToken cancellationToken = default);

    Task<Result> ToggleStatusAsync(string id);
}
