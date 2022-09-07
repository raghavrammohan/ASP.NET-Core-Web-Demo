using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DocMgmtClient.DTO
{
    public class DocInfoDTO
    {
        string documentId { get; set; }
        string docCode { get; set; }
        string description { get; set; }
        string type { get; set; }
        string pageImages { get; set; }
        string docDefinition { get; set; }
    }

}
