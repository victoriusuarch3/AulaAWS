using Amazon.S3;
using Microsoft.AspNetCore.Mvc;

namespace Aula.AWS.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagensController : ControllerBase
    {
        private readonly IAmazonS3 _amazonS3;
        public ImagensController(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }

        [HttpPost("bucket")]
        public async Task<IActionResult> CriarBucket(string nomeBucket)
        {
        var resposta = await _amazonS3.PutBucketAsync(nomeBucket);
        return Ok(resposta);
        }
    }
}