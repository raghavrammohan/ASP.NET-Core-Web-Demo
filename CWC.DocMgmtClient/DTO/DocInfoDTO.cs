using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DocMgmtClient.DTO
{
    public class DocInfoDTO
    {
        public string documentId { get; set; }
        public string docCode { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string pageImages { get; set; }
        public string docDefinition { get; set; }
    }

}
