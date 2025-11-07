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
    /// Lógica de interacción para AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        private Persona persona;

        public AdminPage(Persona persona)
        {
            InitializeComponent();
            this.persona = persona;
            txtBienvenida.Text = $"Bienvenido Administrador, {persona.Nombre}";
        }

        private void BtnIrEmpleados_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí podrías abrir la gestión de empleados.");
        }
    }
}
