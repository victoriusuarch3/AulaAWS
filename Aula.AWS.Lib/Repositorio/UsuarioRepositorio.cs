using Aula.AWS.Lib.Data;
using Aula.AWS.Lib.Interfaces;
using Aula.AWS.Lib.Models;

namespace Aula.AWS.Lib.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AulaAWSContext context) : base(context, context.Usuarios)
        {
            
        }
               public async Task AlteracaoSenha(int id, string senha)
               {
                
               }
    }
}