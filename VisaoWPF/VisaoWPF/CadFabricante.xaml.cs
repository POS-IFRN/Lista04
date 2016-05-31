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

namespace VisaoWPF
{
    /// <summary>
    /// Interaction logic for CadFabricante.xaml
    /// </summary>
    public partial class CadFabricante : Window
    {
        public CadFabricante()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Fabricante f = new Modelo.Fabricante
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text
            };
            new Negocio.Fabricante().Insert(f);
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var fabr = new Negocio.Fabricante().Select();

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = fabr.OrderBy(f => f.Descricao);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Fabricante f = new Modelo.Fabricante
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text
            };
            new Negocio.Fabricante().Update(f);

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Fabricante f = new Modelo.Fabricante
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text
            };
            new Negocio.Fabricante().Delete(f);
        }
    }
}
