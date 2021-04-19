using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MMTApplication.Models;

namespace MMTApplication.Data
{
  public interface IMMTRepository
  {
    // General 
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();

    // Camps
    Task<Product[]> GetAllProductsAsync();
    Task<Product[]> GetAllProductsByCategoryAsync(int categoryId);
    List<Product> GetAllFeaturedProducts(List<string> featuredCategory);
        

    }
}