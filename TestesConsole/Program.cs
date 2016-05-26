using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestesConsole
{
    class Program
    {
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        static void Main(string[] args)
        {
            List<Modelo.Fabricante> fabricantes = new Negocio.Fabricante().Select();
            List<Modelo.Veiculo> veiculos = new Negocio.Veiculo().Select();
            foreach (Modelo.Fabricante f in fabricantes)
            {
                var propfab = GetProperties(f);
                foreach (var p in propfab)
                {
                    Console.Write(p.GetValue(f) + " - ");
                }

                Console.WriteLine();
            }
            foreach (Modelo.Veiculo v in veiculos)
            {
                var propvec = GetProperties(v);
                foreach (var p in propvec)
                {
                    Console.Write(p.GetValue(v) + " - ");
                }

                Console.WriteLine();
            }


        }
    }
}
