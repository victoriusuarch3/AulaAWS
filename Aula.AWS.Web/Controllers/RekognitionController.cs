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

        [HttpGet] //analisar
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

            if(resposta.FaceDetails.Count == 1 && resposta.FaceDetails.First().Eyeglasses.Value == false)
            {
                return Ok(resposta);
            }
            else
            {
                return BadRequest();
            }

            
                
        }
        [HttpPost] //comparar
            public async Task<bool> CompararRostoAsync(string nomeArquivoS3, IFormFile fotoLogin)
        { 
            using (var memoryStream = new MemoryStream())
            {
                var request = new CompareFacesRequest();
                var requestsourceImagem = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Bucket = "reconhecimento-api",
                        Name = nomeArquivoS3
                    }
                };
                    
                await fotoLogin.CopyToAsync(memoryStream);

                var requesttargetImagem = new Image()
                {
                    Bytes = memoryStream
                };
                request.SourceImage = requestsourceImagem;  
                request.TargetImage = requesttargetImagem;

                var resposta = await _rekognitionCliente.CompareFacesAsync(request);
                return true;
            }
    }
  }
}