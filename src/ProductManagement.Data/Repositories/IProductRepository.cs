using ProductManagement.Domain.Models;

namespace ProductManagement.Data.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int productId);

    /// <summary>Inserts a new product and returns the generated ProductId.</summary>
    Task<int> AddAsync(ProductCreateDto product);

    /// <summary>Updates an existing product by ProductId. Returns rows affected.</summary>
    Task<int> UpdateAsync(ProductUpdateDto product);

    /// <summary>Deletes a product by ProductId. Returns rows affected.</summary>
    Task<int> DeleteAsync(int productId);
}
