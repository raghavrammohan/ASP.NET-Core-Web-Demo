using Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWC.DocMgmt.Models;

[Table("doc_info")]
public class DocInfo : BaseEntity
{
    [Key] public string documentId { get; set; }
    [Required] public string docCode { get; set; }
     public string description { get; set; }
    public string type { get; set; }
    public int pageImages { get; set; }
    public int docDefinition { get; set; }
}