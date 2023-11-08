using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
    public class ProductIActionController : Controller
    {

    [HttpGet]
        public IActionResult Get()
        {
            IActionResult ret;
            List<Product> list;

            list = new ProductRepository().Get();

            //list.Clear();

            ret = list?.Count > 0 ? StatusCode(StatusCodes.Status200OK, list) : StatusCode(StatusCodes.Status404NotFound, "No Product Found");

            return ret;
         
        }
    }

