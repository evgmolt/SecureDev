using Microsoft.AspNetCore.Mvc;
using VinylCatalogApi.Models;
using VinylCatalogApi.Services;

namespace VinylCatalogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VinylsController : ControllerBase
{
    private readonly VinylsService _vinylsService;

    public VinylsController(VinylsService vinylsService) =>
        _vinylsService = vinylsService;

    [HttpGet]
    public async Task<List<VinylRecord>> Get() =>
        await _vinylsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<VinylRecord>> Get(string id)
    {
        var book = await _vinylsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(VinylRecord newBook)
    {
        await _vinylsService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, VinylRecord updatedBook)
    {
        var book = await _vinylsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _vinylsService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _vinylsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _vinylsService.RemoveAsync(id);

        return NoContent();
    }
}