using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rellotge
{
    [Serializable()]
    class Alarma
    {
        public Alarma()
        {
            this.HoraAlarma = "00:00";
            this.AlarmaActiva = false;
        }

        public Alarma(String hora)
        {
            this.HoraAlarma = hora;
            this.AlarmaActiva = false;
        }

        public String HoraAlarma { get; set; }

        public Boolean AlarmaActiva { get; set; }
    }
}
