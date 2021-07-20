using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string InsertLesson(Ders data);

        [OperationContract]
        List<Ders> GetAllLessons();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Ders
    {
        int grupNo;
        int krediSayisi;
        int id;
        string dersAdi;

        [DataMember]
        public int GrupNo
        {
            get { return grupNo; }
            set { grupNo = value; }
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public int KrediSayisi
        {
            get { return krediSayisi; }
            set { krediSayisi = value; }
        }
        [DataMember]
        public string DersAdi
        {
            get { return dersAdi; }
            set { dersAdi = value; }
        }

    }
}
