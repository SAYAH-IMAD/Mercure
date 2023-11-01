using System.Text.Json;

namespace Mercure.Common.Helper
{
    public static class JsonSerializerHelper
    {
        public static object DeserializeStreamToObject(Stream stream) 
        {
            using var reader = new StreamReader(stream);
            stream.Seek(0, SeekOrigin.Begin);
            string json = reader.ReadToEnd();
           
            if (string.IsNullOrEmpty(json))
                return json;
            else
                return JsonSerializer.Deserialize<object>(json);
        }

        public static MemoryStream SerializeObjectToStream<T>(T @object)
        {
            return new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(@object));
        }
    }
}
