using CWC.DocMgmt.Util;
using Microsoft.AspNetCore.Components.Web;

namespace CWC.DocMgmt.Repository
{
    public class S3DocRepository : IDocRepository
    {
        private EnvInfo envInfo;

        private FileSystemDocRepository localDocRepo;
        public string putDocument(string localFileName)
        {
            if (envInfo.useLocalCache)
                return localDocRepo.putDocument(localFileName);

            string fileName = new Guid() + "";
            string key = envInfo.docReposBaseDirectory + "/" + fileName;
           // S3DataTransfer.uploadFile(new File(localFileName), key, envInfo.s3BucketName);
            return fileName;
        }

        public string putDocument(string localFileName, string fileName)
        {
            File.Copy(localFileName, envInfo.basePath + envInfo.docReposBaseDirectory + "/" + fileName, true);
            return fileName;
        }

        public string getDocument(string docHandle)
        {
            return envInfo.basePath + envInfo.docReposBaseDirectory + "/" + docHandle;
        }

        public string getLocalTempFile()
        {
            return envInfo.basePath + envInfo.docReposTempDirectory + "/" + new Guid() + "";
        }
    }
}
