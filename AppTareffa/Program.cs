using AppTareffa.Data;
using AppTareffa.Repositorios;
using AppTareffa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conexao com o banco
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<TarefasDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

//AQUI VAI CHAMAR O CONTRUTOR "i" E DEPOIS INSTANCIA A OUTRA 
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();


builder.Services.AddAuthorization();
builder.Services.AddControllers();


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
