using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
//using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using CodeViewerExtractor;
using Microsoft.PowerPlatform.Formulas.Tools;
using System.Text;

namespace DataverseLib
{
    public class DataverseOperator
    {

        private readonly IOrganizationService ServiceObject;
        //private string StrMyUrl;
        //private string StrMyClientID;
        //private string StrMyClientSecret;
        //private string StrMyTokenCachePath;
        //private bool IsMySingleInstance;

        private readonly bool bisConnected = false;
        public string StrLastException = "";

        public bool ConnectionStatus   // property
        {
            get { return bisConnected; }
        }

        public IOrganizationService getService()
        {
            return this.ServiceObject;
        }

        public DataverseOperator(IOrganizationService MyService)
        {
            try
            {

                this.ServiceObject = MyService;
                //new CrmServiceClient(new Uri(this.StrMyUrl), this.StrMyClientID, this.StrMyClientSecret, this.IsMySingleInstance, this.StrMyTokenCachePath);

            }
            catch (Exception ex)
            {
                this.StrLastException = ex.Message;
                this.bisConnected = false;
            }

        }

        public EntityCollection GetAWebRessource(string entityName, string rangeName, string rangeValue)
        {

            QueryByAttribute requestWebResource = new QueryByAttribute
            {
                EntityName = entityName,
                ColumnSet = new ColumnSet(true),
            };
            requestWebResource.Attributes.AddRange(rangeName);
            requestWebResource.Values.AddRange(rangeValue);

            EntityCollection webResourceCollection = this.ServiceObject.RetrieveMultiple(requestWebResource);

            return webResourceCollection;

        }

        /// <summary>
        /// Fetch Canvas App record's appopenuri and web request to fetch the stream
        /// </summary>
        /// <param name="myOperator">Dataverse Operator</param>
        /// <param name="appDocumentUri">App Document URI</param>
        /// <param name="tracingService">Tracing Service</param>
        /// <returns>Stream To Open</returns>
        public System.IO.MemoryStream FetchAppStreamContentbyAppID(DataverseOperator myOperator, string appDocumentUri, ITracingService tracingService = null)
        {
            FileData MyfileData = myOperator.GetAppContentbyAppID(appDocumentUri, tracingService);

            System.IO.MemoryStream streamToOpen = new System.IO.MemoryStream(MyfileData.File);
            if (tracingService != null)
            {
                tracingService.Trace($"Fetched App Stream Length : {MyfileData.File.Length} ");
            }

            return streamToOpen;
        }

        public System.IO.MemoryStream getSolutionZip(DataverseOperator myOperator, Guid reviewGuid, string TableName, string ColumnName, ITracingService tracingService = null)
        {
            FileData MyfileData = myOperator.GetFileColumnContent(TableName, ColumnName, reviewGuid, null);

            System.IO.MemoryStream streamToOpen = new System.IO.MemoryStream(MyfileData.File);
            if (tracingService != null)
            {
                tracingService.Trace("Uploaded filer length : " + MyfileData.File.Length.ToString());
            }

            return streamToOpen;
        }

        public CanvasDocument getCanvasDoc(DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService, string TableName, string ColumnName, string msappUri = null, string appPayload = null)
        {
            string Completeerror = "";
            if (msappUri == "-") msappUri = null;
            if (tracingService != null) tracingService.Trace($"URI Given : {msappUri}");
            byte[] appBytes;
            if (!string.IsNullOrEmpty(appPayload))
            {
                if (tracingService != null) tracingService.Trace("Reading app bytes from Annotation");
                appBytes = Convert.FromBase64String(appPayload);
            }
            else
            {
                if (tracingService != null) tracingService.Trace("Reading app bytes from File column");
                FileData MyfileData = myOperator.GetFileColumnContent(TableName, ColumnName, reviewGuid, msappUri);
                appBytes = MyfileData.File;
            }

            System.IO.MemoryStream streamToOpen = new System.IO.MemoryStream(appBytes);
            if (tracingService != null) tracingService.Trace($"App Payload Bytes Length : {appBytes.Length}");

            (CanvasDocument msApp, ErrorContainer errors) = CanvasDocument.LoadFromMsappStream(streamToOpen, tracingService);

            if (errors.HasErrors)
            {
                if (tracingService != null) tracingService.Trace($"Error loading App : {Completeerror}");
                throw new Exception(" _____-_____ " + Completeerror + " _____-_____ ");
            }

            return msApp;
        }

