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

        public IEntity Add(IEntity entity)
        {
            return Execute(() =>
            {
                using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = $"INSERT INTO {entity.TableName} OUTPUT inserted.{entity.IdColumn} VALUES({entity.Values})";
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    throw new Exception("Nije moguće dobiti ID nakon ubacivanja.");
                }

                entity.SetId(Convert.ToInt32(result));
                return entity;

            }
            }, "Add");
        }
        public void Delete(IEntity entity)
        {
            Execute(() =>
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.WhereCondition}";
                Debug.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }, "Delete");
        }

        public List<IEntity> GetByCondition(IEntity entity, string condition, string join = "")
        {
            return Execute(() =>
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM {entity.TableName} {join} WHERE {condition}";
                Debug.WriteLine(cmd.CommandText);
                using SqlDataReader reader = cmd.ExecuteReader();
                List<IEntity> list = entity.GetReaderList(reader);
                cmd.Dispose();
                return list;
            }, "GetByCondition");
        }
        public List<IEntity> Get(IEntity entity)
        {
            return Execute(() =>
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.WhereCondition}";
                using SqlDataReader reader = cmd.ExecuteReader();
                List<IEntity> list = entity.GetReaderList(reader);
                cmd.Dispose();
                return list;
            }, "Get");
        }
        public IEntity Update(IEntity obj)
        {
            return Execute(() =>
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"UPDATE {obj.TableName} SET {obj.UpdateText} WHERE {obj.WhereCondition}";
                Debug.WriteLine( cmd.CommandText );
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return obj;
            }, "Update");
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            return Execute(() =>
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM {entity.TableName}";
                using SqlDataReader reader = cmd.ExecuteReader();
                List<IEntity> list = entity.GetReaderList(reader);
                cmd.Dispose();
                return list;
            }, "GetAll");
        }

        private T Execute<T>(Func<T> action, string context)
        {
            try
            {
                return action();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL greška u {context}: {ex.Message}");
                throw new Exception($"Greška u bazi ({context})", ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Greška u {context}: {ex.Message}");
                throw new Exception($"Greška u {context}", ex);
            }
        }

    }
}