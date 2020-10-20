using System.Windows;
using RPrestamos.Entidades;
using RPrestamos.BLL;

namespace RPrestamos.UI.Registros
{
    public partial class rPrestamos : Window
    {
        Prestamos prestamos = new Prestamos();

        public rPrestamos()
        {
            InitializeComponent();
            PersonaIdComboBox.ItemsSource= PersonasBLL.GetList(p =>true);
            PersonaIdComboBox.SelectedValuePath= "PersonaId";
            PersonaIdComboBox.DisplayMemberPath="Nombres";
            prestamos.Monto += prestamos.Balance;
            this.DataContext = prestamos;
            
            
        //   Personas personas = new Personas();
          

        }

        

        private void Limpiar(){
            this.prestamos = new Prestamos();
            this.DataContext = prestamos;
        }

        private bool Validar(){
            bool esValido = true;

            if (ConceptoTextBox.Text.Length == 0){   
                esValido = false;
                MessageBox.Show("Transaccion Fallida","Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e){
            var prestamo = PrestamosBLL.Buscar(Utilidades.ToInt(PrestamoIdTextBox.Text));

            if (prestamo != null)
                this.prestamos= prestamo;
            else    
                this.prestamos = new Prestamos();

                this.DataContext = this.prestamos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

     private void GuardarButton_Click(object sender, RoutedEventArgs e){
            
            if(!Validar()){
                return;
            }
            var paso = PrestamosBLL.Guardar(prestamos);

            if(paso){
                Limpiar();
                MessageBox.Show("Transaccion exitosa!" , "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else{
                MessageBox.Show("Transaccion Fallida", "Fallo",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e){
            if (PrestamosBLL.Eliminar(Utilidades.ToInt(PrestamoIdTextBox.Text))){
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }
}