using System;
using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Pasantia
    {
        [Key]
        public int IDPasantia { get; set; }  // Clave primaria

        public string Titulo { get; set; }  // Título de la pasantía

        public string Descripcion { get; set; }  // Descripción de la pasantía

        public DateTime FechaIngreso { get; set; }  // Fecha de ingreso de la pasantía

        public DateTime FechaFin { get; set; }  // Fecha de fin de la pasantía

        public bool EsRemuneracion { get; set; }  // Indica si la pasantía es remunerada

        public decimal DineroRemuneracion { get; set; }  // Monto de la remuneración (si es remunerada)

        public int Duracion { get; set; }  // Duración de la pasantía en meses

        public int IDEmpresa { get; set; }  // ID de la empresa que ofrece la pasantía

        public string ModalidadPasa { get; set; }  // Modalidad de la pasantía (presencial, remota, etc.)

        public string Requisitos { get; set; }  // Requisitos de la pasantía

        public string Area { get; set; }  // Área o departamento de la pasantía

        public string Estado { get; set; }  // Estado actual de la pasantía (abierta, cerrada, etc.)

        public int IDBeneficios { get; set; }  // ID de los beneficios asociados a la pasantía

        public string Rol { get; set; }  // Rol o posición en la pasantía
    }
}