        public string GetAppsPayloadBase64(DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService, string msappUri = null)
        {
            msappUri = (msappUri == "-") ? null : msappUri;
            if (tracingService != null) tracingService.Trace("URI Given : " + msappUri);

            FileData appPayload = myOperator.GetFileColumnContent("cat_review", "cat_msappfile", reviewGuid, msappUri);

            if (tracingService != null) tracingService.Trace($"Apps payload length : {appPayload.File.Length}");

            if (appPayload.File.Length > 0)
            {
                return Convert.ToBase64String(appPayload.File);
            }

            return string.Empty;
        }

        public Guid UploadFileToDataverse(System.IO.Stream FileStream, string fileName, string MimeType, string FileAttributeName, EntityReference RowReference)
        {
            DataVerseFileColumnLoader MyLoader;
            MyLoader = new DataVerseFileColumnLoader();
            return MyLoader.UploadFile(FileStream, fileName, MimeType, RowReference, FileAttributeName, this.ServiceObject);
        }

        public CodeViewerExtractor.FileData GetFileColumnContent(string entityLogicalName, string attributeLogicalName, Guid recordId, string document_uri = null)
        {
            FileData fileColumn;
            DataVerseFileColumnLoader MyLoader;
            System.IO.MemoryStream streamToOpen;
            if (!string.IsNullOrEmpty(document_uri))
            {
                var webRequest = System.Net.WebRequest.Create(document_uri);
                var response = webRequest.GetResponse();
                var content = response.GetResponseStream();
                streamToOpen = new System.IO.MemoryStream();
                content.CopyTo(streamToOpen);
                fileColumn = new FileData { File = streamToOpen.ToArray(), Mimetype = "msapp", Filename = "document_uri.msapp" };
            }
            else
            {
                MyLoader = new DataVerseFileColumnLoader();
                fileColumn = MyLoader.GetFileData(entityLogicalName, attributeLogicalName, recordId, this.ServiceObject);
            }

            return fileColumn;
        }

        /// <summary>
        /// Get App Stream by AppID (i.e., Document_uri)
        /// </summary>
        /// <param name="appDocumentUri">App Document Uri</param>
        /// <param name="tracingService">Tracing Service</param>
        /// <returns>Returns Memory Stream of App</returns>
        public FileData GetAppContentbyAppID(string appDocumentUri, ITracingService tracingService = null)
        {
            FileData fileColumn = null;
            try
            {
                if (tracingService != null) tracingService.Trace($"Apps document_uri; {appDocumentUri}");
                var webRequest = System.Net.WebRequest.Create(appDocumentUri);
                var response = webRequest.GetResponse();
                var content = response.GetResponseStream();
                System.IO.MemoryStream streamToOpen = new System.IO.MemoryStream();
                content.CopyTo(streamToOpen);
                fileColumn = new FileData { File = streamToOpen.ToArray(), Mimetype = "msapp", Filename = "document_uri.msapp" };
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in GetAppContentbyAppID; {ex.Message}");
            }

            return fileColumn;
        }

        public List<Entity> QuerySelect(string StrFetchXmlQuery)
        {
            try
            {
                EntityCollection results = ServiceObject.RetrieveMultiple(new FetchExpression(StrFetchXmlQuery));
                if (results != null && results.Entities != null)
                {
                    return results.Entities.ToList();
                }
                else
                {
                    return new List<Entity>();
                }
            }
            catch (Exception ex)
            {
                return new List<Entity>();
            }
        }

