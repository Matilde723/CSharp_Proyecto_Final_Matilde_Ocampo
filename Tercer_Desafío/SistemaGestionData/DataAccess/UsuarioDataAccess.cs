using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;

using SistemaGestionData;
using SistemaGestionData.DataAccess;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess
{
    public class UsuarioDataAccess
    {
        private readonly CoderhouseContext _context;

        public UsuarioDataAccess(CoderhouseContext context)
        {
            _context = context;
        }

        // ObtenerUsuario - Using LINQ to get a user by ID
        public Usuario ObtenerUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario == null)
                {
                    throw new Exception("Usuario not found");
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching Usuario", ex);
            }
        }

        // ListarUsuarios - Using LINQ to get all users
        public List<Usuario> ListarUsuarios()
        {
            try
            {
                return _context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while listing Usuarios", ex);
            }
        }

        // CrearUsuario - Adding a new user using EF
        public void CrearUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating Usuario", ex);
            }
        }

        // ModificarUsuario - Updating an existing user using EF
        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                var existingUsuario = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
                if (existingUsuario != null)
                {
                    existingUsuario.Nombre = usuario.Nombre;
                    existingUsuario.Apellido = usuario.Apellido;
                    existingUsuario.NombreUsuario = usuario.NombreUsuario;
                    existingUsuario.Contraseña = usuario.Contraseña;
                    existingUsuario.Mail = usuario.Mail;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating Usuario", ex);
            }
        }

        // EliminarUsuario - Deleting a user using EF
        public void EliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting Usuario", ex);
            }
        }
    }
}
