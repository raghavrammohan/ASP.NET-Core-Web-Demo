using CWC.DocMgmtClient.DTO;
using System.Text.Json.Nodes;

namespace CWC.DocMgmt.Services
{
    public interface IDocManagerService
    {
        public void addDocInfo(DocInfoDTO docInfoDTO);

        public void addDocInfos(List<DocInfoDTO> docInfos);
        public void updateDocDefinition(DocInfoDTO docInfoDTO);
        public List<DocInfoDTO> getDocumentList();
        public DocInfoDTO getDocInfo(string name);
        public List<DocInfoDTO> getDocInfoListForDocs(List<string> codes);
        public string getZipOfDocs(List<string> docName);
        public List<DocInfoDTO> searchDocumentsByCriteria(int pageSize, int pageNum, JsonObject searchParams);

        public DocInfoDTO updateDocImages(string docCode, JsonObject pdfTemplateInfo);
    }
}
