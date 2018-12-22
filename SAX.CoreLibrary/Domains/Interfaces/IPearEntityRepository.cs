
namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface IPearEntityRepository<TEntity> where TEntity : class
    {
        bool IsExists(TEntity entity);
        bool IsExists(object primaryKey);
        bool IsExists(string pearValue);
    }
}
