using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estoque.Data;
using Estoque.Models;
using Estoque.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.UtcNow;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null)
            {
                throw new NotFoundException($"Usuario com ID {usuario.Id} não encontrado.");
            }

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataEdicao = DateTime.UtcNow;
            usuarioDB.DataCadastro = DateTime.UtcNow;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            try
            {
                UsuarioModel usuarioDB = ListarPorId(id);
                if (usuarioDB == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                _context.Usuarios.Remove(usuarioDB);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar apagar o usuário: " + ex.Message);
            }
        }


        public UsuarioSemSenhaModel Editar(UsuarioSemSenhaModel usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

    }
}
