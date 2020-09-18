using hoff.courses.Core.DataProvider;
using hoff.courses.Core.DataProvider.Implementation;
using NodaTime;
using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace hoff.courses.Core.Cbr.Implementation.Parser
{
  /// <summary>
  /// Класс для извлечения данных их xml полученных от Api ЦБ РФ
  /// </summary>
  internal static class CbrParser
  {
    /// <summary>
    /// Извлекает данные по конкретному курсу из списка
    /// </summary>
    /// <param name="courses">Список курсов валют, xml в формате - https://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx?op=GetCursOnDateXML </param>
    /// <param name="currencyCode">Наименование валюты</param>
    /// <returns>Информация о курсе валюты по отношению к одному рублю на определенную дату</returns>
    public static ICurrencyCourse? GetCourse(XDocument doc, string currencyCode)
    {
      string? courseDate = doc.Root
        .Descendants("ValuteData")
        .FirstOrDefault()?
        .Attribute("OnDate")?.Value;

      if (courseDate == null)
        return null;

      XElement? course = doc
        .Descendants("ValuteCursOnDate")
        .Where(course => string.Equals(course.Element("VchCode")?.Value, currencyCode, StringComparison.OrdinalIgnoreCase))
        .FirstOrDefault();

      string? courseValue = course.Element("Vcurs")?.Value;
      string? courseName = course.Element("Vname")?.Value;

      if (courseValue == null || courseName == null)
        return null;

      return new CurrencyCourse(
        LocalDate.FromDateTime(DateTime.ParseExact(courseDate, "yyyyMMdd", CultureInfo.InvariantCulture)),
        decimal.Parse(courseValue, CultureInfo.InvariantCulture),
        courseName);
    }
  }
}
