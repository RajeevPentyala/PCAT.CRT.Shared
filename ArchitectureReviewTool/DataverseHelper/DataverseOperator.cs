using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using CodeViewerExtractor;


namespace DataverseLib
{
    public class DataverseOperator
    {

        private CrmServiceClient ServiceObject;
        private string StrMyUrl;
        private string StrMyClientID;
        private string StrMyClientSecret;
        private string StrMyTokenCachePath;
        private bool IsMySingleInstance;

        private bool bisConnected = false;
        public string StrLastException = "";

        public bool ConnectionStatus   // property
        {
            get { return bisConnected; }  
        }

        public DataverseOperator(string StrUrl,string StrClientID, string StrClientSecret,bool IsSingleInstance, string StrTokenCachePath)
        {
            try
            {
                this.StrMyUrl = StrUrl;
                this.StrMyClientID = StrClientID;
                this.StrMyClientSecret = StrClientSecret;
                this.IsMySingleInstance = IsSingleInstance;
                this.StrMyTokenCachePath = StrTokenCachePath;
                this.ServiceObject = new CrmServiceClient(new Uri(this.StrMyUrl), this.StrMyClientID, this.StrMyClientSecret, this.IsMySingleInstance, this.StrMyTokenCachePath);
                this.bisConnected = this.ServiceObject != null && this.ServiceObject.IsReady;

            }
            catch(Exception ex)
            {
                this.StrLastException = ex.Message;
                this.bisConnected = false;
            }
            

        }

        public CodeViewerExtractor.FileData GetFileColumnContent(string entityLogicalName, string attributeLogicalName, Guid recordId)
        {
            
            DataVerseFileColumnLoader MyLoader = new DataVerseFileColumnLoader();
            FileData fileColumn = MyLoader.GetFileData(entityLogicalName, attributeLogicalName, recordId, ServiceObject);

            return fileColumn;
        }

        public WhoAmIResponse WhoIamIRequest() 
        {
            WhoAmIRequest request = new WhoAmIRequest();

            WhoAmIResponse response = (WhoAmIResponse)this.ServiceObject.Execute(request);

            return response;

        }


        public List<Entity> QuerySelect(string StrFetchXmlQuery)
        {
            //var query = new FetchExpression(StrFetchXmlQuery);
            EntityCollection results = this.ServiceObject.GetEntityDataByFetchSearchEC(StrFetchXmlQuery);
            if (results != null)
            {
                
                return results.Entities.ToList();
            }
            else
            {
                return new List<Entity>();
            }
            

        }


        public Guid QueryCreate(string StrEntityName,Dictionary<string, CrmDataTypeWrapper> ListValues)
        {
            Guid RetGuid;

            try
            {
                /*Entity NvEntity = new Entity(StrEntityName);
                foreach(KeyValuePair<string, string> OneValue in ListValues)
                {
                    NvEntity[OneValue.Key] = OneValue.Value;
                }
                RetGuid=this.ServiceObject.Create(NvEntity);*/
                RetGuid = this.ServiceObject.CreateNewRecord(StrEntityName,ListValues);
                

                return RetGuid;
            }
            catch(Exception ex)
            {
                return Guid.Empty;
            }
            

        }


        public Dictionary<String, Object> GetEntityRowById(string StrEntityName,Guid TheId)
        {
            Dictionary<string, object> data = this.ServiceObject.GetEntityDataById(StrEntityName, TheId, null);
            return data;
        }


        public bool QueryUpdate(string StrEntityName, string StrKeyFieldName, Guid GDuidToUpdate, Dictionary<string, CrmDataTypeWrapper> ListValues)
        {
            try
            {
                return this.ServiceObject.UpdateEntity(StrEntityName, StrKeyFieldName, GDuidToUpdate, ListValues);
                
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool QueryDelete(string StrEntityName, Guid GDuidToDelete)
        {
            try
            {
                return this.ServiceObject.DeleteEntity(StrEntityName,  GDuidToDelete);

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
                this.ServiceObject.Dispose();
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
        private string StrEntityName;
        private List<string> FieldsList;
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

            public void AddFilter(string StrNvFilterFieldName, string StrNvFilterOperator, string StrNvFilterValue)
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

        public void SetOrderArgument(string StrNvFieldName,string StrNvTypeOrder)
        {
            this.MyOrder = new OrderArgument(StrNvFieldName, StrNvTypeOrder);
        }

        public void AddFieldColumn(string strFieldName)
        {
            this.FieldsList.Add(strFieldName);
        }

        public string GenerateFetchXmltrong()
        {
            string StrXmlFetch = "";

            if (NbMaxRows > 0)
            {
                StrXmlFetch += "<fetch top='" + NbMaxRows.ToString() + "' >";
            }
            else {
                StrXmlFetch += "<fetch>";
            }
            StrXmlFetch += "<entity name='"+this.StrEntityName+"'>";

            foreach(string StrField in this.FieldsList)
            {
                StrXmlFetch += "<attribute name='" + StrField + "' />";
            }

            if (this.MyOrder.StrFieldName != "")
            {
                StrXmlFetch += "<order attribute = '" + this.MyOrder.StrFieldName + "' descending = " + this.MyOrder.StrOrderType + " />";
            }

            if (this.OMyFilter.lListFilters.Count > 0)
            {
                StrXmlFetch += "<filter type = '" + this.OMyFilter.StrLogicalOperator + "' >";

                foreach(FilterColumn AFilter in this.OMyFilter.lListFilters)
                {
                    if (AFilter.StrFilterValue == "")
                    {
                        StrXmlFetch += "<condition attribute='" + AFilter.StrFilterFieldName + "' operator='" + AFilter.StrFilterOperator + "' />";
                    }
                    else
                    {
                        StrXmlFetch += "<condition attribute='" + AFilter.StrFilterFieldName + "' operator='" + AFilter.StrFilterOperator + "' value='"+ AFilter.StrFilterValue + "' />";
                    }
                    
                }

                StrXmlFetch += "</filter>";
            }

            StrXmlFetch += "</entity>";
            StrXmlFetch += "</fetch>";
            return StrXmlFetch;
        }

    }
        
}
