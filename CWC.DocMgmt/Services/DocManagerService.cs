using AutoMapper;
using Common.UOW;
using CWC.DocMgmt.Models;
using CWC.DocMgmtClient.DTO;
using ProductModule.Repository;
using System.Data;
using System.Text.Json.Nodes;

namespace CWC.DocMgmt.Services
{
    public class DocManagerService : IDocManagerService
    {

        private readonly IMapper _mapper;

        private IDocInfoRepository _docInfoRepository;

        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        private IConfiguration _configuration;

        public DocManagerService(IMapper mapper, IUnitOfWork unitOfWork, DocInfoRepository docInfoRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _docInfoRepository = docInfoRepository;
            _configuration = configuration;
         }

        public void addDocInfo(DocInfoDTO docInfoDTO)
        {
           
            if (_context.Documents.FirstOrDefault(d=>d.docCode == docInfoDTO.docCode) != null)
            {
               throw new DuplicateNameException("Document with " + docInfoDTO.docCode+ " is already present");
            }

            docInfoDTO.documentId = new Guid().ToString();
            DocInfo docDetails = _mapper.Map<DocInfo>(docInfoDTO);
        }

        public void updateDocDefinition(DocInfoDTO docInfoDTO)
        {
            throw new NotImplementedException();
        }

        public List<DocInfoDTO> getDocumentList()
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

        public string getZipOfDocs(List<string> docName)
        {
            throw new NotImplementedException();
        }

        public List<DocInfoDTO> searchDocumentsByCriteria(int pageSize, int pageNum, JsonObject searchParams)
        {
            throw new NotImplementedException();
        }

        public DocInfoDTO updateDocImages(string docCode, JsonObject pdfTemplateInfo)
        {
            throw new NotImplementedException();
        }

        public void addDocInfos(List<DocInfoDTO> docInfos)
        {
            throw new NotImplementedException();
        }
    }
}
