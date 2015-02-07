using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TourService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "api1/khachsan/{diadiem}")]
        List<KhachSan> layDSKhachSan(string diadiem);

        [OperationContract]
        [WebGet(UriTemplate = "api1/xekhach/{diemxuatphat};{diemden}")]
        List<XeKhach> layDSXeKhach(string diemxuatphat, string diemden);

        [OperationContract]
        [WebGet(UriTemplate = "api1/xelua/{diemxuatphat};{diemden}")]
        List<XeLua> layDSXeLua(string diemxuatphat, string diemden);

        [OperationContract]
        [WebGet(UriTemplate = "api1/maybay/{diemxuatphat};{diemden}")]
        List<MayBay> layDSMayBay(string diemxuatphat, string diemden);
        
        //For testing only
        [OperationContract]
        [WebGet(UriTemplate = "api1/tong/{x};{y}")]
        int tong(string x, string y);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class KhachSan
    {
        [DataMember]
        public string diadiem { get; set; }
        [DataMember]
        public string loai { get; set; }
        [DataMember]
        public string kichthuoc { get; set; }
        [DataMember]
        public int sogiuong { get; set; }
        [DataMember]
        public double gia { get; set; }
    }

    [DataContract]
    public class XeKhach
    {

    }

    [DataContract]
    public class XeLua
    {

    }

    [DataContract]
    public class MayBay
    {
     
    }
}
