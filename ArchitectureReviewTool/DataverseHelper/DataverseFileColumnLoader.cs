using System;
using System.Web;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;

namespace CodeViewerExtractor
{
    public class DataVerseFileColumnLoader
    {
        public FileData GetFileData(string entityLogicalName, string attributeLogicalName, Guid recordId, CrmServiceClient ServiceObject)
        {
            var initRequest = new InitializeFileBlocksDownloadRequest() { FileAttributeName = attributeLogicalName, Target = new EntityReference(entityLogicalName, recordId) };
            var initResponse = (InitializeFileBlocksDownloadResponse)ServiceObject.Execute(initRequest);//(InitializeFileBlocksDownloadResponse)base.Service.Execute(initRequest);

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

