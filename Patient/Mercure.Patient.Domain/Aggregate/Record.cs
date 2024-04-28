using Mercure.Common.Domain;

namespace Mercure.Patient.Domain.Aggregate
{
    internal class Record : IEntity
    {
        public Record(long? identifier)
        {
            Identifier = identifier;
        }

        public long? Identifier { get; set; }

        public static Record Create() => 
            new Record(null);
    }
}
