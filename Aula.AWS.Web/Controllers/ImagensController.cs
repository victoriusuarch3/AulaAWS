using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace Aula.AWS.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagensController : ControllerBase
    {
        private readonly IAmazonS3 _amazonS3;
        private static readonly List<string> _extensoesImagem = new List<string>(){"imageinjpeg", "imageinpng"};
        public ImagensController(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }

        [HttpPost]
        public async Task<IActionResult> CriarImagem(IFormFile imagem)
        {
            if(!_extensoesImagem.Contains(imagem.ContentType))
            {
                return BadRequest("Formato de imagem invalido, insira no formato JPEG ou PNG.");
            }
            using (var streamDaImagem = new MemoryStream())
            {  
                await imagem.CopyToAsync(streamDaImagem);  

                var request = new PutObjectRequest();
                request.Key = "reconhecimento" + imagem.FileName;
                request.BucketName = "imagem-Aulas";
                request.InputStream = streamDaImagem;
                
                var resposta = await _amazonS3.PutObjectAsync(request);
                return Ok(resposta);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarImagem(string nomeArquivoNoS3)
        {
            var resposta = await _amazonS3.DeleteObjectAsync("imagem-aulas", nomeArquivoNoS3);
            return Ok(resposta);
        }

        [HttpGet("bucket")]
        public async Task<IActionResult> ListarBuckets()
        {
            var resposta = await _amazonS3.ListBucketsAsync();
            
            return Ok(resposta.Buckets);
        }

        [HttpPost("bucket")]
        public async Task<IActionResult> CriarBucket(string nameBucket){
            var resposta = await _amazonS3.PutBucketAsync(nameBucket);
            return Ok(resposta);
        }
    }
}