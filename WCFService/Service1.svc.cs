using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SchoolEntities svcModel = new SchoolEntities();

        public List<Ders> GetAllLessons()
        {

            var data = (from _ders in svcModel.Course
                        where _ders.Statu == true
                        select new
                        {
                            _ders.Id,
                            _ders.CoursName,
                            _ders.GroupNo,
                            _ders.NumberOfCredits
                        }).ToList();

            List<Ders> dersler = new List<Ders>();

            foreach (var item in data)
            {
                dersler.Add(new Ders { Id = item.Id, DersAdi = item.CoursName, GrupNo = item.GroupNo, KrediSayisi = item.NumberOfCredits });
            }

            return dersler;


        }


        public string InsertLesson(Ders data)
        {
            return string.Format("You entered: {0}", data);
        }
    }
}
