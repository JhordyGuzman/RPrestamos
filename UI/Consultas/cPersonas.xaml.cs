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
using RPrestamos.Entidades;
using RPrestamos.DAL;
using RPrestamos.BLL;

namespace RPrestamos.UI.Consultas
{
    public partial class cPersonas : Window
    {
           
        public cPersonas()
        {
            InitializeComponent();
        }

          private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Datos.ItemsSource = null;
            var listado = new List<Personas>();

            if (DesdeDatePicker.SelectedDate != null)
            {
                listado = PersonasBLL.GetList(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate);
            }
            else
            {
                listado = PersonasBLL.GetList(c => true);
            }

            if (HastaDatePicker.SelectedDate != null)
            {
                listado = PersonasBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }
            else
            {
                listado = PersonasBLL.GetList(c => true);
            }
            Datos.ItemsSource = listado;
        }



    
    }
}