        public void QueryUnRelate(string RelationShipName, string tableMany, List<Guid> listToRelate, string tableOne, Guid oneToBeUnRelated)
        {


            EntityReferenceCollection UnRelatedEntities = new EntityReferenceCollection();
            foreach (Guid OneGuid in listToRelate)
            {
                UnRelatedEntities.Add(new EntityReference(tableMany, OneGuid));

            }
            // Create an object that defines the relationship between the contact and account.
            Relationship relationship = new Relationship(RelationShipName);

            //Associate the contact with the 3 accounts

            this.ServiceObject.Disassociate(tableOne, oneToBeUnRelated, relationship, UnRelatedEntities);


        }

        public void QueryRelate(string RelationShipName, string tableMany, List<Guid> listToRelate, string tableOne, Guid oneToBeRelated)
        {


            EntityReferenceCollection relatedEntities = new EntityReferenceCollection();
            foreach (Guid OneGuid in listToRelate)
            {
                relatedEntities.Add(new EntityReference(tableMany, OneGuid));

            }
            // Create an object that defines the relationship between the contact and account.
            Relationship relationship = new Relationship(RelationShipName);

            //Associate the contact with the 3 accounts

            this.ServiceObject.Associate(tableOne, oneToBeRelated, relationship, relatedEntities);
        }

        public Guid QueryCreate(string StrEntityName, Dictionary<string, Object> ListValues, ITracingService tracingService = null)
        {
            Guid RetGuid;
            try
            {
                Entity NvEntity = new Entity(StrEntityName);
                foreach (KeyValuePair<string, Object> OneValue in ListValues)
                {
                    NvEntity[OneValue.Key] = OneValue.Value;
                }

                RetGuid = this.ServiceObject.Create(NvEntity);

                return RetGuid;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error creating {StrEntityName} record; Message : {ex.Message}");
                throw ex;
            }
        }

