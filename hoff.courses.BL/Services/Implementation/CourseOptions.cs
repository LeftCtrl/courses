namespace hoff.courses.BL.Services.Implementation
{
  /// <summary>
  /// Параметры, необходимые для работы CourseService
  /// </summary>
  public class CourseOptions
  {
    /// <summary>
    /// Радиус окружности
    /// </summary>
    public decimal CircleRadius { get; set; }

    /// <summary>
    /// Код иностранной валюты
    /// </summary>
    public string CurrencyCode { get; set; } = "";
  }
}
