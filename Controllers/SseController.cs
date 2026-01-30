
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

            var i = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var message = $"data: Message {i++} at {DateTime.Now}\n\n";
                    await Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(message), cancellationToken);
                    await Response.Body.FlushAsync(cancellationToken);
                    await Task.Delay(1000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    }
}
