using CWC.DocMgmt.Util;

namespace CWC.DocMgmt.Repository
{
    public class DocRepoFactory
    {
        private static EnvInfo envInfo;
        private static FileSystemDocRepository fileSystemDocRepository;
        private static S3DocRepository s3DocRepository;

 //       static {
	//	envInfo = SpringApplicationContext.getBean(EnvInfo.class);
	//	fileSystemDocRepository =  SpringApplicationContext.getBean(FileSystemDocRepository.class);
	//	s3DocRepository = SpringApplicationContext.getBean(S3DocRepository.class);
	//}

    public static IDocRepository getDocumentRepository()
    {
        if (envInfo.useLocalDocRepos)
            return fileSystemDocRepository;
        else
            return s3DocRepository;
    }
}
}
