using System.Linq;
using System.Collections.Generic;


namespace CriandoProjeto.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private static List<Usuario> listagem = new List<Usuario>();
        public static IQueryable<Usuario> Listagem 
        {
            get 
            {
                return listagem.AsQueryable();
            }
        }

        static Usuario()
        {
            Usuario.listagem.Add(new Usuario { Id = 1, Nome = "Fulano", Email = "fulano@email.com"});
            Usuario.listagem.Add(new Usuario { Id = 2, Nome = "IDk", Email = "fulano@email.com"});
            Usuario.listagem.Add(new Usuario { Id = 3, Nome = "Beltrano", Email = "fulano@email.com"});
            Usuario.listagem.Add(new Usuario { Id = 4, Nome = "Liss", Email = "fulano@email.com"});
            Usuario.listagem.Add(new Usuario { Id = 5, Nome = "Layon", Email = "fulano@email.com"});
        }

        public static void Salvar(Usuario user)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.Id == user.Id);
            if(usuarioExistente != null)
            {
                usuarioExistente.Nome = user.Nome;
                usuarioExistente.Email = user.Email;
            } 
            else
            {
                int maiorId = Usuario.listagem.Max(u => u.Id);
                user.Id = maiorId + 1;
                Usuario.listagem.Add(user);
            }
        }

        public static bool Excluir(int id)
        {
            var conta = Usuario.listagem.Find(x => x.Id == id);
            if(conta != null)
            {
               return Usuario.listagem.Remove(conta);
            }

            return false;
        } 
    }
}