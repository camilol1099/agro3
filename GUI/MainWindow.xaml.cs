using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace GUI
{
    
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               
                DragMove();
            }
        }

        
        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Has hecho clic en Ingresar a mi cuenta", "AgroSmart");
        }

        
        private void CrearCuentaButton_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Has hecho clic en Crear cuenta (registrarme)", "AgroSmart");
        }
    }
}
