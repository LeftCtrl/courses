namespace hoff.courses.Core.Geometry
{
  /// <summary>
  /// Координаты точки в двухмерном пространстве
  /// </summary>
  public interface IPoint
  {
    /// <summary>
    /// Координата по оси X
    /// </summary>
    public decimal X { get; }
    /// <summary>
    /// Координата по оси Y
    /// </summary>
    public decimal Y { get; }
  }
}