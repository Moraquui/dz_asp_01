using Asp.Net_HW_Module_02_ч1.Models.Animals;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Asp.Net_HW_Module_02_ч1.Services
{


        public class AnimalJsonConverter : JsonConverter<Animal>
        {
        private enum TypeDiscriminator
        {
            Animal = 0,
            Cat = 1,
            Dog = 2
        }
        public override bool CanConvert(Type type)
        {
            return typeof(Animal).IsAssignableFrom(type);
        }
        public override Animal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            string propertyName = null;
            string name = null;
            int age = 0;
            TypeDiscriminator typeDiscriminator = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    // Завершение чтения текущего объекта
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read(); // Переход к значению свойства

                    switch (propertyName)
                    {
                        case "TypeDiscriminator":
                            typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
                            break;
                        case "TypeValue":
                            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                            {
                                if (reader.TokenType == JsonTokenType.PropertyName)
                                {
                                    var propName = reader.GetString();
                                    reader.Read(); // Переход к значению свойства

                                    switch (propName)
                                    {
                                        case "Name":
                                            name = reader.GetString();
                                            break;
                                        case "Age":
                                            age = reader.GetInt32();
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            if (name == null || age == null)
            {
                throw new JsonException("Name or Age is not provided.");
            }

            // Создание объекта на основе прочитанных данных
            switch (typeDiscriminator)
            {
                case TypeDiscriminator.Cat:
                    return new Cat(new ConsoleOutputService(), name, age);
                case TypeDiscriminator.Dog:
                    return new Dog (name, age);
                default:
                    throw new NotSupportedException($"Unsupported TypeDiscriminator value: {typeDiscriminator}");
            }
        }

        public override void Write(Utf8JsonWriter writer, Animal value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is Cat derivedA)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Cat);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedA);
            }
            else if (value is Dog derivedB)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Dog);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedB);
            }
            else
            {
                throw new NotSupportedException();
            }

            writer.WriteEndObject();
        }
    }

}
