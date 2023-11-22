namespace MoveisCore.Models.ModelView;

public class MovelModelView
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool IsComprado { get; set; }

    public MovelModelView(string nome, string descricao, bool isComprado)
    {
        Nome = nome;
        Descricao = descricao;
        IsComprado = isComprado;
    }

    public MovelModelView()
    {
        
    }
}
