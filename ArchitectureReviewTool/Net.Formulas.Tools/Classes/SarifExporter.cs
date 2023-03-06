using System;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using DataverseLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Formulas.Tools.Classes
{


    public class reviewExport
    {
        public string Lb_Review;
        public float IPercent;
        public List<RevItemExport> lstRevItem;

        public reviewExport()
        {
            this.lstRevItem = new List<RevItemExport>();
        }

    }
    public class RevItemExport
    {
        public string Lb_Pattern;
        public string Lb_Status;
        public string Lb_Comment;

        public List<CodePartExport> lstCodesParts;

        public RevItemExport()
        {
            this.lstCodesParts = new List<CodePartExport>();
        }

    }
    public class CodePartExport
    {
        public string Lb_ScreenName;
        public string Lb_ControlName;
        public string Lb_PropertyName;
        public string Lb_Code;
    }

    public class SarifExporter
    {

        private string ReviewName;
        public SarifExporter(string NvReviewName)
        {
            this.ReviewName = NvReviewName;
        }
        /*
        public string MakeExport(DataverseOperator myOperator, IOrganizationService ServiceOp)
        {

            string RetVal = "";
            List<Entity> LstCodesParts;
            Guid reviewGuid;
            reviewExport ObjExport = new reviewExport();
            ObjExport.Lb_Review = this.ReviewName;
            CodePartExport objCodePart;
            List<CodePartExport> TheCodes;
            RevItemExport objRevItem;

            try
            {

                reviewGuid = DataverseLib.DataAccessLogic.GetReviewID(myOperator, this.ReviewName);
                Entity TheReview = DataverseLib.DataAccessLogic.GetEntityDatas(ServiceOp, this.ReviewName, reviewGuid);
                ObjExport.IPercent = (float)TheReview.Attributes["cat_score"];

                FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.AddFieldColumn("cat_comment"); 
                xmlFetcher.AddFieldColumn("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_reviewitemstatus");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
                List<Entity> resultsReviewItems = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

                xmlFetcher = new FetchXmlFormatter("cat_rev_codeparts");
                xmlFetcher.AddFieldColumn("cat_lb_code");
                xmlFetcher.AddFieldColumn("cat_lb_controlname");
                xmlFetcher.AddFieldColumn("cat_lb_propertyname");
                xmlFetcher.AddFieldColumn("cat_lb_screenname");
                xmlFetcher.AddFieldColumn("cat_fk_codepart_reviewitem");
               List<Entity> resultsCodesParts = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

                xmlFetcher = new FetchXmlFormatter("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_patternid");
                xmlFetcher.AddFieldColumn("cat_name");
                List<Entity> resultsPatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltrong());

                foreach (Entity OnerevItem in resultsReviewItems)
                {

                    OptionSetValue OptionStatus = (OptionSetValue)OnerevItem.Attributes["cat_reviewitemstatus"];
                    Entity OnePattern = resultsPatterns.Find(x => x.Id == new Guid(OnerevItem.Attributes["cat_pattern"].ToString()));

                    if (OptionStatus.Value == 695100003 || OptionStatus.Value == 695100002)
                    {

                        objRevItem = new RevItemExport();
                        objRevItem.Lb_Comment = OnerevItem.Attributes["cat_comment"].ToString();
                        objRevItem.Lb_Status = OptionStatus.Value== 695100003?"Fail":"Pass";
                        objRevItem.Lb_Pattern = OnePattern.Attributes["cat_name"].ToString();

                        LstCodesParts = resultsCodesParts.Where(x => x.Attributes["cat_fk_codepart_reviewitem"].ToString() == OnerevItem.Attributes["cat_reviewitemid"].ToString()).ToList();
                        //TheCodes = new List<CodePartExport>(); 
                        foreach (Entity OneCPart in LstCodesParts)
                        {
                            objCodePart = new CodePartExport();
                            objCodePart.Lb_Code = OneCPart.Attributes["cat_lb_code"].ToString();
                            objCodePart.Lb_Code = OneCPart.Attributes["cat_lb_controlname"].ToString();
                            objCodePart.Lb_Code = OneCPart.Attributes["cat_lb_propertyname"].ToString();
                            objCodePart.Lb_Code = OneCPart.Attributes["cat_lb_screenname"].ToString();
                            objRevItem.lstCodesParts.Add(objCodePart);
                        }

                        ObjExport.lstRevItem.Add(objRevItem);

                    }
                }
                

                return RetVal;

            }
            catch(Exception ex)
            {
                return ex.Message;
            }



            
        }
        */
    }
}
