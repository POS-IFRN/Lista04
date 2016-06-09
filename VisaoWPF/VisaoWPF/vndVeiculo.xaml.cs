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
    /// Interaction logic for vndVeiculo.xaml
    /// </summary>
    public partial class vndVeiculo : Window
    {
        private Modelo.Veiculo v;
        public vndVeiculo(Modelo.Veiculo v)
        {
            InitializeComponent();
            txtId.Text = v.Id.ToString();
            this.v = v;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            v.PrecoVenda = Convert.ToDecimal(txtVenda.Text);
            v.DataVenda = Convert.ToDateTime(txtVenda.Text);
            new Negocio.Veiculo().Update(v);
        }
    }
}
