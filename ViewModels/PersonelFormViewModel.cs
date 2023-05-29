using Personel_MVC_SQL.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personel_MVC_SQL.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> Departmanlar { get; set; }
        public Personel Personel { get; set; }
    }
}