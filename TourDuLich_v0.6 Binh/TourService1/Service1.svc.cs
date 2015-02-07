using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace TourService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<KhachSan> layDSKhachSan(string diadiem)
        {
            string xmlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/API.xml");

            XElement root = XElement.Load(xmlFileName);
            var listEle = root.Elements("room");

            List<KhachSan> hotels = new List<KhachSan>();

            foreach (XElement element in listEle)
            {
                KhachSan hotel = new KhachSan
                {
                    diadiem = diadiem,
                    loai = element.Element("loai").Value,
                    kichthuoc = element.Element("kichthuoc").Value,
                    sogiuong = Convert.ToInt32(element.Element("sogiuong").Value),
                    gia = Convert.ToDouble(element.Element("gia").Value)
                };
                hotels.Add(hotel);
            }

            return hotels;
        }

        public int tong(string x, string y)
        {
            int iX, iY;
            if (int.TryParse(x, out iX) && int.TryParse(y, out iY))
            {
                return iX + iY;
            }
            return int.MinValue;
        }


        public List<XeKhach> layDSXeKhach(string diemxuatphat, string diemden)
        {
            throw new NotImplementedException();
        }

        public List<XeLua> layDSXeLua(string diemxuatphat, string diemden)
        {
            throw new NotImplementedException();
        }

        public List<MayBay> layDSMayBay(string diemxuatphat, string diemden)
        {
            throw new NotImplementedException();
        }
    }
}
