namespace Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task Create(T entity);

        Task SaveChanges();
    }
}
