using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Diagnostics.Contracts;
using WepApi91.Context;

namespace WepApi91.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista de usuarios 
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {

                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }

        }


        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x=>x.PkUsuario == id);    

                return new Response<Usuario>(res);

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }



        }



        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {

                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User=request.User,
                    Password=request.Password,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario); 
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }


        }








    }
}
