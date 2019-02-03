using Newtonsoft.Json;

namespace TestLibrary.Helpers
{
    public static class SerializeHelper
    {
        public static string SerializeIntended(this object input, bool hasToBeCleaned = false)
        {
            var serializedObject = JsonConvert.SerializeObject(input, Formatting.Indented);

            return hasToBeCleaned ? serializedObject.Clean() : serializedObject;
        }

        public static T Deserialize<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
