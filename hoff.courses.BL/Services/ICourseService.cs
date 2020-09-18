using hoff.courses.Core.DataProvider;
using hoff.courses.Core.Geometry;

namespace hoff.courses.BL.Services
{
  /// <summary>
  /// Операции с курсами валют.
  /// Обслуживает CoursesController.
  /// </summary>
  public interface ICourseService
  {
    /// <summary>
    /// Получить курс валюты по отношению к 1 рублю
    /// </summary>
    /// <param name="point">Координата, по которой вычисляется курс</param>
    /// <returns>Информация о валюте и ее курсе</returns>
    ICurrencyCourse GetCourse(IPoint point);
  }
}