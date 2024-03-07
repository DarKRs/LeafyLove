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
using System.Text.Json;
using System.IO;

namespace LeafyLove
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private User mainUser;

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
            mainUser = LoadUserData() ?? new User(plantName);
            var mainWindow = new MainWindow(mainUser);

            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
            mainWindow.Show();
        }

        public void SaveUserData(User user)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(user, options);
            File.WriteAllText("user_data.json", json);
        }

        public User LoadUserData()
        {
            if (File.Exists("user_data.json"))
            {
                string json = File.ReadAllText("user_data.json");
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                    WriteIndented = true
                };
                return JsonSerializer.Deserialize<User>(json,options);
            }
            return null; // или создать нового пользователя, если файл не найден
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            SaveUserData(mainUser); // Убедитесь, что у вас есть доступ к текущему пользователю
        }

        public void ResetUserAndReloadUI()
        {
            Settings.Default.FirstRun = true;
            Settings.Default.PlantName = "";

            Current.MainWindow.Hide();
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

            string plantName = Settings.Default.PlantName;

            mainUser = new User(plantName); 
            SaveUserData(mainUser);


            var mainWindow = new MainWindow(mainUser);
            Current.MainWindow.Close();
            Current.MainWindow = mainWindow; 
            mainWindow.Show();
        }

    }
}
