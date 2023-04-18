using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoteBookWebApi.Context;
using NoteBookWebApi.Context.Repository;
using NoteBookWebApi.Context.UnitOfWork;
using NoteBookWebApi.Extensions;
using NoteBookWebApi.Migrations;
using NoteBookWebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var autoMapperconfig = new MapperConfiguration(cfg => { 
    cfg.AddMaps(new[] { typeof(AutoMapperProFile) });
});

builder.Services.AddSingleton(autoMapperconfig.CreateMapper());

builder.Services.AddDbContext<MyNoteBookContext>(opt => {
    string connStr = builder.Configuration.GetConnectionString("MyNoteConnection");
    opt.UseSqlite(connStr);
}).AddUnitOfWork<MyNoteBookContext>()
.AddCustomRepository<Memo,MemoRepository>()
.AddCustomRepository<NoteBookWebApi.Context.NoteBook, MyNoteBookRepository>()
.AddCustomRepository<User, UserRepository>();

builder.Services.AddScoped<NoteBookService>();
builder.Services.AddScoped<MemoService>();
builder.Services.AddScoped<LoginService>();

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
