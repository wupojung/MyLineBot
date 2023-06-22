using MyLineBot.Models;

namespace MyLineBot.Services;

public static class TalkService
{
    public static List<TalkModel> _db;

    static TalkService()
    {
        _db = new List<TalkModel>()
        {
            new TalkModel() { Id = 1, Keyword = "ipas", Respond = "台灣最好的課程" },
            new TalkModel() { Id = 2, Keyword = "webapi", Respond = "是一種交換資料的方法" },
            new TalkModel() { Id = 3, Keyword = "line", Respond = "是一種通訊軟體" },
        };
    }

    public static List<TalkModel> ListTalk()
    {
        return _db;
    }

    public static TalkModel GetTalk(int id)
    {
        return _db.Where(x => x.Id == id).FirstOrDefault();
    }

    public static TalkModel InsertTalk(TalkModel model)
    {
        model.Id = _db.Max(x => x.Id) + 1;  //max id +1 = new id 
        _db.Add(model);
        return model; //update     
    }

    public static TalkModel UpdateTalk(TalkModel model)
    {
        TalkModel target = _db.Where(x => x.Id == model.Id).FirstOrDefault();
        if (target != null)
        {
            target.Keyword = model.Keyword;
            target.Respond = model.Respond;
        }

        return target;
    }

    public static int DeleteTalk(int id)
    {
        TalkModel target = _db.Where(x => x.Id == id).FirstOrDefault();
        if (target != null)
        {
            _db.Remove(target);
        }

        return _db.Count;
    }
}