namespace CWC.DocMgmt.Util
{
    public class EnvInfo
    {
        public string basePath { get; set; }

        public string docReposBaseDirectory { get; set; }

        public string docReposTempDirectory { get; set; }

        public bool useLocalCache { get; set; }

        public string s3BucketName { get; set; }

        public bool useLocalDocRepos { get; set; }

        public string awsCredFile { get; set; }

        public string awsRegion { get; set; }
    }
}
