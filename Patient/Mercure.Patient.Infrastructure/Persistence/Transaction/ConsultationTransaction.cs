using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Transactions;
using Mercure.Patient.Infrastructure.Persistence.Model;
using Mercure.Patient.Infrastructure.Persistence.Query;

namespace Mercure.Patient.Infrastructure.Persistence.Transaction
{
    internal class ConsultationTransaction : ITransaction<ConsultationModel>
    {
        public ConsultationTransaction(IDBContext context)
        {
            Context = context;
        }

        public IDBContext Context { get; private set; }

        public bool Delete(ConsultationModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public ConsultationModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", identifier}
            };

            var result = Context.ReadFirst<ConsultationModel>(ConsultationQueries.Get, parameters);

            return result;
        }

        public List<ConsultationModel> GetByParentKey(params object[] parentKeys)
        {
            long? patientId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@PATIENT_ID",patientId},
            };

            var result = Context.Read<ConsultationModel>(ConsultationQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(ConsultationModel persistence, params object[] parentKeys)
        {
            long? patientId = parentKeys[0] as long?;
            persistence.Id = Context.GetSequence("PROFILE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@DATE",persistence.Date},
            };

            Context.Execute<ConsultationModel>(ConsultationQueries.Insert, parameters);

            return true;
        }

        public bool Update(ConsultationModel persistence, params object[] parentKeys)
        {
            long? patientId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@ID",persistence.Id.Value},
                { "@DATE",persistence.Date},
            };

            Context.Execute<ConsultationModel>(ConsultationQueries.Update, parameters);

            return true;
        }
    }
}
