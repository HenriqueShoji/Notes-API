using NoteAPI.Repositories;
using NoteAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<NoteDatabaseSettings>(builder.Configuration.GetSection("NotesDataBase"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowReactApp", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .Build();
    });
});

builder.Services.AddTransient<NoteServices, NoteServices>();
builder.Services.AddScoped<NoteServices, NoteServices>();
builder.Services.AddTransient<NoteRepositories, NoteRepositories>();
builder.Services.AddScoped<NoteRepositories, NoteRepositories>();
builder.Services.AddTransient<NoteDatabaseContext, NoteDatabaseContext>();
builder.Services.AddScoped<NoteDatabaseContext, NoteDatabaseContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
