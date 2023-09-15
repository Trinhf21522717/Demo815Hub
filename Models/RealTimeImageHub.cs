using Microsoft.AspNetCore.SignalR;

namespace Advanced.Models;

public class RealTimeImageHub: Hub {
    // cái này được dùng để gọi bên cshtml
    public async Task SendImage(byte[] imageData) {
        await Clients.All.SendAsync("ReceiveImage", imageData);
    }
}