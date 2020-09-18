using NodaTime;

namespace hoff.courses.Core.DataProvider.Implementation
{
  internal class CurrencyCourse : ICurrencyCourse
  {
    /// <summary>
    /// Информация о курсе валюты по отношению к одному рублю на определенную дату
    /// </summary>
    /// <param name="courseDate">Дата, на которую актуален курс валюты</param>
    /// <param name="courseValue">Курс валюты по отношению к одному рублю</param>
    /// <param name="currencyName">Наименование валюты</param>
    public CurrencyCourse(LocalDate courseDate, decimal courseValue, string currencyName)
    {
      CourseDate = courseDate;
      CourseValue = courseValue;
      CurrencyName = currencyName;
    }

    public LocalDate CourseDate { get; set; }
    public decimal CourseValue { get; set; }
    public string CurrencyName { get; set; }
  }
}
