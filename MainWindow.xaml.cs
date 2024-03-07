using LeafyLove.Domain.Models;
using LeafyLove.Models;
using LeafyLove.Utilities;
using LeafyLove.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LeafyLove
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer backgroundUpdateTimer;

        public MainWindow(User user)
        {
            InitializeComponent();

            var plantViewModel = new PlantViewModel(user);
            this.DataContext = plantViewModel;

            var storeViewModel = new StoreViewModel(user);
            StoreTab.DataContext = storeViewModel;

        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is StackPanel panel && panel.DataContext is Plant plant)
            {
                var viewModel = this.DataContext as PlantViewModel;
                viewModel.SelectedPlant = plant;
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is StackPanel panel && panel.DataContext is Plant plant)
            {
                var viewModel = this.DataContext as PlantViewModel;
                viewModel.SelectedPlant = null;
            }
        }


    }


}
