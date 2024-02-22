using LeafyLove.Domain.Models;
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

namespace LeafyLove
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is StackPanel panel && panel.DataContext is Plant plant)
            {
                panel.Style = (Style)FindResource("HighlightStyle");
                // Предполагая, что у вас есть доступ к ViewModel через DataContext или через другой механизм
                var viewModel = this.DataContext as PlantViewModel;
                viewModel.SelectedPlant = plant;
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is StackPanel panel && panel.DataContext is Plant plant)
            {
                panel.Style = null;
                // Предполагая, что у вас есть доступ к ViewModel через DataContext или через другой механизм
                var viewModel = this.DataContext as PlantViewModel;
                viewModel.SelectedPlant = null;
            }
        }
    }


}
