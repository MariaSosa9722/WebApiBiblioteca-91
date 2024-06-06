using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WepApi91.Context;

namespace WepApi91.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;
        public AutorServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new {}, commandType:CommandType.StoredProcedure);

                response = result.ToList();

                return  new Response<List<Autor>> ( response ); 

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error :c");
            }

        }


        public  async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor> ( result );
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error :c " +ex.Message);
            }

        }


    }
}
