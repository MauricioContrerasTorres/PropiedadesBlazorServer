using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.IRepositorio
{
    public interface IPropiedadRepositorio
    {
        Task<IEnumerable<PropiedadDTO>> GetAllPropiedades();

        Task<PropiedadDTO> GetPropiedad(int propiedadId);

        Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO);

        Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO);

        Task<PropiedadDTO> NombrePropiedadExiste(string nombrePropiedad);

        Task<int> BorrarPropiedad(int propiedadId);

        //Task<IEnumerable<PropiedadDTO>> GetDropDownPropiedades();
    }
}
