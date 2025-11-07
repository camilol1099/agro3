using System.Windows;
using System.Windows.Controls;

namespace Gui
{
    public partial class AdmminView : Window
    {
        public AdmminView()
        {
            InitializeComponent();

            // Seleccionar el primer item por defecto (Dashboard)
            MenuListBox.SelectedIndex = 0;

            // Cargar página inicial si tienes una
            // MainContentFrame.Navigate(new DashboardPage());
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuListBox.SelectedItem == null) return;

            var selectedItem = MenuListBox.SelectedItem as ListBoxItem;
            string menuText = selectedItem.Content.ToString();

            // Deseleccionar el otro ListBox
            SystemMenuListBox.SelectedIndex = -1;

            switch (menuText)
            {
                case "Dashboard":
                    // MainContentFrame.Navigate(new DashboardPage());
                    break;
                case "Empleados":
                    // MainContentFrame.Navigate(new EmpleadosPage());
                    break;
                case "Inventario":
                    // MainContentFrame.Navigate(new InventarioPage());
                    break;
                case "Cultivos":
                    // MainContentFrame.Navigate(new CultivosPage());
                    break;
                case "Tareas":
                    // MainContentFrame.Navigate(new TareasPage());
                    break;
                case "Reportes":
                    // MainContentFrame.Navigate(new ReportesPage());
                    break;
            }
        }

        private void SystemMenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SystemMenuListBox.SelectedItem == null) return;

            var selectedItem = SystemMenuListBox.SelectedItem as ListBoxItem;
            string menuText = selectedItem.Content.ToString();

            // Deseleccionar el otro ListBox
            MenuListBox.SelectedIndex = -1;

            switch (menuText)
            {
                case "Perfil":
                    // MainContentFrame.Navigate(new PerfilAdminPage());
                    break;
                case "Configuración":
                    // MainContentFrame.Navigate(new ConfiguracionPage());
                    break;
                case "Ayuda":
                    // MainContentFrame.Navigate(new AyudaPage());
                    break;
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
                // MainWindow mainWindow = new MainWindow();
                // mainWindow.Show();
                this.Close();
            }
        }
    }
}
