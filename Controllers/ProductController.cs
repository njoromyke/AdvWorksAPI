using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Product>> Get()
    {
        List<Product> list = new ProductRepository().Get();

        return list?.Count > 0
            ? StatusCode(StatusCodes.Status200OK, list)
            : StatusCode(StatusCodes.Status404NotFound, "No Product Found");
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
        var entity = new ProductRepository().Get(id);

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
