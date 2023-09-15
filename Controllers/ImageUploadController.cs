using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Advanced.Models;

namespace Advanced.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageUploadController : ControllerBase
    {
        private readonly ILogger<ImageUploadController> _logger;
        private readonly IHubContext<RealTimeImageHub> _hubContext;
        // private readonly IHubContext<RealTimeMessageHub> _hubContext;

        public ImageUploadController(ILogger<ImageUploadController> logger, IHubContext<RealTimeImageHub> hubContext)
        // public ImageUploadController(ILogger<ImageUploadController> logger, IHubContext<RealTimeMessageHub> hubContext)
        {
            Console.WriteLine("ImageUploadController");
            _logger = logger;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] string imageData, [FromForm] string encodeType)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveImage", imageData, encodeType);

            Console.WriteLine("Got image");

            return Ok(new { message = "Image uploaded" });
        }
    }
}
