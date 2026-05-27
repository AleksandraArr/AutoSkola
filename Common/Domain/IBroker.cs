namespace Common.Domain
{
    public interface IBroker
    {
        void OpenConnection();
        void CloseConnection();
        void BeginTransaction();
        void Commit();
        void Rollback();

        IEntity Add(IEntity entity);
        void Delete(IEntity entity);
        IEntity Update(IEntity entity);
        List<IEntity> Get(IEntity entity);
        List<IEntity> GetAll(IEntity entity);
        List<IEntity> GetByCondition(IEntity entity, string condition, string join = "");
    }
}
