using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLineBot.Models;
using MyLineBot.Services;

namespace MyLineBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalkController : ControllerBase
    {
        public static List<TalkModel> entiyList;

        public TalkController()
        {
            entiyList = new List<TalkModel>()
            {
                new TalkModel() { Id = 1, Keyword = "ipas", Respond = "台灣最好的課程" },
                new TalkModel() { Id = 2, Keyword = "webapi", Respond = "是一種交換資料的方法" },
                new TalkModel() { Id = 3, Keyword = "line", Respond = "是一種通訊軟體" },
            };
        }

        [HttpGet]
        public List<TalkModel> Get()
        {
            return TalkService.ListTalk();
        }

        [HttpGet("{id}")]
        public TalkModel GetItem(int id)
        {
            return TalkService.GetTalk(id);
        }

        [HttpPost]
        public TalkModel Post([FromBody] TalkModel model)
        {
            return TalkService.InsertTalk(model);
        }

        [HttpPut("{id}")]
        public TalkModel Put(int id, [FromBody] TalkModel model)
        {
            model.Id = id;

            return TalkService.UpdateTalk(model);
        }

        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            return TalkService.DeleteTalk(id);
        }
    }
}