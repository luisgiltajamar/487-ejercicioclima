using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfClima.Model
{
    [DataContract]
   public class Temperaturas
    {
       [DataMember]
       public int Temperatura { get; set; }
       [DataMember]
       public int Precipitacion { get; set; }
       [DataMember]
       public int Humedad { get; set; }
    }
}
