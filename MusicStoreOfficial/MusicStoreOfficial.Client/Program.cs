using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicStoreOfficial.Client.Services;
using MusicStoreOfficial.Client.ViewModel;
using SharedLibrary.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IAlbumRepository, AlbumService>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddMvvm();
builder.Services.AddScoped<AddAlbumViewModel>();
builder.Services.AddScoped<EditAlbumViewModel>();
builder.Services.AddScoped<DeleteAlbumViewModel>();

await builder.Build().RunAsync();
