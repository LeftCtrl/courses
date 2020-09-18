using Microsoft.Extensions.Options;
using NodaTime;
using System;
using System.Xml.Linq;

namespace hoff.courses.Core.Cbr.Implementation
{
  public class CbrService : CbrServiceBase, ICbrService
  {
    private CbrOptions _options;

    public CbrService(IOptions<CbrOptions> options)
    {
      _options = options.Value;
    }

    public XDocument GetCursOnDateXml(LocalDate date)
    {
      Uri cbrUri = new Uri(_options.CbrUri);
      string body = GetCursOnDateXmlBody(date);
      return SendRequest(body, cbrUri);
    }

    /// <summary>
    /// Тело запроса GetCursOnDateXml
    /// </summary>
    /// <param name="date">Дата, на которую запрашиваются курсы валют</param>
    /// <param name="cbrUri">Адрес api ЦБ РФ</param>
    /// <returns>Тело запроса GetCursOnDateXml</returns>
    private string GetCursOnDateXmlBody(LocalDate date)
    {
      return @$"
        <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
          <soap12:Body>
            <GetCursOnDateXML xmlns=""http://web.cbr.ru/"">
              <On_date>{date:yyyy-MM-dd}</On_date>
            </GetCursOnDateXML>
          </soap12:Body>
        </soap12:Envelope>";
    }
  }
}
