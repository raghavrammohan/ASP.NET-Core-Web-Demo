using CWC.DocMgmt.Util;

namespace CWC.DocMgmt.Repository
{
    public class FileSystemDocRepository : IDocRepository
    {
        private EnvInfo envInfo;
        public string putDocument(string localFileName)
        {
            string fileName = new Guid() + "";
            File.Copy(fileName,envInfo.basePath + envInfo.docReposBaseDirectory + "/" + fileName, true);
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
