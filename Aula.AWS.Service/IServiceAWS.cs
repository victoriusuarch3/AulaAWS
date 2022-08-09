namespace Aula.AWS.Service
{
    public class IServiceAWS
    {
        Task<string> SalvarS3(IFormFile image);
        Task<bool> BuscarUsuarioImagem(string urlImagemCadastro, IFormFile image);
        Task DeletarImagem(string nomeBucket, string nomeArquivoNoS3);
        Taks<bool> ValidarImagem(string nomeArquivo);
    }
}