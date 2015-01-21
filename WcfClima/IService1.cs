using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfClima.Model;

namespace WcfClima
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicioClima
    {

        [OperationContract]
        [FaultContract(typeof(ErrorCiudad))]
        [FaultContract(typeof(ErrorFechas))]
        Temperaturas GetClima(String ciudad,DateTime fecha);

      

        // TODO: Add your service operations here
    }


  
}
