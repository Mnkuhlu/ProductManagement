/*
    Phase 1 - Stored procedures backing the Dapper repository.
    All C# data access goes through these - no inline SQL in the app.
*/

CREATE  PROCEDURE dbo.usp_Product_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductId, ProductName, ProductCategory, SupplierName, Price, CreatedDate, ModifiedDate
    FROM dbo.Product
    ORDER BY ProductId DESC;
END
GO

CREATE  PROCEDURE dbo.usp_Product_GetById
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductId, ProductName, ProductCategory, SupplierName, Price, CreatedDate, ModifiedDate
    FROM dbo.Product
    WHERE ProductId = @ProductId;
END
GO

CREATE  PROCEDURE dbo.usp_Product_Insert
    @ProductName     NVARCHAR(200),
    @ProductCategory NVARCHAR(100),
    @SupplierName    NVARCHAR(200),
    @Price           DECIMAL(18,2),
    @NewProductId    INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Product (ProductName, ProductCategory, SupplierName, Price, CreatedDate)
    VALUES (@ProductName, @ProductCategory, @SupplierName, @Price, SYSUTCDATETIME());

    SET @NewProductId = SCOPE_IDENTITY();
END
GO

CREATE  PROCEDURE dbo.usp_Product_Update
    @ProductId       INT,
    @ProductName     NVARCHAR(200),
    @ProductCategory NVARCHAR(100),
    @SupplierName    NVARCHAR(200),
    @Price           DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Product
    SET ProductName     = @ProductName,
        ProductCategory  = @ProductCategory,
        SupplierName     = @SupplierName,
        Price            = @Price,
        ModifiedDate     = SYSUTCDATETIME()
    WHERE ProductId = @ProductId;
END
GO

CREATE  PROCEDURE dbo.usp_Product_Delete
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Product
    WHERE ProductId = @ProductId;
END
GO
