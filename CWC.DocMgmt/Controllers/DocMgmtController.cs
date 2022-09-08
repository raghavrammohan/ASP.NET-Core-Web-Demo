using CWC.DocMgmt.Engine;
using CWC.DocMgmt.Services;
using CWC.DocMgmtClient.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CWC.DocMgmt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocMgmtController : ControllerBase
    {
        private IDocManagerService _docManagerService;
        
        public DocMgmtController(IDocManagerService docManagerService)
        {
            _docManagerService = docManagerService;
        }

        [HttpPost("/uploadPDFTemplate")]
        public IActionResult UploadPDFTemplate(List<IFormFile> file)
        {
           // var response = _productService.getProduct(productId);
            return Ok();
        }

        [HttpGet("/getDocPageImage")]
        public IActionResult GetDocPageImage(string docId)
        {
           // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpPost("/createDocument")]
        public IActionResult CreateDocument(DocInfoDTO docInfoDTO)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpPost("/saveDocumentDefinition")]
        public IActionResult SaveDocumentDefinition(DocInfoDTO docInfoDTO)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }


        [HttpGet("/getDocumentList")]
        public IActionResult GetDocumentList(string docId)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpGet("/searchDocuments")]
        public IActionResult SearchDocuments(string searchParams, int pageNum,
             int pageSize)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpGet("/getDocumentInfo")]
        public IActionResult GetDocumentInfo(string name)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpGet("/getDocumentDefinition")]
        public IActionResult GetDocumentDefinition(string name)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpGet("/getDocumentInfoListForDocCodes")]
        public IActionResult GetDocumentInfoListForDocCodes(List<string> codes)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpPost("/exportDocuments")]
        public IActionResult ExportDocuments(string searchParams,List<string> docNames)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpPost("/editTemplate")]
        public IActionResult EditTemplate(List<IFormFile> files,string docCode)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpPost("/importDocuments")]
        public IActionResult ImportDocuments(List<IFormFile> files)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }

        [HttpPost("/beautifyExpression")]
        public IActionResult BeautifyExpression(string functionString)
        {
            // var response = _productService.createProduct(productDTO);
            return Ok();
        }
    }
}