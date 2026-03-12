

using SurveyNest.Application.DtoContracts.Users;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Application.Interfaces;

public interface IUserService
{
    Task<Result<UserProfileResponse>> GetProfileAsync(string userId);

    Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request);

    Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request);
    Task<Result<IEnumerable<UserResponse>>>GetAllAsync(CancellationToken cancellationToken = default);

    Task<Result<UserResponse>> GetAsync(string id);

    Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default);

    Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default);

    Task<Result> ToggleStatus(string id, CancellationToken cancellationToken = default);
    Task<Result> Unlock(string id, CancellationToken cancellationToken = default);
}
