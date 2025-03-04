using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PropiedadesBlazor.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCategoria { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public virtual ICollection<Propiedad> Propiedad { get; set; }
    }
}
