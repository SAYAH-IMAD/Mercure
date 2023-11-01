namespace Mercure.Common.Domain
{
    public interface IConverter<TValueObject, TPersistance>
    {
        static abstract TPersistance Convert(TValueObject value);
        static abstract TValueObject Convert(TPersistance value);
    }
}
