using Amazon.S3;
using System.Drawing;

namespace CWC.DocMgmt.Util
{
    public class S3DataTransfer
    {
        private readonly IAmazonS3 _s3Client;

        public S3DataTransfer()
        {
           string bucketName = "";
            string region = "";
            string awsAccessKeyId = "";
            string awsSecretAccessKey = "";
            string awsSessionToken = "";

            _s3Client  = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, Amazon.RegionEndpoint.USEast1);
        }
       
}
}
