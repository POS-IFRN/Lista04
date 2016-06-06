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
    /// Interaction logic for CmpVeiculo.xaml
    /// </summary>
    public partial class CmpVeiculo : Window
    {
        public CmpVeiculo()
        {
            InitializeComponent();
            SetFabricantes();
        }

        private void SetFabricantes()
        {
            var fabr = new Negocio.Fabricante().Select();

            cmbFabricantes.ItemsSource = null;
            cmbFabricantes.ItemsSource = fabr.OrderBy(f => f.Descricao);
            cmbFabricantes.DisplayMemberPath = "Descricao";
            cmbFabricantes.SelectedValuePath = "Id";
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Veiculo v = new Modelo.Veiculo
            {
                Id = int.Parse(txtId.Text),
                Modelo = txtModelo.Text,
                Ano = int.Parse(txtAno.Text),
                ValorCompra = decimal.Parse(txtValorCompra.Text),
                DataCompra = (DateTime)dtDataCompra.SelectedDate,
                ValorVenda = decimal.Parse(txtVenda.Text),
                IdFabricante = Convert.ToInt16(cmbFabricantes.SelectedValue)
            };

            new Negocio.Veiculo().Insert(v);
        }
    }
}
