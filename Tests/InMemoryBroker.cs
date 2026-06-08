using Common.Domain;

namespace Tests
{
    public class InMemoryBroker : IBroker
    {
        //Dictionary sa parovima {nazivTabele} i {redUBazi}
        private readonly Dictionary<string, List<IEntity>> store = new();
        private int nextId = 1;

        private List<IEntity> GetTable(string tableName)
        {
            if (!store.ContainsKey(tableName))
                store[tableName] = new List<IEntity>();
            return store[tableName];
        }

        public IEntity Add(IEntity entity)
        {
            entity.SetId(nextId++);
            GetTable(entity.TableName).Add(entity);
            return entity;
        }

        public void Delete(IEntity entity)
        {
            var table = GetTable(entity.TableName);
            var toRemove = table.FirstOrDefault(e => e.WhereCondition == entity.WhereCondition);
            if (toRemove != null)
                table.Remove(toRemove);
        }

        public IEntity Update(IEntity entity)
        {
            var table = GetTable(entity.TableName);
            var index = table.FindIndex(e => e.WhereCondition == entity.WhereCondition);
            if (index == -1)
                throw new InvalidOperationException($"Entitet nije pronađen u tabeli '{entity.TableName}'.");
            table[index] = entity;
            return entity;
        }

        public List<IEntity> Get(IEntity entity)
        {
            return GetTable(entity.TableName)
                .Where(e => e.WhereCondition == entity.WhereCondition)
                .ToList();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            return GetTable(entity.TableName).ToList();
        }

        public List<IEntity> GetByCondition(IEntity entity, string condition, string join = "")
        {
            return GetTable(entity.TableName).ToList();
        }

        public void OpenConnection() { }
        public void CloseConnection() { }
        public void BeginTransaction() { }
        public void Commit() { }
        public void Rollback() { }
    }
}
