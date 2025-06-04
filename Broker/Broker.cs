using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public void Add(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.TableName} VALUES({entity.Values} )";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public void Delete(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.WhereCondition}";
            Debug.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<IEntity> GetByCondition(IEntity entity, string condition, string join = "")
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} {join} WHERE {condition}";
            Debug.WriteLine(cmd.CommandText);
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            cmd.Dispose();
            return list;
        }
        public List<IEntity> Get(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.WhereCondition}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            cmd.Dispose();
            return list;
        }
        public IEntity Update(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE {obj.TableName} SET {obj.UpdateText} WHERE {obj.WhereCondition}";
            Debug.WriteLine( cmd.CommandText );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return obj;
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            cmd.Dispose();
            return list;
        }
       

        
    }
}