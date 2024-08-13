using Estoque.Models;

namespace Estoque.Helper{
    public interface ISessao{
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}