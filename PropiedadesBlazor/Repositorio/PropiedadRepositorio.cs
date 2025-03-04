using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazor.Data;
using PropiedadesBlazor.IRepositorio;
using PropiedadesBlazor.Modelos;
using PropiedadesBlazor.Modelos.DTO;

namespace PropiedadesBlazor.Repositorio
{
    public class PropiedadRepositorio : IPropiedadRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;

        public PropiedadRepositorio(ApplicationDbContext bd, IMapper mapper)
        {
            this._bd = bd;
            this._mapper = mapper;
        }
        public async Task<PropiedadDTO> ActualizarPropiedad(int propiedadId, PropiedadDTO propiedadDTO)
        {
            try
            {
                if (propiedadId == propiedadDTO.Id)
                {
                    //valido para actualizar
                    Propiedad propiedad = await _bd.Propiedad.FindAsync(propiedadId);
                    Propiedad cate = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO, propiedad);
                    cate.FechaActualizacion = DateTime.Now;
                    var PropiedadActualizada = _bd.Propiedad.Update(cate);
                    await _bd.SaveChangesAsync();
                    return _mapper.Map<Propiedad, PropiedadDTO>(PropiedadActualizada.Entity);

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<int> BorrarPropiedad(int propiedadId)
        {
            var propiedad = await _bd.Propiedad.FindAsync(propiedadId);
            if (propiedad != null)
            {
                var todasImagenes = await _bd.ImagenPropiedad.Where(t=> t.PropiedadId == propiedadId).ToListAsync();
                _bd.ImagenPropiedad.RemoveRange(todasImagenes);
                _bd.Propiedad.Remove(propiedad);
                return await _bd.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<PropiedadDTO> CrearPropiedad(PropiedadDTO propiedadDTO)
        {
            Propiedad propiedad = _mapper.Map<PropiedadDTO, Propiedad>(propiedadDTO);
            propiedad.FechaCreacion = DateTime.Now;
            var propiedadGuardada = await _bd.Propiedad.AddAsync(propiedad);
            await _bd.SaveChangesAsync();
            return _mapper.Map<Propiedad, PropiedadDTO>(propiedadGuardada.Entity);
        }

        public async Task<IEnumerable<PropiedadDTO>> GetAllPropiedades()
        {
            //try
            //{
            //    IEnumerable<PropiedadDTO> propiedadDTO = _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(_bd.Propiedad);
            //    return (propiedadDTO);
            //}
            //catch (Exception)
            //{

            //    return null;
            //}


            try
            {
                IEnumerable<PropiedadDTO> propiedadDTO = _mapper.Map<IEnumerable<Propiedad>, IEnumerable<PropiedadDTO>>(_bd.Propiedad.Include(x=> x.ImagenPropiedad).Include(c => c.Categoria));
                return (propiedadDTO);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<PropiedadDTO> GetPropiedad(int propiedadId)
        {
            try
            {
                PropiedadDTO propiedadDTO = _mapper.Map<Propiedad, PropiedadDTO>(await _bd.Propiedad.FirstOrDefaultAsync(c => c.Id == propiedadId));
                return (propiedadDTO);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<PropiedadDTO> NombrePropiedadExiste(string nombrePropiedad)
        {
            try
            {
                PropiedadDTO propiedadDTO = _mapper.Map<Propiedad, PropiedadDTO>(await _bd.Propiedad.FirstOrDefaultAsync(c => c.Nombre.ToLower() == nombrePropiedad.ToLower()));
                return (propiedadDTO);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
