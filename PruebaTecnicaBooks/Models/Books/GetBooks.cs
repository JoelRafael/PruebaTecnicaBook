using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaBooks.Models.Books
{
    public class GetBooks
    {
        [Required(ErrorMessage ="El id es requerido")]
        public int id { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public string title { get; set; }
        [Required(ErrorMessage = "La descripcion es requerido")]
        public string description{ get; set; }
        [Required(ErrorMessage = "La cantidad de pagina es requerida")]
        public int pageCount { get; set; }
        [Required(ErrorMessage = "El excerpt es requerido")]
        public string excerpt { get; set; }
        [Required(ErrorMessage = "La fecha de publicacion es requerido")]
        public DateTime publishDate { get; set; }
    }
}
