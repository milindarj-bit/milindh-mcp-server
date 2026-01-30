using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace myapp.Controllers
{
    public class SseController : Controller
    {
        [HttpGet]
        public async Task Stream(CancellationToken cancellationToken)
        {
            Response.ContentType = "text/event-stream";
            Response.Headers.Append("Cache-Control", "no-cache");
            Response.Headers.Append("Connection", "keep-alive");

            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken); // Initial delay

            try
            {
                // Send initial data messages
                await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes("data: Starting up...\n\n"), cancellationToken);
                await Response.Body.FlushAsync(cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

                await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes("data: Almost there...\n\n"), cancellationToken);
                await Response.Body.FlushAsync(cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

                await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes("data: Ready!\n\n"), cancellationToken);
                await Response.Body.FlushAsync(cancellationToken);

                // Start the heartbeat loop
                var heartbeatMessage = ": heartbeat\n\n";
                var heartbeatDelay = TimeSpan.FromSeconds(15);

                while (!cancellationToken.IsCancellationRequested)
                {
                    await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(heartbeatMessage), cancellationToken);
                    await Response.Body.FlushAsync(cancellationToken);
                    await Task.Delay(heartbeatDelay, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Client disconnected, no action needed
            }
        }
    }
}
