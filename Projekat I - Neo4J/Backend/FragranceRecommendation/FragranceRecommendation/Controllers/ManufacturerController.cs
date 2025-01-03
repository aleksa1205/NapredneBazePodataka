﻿using FragranceRecommendation.Services.ManufacturerService;

namespace FragranceRecommendation.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController(
    IDriver driver,
    IManufacturerService manufacturerService,
    IFragranceService fragranceService,
    IPerfumerService perfumerService) : ControllerBase
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("get all manufacturers")]
    [HttpGet]
    public async Task<IActionResult> GetAllManufacturers()
    {
        try
        {
            var manufacturers = await manufacturerService.GetAllManufacturers();

            return Ok(manufacturers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("get manufacturer by name")]
    [HttpGet("{name}")]
    public async Task<IActionResult> GetManufacturer(string name)
    {
        try
        {
            if (!await manufacturerService.ManufacturerExistsAsync(name))
                return NotFound($"Manufacturer {name} does not exist");

            var manufacturer = await manufacturerService.GetManufacturerAsync(name);

            return Ok(manufacturer);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("add manufacturer")]
    [HttpPost("{name}")]
    public async Task<IActionResult> AddManufacturer(string name)
    {
        try
        {
            if (await manufacturerService.ManufacturerExistsAsync(name))
                return NotFound($"Manufacturer {name} already exists.");

            await manufacturerService.AddManufacturerAsync(name);
            return Ok($"Manufacturer {name} successfully added!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("add manufacturer to fragrance")]
    [HttpPatch("{manufacturerName}/{fragranceId}")]
    public async Task<IActionResult> AddFragranceToManufacturer(string manufacturerName, int fragranceId)
    {
        try
        {
            if (!await manufacturerService.ManufacturerExistsAsync(manufacturerName))
                return NotFound($"Manufacturer {manufacturerName} doesn't exist!");

            if (!await fragranceService.FragranceExistsAsync(fragranceId))
                return NotFound($"Fragrance with id {fragranceId} doesn't exist!");

            if (await manufacturerService.IsFragranceCreatedByManufacturerAsync(fragranceId, manufacturerName))
                return Conflict($"Manufacturer {manufacturerName} already manufactures fragrance with id {fragranceId}");

            if (await fragranceService.FragranceHasManufacturerAsync(fragranceId))
                return Conflict($"Fragrance with id {fragranceId} already has manufacturer!");

            await manufacturerService.AddFragranceToManufacturerAsync(fragranceId, manufacturerName);

            return Ok($"Successfully added fragrance with the id {fragranceId} to manufacturer {manufacturerName}!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("delete manufacturer")]
    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteManufacturer(string name)
    {
        try
        {
            if (!await manufacturerService.ManufacturerExistsAsync(name))
                return NotFound($"Manufacturer {name} doesn't exist!");

            await manufacturerService.DeleteManufacturerAsync(name);

            return Ok($"Manufacturer {name} successfully deleted!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
