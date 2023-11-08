using Microsoft.AspNetCore.Mvc;
using AdvWorksAPI.RepositoryLayer;
using AdvWorksAPI.EntityLayer;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
    public class ProductEntityController : Controller
    {
        [HttpGet]

        public List<Product> Get()
        {
            List<Product> list = new ProductRepository().Get();

            return list;
        }

        [HttpGet("{id}")]
        public Product? Get(int id)
        {
            Product? entity = new ProductRepository().Get(id);

            return entity;
        }
    }

