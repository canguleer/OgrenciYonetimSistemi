using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciYonetimSistemi.Models.Helper.Result
{
    public class ResultObject
    {
        public object data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public int? Id { get; set; }
        public string adress { get; set; }
    }
}