using Microsoft.AspNetCore.Mvc;
using Mesbg.Api.Services;


namespace Mesbg.Api.Controllers;

[ApiController]
[Route("api/units")]
public class UnitsController: ControllerBase
{
    private readonly UnitService _unitService;

    public UnitsController(UnitService unitService)
    {
        _unitService = unitService;
    }

    //Get: api/units
    [HttpGet]
    public async Task<IActionResult> GetAllUnits()
    {
        var units = await _unitService.GetAllUnitsAsync();
        return Ok(units);

    }

}