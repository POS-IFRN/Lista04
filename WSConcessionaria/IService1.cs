using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSConcessionaria
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        // TODO: Add your service operations here
        [OperationContract]
        void InsertFabricante(Modelo.Fabricante f);

        [OperationContract]
        List<Modelo.Fabricante> SelectFabricantes();

        [OperationContract]
        void UpdateFabricante(Modelo.Fabricante f);

        [OperationContract]
        void DeleteFabricante(Modelo.Fabricante f);

        [OperationContract]
        void InsertVeiculo(Modelo.Veiculo v);

        [OperationContract]
        List<Modelo.Veiculo> SelectVeiculos();

        [OperationContract]
        void UpdateVeiculo(Modelo.Veiculo v);

        [OperationContract]
        void DeleteVeiculo(Modelo.Veiculo v);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
