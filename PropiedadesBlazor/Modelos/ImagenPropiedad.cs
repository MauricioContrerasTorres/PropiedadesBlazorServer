using PropiedadesBlazor.Repositorio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropiedadesBlazor.Modelos
{
    public class ImagenPropiedad
    {
        [Key]
        public int id { get; set; }

        public int PropiedadId { get; set; }

        public string UrlImagenPropiedad { get; set; }

        [ForeignKey("PropiedadId")]

        public virtual Propiedad Propiedad { get; set; }
    }
}
