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
        /*
        [HttpPost]
        public async Task<IActionResult> PostImage()
        {
            // Đọc dữ liệu từ phần thân yêu cầu dưới dạng luồng
            using (Stream requestStream = Request.Body)
            {
                try
                {
                    byte[] buffer = new byte[1024]; // Buffer để đọc dữ liệu
                    int bytesRead;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        while ((bytesRead = await requestStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesRead);
                        }
                        byte[] imageData = memoryStream.ToArray();


                        // Console.WriteLine(_hubContext.Clients.Count());

                        await _hubContext.Clients.All.SendAsync("ReceiveImage", imageData);
                        // _hubContext.SendImage()

                        Console.WriteLine("Anh up roi ne");
                        Console.WriteLine(imageData.Length);

                        // Xử lý dữ liệu ảnh ở đây
                        // imageData chứa dữ liệu ảnh dưới dạng byte[]
                        // Ví dụ: Lưu trữ ảnh vào một tệp trên máy chủ
                        // File.WriteAllBytes("path/to/save/image.jpg", imageData);

                        return Ok(new { message = "Image uploaded" });
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    return StatusCode(500, new { message = "Error processing the request" });
                }
            }
        }
        */

        /*
        [HttpPost]
        public async Task<IActionResult> PostImage(ICollection<IFormFile> files)
        {
            Console.WriteLine($"Count {files.Count()}");
            await _hubContext.Clients.All.SendAsync("ReceiveImage", new {imageData = files.FirstOrDefault()});
            // _hubContext.SendImage()

            Console.WriteLine("Anh up roi ne");

            // Xử lý dữ liệu ảnh ở đây
            // imageData chứa dữ liệu ảnh dưới dạng byte[]
            // Ví dụ: Lưu trữ ảnh vào một tệp trên máy chủ
            // File.WriteAllBytes("path/to/save/image.jpg", imageData);

            return Ok(new { message = "Image uploaded" });
        }
        */

        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] string imageData)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveImage", imageData);
            // _hubContext.SendImage()

            Console.WriteLine("Anh up roi ne");
            Console.WriteLine(imageData);

            // Xử lý dữ liệu ảnh ở đây
            // imageData chứa dữ liệu ảnh dưới dạng byte[]
            // Ví dụ: Lưu trữ ảnh vào một tệp trên máy chủ
            // File.WriteAllBytes("path/to/save/image.jpg", imageData);

            return Ok(new { message = "Image uploaded" });
        }

        /*
        [HttpPost]
        public async Task<IActionResult> PostImage([FromQuery] string Message)
        {

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", Message);
            // _hubContext.SendImage()

            Console.WriteLine($"Message up roi ne {Message}");
            // Console.WriteLine(imageData.Length);

            // Xử lý dữ liệu ảnh ở đây
            // imageData chứa dữ liệu ảnh dưới dạng byte[]
            // Ví dụ: Lưu trữ ảnh vào một tệp trên máy chủ
            // File.WriteAllBytes("path/to/save/image.jpg", imageData);

            return Ok(new { message = "Image uploaded" });
        }
        */
    }
}
