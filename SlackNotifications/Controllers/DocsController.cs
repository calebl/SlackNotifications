using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlackNotifications.Data;
using SlackNotifications.Services;

namespace SlackNotifications.Controllers
{
    [Route("api/[controller]")]
    public class DocsController : Controller
    {
        private readonly IDocsService _docsService;

        public DocsController(IDocsService docsService)
        {
            _docsService = docsService;
        }
        
        [HttpPost("")]
        public async Task<ActionResult> PostDocAsync([FromBody] Document document)
        {
            await _docsService.SubmitDocumentAsync(document);

            return Ok();
        }
    }
}