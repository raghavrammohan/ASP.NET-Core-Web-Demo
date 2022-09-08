using CWC.DocMgmt.Util;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;

namespace CWC.DocMgmt.Repository
{
    public class S3DocRepository : IDocRepository
    {
        private FileSystemDocRepository localDocRepo;

        private IConfiguration _configuration;

        public S3DocRepository(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string putDocument(string localFileName)
        {
            if (_configuration["DocMgmt:useLocalCache"] == "true")
                return localDocRepo.putDocument(localFileName);

            string fileName = new Guid() + "";
            string key = _configuration["DocMgmt:docReposBaseDirectory"] + "/" + fileName;
           // S3DataTransfer.uploadFile(new File(localFileName), key, envInfo.s3BucketName);
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
