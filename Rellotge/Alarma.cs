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
        private String Hora;
        private Boolean Activa;

        public Alarma()
        {
            this.Hora = "00:00";
            this.Activa = false;
        }

        public Alarma(String hora)
        {
            this.Hora = hora;
            this.Activa = false;
        }

        public String HoraAlarma
        {
            get { return Hora; }
            set { Hora = value; }
        }

        public Boolean AlarmaActiva
        {
            get { return Activa; }
            set {
                Activa = value;
            }
        }
    }
}
