using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfClima.Model
{

    [DataContract]
  public class ErrorFechas
    {
        [DataMember]
        public List<DateTime> Fechas { get; set; }
    }
}
