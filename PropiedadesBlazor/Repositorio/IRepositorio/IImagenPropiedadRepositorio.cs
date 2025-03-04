using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.IRepositorio
{
    public interface IImagenPropiedadRepositorio
    {
        Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDTO);

        Task<int> BorrarPropiedadImagenPorIdImagen(int imagenId);

        Task<int> BorrarPropiedadImagenPorIdIdPropiedad(int propiedadId);

        Task<int> BorrarPropiedadImagenPorUrlImagen(string imagenUrl);

        Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId);
    }
}
