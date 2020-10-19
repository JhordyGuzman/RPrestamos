using System.Windows;
using RPrestamos.Entidades;
using RPrestamos.BLL;

namespace RPrestamos.UI.Registros
{
    public partial class rPersonas : Window
    {
        Personas personas = new Personas();

        public rPersonas()
        {
            InitializeComponent();
            this.DataContext = personas;


            // PersonaIdComboBox.ItemsSource = PersonasBLL.GetPersonas();
            // PersonaIdComboBox.SelectedValuePath = "PersonaId";
            // PersonaIdComboBox.DisplayMemberPath = "Nombres";

        }

        

        private void Limpiar(){
            this.personas = new Personas();
            this.DataContext = personas;
        }

        private bool Validar(){
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0){   
                esValido = false;
                MessageBox.Show("Transaccion Fallida","Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e){
            var persona = PersonasBLL.Buscar(Utilidades.ToInt(PersonaIdTextBox.Text));

            if (persona == null)
                this.personas = persona;
            else    
                this.personas = new Personas();

                this.DataContext = this.personas;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

     private void GuardarButton_Click(object sender, RoutedEventArgs e){
            
            if(!Validar()){
                return;
            }
            var paso = PersonasBLL.Guardar(personas);

            if(paso){
                Limpiar();
                MessageBox.Show("Transaccion exitosa!" , "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else{
                MessageBox.Show("Transaccion Fallida", "Fallo",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e){
            if (PersonasBLL.Eliminar(Utilidades.ToInt(PersonaIdTextBox.Text))){
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }
}