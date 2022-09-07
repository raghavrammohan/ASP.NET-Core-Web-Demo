using CWC.DocMgmtClient.DTO;
using System.Text.Json.Nodes;

namespace CWC.DocMgmt.Services
{
    public class DocManagerService : IDocManagerService
    {

    //private ModelMapper modelMapper;

    //private DocInfoRepository docDetailsRepository;

    private String basePath;

    private String docReposTempDirectory;


        public void addDocInfo(DocInfoDTO docInfoDTO)
        {
            throw new NotImplementedException();
        }

        public void addDocInfos(List<DocInfoDTO> docInfos)
        {
            throw new NotImplementedException();
        }

        public DocInfoDTO getDocInfo(string name)
        {
            throw new NotImplementedException();
        }

        public List<DocInfoDTO> getDocInfoListForDocs(List<string> codes)
        {
            throw new NotImplementedException();
        }

        public List<DocInfoDTO> getDocumentList()
        {
            throw new NotImplementedException();
        }

        public string getZipOfDocs(List<string> docName)
        {
            throw new NotImplementedException();
        }

        public List<DocInfoDTO> searchDocumentsByCriteria(int pageSize, int pageNum, JsonObject searchParams)
        {
            throw new NotImplementedException();
        }

        public void updateDocDefinition(DocInfoDTO docInfoDTO)
        {
            throw new NotImplementedException();
        }

        public DocInfoDTO updateDocImages(string docCode, JsonObject pdfTemplateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
