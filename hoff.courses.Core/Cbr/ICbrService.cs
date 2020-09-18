using NodaTime;
using System.Xml.Linq;

namespace hoff.courses.Core.Cbr
{
  /// <summary>
  /// Работа с API ЦБ РФ
  /// </summary>
  /// Описание API - https://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx
  public interface ICbrService
  {
    /// <summary>
    /// Получение ежедневных курсов валют
    /// </summary>
    /// <param name="date">Дата курсов валют</param>
    /// <returns>Курсы валют в формате - https://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx?op=GetCursOnDateXML </returns>
    public XDocument GetCursOnDateXml(LocalDate date);
  }
}
