using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        /// <summary>
        /// Referencia al contexto de Usuario
        /// </summary>

        private readonly AppContext _appContext;
       
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioUsuario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            var usuarioAdicionado = _appContext.Usuarios.Add(usuario);
            _appContext.SaveChanges();
            return usuarioAdicionado.Entity;
        }

        public void DeleteUsuario(int idUsuario)
        {
            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(d => d.Id == idUsuario);
            if (usuarioEncontrado == null)
                return;
            _appContext.Usuarios.Remove(usuarioEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Usuario> GetAllUsuarios()
        {
            return  _appContext.Usuarios;
        }

        public IEnumerable<Usuario> GetUsuariosPorFiltro(string filtro)
        {
            var usuarios = GetAllUsuarios(); // Obtiene todos los saludos
            if (usuarios != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    usuarios = usuarios.Where(s => s.UserName.Contains(filtro));
                }
            }
            return usuarios;
        }

       
        public Usuario GetUsuario(int idUsuario)
        {
            return _appContext.Usuarios.FirstOrDefault(d => d.Id == idUsuario);
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(d => d.Id == usuario.Id);
            if (usuarioEncontrado != null)
            {        
                usuarioEncontrado.UserName = usuario.UserName;
                usuarioEncontrado.Contrasena = usuario.Contrasena;
                _appContext.SaveChanges();
            }
            return usuarioEncontrado;
        }     
    }
}