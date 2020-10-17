using System;
using System.Windows;
using RPrestamos.Entidades;
using RPrestamos.BLL;



namespace RPrestamos.UI.Registros
{

    public partial class rMoras : Window
    {

        Moras moras = new Moras();
        public rMoras()
        {
        InitializeComponent();
            this.DataContext = moras;

            PrestamoIdComboBox.ItemsSource= PersonasBLL.GetList(p =>true);
            PrestamoIdComboBox.SelectedValuePath= "PersonaId";
            PrestamoIdComboBox.DisplayMemberPath="Nombres";

        }

        
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = moras;
        }

        private void Limpiar(){
            this.moras = new Moras();
            this.DataContext= moras;
        }

        private bool Validar(){
            bool esValido = true;

            if(ValorTextBox.Text.Length ==0){
                esValido = false;
                MessageBox.Show("Transaccion Fallida" , "Fallo",  MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

         private bool ExisteEnLaBaseDeDatos()
        {
            Moras esValido = MorasBLL.Buscar(moras.MoraId);

            return (esValido != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e){
              var moras = MorasBLL.Buscar(Utilidades.ToInt(MoraIdTextBox.Text));

            if(moras != null){
                    this.moras = moras;
                    Cargar();   
            }
            else{
                    this.moras = new Moras();
              Limpiar();
              MessageBox.Show("Mora no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.DataContext = this.moras;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e){

            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e){
            
            if(!Validar()){
                return;
            }
                var paso = MorasBLL.Guardar(moras);

            if (moras.MoraId == 0)
            {
                paso = MorasBLL.Guardar(moras);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = MorasBLL.Guardar(moras);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
                if(paso){
                Limpiar();
                MessageBox.Show("Transaccion exitosa!" , "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else{
                MessageBox.Show("Transaccion Fallida", "Fallo",  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e){
            if(PrestamosBLL.Eliminar(Utilidades.ToInt(MoraIdTextBox.Text))){

                Limpiar();
                MessageBox.Show("Registro eliminado!" , "Exito" , MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else{
                MessageBox.Show("No fue posible eliminar", "Fallo",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var filaDetalle = new MorasDetalle( moras.MoraId, Convert.ToInt32(PrestamoIdComboBox.Text),
              Convert.ToInt32(ValorTextBox.Text));

            moras.MorasDetalle.Add(filaDetalle);
            Cargar();

            IdTextBox.Clear();
            ValorTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                moras.MorasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

    }
}