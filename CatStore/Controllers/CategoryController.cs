using CatStore.Models;
using CatStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatStore.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));   
    }
    [HttpGet]
    public async Task<ActionResult> GetProductsAsync()
    {
        var productEntity = await _categoryRepository.GetAllCategoriesAsync();
        var results = new List<CategoryDto>();
        foreach (var entity in productEntity)
        {
            results.Add(new CategoryDto(entity));
        }
        return Ok(results);
    }
    [HttpGet("{id}")]
    public ActionResult GetProduct(int id)
    {
        var categoryToReturn = _categoryRepository.GetCategory(id);

        return categoryToReturn == null ? NotFound() : Ok(categoryToReturn);
    }
}
