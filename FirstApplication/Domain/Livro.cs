﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
              
       
    }
}