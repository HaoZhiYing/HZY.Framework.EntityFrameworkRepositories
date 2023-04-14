using HZY.Framework.EntityFrameworkRepositories;
using HZY.Framework.EntityFrameworkRepositories.Test.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ȡ������֤
builder.Host.UseDefaultServiceProvider(options => { options.ValidateScopes = false; });
builder.Services.AddDbContextPool<AppDbContext>((serviceProvider, options) =>
   {
       //
       //options.AddEntityFrameworkRepositories();

       options.UseSqlServer(@"Server=.;Database=hzy_admin_sqlserver_20220526;User ID=sa;Password=123456;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;");
       options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

   });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

EntityFrameworkRepositoriesUtil.UseEntityFrameworkRepositories(typeof(AppDbContext1));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
