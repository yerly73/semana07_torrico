using Business;
using Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            dgProducts.ItemsSource = business.Get();
        }

        private void registrar(object sender, RoutedEventArgs e)
        {
            registrar re = new registrar();  
            re.ShowDialog();

        }

        private void eliminar(object sender, RoutedEventArgs e)
        {
            // Obtener el producto seleccionado en el DataGrid
            Product productoSeleccionado = (Product)dgProducts.SelectedItem;



            // Obtener el ID del registro seleccionado
            int id = productoSeleccionado.ProductID;
            //MessageBox.Show("IdProducto del registro seleccionado: " + productoSeleccionado.product_id);

            if (productoSeleccionado != null)
            {
                ProductBusiness prod = new ProductBusiness();
                prod.eliminar(id);
                

            }
            else
            {
                MessageBox.Show("Producto no seleccionado correctamente :D");
            }
        }
    }
}