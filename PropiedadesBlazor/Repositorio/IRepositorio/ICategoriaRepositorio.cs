using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<CategoriaDTO>> GetAllCategorias();

        Task<CategoriaDTO> GetCategoria(int categoriaId);

        Task<CategoriaDTO> CrearCategoria(CategoriaDTO categoriaDTO);

        Task<CategoriaDTO> ActualizarCategoria(int categoriaId, CategoriaDTO categoriaDTO);

        Task<CategoriaDTO> NombreCategoriaExiste(string nombreCategoria);

        Task<int> BorrarCategoria(int categoriaId);

        Task<IEnumerable<DropDownCategoriaDTO>> GetDropDownCategorias();
    }
}
