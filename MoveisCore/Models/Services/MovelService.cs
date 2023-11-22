using MoveisCore.Models.ModelView;
using MoveisCore.Models.Persistence;

namespace MoveisCore.Models.Services;

public class MovelService
{
    private readonly MovelDAO _movelDAO;

    public MovelService()
    {
        _movelDAO = new MovelDAO();
    }

    public bool Adicionar(MovelModelView modelView)
    {
        if (modelView is null)
            return false;

        var movel = new MovelModel(modelView.Nome, modelView.Descricao, modelView.IsComprado);

        _movelDAO.Add(movel);

        return true;
    }

    public bool Atualizar(Guid id, MovelModelView modelView)
    {
        if (modelView is null)
            return false;

        var movel = new MovelModel(modelView.Nome, modelView.Descricao, modelView.IsComprado);

        _movelDAO.Update(id, movel);

        return true;
    }

    public bool Remover(string nome)
    {
        var id = _movelDAO.GetAll().Find(x => x.Nome == nome).Id;
        _movelDAO.Remove(id);

        return true;
    }

    public List<MovelModel> ObterTodos()
    {
        var list = _movelDAO.GetAll();

        return list.Select(x => new MovelModel(x.Id, x.Nome, x.Descricao, x.IsComprado)).ToList();
    }

    public List<MovelModelView> ObterTodosAsModelView()
    {
        var moveis = ObterTodos();

        return moveis.Select(x => x.ToModelView()).ToList();
    }

    public MovelModel? ObterPorId(Guid id)
    {
        var entity = _movelDAO.GetById(id);

        if (entity is null)
            return null;

        return new MovelModel(entity.Id, entity.Nome, entity.Descricao, entity.IsComprado);
    }
}
