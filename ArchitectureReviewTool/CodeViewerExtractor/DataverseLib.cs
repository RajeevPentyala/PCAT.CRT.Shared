using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;


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

        public DataverseOperator(string StrUrl, string StrClientID, string StrClientSecret, bool IsSingleInstance, string StrTokenCachePath)
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
            catch (Exception ex)
            {
                this.StrLastException = ex.Message;
                this.bisConnected = false;
            }


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
            return results.Entities.ToList();
        }

        public List<Entity> QuerySelectOld(string StrFetchXmlQuery)
        {
            //var query = new FetchExpression(StrFetchXmlQuery);
            EntityCollection results = this.ServiceObject.GetEntityDataByFetchSearchEC(StrFetchXmlQuery);
            return results.Entities.ToList();
        }


        public EntityCollection SearchThroughRelationShip2(string StrMainTable,string strReltable, string strRelationShipName, string strRelationShipName2, string strColumnFrom1, string strColumnTo1, string strColumnFrom2, string strColumnTo2, string strSearchedColumn, object SearchedValue)
        {
            try
            {
                QueryExpression query = new QueryExpression(StrMainTable)
                {
                    ColumnSet = new ColumnSet(true),
                    LinkEntities =
                    {
                        new LinkEntity
                        {
                            LinkFromEntityName = StrMainTable,
                            LinkToEntityName = strRelationShipName,
                            LinkFromAttributeName = strColumnFrom1,
                            LinkToAttributeName = strColumnTo1,
                            LinkEntities =
                            {
                                new LinkEntity
                                {
                                    LinkFromEntityName = strRelationShipName2,
                                    LinkToEntityName = strReltable,
                                    LinkFromAttributeName = strColumnTo2,
                                    LinkToAttributeName = strColumnFrom2/*,
                                    LinkCriteria = new FilterExpression
                                    {
                                        Conditions =
                                        {
                                            new ConditionExpression(strSearchedColumn, ConditionOperator.Equal, SearchedValue)
                                        }
                                    }*/
                                }
                            }
                        }
                    }
                };
                EntityCollection Results = ServiceObject.RetrieveMultiple(query);
                return Results;
            }
            catch (Exception ex)
            {
                return new EntityCollection();
            }

            /*
            try
            {
                QueryExpression query = new QueryExpression("ccseq_contract")
                {
                    ColumnSet = new ColumnSet(true),
                    LinkEntities =
                    {
                        new LinkEntity
                        {
                            LinkFromEntityName = "ccseq_contract",
                            LinkToEntityName = "ccseq_opportunity_ccseq_contract",
                            LinkFromAttributeName = "ccseq_contractId",
                            LinkToAttributeName = "ccseq_contractId",
                            LinkEntities =
                            {
                                new LinkEntity
                                {
                                    LinkFromEntityName = "ccseq_opportunity_ccseq_contract",
                                    LinkToEntityName = "opportunity",
                                    LinkFromAttributeName = "opportunityid",
                                    LinkToAttributeName = "opportunityid",
                                    LinkCriteria = new FilterExpression
                                    {
                                        Conditions =
                                        {
                                            new ConditionExpression("opportunityid", ConditionOperator.Equal, wonOpportunity.Id)
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                EntityCollection Results = ServiceObject.RetrieveMultiple(query);
                return Results;
            }
            catch(Exception ex)
            {
                return new EntityCollection();
            }*/
        }


        public EntityCollection SearchThroughRelationShip(string RelationName, string[] Mycolumns, string ColumnName, object SearchedValue)
        {
            //string[] Mycolumns = { "cat_name", "cat_patternid" };
            //QueryExpression query = new QueryExpression("cat_rev_appchecker_rulesreferences");
            try
            {
                QueryExpression query = new QueryExpression(RelationName);

                query.ColumnSet.AddColumns(Mycolumns);
                query.Criteria = new FilterExpression();
                if (SearchedValue != null)
                {
                    query.Criteria.AddCondition(ColumnName, ConditionOperator.Equal, SearchedValue);
                }
                
                //query.Criteria.AddCondition(Opportunity.Properties.OpportunityId, ConditionOperator.Equal, wonOpportunity.Id);

                EntityCollection Results = ServiceObject.RetrieveMultiple(query);
                return Results;
            }
            catch(Exception ex)
            {
                return new EntityCollection();
            }            
        }

        public Guid QueryCreate(string StrEntityName, Dictionary<string, CrmDataTypeWrapper> ListValues)
        {
            Guid RetGuid;

            try
            {
                /*
                Entity NvEntity = new Entity(StrEntityName);
                foreach(KeyValuePair<string, string> OneValue in ListValues)
                {
                    NvEntity[OneValue.Key] = OneValue.Value;
                }
                RetGuid=this.ServiceObject.Create(NvEntity);
                */
                RetGuid = this.ServiceObject.CreateNewRecord(StrEntityName, ListValues);

                return RetGuid;

            }
            catch (Exception ex)
            {
                return Guid.Empty;
            }


        }

        public Guid QueryCreateOld(string StrEntityName, Dictionary<string, CrmDataTypeWrapper> ListValues)
        {
            Guid RetGuid;
            Dictionary<string, string> NvDico = new Dictionary<string, string>();
            foreach (KeyValuePair<string, CrmDataTypeWrapper> OneValueIn in ListValues)
            {
                NvDico.Add(OneValueIn.Key, OneValueIn.Value.Value.ToString());
            }
            try
            {
                Entity NvEntity = new Entity(StrEntityName);
                foreach(KeyValuePair<string, string> OneValue in NvDico)
                {
                    NvEntity[OneValue.Key] = OneValue.Value;
                }
                RetGuid=this.ServiceObject.Create(NvEntity);
                //RetGuid = this.ServiceObject.CreateNewRecord(StrEntityName, ListValues);


                return RetGuid;
            }
            catch (Exception ex)
            {
                return Guid.Empty;
            }


        }


        public Dictionary<String, Object> GetEntityRowById(string StrEntityName, Guid TheId)
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
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool QueryDelete(string StrEntityName, Guid GDuidToDelete)
        {
            try
            {
                return this.ServiceObject.DeleteEntity(StrEntityName, GDuidToDelete);

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

        public void SetOrderArgument(string StrNvFieldName, string StrNvTypeOrder)
        {
            this.MyOrder = new OrderArgument(StrNvFieldName, StrNvTypeOrder);
        }

        public void AddFieldColumn(string strFieldName)
        {
            this.FieldsList.Add(strFieldName);
        }

        public string GenerateFetchXmltrong()
        {
            string StrXmlFetch;

            if (NbMaxRows > 0)
            {
                StrXmlFetch = "<fetch top='" + NbMaxRows.ToString() + "'>";

            }
            else
            {
                StrXmlFetch = "<fetch>";
            }
            StrXmlFetch += @"
    <entity name='" + this.StrEntityName + "'>";

            foreach (string StrField in this.FieldsList)
            {
                StrXmlFetch += @"
        <attribute name='" + StrField + "' />";
            }

            if (this.MyOrder.StrFieldName != "")
            {
                StrXmlFetch += @"
        <order attribute = '" + this.MyOrder.StrFieldName + "' descending = " + this.MyOrder.StrOrderType + " />";
            }

            if (this.OMyFilter.lListFilters.Count > 0)
            {
                StrXmlFetch += @"
        <filter type = '" + this.OMyFilter.StrLogicalOperator + "' >";

                foreach (FilterColumn AFilter in this.OMyFilter.lListFilters)
                {
                    if (AFilter.StrFilterValue == "")
                    {
                        StrXmlFetch += @"
            <condition attribute='" + AFilter.StrFilterFieldName + "' operator='" + AFilter.StrFilterOperator + "' />";
                    }
                    else
                    {
                        StrXmlFetch += @"
            <condition attribute='" + AFilter.StrFilterFieldName + "' operator='" + AFilter.StrFilterOperator + "' value='" + AFilter.StrFilterValue + "' />";
                    }

                }

                StrXmlFetch += @"
        </filter>";
            }

            StrXmlFetch += @"
    </entity>";
            StrXmlFetch += @"
</fetch>";
            return StrXmlFetch;
        }

    }

}
