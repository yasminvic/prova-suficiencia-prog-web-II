namespace Domain.Interfaces.IServices
{
    public interface IBaseService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<int> Save(T entity);
        Task<int> Delete(int id);
    }
}
