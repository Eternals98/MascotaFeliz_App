
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioUsuario
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario AddUsuario(Usuario usuario);
        Usuario UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int idUsuario);
        Usuario GetUsuario(int idUsuario);
        IEnumerable<Usuario> GetUsuariosPorFiltro(string filtro);
    }
}