namespace Aula.AWS.Lib.Models
{
    public class Usuario : ModelBase
    {
        public string Nome{get; private set;}
        public string Cpf{get; private set;}
        public DateTime DataNascimento{get; private set;}
        public string Email{get; private set;}
        public string Senha{get; private set;}
        public string UrlImagemCadastro{get; private set;}
        public DateTime DataCriacao{get; private set;}

        public Usuario(int id, string nome, string cpf, DateTime dataNascimento, string email, string senha, string urlImagemCadastro, DateTime dataCriacao) : base (id)
        {
            SetNome(nome);
            SetCpf(cpf);
            SetDataNascimento(dataNascimento);
            SetEmail(email);
            SetSenha(senha);
            SetUrlImagemCadastro(urlImagemCadastro);
            SetDataCriacao(dataCriacao);
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetCpf(string cpf)
        {
            ValidarSetCpfNumeros(cpf);
            Cpf = cpf;
        }
        public void SetDataNascimento(DateTime dataNascimento)
        {
            ValidarSetDataNascimentoAnterior2010(dataNascimento);
            DataNascimento = dataNascimento;
        }
        public void SetEmail(string email)
        {
            ValidarSetEmail(email);
            Email = email; 
        }
        public void SetSenha(string senha)
        {
            Senha = senha;
        }
        public void SetUrlImagemCadastro(string urlImagemCadastro)
        {
            UrlImagemCadastro = urlImagemCadastro;
        }

        public void SetDataCriacao(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
        }

         public bool ValidarSetDataNascimentoAnterior2010(DateTime dataNascimento)
        {
            if (dataNascimento < DateTime.Parse("01/01/2010"))
                return true;
            throw new Exception();
        }

         public bool ValidarSetCpfNumeros(string cpf)
        {
            if ((cpf.Count() <= 11) & cpf.All(char.IsNumber))
                return true;
            throw new Exception();
        }

         public bool ValidarSetEmail(string email)
        {
            if (email.Contains("@"))
                return true;
            throw new Exception();
        }

        public bool ValidarSenhaPossuiOitoDigitos(string senha)
        {
            if (senha.Count() > 8)
                return true;
            throw new Exception();
        }
    }
}