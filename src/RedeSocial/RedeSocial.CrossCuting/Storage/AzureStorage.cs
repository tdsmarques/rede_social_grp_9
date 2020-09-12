using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace RedeSocial.CrossCuting.Storage
{
    public class AzureStorage
    {
        private AzureStorageOptions Options { get; set;}

        private CloudBlobClient CloudBlobClient { get; set; }
        private CloudBlobDirectory ImagesDirectory { get; set; }

        public AzureStorage(IOptions<AzureStorageOptions> options)
        {
            this.Options = options.Value;
            this.Setup();
        }

        private void Setup()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(this.Options.ConnectionString);
            this.CloudBlobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = this.CloudBlobClient.GetContainerReference("horkutcontainer");

            this.ImagesDirectory = container.GetDirectoryReference(".");
        }

        public async Task<String> SaveToStorage(byte[] buffer, string fileName)
        {
            CloudBlockBlob cloudBlockBlob = null;
            cloudBlockBlob = this.ImagesDirectory.GetBlockBlobReference(fileName);

            using (Stream stream = new MemoryStream(buffer))
            {
                await cloudBlockBlob.UploadFromStreamAsync(stream);
            }
            return $"https://horkutstorage.blob.core.windows.net/horkutcontainer/{fileName}";
        } 
    }
}