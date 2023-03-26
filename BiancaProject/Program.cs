using BiancaProject.Services;

var menu = new MenuService();

while (true)
    await menu.MainMenu();