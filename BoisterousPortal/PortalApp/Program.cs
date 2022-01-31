using BooksRelational.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

PortalApp.AppSetup.SetupServices(builder);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        optionBuilder =>
        {
            optionBuilder.WithOrigins("http://example.com",
                                "http://www.contoso.com",
                                "http://localhost");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(corsBuilder =>
    corsBuilder.WithOrigins(new string []{ "http://localhost:4200", "https://localhost:4200", "*" })
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod());

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
var contextFactory = new BooksRelationalContextFactory();
using (var client = contextFactory.CreateDbContext(new string[] { }))
{
    client.Database.EnsureCreated();
}

app.Run();
