using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adiciona o swagger do dotnet para visualizar
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(

    //Define uma novo servidor openAPI que podemos utilizar para chamar o angular
    c =>
    {
        c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
        {
            Description = "Development Server",
            Url = "https://localhost:7280"
        }
        );

        c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"] + e.ActionDescriptor.RouteValues["controller"]}");
    }
    );



var app = builder.Build();
app.UseCors(builder => builder
.WithOrigins("*")
.AllowAnyMethod()
.AllowAnyHeader()
); //Permitindo cors para todas as origens

app.UseSwagger().UseSwaggerUI();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
