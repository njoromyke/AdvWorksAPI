using AdvWorksAPI.BaseController;
using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBaseApi
{
    private readonly IRepository<Product> _repo;
    private readonly AdvWorksApiDefaults _settings;

    public ProductController(IRepository<Product> repo, ILogger<ProductController> logger,IOptionsMonitor<AdvWorksApiDefaults> settings) : base(logger)
    {
        _repo = repo;
        _settings = settings.CurrentValue;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/xml")]
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
            InfoMessage = _settings.InfoMessageDefault.Replace("{Verb}", "Get").Replace("{ClassName}", "Product");
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


    [HttpPost]
    [Consumes("application/xml")]
    [Produces("application/xml")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Product> Post(Product entity)
    {
        ActionResult<Product> ret;

        entity.ModifiedDate = DateTime.Now;

        ret = StatusCode(StatusCodes.Status201Created, entity);

        return ret;
    }
}
