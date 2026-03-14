



using SurveyNest.Application.DtoContracts.Roles;

namespace SurveyNest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RolesController(IRoleService roleService) : ControllerBase
{
    [HttpGet("")]
    [HasPermission(Permissions.GetRoles)]
    public async Task<IActionResult> GetAll([FromQuery] bool includeDisabled, CancellationToken cancellationToken)
    {
        var roles = await roleService.GetAllAsync(includeDisabled, cancellationToken);
        return Ok(roles);
    }

    [HttpGet("{id}")]
    [HasPermission(Permissions.GetRoles)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await roleService.GetAsync(id);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddRoles)]
    public async Task<IActionResult> Add([FromBody] RoleRequest request, CancellationToken cancellationToken)
    {
        var result = await roleService.AddAsync(request, cancellationToken);
        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value)
            : result.ToProblem();
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UpdateRoles)]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] RoleRequest request, CancellationToken cancellationToken)
    {
        var result = await roleService.UpdateAsync(id, request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("{id}/toggle-status")]
    [HasPermission(Permissions.UpdateRoles)]
    public async Task<IActionResult> ToggleStatus([FromRoute] string id)
    {
        var result = await roleService.ToggleStatusAsync(id);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}