        public Entity GetEntityToCreate(string StrEntityName, Dictionary<string, Object> ListValues)
        {
            try
            {

                Entity entitytoCreate = new Entity(StrEntityName);
                foreach (KeyValuePair<string, Object> OneValue in ListValues)
                {
                    entitytoCreate[OneValue.Key] = OneValue.Value;
                }

                return entitytoCreate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public Entity GetEntityRowById(string StrEntityName,Guid TheId)
        {
            //Dictionary<string, object> data = this.ServiceObject.GetEntityDataById(StrEntityName, TheId, null);
            Entity data = this.ServiceObject.Retrieve(StrEntityName,TheId, new ColumnSet(true));
            return data;
        }*/

        public bool QueryUpdateStatus(string StrEntityName, Dictionary<string, object> ListValues, Guid TheGuid)
        {

            try
            {

                ColumnSet MyColSet = new ColumnSet(ListValues.Keys.ToArray());
                Entity MyEntity = this.ServiceObject.Retrieve(StrEntityName, TheGuid, MyColSet);
                //IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

                //Entity NvEntity = new Entity(StrEntityName);
                foreach (KeyValuePair<string, Object> OneValue in ListValues)
                {
                    MyEntity[OneValue.Key] = OneValue.Value;
                }
                this.ServiceObject.Update(MyEntity);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Guid CreateNewReview(DataverseOperator myoperator, string ReviewName)
        {
            Guid NvGuid = new Guid();


            return NvGuid;
        }

        public bool QueryUpdate(string StrEntityName, Dictionary<string, object> ListValues, Entity NvEntity, ITracingService tracingService = null)
        {
            try
            {
                foreach (KeyValuePair<string, Object> OneValue in ListValues)
                {
                    NvEntity[OneValue.Key] = OneValue.Value;
                }

                this.ServiceObject.Update(NvEntity);
                return true;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in QueryUpdate of {StrEntityName} table; Message : {ex.Message}");
                throw ex;
            }
        }

        public bool QueryDelete(string StrEntityName, Guid GDuidToDelete)
        {

            try
            {
                this.ServiceObject.Delete(StrEntityName, GDuidToDelete);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ReleaseConnection()
        {
            try
            {
                //this.ServiceObject.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class FetchXmlFormatter
    {

        public string StrFinalQuery;
        private readonly string StrEntityName;
        private readonly List<string> FieldsList;
        //private List<FilterGroup> LMyFilters;
        //private FilterGroup OMyFilter; 
        public FilterGroup OMyFilter;//public for now because easier
        private OrderArgument MyOrder;

        private int NbMaxRows;
        public int MaxRows   // property
        {
            get { return NbMaxRows; }
            set { NbMaxRows = value; }
        }

        public class OrderArgument
        {
            public string StrFieldName;
            public string StrOrderType;

            public OrderArgument(string StrNvFieldName, string StrNvOrderType)
            {
                this.StrFieldName = StrNvFieldName;
                this.StrOrderType = StrNvOrderType;
            }

        }

        public class FilterColumn
        {
            public string StrFilterFieldName;
            public string StrFilterOperator;
            public string StrFilterValue;

            public FilterColumn(string StrNvFilterFieldName, string StrNvFilterOperator, string StrNvFilterValue)
            {
                this.StrFilterFieldName = StrNvFilterFieldName;
                this.StrFilterOperator = StrNvFilterOperator;
                this.StrFilterValue = StrNvFilterValue;
            }

        }

        public class FilterGroup
        {
            public string StrLogicalOperator;
            public List<FilterColumn> lListFilters;

            public FilterGroup(string StrNvLogicalOperator)
            {
                this.StrLogicalOperator = StrNvLogicalOperator;
                this.lListFilters = new List<FilterColumn>();
            }

            public void AddFilter(string StrNvFilterFieldName, string StrNvFilterOperator, string StrNvFilterValue = "")
            {
                FilterColumn NvFilter = new FilterColumn(StrNvFilterFieldName, StrNvFilterOperator, StrNvFilterValue);
                this.lListFilters.Add(NvFilter);
            }

        }


        public FetchXmlFormatter(string StrNvEntityName)
        {
            this.StrEntityName = StrNvEntityName;
            FieldsList = new List<string>();
            MyOrder = new OrderArgument("", "");
            this.StrFinalQuery = "";
            this.OMyFilter = new FilterGroup("");
            NbMaxRows = 0;
        }

        public void SetOrderArgument(string StrNvFieldName, string StrNvTypeOrder)
        {
            this.MyOrder = new OrderArgument(StrNvFieldName, StrNvTypeOrder);
        }

        public void AddFieldColumn(string strFieldName)
        {
            this.FieldsList.Add(strFieldName);
        }

        public string GenerateFetchXmltString()
        {
            StringBuilder StrXmlFetch = new StringBuilder();

            if (NbMaxRows > 0)
            {
                StrXmlFetch.Append("<fetch top='" + NbMaxRows.ToString() + "' >");
            }
            else
            {
                StrXmlFetch.Append("<fetch>");
            }

            StrXmlFetch.Append("<entity name='" + this.StrEntityName + "'>");

            foreach (string StrField in this.FieldsList)
            {
                StrXmlFetch.Append("<attribute name='" + StrField + "' />");
            }

            if (this.MyOrder.StrFieldName != "")
            {
                StrXmlFetch.Append("<order attribute = '" + this.MyOrder.StrFieldName + "' descending = " + this.MyOrder.StrOrderType + " />");
            }

            if (this.OMyFilter.lListFilters.Count > 0)
            {
                StrXmlFetch.Append("<filter type = '" + this.OMyFilter.StrLogicalOperator + "' >");

                foreach (FilterColumn AFilter in this.OMyFilter.lListFilters)
                {
                    if (AFilter.StrFilterValue == "")
                    {
                        StrXmlFetch.Append("<condition attribute='" + AFilter.StrFilterFieldName + "' operator='" + AFilter.StrFilterOperator + "' />");
                    }
                    else
                    {
                        StrXmlFetch.Append("<condition attribute='" + AFilter.StrFilterFieldName + "' operator='" + AFilter.StrFilterOperator + "' value='" + AFilter.StrFilterValue + "' />");
                    }

                }

                StrXmlFetch.Append("</filter>");
            }

            StrXmlFetch.Append("</entity>");
            StrXmlFetch.Append("</fetch>");
            return StrXmlFetch.ToString();
        }
    }
}