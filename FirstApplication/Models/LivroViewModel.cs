using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstApplication.Models
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(100)]
        public string Autor { get; set; }
        [Required]
        [StringLength(100)]
        public string Editora { get; set; }

    }
}