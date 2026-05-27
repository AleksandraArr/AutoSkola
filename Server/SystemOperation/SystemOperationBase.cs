using Common.Domain;
using DBBroker;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase
    {
        protected IBroker broker;

        public SystemOperationBase() : this(new Broker()) { }

        public SystemOperationBase(IBroker broker)
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
            }catch(Exception ex)
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
