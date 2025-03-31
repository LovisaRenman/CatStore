using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using CatStore.Components;
using CatStore.Services;
using CatStore.Context;

var builder = WebApplication.CreateBuilder(args);


// Add MudBlazor services
builder.Services.AddMudServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("CatEquipmentStore", client =>
{
    client.BaseAddress = new Uri("https://localhost:7099");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<CatContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatStore")));

var connectionString = builder.Configuration.GetConnectionString("CatStore");
if (string.IsNullOrEmpty(connectionString))
    throw new Exception("Connection string not found");

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CatStore.Client._Imports).Assembly);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
