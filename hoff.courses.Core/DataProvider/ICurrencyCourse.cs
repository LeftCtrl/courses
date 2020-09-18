using NodaTime;

namespace hoff.courses.Core.DataProvider
{
  /// <summary>
  /// Информация о курсе валюты по отношению к одному рублю на определенную дату
  /// </summary>
  public interface ICurrencyCourse
  {
    /// <summary>
    /// Дата, на которую актуален курс валюты
    /// </summary>
    LocalDate CourseDate { get; set; }

    /// <summary>
    /// Курс валюты по отношению к одному рублю
    /// </summary>
    decimal CourseValue { get; }

    /// <summary>
    /// Наименование валюты
    /// </summary>
    string CurrencyName { get; }
  }
}