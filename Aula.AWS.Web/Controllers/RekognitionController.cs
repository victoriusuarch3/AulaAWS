using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Mvc;
namespace Aula.AWS.Web.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RekognitionController : ControllerBase
    {
        private readonly AmazonRekognitionClient _rekognitionCliente;
        public RekognitionController(AmazonRekognitionClient rekognitionClient)
        {
            _rekognitionCliente = rekognitionClient;
        }

        [HttpGet]
        public async Task<IActionResult> DetectorFacial(string nomeArquivo){
            var entrada = new DetectFacesRequest();
            var imagem = new Image();

            var s3Object = new S3Object(){
                Bucket = "reconhecimento-api",
                Name = nomeArquivo
            }; 

            imagem.S3Object = s3Object;
            entrada.Image = imagem;
            entrada.Attributes = new List<string>(){"ALL"};
            var resposta = await _rekognitionCliente.DetectFacesAsync(entrada);
            return Ok(resposta);
        }
    }
}