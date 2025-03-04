using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropiedadesBlazor.Modelos.DTO
{
    public class ImagenPropiedadDTO
    {
        
        public int id { get; set; }

        public int PropiedadId { get; set; }

        public string UrlImagenPropiedad { get; set; }        
    }
}
