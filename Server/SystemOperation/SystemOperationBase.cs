using Common.Domain;
using DBBroker;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase
    {
        protected IBroker broker;

        protected SystemOperationBase() : this(new Broker()) { }

        protected SystemOperationBase(IBroker broker)
        {
            this.broker = broker;
        }


        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }catch(Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
