/*
    Phase 1 - Master Product table
    Run this once against your target SQL Server database.
*/

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Product')
BEGIN
    CREATE TABLE dbo.Product
    (
        ProductId         INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ProductName       NVARCHAR(200)     NOT NULL,
        ProductCategory   NVARCHAR(100)     NOT NULL,
        SupplierName      NVARCHAR(200)     NOT NULL,
        Price             DECIMAL(18,2)     NOT NULL DEFAULT 0,
        CreatedDate       DATETIME2         NOT NULL DEFAULT SYSUTCDATETIME(),
        ModifiedDate      DATETIME2         NULL
    );
END
GO
