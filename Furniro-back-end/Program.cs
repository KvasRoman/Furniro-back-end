using Furniro.BusinessLogic.DefaultIfEmpty;
using Furniro.BusinessLogic.Email;
using Furniro.DataAccess;
using Furniro.DataAccess.Models.DataAccess;
using Furniro_back_end.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
#region Config
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
var imageConfig = builder.Configuration.GetSection("DefaultImages")
    .Get<DefaultImagesConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddSingleton(imageConfig);
#endregion
#region CustomServices
builder.Services.AddScoped<IEmailSender, EmailSender>();
#endregion
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
#region DbContext
builder.Services.AddDbContext<FurniroDbContext>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
#endregion
#region Repos
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ProductImageRepository));
builder.Services.AddScoped(typeof(IRepository<Product>),typeof(ProductRepository));
builder.Services.AddScoped(typeof(ProductCardRepository));
#endregion
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(builder.Configuration.GetSection("CorsAllowed:Default").Value)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x =>
{
        x.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
