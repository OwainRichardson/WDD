using WDD.Repositories.Interfaces;
using WDD.Repositories.Repositories;
using WDD.Services.Interfaces;
using WDD.Services.Services;

string AllowLocalhostInterviewOrigin = "_allowLocalhostInterviewOrigin";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPhoneBookDatabase, PhoneBookDatabase>();
builder.Services.AddTransient<IPhoneBookRepository, PhoneBookRepository>();

builder.Services.AddTransient<IPhoneBookService, PhoneBookService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowLocalhostInterviewOrigin,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowLocalhostInterviewOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
