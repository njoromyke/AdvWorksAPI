﻿using AdvWorksAPI.BaseController;
using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBaseApi
{
    private readonly IRepository<Product> _repo;

    public ProductController(IRepository<Product> repo, ILogger<ProductController> logger) : base(logger)
    {
        _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<Product>> Get()
    {
        ActionResult<IEnumerable<Product>> ret;
        List<Product> list = _repo.Get();
        InfoMessage  = "No Products are available";

        try
        {

            return list?.Count > 0
                ? StatusCode(StatusCodes.Status200OK, list)
                : StatusCode(StatusCodes.Status404NotFound, "No Product Found");
        }
        catch (Exception e)
        {
            InfoMessage = "Error in Product API";
            ErrorLogMessage = " Error in ProductController.Get()";
            ret = HandleException<IEnumerable<Product>>(e);
        }

        return ret; 
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ByCategory/{categoryId}")]
    public ActionResult<IEnumerable<Product>> SearchByCategory(int categoryId)
    {
        Console.WriteLine(categoryId.ToString());

        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product?> Get(int id)
    {
        var entity = _repo.Get(id);

        return entity != null ? Ok(entity) : NotFound($"Cannot find product with id {id}");
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("SearchByNameAndPrice")]
    public ActionResult<IEnumerable<Product>> SearchByNameAndPrice(string name, decimal listPrice)
    {
        return StatusCode(StatusCodes.Status200OK);
    }
}
