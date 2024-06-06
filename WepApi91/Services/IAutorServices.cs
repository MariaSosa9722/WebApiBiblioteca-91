using Domain.Entities;

namespace WepApi91.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> Crear(Autor i);
    }
}
