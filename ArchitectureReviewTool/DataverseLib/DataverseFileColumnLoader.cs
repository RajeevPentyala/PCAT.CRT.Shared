using System;
using System.Web;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CodeViewerExtractor
{
    public class DataVerseFileColumnLoader
    {


    public Guid UploadFile
    (
        Stream MyStream,
        string fileName,
        string mimeType,
        EntityReference target,
        string fileAttributeName,
        IOrganizationService organizationService
    )
        {
            var initializeUploadRequest = new InitializeFileBlocksUploadRequest
            {
                FileAttributeName = fileAttributeName,
                FileName = fileName,
                Target = target
            };

            var initializeUploadResponse = (InitializeFileBlocksUploadResponse)organizationService.Execute(initializeUploadRequest);

            const int blockSize = 4194304; // 4 MB
            int byteCount;
            var blockList = new List<string>();
            MyStream.Position = 0;
            do
            {
                var buffer = new byte[blockSize];
                byteCount = MyStream.Read(buffer, 0, blockSize);

                if (byteCount < blockSize)
                    Array.Resize(ref buffer, byteCount);

                var uploadRequest = new UploadBlockRequest
                {
                    BlockData = buffer,
                    BlockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString("N"))),
                    FileContinuationToken = initializeUploadResponse.FileContinuationToken
                };

                organizationService.Execute(uploadRequest);
                blockList.Add(uploadRequest.BlockId);
            } while (byteCount == blockSize);

            var commitRequest = new CommitFileBlocksUploadRequest
            {
                BlockList = blockList.ToArray(),
                FileContinuationToken = initializeUploadResponse.FileContinuationToken,
                FileName = initializeUploadRequest.FileName,
                MimeType = mimeType
            };

            var commitResponse = (CommitFileBlocksUploadResponse)organizationService.Execute(commitRequest);
            return commitResponse.FileId;
        }

        public FileData GetFileData(string entityLogicalName, string attributeLogicalName, Guid recordId, IOrganizationService ServiceObject)
        {
            var initRequest = new InitializeFileBlocksDownloadRequest() { FileAttributeName = attributeLogicalName, Target = new EntityReference(entityLogicalName, recordId) };
            var initResponse = (InitializeFileBlocksDownloadResponse)ServiceObject.Execute(initRequest);

            var increment = 4194304;
            var from = 0;
            var fileSize = initResponse.FileSizeInBytes;
            byte[] downloaded = new byte[fileSize];
            var fileContinuationToken = initResponse.FileContinuationToken;

            while (from < fileSize)
            {
                var blockRequest = new DownloadBlockRequest() { Offset = from, BlockLength = increment, FileContinuationToken = fileContinuationToken };
                var blockResponse = (DownloadBlockResponse)ServiceObject.Execute(blockRequest);
                blockResponse.Data.CopyTo(downloaded, from);
                from += increment;
            }

            return new FileData { File = downloaded, Mimetype = GetMimeType(initResponse.FileName), Filename = initResponse.FileName };
        }

        private string GetMimeType(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return null;

            var extension = MimeMapping.GetMimeMapping(filename);
            return extension;
        }
    }

    public class FileData
    {
        public string Filename { get; set; }
        public string Mimetype { get; set; }
        public byte[] File { get; set; }
    }
}

