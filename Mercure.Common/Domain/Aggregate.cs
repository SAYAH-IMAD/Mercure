namespace Mercure.Common.Domain
{
    public abstract class Aggregate : IAggregate
    {
        public Aggregate(long? identifier)
        {
            Identifier = identifier;
        }

        public long? Identifier { get; set; }
    }
}
