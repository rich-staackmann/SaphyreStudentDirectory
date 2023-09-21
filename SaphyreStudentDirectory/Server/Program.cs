using Microsoft.EntityFrameworkCore;
using SaphyreStudentDirectory.DAL.Repositories;
using SaphyreStudentDirectory.Domain.Services;
using SaphyreStudentDirectory.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddDbContext<StudentContext>(options =>
        options.UseSqlite("Data Source=students.db"));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentContext>();
    db.Database.EnsureDeleted();
    if (db != null && db.Database.EnsureCreated())
    {
        // For the sake of simplicity and portability I am going with the EnsureCreated() call
        // Obviously EF Core in production would want to move to Migrations
        SeedData.Initialize(db);
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
