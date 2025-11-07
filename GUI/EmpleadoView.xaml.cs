using BLL;
using Entidades;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Navigation;


namespace Gui
{
    /// <summary>
    /// Lógica de interacción para EmpleadoView.xaml
    /// </summary>
    public partial class EmpleadoView : Window
    {
        PersonaService personaService = new PersonaService();
       
        public EmpleadoView()
        {
            InitializeComponent();

           EmpleadoFrame.Content = new EmpleadoPage();
        }
        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuListBox.SelectedItem is ListBoxItem item)
            {
                string tag = item.Tag.ToString();

                switch (tag)
                {
                    case "🏠":
                        EmpleadoFrame.Navigate(new EmpleadoPage());

                        break;
                    case "📈":
                        EmpleadoFrame.Navigate(new ProgresoPage());
                        break;
                    case "👤":
                        EmpleadoFrame.Navigate(new PerfilPage());
                        break;
                    case "❓":
                        EmpleadoFrame.Navigate(new AyudaPage());
                        break;
                }
            }
        }
        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "¿Estás seguro que deseas cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Aquí puedes volver a tu MainWindow o LoginPage
                 MainWindow mainWindow = new MainWindow();
                 mainWindow.Show();
                this.Close();
            }
        }


    }
}
