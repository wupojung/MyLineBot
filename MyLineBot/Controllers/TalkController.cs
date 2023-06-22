using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLineBot.Models;

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
            return entiyList;
        }

        [HttpGet("{id}")]
        public TalkModel GetItem(int id)
        {
            return entiyList.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public TalkModel Post([FromBody] TalkModel model)
        {
            model.Id = entiyList.Count;
            entiyList.Add(model);
            return model; //update 
        }

        [HttpPut("{id}")]
        public TalkModel Put(int id, [FromBody] TalkModel model)
        {
            TalkModel target = entiyList.Where(x => x.Id == id).FirstOrDefault();
            if (target != null)
            {
                target.Keyword = model.Keyword;
                target.Respond = model.Respond;
            }

            return target;
        }

        [HttpDelete("{id:int}")]
        public int Delete(int id)
        {
            TalkModel target = entiyList.Where(x => x.Id == id).FirstOrDefault();
            if (target != null)
            {
                entiyList.Remove(target);
            }

            return entiyList.Count;
        }
    }
}