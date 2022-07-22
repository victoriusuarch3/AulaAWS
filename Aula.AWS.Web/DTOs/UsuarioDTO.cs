namespace Aula.AWS.Web.DTOs
{
    public class UsuarioDTO
    {
        public int  id{get; set;}
        public string Nome{get; set;}
        public string Cpf{get; set;}
        public DateTime DataNascimento{get; set;}
        public string Email{get; set;}
        public string UrlImagemCadastro {get; set;}
        public string Senha{get; set;} 
        public DateTime DataCriacao{get; set;}
    }
}