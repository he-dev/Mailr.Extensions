using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Custom;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reusable.Exceptionize;
using Reusable.Reflection;

namespace Mailr.Extensions.Gunter.Json
{
    // Deserializes test-result modules from a dictionary where keys are module-type-names.
    internal class DictionaryConverter<TValue> : JsonConverter
    {
        // ReSharper disable once StaticMemberInGenericType - We want this to be static for the current type.
        private static readonly IDictionary<string, Type> ModuleTypes;

        static DictionaryConverter()
        {
            ModuleTypes =
                typeof(TValue)
                    .Assembly
                    .GetTypes()
                    .Where(t => t.IsClass && typeof(TValue).IsAssignableFrom(t))
                    .ToDictionary(t => t.Name);
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType.IsGenericType &&
                objectType.GetGenericTypeDefinition().In(
                    typeof(IDictionary<,>), 
                    typeof(Dictionary<,>)
                );
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var keyType = objectType.GetGenericArguments()[0];
            var valueType = objectType.GetGenericArguments()[1];
            var dictionaryType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
            var modules = (IDictionary)Activator.CreateInstance(dictionaryType);

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var moduleName = reader.Value.ToString();
                    if (reader.Read() && reader.TokenType == JsonToken.StartObject)
                    {
                        var moduleToken = JToken.ReadFrom(reader);
                        var module = serializer.Deserialize(moduleToken.CreateReader(), ModuleTypes[moduleName]);
                        modules.Add(moduleName, module);
                    }
                    else
                    {
                        throw DynamicException.Create
                        (
                            $"DictionaryNotFound",
                            $"Expected a JsonObject but found {reader.TokenType}"
                        );
                    }
                }
                else if (reader.TokenType == JsonToken.EndObject)
                {
                    // Stop reading the current object. 
                    // If we keep going then we break the parsing for the rest of the json.
                    break;
                }
            }

            return modules;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not requried in this scenario because it's only for reading.");
        }

        // I'll let it here and implement it another time...
        //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    var dictionary = (IDictionary)value;
        //    writer.WriteStartArray();
        //    foreach (var key in dictionary.Keys)
        //    {
        //        writer.WriteStartObject();
        //        writer.WritePropertyName("Key");
        //        serializer.Serialize(writer, key);
        //        writer.WritePropertyName("Value");
        //        serializer.Serialize(writer, dictionary[key]);
        //        writer.WriteEndObject();
        //    }
        //    writer.WriteEndArray();
        //}
    }
}