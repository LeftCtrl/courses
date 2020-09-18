namespace hoff.courses.Core.Geometry.Implementation
{
  public class GeometryService : IGeometryService
  {
    ///Алгоритм проверки на попадание точки в круг: https://taskcode.ru/if/circle-point
    ///Чтобы не терять точность вместо извлечения корня - возводим обе части в квадрат: https://www.yaklass.ru/p/algebra/8-klass/neravenstva-11023/svoistva-chislovykh-neravenstv-12298/re-d8bbf93c-7994-4231-8897-e46a4eed8d03
    public bool CheckPointInCircle(IPoint point, decimal circleRadius)
    {
      if (circleRadius < 0)
        return false;

      return point.X * point.X + point.Y * point.Y <= circleRadius * circleRadius;
    }

    public PlanePosition GetPlanePosition(IPoint point)
    {
      if (point.X == 0 || point.Y == 0)
        return PlanePosition.OnAxis;

      if (point.X > 0)
          return point.Y > 0 ? PlanePosition.Quarter1 : PlanePosition.Quarter2;

      return point.Y > 0 ? PlanePosition.Quarter4 : PlanePosition.Quarter3;
    }
  }
}
