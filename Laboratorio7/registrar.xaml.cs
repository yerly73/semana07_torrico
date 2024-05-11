using Business;
using Entity;
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
using System.Windows.Shapes;

namespace Laboratorio7
{
    /// <summary>
    /// Lógica de interacción para registrar.xaml
    /// </summary>
    public partial class registrar : Window
    {
        public registrar()
        {
            InitializeComponent();
        }

        private void RegistrarProductoClick(object sender, RoutedEventArgs e)
        {
            Product nuevoProducto = new Product();
            nuevoProducto.Name = txtProductName.Text;
            nuevoProducto.Price = decimal.Parse(txtPrice.Text);
            nuevoProducto.Stock = int.Parse(txtStock.Text);


            //clase de la capa negocio
            ProductBusiness prod = new ProductBusiness();

            prod.InsertarProducto(nuevoProducto);
                       
            MessageBox.Show("Producto registrado correctamente :D");
            }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
