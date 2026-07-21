using ProductManagement.Data;
using ProductManagement.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Blazor Server (Razor Pages hosting model)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Data access - Dapper
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
