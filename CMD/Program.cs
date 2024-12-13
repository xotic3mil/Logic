using Logic.Interfaces;
using Logic.Services;
using CMD.Menu;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("Data", "users.json"))
    .AddSingleton<IUserService, UserService>()
    .AddTransient<MenuService>()
    .BuildServiceProvider();

var menuService = serviceProvider.GetRequiredService<MenuService>();
menuService.MainMenu();

