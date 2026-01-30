using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

            var biryanis = new List<string>
            {
                "Chicken Biryani",
                "Mutton Biryani",
                "Vegetable Biryani"
            };

            try
            {
                foreach (var biryani in biryanis)
                {
                    if (cancellationToken.IsCancellationRequested) break;

                    var message = $"data: {biryani}\n\n";
                    await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(message), cancellationToken);
                    await Response.Body.FlushAsync(cancellationToken);
                    await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                }

                // Keep the connection open after the list is sent
                // while (!cancellationToken.IsCancellationRequested)
                // {
                //     await Task.Delay(TimeSpan.FromSeconds(15), cancellationToken);
                //     var heartbeatMessage = ": heartbeat\n\n";
                //     await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(heartbeatMessage), cancellationToken);
                //     await Response.Body.FlushAsync(cancellationToken);
                // }
            }
            catch (OperationCanceledException)
            {
                // Client disconnected, no action needed
            }
        }
    }
}
