namespace Generic_Repo_Pattern.Repository
{
    public interface IGenericRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> Insert(T item);
        List<T> Update(T item);
        List<T> Delete(int id);
    }
}
