using hoff.courses.BL.Services;
using hoff.courses.Core.DataProvider;
using hoff.courses.Core.Exceptions;
using hoff.courses.Models.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace hoff.courses.Controllers.V1
{
  /// <summary>
  /// Курсы валют
  /// </summary>
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CoursesController : ControllerBase
  {
    private ICourseService _courseService;
    private ILogger<CoursesController> _logger;

    public CoursesController(ICourseService courseService, ILogger<CoursesController> logger)
    {
      _courseService = courseService;
      _logger = logger;
    }

    /// <summary>
    /// Получение курса валюты на определенную дату (дата и валюта определяются алгоритмом самостоятельно)
    /// </summary>
    /// <param name="point">Координаты точки на плоскости</param>
    /// <returns>Информация о курсе валюты за определенную алгоритмом дату</returns>
    [HttpGet]
    public IActionResult Get([FromQuery] Point point)
    {
      Guid requestGuid = Guid.NewGuid();

      try
      {
        _logger.LogInformation($"{Request.Method} {Request.Path}{Request.QueryString} -requestId-{requestGuid}");
        
        ICurrencyCourse result = _courseService.GetCourse(point);
       
        _logger.LogInformation($"Done -requestId-{requestGuid}");
        return Ok(result);
      }
      catch (Exception ex)
      {
        if (ex is HoffException)
          _logger.LogWarning(ex, $"-requestId-{requestGuid}");
        else
          _logger.LogError(ex, $"-requestId-{requestGuid}");

        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
      }
    }
  }
}

