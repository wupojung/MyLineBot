using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Line.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLineBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineBotController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;
        private LineBotConfig _lineBotConfig;

        public LineBotController(IServiceProvider serviceProvider)
        {
            _httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _httpContext = _httpContextAccessor.HttpContext;
            //...略
            
            _lineBotConfig = new LineBotConfig();
            _lineBotConfig.channelSecret = "054284d9deba46e021a2ab0e58d3128b";
            _lineBotConfig.accessToken = "GIUq0gBAddH2qiJ8+AStMOWR9oINjFIVaQxiVOmbToRKqfMYFyMzC3mWMMhUmQ5r3JmCHPgRV9eNEfW7Fq6Hf9PZro9YLOfE/bXI753bH7AIggtEPYIfGcIe7Mxzl32XBG0XtyAygt7k/fToALZzygdB04t89/1O/w1cDnyilFU=";
        }
        
        [HttpPost("run")]   //POST {url}/api/linebot/run
        public async Task<IActionResult> Post()
        {
            var events = await _httpContext.Request.GetWebhookEventsAsync(_lineBotConfig.channelSecret);
            var lineMessagingClient = new LineMessagingClient(_lineBotConfig.accessToken);
            var lineBotApp = new LineBotApp(lineMessagingClient);
            await lineBotApp.RunAsync(events);
    
            return Ok();
        }
    
    }
}
