using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _6_MovieApp.ViewModel
{
    public class MovieAppViewModel
    {
        /* esto lo agregue yo, en la clase del profesor no aparece esto,
         * pero para poder generar un identificador necesite de esto 
         * y de algunas modificaciones en el controller
         */
        public Guid Identi = Guid.NewGuid();

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Por favor Ingrese un nombre")]
        [MaxLength(30, ErrorMessage = "Has excedido el maximo de caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor Ingrese un genero")]
        [MaxLength(30, ErrorMessage = "Has excedido el maximo de caracteres")]
        public string Genero { get; set; }
    }
}
