using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace Upload2S3
{
    class Program
    {

        private const string bucketName = "bucketmamun131";
      //  private const string keyName = "funnyImage.jpg";
        private const string filePath = "C:\\Users\\310267647\\Pictures\\robo1.jpg";
        //Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;
        private static IAmazonS3 s3Client;

        public static void Main(string[] args)
        {
            s3Client = new AmazonS3Client();

            //  Console.Read();

            UploadFileAsync().Wait();



        }

        private static async Task UploadFileAsync()
        {

            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);
                //Option 1: Upload a file. The file name is used as the object key name. 
                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Upload 1 completed");

                //Option 2: Specify the object key name explicitly.
                //await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                //Console.WriteLine("Upload 2 completed");
            }
            catch (AmazonS3Exception e)
            { Console.WriteLine("Error encountered on server. Message: 1{0}1 when writing an object", e.Message); }


            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message: 1{0). when writing an object", e.Message);
            }
        }
    }
}