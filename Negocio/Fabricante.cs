using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Fabricante
    {
        private ServicoConcessionaria.Service1Client sr = new ServicoConcessionaria.Service1Client();
        public void Insert(Modelo.Fabricante f)
        {
            List<Modelo.Fabricante> fabricantes = Select();
            if (!fabricantes.Exists(fabr => fabr.Id == f.Id))
            {
                sr.InsertFabricante(f);
            }
        }

        public List<Modelo.Fabricante> Select()
        {
            List<Modelo.Fabricante> fabricantes = sr.SelectFabricantes().ToList();
            if (fabricantes.Count == 0) return null;
            return fabricantes;
        }

        public void Update(Modelo.Fabricante f)
        {
            List<Modelo.Fabricante> fabricantes = Select();
            if (fabricantes.Exists(fabr => fabr.Id == f.Id))
            {
                sr.UpdateFabricante(f);
            }
        }

        public void Delete(Modelo.Fabricante f)
        {
            List<Modelo.Fabricante> fabricantes = Select();
            if (fabricantes.Exists(fabr => fabr.Id == f.Id))
            {
                sr.DeleteFabricante(f);
            }
        }
    }
}
