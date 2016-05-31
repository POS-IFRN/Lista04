using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Veiculo
    {
        private ServicoConcessionaria.Service1Client sr = new ServicoConcessionaria.Service1Client();
        public void Insert(Modelo.Veiculo v)
        {
            List<Modelo.Veiculo> veiculos = Select();
            if (!veiculos.Exists(veic => veic.Id == v.Id))
            {
                sr.InsertVeiculo(v);
            }
        }

        public List<Modelo.Veiculo> Select()
        {
            List<Modelo.Veiculo> veiculos = sr.SelectVeiculos().ToList();
            return veiculos;
        }

        public List<Modelo.Veiculo> SelectDisponiveis()
        {
            List<Modelo.Veiculo> veiculos = sr.SelectVeiculosDisponiveis().ToList();
            return veiculos;
        }

        public List<Modelo.Veiculo> SelectVendidos()
        {
            List<Modelo.Veiculo> veiculos = sr.SelectVeiculosVendidos().ToList();
            return veiculos;
        }

        public void Update(Modelo.Veiculo v)
        {
            List<Modelo.Veiculo> veiculos = Select();
            if (veiculos.Exists(veic => veic.Id == v.Id))
            {
                sr.UpdateVeiculo(v);
            }
        }
    }
}
