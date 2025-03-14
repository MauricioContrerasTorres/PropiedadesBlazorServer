﻿using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Modelos.DTO
{
    public class PropiedadDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage ="El nombre debe estar entre 5 y 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "La descripción debe estar entre 20 y 300 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El Área es obligatoria")]
        [Range(1,5000, ErrorMessage ="Debes ingresar un número válido")]
        public int Area { get; set; }

        [Required(ErrorMessage = "las habitaciones son obligatorias")]
        [Range(1, 5000, ErrorMessage = "Debes ingresar un número válido")]
        public int Habitaciones { get; set; }

        [Required(ErrorMessage = "los baños son obligatorios")]
        [Range(1, 20, ErrorMessage = "Debes ingresar un número válido")]
        public int Banios { get; set; }

        [Required(ErrorMessage = "El parqueadero es obligatorio")]
        [Range(1, 5, ErrorMessage = "Debes ingresar un número válido")]
        public int Parqueadero { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]        
        public double Precio { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }        

        //relación con modelo/tabla categoria
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public ICollection<ImagenPropiedad> ImagenPropiedad { get; set; }

        public List<string> UrlImagenes { get; set; }
    }
}
