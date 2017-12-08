using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rellotge
{
    [Serializable()]
    class Alarma
    {
        private String Hora;

        public Alarma()
        {
            this.Hora = "00:00";
            this.AlarmaActiva = false;
        }

        public Alarma(String hora)
        {
            this.Hora = hora;
            this.AlarmaActiva = false;
        }

        public String HoraAlarma
        {
            get { return Hora; }
            set { Hora = value; }
        }

        public bool AlarmaActiva { get; set; }
    }
}
