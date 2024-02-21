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
using System.Windows.Shapes;

namespace LeafyLove.Views
{
    /// <summary>
    /// Логика взаимодействия для StartDialog.xaml
    /// </summary>
    public partial class StartDialog : Window
    {
        public string PlantName { get; private set; }

        public StartDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            PlantName = PlantNameTextBox.Text;
            this.DialogResult = true;
        }
    }
}
