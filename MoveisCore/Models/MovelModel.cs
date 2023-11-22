using MoveisCore.Models.ModelView;

namespace MoveisCore.Models;

public class MovelModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool IsComprado { get; set; }

    public MovelModel(Guid id, string nome, string descricao, bool isComprado)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        IsComprado = isComprado;
    }

    public MovelModel(string nome, string descricao, bool isComprado)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        IsComprado = isComprado;
    }

    public MovelModel()
    {
        Id = Guid.NewGuid();
    }

    public MovelModelView ToModelView()
    {
        return new MovelModelView(Nome, Descricao, IsComprado);
    }
}
