using Mercure.Common.Extension;
using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Transactions;
using Mercure.Patient.Infrastructure.Persistence.Model;
using Mercure.Patient.Infrastructure.Persistence.Query;

namespace Mercure.Patient.Infrastructure.Persistence.Transaction
{
    public class PatientTransaction : ITransaction<PatientModel>
    {
        readonly ITransaction<ConsultationModel> ConsultationTransaction;

        public PatientTransaction(IDBContext context, 
            ITransaction<ConsultationModel> consultationTransaction)
        {
            Context = context;
            ConsultationTransaction = consultationTransaction;
        }

        public IDBContext Context { get; private set; }

        public bool Delete(PatientModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public PatientModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", identifier}
            };

            var result = Context.ReadFirst<PatientModel>(PatientQueries.Get, parameters);

            result.Consultations = ConsultationTransaction.GetByParentKey(result.Id);

            return result;
        }

        public List<PatientModel> GetByParentKey(params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PatientModel persistence, params object[] parentKeys)
        {
            persistence.Id = Context.GetSequence("PATIENT_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@FIRST_NAME",persistence.FirstName},
                { "@LAST_NAME",persistence.LastName},
                { "@EMAIL",persistence.Email},
                { "@PHONE_NUMBER",persistence.PhoneNumber},
                { "@STREET",persistence.Street},
                { "@CITY",persistence.City},
                { "@POSTAL_CODE",persistence.PostalCode},
            };

            Context.Execute<PatientModel>(PatientQueries.Insert, parameters);

            foreach (var consultation in persistence.Consultations)
            {
                ConsultationTransaction.Insert(consultation);
            }

            return true;
        }

        public bool Update(PatientModel persistence, params object[] parentKeys)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@FIRST_NAME",persistence.FirstName},
                { "@LAST_NAME",persistence.LastName},
                { "@EMAIL",persistence.Email},
                { "@PHONE_NUMBER",persistence.PhoneNumber},
                { "@STREET",persistence.Street},
                { "@CITY",persistence.City},
                { "@POSTAL_CODE",persistence.PostalCode},
            };

            Context.Execute<PatientModel>(PatientQueries.Update, parameters);

            foreach (var consultation in persistence.Consultations)
            {
                ConsultationTransaction.ApplyChanges(consultation, persistence.Id);
            }

            return true;
        }
    }
}
