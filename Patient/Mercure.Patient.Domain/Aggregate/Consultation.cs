using Mercure.Common.Domain;

namespace Mercure.Patient.Domain.Aggregate
{
    public class Consultation : IEntity
    {
        public Consultation(long? identifier, 
            DateTime date)
        {
            Identifier = identifier;
            Date = date;
        }

        public long? Identifier { get; set; }
        public DateTime Date { get; private set; }

        public static Consultation Create(DateTime date) =>
            new(null, date);
    }
}
