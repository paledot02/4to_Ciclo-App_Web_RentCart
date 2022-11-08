using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; // --
using System.ComponentModel.DataAnnotations; // --

namespace Dominio.Core.Entities
{
    public class ClienteFiltroDistrito
    {

        [DisplayName("ID")]
        public int ide_cli { get; set; }


        [DisplayName("NOMBRE")]
        public String nom_cli { get; set; }


        [DisplayName("APELLIDO")]
        public String ape_cli { get; set; }


        [DisplayName("DNI")]
        public String dni_cli { get; set; }


        [DisplayName("TELEFONO")]
        public String tel_cli { get; set; }


        [DisplayName("DISTRITO")]
        public String des_dis { get; set; }

        [DisplayName("NUMERO DE ALQUILERES")]
        public int veces_alquilo { get; set; }

        [DisplayName("MONTO ACUMULADO")]
        public double monto_acumulado { get; set; }

    }
}
