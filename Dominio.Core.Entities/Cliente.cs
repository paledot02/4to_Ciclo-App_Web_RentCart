using System;
using System.Collections.Generic;
using System.ComponentModel; // --
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities
{
    public class Cliente
    {
        [DisplayName("ID")]
        public int ide_cli { get; set; }


        [DisplayName("CLIENTE")]
        public String nom_cli { get; set; }


        [DisplayName("DNI")]
        public String dni_cli { get; set; }


        [DisplayName("TELEFONO")]
        public String tel_cli { get; set; }


        [DisplayName("DISTRITO")]
        public String des_dis { get; set; }


    }
}
