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
    /// Interaction logic for LstVeiculosDisponiveis.xaml
    /// </summary>
    public partial class LstVeiculosDisponiveis : Window
    {
        public LstVeiculosDisponiveis()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            var veiculos = new Negocio.Veiculo().SelectDisponiveis();
            var fabricantes = new Negocio.Fabricante().Select();
            var vplusf = from v in veiculos
                         join fab in fabricantes on v.IdFabricante equals fab.Id
                         select new
                         {
                             id = v.Id,
                             modelo = v.Modelo,
                             ano = v.Ano,
                             dtCompra = v.DataCompra,
                             vCompra = v.ValorCompra,
                             desc = fab.Descricao,
                             idFab = fab.Id
                         };

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = vplusf.OrderBy(desc => desc.desc).ThenBy(mode => mode.modelo);
        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var abrir = new vndVeiculo((Modelo.Veiculo)dataGrid.SelectedItem);
                abrir.Show();
            }
        }

    }
}
