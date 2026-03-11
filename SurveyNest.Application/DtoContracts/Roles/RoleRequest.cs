


namespace SurveyNest.Application.DtoContracts.Roles;

public record RoleRequest
(
    string Name,
    IList<string> Permissions

);