using hoff.courses.Core.DataProvider;
using hoff.courses.Core.Exceptions;
using hoff.courses.Core.Geometry;
using Microsoft.Extensions.Options;
using NodaTime;
using System;

namespace hoff.courses.BL.Services.Implementation
{
  public class CourseService : ICourseService
  {
    private readonly IGeometryService _geometryService;
    private readonly IDataProvider _dataProvider;
    private readonly CourseOptions _options;

    public CourseService(
      IGeometryService geometryService,
      IDataProvider dataProvider,
      IOptions<CourseOptions> options)
    {
      _geometryService = geometryService;
      _dataProvider = dataProvider;
      _options = options.Value;
    }

    public ICurrencyCourse GetCourse(IPoint point)
    {
      if (!_geometryService.CheckPointInCircle(point, _options.CircleRadius))
        throw new HoffException("Координата находится вне круга");

      PlanePosition plainPosition = _geometryService.GetPlanePosition(point);
      LocalDate courseDate = ConvertPositionToDate(plainPosition);

      ICurrencyCourse? course = _dataProvider.GetCourse(courseDate, _options.CurrencyCode);
      if (course == null)
        throw new HoffException("Запрошенные данные не найдены");

      if (course.CourseDate < courseDate) //ЦБ присылает последние данные какие есть, даже если запрашивали на следующий день
        throw new HoffException($"Данные на {courseDate:yyyyMMdd} еще не доступны!");

      return course;
    }

    private LocalDate ConvertPositionToDate(PlanePosition plainPosition)
    {
      return plainPosition switch
      {
        PlanePosition.Quarter1 => LocalDate.FromDateTime(DateTime.Today),
        PlanePosition.Quarter2 => LocalDate.FromDateTime(DateTime.Today.AddDays(-1)),
        PlanePosition.Quarter3 => LocalDate.FromDateTime(DateTime.Today.AddDays(-2)),
        PlanePosition.Quarter4 => LocalDate.FromDateTime(DateTime.Today.AddDays(1)),
        PlanePosition.OnAxis => throw new HoffException("Не удалось определить четверть круга: точка лежит на оси координат"),
        _ => throw new HoffException("Не удалось определить четверть круга :("),
      };
    }
  }
}
