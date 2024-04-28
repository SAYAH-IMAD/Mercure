namespace Mercure.Common.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public AggregateRoot(long? identifier)
        {
            Identifier = identifier;
        }

        public long? Identifier { get; set; }
    }
}
