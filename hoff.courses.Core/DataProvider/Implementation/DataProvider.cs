using hoff.courses.Core.Cbr;
using hoff.courses.Core.Cbr.Implementation.Parser;
using NodaTime;
using System.Xml.Linq;

namespace hoff.courses.Core.DataProvider.Implementation
{
  public class DataProvider : IDataProvider
  {
    private ICbrService _cbrService;

    public DataProvider(ICbrService cbrService)
    {
      _cbrService = cbrService;
    }

    public ICurrencyCourse? GetCourse(LocalDate courseDate, string currencyCode)
    {
      XDocument courses = _cbrService.GetCursOnDateXml(courseDate);
      return CbrParser.GetCourse(courses, currencyCode);
    }
  }
}
