using LayoutLesson.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LayoutLesson.XML
{
    public  static class XMLTool
    {
        public static Record loadDataFromXMLFile()
        {
            string strAppPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(strAppPath + "\\CheckInfo.xml"))
            {
                writeXMLToFile();
            }
            XDocument xDoc = XDocument.Load(strAppPath + "\\CheckInfo.xml");
            List<CheckInfo> CheckInfos
               = (from checkInfo in xDoc.Element("Record").Element("CheckInfos").Elements("CheckInfo")
                  select new CheckInfo
                  {
                      CheckName = checkInfo.Element("CheckName").Value,
                      IsCheck = bool.Parse(checkInfo.Element("IsCheck").Value),
                      NewResult = float.Parse( checkInfo.Element("NewResult").Value),
                      OldResult = float.Parse(checkInfo.Element("OldResult").Value),
                      Average = float.Parse(checkInfo.Element("Average").Value)
       
                  }).ToList();
            Record rd = new Record();
            rd.CheckInfos = new ObservableCollection<CheckInfo>(CheckInfos);
            rd.RecordID = xDoc.Element("Record").Element("RecordID").Value;
            rd.Customername = xDoc.Element("Record").Element("Customername").Value;
            rd.Type = int.Parse(xDoc.Element("Record").Element("Type").Value);
            rd.Gender = bool.Parse(xDoc.Element("Record").Element("Gender").Value);
            rd.Comment = xDoc.Element("Record").Element("Comment").Value;
            rd.Memo = xDoc.Element("Record").Element("Memo").Value;
            

            return rd;
        }
        private static void writeXMLToFile()
        {
            string strAppPath = AppDomain.CurrentDomain.BaseDirectory;
            ObservableCollection<CheckInfo> CheckInfos = new ObservableCollection<CheckInfo>();
            string[] arrName = { "Eyes", "Heart", "Blood", "Measures", "Lung", "Hearing", "X-Ray", "CT" };
            Random random = new Random();
            for (int i = 0; i < arrName.Length; i++)
            {
                CheckInfo info = new CheckInfo();
                info.CheckName = arrName[i];
                info.IsCheck = random.Next(0, 3) == 0 ? false : true;
                if (info.IsCheck)
                {
                    info.OldResult = float.Parse(random.Next(20, 200).ToString());
                    info.NewResult = float.Parse(random.Next(20, 200).ToString());
                    info.Average = float.Parse(random.Next(20, 200).ToString());
                }
                else
                {
                    info.OldResult = 0;
                    info.NewResult = 0;
                    info.Average = 0;
                }
               
                CheckInfos.Add(info);
            }
            Record record = new Record();
            record.RecordID = "RCD0001";
            record.Gender = true;
            record.Customername = "Hieu Huynh";
            record.Memo = "Nothing to show";
            record.CheckInfos = CheckInfos;
            record.Type = 0;
            record.Comment = "Comment is here";

             try
            {
                var xEle = new XElement("Record",   new XElement("RecordID",record.RecordID),
                                                    new XElement("Customername", record.Customername),
                                                    new XElement("Gender", record.Gender),
                                                    new XElement("Type", record.Type),
                                                    new XElement("Memo", record.Memo),
                                                    new XElement("Comment", record.Comment),
                                                    new XElement("CheckInfos",from info in CheckInfos
                                                                                select new XElement("CheckInfo",
                                                                                            new XElement("CheckName", info.CheckName),
                                                                                            new XElement("IsCheck", info.IsCheck),
                                                                                            new XElement("NewResult", info.NewResult),
                                                                                            new XElement("OldResult", info.OldResult),
                                                                                            new XElement("Average", info.Average)
                                                        ))
                                                       );
                xEle.Save(strAppPath + "\\CheckInfo.xml");
            }
            catch (Exception ex)
            {
            }
        }
       
        private static float randomFloatValue(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent) < 0 ? (float)(mantissa * exponent*-1) : (float)(mantissa * exponent);

        }
    }
}
