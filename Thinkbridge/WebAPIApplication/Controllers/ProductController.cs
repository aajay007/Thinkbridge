using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebAPIApplication.Models;
using WebAPIApplication.Service;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService productService;
        public ProductController(IProductService _ProductService)
        {
            productService = _ProductService;
        }


        [HttpGet("/api/Product")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var products = await productService.GetProduct();
                if (products == null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet("/api/Product/{id}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            try
            {
                var post = await productService.GetProduct(Id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("/api/Product")]
        public async Task<IActionResult> AddProduct([FromBody] Product Product)
        {
            try
            {
                var postId = await productService.AddProduct(Product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();

        }


        [HttpPut("/api/Product")]
        public async Task<IActionResult> PutProduct([FromBody] Product Product)
        {
            try
            {
                await productService.PutProduct(Product);

                return Ok();
            }
            catch (Exception)

            {
                return BadRequest();
            }

        }

        [HttpPatch("/api/Product")]
        public async Task<IActionResult> PatchProduct([FromBody] Product Product)
        {

            try
            {
                await productService.PatchProduct(Product);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpDelete("/api/Product/{id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            int result = 0;
            try
            {
                result = await productService.DeleteProduct(Id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
