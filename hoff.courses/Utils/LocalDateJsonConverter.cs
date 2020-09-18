using NodaTime;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace hoff.courses.Utils
{
  /// <summary>
  /// Сериализатор для типа LocalDate
  /// </summary>
  internal class LocalDateJsonConverter : JsonConverter<LocalDate>
  {
    /// <summary>
    /// формат строки для конвертации в/из LocalDate
    /// </summary>
    private readonly string _format;

    public LocalDateJsonConverter(string format)
    {
      _format = format;
    }

    public override LocalDate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      return LocalDate.FromDateTime(DateTime.Parse(reader.GetString()));
    }

    public override void Write(Utf8JsonWriter writer, LocalDate value, JsonSerializerOptions options)
    {
      writer.WriteStringValue(value.ToString(_format, CultureInfo.InvariantCulture));
    }
  }
}