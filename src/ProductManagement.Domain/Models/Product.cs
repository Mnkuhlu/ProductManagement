namespace ProductManagement.Domain.Models;

/// <summary>
/// Represents a row in the master Product data table.
/// ProductId is identity/PK in SQL Server and is the value used
/// for all subsequent update/delete operations.
/// </summary>
public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string ProductCategory { get; set; } = string.Empty;

    public string SupplierName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

/// <summary>
/// DTO used when creating a new product (no ProductId yet — SQL Server assigns it).
/// </summary>
public class ProductCreateDto
{
    public string ProductName { get; set; } = string.Empty;
    public string ProductCategory { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

/// <summary>
/// DTO used when editing an existing product. ProductId is required
/// so the stored procedure knows which row to update.
/// </summary>
public class ProductUpdateDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductCategory { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
