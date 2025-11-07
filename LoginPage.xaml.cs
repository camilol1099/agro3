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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gui
{
    /// <summary>
    /// Lógica de interacción para LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        PersonaService personaService = new PersonaService();
        

        public LoginPage()
        {
            InitializeComponent();
            this.Loaded += (s, e) => txbId.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txbId.Text);
                string contrasena = txbContra.Password;

                Persona persona = personaService.ObtenerPorId(id);

                if (persona == null)
                {
                    MessageBox.Show("Usuario no encontrado. Regístrese primero.");
                    return;
                }

                if (persona.Contraseña != contrasena)
                {
                    MessageBox.Show("Contraseña incorrecta ❌");
                    return;
                }

             
                MessageBox.Show($"Bienvenido, {persona.Nombre}");

              
                if (persona.TipoUsuario == "Administrador")
                {
                    MessageBox.Show("Acceso de administrador concedido.");
                    AdmminView adminView = new AdmminView();
                    adminView.Show();
                    Window.GetWindow(this)?.Close();
                }
                else if (persona.TipoUsuario == "Empleado")
                {
                    MessageBox.Show("Acceso de empleado concedido.");
                    EmpleadoView empleadoView = new EmpleadoView();
                    empleadoView.Show();
                    Window.GetWindow(this)?.Close();


                }
                else
                {
                    
                    MessageBox.Show("Tipo de usuario no reconocido.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un ID numérico válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            
                NavigationService.Navigate(new MenuPage());
            
        }

        private void TxbId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Mover foco al campo de contraseña
                txbContra.Focus();
                e.Handled = true;
            }
        }
        private void TxbContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Ejecutar el login al presionar Enter
                LoginButton_Click(sender, e);
                e.Handled = true;
            }
        }
        private void TxbId_GotFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)((TextBox)sender).Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F5233"));
                border.BorderThickness = new Thickness(2);
            }
        }

        private void TxbId_LostFocus(object sender, RoutedEventArgs e)
        {
            var border = ((Grid)((TextBox)sender).Parent).Parent as Border;
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
                border.BorderThickness = new Thickness(1.5);
            }
        }

        private void TxbContra_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2F5233"));
            PasswordBorder.BorderThickness = new Thickness(2);
        }

        private void TxbContra_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB"));
            PasswordBorder.BorderThickness = new Thickness(1.5);
        }
    }
}
