namespace ExplorerDesktop.Domain;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();

    T Get(string key);
    
    void Create(T entry);

    void Delete(T entry);

    void Update(string key, T entry);
}