using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group11_007_iCAREAPP.Models
{
    public class UploadDocument
    {
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
    }
}