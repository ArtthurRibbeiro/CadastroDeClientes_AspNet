using CadastroDeClientes.Data;
using CadastroDeClientes.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
        .AddRazorRuntimeCompilation();

builder.Services.AddHttpClient();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Clientes", Version = "v1" });
});

//Conexão com banco

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<BancoContext>(item => item.UseSqlServer(configuration.GetConnectionString("DataBase")));
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //swagger
    app.UseDeveloperExceptionPage();
    app.UseSwagger();


    app.MapSwagger().RequireAuthorization();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Clientes v1"));

    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/swagger")
        {
            context.Response.Redirect("/swagger/index.html");
            return;

        }
        await next();

    });
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
