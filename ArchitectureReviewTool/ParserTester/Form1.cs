using System;
using Microsoft.PowerPlatform.Formulas.Tools;
using System.IO;
//using DataverseLib;
//using Net.Formulas.Tools.DataverseLib;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ParserTester
{


   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            /*msAppPath
     string envUrl = "https://codereviewdev.crm.dynamics.com";
          string clientId = "287c306f-ea65-4766-96ff-45712ddb6ac0";
          string Secret = "5SyNaEV52YTY.22FXP3B9-92zUD~CJ_SlE";
            

            string envUrl = "https://orgf13f21b3.crm.dynamics.com";
            string clientId = "93c32c72-f056-42ae-8c31-450e0ba4cf71";
            string Secret = "HQ4a8~5mVm~Q0rZ.EAOz549S-8xZ66k_.F";

            var service = new CrmServiceClient(new Uri(envUrl), clientId, Secret, true, String.Empty);
            

            DataverseLib.DataverseOperator myOperator = new DataverseLib.DataverseOperator(service);
            

            Guid reviewGuid = Net.Formulas.Tools.DataverseLib.DataAccessLogic.GetReviewID(myOperator, "");


            byte[] MyfileData = myOperator.GetFileColumnContent("cat_review", "cat_msappfile", reviewGuid).File;
            */

            //FileStream zipToOpen = new FileStream(TxtPathMsapp.Text, FileMode.Open);
            //MemoryStream streamToOpen = new MemoryStream(MyfileData);

            (CanvasDocument msApp, ErrorContainer errors) = CanvasDocument.LoadFromMsapp(TxtPathMsapp.Text);



            if (errors.HasErrors)
            {
                return;
            }

            List<DataSourceElement> ListeDatas=new List<ParserTester.DataSourceElement>();
            //ParserTester.DataSourceElement OneDataSource;

            /*
            foreach (KeyValuePair<string, List<DataSourceEntry>> GrpDatasource in msApp.GetDataSources())
            {

                DataSourceEntry OneDatasource = GrpDatasource.Value[GrpDatasource.Value.Count-1];

                if (OneDatasource.ExtensionData != null && OneDatasource.ExtensionData.ContainsKey("IsSampleData"))
                {
                    if (OneDatasource.ExtensionData["IsSampleData"].ValueKind == System.Text.Json.JsonValueKind.False)
                    {
                        OneDataSource = new DataSourceElement();
                        OneDataSource.lb_namedatasource=OneDatasource.Name;
                        OneDataSource.lb_datasetname = OneDatasource.DatasetName;
                        OneDataSource.lb_typedatasource = OneDatasource.Type;
                        OneDataSource.lb_displaynamedatasource = OneDatasource.RelatedEntityName;
                        ListeDatas.Add(OneDataSource);
                    }
                }
                else
                {

                    OneDataSource = new DataSourceElement();
                    OneDataSource.lb_namedatasource = OneDatasource.Name;
                    OneDataSource.lb_datasetname = OneDatasource.DatasetName;
                    OneDataSource.lb_typedatasource = OneDatasource.Type;
                    OneDataSource.lb_displaynamedatasource = OneDatasource.RelatedEntityName;
                    ListeDatas.Add(OneDataSource);
                }

            }
            */
        


            PowerAppsParser myparser = new PowerAppsParser(text_StartCode.Text, ListeDatas,"Items","Galtest",false,0);
            text_Resultat.Text = myparser.CodeCleanedProperty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MsappDialog1.ShowDialog();
            TxtPathMsapp.Text = MsappDialog1.SelectedPath;
        }


        private void btn_TestUnit_Click(object sender, EventArgs e)
        {
            //new List<DataSourceElement>()
            List<DataSourceElement> NvListDatas = new List<DataSourceElement>();
            DataSourceElement Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "StaticStyles";
            Elemt.lb_displaynamedatasource = "StaticStyles";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "StaticStyles";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'Area Inspections'";
            Elemt.lb_displaynamedatasource = "'Area Inspections'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'Area Inspections'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'Area Inspection Labels'";
            Elemt.lb_displaynamedatasource = "'Area Inspection Labels'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'Area Inspection Labels'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'Area Inspection Settings'";
            Elemt.lb_displaynamedatasource = "'Area Inspection Settings'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'Area Inspection Settings'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'Area Inspection User Settings'";
            Elemt.lb_displaynamedatasource = "'Area Inspection User Settings'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'Area Inspection User Settings'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "Planner";
            Elemt.lb_displaynamedatasource = "Planner";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "Planner";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "ComponentStyles";
            Elemt.lb_displaynamedatasource = "ComponentStyles";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "ComponentStyles";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "Menu";
            Elemt.lb_displaynamedatasource = "Menu";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "Menu";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "colLocalization";
            Elemt.lb_displaynamedatasource = "colLocalization";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "colLocalization";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "colUserSettings";
            Elemt.lb_displaynamedatasource = "colUserSettings";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "colUserSettings";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "colLabels";
            Elemt.lb_displaynamedatasource = "colLabels";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "colLabels";
            NvListDatas.Add(Elemt);
            Elemt.lb_datasetname = "colItemConfig";
            Elemt.lb_displaynamedatasource = "colItemConfig";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "colItemConfig"; 
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "ThemeStyles";
            Elemt.lb_displaynamedatasource = "ThemeStyles";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "ThemeStyles";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "Users";
            Elemt.lb_displaynamedatasource = "Users";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "Users";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'User Configurations'";
            Elemt.lb_displaynamedatasource = "'User Configurations'";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "'User Configurations'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "AppTips";
            Elemt.lb_displaynamedatasource = "AppTips";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "AppTips";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'System Configurations'";
            Elemt.lb_displaynamedatasource = "'System Configurations'";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "'System Configurations'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "Accounts";
            Elemt.lb_displaynamedatasource = "Accounts";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "Accounts";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'NBA Store Visit Headers'";
            Elemt.lb_displaynamedatasource = "'NBA Store Visit Headers'";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "'NBA Store Visit Headers'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'ProfilePlus User Settings'";
            Elemt.lb_displaynamedatasource = "'ProfilePlus User Settings'";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "''ProfilePlus User Settings'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "Office365Users";
            Elemt.lb_displaynamedatasource = "Office365Users";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "Office365Users";
            NvListDatas.Add(Elemt);
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'ProfilePlus User Settings'";
            Elemt.lb_displaynamedatasource = "'ProfilePlus User Settings'";
            Elemt.lb_typedatasource = "Dataverse";
            Elemt.lb_namedatasource = "'ProfilePlus User Settings'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "MenuFilterSiteAll";
            Elemt.lb_displaynamedatasource = "MenuFilterSiteAll";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "MenuFilterSiteAll";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'HealthHub.vwMasterWithRows'";
            Elemt.lb_displaynamedatasource = "'HealthHub.vwMasterWithRows'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'HealthHub.vwMasterWithRows'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'[dbo].[Session]'";
            Elemt.lb_displaynamedatasource = "'[dbo].[Session]'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'[dbo].[Session]'";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "Sessions";
            Elemt.lb_displaynamedatasource = "Sessions";
            Elemt.lb_typedatasource = "CollectionDataSourceInfo";
            Elemt.lb_namedatasource = "Sessions";
            NvListDatas.Add(Elemt);
            Elemt = new DataSourceElement();
            Elemt.lb_datasetname = "'[dbo].[ConferenceUser]'";
            Elemt.lb_displaynamedatasource = "'[dbo].[ConferenceUser]'";
            Elemt.lb_typedatasource = "SQL";
            Elemt.lb_namedatasource = "'[dbo].[ConferenceUser]'";
            NvListDatas.Add(Elemt);

            
            //Search(Filter(Filter('[dbo].[Session]', ConferenceID = 1), SessionTypeID > 1), SearchTextInput.Text, "Title", "Description")
            //If(ThisItem.Value = "My Sessions", ClearCollect(PatchedSession, AddColumns(MySessions, "Day", Text(StartTime, LongDate))),ClearCollect(PatchedSession, AddColumns(Sessions, "Day", Text(StartTime, LongDate))))




            PowerAppsParser myparser = new PowerAppsParser(text_StartCode.Text, NvListDatas, text_Propriete.Text,text_Controle.Text, check_Nested.Checked,1);

            text_Resultat.Text = myparser.CodeCleanedProperty;
            text_Resultat.Text = "";

            foreach (CodeFail onefail in myparser.ListOfFails)
            {
                text_Resultat.Text = text_Resultat.Text + onefail.failMessage;
            }
        }
    }
}
