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
        private String alarma;
        private bool activa;

        public Alarma()
        {
            this.alarma = "00:00";
            activa = false;
        }

        public Alarma(String alarma, bool activa)
        {
            this.alarma = alarma;
            this.activa = activa;
        }

        public String horaAlarma
        {
            get { return alarma; }
            set { alarma = value; }
        }

        public bool alarmaActiva { get; set; }
    }
}
