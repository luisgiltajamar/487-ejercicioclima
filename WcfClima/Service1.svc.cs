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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioClima : IServicioClima
    {
        public Temperaturas GetClima(string ciudad, DateTime fecha)
        {
            using (var db=new ClimaEntities())
            {
                if (!db.Ciudad.Any(o => o.nombre == ciudad))
                {
                    var lc = db.Ciudad.Select(o => o.nombre).ToList();
                    var ec = new ErrorCiudad() {Ciudades = lc};
                    throw new FaultException<ErrorCiudad>(ec,
                        "Ciudad no disponible");
                }
                var clima = db.
                    Clima.FirstOrDefault
                    (o => o.Ciudad.nombre == ciudad && o.fecha == fecha);
                if (clima == null)
                {
                    var lf = db.Clima.Where(o => o.Ciudad.nombre == ciudad).
                        Select(o => o.fecha).ToList();
                    var ef = new ErrorFechas() {Fechas = lf};
                    throw new FaultException<ErrorFechas>(ef,
                        "Fecha no disponible");
                }

                var t = new Temperaturas()
                {
                    Temperatura = clima.temperatura,
                    Humedad = clima.humedad,
                    Precipitacion = clima.precipitacion

                };
                return t;

            }
        }
    }
}