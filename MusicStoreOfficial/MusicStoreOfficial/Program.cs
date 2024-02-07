using Microsoft.EntityFrameworkCore;
using MusicStoreOfficial.Client.Pages;
using MusicStoreOfficial.Client.Services;
using MusicStoreOfficial.Client.ViewModel;
using MusicStoreOfficial.Components;
using MusicStoreOfficial.DataContext;
using MusicStoreOfficial.ViewModel;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddDbContext<DbCtx>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString(
            "DefaultConnection")));

builder.Services.AddMvvm();
builder.Services.AddScoped<IAlbumRepository, AlbumService>();
builder.Services.AddScoped<AddAlbumViewModel>();
builder.Services.AddScoped<EditAlbumViewModel>();
builder.Services.AddScoped<DeleteAlbumViewModel>();


builder.Services.AddScoped<IAlbumRepository,AlbumRepositoryVM>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
}) ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MusicStoreOfficial.Client._Imports).Assembly);

app.Run();
