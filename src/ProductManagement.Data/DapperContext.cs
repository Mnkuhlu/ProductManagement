using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ProductManagement.Data;

/// <summary>
/// Creates raw ADO.NET connections for Dapper to use.
/// Registered as a singleton in DI; each repository call opens/closes
/// its own connection (Dapper handles that internally when you pass
/// an unopened connection).
/// </summary>
public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ProductDatabase")
            ?? throw new InvalidOperationException(
                "Connection string 'ProductDatabase' was not found in configuration.");
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}
