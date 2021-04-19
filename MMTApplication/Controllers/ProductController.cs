using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMTApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MMTApplication.Models;

namespace MMTApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMMTRepository _repository;
        private readonly ILogger<ProductController> _logger;
        public IConfiguration _config { get; set; }
        public ProductController(IMMTRepository repository, ILogger<ProductController> logger , IConfiguration config)
        {
            _repository = repository;
            _logger = logger;
            _config = config;
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<Product[]>> GetProducts()
        {
            try
            {
                var results = await _repository.GetAllProductsAsync();
                return results;             
            }
            catch (Exception ex)
            {
                _logger.LogInformation($" Error in getting all Products");                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failuer");
            }
        }
        [HttpGet]
        [Route("GetProductByCategoryId/{categoryId:int=3}")]
        public async Task<ActionResult<Product[]>> GetProductByCategoryId(int categoryId)
        {
            try
            {
                var results = await _repository.GetAllProductsByCategoryAsync(categoryId);
                return results;               
            }
            catch (Exception ex)
            {
                _logger.LogInformation($" Error in getting Products By Category");
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failuer");
            }
        }
        [HttpGet]
        [Route("GetFeaturedProducts")]
        public  List<Product> GetFeaturedProducts()
        {
            List<string> featuredCategory = this._config.GetSection("FeaturedProducts")?.GetChildren()?.Select(x => x.Value)?.ToList();
            List<Product> results = null;
            try
            {
                results =  _repository.GetAllFeaturedProducts(featuredCategory);
                return results;
            }
            catch (Exception ex)
            {                
                _logger.LogInformation($" Error in getting Featured Products");
                return results ;
            }            

        }

       
    }
}
