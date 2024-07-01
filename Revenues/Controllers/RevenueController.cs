using FinancialRevenues.Base;
using FinancialRevenues.Revenues.Dtos;
using FinancialRevenues.Revenues.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialRevenues.Revenues.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RevenueController(IRevenueService revenueService) : Controller
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<IList<GetRevenueForViewDto>>> GetAll([FromQuery]GetAllRevenuesInput input)
    {
        return Ok(await revenueService.GetAllPagedAsync(input));
    }

    [HttpGet("GetRevenueForView")]
    public async Task<ActionResult<GetRevenueForViewDto>> GetRevenueForView([FromQuery]EntityDto<Guid> input)
    {
        return Ok(await revenueService.GetRevenueForViewAsync(input));
    }
    
    [HttpGet("GetRevenueForEdit")]
    public async Task<ActionResult<GetRevenueForEditOutput>> GetRevenueForEdit([FromQuery]EntityDto<Guid> input)
    {
        return Ok(await revenueService.GetRevenueForEditAsync(input));
    }

    [HttpGet("GetAllDeleted")]
    public async Task<ActionResult<IList<GetRevenueForEditOutput>>> GetAllDeleted()
    {
        var deletedRevenues = await revenueService.GetAllDeletedAsync();
        return Ok(deletedRevenues);
    }

    [HttpPost("CreateOrEdit")]
    public async Task<IActionResult> CreateOrEdit([FromBody]CreateOrEditRevenueDto input)
    {
        if (input.Id==Guid.Empty)
        {
            await revenueService.AddAsync(input);
            return Ok();
        }

        await revenueService.ModifyAsync(input);
        return Ok();
    }

    [HttpDelete("SoftDelete")]
    public async Task<IActionResult> SoftDelete([FromQuery]EntityDto<Guid> input)
    {
        await revenueService.SoftDeleteAsync(input);
        return Ok();
    }
    [HttpDelete("HardDelete")]
    public async Task<IActionResult> HardDelete([FromQuery]EntityDto<Guid> input)
    {
        await revenueService.HardDeleteAsync(input);
        return Ok();
    }
}