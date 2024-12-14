using Logic.Interfaces;
using Logic.Services;
using CMD.Menu;
using Microsoft.Extensions.DependencyInjection;
using Logic.Repositories;


var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("Data", "users.json"))
    .AddSingleton<IFileRepository, FileRepository>()
    .AddSingleton<IUserService, UserService>()
    .AddTransient<MenuService>()
    .BuildServiceProvider();

var menuService = serviceProvider.GetRequiredService<MenuService>();
menuService.MainMenu();

