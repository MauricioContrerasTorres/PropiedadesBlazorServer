using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;
using PropiedadesBlazor.IRepositorio;

namespace PropiedadesBlazor.Repositorio
{    
    public class ImagenPropiedadRepositorio : IImagenPropiedadRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;
        public ImagenPropiedadRepositorio(ApplicationDbContext bd, IMapper mapper)
        {
            this._bd = bd;
            this._mapper = mapper;
        }
        public async Task<int> BorrarPropiedadImagenPorIdIdPropiedad(int propiedadId)
        {
            var listaImagenes = await _bd.ImagenPropiedad.Where(t => t.PropiedadId == propiedadId).ToListAsync();
            _bd.ImagenPropiedad.RemoveRange(listaImagenes);
            return await _bd.SaveChangesAsync();
        }

        public async Task<int> BorrarPropiedadImagenPorIdImagen(int imagenId)
        {
            var imagen = await _bd.ImagenPropiedad.FindAsync(imagenId);
            _bd.ImagenPropiedad.Remove(imagen);
            return await _bd.SaveChangesAsync();            
        }

        public async Task<int> BorrarPropiedadImagenPorUrlImagen(string imagenUrl)
        {
            var imagen = await _bd.ImagenPropiedad.Where(t => t.UrlImagenPropiedad.ToLower() == imagenUrl.ToLower()).FirstOrDefaultAsync();
            _bd.ImagenPropiedad.RemoveRange(imagen);
            return await _bd.SaveChangesAsync();
        }

        public async Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDTO)
        {
            //var imagen = _mapper.Map<ImagenPropiedadDTO, ImagenPropiedad>(imagenDTO);
            //await _bd.ImagenPropiedad.AddAsync(imagen);
            //return await _bd.SaveChangesAsync();


            ImagenPropiedad aux = new ImagenPropiedad();
            aux.UrlImagenPropiedad = imagenDTO.UrlImagenPropiedad;
            aux.PropiedadId = imagenDTO.PropiedadId;


            await _bd.ImagenPropiedad.AddAsync(aux);
            return await _bd.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId)
        {
            return _mapper.Map<IEnumerable<ImagenPropiedad>, IEnumerable<ImagenPropiedadDTO>>(await _bd.ImagenPropiedad.Where(t => t.PropiedadId == propiedadId).ToListAsync());
        }
    }
}
