using LeafyLove.Domain.Models;
using LeafyLove.ViewModels;
using LeafyLove.Views;
using LeafyLove.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LeafyLove.Models;

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

            if (Settings.Default.FirstRun)
            {
                StartDialog dialog = new StartDialog();
                if (dialog.ShowDialog() == true)
                {
                    // Сохранение имени растения для последующих запусков
                    Settings.Default.PlantName = dialog.PlantName;
                    Settings.Default.FirstRun = false;
                    Settings.Default.Save();
                }
                else
                {
                    Shutdown();
                    return;
                }
            }

            string plantName = Settings.Default.PlantName;
            User mainUser = new User(plantName);
            var mainWindow = new MainWindow(mainUser);

            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
            mainWindow.Show();
        }
    }
}
