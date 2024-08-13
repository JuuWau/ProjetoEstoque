using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;
using Estoque.Models;

namespace Estoque.Repositorio{

    public interface IUsuarioRepositorio{
        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> BuscarTodos();

        UsuarioModel ListarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Editar(UsuarioModel usuario);

        bool Apagar(int id);
        UsuarioModel Atualizar(UsuarioModel usuario);

    }
}