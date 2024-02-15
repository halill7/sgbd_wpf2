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

namespace Page_Navigation_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Si l'utilisateur appuie sur le bouton gauche de la souris, commencez à déplacer la fenêtre
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void ToggleFullScreen_Click(object sender, RoutedEventArgs e)
        {
            // Basculer entre le mode plein écran et le mode normal
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized; // Mettre en plein écran
            }
            else
            {
                WindowState = WindowState.Normal; // Retour au mode normal
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
