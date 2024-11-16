using CropMS.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//---------LOAD USER SECRETS IN DEVELOPMENT MODE------
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();

}


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-------REGISTERING OUR SERVICES FOR DI-------
//-------1. DB CONTEXT TO THE DI CONTAINER
builder.Services.AddDbContext<CropDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CropConnection") ?? throw new InvalidOperationException("Connection string not found"));
});
//---------2. VET SERVICES TO THE DI--------
//builder.Services.AddScoped<IVeterinaryService, VeterinaryService>();
//---------3. AUTOMAPPER ----------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
