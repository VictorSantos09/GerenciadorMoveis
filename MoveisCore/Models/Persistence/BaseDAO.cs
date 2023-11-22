using System.Text.Json;

namespace MoveisCore.Models.Persistence;

public abstract class BaseDAO
{
    private readonly string _pathFile = $@"{Directory.GetCurrentDirectory()}\Models\Persistence\Moveis.json";

    public void Add(MovelModel entity)
    {
        var list = GetAll();

        list.Add(entity);

        string json = JsonSerializer.Serialize(list);
        File.WriteAllText(_pathFile, json);
    }
    public List<MovelModel> GetAll()
    {
        using (StreamReader r = new StreamReader(_pathFile))
        {
            string json = r.ReadToEnd();

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<MovelModel>();
            }

            return JsonSerializer.Deserialize<List<MovelModel>>(json);
        }
    }
    public MovelModel? GetById(Guid id)
    {
        return GetAll().Find(x => x.Id == id);
    }
    public void Remove(Guid id)
    {
        var list = GetAll();

        var entity = list.Find(x => x.Id == id);

        if (entity == null)
            return;

        list.Remove(entity);

        string json = JsonSerializer.Serialize(list);
        File.WriteAllText(_pathFile, json);
    }
    public void Update(Guid id, MovelModel newEntity)
    {
        var list = GetAll();

        var entity = list.Find(x => x.Id == id);

        if (entity == null)
            return;

        list.Remove(entity);

        list.Add(newEntity);

        string json = JsonSerializer.Serialize(list);
        File.WriteAllText(_pathFile, json);
    }
}
