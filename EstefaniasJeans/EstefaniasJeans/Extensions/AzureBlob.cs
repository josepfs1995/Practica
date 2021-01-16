using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace EstefaniasJeans.Extensions
{
  public class AzureBlob
  {
    public async Task<string> GuardarFoto(byte[] fileData, string fileMimeType)
    {
      CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("ConnectionString");
      CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
      string strContainerName = "test02";
      CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
      string fileName = "test.jpg";

      if (await cloudBlobContainer.CreateIfNotExistsAsync())
      {
        await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
      }

      if (fileName != null && fileData != null)
      {
        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
        cloudBlockBlob.Properties.ContentType = fileMimeType;
        await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);
        return cloudBlockBlob.Uri.AbsoluteUri;
      }
      return "";
    }
  }
}
