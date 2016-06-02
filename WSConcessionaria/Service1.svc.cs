using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSConcessionaria
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private LojaDataContext dc = new LojaDataContext();
        public void InsertFabricante(Modelo.Fabricante f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("Fabricante nulo");
            }

            dc.Fabricantes.InsertOnSubmit(new Fabricante { id = f.Id, descricao = f.Descricao });
            dc.SubmitChanges();
        }

        public List<Modelo.Fabricante> SelectFabricantes()
        {
            IQueryable objs = from f in dc.Fabricantes select f;
            List <Modelo.Fabricante> fabricantes = new List<Modelo.Fabricante>();
            foreach (Fabricante obj in objs)
            {
                Modelo.Fabricante f = new Modelo.Fabricante
                {
                    Id = obj.id,
                    Descricao = obj.descricao
                };
                fabricantes.Add(f);
            }

            return fabricantes;
        }

        public void UpdateFabricante(Modelo.Fabricante f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("Fabricante nulo");
            }

            Fabricante fabr = (from fab in dc.Fabricantes where fab.id == f.Id select fab).Single();
            fabr.descricao = f.Descricao;
            dc.SubmitChanges();
        }

        public void DeleteFabricante(Modelo.Fabricante f)
        {
            if (f == null)
            {
                throw new ArgumentNullException("Fabricante nulo");
            }

            Fabricante fabr = (from fab in dc.Fabricantes where fab.id == f.Id select fab).Single();
            dc.Fabricantes.DeleteOnSubmit(fabr);
            dc.SubmitChanges();
        }

        public void InsertVeiculo(Modelo.Veiculo v)
        {
            if (v == null)
            {
                throw new ArgumentNullException("Veiculo nulo");
            }

            dc.Veiculos.InsertOnSubmit(new Veiculo {
                id = v.Id,
                Modelo = v.Modelo,
                Ano = v.Ano,
                idFabricante = v.IdFabricante,
                DataCompra = v.DataCompra,
                DataVenda = null,
                ValorCompra = v.ValorCompra,
                ValorVenda = null,
                PrecoVenda = null
            });
            dc.SubmitChanges();
        }

        public List<Modelo.Veiculo> SelectVeiculos()
        {
            IQueryable objs = from v in dc.Veiculos select v;
            List<Modelo.Veiculo> fabricantes = new List<Modelo.Veiculo>();
            foreach (Veiculo obj in objs)
            {
                Modelo.Veiculo v = new Modelo.Veiculo
                {
                    Id = obj.id,
                    Modelo = obj.Modelo,
                    Ano = Convert.ToInt16(obj.Ano),
                    IdFabricante = Convert.ToInt16(obj.idFabricante),
                    DataCompra = Convert.ToDateTime(obj.DataCompra),
                    DataVenda = Convert.ToDateTime(obj.DataVenda),
                    ValorCompra =Convert.ToDecimal(obj.ValorCompra),
                    ValorVenda = Convert.ToDecimal(obj.ValorVenda),
                    PrecoVenda = Convert.ToDecimal(obj.PrecoVenda)
                };
                fabricantes.Add(v);
            }

            return fabricantes;
        }

        public List<Modelo.Veiculo> SelectVeiculosDisponiveis()
        {
            IQueryable objs = from v in dc.Veiculos where v.DataVenda == null select v;
            List<Modelo.Veiculo> fabricantes = new List<Modelo.Veiculo>();
            foreach (Veiculo obj in objs)
            {
                Modelo.Veiculo v = new Modelo.Veiculo
                {
                    Id = obj.id,
                    Modelo = obj.Modelo,
                    Ano = Convert.ToInt16(obj.Ano),
                    IdFabricante = Convert.ToInt16(obj.idFabricante),
                    DataCompra = Convert.ToDateTime(obj.DataCompra),
                    DataVenda = Convert.ToDateTime(obj.DataVenda),
                    ValorCompra = Convert.ToDecimal(obj.ValorCompra),
                    ValorVenda = Convert.ToDecimal(obj.ValorVenda),
                    PrecoVenda = Convert.ToDecimal(obj.PrecoVenda)
                };
                fabricantes.Add(v);
            }

            return fabricantes;
        }

        public List<Modelo.Veiculo> SelectVeiculosVendidos()
        {
            IQueryable objs = from v in dc.Veiculos where v.DataVenda != null select v;
            List<Modelo.Veiculo> fabricantes = new List<Modelo.Veiculo>();
            foreach (Veiculo obj in objs)
            {
                Modelo.Veiculo v = new Modelo.Veiculo
                {
                    Id = obj.id,
                    Modelo = obj.Modelo,
                    Ano = Convert.ToInt16(obj.Ano),
                    IdFabricante = Convert.ToInt16(obj.idFabricante),
                    DataCompra = Convert.ToDateTime(obj.DataCompra),
                    DataVenda = Convert.ToDateTime(obj.DataVenda),
                    ValorCompra = Convert.ToDecimal(obj.ValorCompra),
                    ValorVenda = Convert.ToDecimal(obj.ValorVenda),
                    PrecoVenda = Convert.ToDecimal(obj.PrecoVenda)
                };
                fabricantes.Add(v);
            }

            return fabricantes;
        }



        public void UpdateVeiculo(Modelo.Veiculo v)
        {
            if (v == null)
            {
                throw new ArgumentNullException("Veiculo nulo");
            }

            Veiculo fabr = (from fab in dc.Veiculos where fab.id == v.Id select fab).Single();
            fabr.Modelo = v.Modelo;
            fabr.Ano = Convert.ToInt16(v.Ano);
            fabr.idFabricante = Convert.ToInt16(v.IdFabricante);
            fabr.DataCompra = Convert.ToDateTime(v.DataCompra);
            fabr.DataVenda = Convert.ToDateTime(v.DataVenda);
            fabr.ValorCompra = Convert.ToDecimal(v.ValorCompra);
            fabr.ValorVenda = Convert.ToDecimal(v.ValorVenda);
            fabr.PrecoVenda = Convert.ToDecimal(v.PrecoVenda);
            dc.SubmitChanges();
        }



    }
}
