using System;

namespace hoff.courses.Core.Exceptions
{
  /// <summary>
  /// Допустимые для работы приложения ошибки в бизнес-логике. 
  /// Могут использоваться для досрочного выхода из метода / показа сообщения пользователю.
  /// </summary>
  public class HoffException : Exception
  {
    public HoffException(string message) : base(message) { }

    public HoffException(string message, Exception? innerException) : base(message, innerException) { }
  }
}
