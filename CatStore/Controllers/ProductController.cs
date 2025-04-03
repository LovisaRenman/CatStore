using CatStore.Components.Pages;
using CatStore.Entities;
using CatStore.Models;
using CatStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Threading.Tasks;

namespace CatStore.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    public readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var productEntity = await _productRepository.GetAllProductsAsync();
        var results = new List<ProductDto>();
        foreach (var entity in productEntity)
        {
            results.Add(new ProductDto(entity));
        }
        return Ok(results);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var productToReturn = await _productRepository.GetProduct(id);
        return productToReturn == null 
            ? NotFound($"No product was found by id: {id}") 
            : Ok(productToReturn);
    }
    [HttpGet("get/{name}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByName(string name)
    {
        var productEntity = await _productRepository.GetAllProductsByNameAsync(name);

        var results = new List<ProductDto>();
        foreach (var entity in productEntity)
        {
            results.Add(new ProductDto(entity));
        }
        return Ok(results);        
    }
    [HttpPut("allowDelete{id}")]
    public async Task<ActionResult> AllowDelete(int id)
    {
        var product = await _productRepository.AllowDelete(id);
        if (product != null && product.Customers.Count == 0) return NoContent();
        return NotFound();
    }
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto product)
    {
        var newProduct = new Product(product);
        await _productRepository.NewProduct(newProduct);

        return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, new ProductDto(newProduct));
    }
    [HttpPut]
    public async Task<ActionResult> UpdateProduct(ProductDto product)
    {
        var productUpdate = await _productRepository.UpdateProduct(new Product(product));
        return productUpdate == null 
            ? NotFound() 
            : Ok(productUpdate);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await _productRepository.DeleteProduct(id);
        return product == null
            ? NotFound() 
            : NoContent();   
    }
}
