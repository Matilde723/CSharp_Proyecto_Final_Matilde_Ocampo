using SistemaGestionData.DataAccess;
using SistemaGestionEntities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class UsuarioBussiness
    {
        private readonly UsuarioDataAccess _usuarioDataAccess;

        public UsuarioBussiness(UsuarioDataAccess usuarioDataAccess)
        {
            _usuarioDataAccess = usuarioDataAccess;
        }

        // Get a Usuario by ID
        public async Task<Usuario> ObtenerUsuario(int id)
        {
            try
            {
                var usuario = await Task.Run(() => _usuarioDataAccess.ObtenerUsuario(id));
                if (usuario == null)
                {
                    throw new Exception("Usuario not found");
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Usuario with ID {id}: {ex.Message}");
            }
        }

        // List all Usuarios
        public async Task<List<Usuario>> ListarUsuarios()
        {
            try
            {
                return await Task.Run(() => _usuarioDataAccess.ListarUsuarios());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error listing Usuarios: {ex.Message}");
            }
        }

        // Create a new Usuario
        public async Task CrearUsuario(Usuario usuario)
        {
            try
            {
                await Task.Run(() => _usuarioDataAccess.CrearUsuario(usuario));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating Usuario: {ex.Message}");
            }
        }

        // Update an existing Usuario
        public async Task ModificarUsuario(Usuario usuario)
        {
            try
            {
                await Task.Run(() => _usuarioDataAccess.ModificarUsuario(usuario));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Usuario: {ex.Message}");
            }
        }

        // Delete a Usuario by ID
        public async Task EliminarUsuario(int id)
        {
            try
            {
                await Task.Run(() => _usuarioDataAccess.EliminarUsuario(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Usuario with ID {id}: {ex.Message}");
            }
        }
    }
}
