# Product Management

A Blazor Server (Razor Pages host) + Dapper + SQL Server CRUD app for a master Product data table.

Built and checked in **incrementally, phase by phase**, as a work-in-progress project.

## Architecture

- **ProductManagement.Domain** - POCOs / DTOs, no dependencies.
- **ProductManagement.Data** - `DapperContext` + `IProductRepository` / `ProductRepository`. All SQL access goes through stored procedures in `/database`, called via Dapper. No inline SQL in the app.
- **ProductManagement.Web** - Blazor Server app. Grid, Add Product form, and the Edit/Delete popup live here.
- **/database** - SQL scripts: table creation + stored procedures (`usp_Product_GetAll`, `GetById`, `Insert`, `Update`, `Delete`).

## Getting started locally

1. Run `database/01_CreateTables.sql` then `database/02_StoredProcedures.sql` against your SQL Server instance.
2. Update the `ConnectionStrings:ProductDatabase` value in `src/ProductManagement.Web/appsettings.json`.
3. `dotnet restore` then `dotnet run --project src/ProductManagement.Web`.
4. Browse to `/products`.

## Roadmap / Phases

- [x] **Phase 1 - Skeleton & startup**: solution/project structure, SQL schema + stored procs, `DapperContext`, `IProductRepository`/`ProductRepository`, DI wiring in `Program.cs`, and a placeholder `/products` page that proves the pipeline end-to-end.
- [ ] **Phase 2 - Product grid**: real Blazor grid on `/products` showing all products, with the `ProductId` column rendered as a clickable link.
- [ ] **Phase 3 - Add Product**: form/page to add a new product, calling `usp_Product_Insert` via the repository, refreshing the grid with the new `ProductId`.
- [ ] **Phase 4 - Edit/Delete popup**: clicking a `ProductId` opens a modal pre-populated with that product's data (via `usp_Product_GetById`). Submitting saves changes via `usp_Product_Update`. A "Delete" checkbox in the same modal, when checked and submitted, calls `usp_Product_Delete` instead.
- [ ] **Phase 5 - Validation & polish**: input validation, error handling/toasts, loading states, and any supplier-table normalization if needed.

Each phase is committed separately so history reflects the build-up of the app.
