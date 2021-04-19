using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MMTApplication.Models;

namespace MMTApplication.Data
{
  public class MmtRepository : IMMTRepository
  {
    private readonly MMTContext _context;
    private readonly ILogger<MmtRepository> _logger;

    public MmtRepository(MMTContext context, ILogger<MmtRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public void Add<T>(T entity) where T : class 
    {
      _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T: class
    {
      _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
      _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      _logger.LogInformation($"Attempitng to save the changes in the context");

      // Only return success if at least one row was changed
      return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<Product[]> GetAllProductsAsync()
    {
      _logger.LogInformation($"Getting all Products");
            IQueryable<Product> query = _context.Products;       

      return await query.ToArrayAsync();
    }
    public async Task<Product[]> GetAllProductsByCategoryAsync(int categoryId)
    {
      _logger.LogInformation($"Getting all Products By Category");
            IQueryable<Product> query = _context.Products
                              .FromSqlRaw<Product>($"GetProdutsByCategory {categoryId}");                              

     return await query.ToArrayAsync();
    }
    public List<Product> GetAllFeaturedProducts(List<string> featuredCategory)
    {
           _logger.LogInformation($"Getting all Featured Products");            
            IQueryable<Product> query = _context.Products;
            IQueryable<Product> featuredQueryResults;
            List<Product> featuredList = new List<Product>();

            foreach (var featuredProduct in featuredCategory)
            {
                string str = featuredProduct.Substring(0, 1);
                featuredQueryResults = query.Where(r => r.SKU.StartsWith(str));
                List<Product> list = featuredQueryResults.ToList();
                featuredList.AddRange(list);                
            }
           
            return featuredList;
    }
        

  }
}
