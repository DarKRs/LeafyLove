using LeafyLove.Domain.Models;
using LeafyLove.ViewModels;
using LeafyLove.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LeafyLove
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            StartDialog dialog = new StartDialog();
            if (dialog.ShowDialog() == true)
            {
                // Создание растения с именем из диалогового окна
                var plantName = dialog.PlantName;

                // Создайте ViewModel с полученным именем растения
                var viewModel = new PlantViewModel(plantName);

                // Создайте и покажите MainWindow, передав ViewModel через DataContext
                var mainWindow = new MainWindow
                {
                    DataContext = viewModel
                };
                this.ShutdownMode = ShutdownMode.OnLastWindowClose;
                mainWindow.Show();
            }
            else
            {
                // Пользователь закрыл диалоговое окно без ввода имени, можно закрыть приложение или обработать иначе
                this.Shutdown();
            }
        }
    }
}
