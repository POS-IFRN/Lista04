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
            var vplusf = from v in veiculos join fab in fabricantes on v.IdFabricante equals fab.Id select new { Veiculo = v, Fabricante = fab };

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = vplusf.OrderBy(desc => desc.Fabricante.Descricao).ThenBy(mode => mode.Veiculo.Modelo);
        }
    }
}
