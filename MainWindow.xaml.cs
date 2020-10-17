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
using RPrestamos.UI.Registros;
using RPrestamos.UI.Consultas;

namespace RPrestamos
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void RegistrosPersonas_Click(object sender, RoutedEventArgs e)
        {
            rPersonas ventana = new rPersonas();
            ventana.Show();
        }

        private void RegistrosPrestamos_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos ventana = new rPrestamos();
            ventana.Show();
        }

          private void ConsultasPersonas_Click(object sender, RoutedEventArgs e)
        {
            cPersonas ventana = new cPersonas();
            ventana.Show();
        }

          private void ConsultasPrestamos_Click(object sender, RoutedEventArgs e)
        {
            cPrestamos ventana = new cPrestamos();
            ventana.Show();
        }


           private void RegistrosMoras_Click(object sender, RoutedEventArgs e)
        {
            rMoras ventana = new rMoras();
            ventana.Show();
        }
    }
}
