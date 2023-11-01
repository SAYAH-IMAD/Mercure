namespace Mercure.Common.Domain
{
    public class Enumeration
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public Enumeration(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public static implicit operator string(Enumeration enumeration) => enumeration.Code;
    }
}
