using System;
using System.Collections.Generic;
using System.ComponentModel; // --
using System.ComponentModel.DataAnnotations; // --
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entities
{
    public class ClienteO
    {

        [DisplayName("ID")]
        public int ide_cli { get; set; }


        [DisplayName("APELLIDOS")]
        [Required(ErrorMessage = "Debe ingresar los apellidos")]
        public String ape_cli { get; set; }


        [DisplayName("NOMBRES")]
        [Required(ErrorMessage = "Debe ingresar los nombres")]
        public String nom_cli { get; set; }


        [DisplayName("DNI")]
        [Required(ErrorMessage = "Debe ingresar el DNI")]
        public String dni_cli { get; set; }


        [DisplayName("TELEFONO")]
        [Required(ErrorMessage = "Debe ingresar un numero de telefono")]
        public String tel_cli { get; set; }


        [DisplayName("DISTRITO")]
        [Required(ErrorMessage = "Debe seleccionar un distrito")]
        public int ide_dis { get; set; }

    }
}
