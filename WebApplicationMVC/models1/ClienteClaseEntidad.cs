using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationMVC.models1
{
    //aqui puedes agregar campos adicionales ,tabien  se agrega dataanotation.
    public class ClienteClaseEntidad
    {
        [Required]
        [Display(Name ="Cod Alias")]
        public string AliasCliente { get; set; }
        [Required]
        [Display(Name = "Nommbre del cliente")]
        public string NomCliente { get; set; }
        //public string DirCliente { get; set; }
        //public string Pais { get; set; }
        //public string fonoCliente { get; set; }
    }
    [MetadataType(typeof(ClienteClaseEntidad))]

    // puedes retornar cadena conctenada. nombre y aplellidos.(ejemplo nombre completo) 
    public partial class clientes {
        public string Nombrecopleto { get { return NomCliente + "" + AliasCliente; } }
    }
}