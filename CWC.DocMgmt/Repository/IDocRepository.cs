namespace CWC.DocMgmt.Repository
{
    public interface IDocRepository
    {
        public String putDocument(String localFileName);

        public String putDocument(String localFileName, String fileName);

        public String getDocument(String docHandle);

        public String getLocalTempFile();
    }
}
