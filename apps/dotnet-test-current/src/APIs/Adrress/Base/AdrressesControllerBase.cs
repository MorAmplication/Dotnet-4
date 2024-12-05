using DotnetTestCurrent.APIs;
using DotnetTestCurrent.APIs.Common;
using DotnetTestCurrent.APIs.Dtos;
using DotnetTestCurrent.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTestCurrent.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AdrressesControllerBase : ControllerBase
{
    protected readonly IAdrressesService _service;

    public AdrressesControllerBase(IAdrressesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Meta data about adrress records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AdrressesMeta(
        [FromQuery()] AdrressFindManyArgs filter
    )
    {
        return Ok(await _service.AdrressesMeta(filter));
    }

    /// <summary>
    /// Create one adrress
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Adrress>> CreateAdrress(AdrressCreateInput input)
    {
        var adrress = await _service.CreateAdrress(input);

        return CreatedAtAction(nameof(Adrress), new { id = adrress.Id }, adrress);
    }

    /// <summary>
    /// Delete one adrress
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAdrress([FromRoute()] AdrressWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAdrress(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many adrresses
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Adrress>>> Adrresses(
        [FromQuery()] AdrressFindManyArgs filter
    )
    {
        return Ok(await _service.Adrresses(filter));
    }

    /// <summary>
    /// Get one adrress
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Adrress>> Adrress([FromRoute()] AdrressWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Adrress(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one adrress
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAdrress(
        [FromRoute()] AdrressWhereUniqueInput uniqueId,
        [FromQuery()] AdrressUpdateInput adrressUpdateDto
    )
    {
        try
        {
            await _service.UpdateAdrress(uniqueId, adrressUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
