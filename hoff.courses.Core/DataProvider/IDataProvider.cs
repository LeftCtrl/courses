using NodaTime;

namespace hoff.courses.Core.DataProvider
{
  /// <summary>
  /// Предоставляет данные для высокоуровневой логики в удобном виде
  /// </summary>
  public interface IDataProvider
  {
    /// <summary>
    /// Информация о курсе валюты по отношению к одному рублю на определенную дату
    /// </summary>
    /// <param name="courseDate">Дата, на которую актуален курс валюты</param>
    /// <param name="currencyCode">Наименование валюты</param>
    /// <returns></returns>
    ICurrencyCourse? GetCourse(LocalDate courseDate, string currencyCode);
  }
}
