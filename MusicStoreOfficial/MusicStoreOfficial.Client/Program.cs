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

await builder.Build().RunAsync();
