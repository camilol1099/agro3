using BLL;
using Entidades;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gui
{
    /// <summary>
    /// Lógica de interacción para RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        PersonaService personaService = new PersonaService();

        public RegisterPage()
        {
            InitializeComponent();
            this.Loaded += (s, e) => TxbId.Focus();
        }


        private void TxbId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txbNom.Focus();
                e.Handled = true;
            }
        }

        private void TxbNom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txbApel.Focus();
                e.Handled = true;
            }
        }

        private void TxbApel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txbEmail.Focus();
                e.Handled = true;
            }
        }

        private void TxbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txbContra.Focus();
                e.Handled = true;
            }
        }

        private void TxbContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e);
                e.Handled = true;
            }
        }

        // Eventos GotFocus para cambiar color del borde
        private void TxbId_GotFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)TxbId.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00A859"));
                border.BorderThickness = new Thickness(2);
            }
        }

        private void TxbNom_GotFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbNom.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00A859"));
                border.BorderThickness = new Thickness(2);
            }
        }

        private void TxbApel_GotFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbApel.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00A859"));
                border.BorderThickness = new Thickness(2);
            }
        }

        private void TxbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbEmail.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00A859"));
                border.BorderThickness = new Thickness(2);
            }
        }

        private void TxbContra_GotFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbContra.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00A859"));
                border.BorderThickness = new Thickness(2);
            }
        }

        // Eventos LostFocus para restaurar color del borde
        private void TxbId_LostFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)TxbId.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
                border.BorderThickness = new Thickness(1.5);
            }
        }

        private void TxbNom_LostFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbNom.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
                border.BorderThickness = new Thickness(1.5);
            }
        }

        private void TxbApel_LostFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbApel.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
                border.BorderThickness = new Thickness(1.5);
            }
        }

        private void TxbEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbEmail.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
                border.BorderThickness = new Thickness(1.5);
            }
        }

        private void TxbContra_LostFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)txbContra.Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
                border.BorderThickness = new Thickness(1.5);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Persona persona = new Persona
                {
                    Id = int.Parse(TxbId.Text),
                    Nombre = txbNom.Text,
                    Apellido = txbApel.Text,
                    Email = txbEmail.Text,
                    Contraseña = txbContra.Password,
                    TipoUsuario = "Empleado"
                };

                string mensaje = personaService.Guardar(persona);
                MessageBox.Show(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BackButon_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
