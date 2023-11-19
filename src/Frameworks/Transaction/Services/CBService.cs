namespace Transaction.Framework.Services.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using Transaction.Framework.Domain;
    using Transaction.Framework.Exceptions;

    public class CBService : ICBService
    {

        private System.Xml.XmlDocument xd;
        private XmlNamespaceManager nm;
        private string targetNamespace;    
        public string ServiceURL = "http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx"; // //TODO

        public async Task<string> GetData(Data request, DateTime? dt)
        {
            try
            {
                xd = new System.Xml.XmlDocument();
                xd.Load(ServiceURL + "?WSDL"); 
                nm = new XmlNamespaceManager(xd.NameTable);
                nm.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
                nm.AddNamespace("s", "http://www.w3.org/2001/XMLSchema");
                nm.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                nm.PushScope();
                targetNamespace = xd.SelectSingleNode("/wsdl:definitions/@targetNamespace", nm).Value;

                //TODO
                string met_name = "GetCursDynamic";

                XmlDocument ret_xml = SendSOAPQueryToServer(request, ServiceURL, met_name, dt);
                if (ret_xml == null) return null;

                string srr = "/soap:Envelope/soap:Body";
                XmlNode rs = ret_xml.SelectSingleNode(srr, nm);
                rs = rs.FirstChild;
                if (rs != null)
                {
                    if (rs.SelectSingleNode("*/s:schema", nm) != null)
                    {
                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        XmlReader reader = XmlReader.Create(new StringReader(rs.InnerXml), settings);
                        System.Data.DataSet sd = new DataSet();
                        sd.ReadXml(reader);
                        return rs.InnerXml;
                    }
                    else
                    {
                        return rs.FirstChild.InnerXml;
                    }
                }
                else
                {
                    throw new InvalidRequestFromCBException();
                    await Task.CompletedTask;

                }
            }
            catch (Exception ex)
            {
                throw new InvalidRequestFromCBException();
                await Task.CompletedTask;
            }
            return null;
        }



        #region private helpers

        private System.Xml.XmlDocument SendSOAPQueryToServer(Data request, string ReqString, string method_name, DateTime? dt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
                sb.Append("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                sb.Append("<soap:Body>");
                sb.Append("<" + method_name + " xmlns=\"" + targetNamespace + "\">");
                XmlNodeList Params = xd.SelectNodes("/wsdl:definitions/wsdl:types/s:schema/s:element[@name='" + method_name + "']/s:complexType/s:sequence/s:element", nm);

                for (int i = 0; i < Params.Count; i++)
                {
                    string param_name = Params[i].SelectSingleNode("@name").Value;
                    string val = "";
                    switch (param_name)
                    {
                        case "FromDate":
                            val = request.FromDate != null ? request.FromDate : dt?.ToString("yyyy-MM-dd");
                            break;
                        case "ToDate":
                            val = request.ToDate != null ? request.ToDate : dt?.ToString("yyyy-MM-dd");
                            break;
                        case "ValutaCode":
                            val = request.ValutaCode;
                            break;
                        default:
                            break;
                    }
                    sb.Append("<" + param_name + ">" + val + "</" + param_name + ">");
                }

                sb.Append("</" + method_name + ">");
                sb.Append("</soap:Body>");
                sb.Append("</soap:Envelope>");

                XmlDocument soap_res = new XmlDocument();
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(ReqString);

                wr.ContentType = "text/xml";

                string SoapMsg = sb.ToString();

                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byte1 = encoding.GetBytes(SoapMsg);

                wr.Method = "POST";
                Stream newStream = wr.GetRequestStream();
                newStream.Write(byte1, 0, byte1.Length);

                newStream.Close();

                HttpWebResponse response = (HttpWebResponse)wr.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                soap_res.LoadXml(reader.ReadToEnd());
                reader.Close();
                dataStream.Close();
                response.Close();

                return soap_res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
