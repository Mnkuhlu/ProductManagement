using System.Data;
using Dapper;
using ProductManagement.Domain.Models;

namespace ProductManagement.Data.Repositories;

/// <summary>
/// All calls go through stored procedures (see database/02_StoredProcedures.sql)
/// rather than inline SQL, per the agreed design.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DapperContext _context;

    public ProductRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Product>(
            "dbo.usp_Product_GetAll",
            commandType: CommandType.StoredProcedure);
    }

    public async Task<Product?> GetByIdAsync(int productId)
    {
        using var connection = _context.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("ProductId", productId);

        return await connection.QueryFirstOrDefaultAsync<Product>(
            "dbo.usp_Product_GetById",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<int> AddAsync(ProductCreateDto product)
    {
        using var connection = _context.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("ProductName", product.ProductName);
        parameters.Add("ProductCategory", product.ProductCategory);
        parameters.Add("SupplierName", product.SupplierName);
        parameters.Add("Price", product.Price);
        parameters.Add("NewProductId", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await connection.ExecuteAsync(
            "dbo.usp_Product_Insert",
            parameters,
            commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("NewProductId");
    }

    public async Task<int> UpdateAsync(ProductUpdateDto product)
    {
        using var connection = _context.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("ProductId", product.ProductId);
        parameters.Add("ProductName", product.ProductName);
        parameters.Add("ProductCategory", product.ProductCategory);
        parameters.Add("SupplierName", product.SupplierName);
        parameters.Add("Price", product.Price);

        return await connection.ExecuteAsync(
            "dbo.usp_Product_Update",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<int> DeleteAsync(int productId)
    {
        using var connection = _context.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("ProductId", productId);

        return await connection.ExecuteAsync(
            "dbo.usp_Product_Delete",
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
