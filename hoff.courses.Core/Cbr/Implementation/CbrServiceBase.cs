using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace hoff.courses.Core.Cbr.Implementation
{
  /// <summary>
  /// Базовая логика общения с api ЦБ РФ
  /// </summary>
  public class CbrServiceBase
  {
    /// <summary>
    /// Запрос данных из ЦБ РФ
    /// </summary>
    /// <returns>Данные в xml-формате согласно описанию - https://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx </returns>
    protected XDocument SendRequest(string body, Uri cbrUri)
    {
      WebRequest request = CreateRequest(body, cbrUri);
      
      using (WebResponse response = request.GetResponse())
      using (Stream responseStream = response.GetResponseStream())
      {
        return XDocument.Load(responseStream);
      }
    }

    /// <summary>
    /// Создает запрос в API ЦБ РФ 
    /// </summary>
    /// <param name="body">Тело запроса</param>
    /// <param name="cbrUri">Адрес api ЦБ РФ</param>
    /// <returns>WebRequest, готовый к запуску</returns>
    protected WebRequest CreateRequest(string body, Uri cbrUri)
    {
      WebRequest request = WebRequest.Create(cbrUri);
      request.ContentType = "text/xml";
      request.Method = "POST";

      using (Stream requestStream = request.GetRequestStream())
      {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] bodyEncoded = encoding.GetBytes(body);
        requestStream.Write(bodyEncoded, 0, bodyEncoded.Length);
      }

      return request;
    }
  }
}
