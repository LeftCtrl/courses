namespace hoff.courses.Core.Geometry
{
  /// <summary>
  /// Геометрические алгоритмы
  /// </summary>
  public interface IGeometryService
  {
    /// <summary>
    /// Проверка на попадание точки в круг заданного радиуса с центром в начале координат
    /// </summary>
    /// <param name="point">Координаты точки</param>
    /// <param name="circleRadius">Радиус круга</param>
    /// <returns>true если точка попадает в круг или лежит на его окружности, иначе false</returns>
    bool CheckPointInCircle(IPoint point, decimal circleRadius);

    /// <summary>
    /// Определяет, к какой четверти плоскости принадлежит точка.
    /// </summary>
    /// <param name="point">Координаты точки</param>
    /// <returns>Четверть плоскости, к которой относится точка</returns>
    PlanePosition GetPlanePosition(IPoint point);
  }
}