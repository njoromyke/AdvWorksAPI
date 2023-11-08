using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
    public class ProductIActionController : Controller
    {

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get()
        {
            IActionResult ret;
            List<Product> list;

            list = new ProductRepository().Get();

            //list.Clear();

            ret = list?.Count > 0 ? StatusCode(StatusCodes.Status200OK, list) : StatusCode(StatusCodes.Status404NotFound, "No Product Found");

            return ret;
         
        }

        [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Get(int id)
        {
            IActionResult ret;

            var entity = new ProductRepository().Get(id);


            ret = entity != null ? Ok(entity) : NotFound($"Cannot find product with id {id}");
            
            return ret;

        }

    }

