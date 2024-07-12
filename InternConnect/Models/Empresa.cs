﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Empresa
    {
        [Key]
        public int IDEmpresa { get; set; }
            
        public string? Nombre { get; set; }

        public string? CorreoRRHH { get; set; }

        public string? Direccion { get; set; }

        public string? RNC { get; set; }

        public string? Descripcion { get; set; }

        public bool Verificacion { get; set; }

        public string LogoEmpresa { get; set; } // Tipo byte[] para almacenar longblob

        public DateTime FechaIngreso { get; set; }

        public string? Contacto { get; set; }
    }
}
