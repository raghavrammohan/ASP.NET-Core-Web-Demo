using CWC.DocMgmt.Util;

namespace CWC.DocMgmt.Repository
{
    public class FileSystemDocRepository : IDocRepository
    {
        private IConfiguration _configuration;

        public FileSystemDocRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string putDocument(string localFileName)
        {
            string fileName = new Guid() + "";
            File.Copy(fileName, _configuration["DocMgmt:basePath"] + _configuration["DocMgmt:docReposBaseDirectory"] + "/" + fileName, true);
            return fileName;
        }

        public string putDocument(string localFileName, string fileName)
        {
            File.Copy(localFileName, _configuration["DocMgmt:basePath"] + _configuration["DocMgmt:docReposBaseDirectory"] + "/" + fileName, true);
            return fileName;
        }

        public string getDocument(string docHandle)
        {
            return _configuration["DocMgmt:basePath"] + _configuration["DocMgmt:docReposBaseDirectory"] + "/" + docHandle;
        }

        public string getLocalTempFile()
        {
            return _configuration["DocMgmt:basePath"] + _configuration["DocMgmt:docReposTempDirectory"] + "/" + new Guid() + "";
        }
    }
}
