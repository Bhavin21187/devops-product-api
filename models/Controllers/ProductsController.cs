using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products =
    [
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 75000
        },
        new Product
        {
            Id = 2,
            Name = "Keyboard",
            Price = 2500
        },
        new Product
        {
            Id = 3,
            Name = "Mouse",
            Price = 1200
        }
    ];

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(Products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        product.Id = Products.Count + 1;

        Products.Add(product);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product);
    }
}