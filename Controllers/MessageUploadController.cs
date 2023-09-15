using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Advanced.Models;

namespace Advanced.Controllers
{
    [ApiController]
    [Route("Msg/[controller]")]
    public class MessageUploadController : ControllerBase
    {
        private readonly ILogger<ImageUploadController> _logger;
        private readonly IHubContext<RealTimeMessageHub> _hubContext;

        public MessageUploadController(ILogger<ImageUploadController> logger, IHubContext<RealTimeMessageHub> hubContext)
        {
            Console.WriteLine("MessageUploadController");
            _logger = logger;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage([FromQuery] string Message)
        {
            Console.WriteLine($"Got message {Message}");
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", Message);
            return Ok(new { message = "Message uploaded" });
        }
    }
}
