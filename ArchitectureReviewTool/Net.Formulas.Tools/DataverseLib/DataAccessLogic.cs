using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using DataverseLib;
using Microsoft.PowerPlatform.Formulas.Tools;
using Microsoft.Xrm.Sdk.Query;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using Net.Formulas.Tools.Solution;
using Microsoft.Xrm.Sdk.Messages;

namespace Net.Formulas.Tools.DataverseLib
{
    [XmlRoot(ElementName = "Pattern")]
    public class Pattern
    {

        [XmlElement(ElementName = "Resources")]
        public XmlResources Resources { get; set; }

        [XmlElement(ElementName = "Rules")]
        public XmlRules Rules { get; set; }

        [XmlElement(ElementName = "PatternId")]
        public string PatternId { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Category")]
        public int Category { get; set; }

        [XmlElement(ElementName = "Severity")]
        public int Severity { get; set; }

        [XmlElement(ElementName = "Value")]
        public int Value { get; set; }

        [XmlElement(ElementName = "PatternType")]
        public int PatternType { get; set; }

    }


    [XmlRoot(ElementName = "Resource")]
    public class ResourceXml
    {

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Url")]
        public string Url { get; set; }

    }

    [XmlRoot(ElementName = "Resources")]
    public class XmlResources
    {

        [XmlElement(ElementName = "Resource")]
        public List<ResourceXml> Resource { get; set; }
    }


    [XmlRoot(ElementName = "Rule")]
    public class RuleXml
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Level")]
        public string Level { get; set; }

        [XmlElement(ElementName = "PrimaryCategory")]
        public string PrimaryCategory { get; set; }

        [XmlElement(ElementName = "ComponentType")]
        public string ComponentType { get; set; }

        [XmlElement(ElementName = "WhyFix")]
        public string WhyFix { get; set; }
    }

    [XmlRoot(ElementName = "Rules")]
    public class XmlRules
    {

        [XmlElement(ElementName = "Rule")]
        public List<RuleXml> Rule { get; set; }
    }

    [XmlRoot(ElementName = "Patterns")]
    public class XmlPatterns
    {

        [XmlElement(ElementName = "Pattern")]
        public List<Pattern> Pattern { get; set; }
    }


    [XmlRoot(ElementName = "Model")]
    public class RootXml
    {

        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd")]
        public string Xsd { get; set; }

        [XmlElement(ElementName = "Version")]
        public int Version { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "Patterns")]
        public XmlPatterns Patterns { get; set; }

        [XmlElement(ElementName = "Rules")]
        public XmlRules Rules { get; set; }
    }


    public class SettingElement
    {
        public string PropertyName { get; set; }
    }

    public class Variable
    {
        public string VariableName { get; set; }
        public string ScreenListName { get; set; }
        public string[] SeparatorsValues { get; set; }

        public Variable(string NvVariableName, string NvScreenName)
        {
            this.VariableName = NvVariableName;
            this.ScreenListName = NvScreenName;
            List<string> TmpList = new List<string>();

            TmpList.Add(" " + VariableName);
            TmpList.Add(VariableName + " ");
            TmpList.Add(" " + VariableName + " ");
            TmpList.Add(", " + VariableName);
            TmpList.Add(VariableName + ",");
            SeparatorsValues = TmpList.ToArray();

        }

        public void AddScreenName(string NvScreen)
        {
            if (this.ScreenListName != "")
            {
                if (!(this.ScreenListName.Contains(NvScreen + ",") || this.ScreenListName.Contains(", " + NvScreen)))
                {
                    this.ScreenListName += ", " + NvScreen;
                }
            }
            else
            {
                this.ScreenListName = NvScreen;
            }

        }
    }

    public class ListeSimplifiedcreens
    {
        public string ScreenName { get; set; }
        public string ControlName { get; set; }
        public string PropertyName { get; set; }
        public string CodeValue { get; set; }

        public ListeSimplifiedcreens(string NvScreenName, string NvControlName, string NvPropertyName, string NvCodeValue)
        {
            this.ScreenName = NvScreenName;
            this.ControlName = NvControlName;
            this.PropertyName = NvPropertyName;

            string StrCleanedScript;
            int NbLengthScript, ibutee;
            StrCleanedScript = PowerAppsParser.CustomStripComments(NvCodeValue);
            StrCleanedScript = StrCleanedScript.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");
            NbLengthScript = StrCleanedScript.Length;
            ibutee = NbLengthScript >= 25000 ? 25000 : NbLengthScript;


            this.CodeValue = StrCleanedScript;
        }

        public static List<Variable> GetListScreensVariable(List<ListeSimplifiedcreens> LesProprietes)
        {
            string[] ListSplited;
            string[] SplitersSet = { ",Set(", ";Set(", " Set(", "Set(", "Set (" }, SplitersSeparators = { ",", ";" };
            string VarToAdd;
            List<Variable> VarList = new List<Variable>();


            foreach (ListeSimplifiedcreens OneProp in LesProprietes)
            {

                ListSplited = OneProp.CodeValue.Split(SplitersSet, StringSplitOptions.None);
                if (ListSplited.Count() > 1)
                {
                    for (int i = 0; i < ListSplited.Count(); i++)
                    {
                        if (i % 2 > 0)
                        {
                            try
                            {
                                VarToAdd = ListSplited[i].Split(SplitersSeparators, StringSplitOptions.None)[0];
                            }
                            catch (Exception ex)
                            {
                                VarToAdd = "";
                            }

                            if (VarList.Where(x => x.VariableName == VarToAdd).ToList().Count() == 0 && VarToAdd != "")
                            {
                                VarList.Add(new Variable(VarToAdd, ""));
                            }
                        }
                    }
                }
            }

            List<ListeSimplifiedcreens> ecranstrouves;
            for (int i = 0; i < VarList.Count(); i++)
            {

                ecranstrouves = LesProprietes.Where(x => x.CodeValue.Split(VarList[i].SeparatorsValues, StringSplitOptions.None).Length > 1).ToList();
                foreach (ListeSimplifiedcreens Onescr in ecranstrouves)
                {
                    VarList[i].AddScreenName(Onescr.ScreenName);
                }
            }

            return VarList;
        }


    }

    public enum patternsCategoriesChoices
    {
        Performance = 695100000,
        Mantainability = 695100001,
        Security = 695100002,
        Data = 695100003,
        Accessibility = 695100004,
        Coding_Standards = 695100005,
        UX = 695100006
    }

    public enum StatusChoices
    {
        InProgress = 695100001,
        Done = 695100002,
        NotStarted = 695100000,
        Error = 341200000
    }

    class MyResultsCounter
    {
        //public Result thesultObj;
        public List<Result> CollresObj;
        public int nbAdded;
        public int nbTotal;

        public void AddToTotal(Result thesultObj)
        {
            if (this.nbTotal <= 5 || !thesultObj.ruleId.StartsWith("acc"))
            {
                this.CollresObj.Add(thesultObj);
            }
            this.nbTotal += 1;
        }

        public MyResultsCounter(Result NewResult)
        {
            this.nbTotal = 0;
            this.nbAdded = 0;
            this.CollresObj = new List<Result>();
            //this.thesultObj = NewResult;
            this.AddToTotal(NewResult);
        }

        public static Dictionary<string, MyResultsCounter> WrapMyResults(List<Result> msappResults)
        {

            Dictionary<string, MyResultsCounter> retList = new Dictionary<string, MyResultsCounter>();

            foreach (Result OneResult in msappResults)
            {

                if (retList.ContainsKey(OneResult.ruleId))
                {
                    retList["OneResult.ruleId"].AddToTotal(OneResult);
                }
                else
                {
                    retList.Add(OneResult.ruleId, new MyResultsCounter(OneResult));
                }

            }

            return retList;

        }

    }

    class DataLoadingElement
    {
        public string lbCollectionName { get; set; }

        public List<string> lListSubFunctions { get; set; }

        public DataLoadingElement(string strtoSplit)
        {

            string[] MyStr = { ",,,," };
            List<string> ListElemts = strtoSplit.Split(MyStr, StringSplitOptions.None).ToList();
            this.lbCollectionName = ListElemts.First();

            this.lListSubFunctions = new List<string>();

            for (int i = 1; i < ListElemts.Count; i++)
            {
                this.lListSubFunctions.Add(ListElemts[i]);
            }

        }

    }

    public class AutoFailPattern
    {
        public string lbPatternName { get; set; }
        public bool isDirectError { get; set; }
        public string MessageIfNotFound { get; set; }

        public AutoFailPattern(string nvlbPatternName, bool nvisDirectError, string NvMessageIfNotFound = "")
        {
            this.lbPatternName = nvlbPatternName;
            this.isDirectError = nvisDirectError;
            this.MessageIfNotFound = NvMessageIfNotFound;
        }

        public static List<AutoFailPattern> GenerateListAutoFails()
        {
            List<AutoFailPattern> PatternsToCheck = new List<AutoFailPattern>
            {
                new AutoFailPattern("app-CheckForNplusOneCalls", true),
                new AutoFailPattern("app-FormulaOptimization-NestedFilter", true),
                new AutoFailPattern("app-FormulaOptimization-Patch", true),
                new AutoFailPattern("app-FormulaOptimization-FirstFilter", true),
                new AutoFailPattern("app-FormulaOptimization-UseStartsWith", true),

                new AutoFailPattern("app-FormulaOptimization-NestedApiCalls", true),
                new AutoFailPattern("app-CodeReadability", true),
                new AutoFailPattern("app-ErrorHandling", true),
                new AutoFailPattern("app-DataLoadingStrategy", true),
                new AutoFailPattern("app-ConcurrentCall", false, "Code review tool : This app does not does not make use of Concurrent function. Please consider use it to ensure external database or API requests are performed in parallel.")
            };

            return PatternsToCheck;
        }

    }


    public class AutoFailElement
    {
        public string lbPatternName;
        public string lbPropertyGuid;
        public string lbComment;
        public string lbScreenName;
        public string lbControlName;
        public string lbPropertyName;
        public string lbCode;

        public string lbCompletestring;

        public AutoFailElement(string strToParse)
        {
            string[] Splitrers = { ";;;;" };
            string[] ParsedOne = strToParse.Split(Splitrers, StringSplitOptions.None);

            if (ParsedOne.Count() >= 6)
            {
                this.lbPatternName = ParsedOne[0];
                this.lbPropertyGuid = ParsedOne[1];
                this.lbComment = ParsedOne[2];
                this.lbScreenName = ParsedOne[3];
                this.lbControlName = ParsedOne[4];
                this.lbPropertyName = ParsedOne[5];
                if (ParsedOne.Count() == 7)
                    this.lbCode = ParsedOne[6];
            }
            else
            {
                this.lbPatternName = "no";
                this.lbPropertyGuid = "no";
                this.lbComment = "no";
                this.lbScreenName = "no";
                this.lbControlName = "no";
                this.lbPropertyName = "no";
                this.lbCode = "no";
            }

        }

        public AutoFailElement(string nvlbPatternName, string nvlbPropertyGuid, string nvlbComment, string nvlbScreenName, string nvlbControlName, string nvlbPropertyName, string nvlbCode)
        {

            this.lbPatternName = nvlbPatternName;
            this.lbPropertyGuid = nvlbPropertyGuid;
            this.lbComment = nvlbComment;
            this.lbScreenName = nvlbScreenName;
            this.lbControlName = nvlbControlName;
            this.lbPropertyName = nvlbPropertyName;
            this.lbCode = nvlbCode;

            lbCompletestring = nvlbPatternName + ";;;;" + nvlbPropertyGuid + ";;;;" + nvlbComment + ";;;;" + nvlbScreenName + ";;;;" + nvlbControlName + ";;;;" + nvlbPropertyName + ";;;;" + nvlbCode;

        }

        public static List<AutoFailElement> LoadListAutoFailsElements(string strToParse)
        {

            List<AutoFailElement> ListRet = new List<AutoFailElement>();
            string[] Splitrers = { "____" };
            string[] ParsedOne = strToParse.Split(Splitrers, StringSplitOptions.None);

            AutoFailElement OneElement;

            foreach (string OneStr in ParsedOne)
            {
                OneElement = new AutoFailElement(OneStr);
                if (OneElement.lbPatternName != "no" && OneElement.lbPropertyGuid != "no")
                {
                    ListRet.Add(OneElement);
                }

            }

            return ListRet;

        }

        public static string LoadListAutoFailsElements(List<AutoFailElement> listToParse)
        {

            string strRet = "", strEnc = "";


            foreach (AutoFailElement OneStr in listToParse)
            {
                strEnc = OneStr.lbPatternName + ";;;;" + OneStr.lbPropertyGuid + ";;;;" + OneStr.lbComment + ";;;;" + OneStr.lbScreenName + ";;;;" + OneStr.lbControlName + ";;;;" + OneStr.lbPropertyName + ";;;;";// + OneStr.lbCode ;
                if (strRet == "")
                {
                    strRet = strEnc;
                }
                else
                {
                    strRet += "____" + strEnc;
                }
            }

            return strRet;

        }

    }

    public class CodeFail
    {
        public string PropertyName { get; set; }
        public string failMessage { get; set; }

        public string patternName { get; set; }
        public string ControlName { get; set; }

        public CodeFail(string NvProperty, string NvMessage, string NvpatternName, string NvcontrolName)
        {
            this.PropertyName = NvProperty;
            this.failMessage = NvMessage;
            this.patternName = NvpatternName;
            this.ControlName = NvcontrolName;
        }

    }

    public class DataSourceElement
    {
        public string lb_namedatasource { get; set; }
        public string lb_datasetname { get; set; }
        public string lb_typedatasource { get; set; }
        public string lb_displaynamedatasource { get; set; }

    }

    public class ParametersFunction
    {
        public List<int> RankParameters { get; set; }
        public string strParameters { get; set; }

        public bool HasSubFunctions { get; set; }

        public ParametersFunction(List<int> RankParams, string strParams, bool subfunctions)
        {
            this.strParameters = strParams;
            this.RankParameters = RankParams;
            this.HasSubFunctions = subfunctions;
        }

        public ParametersFunction()
        {
            this.RankParameters = new List<int>();
            this.HasSubFunctions = false;
        }

    }

    public class PowerAppsElement
    {
        public string ElementName { get; set; }
        public string ElementType { get; set; }

        //For variables
        public string strValue { get; set; }
        public string strTypeValue { get; set; }


        //For datasources
        public bool IsLocal { get; set; }

        //ForFUnctions
        public List<PowerAppsElement> Parameters { get; set; }

        public List<DataSourceElement> ListeDatasources;

        public PowerAppsElement(string NvElementName, string NvElementType, string NvstrValue, string NvstrTypeValue, bool NvIsLocal, List<DataSourceElement> TheDatasources, ParametersFunction ContentCode)
        {

            this.ElementName = NvElementName.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(")", "").Trim();
            this.ElementType = NvElementType;

            this.strValue = NvstrValue;
            this.strTypeValue = NvstrTypeValue;

            this.IsLocal = NvIsLocal;
            this.ListeDatasources = TheDatasources;
            //ici
            if (ContentCode.RankParameters.Count > 0 || ContentCode.HasSubFunctions)
            {
                this.ParseParameters(ContentCode);
            }
            else if (ContentCode.strParameters.Trim().Length > 0)
            {
                this.Parameters = new List<PowerAppsElement>();
                this.Parameters.Add(this.GetElementTypeFromString(ContentCode.strParameters));
            }
            else
            {
                this.Parameters = new List<PowerAppsElement>();
            }

        }

        public PowerAppsElement(string NvElementName, string NvElementType, string NvstrValue, string NvstrTypeValue, bool NvIsLocal, List<DataSourceElement> TheDatasources)
        {

            this.ElementName = NvElementName.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(")", "").Replace(",", "").Replace(";", "").Trim();
            this.ElementType = NvElementType;

            this.strValue = NvstrValue;
            this.strTypeValue = NvstrTypeValue;

            this.IsLocal = NvIsLocal;
            this.ListeDatasources = TheDatasources;

            this.Parameters = new List<PowerAppsElement>();

        }

        public PowerAppsElement(string NvElementName, string NvElementType, string NvstrValue, string NvstrTypeValue, bool NvIsLocal)
        {
            this.ElementName = NvElementName.Replace("\n", "").Replace("\r", "").Replace("\t", "").Trim();
            this.ElementType = NvElementType;

            this.strValue = NvstrValue;
            this.strTypeValue = NvstrTypeValue;

            this.IsLocal = NvIsLocal;
            this.Parameters = new List<PowerAppsElement>();

        }

        public static bool CheckCharIndexNotInQuotes(string MainTxt, int index)
        {
            if (index == -1) return false;
            int NbAfterSingle, NbBeforeSingle, NbAfterDouble, NbBeforeDouble;
            string txtStart, txtEnd;
            txtStart = MainTxt.Substring(0, index - 1);
            txtEnd = MainTxt.Substring(index + 1, MainTxt.Length - index - 2);

            NbBeforeSingle = txtStart.Split('\'').Length - 1;
            NbBeforeDouble = txtStart.Split('"').Length - 1;
            NbAfterSingle = txtEnd.Split('\'').Length - 1;
            NbAfterDouble = txtEnd.Split('"').Length - 1;

            if ((NbBeforeSingle == 1 && NbAfterSingle == 1) || (NbBeforeDouble == 1 && NbAfterDouble == 1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public PowerAppsElement GetElementTypeFromString(string PAppsCode)
        {
            char[] formulaschars = { '=', '>', '<', '&', '|', '+', ' ', '\r', '\n', '\t' };

            PowerAppsElement NvPowerAppsElement;
            List<DataSourceElement> MatchedDatasources = this.ListeDatasources.Where(x => x.lb_namedatasource.Replace("'", "").Replace(")", "").Replace("\"", "") == PAppsCode.Replace("'", "").Replace(",", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "").Trim()).ToList();

            if (MatchedDatasources.Count == 0)
            {
                MatchedDatasources = this.ListeDatasources.Where(x => PAppsCode.Split(formulaschars).Contains(x.lb_namedatasource)).ToList();
            }

            /*
                List<DataSourceElement> MatchedDatasources = this.ListeDatasources.Where(x => 
            (" "+PAppsCode.Replace("'", "").Replace(")", " ").Replace(",", " ").Replace("=", " ").Replace(">", " ").Replace("<", " ").Replace("\"", "").Replace("\r", " ").Replace("\t", " ").Replace("\n", " ")+" ").Contains(" " + x.lb_namedatasource.Replace("'", "").Replace("\"", "") + " ")
            || x.lb_namedatasource.Replace("'", "").Replace(")", "").Replace("\"", "") == PAppsCode.Replace("'", "").Replace(",", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "").Trim()
            ).ToList();
            */

            if (MatchedDatasources.Count > 0)
            {
                if (MatchedDatasources.First().lb_typedatasource == "CollectionDataSourceInfo" || MatchedDatasources.First().lb_typedatasource == "StaticDataSourceInfo")
                {
                    NvPowerAppsElement = new PowerAppsElement(MatchedDatasources.First().lb_namedatasource, "Datasource", "", "", true, MatchedDatasources);
                }
                else
                {
                    NvPowerAppsElement = new PowerAppsElement(MatchedDatasources.First().lb_namedatasource, "Datasource", "", "", false, MatchedDatasources);//PAppsCode
                }

            }
            else
            {
                if (PAppsCode.Contains("\""))
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "HardCoded", PAppsCode, "string", true, new List<DataSourceElement>());
                }
                else if (int.TryParse(PAppsCode, out int val))
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "HardCoded", PAppsCode, "number", true, new List<DataSourceElement>());
                }
                /*else if (PAppsCode.Split(formulaschars).Count()>1)
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "Formula", PAppsCode, "Formula", true, new List<DataSourceElement>());
                }*/
                else
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "Variable", PAppsCode, "Variable", true, new List<DataSourceElement>());
                }

            }

            return NvPowerAppsElement;
        }
        /*public PowerAppsElement GetElementTypeFromString(string PAppsCode)
        {

            PowerAppsElement NvPowerAppsElement;
            List<DataSourceElement> MatchedDatasources = this.ListeDatasources.Where(x => x.lb_namedatasource.Replace("'", "").Replace("\"", "") == PAppsCode.Replace("'", "").Replace(",", "").Replace("\"", "").Replace("\r", "").Replace("\t", "").Replace("\n", "").Trim()).ToList();
            if (MatchedDatasources.Count > 0)
            {
                if (MatchedDatasources.First().lb_typedatasource == "CollectionDataSourceInfo" || MatchedDatasources.First().lb_typedatasource == "StaticDataSourceInfo")
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "Datasource", "", "", true, MatchedDatasources);
                }
                else
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "Datasource", "", "", false, MatchedDatasources);
                }

            }
            else
            {
                if (PAppsCode.Contains("\""))
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "HardCoded", PAppsCode, "string", true, new List<DataSourceElement>());
                }
                else if (int.TryParse(PAppsCode, out int val))
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "HardCoded", PAppsCode, "number", true, new List<DataSourceElement>());
                }
                else
                {
                    NvPowerAppsElement = new PowerAppsElement(PAppsCode, "Variable", PAppsCode, "Variable", true, new List<DataSourceElement>());
                }

            }

            return NvPowerAppsElement;
        }
        */
        private void ParseParameters(ParametersFunction ContentCode)
        {

            string strParam = "", FromBeginning;
            int lastIndex = 0, curindex = 0;
            PowerAppsElement NvPowerAppsElement;
            int oneIndex = 0;

            for (int ind = 0; ind <= ContentCode.RankParameters.Count; ind++)
            {
                if (ind == ContentCode.RankParameters.Count)
                {
                    lastIndex = oneIndex;
                    oneIndex = ContentCode.strParameters.Length - 1;
                }
                else if (ind == 0)
                {
                    lastIndex = 0;
                    oneIndex = ContentCode.RankParameters[0];
                }
                else
                {
                    lastIndex = oneIndex;
                    oneIndex = ContentCode.RankParameters[ind];
                }

                strParam = ContentCode.strParameters.Substring(lastIndex, oneIndex - lastIndex);

                if (strParam.Contains("(") && !PowerAppsElement.CheckCharIndexNotInQuotes(strParam, strParam.IndexOf("(", 1)) && strParam.Substring(0, strParam.IndexOf("(", 1)).Trim().Length >= 2)
                {

                    if (this.Parameters == null)
                    {
                        this.Parameters = new List<PowerAppsElement>();
                    }

                    curindex = strParam.IndexOf("(", 1);
                    FromBeginning = strParam.Substring(0, curindex);
                    FromBeginning = FromBeginning.Split(PowerAppsParser.exlusionList, StringSplitOptions.None).Last();

                    if (FromBeginning.Trim() != "")
                    {

                        if (FromBeginning.Contains(".") && !PowerAppsElement.CheckCharIndexNotInQuotes(FromBeginning, FromBeginning.IndexOf(".", 1)))
                        {
                            string ConnectorPartOfFunction = FromBeginning.Split('.')[0];
                            this.Parameters.Add(this.GetElementTypeFromString(ConnectorPartOfFunction.Trim()));
                        }

                        this.Parameters.Add(new PowerAppsElement(FromBeginning, "Function", "", "", true, this.ListeDatasources, PowerAppsParser.GestAllParametersFunction(strParam.Substring(curindex))));

                    }
                }
                else
                {

                    NvPowerAppsElement = this.GetElementTypeFromString(strParam);
                    if (this.Parameters == null)
                    {
                        this.Parameters = new List<PowerAppsElement>();
                    }
                    this.Parameters.Add(NvPowerAppsElement);

                }

            }

        }


    }

    public class PowerAppsParser
    {

        private List<DataSourceElement> ListeDatasources;

        public static string[] exlusionList = { "\n", "\r", "\t", ";", ",", "(", ")", " ", "&", "|", "+", "*", "/", "\"" };
        public List<CodeFail> ListOfFails { get; set; }

        public int IndiceScreen { get; set; }
        public string NameProperty { get; set; }
        public string NameControl { get; set; }
        public bool isNestedProperty { get; set; }

        public string CodeProperty { get; set; }

        public string CodeCleanedProperty { get; set; }

        public List<PowerAppsElement> ListFunctions { get; set; }

        public PowerAppsParser(string NvCodeProperty, List<DataSourceElement> NvListeDatasources, string NvNameProperty, string NvNameControl, bool NvisNestedProperty, int NvIndiceScreen)
        {

            this.ListOfFails = new List<CodeFail>();
            this.CodeProperty = NvCodeProperty;
            this.ListeDatasources = NvListeDatasources;
            this.NameProperty = NvNameProperty;
            this.isNestedProperty = NvisNestedProperty;
            this.NameControl = NvNameControl;
            this.IndiceScreen = NvIndiceScreen;
            this.ListFunctions = new List<PowerAppsElement>();

            this.ParseCode();

            if (this.ListFunctions.Count > 0)
            {

                if (!string.IsNullOrEmpty(this.NameProperty))
                {
                    if (isNestedProperty && this.NameProperty.Substring(0, 2) != "On")
                    {
                        this.SearchNplusOneCalls();
                    }
                }

                this.SearchNestedFilters();
                this.SearchFirstFilter();
                this.SearchPatch();
                this.SearchnestedApiCalls();
                this.SearchCodeReadability();
                this.SearchErrorHandling();
                this.SearchConcurent();
                this.SearchDataLoadingStrategy();

            }

        }

        static public string CustomStripComments(string code)
        {
            /*if(!code.Contains("//") && !(code.Contains("/*") && code.Contains("/")))
            {
                return code;
            }

            char[] collEndrows = { '\n', '\r' };

            if (code.Contains("//"))
            {

            }*/

            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var verbatimStrings = @"@(""[^""]*"")+";

            code = Regex.Replace(code,
                                blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
                                me =>
                                {
                                    if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                                        return me.Value.StartsWith("//") ? Environment.NewLine : "";
                                    return me.Value;
                                },
                                RegexOptions.Singleline);

            return code;
        }


        static string StripComments(string code)
        {
            var re = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
            code = Regex.Replace(code, "<svg(.|\n)*?</svg>", "svg image");

            return Regex.Replace(code, re, "$1");
        }

        private void ParseCode()
        {
            try
            {
                this.CodeCleanedProperty = PowerAppsParser.CustomStripComments(this.CodeProperty);
                this.ListFunctions = PowerAppsParser.ExtractListFunctions(this.CodeCleanedProperty, this.ListeDatasources);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }

        private void SearchNplusOneCalls()
        {
            List<string> ListNPlus = PowerAppsParser.GetListFunctions("nplusun");
            List<PowerAppsElement> ListKo = new List<PowerAppsElement>();
            if (this.isNestedProperty)
            {
                ListKo = this.ListFunctions
                        .Flatten(myObject => myObject.Parameters)
                            .Where(myObject => myObject.ElementType == "Function" && ListNPlus.Contains(myObject.ElementName)
                                    && myObject.Parameters.Flatten(mySubObject => mySubObject.Parameters)
                                                            .Where(mySubObject => mySubObject.ElementType == "Datasource" && mySubObject.IsLocal == false)
                                                            .ToList().Count > 0
                            )
                        .ToList();
            }

            if (ListKo.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Calling external datasources from within gallery items can result in large number of calls.", "app-CheckForNplusOneCalls", this.NameControl));
            }

        }

        private void SearchCodeReadability()
        {

            bool IsReadabilityOk = true;
            string strRet = "Code review tool : ";
            if (this.CodeCleanedProperty.Length == this.CodeProperty.Length && this.CodeCleanedProperty.Length > 1000)
            {
                IsReadabilityOk = false;
                strRet += this.CodeCleanedProperty.Length.ToString() + " carachters long code without comments.";
            }

            List<string> ListNestedIf = GetListFunctions("nestingFunctions");
            List<PowerAppsElement> Listif = new List<PowerAppsElement>();
            List<PowerAppsElement> Listif2 = new List<PowerAppsElement>();
            Listif = this.ListFunctions.Flatten(FunctionNesting => FunctionNesting.Parameters)
                                        .Where(FunctionNesting => FunctionNesting.ElementType == "Function" && ListNestedIf.Contains(FunctionNesting.ElementName))
                                        .ToList();

            foreach (PowerAppsElement OneSon in Listif)
            {
                if (OneSon.Parameters != null)
                    Listif2.AddRange(OneSon.Parameters.Flatten(FunctionNested => FunctionNested.Parameters)
                        .Where(FunctionNested => FunctionNested.ElementType == "Function" && ListNestedIf.Contains(FunctionNested.ElementName))
                        .ToList());
            }

            if (Listif2.Count >= 2)
            {
                IsReadabilityOk = false;
                strRet += this.CodeCleanedProperty.Length.ToString() + (Listif2.Count + 1) + " nested If, consider using switch statment instead.";
            }

            if (!IsReadabilityOk)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, strRet, "app-CodeReadability", this.NameControl));
            }

        }

        private void SearchDataLoadingStrategy()
        {

            List<string> ListLoadingFunctions = PowerAppsParser.GetListFunctions("LoadingFunctions");
            List<string> ListLocalFunction = new List<string>();

            if (this.IndiceScreen == 0)
            {

                if (this.NameProperty == "OnStart")
                {
                    List<string> ListNavigationFunctions = PowerAppsParser.GetListFunctions("Navigation");

                    List<PowerAppsElement> ListNavigate = new List<PowerAppsElement>();
                    ListNavigate.AddRange(this.ListFunctions.Flatten(FunctionNested => FunctionNested.Parameters)
                        .Where(
                            DatasourceExt => DatasourceExt.ElementType == "Function" && ListNavigationFunctions.Contains(DatasourceExt.ElementName)
                        )
                    );

                    if (ListNavigate.Count > 0)
                    {
                        this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Using 'Navigate' function", "app-DataLoadingStrategy", this.NameControl));
                    }
                }

                List<PowerAppsElement> ListExternalClearCollect = new List<PowerAppsElement>();
                ListExternalClearCollect.AddRange(this.ListFunctions.Flatten(FunctionNested => FunctionNested.Parameters)
                    .Where(DatasourceExt => DatasourceExt.ElementType == "Function" && ListLoadingFunctions.Contains(DatasourceExt.ElementName) &&
                        DatasourceExt.Parameters.Count >= 2 &&
                        (
                             DatasourceExt.Parameters//[1].Parameters
                                    .Flatten(FunctionNested => FunctionNested.Parameters)
                                    .Where(Datasrc => Datasrc.ElementType == "Datasource" && Datasrc.IsLocal == false).ToList().Count > 0
                        )

                    )

                );

                foreach (PowerAppsElement OneElt in ListExternalClearCollect)
                {
                    if (OneElt.Parameters.Count >= 2)
                    {
                        if (!ListLocalFunction.Contains(OneElt.Parameters[0].ElementName))
                        {
                            ListLocalFunction.Add(OneElt.Parameters[0].ElementName);
                        }
                    }
                }

                List<PowerAppsElement> ListLocalsDupplicates;

                for (int i = 0; i < ListLocalFunction.Count; i++)
                {
                    ListLocalsDupplicates = new List<PowerAppsElement>();
                    ListLocalsDupplicates.AddRange(this.ListFunctions.Flatten(FunctionNested => FunctionNested.Parameters)
                        .Where(DatasourceExt => DatasourceExt.ElementType == "Function" && ListLoadingFunctions.Contains(DatasourceExt.ElementName) &&
                            DatasourceExt.Parameters.Count >= 2 &&
                            (
                                DatasourceExt.Parameters//[1].Parameters
                                .Flatten(FunctionNested => FunctionNested.Parameters)
                                .Where(Datasrc => Datasrc.ElementName == ListLocalFunction[i] || Datasrc.ElementName.Split('.')[0] == ListLocalFunction[i]).ToList().Count > 0
                            )
                        ).ToList()
                    );

                    foreach (PowerAppsElement OneFinal in ListLocalsDupplicates)
                    {
                        ListLocalFunction[i] += ",,,," + OneFinal.Parameters[0].ElementName;

                    }

                }

                if (ListLocalFunction.Count > 0)
                {
                    string strRet = "";
                    foreach (string OneStr in ListLocalFunction)
                    {
                        if (strRet == "")
                        {
                            strRet = OneStr;
                        }
                        else
                        {
                            strRet += "|||||" + OneStr;
                        }
                    }
                    this.ListOfFails.Add(new CodeFail("", strRet, "app-DataLoadingStrategy0", this.NameControl));
                }
            }
            else if (this.IndiceScreen == 1)
            {

                List<PowerAppsElement> ListExternalClearCollect = new List<PowerAppsElement>();
                ListExternalClearCollect.AddRange(this.ListFunctions.Flatten(FunctionNested => FunctionNested.Parameters)
                    .Where(DatasourceExt => ((DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal) || DatasourceExt.ElementType == "Variable")
                        )
                    );

                string strRet = "";

                foreach (PowerAppsElement OneStr in ListExternalClearCollect)
                {
                    if (strRet == "")
                    {
                        strRet = OneStr.ElementName;
                    }
                    else
                    {
                        strRet += "|||||" + OneStr.ElementName;
                    }
                }
                if (ListExternalClearCollect.Count > 0)
                {
                    this.ListOfFails.Add(new CodeFail("", strRet, "app-DataLoadingStrategy1", this.NameControl));
                }

            }

        }

        private void SearchConcurent()
        {

            List<string> ListNestedOut = GetListFunctions("concurrentTrackedFunction");
            List<PowerAppsElement> ListConcurrent = new List<PowerAppsElement>();
            List<PowerAppsElement> ListKo2 = new List<PowerAppsElement>();

            ListConcurrent = this.ListFunctions.Flatten(FunctionNesting => FunctionNesting.Parameters)
                .Where(FunctionNesting => FunctionNesting.ElementType == "Function" && FunctionNesting.ElementName == "Concurrent").ToList();
            foreach (PowerAppsElement OneSon in ListConcurrent)
            {

                ListKo2.AddRange(OneSon.Parameters.Flatten(FunctionNested => FunctionNested.Parameters)
                    .Where(FunctionNested => FunctionNested.ElementType == "Function" && ListNestedOut.Contains(FunctionNested.ElementName))
                    .Flatten(FunctionNested => FunctionNested.Parameters)
                        .Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false).ToList()
                    );

                if (ListKo2.Count > 2)
                {
                    break;
                }

            }

            if (ListKo2.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : the Concurrent function used in your code at least once. Use the code viewer to find more opportunities to use ConcurrentCall", "app-ConcurrentCall", this.NameControl));
            }

        }

        private void SearchErrorHandling()
        {

            bool IsErrorHandlingOk = true;

            List<PowerAppsElement> ListPatch = new List<PowerAppsElement>();
            List<PowerAppsElement> ListPatchOut = new List<PowerAppsElement>();
            List<PowerAppsElement> ListIfError = new List<PowerAppsElement>();
            List<string> ListErrorManagment = GetListFunctions("ErrorManagment");

            ListPatchOut = this.ListFunctions.Flatten(FunctionNesting => FunctionNesting.Parameters)
                            .Where(FunctionsPatch => FunctionsPatch.ElementType == "Function" && FunctionsPatch.ElementName == "Patch")
                                .Flatten(FunctionNested => FunctionNested.Parameters)
                                .Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false)
                    .ToList();

            if (ListPatchOut.Count > 0)
            {
                ListIfError = this.ListFunctions
                    .Flatten(FunctionsPatch => FunctionsPatch.Parameters).Where(FunctionsPatch => FunctionsPatch.ElementType == "Function" && ListErrorManagment.Contains(FunctionsPatch.ElementName)).ToList();


                if (ListIfError.Count > 0)
                {

                    foreach (PowerAppsElement IfErrorFounded in ListIfError)
                    {
                        ListPatch.AddRange(IfErrorFounded.Parameters.Flatten(FunctionNesting => FunctionNesting.Parameters)
                            .Where(FunctionsPatch => FunctionsPatch.ElementType == "Function" && FunctionsPatch.ElementName == "Patch")
                                .Flatten(FunctionNested => FunctionNested.Parameters)
                                .Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false)
                        .ToList());
                    }


                }
                else
                {
                    IsErrorHandlingOk = false;
                }

                if (ListPatch.Count < ListPatchOut.Count)
                {
                    IsErrorHandlingOk = false;
                }

            }

            if (!IsErrorHandlingOk)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Patch functions on external datasources. Consider using IfError() or IsError() to implement error handling", "app-ErrorHandling", this.NameControl));
            }

        }


        private void SearchNestedFilters()
        {

            List<string> ListNestedOut = GetListFunctions("nestedSearchout");
            List<string> ListNestedIn = GetListFunctions("nestedSearchin");
            List<PowerAppsElement> ListKo = new List<PowerAppsElement>();
            List<PowerAppsElement> ListKo2 = new List<PowerAppsElement>();

            ListKo = this.ListFunctions.Flatten(FunctionNesting => FunctionNesting.Parameters).Where(FunctionNesting => FunctionNesting.ElementType == "Function" && ListNestedOut.Contains(FunctionNesting.ElementName)).ToList();
            foreach (PowerAppsElement OneSon in ListKo)
            {
                ListKo2.AddRange(OneSon.Parameters
                        .Flatten(FunctionNested => FunctionNested.Parameters)
                        .Where(FunctionNested => FunctionNested.ElementType == "Function" && ListNestedIn.Contains(FunctionNested.ElementName)
                        && FunctionNested.Parameters.Flatten(FunctionSubNested => FunctionSubNested.Parameters)
                            .Where(FunctionSubNested => FunctionSubNested.ElementType == "Datasource" && FunctionSubNested.IsLocal == false)
                            .ToList().Count > 0
                        ).ToList()
                    );
            }


            if (ListKo2.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Nested search operations found. Consider not using Filter/Search targeting external datasources inside another Filter/ForAll/Search", "app-FormulaOptimization-NestedFilter", this.NameControl));
            }

        }

        private void SearchnestedApiCalls()
        {

            List<string> ListNestedOut = PowerAppsParser.GetListFunctions("nestedCallout");
            List<string> ListNestedIn = PowerAppsParser.GetListFunctions("nestedCallin");
            List<PowerAppsElement> ListKo = new List<PowerAppsElement>();
            List<PowerAppsElement> ListKo2 = new List<PowerAppsElement>();

            ListKo = this.ListFunctions.Flatten(FunctionNesting => FunctionNesting.Parameters)
                                        .Where(FunctionNesting => FunctionNesting.ElementType == "Function" && ListNestedOut.Contains(FunctionNesting.ElementName))
                                        .ToList();
            foreach (PowerAppsElement OneSon in ListKo)
            {
                ListKo2.AddRange(OneSon.Parameters.Flatten(FunctionNested => FunctionNested.Parameters)
                                                    .Where(FunctionNested => FunctionNested.ElementType == "Function" && ListNestedIn.Contains(FunctionNested.ElementName)
                                                            && FunctionNested.Parameters.Flatten(FunctionSubNested => FunctionSubNested.Parameters)
                                                            .Where(FunctionSubNested => FunctionSubNested.ElementType == "Datasource" && FunctionSubNested.IsLocal == false)
                                                            .ToList().Count > 0
                                                    ).ToList()
                    );
            }


            if (ListKo2.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Nested API calls found. Consider not nesting calls to external API inside Filter/ForAll/Search/Lookup", "app-FormulaOptimization-NestedApiCalls", this.NameControl));
            }


        }

        private void SearchPatch()
        {
            List<string> ListPatch = PowerAppsParser.GetListFunctions("patch");
            List<PowerAppsElement> ListKo = new List<PowerAppsElement>();

            ListKo = this.ListFunctions
                    .Flatten(FunctionsPatch => FunctionsPatch.Parameters)
                    .Where(FunctionsPatch => FunctionsPatch.ElementType == "Function" && FunctionsPatch.ElementName == "Patch")
                    .Flatten(FunctionsPatch2 => FunctionsPatch2.Parameters)
                        .Where(FunctionNested => FunctionNested.ElementType == "Function" && ListPatch.Contains(FunctionNested.ElementName))
                        .Flatten(FunctionsPatch3 => FunctionsPatch3.Parameters)
                            .Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false)
                    .ToList();

            if (ListKo.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Additional API calls found within a Patch statement. Consider not refactoring out the API Call from the Patch", "app-FormulaOptimization-Patch", this.NameControl));
            }
        }

        private void SearchFirstFilter()
        {
            List<string> ListFirst = PowerAppsParser.GetListFunctions("first");
            List<string> ListFFilter = PowerAppsParser.GetListFunctions("firstfilter");
            List<PowerAppsElement> ListKo = new List<PowerAppsElement>();

            ListKo = this.ListFunctions
                    .Flatten(FunctionsFirst => FunctionsFirst.Parameters)
                            .Where(FunctionsFirst => FunctionsFirst.ElementType == "Function" && ListFirst.Contains(FunctionsFirst.ElementName)
                                && FunctionsFirst.Parameters.Flatten(FunctionFilter => FunctionFilter.Parameters)
                                    .Where(FunctionFilters => FunctionFilters.ElementType == "Function" && ListFFilter.Contains(FunctionFilters.ElementName)
                                        && FunctionFilters.Parameters.Flatten(DataSource => DataSource.Parameters)
                                        .Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false)
                                            .ToList().Count > 0
                                        ).ToList().Count > 0
                                    ).ToList();

            if (ListKo.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : First(Filter/Search or Last(Filter/Search found. Use LookUp instead.", "app-FormulaOptimization-FirstFilter", this.NameControl));
            }
        }
        //ICI fonctions de fail

        public string GenerateErrorString()
        {
            string str_error = "";
            return str_error;
        }

        public static List<string> GetListFunctions(string typeFunctions)
        {
            List<string> RetLst = new List<string>();
            switch (typeFunctions)
            {
                case "nestedSearchin":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    RetLst.Add("LookUp");
                    break;
                case "Navigation":
                    RetLst.Add("Navigate");
                    break;
                case "nestedSearchout":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    break;
                case "nestedCallin":
                    RetLst.Add("Patch");
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    RetLst.Add("ForAll");
                    RetLst.Add("LookUp");
                    break;
                case "nestedCallout":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    RetLst.Add("ForAll");
                    RetLst.Add("LookUp");
                    break;
                case "nplusun":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    RetLst.Add("ForAll");
                    RetLst.Add("LookUp");
                    RetLst.Add("Patch");
                    RetLst.Add("CountRows");
                    break;
                case "patch":
                    RetLst.Add("LookUp");
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    break;
                case "first":
                    RetLst.Add("First");
                    RetLst.Add("Last");
                    break;
                case "firstfilter":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    break;
                case "nestingFunctions":
                    RetLst.Add("If");
                    break;
                case "concurrentTrackedFunction":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    RetLst.Add("LookUp");
                    RetLst.Add("Collect");
                    RetLst.Add("ClearCollect");
                    RetLst.Add("Set");
                    break;
                case "LoadingFunctions":
                    RetLst.Add("ClearCollect");
                    RetLst.Add("Collect");
                    RetLst.Add("Set");
                    break;
                case "ActionProperties":
                    RetLst.Add("OnSelect");
                    RetLst.Add("OnChange");
                    break;
                case "ErrorManagment":
                    RetLst.Add("IfError");
                    RetLst.Add("IsError");
                    break;

            }

            return RetLst;
        }


        public static List<DataSourceElement> GetListDataSourceElements(CanvasDocument msApp)
        {
            List<DataSourceElement> ListeDatas = new List<DataSourceElement>();

            DataSourceElement NvDataSource;
            foreach (KeyValuePair<string, List<DataSourceEntry>> GrpDatasource in msApp.GetDataSources())
            {

                DataSourceEntry OneDatasource = GrpDatasource.Value[GrpDatasource.Value.Count - 1];

                if (OneDatasource.ExtensionData != null && OneDatasource.ExtensionData.ContainsKey("IsSampleData"))
                {
                    if (OneDatasource.ExtensionData["IsSampleData"].ValueKind == System.Text.Json.JsonValueKind.False)
                    {
                        NvDataSource = new DataSourceElement();
                        NvDataSource.lb_namedatasource = OneDatasource.Name;
                        NvDataSource.lb_datasetname = OneDatasource.DatasetName;
                        NvDataSource.lb_typedatasource = OneDatasource.Type;
                        NvDataSource.lb_displaynamedatasource = OneDatasource.RelatedEntityName;
                        ListeDatas.Add(NvDataSource);
                    }
                }
                else
                {

                    NvDataSource = new DataSourceElement();
                    NvDataSource.lb_namedatasource = OneDatasource.Name;
                    NvDataSource.lb_datasetname = OneDatasource.DatasetName;
                    NvDataSource.lb_typedatasource = OneDatasource.Type;
                    NvDataSource.lb_displaynamedatasource = OneDatasource.RelatedEntityName;
                    ListeDatas.Add(NvDataSource);
                }

            }

            return ListeDatas;

        }

        public static ParametersFunction GestAllParametersFunction(string CodesEnding)
        {

            int countParenthesis = 1, countChars = 1, functionCountChars = 0;
            string ParenthesisOpen = "(", ParenthesisClosed = ")", strParams = "", Ouotes = "\"", strComma = ",", strCommaDot = ";";
            bool areQuotesOpened = false;

            ParametersFunction paramsFunction = new ParametersFunction();

            while (countParenthesis > 0)
            {

                strParams += CodesEnding[countChars];
                if (CodesEnding[countChars] == Ouotes[0])
                {
                    areQuotesOpened = !areQuotesOpened;
                }
                else
                {
                    if (CodesEnding[countChars] == ParenthesisOpen[0] && !areQuotesOpened)
                    {
                        paramsFunction.HasSubFunctions = true;
                        countParenthesis += 1;
                    }
                    if (CodesEnding[countChars] == ParenthesisClosed[0] && !areQuotesOpened)
                    {
                        countParenthesis -= 1;
                    }
                    if (countParenthesis == 1 && !areQuotesOpened && (CodesEnding[countChars] == strComma[0] || CodesEnding[countChars] == strCommaDot[0]))
                    {
                        paramsFunction.RankParameters.Add(functionCountChars);
                    }
                }
                functionCountChars += 1;
                countChars += 1;
            }
            paramsFunction.strParameters = strParams;
            return paramsFunction;

        }

        private static List<PowerAppsElement> ExtractListFunctions(string CodeToAnalyse, List<DataSourceElement> ListeDatasources)
        {

            List<PowerAppsElement> LesFonctions = new List<PowerAppsElement>();
            List<string> RetFunctions = new List<string>();
            string tmpfunction = "", FromBeginning;
            ParametersFunction tmpParams;
            int curindex = 0, lastIndex = 0;
            string[] ParenthesisList = { "(" };

            while (curindex < CodeToAnalyse.Length - 1)
            {

                curindex = CodeToAnalyse.IndexOf("(", lastIndex);

                if (curindex > CodeToAnalyse.Length || curindex == -1)
                {
                    break;
                }
                tmpParams = PowerAppsParser.GestAllParametersFunction(CodeToAnalyse.Substring(curindex));

                FromBeginning = CodeToAnalyse.Substring(0, curindex);
                tmpfunction = FromBeginning.Split(PowerAppsParser.exlusionList, StringSplitOptions.None).Last();

                curindex += tmpParams.strParameters.Length;

                LesFonctions.Add(new PowerAppsElement(tmpfunction, "Function", "", "", true, ListeDatasources, tmpParams));

                lastIndex = curindex + 1;

            }

            return LesFonctions;

        }

        private static List<string> GetListOfFunctions(string CodeToAnalyse)
        {

            List<string> RetFunctions = new List<string>();
            string tmpfunction = "", FromBeginning;
            int curindex = 0, lastIndex = 0;
            string[] ParenthesisList = { "(" };
            int numparentheses = CodeToAnalyse.Split(ParenthesisList, StringSplitOptions.None).Count();

            for (int p = 0; p < numparentheses; p++)
            {

                curindex = CodeToAnalyse.IndexOf("(", lastIndex);
                if (curindex > CodeToAnalyse.Length || curindex == -1)
                {
                    break;
                }
                FromBeginning = CodeToAnalyse.Substring(0, curindex);
                tmpfunction = FromBeginning.Split(PowerAppsParser.exlusionList, StringSplitOptions.None).Last();

                RetFunctions.Add(tmpfunction);

                lastIndex = curindex + 1;
            }

            return RetFunctions;

        }

        private static string RemoveExtraContents(string stringcode)
        {

            string current = stringcode;

            current = PowerAppsParser.RemoveBetween2Substrings(stringcode, "\"", "\"");

            current = PowerAppsParser.RemoveBetween2Substrings(current, "/*", "*/");

            current = PowerAppsParser.RemoveBetween2Substrings(current, "//", "\r\n");

            return current;
        }


        public static string RemoveBetween2Substrings(string original, string substart, string subend)
        {
            string retstring = "";

            string[] separatingStringstart = { substart };
            string[] separatingStringend = { subend };

            List<string> SplitedParts;
            List<string> Messtrings;

            int cmpt = 0;
            if (substart != subend)
            {
                if (original.Contains(substart))
                {
                    Messtrings = original.Split(separatingStringstart, System.StringSplitOptions.None).ToList();

                    foreach (string OnePart in Messtrings)
                    {
                        if (OnePart.Contains(subend))
                        {
                            SplitedParts = OnePart.Split(separatingStringend, System.StringSplitOptions.None).ToList();
                            if (SplitedParts.Count() > 1)
                            {
                                for (int cp = 1; cp < SplitedParts.Count(); cp++)
                                {
                                    retstring += SplitedParts[cp];
                                }

                            }
                        }
                        else
                        {
                            retstring += substart + OnePart + subend;
                        }

                    }
                }
            }
            else
            {

                if (original.Contains(substart))
                {
                    Messtrings = original.Split(separatingStringstart, System.StringSplitOptions.None).ToList();

                    foreach (string OnePart in Messtrings)
                    {
                        cmpt += 1;
                        if (cmpt % 2 == 1)
                        {
                            retstring += OnePart;
                        }

                    }

                }

            }

            return retstring;
        }

        private void CheckParsedCode()
        {

        }

    }


    class DataAccessLogic
    {
        public static List<Entity> BulkRecordstoCreate = new List<Entity>();
        public static bool ProcessAppLaunch(DataverseOperator myOperator, PowerApps OneApp, Guid SolutionGuid, Guid MyResultAppGUID, ITracingService tracingService)
        {

            Guid MyRequestReviewGUID, MyResultReviewGUID;
            Dictionary<string, object> newDatas;

            try
            {
                string appName = OneApp.NomPowerApps.Replace(".msapp", "");
                newDatas = new Dictionary<string, object>
                {
                    { "cat_name", appName },
                    { "cat_appname", appName },
                    { "cat_cd_typeoriginereview", "Solution" }
                };

                OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);
                newDatas.Add("cat_chc_statutimportglobal", OptionReviewNotStarted);

                EntityReference ReviewSolution = new EntityReference("cat_rev_solutionreview", SolutionGuid);
                newDatas.Add("cat_review_solutionreviews", ReviewSolution);
                EntityReference ReviewApp = new EntityReference("cat_rev_apps", MyResultAppGUID);
                newDatas.Add("cat_rev_reviews_apps", ReviewApp);

                // Convert App to Base64 string and store in 'cat_apppayload' field
                string base64AppPayload = string.Empty;
                Stream appStream = OneApp.ContenuFichier;
                if (tracingService != null) tracingService.Trace($"Converting appStream of size {appStream.Length} to Base64 string");
                BinaryReader br = new BinaryReader(appStream);
                appStream.Position = 0;
                byte[] appDataBytes = br.ReadBytes(Convert.ToInt32(appStream.Length));
                base64AppPayload = Convert.ToBase64String(appDataBytes);
                // Add payload to Review record only if length is valid
                //if (base64AppPayload.Length < 1048000) newDatas.Add("cat_apppayload", base64AppPayload);

                if (tracingService != null) tracingService.Trace($"Creating 'Review' : {appName}");
                MyResultReviewGUID = myOperator.QueryCreate("cat_review", newDatas);
                if (tracingService != null) tracingService.Trace($"'Review' : {appName} created; Id : {MyResultReviewGUID}");

                // Create Note record
                if (tracingService != null) tracingService.Trace($"Binary Reader; Bytes Length : {appDataBytes.Length}; Base64AppPayload length : {base64AppPayload.Length}");
                if (tracingService != null) tracingService.Trace("Creating annotation");
                try
                {
                    var entAnnotation = new Entity("annotation");
                    entAnnotation["objectid"] = new EntityReference("cat_review", MyResultReviewGUID);
                    entAnnotation["objecttypecode"] = "cat_review";
                    entAnnotation["filename"] = $"cat_review_{MyResultReviewGUID}";
                    entAnnotation["subject"] = $"cat_review_{MyResultReviewGUID}";
                    entAnnotation["documentbody"] = base64AppPayload;
                    myOperator.getService().Create(entAnnotation);
                }
                catch (Exception ex)
                {
                    if (tracingService != null) tracingService.Trace($"Error creating Annotation; Message : {ex.Message}");
                }

                EntityReference ReviewReference = new EntityReference("cat_review", MyResultReviewGUID);
                myOperator.UploadFileToDataverse(OneApp.ContenuFichier, OneApp.NomPowerApps + ".msapp", "msapp", "cat_msappfile", ReviewReference);

                newDatas = new Dictionary<string, object>
                {
                    { "cat_name", appName },
                    { "cat_requeststatus", OptionReviewNotStarted },
                    { "cat_chc_appcheckerstatus", OptionReviewNotStarted },
                    { "cat_chc_reviewitemstatus", OptionReviewNotStarted },
                    { "cat_cd_typeoriginereview", "Solution" }
                };

                ReviewSolution = new EntityReference("cat_review", MyResultReviewGUID);
                newDatas.Add("cat_review", ReviewSolution);

                MyRequestReviewGUID = myOperator.QueryCreate("cat_reviewrequest", newDatas);

                return true;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in ProcessAppLaunch; Message : {ex.Message}");
                throw ex;
            }
        }

        public static bool LoadSolutionElements(DataverseOperator myOperator, Guid SolutionGuid, SolutionLoader UploadedSolution, ITracingService tracingService = null)
        {
            OptionSetValue OptionCanvasApp = new OptionSetValue(695100000);
            OptionSetValue OptionModelDriven = new OptionSetValue(695100001);
            OptionSetValue OptionCustomPages = new OptionSetValue(695100002);
            OptionSetValue OptionComponentLibrary = new OptionSetValue(695100003);

            OptionSetValue OptionReviewDone = new OptionSetValue(695100002);
            OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);

            if (tracingService != null) tracingService.Trace($"Loading {UploadedSolution.AppOrganisations.Count} of Apps");
            Dictionary<string, object> newDatas;
            Guid MyResultAppGUID;
            try
            {
                foreach (AppContainer OneContainer in UploadedSolution.AppOrganisations)
                {
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lbname", OneContainer.NomContainer.Replace(".msapp", "") }
                    };

                    if (OneContainer.SubApps.Count > 1)
                    {
                        if (OneContainer.SubApps.Where(x => x.TypeApp == "ComponentLibrary").ToList().Count == OneContainer.SubApps.Count)
                        {
                            newDatas.Add("cat_chx_apptype", OptionComponentLibrary);
                        }
                        else
                        {
                            newDatas.Add("cat_chx_apptype", OptionCustomPages);
                        }
                        newDatas.Add("cat_chx_app_status", OptionReviewNotStarted);
                    }
                    else if (OneContainer.SubApps.Count == 1)
                    {
                        if (OneContainer.SubApps[0].TypeApp == "App")
                        {
                            newDatas.Add("cat_chx_apptype", OptionCanvasApp);
                        }
                        else if (OneContainer.SubApps[0].TypeApp == "ComponentLibrary")
                        {
                            newDatas.Add("cat_chx_apptype", OptionComponentLibrary);
                        }
                        else
                        {
                            newDatas.Add("cat_chx_apptype", OptionCustomPages);
                        }
                        newDatas.Add("cat_chx_app_status", OptionReviewNotStarted);
                    }
                    else
                    {
                        newDatas.Add("cat_chx_app_status", OptionReviewDone);
                        newDatas.Add("cat_chx_apptype", OptionModelDriven);
                    }

                    EntityReference AppSolution = new EntityReference("cat_rev_solutionreview", SolutionGuid);
                    newDatas.Add("cat_rev_apps_solutionreview", AppSolution);

                    MyResultAppGUID = myOperator.QueryCreate("cat_rev_apps", newDatas);

                    foreach (PowerApps OneApp in OneContainer.SubApps)
                    {
                        bool Ret = ProcessAppLaunch(myOperator, OneApp, SolutionGuid, MyResultAppGUID, tracingService);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in LoadSolutionElements; Message : {ex.Message}");
                throw ex;
            }
        }

        public static Entity GetEntityValue(DataverseOperator myOperator, Guid reviewGuid, string EntityName = "cat_review", string IdColumnName = "cat_reviewid", string WantedColumns = "cat_name")
        {
            FetchXmlFormatter xmlFetcher;
            List<Entity> results;
            Entity OneRes;
            try
            {
                xmlFetcher = new FetchXmlFormatter(EntityName)
                {
                    MaxRows = 1
                };

                foreach (string OneColumn in WantedColumns.Split(';'))
                {
                    xmlFetcher.AddFieldColumn(OneColumn);
                }

                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter(IdColumnName, "eq", reviewGuid.ToString());
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                if (results.Count() > 0)
                {
                    OneRes = results[0];
                    return OneRes;
                }
                else
                {
                    return new Entity();
                }

            }
            catch (Exception ex)
            {
                return new Entity();
            }

        }

        public static void ProcessAppCheckerResults(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService = null)
        {
            string AppchekerDatas = "";
            if (msApp._appCheckerResultJson == null)
            {
                return;
            }
            else
            {
                foreach (string OneKey in msApp._appCheckerResultJson.ExtensionData.Keys)
                {
                    if (OneKey == "runs")
                    {
                        AppchekerDatas += msApp._appCheckerResultJson.ExtensionData[OneKey];
                    }
                }
            }

            if (tracingService != null) tracingService.Trace($"AppchekerDatas : {AppchekerDatas}");

            Run[] appCheckerResults = System.Text.Json.JsonSerializer.Deserialize<Run[]>(AppchekerDatas);//msApp._entropy.AppCheckerResult);
            Run LastRun = appCheckerResults.Last<Run>();
            List<Entity> results;
            Guid rulesReferenceId;
            Guid resultReviewId;
            Guid MyResultRecordGuid;
            Dictionary<string, object> newDatas;
            FetchXmlFormatter xmlFetcher;

            List<Result> MyRes;

            List<Result> ResLst = LastRun.results.ToList();

            var groupbyresults = ResLst.GroupBy(x => x.ruleId).ToList();

            string PhysicalLocationRegionLength = "", PhysicalLocationRegionSniplet = "", PhysicalLocationRegionOffest = "", LogicalLocationFullQualifiedName = "";
            string LocationPropertiesMember = "", LocationPropertiesModule = "", PhysicalLocationFullyQualifiedName = "", PhysicalLocationRelativeAdress = "";

            foreach (IGrouping<string, Result> OneDicItem in groupbyresults)
            {
                xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_rulesreferences")
                {
                    MaxRows = 1
                };
                xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_ref", "eq", OneDicItem.Key);
                string fetchXMLRulesReferences = xmlFetcher.GenerateFetchXmltString();
                if (tracingService != null) tracingService.Trace($"fetchXML RulesReferences : {fetchXMLRulesReferences}");

                results = myOperator.QuerySelect(fetchXMLRulesReferences);
                if (results.Count() > 0)
                {
                    rulesReferenceId = new Guid(results.First().Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());
                    if (tracingService != null) tracingService.Trace($"Reading existed Rules Reference Id : {rulesReferenceId}");
                }
                else
                {
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_ruleid_ref", OneDicItem.Key }
                    };

                    if (tracingService != null) tracingService.Trace($"Creating new Rules References record; cat_lb_ruleid_ref : {OneDicItem.Key}");
                    rulesReferenceId = myOperator.QueryCreate("cat_rev_appchecker_rulesreferences", newDatas);
                }

                // Reading App Checker Result Review
                xmlFetcher = new FetchXmlFormatter("cat_rev_appcheckerresult_review")
                {
                    MaxRows = 1
                };
                xmlFetcher.AddFieldColumn("cat_rev_appcheckerresult_reviewid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_result", "eq", OneDicItem.Key);
                xmlFetcher.OMyFilter.AddFilter("cat_relappchecker_resultreview_review", "eq", reviewGuid.ToString());
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                if (results.Count() > 0)
                {
                    resultReviewId = new Guid(results.First().Attributes["cat_rev_appcheckerresult_reviewid"].ToString());
                    if (tracingService != null) tracingService.Trace($"Reading existed Rules Review Id : {resultReviewId}");
                }
                else
                {
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_ruleid_result", OneDicItem.Key },
                        { "cat_nb_elements", OneDicItem.ToList().Count() }//Value.nbTotal);
                    };
                    EntityReference ReviewRefMain = new EntityReference("cat_review", reviewGuid);
                    newDatas.Add("cat_relappchecker_resultreview_review", ReviewRefMain);

                    EntityReference ResultRef = new EntityReference("cat_rev_appchecker_rulesreferences", rulesReferenceId);
                    newDatas.Add("cat_rel_appchecker_resultreview_rules", ResultRef);

                    if (tracingService != null) tracingService.Trace($"Creating new Results Review record with RulesRefId : {rulesReferenceId}");
                    resultReviewId = myOperator.QueryCreate("cat_rev_appcheckerresult_review", newDatas);
                }

                if (OneDicItem.Key.StartsWith("acc"))
                {
                    MyRes = OneDicItem.Take(5).ToList();
                }
                else
                {
                    MyRes = OneDicItem.Take(150).ToList();
                }

                foreach (Result OneResult in MyRes)//OneDicItem.Value.CollresObj)
                {
                    foreach (Location OneLocation in OneResult.locations)
                    {
                        if (OneLocation.physicalLocation.address == null)
                        {
                            PhysicalLocationRegionLength = "";
                            PhysicalLocationRegionSniplet = "";
                            PhysicalLocationRegionOffest = "";
                        }
                        else
                        {
                            PhysicalLocationRegionLength = OneLocation.physicalLocation.address.fullyQualifiedName.Length.ToString();
                            PhysicalLocationRegionSniplet = "";
                            PhysicalLocationRegionOffest = "";
                        }
                        LogicalLocationFullQualifiedName = OneLocation.logicalLocations[0].fullyQualifiedName;
                        LocationPropertiesMember = OneLocation.properties.member;
                        LocationPropertiesModule = OneLocation.properties.module;
                        PhysicalLocationFullyQualifiedName = OneLocation.physicalLocation.address.fullyQualifiedName;
                        PhysicalLocationRelativeAdress = OneLocation.physicalLocation.address.relativeAddress.ToString();
                    }

                    // AppChecker Results
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_ruleid", OneResult.ruleId },

                        { "cat_lb_physicallocation_region_charlength", PhysicalLocationRegionLength },
                        { "cat_lb_physicallocation_region_snippet", PhysicalLocationRegionSniplet },
                        { "cat_lb_physicallocation_region_charoffset", PhysicalLocationRegionOffest },

                        { "cat_lb_logicallocation_fullyqualifiedname", LogicalLocationFullQualifiedName },

                        { "cat_lb_messageid", OneResult.message.id },

                        { "cat_lb_location_propertiesmember", LocationPropertiesMember },
                        { "cat_lb_location_propertiesmodule", LocationPropertiesModule },

                        { "cat_nb_ruleindex", OneResult.ruleIndex },

                        { "cat_lb_physicallocation_fullyqualifiedname", PhysicalLocationFullyQualifiedName },
                        { "cat_lb_physicallocation_relativeaddress", PhysicalLocationRelativeAdress }
                    };

                    EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                    newDatas.Add("cat_rel_appchecker_result_review", ReviewRef);

                    EntityReference ResultReviewRef = new EntityReference("cat_rev_appcheckerresult_review", resultReviewId);
                    newDatas.Add("cat_rel_appcheckerresult_resultsrevie", ResultReviewRef);

                    if (tracingService != null) tracingService.Trace($"Creating new AppCheckerResults {PhysicalLocationFullyQualifiedName}");
                    MyResultRecordGuid = myOperator.QueryCreate("cat_rev_appchecker_results", newDatas);

                    if (OneResult.message.arguments != null)
                    {
                        foreach (string OneArgument in OneResult.message.arguments)//supposed to be OneResult.message.aguments.count()>0
                        {
                            newDatas = new Dictionary<string, object>
                            {
                                { "cat_lb_argument", OneArgument }
                            };

                            ReviewRef = new EntityReference("cat_review", reviewGuid);
                            newDatas.Add("cat_rel_appcheckerargument_review", ReviewRef);

                            EntityReference ResultRef = new EntityReference("cat_rev_appchecker_results", MyResultRecordGuid);
                            newDatas.Add("cat_rel_appcheckerarguments_results", ResultRef);

                            if (tracingService != null) tracingService.Trace($"Creating new AppCheckerMessagesArguments");
                            resultReviewId = myOperator.QueryCreate("cat_rev_appcheckermessagesarguments", newDatas);
                        }
                    }
                }
            }

            if (LastRun.tool.driver.rules != null)
            {
                foreach (Rule OneRule in LastRun.tool.driver.rules)
                {
                    //cat_lb_ruleid_ref
                    xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_rulesreferences")
                    {
                        MaxRows = 1
                    };
                    xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
                    xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                    xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_ref", "eq", OneRule.id);
                    results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_ruleid_ref", OneRule.id },
                        { "cat_lb_componenttype", OneRule.properties.componentType },
                        { "cat_lb_level_ref", OneRule.properties.level },
                        { "cat_lb_whyfix", OneRule.properties.whyFix },
                        { "cat_lb_messageissue_ref", "" },//Missing!!!!
                        { "cat_lb_primarycategory", OneRule.properties.primaryCategory }
                    };

                    if (results.Count() > 0)
                    {
                        rulesReferenceId = new Guid(results.First().Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());
                        if (tracingService != null) tracingService.Trace($"Updating new Rules References; Id - {rulesReferenceId}");
                        myOperator.QueryUpdate("cat_rev_appchecker_rulesreferences", newDatas, results.First());
                    }
                    else
                    {
                        if (tracingService != null) tracingService.Trace($"Creating new Rules References");
                        rulesReferenceId = myOperator.QueryCreate("cat_rev_appchecker_rulesreferences", newDatas);
                    }

                    if (OneRule.properties.howToFix != null)
                    {
                        foreach (string HowtoFix in OneRule.properties.howToFix)
                        {
                            if (HowtoFix != null)
                            {
                                xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_howtofix")
                                {
                                    MaxRows = 1
                                };
                                xmlFetcher.AddFieldColumn("cat_rev_appchecker_howtofixid");
                                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                                xmlFetcher.OMyFilter.AddFilter("cat_lbhowtofix", "eq", HowtoFix.Replace("'", "\\'"));
                                xmlFetcher.OMyFilter.AddFilter("cat_rel_appcheckerhowtofix_rulesrefer", "eq", rulesReferenceId.ToString());

                                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                                if (results.Count == 0 || results == null)
                                {
                                    newDatas = new Dictionary<string, object>
                                    {
                                        { "cat_lbhowtofix", HowtoFix }
                                    };

                                    EntityReference rulesreferencesRef = new EntityReference("cat_rev_appchecker_rulesreferences", rulesReferenceId);

                                    newDatas.Add("cat_rel_appcheckerhowtofix_rulesrefer", rulesreferencesRef);
                                    if (tracingService != null) tracingService.Trace($"Creating new App Checker How to Fix");
                                    try
                                    {
                                        rulesReferenceId = myOperator.QueryCreate("cat_rev_appchecker_howtofix", newDatas);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (tracingService != null) tracingService.Trace($"Error while creating cat_rev_appchecker_howtofix. Error {ex.Message}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ProcessAppSettings(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid)
        {
            if (msApp._properties == null) return;

            string ReviewName;
            EntityReference reviewGuidRef;
            Entity MyEntity = GetEntityValue(myOperator, reviewGuid);
            ReviewName = MyEntity.Attributes["cat_name"].ToString();
            Dictionary<string, object> newDatas;
            if (msApp._properties.ExtensionData != null && msApp._properties.ExtensionData.ContainsKey("AppPreviewFlagsMap"))
            {
                //System.Text.Json.JsonSerializer stt =new System.Text.Json.JsonSerializer() ;
                System.Text.Json.JsonElement jss = msApp._properties.ExtensionData["AppPreviewFlagsMap"];
                string SettingsStr = jss.ToString();
                char[] MainSep = { '{', '}' };

                if (SettingsStr.Contains("{"))
                {

                    string strElms = SettingsStr.Split(MainSep)[1];
                    List<string> ListElms = strElms.Split(',').ToList();

                    string ElementName, ElementValue;

                    foreach (string OneElmt in ListElms)
                    {
                        if (OneElmt.Contains(":"))
                        {
                            ElementName = OneElmt.Replace("\"", "").Split(':')[0];
                            ElementValue = OneElmt.Replace("\"", "").Split(':')[1];
                            if (ElementValue == "true")
                            {
                                newDatas = new Dictionary<string, object>();
                                newDatas.Add("cat_lb_parametername", ElementName);
                                newDatas.Add("cat_lb_parametervalue", "true");
                                newDatas.Add("cat_lb_reviewname", ReviewName);
                                reviewGuidRef = new EntityReference("cat_review", reviewGuid);
                                newDatas.Add("cat_rel_appsettings_review", reviewGuidRef);

                                myOperator.QueryCreate("cat_rev_appsettings", newDatas);
                            }
                        }
                    }
                }
            }
            else if (msApp._properties.AppPreviewFlagsKey != null)
            {
                foreach (string OneProperty in msApp._properties.AppPreviewFlagsKey)
                {
                    newDatas = new Dictionary<string, object>();
                    newDatas.Add("cat_lb_parametername", OneProperty);
                    newDatas.Add("cat_lb_parametervalue", "true");
                    newDatas.Add("cat_lb_reviewname", ReviewName);

                    reviewGuidRef = new EntityReference("cat_review", reviewGuid);
                    newDatas.Add("cat_rel_appsettings_review", reviewGuidRef);

                    myOperator.QueryCreate("cat_rev_appsettings", newDatas);
                }
            }

            if (msApp._properties.DocumentLayoutScaleToFit != null)
            {
                newDatas = new Dictionary<string, object>();
                newDatas.Add("cat_lb_parametername", "DocumentLayoutScaleToFit");
                newDatas.Add("cat_lb_parametervalue", msApp._properties.DocumentLayoutScaleToFit.ToString());
                newDatas.Add("cat_lb_reviewname", ReviewName);
                reviewGuidRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_rel_appsettings_review", reviewGuidRef);
                myOperator.QueryCreate("cat_rev_appsettings", newDatas);
            }


            if (msApp._properties.DefaultConnectedDataSourceMaxGetRowsCount != null)
            {
                newDatas = new Dictionary<string, object>();
                newDatas.Add("cat_lb_parametername", "DefaultConnectedDataSourceMaxGetRowsCount");
                newDatas.Add("cat_lb_parametervalue", msApp._properties.DefaultConnectedDataSourceMaxGetRowsCount.ToString());
                newDatas.Add("cat_lb_reviewname", ReviewName);

                reviewGuidRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_rel_appsettings_review", reviewGuidRef);
                myOperator.QueryCreate("cat_rev_appsettings", newDatas);
            }

            if (msApp._properties.DocumentLayoutMaintainAspectRatio != null)
            {
                newDatas = new Dictionary<string, object>();
                newDatas.Add("cat_lb_parametername", "DocumentLayoutMaintainAspectRatio");
                newDatas.Add("cat_lb_parametervalue", msApp._properties.DocumentLayoutMaintainAspectRatio.ToString());
                newDatas.Add("cat_lb_reviewname", ReviewName);

                reviewGuidRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_rel_appsettings_review", reviewGuidRef);
                myOperator.QueryCreate("cat_rev_appsettings", newDatas);
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }

        public static Guid GetReviewID(DataverseOperator myOperator, string reviewName, string EntityName = "cat_review", string ResearchColumnName = "cat_name", string ColumnId = "cat_reviewid", string WantedColumns = "cat_reviewid;cat_name")
        {
            List<Entity> results;
            Guid reviewGuid;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter(EntityName);
            xmlFetcher.MaxRows = 1;
            foreach (string OneColumn in WantedColumns.Split(';'))
            {
                xmlFetcher.AddFieldColumn(OneColumn);
            }

            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter(ResearchColumnName, "eq", reviewName);
            results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            if (results.Any())
            {
                reviewGuid = new Guid(results.First().Attributes[ColumnId].ToString());
            }
            else
            {
                reviewGuid = new Guid();
            }

            return reviewGuid;
        }

        public static Guid GetReviewIDAll(DataverseOperator myOperator)
        {
            List<Entity> results;
            Guid reviewGuid;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_review");
            xmlFetcher.MaxRows = 1;
            xmlFetcher.AddFieldColumn("cat_reviewid");
            xmlFetcher.AddFieldColumn("cat_name");
            results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            if (results.Any())
            {
                reviewGuid = new Guid(results.First().Attributes["cat_reviewid"].ToString());
            }
            else
            {
                reviewGuid = new Guid();
            }

            return reviewGuid;
        }

        public static bool CheckReviewAllStatus(DataverseOperator myOperator, Guid reviewGuid)
        {
            try
            {
                List<Entity> results;
                OptionSetValue OptionReviewDone = new OptionSetValue(695100002);

                FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_review");
                xmlFetcher.MaxRows = 1;
                xmlFetcher.AddFieldColumn("cat_chc_statusimportappcheckerresults");
                xmlFetcher.AddFieldColumn("cat_chc_statusimportdatasources");
                xmlFetcher.AddFieldColumn("cat_chc_statusimportappsettingsflags");
                xmlFetcher.AddFieldColumn("cat_chc_statusimport");
                xmlFetcher.AddFieldColumn("cat_chc_statusimportfiles");
                xmlFetcher.AddFieldColumn("cat_chc_statusimportreviewitems");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_reviewid", "eq", reviewGuid.ToString());
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                if (results.Any())
                {
                    OptionSetValue AppcheckerOptionSet = (OptionSetValue)results.First().Attributes["cat_chc_statusimportappcheckerresults"];
                    OptionSetValue datasourcesOptionSet = (OptionSetValue)results.First().Attributes["cat_chc_statusimportdatasources"];
                    OptionSetValue appsettingsOptionSet = (OptionSetValue)results.First().Attributes["cat_chc_statusimportappsettingsflags"];
                    OptionSetValue screensOptionSet = (OptionSetValue)results.First().Attributes["cat_chc_statusimport"];
                    OptionSetValue FilesOptionSet = (OptionSetValue)results.First().Attributes["cat_chc_statusimportfiles"];
                    OptionSetValue ReviewItemssOptionSet = (OptionSetValue)results.First().Attributes["cat_chc_statusimportreviewitems"];

                    if (FilesOptionSet.Value == OptionReviewDone.Value &&
                        ReviewItemssOptionSet.Value == OptionReviewDone.Value &&
                        screensOptionSet.Value == OptionReviewDone.Value &&
                        appsettingsOptionSet.Value == OptionReviewDone.Value &&
                        datasourcesOptionSet.Value == OptionReviewDone.Value &&
                        AppcheckerOptionSet.Value == OptionReviewDone.Value)
                    {
                        DataAccessLogic.UpdateReviewStatus(myOperator, reviewGuid, OptionReviewDone, "cat_chc_statutimportglobal");
                    }

                    return true;

                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Read Active Patterns and create 'Review Items' for the Review.
        /// </summary>
        /// <param name="myOperator">Data verse operator</param>
        /// <param name="reviewGuid">Review Id</param>
        public static void ProcessReviewItemsImport(DataverseOperator myOperator, Guid reviewGuid, List<Entity> existingPatterns = null)
        {
            Random MyRand = new Random();
            Dictionary<string, object> newDatas;
            List<Entity> collPatterns = null;

            if (existingPatterns != null)
            {
                collPatterns = existingPatterns;
            }
            else
            {
                // Fetch available Patterns
                FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_patternid");
                xmlFetcher.AddFieldColumn("cat_name");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("statecode", "eq", "0");
                collPatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            }

            foreach (Entity patterns in collPatterns)
            {
                newDatas = new Dictionary<string, object>
                {
                    { "cat_review", new EntityReference("cat_review", reviewGuid) },
                    { "cat_pattern", new EntityReference("cat_pattern", new Guid(patterns.Attributes["cat_patternid"].ToString())) },
                    { "cat_reviewitemstatus", new OptionSetValue(695100001) }
                };

                myOperator.QueryCreate("cat_reviewitem", newDatas);
            }
        }

        public static List<string> GetListSettingMandatory()
        {
            List<string> retList = new List<string>
            {
                "projectionmapping",
                "delayloadscreens",
                "reliableconcurrent",
                "componentauthoring",
                "keeprecentscreensloaded",
                "formuladataprefetch",
                "enableappembeddingux",
                "enhanceddelegation",
                "usenonblockingonstartrule"
            };

            return retList;
        }

        /// <summary>
        /// Get Active Patterns from Dataverse 'Patterns' table
        /// </summary>
        /// <param name="myOperator">Dataverse Operator</param>
        /// <returns>Active Pattern Collection</returns>
        public static List<Entity> GetActivePatterns(DataverseOperator myOperator)
        {
            // Fetch available Patterns
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_pattern");
            xmlFetcher.AddFieldColumn("cat_patternid");
            xmlFetcher.AddFieldColumn("cat_patterntype");
            xmlFetcher.AddFieldColumn("cat_name");
            xmlFetcher.AddFieldColumn("cat_description");
            xmlFetcher.AddFieldColumn("cat_severity");
            xmlFetcher.AddFieldColumn("cat_value");

            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter("statecode", "eq", "0");
            List<Entity> collPatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

            return collPatterns;
        }

        /// <summary>
        /// Fetch Patterns of type 'Automatic' and match with Static Patterns and Create 'Review Items'
        /// Update the Status of 'Review Items'
        /// </summary>
        /// <param name="dataverseService">Dataverse Service</param>
        /// <param name="reviewGuid">Review Id</param>
        /// <param name="existingPatterns">Cached Patterns</param>
        public static void CreateandAutoPassReviewItems(IOrganizationService dataverseService, Guid reviewGuid, List<Entity> collPatterns, ITracingService tracingService = null)
        {
            OptionSetValue PatternManual = new OptionSetValue(695100000);
            OptionSetValue PatternAutomatic = new OptionSetValue(695100001);
            Entity reviewItemFounded;
            OptionSetValue reviewItemStatus;
            List<Entity> automaticPatterns = null;

            // Filter Patterns by 'Pattern Type = Automatic'
            automaticPatterns = collPatterns.Where(x => ((OptionSetValue)x.Attributes["cat_patterntype"]).Value == PatternAutomatic.Value).ToList();

            if (tracingService != null) tracingService.Trace($"Automatic Patterns Count {automaticPatterns.Count}");

            List<Entity> reviewItems = new List<Entity>();
            foreach (Entity pattern in collPatterns)
            {
                Entity newReviewItem = new Entity("cat_reviewitem");
                newReviewItem["cat_name"] = pattern["cat_name"];
                newReviewItem["cat_review"] = new EntityReference("cat_review", reviewGuid);
                newReviewItem["cat_pattern"] = new EntityReference("cat_pattern", new Guid(pattern.Attributes["cat_patternid"].ToString()));
                newReviewItem["cat_reviewitemstatus"] = new OptionSetValue(695100001);
                reviewItems.Add(newReviewItem);
            }
            if (tracingService != null) tracingService.Trace($"Stubbed {reviewItems.Count} Review Items");

            // Get 'Auto Fail' pattern collection (Static)
            List<AutoFailPattern> ListPatternsCode = AutoFailPattern.GenerateListAutoFails();
            AutoFailPattern OnePatternFail;
            bool WaitForOne = true;

            foreach (Entity automaticPattern in automaticPatterns)
            {
                if (tracingService != null) tracingService.Trace($"Matching Automatic Pattern {automaticPattern["cat_name"]}");

                // Match if current Pattern is part of Static Auto Fail Pattern list
                OnePatternFail = ListPatternsCode.Find(x => x.lbPatternName == automaticPattern.Attributes["cat_name"].ToString());

                if (OnePatternFail != null)
                {
                    WaitForOne = OnePatternFail.isDirectError;
                }

                // Fetch the 'Review Item' associated with matched Pattern
                reviewItemFounded = reviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Id == new Guid(automaticPattern.Attributes["cat_patternid"].ToString()));
                if (reviewItemFounded != null)
                {
                    if (tracingService != null) tracingService.Trace($"Review Item Founded with matched pattern");
                    string message = string.Empty;
                    if (WaitForOne)
                    {
                        // Set Status as Pass
                        reviewItemStatus = new OptionSetValue(695100002);
                    }
                    else
                    {
                        // Set Status as Failed
                        reviewItemStatus = new OptionSetValue(695100003);
                        message = OnePatternFail.MessageIfNotFound;
                    }

                    reviewItemFounded["cat_reviewitemstatus"] = reviewItemStatus;
                    reviewItemFounded["cat_comment"] = message;

                    // Create 'Review Item'
                    if (tracingService != null) tracingService.Trace($"Creating new 'Review Item' {reviewItemFounded["cat_name"]}");
                    dataverseService.Create(reviewItemFounded);
                }
                else
                {
                    if (tracingService != null) tracingService.Trace($"Review Item not founded with matched pattern {automaticPattern["cat_name"]}");
                }
            }
        }

        /// <summary>
        /// Fetch Patterns of type 'Automatic' and match with Static Patterns
        /// Update the Status of 'Review Items'
        /// </summary>
        /// <param name="myOperator">Dataverse Operator</param>
        /// <param name="reviewGuid">Review Id</param>
        /// <param name="existingPatterns">Cached Patterns</param>
        public static void ProcessAutoPassAll(DataverseOperator myOperator, Guid reviewGuid, List<Entity> existingPatterns = null)
        {
            OptionSetValue PatternManual = new OptionSetValue(695100000);
            OptionSetValue PatternAutomatic = new OptionSetValue(695100001);
            Entity reviewItemFounded;
            Dictionary<string, object> newDatas;
            OptionSetValue TheStatus;
            List<Entity> resultsPatterns = null;
            List<Entity> automaticPatterns = null;
            FetchXmlFormatter xmlFetcher = null;

            if (existingPatterns != null)
            {
                resultsPatterns = existingPatterns;
            }
            else
            {
                xmlFetcher = new FetchXmlFormatter("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_patternid");
                xmlFetcher.AddFieldColumn("cat_patterntype");
                xmlFetcher.AddFieldColumn("cat_name");
                resultsPatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            }

            automaticPatterns = resultsPatterns.Where(x => ((OptionSetValue)x.Attributes["cat_patterntype"]).Value == PatternAutomatic.Value).ToList();

            // Read 'Review Items'
            xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
            xmlFetcher.AddFieldColumn("cat_reviewitemid");
            xmlFetcher.AddFieldColumn("cat_pattern");
            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
            List<Entity> resultsReviewItems = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

            // Get 'Auto Fail' pattern collection (Static)
            List<AutoFailPattern> ListPatternsCode = AutoFailPattern.GenerateListAutoFails();
            AutoFailPattern OnePatternFail;
            bool WaitForOne = true;

            foreach (Entity automaticPattern in automaticPatterns)
            {
                // Match if current Pattern is part of Static Auto Fail Pattern list
                OnePatternFail = ListPatternsCode.Find(x => x.lbPatternName == automaticPattern.Attributes["cat_name"].ToString());

                if (OnePatternFail != null)
                {
                    WaitForOne = OnePatternFail.isDirectError;
                }

                // Fetch the 'Review Item' associated with matched Pattern
                reviewItemFounded = resultsReviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Id == new Guid(automaticPattern.Attributes["cat_patternid"].ToString()));
                if (reviewItemFounded != null)
                {
                    string TheComment = "";
                    if (WaitForOne)
                    {
                        // Set Status as Pass
                        TheStatus = new OptionSetValue(695100002);
                    }
                    else
                    {
                        // Set Status as Failed
                        TheStatus = new OptionSetValue(695100003);
                        TheComment = OnePatternFail.MessageIfNotFound;
                    }

                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_reviewitemstatus", TheStatus },
                        { "cat_comment", TheComment }
                    };

                    // Set the Status of 'Review Item'
                    myOperator.QueryUpdate("cat_reviewitem", newDatas, reviewItemFounded);
                }
            }
        }

        public static void ProcessCodesAutoFail(DataverseOperator myOperator, Guid reviewGuid)
        {
            string OneListErrors;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_rev_screens");
            xmlFetcher.AddFieldColumn("cat_rev_screensid");
            xmlFetcher.AddFieldColumn("cat_txt_listfails");
            xmlFetcher.AddFieldColumn("cat_rel_screen_review");
            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter("cat_rel_screen_review", "eq", reviewGuid.ToString());
            List<Entity> resultscreens = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

            xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
            xmlFetcher.AddFieldColumn("cat_reviewitemid");
            xmlFetcher.AddFieldColumn("cat_comment");
            xmlFetcher.AddFieldColumn("cat_pattern");
            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
            List<Entity> resultsReviewItems = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

            List<AutoFailElement> FullErrorList = new List<AutoFailElement>();
            List<AutoFailElement> curElmt;

            OptionSetValue TheStatus;
            Dictionary<string, object> newDatas;

            try
            {
                foreach (Entity oneRes in resultscreens)
                {

                    if (oneRes.Contains("cat_txt_listfails"))
                    {
                        OneListErrors = oneRes.Attributes["cat_txt_listfails"].ToString();

                        if (OneListErrors != null)
                        {
                            curElmt = AutoFailElement.LoadListAutoFailsElements(OneListErrors);
                            if (curElmt.Count > 0)
                            {
                                FullErrorList.AddRange(curElmt);
                            }
                        }
                    }
                }

                Entity reviewItemFounded;
                List<AutoFailPattern> PatternsToRemove = AutoFailPattern.GenerateListAutoFails();

                var groupbyresults = FullErrorList.GroupBy(x => x.lbPatternName).ToList();

                IGrouping<string, AutoFailElement> AppRes = groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy0");
                IGrouping<string, AutoFailElement> LandingScreenRes = groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy1");
                string[] ListElmts = { "|||||" };
                string resultsLoadingStrategy = "";
                List<DataLoadingElement> LesCollects = new List<DataLoadingElement>();
                List<string> TheCollFounded = new List<string>();
                if (AppRes != null)
                {
                    foreach (AutoFailElement FailedItem in AppRes)
                    {
                        foreach (string OnElmtInOnstart in FailedItem.lbComment.Split(ListElmts, StringSplitOptions.None))
                        {
                            LesCollects.Add(new DataLoadingElement(OnElmtInOnstart));
                        }
                    }
                    if (LandingScreenRes != null)
                    {
                        foreach (AutoFailElement FoundedItem in LandingScreenRes)
                        {
                            TheCollFounded.AddRange(FoundedItem.lbComment.Split(ListElmts, StringSplitOptions.None).ToList());
                        }
                    }

                    //List<DataLoadingElement> ListFounded = LesCollects.Where(x => TheCollFounded.Contains(x.lbCollectionName) || x.lListSubFunctions.Intersect(TheCollFounded).Any());
                    foreach (DataLoadingElement OneElet in LesCollects)
                    {
                        if (!(TheCollFounded.Contains(OneElet.lbCollectionName) || OneElet.lListSubFunctions.Intersect(TheCollFounded).Any()))
                        {
                            if (resultsLoadingStrategy == "")
                            {
                                resultsLoadingStrategy += OneElet.lbCollectionName;
                            }
                            else
                            {
                                resultsLoadingStrategy += ", " + OneElet.lbCollectionName;
                            }

                        }
                    }

                    if (resultsLoadingStrategy != "")
                    {

                        reviewItemFounded = resultsReviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Name == "app-DataLoadingStrategy");

                        if (reviewItemFounded != null)
                        {
                            TheStatus = new OptionSetValue(695100003);
                            newDatas = new Dictionary<string, object>
                            {
                                { "cat_reviewitemstatus", TheStatus },
                                { "cat_comment", "Code review tool : The following Collections have been loaded in the OnStart event but are not used in the home page : " + resultsLoadingStrategy + ". Consider loading these collections in subsequent screens to speed up initial app loading" }
                            };

                            myOperator.QueryUpdate("cat_reviewitem", newDatas, reviewItemFounded);
                        }
                        try
                        {
                            PatternsToRemove.Remove(PatternsToRemove.Find(x => x.lbPatternName == "app-DataLoadingStrategy0"));
                            PatternsToRemove.Remove(PatternsToRemove.Find(x => x.lbPatternName == "app-DataLoadingStrategy1"));

                            groupbyresults.Remove(groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy0"));
                            groupbyresults.Remove(groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy1"));
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                AutoFailPattern PatternEnCours;
                foreach (IGrouping<string, AutoFailElement> OneFail in groupbyresults)
                {

                    reviewItemFounded = resultsReviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Name == OneFail.Key);

                    PatternEnCours = PatternsToRemove.Find(x => x.lbPatternName == OneFail.Key);

                    if (PatternEnCours.isDirectError && reviewItemFounded != null)
                    {
                        if (PatternEnCours != null)
                        {
                            PatternsToRemove.Remove(PatternEnCours);
                        }

                        TheStatus = new OptionSetValue(695100003);
                        newDatas = new Dictionary<string, object>();

                        newDatas.Add("cat_reviewitemstatus", TheStatus);
                        newDatas.Add("cat_comment", OneFail.First().lbComment);

                        myOperator.QueryUpdate("cat_reviewitem", newDatas, reviewItemFounded);

                        foreach (AutoFailElement FailedItem in OneFail)
                        {
                            newDatas = new Dictionary<string, object>
                            {
                                { "cat_lb_code", FailedItem.lbCode },
                                { "cat_lb_controlname", FailedItem.lbControlName },
                                { "cat_lb_propertyname", FailedItem.lbPropertyName },
                                { "cat_lb_screenname", FailedItem.lbScreenName }
                            };

                            EntityReference PropertyRef = new EntityReference("cat_rev_propertiescode", new Guid(FailedItem.lbPropertyGuid));
                            newDatas.Add("crfd9_rel_codeparts_properties", PropertyRef);

                            EntityReference ReviewItemRef = new EntityReference("cat_reviewitem", reviewItemFounded.Id);
                            newDatas.Add("cat_fk_codepart_reviewitem", ReviewItemRef);

                            myOperator.QueryCreate("cat_rev_codeparts", newDatas);

                        }

                    }

                }

                IGrouping<string, AutoFailElement> NotFounded;
                foreach (AutoFailPattern OnePat in PatternsToRemove)
                {
                    if (!OnePat.isDirectError)
                    {
                        reviewItemFounded = resultsReviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Name == OnePat.lbPatternName);
                        NotFounded = groupbyresults.Find(y => y.Key == OnePat.lbPatternName);

                        TheStatus = new OptionSetValue(695100003);
                        newDatas = new Dictionary<string, object>();

                        newDatas.Add("cat_reviewitemstatus", TheStatus);
                        newDatas.Add("cat_comment", OnePat.MessageIfNotFound);

                        myOperator.QueryUpdate("cat_reviewitem", newDatas, reviewItemFounded);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void ProcessCodesAutoFailOneScreen(DataverseOperator myOperator, Guid reviewGuid, Entity resultcreens, ITracingService tracingService, Entity resultcreensOneOrZero = null)
        {

            int levelMyscreen = (int)resultcreens.Attributes["cat_nb_publishorderindexscreen"];
            if (resultcreensOneOrZero != null)
            {
                int levelOtherscreen = (int)resultcreens.Attributes["cat_nb_publishorderindexscreen"];
            }


            string OneListErrors;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
            xmlFetcher.AddFieldColumn("cat_reviewitemid");
            xmlFetcher.AddFieldColumn("cat_comment");
            xmlFetcher.AddFieldColumn("cat_pattern");
            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
            xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
            List<Entity> resultsReviewItems = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

            List<AutoFailElement> FullErrorList = new List<AutoFailElement>();
            List<AutoFailElement> curElmt;

            OptionSetValue TheStatus;
            Dictionary<string, object> newDatas;

            try
            {
                if (resultcreens.Attributes.ContainsKey("cat_txt_listfails"))
                {
                    OneListErrors = resultcreens.Attributes["cat_txt_listfails"].ToString();

                    if (OneListErrors != null)
                    {
                        curElmt = AutoFailElement.LoadListAutoFailsElements(OneListErrors);
                        if (curElmt.Count > 0)
                        {
                            FullErrorList.AddRange(curElmt);
                        }
                    }
                }


                Entity reviewItemFounded;
                List<AutoFailPattern> PatternsToRemove = AutoFailPattern.GenerateListAutoFails();

                var groupbyresults = FullErrorList.GroupBy(x => x.lbPatternName).ToList();
                IGrouping<string, AutoFailElement> AppRes, LandingScreenRes;

                try
                {
                    if ((levelMyscreen == 0 || levelMyscreen == 1) && resultcreensOneOrZero != null)
                    {
                        if (levelMyscreen == 0)
                        {
                            AppRes = groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy0");
                            LandingScreenRes = AutoFailElement.LoadListAutoFailsElements(resultcreensOneOrZero.Attributes["cat_txt_listfails"].ToString()).GroupBy(x => x.lbPatternName).ToList().Find(x => x.Key == "app-DataLoadingStrategy1");
                        }
                        else
                        {
                            LandingScreenRes = groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy1");
                            AppRes = AutoFailElement.LoadListAutoFailsElements(resultcreensOneOrZero.Attributes["cat_txt_listfails"].ToString()).GroupBy(x => x.lbPatternName).ToList().Find(x => x.Key == "app-DataLoadingStrategy0");
                        }

                        string[] ListElmts = { "|||||" };
                        string resultsLoadingStrategy = "";
                        List<DataLoadingElement> LesCollects = new List<DataLoadingElement>();
                        List<string> TheCollFounded = new List<string>();
                        if (AppRes != null)
                        {
                            foreach (AutoFailElement FailedItem in AppRes)
                            {
                                foreach (string OnElmtInOnstart in FailedItem.lbComment.Split(ListElmts, StringSplitOptions.None))
                                {
                                    LesCollects.Add(new DataLoadingElement(OnElmtInOnstart));
                                }
                            }
                            if (LandingScreenRes != null)
                            {
                                foreach (AutoFailElement FoundedItem in LandingScreenRes)
                                {
                                    TheCollFounded.AddRange(FoundedItem.lbComment.Split(ListElmts, StringSplitOptions.None).ToList());
                                }
                            }

                            foreach (DataLoadingElement OneElet in LesCollects)
                            {
                                if (!(TheCollFounded.Contains(OneElet.lbCollectionName) || OneElet.lListSubFunctions.Intersect(TheCollFounded).Any()
                                    || TheCollFounded.Where(x => ((" " + x + " ").Replace("'", "").Replace(")", " ").Replace(",", " ").Replace("=", " ").Replace(">", " ").Replace("<", " ").Replace("\"", "").Replace("\r", " ").Replace("\t", " ").Replace("\n", " ") + " ").Contains(" " + OneElet.lbCollectionName.Replace("'", "").Replace("\"", "") + " ")
                                        ).ToList().Count > 0
                                    )
                                )
                                {
                                    if (resultsLoadingStrategy == "")
                                    {
                                        resultsLoadingStrategy += OneElet.lbCollectionName;
                                    }
                                    else
                                    {
                                        resultsLoadingStrategy += ", " + OneElet.lbCollectionName;
                                    }

                                }
                            }

                            IGrouping<string, AutoFailElement> NavigateLoadingFail;
                            NavigateLoadingFail = groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy");
                            string NavigateLoading = "";
                            if (NavigateLoadingFail != null)
                            {
                                NavigateLoading = NavigateLoadingFail.First().lbComment;
                            }

                            if (resultsLoadingStrategy != "" || NavigateLoading != "")
                            {

                                reviewItemFounded = resultsReviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Name == "app-DataLoadingStrategy");
                                string CommentFinal = "";

                                if (resultsLoadingStrategy != "")
                                {
                                    CommentFinal = "Code review tool : The following Collections have been loaded in the OnStart event but are not used in the home page : " + resultsLoadingStrategy + ". Consider loading these collections in subsequent screens to speed up initial app loading";
                                }
                                if (NavigateLoading != "")
                                {
                                    CommentFinal += "<br/>" + NavigateLoading;
                                }

                                if (reviewItemFounded != null)
                                {
                                    TheStatus = new OptionSetValue(695100003);
                                    newDatas = new Dictionary<string, object>
                                    {
                                        { "cat_reviewitemstatus", TheStatus },
                                        { "cat_comment", CommentFinal }
                                    };

                                    myOperator.QueryUpdate("cat_reviewitem", newDatas, reviewItemFounded);

                                    if (resultsLoadingStrategy != "" && NavigateLoadingFail != null)
                                    {
                                        newDatas = new Dictionary<string, object>
                                        {
                                            { "cat_lb_code", NavigateLoadingFail.First().lbCode },
                                            { "cat_lb_controlname", NavigateLoadingFail.First().lbControlName },
                                            { "cat_lb_propertyname", NavigateLoadingFail.First().lbPropertyName },
                                            { "cat_lb_screenname", NavigateLoadingFail.First().lbScreenName }
                                        };

                                        EntityReference PropertyRef = new EntityReference("cat_rev_propertiescode", new Guid(NavigateLoadingFail.First().lbPropertyGuid));
                                        newDatas.Add("crfd9_rel_codeparts_properties", PropertyRef);

                                        EntityReference ReviewItemRef = new EntityReference("cat_reviewitem", reviewItemFounded.Id);
                                        newDatas.Add("cat_fk_codepart_reviewitem", ReviewItemRef);

                                        myOperator.QueryCreate("cat_rev_codeparts", newDatas);
                                    }
                                }

                                try
                                {
                                    PatternsToRemove.Remove(PatternsToRemove.Find(x => x.lbPatternName == "app-DataLoadingStrategy0"));
                                    PatternsToRemove.Remove(PatternsToRemove.Find(x => x.lbPatternName == "app-DataLoadingStrategy1"));
                                    PatternsToRemove.Remove(PatternsToRemove.Find(x => x.lbPatternName == "app-DataLoadingStrategy"));

                                    groupbyresults.Remove(groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy0"));
                                    groupbyresults.Remove(groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy1"));
                                    groupbyresults.Remove(groupbyresults.Find(x => x.Key == "app-DataLoadingStrategy"));
                                }
                                catch (Exception ex)
                                {

                                }

                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    tracingService.Trace("Error during Dataloading strategy managment : " + ex.Message);
                }

                AutoFailPattern PatternEnCours;
                foreach (IGrouping<string, AutoFailElement> OneFail in groupbyresults)
                {

                    reviewItemFounded = resultsReviewItems.Find(x => (x.Attributes["cat_pattern"] as EntityReference).Name == OneFail.Key);

                    PatternEnCours = PatternsToRemove.Find(x => x.lbPatternName == OneFail.Key);
                    if (reviewItemFounded != null)
                    {
                        string TheComment;
                        if (PatternEnCours.isDirectError)
                        {
                            TheComment = OneFail.First().lbComment;
                            TheStatus = new OptionSetValue(695100003);
                        }
                        else
                        {
                            TheComment = "";// PatternEnCours.MessageIfNotFound;
                            TheStatus = new OptionSetValue(695100002);
                        }

                        newDatas = new Dictionary<string, object>
                        {
                            { "cat_reviewitemstatus", TheStatus },
                            { "cat_comment", TheComment }
                        };

                        myOperator.QueryUpdate("cat_reviewitem", newDatas, reviewItemFounded);

                        foreach (AutoFailElement FailedItem in OneFail)
                        {
                            newDatas = new Dictionary<string, object>
                            {
                                { "cat_lb_code", FailedItem.lbCode },
                                { "cat_lb_controlname", FailedItem.lbControlName },
                                { "cat_lb_propertyname", FailedItem.lbPropertyName },
                                { "cat_lb_screenname", FailedItem.lbScreenName }
                            };

                            EntityReference PropertyRef = new EntityReference("cat_rev_propertiescode", new Guid(FailedItem.lbPropertyGuid));
                            newDatas.Add("crfd9_rel_codeparts_properties", PropertyRef);

                            EntityReference ReviewItemRef = new EntityReference("cat_reviewitem", reviewItemFounded.Id);
                            newDatas.Add("cat_fk_codepart_reviewitem", ReviewItemRef);

                            myOperator.QueryCreate("cat_rev_codeparts", newDatas);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// Fetch all the Review under 'Solution Request'
        /// 
        public static bool PropagateStatusUntilSolution(DataverseOperator myOperator, Entity entReview, ITracingService tracingService = null)
        {
            if (tracingService != null) tracingService.Trace("Inside PropagateStatusUntilSolution");
            OptionSetValue OptionReviewNotStarted = new OptionSetValue(695100000);
            OptionSetValue OptionReviewInProgress = new OptionSetValue(695100001);
            OptionSetValue OptionReviewCompleted = new OptionSetValue(695100002);
            OptionSetValue OptionReviewError = new OptionSetValue(341200000);
            OptionSetValue CurrentStatus = OptionReviewCompleted;


            OptionSetValue OptionModelDriven = new OptionSetValue(695100001);

            try
            {
                //cat_score  
                Dictionary<string, object> newDatas;
                FetchXmlFormatter xmlFetcher;

                if (tracingService != null) tracingService.Trace("Fetching Rev_Apps record");
                Entity entRevApp = GetEntityFromARelatedOne(myOperator.getService(), entReview, "cat_rev_reviews_apps", "cat_rev_apps", tracingService);

                xmlFetcher = new FetchXmlFormatter("cat_review");
                xmlFetcher.AddFieldColumn("cat_chc_statutimportglobal");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_rev_reviews_apps", "eq", entRevApp.Id.ToString());
                string strFetchXml = xmlFetcher.GenerateFetchXmltString();
                List<Entity> ListReviewsApp = myOperator.QuerySelect(strFetchXml);
                if (tracingService != null) tracingService.Trace($"Fetched {ListReviewsApp.Count} Review records using {strFetchXml}");

                foreach (Entity OneReview in ListReviewsApp)
                {
                    if ((OptionSetValue)OneReview.Attributes["cat_chc_statutimportglobal"] == OptionReviewError)
                    {
                        CurrentStatus = OptionReviewError;
                    }
                    else if ((OptionSetValue)OneReview.Attributes["cat_chc_statutimportglobal"] == OptionReviewInProgress || (OptionSetValue)OneReview.Attributes["cat_chc_statutimportglobal"] == OptionReviewNotStarted)
                    {
                        CurrentStatus = OptionReviewInProgress;
                    }
                }

                newDatas = new Dictionary<string, object>
                {
                    { "cat_chx_app_status", CurrentStatus }
                };
                if (tracingService != null) tracingService.Trace($"Updating cat_rev_apps record; cat_chx_app_status - {CurrentStatus.Value}");
                myOperator.QueryUpdate("cat_rev_apps", newDatas, entRevApp);

                if (tracingService != null) tracingService.Trace($"Fectching cat_rev_solutionreview record by entRevApp.cat_rev_apps_solutionreview");
                // Fetch 'Solution Review' based on 'Rev_App'
                Entity entSolutionReview = GetEntityFromARelatedOne(myOperator.getService(), entRevApp, "cat_rev_apps_solutionreview", "cat_rev_solutionreview", tracingService);

                // Fetch remaining 'Rev_Apps' records under 'Solution Review'
                if (tracingService != null) tracingService.Trace($"Fectching all cat_rev_apps records by cat_rev_apps.cat_rev_apps_solutionreview");
                xmlFetcher = new FetchXmlFormatter("cat_rev_apps");
                xmlFetcher.AddFieldColumn("cat_chx_app_status");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_rev_apps_solutionreview", "eq", entSolutionReview.Id.ToString());
                List<Entity> ListAppsSolution = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                CurrentStatus = OptionReviewCompleted;
                foreach (Entity OneReview in ListAppsSolution)
                {
                    if ((OptionSetValue)OneReview.Attributes["cat_chx_app_status"] == OptionReviewError)
                    {
                        CurrentStatus = OptionReviewError;
                    }
                    else if ((OptionSetValue)OneReview.Attributes["cat_chx_app_status"] == OptionReviewInProgress || (OptionSetValue)OneReview.Attributes["cat_chx_app_status"] == OptionReviewNotStarted)
                    {
                        CurrentStatus = OptionReviewInProgress;
                    }
                }

                // Update Solution Review
                newDatas = new Dictionary<string, object>
                {
                    { "cat_chc_solutionreview_status", CurrentStatus }
                };
                myOperator.QueryUpdate("cat_rev_solutionreview", newDatas, entSolutionReview);

                if (tracingService != null) tracingService.Trace($"Updating SolutionReview record; cat_chc_solutionreview_status - {CurrentStatus.Value}");

                return true;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in PropagateStatusUntilSolution; Message : {ex.Message}");
                return false;
            }
        }

        public static bool PropageScoreUntilSolution(DataverseOperator myOperator, Entity TheReview, ITracingService tracingService = null)
        {
            OptionSetValue OptionCanvas = new OptionSetValue(695100000);
            OptionSetValue OptionModelDriven = new OptionSetValue(695100001);
            OptionSetValue OptionConverged = new OptionSetValue(695100002);
            OptionSetValue OptionComponent = new OptionSetValue(695100003);

            try
            {
                //cat_score  
                Dictionary<string, object> newDatas;
                FetchXmlFormatter xmlFetcher;
                //cat_review_solutionreviews  cat_rev_reviews_apps
                Entity entRevApp = GetEntityFromARelatedOne(myOperator.getService(), TheReview, "cat_rev_reviews_apps", "cat_rev_apps");

                xmlFetcher = new FetchXmlFormatter("cat_review");
                //xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.AddFieldColumn("cat_score");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_rev_reviews_apps", "eq", entRevApp.Id.ToString());
                List<Entity> ListReviewsApp = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                double AverageApp = 0, TotalApp = 0;
                decimal TmpDecVal;

                foreach (Entity OneReview in ListReviewsApp)
                {
                    if (OneReview.Attributes.ContainsKey("cat_score"))
                    {
                        TmpDecVal = ((decimal)OneReview.Attributes["cat_score"]);
                        TotalApp += ((double)TmpDecVal);
                    }
                }

                AverageApp = (double)(TotalApp / ListReviewsApp.Count());

                // Update App Score
                newDatas = new Dictionary<string, object>
                {
                    { "cat_nb_appscore", AverageApp }
                };
                bool retupdate = myOperator.QueryUpdate("cat_rev_apps", newDatas, entRevApp);

                Entity entSolutionReview = GetEntityFromARelatedOne(myOperator.getService(), entRevApp, "cat_rev_apps_solutionreview", "cat_rev_solutionreview");

                // Fetch all Apps under the 'Solution Review'
                xmlFetcher = new FetchXmlFormatter("cat_rev_apps");
                xmlFetcher.AddFieldColumn("cat_nb_appscore");
                xmlFetcher.AddFieldColumn("cat_chx_apptype");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_rev_apps_solutionreview", "eq", entSolutionReview.Id.ToString());
                List<Entity> ListAppsSolution = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                double AverageSolution = 0, TotalSolution = 0;
                int NbNonDriven = 0;

                foreach (Entity NvReview in ListAppsSolution)
                {

                    if (NvReview.Attributes.ContainsKey("cat_nb_appscore"))
                    {
                        TmpDecVal = ((decimal)NvReview.Attributes["cat_nb_appscore"]);
                        TotalSolution += ((double)TmpDecVal);
                        if (NvReview.Attributes.ContainsKey("cat_chx_apptype"))
                        {
                            if ((OptionSetValue)NvReview.Attributes["cat_chx_apptype"] != OptionModelDriven) //&& ((decimal)NvReview.Attributes["cat_nb_appscore"])>0
                            {
                                NbNonDriven += 1;
                            }
                        }
                    }
                }

                if (NbNonDriven > 0)
                {
                    AverageSolution = (double)(TotalSolution / NbNonDriven);
                }
                else
                {
                    AverageSolution = (double)(TotalSolution / ListAppsSolution.Count());
                }

                // Update Soluion Score of 'Solution Review'
                newDatas = new Dictionary<string, object>
                {
                    { "cat_nb_solutionscore", AverageSolution }
                };
                retupdate = myOperator.QueryUpdate("cat_rev_solutionreview", newDatas, entSolutionReview);

                return true;

            }
            catch (Exception ex)
            {
                DataAccessLogic.LogPlugginAction(myOperator, DataAccessLogic.GetTimestamp(DateTime.Now) + " : Error : Score calcul val : ", 0);
                if (tracingService != null) tracingService.Trace($"Error in PropageScoreUntilSolution; Message : {ex.Message}");
                return false;
            }
        }

        public static void CalculateReviewScore(DataverseOperator myOperator, Entity ReviewEntity, ITracingService tracingService = null)
        {
            double scoreReview;
            int TotalValue = 0, TotalScore = 0;
            OptionSetValue StatutReviewItem;

            try
            {
                FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.AddFieldColumn("cat_reviewitemstatus");
                xmlFetcher.AddFieldColumn("cat_pattern");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", ReviewEntity.Id.ToString());
                List<Entity> ListeReviewItems = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                xmlFetcher = new FetchXmlFormatter("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_patternid");
                xmlFetcher.AddFieldColumn("cat_name");
                xmlFetcher.AddFieldColumn("cat_value");
                xmlFetcher.AddFieldColumn("cat_severity");
                List<Entity> ListePatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                Entity OnePatern;
                Guid PatternGuid;

                foreach (Entity OneReview in ListeReviewItems)
                {
                    if (OneReview.Attributes.ContainsKey("cat_reviewitemstatus") && OneReview.Attributes.ContainsKey("cat_pattern"))
                    {
                        StatutReviewItem = (OptionSetValue)OneReview.Attributes["cat_reviewitemstatus"];

                        if (StatutReviewItem.Value == 695100003 || StatutReviewItem.Value == 695100002)
                        {

                            PatternGuid = (OneReview.Attributes["cat_pattern"] as EntityReference).Id;
                            if (PatternGuid != null)
                            {
                                OnePatern = ListePatterns.Find(x => x.Id.ToString() == PatternGuid.ToString());

                                if (OnePatern != null)
                                {
                                    if (OnePatern.Attributes.ContainsKey("cat_value"))
                                    {
                                        TotalValue += (int)OnePatern.Attributes["cat_value"];
                                        if (StatutReviewItem.Value == 695100002)
                                        {
                                            TotalScore += (int)OnePatern.Attributes["cat_value"];
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (TotalValue > 0)
                {
                    scoreReview = ((double)TotalScore / (double)TotalValue);

                    Dictionary<string, object> newDatas = new Dictionary<string, object>();

                    newDatas.Add("cat_score", scoreReview);

                    myOperator.QueryUpdate("cat_review", newDatas, ReviewEntity);

                    //DataAccessLogic.LogPlugginAction(myOperator, DataAccessLogic.GetTimestamp(DateTime.Now) + " : "  + ReviewEntity.Id + " : Score calcul val : "+ scoreReview.ToString(), 1);
                    DataAccessLogic.PropageScoreUntilSolution(myOperator, ReviewEntity, tracingService);
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in CalculateReviewScore; Message : {ex.Message}");
                throw ex;
            }
        }

        public static bool ProcessFileSizeAssetsAutoFail(IOrganizationService ServiceObject, DataverseOperator myOperator, Guid reviewGuid, int Threshold, ITracingService tracingService = null)
        {
            Dictionary<string, object> newDatas;
            string PreviousComment = "";
            string UnCheckedMedia = "";

            List<Entity> results;
            List<Entity> FilesChecker;
            Entity ConcernedreviewItem;
            Entity ConcernedPattern;

            FetchXmlFormatter xmlFetcher;

            try
            {
                OptionSetValue TheStatus = new OptionSetValue(695100000);

                xmlFetcher = new FetchXmlFormatter("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_patternid");
                xmlFetcher.AddFieldColumn("cat_name");
                xmlFetcher.MaxRows = 1;
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_name", "eq", "app-AssetOptimization");
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                ConcernedPattern = results.First();


                xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.AddFieldColumn("cat_comment");
                xmlFetcher.MaxRows = 1;
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
                xmlFetcher.OMyFilter.AddFilter("cat_pattern", "eq", ConcernedPattern.Attributes["cat_patternid"].ToString());
                results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                ConcernedreviewItem = results.First();

                try
                {
                    PreviousComment = ConcernedreviewItem.Attributes["cat_comment"].ToString();
                }
                catch (Exception ex)
                {
                    if (tracingService != null) tracingService.Trace($"Error in PreviousComment; Message : {ex.Message}");
                    PreviousComment = "";
                }

                xmlFetcher = new FetchXmlFormatter("cat_rev_mediafiles");
                xmlFetcher.AddFieldColumn("cat_rev_mediafilesid");
                xmlFetcher.AddFieldColumn("cat_nb_mediasize");
                xmlFetcher.AddFieldColumn("cat_lb_namemedia");

                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_rel_mediafile_review", "eq", reviewGuid.ToString());
                xmlFetcher.OMyFilter.AddFilter("cat_nb_mediasize", "gt", (Threshold * 1000).ToString());
                FilesChecker = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());


                foreach (Entity oneFilePresent in FilesChecker)
                {
                    if ((int)oneFilePresent.Attributes["cat_nb_mediasize"] > (Threshold * 1000))
                    {
                        if (UnCheckedMedia.Trim() == "")
                        {
                            UnCheckedMedia = oneFilePresent.Attributes["cat_lb_namemedia"].ToString() + " (" + oneFilePresent.Attributes["cat_nb_mediasize"].ToString() + " bytes)";
                        }
                        else
                        {
                            UnCheckedMedia += ", " + oneFilePresent.Attributes["cat_lb_namemedia"].ToString() + " (" + oneFilePresent.Attributes["cat_nb_mediasize"].ToString() + " bytes)";
                        }
                    }

                }

                if (PreviousComment == null || PreviousComment.Trim() == "")
                {
                    if (UnCheckedMedia == "")
                    {
                        TheStatus = new OptionSetValue(695100002);
                        UnCheckedMedia = "";
                    }
                    else
                    {
                        TheStatus = new OptionSetValue(695100003);
                        UnCheckedMedia = "Code review tool : Media file size is too large.<br /> Please consider compressing files. Recommended file size < 300kb : " + UnCheckedMedia;
                    }
                }
                else
                {
                    if (UnCheckedMedia != "")
                    {

                        TheStatus = new OptionSetValue(695100003);
                        UnCheckedMedia = PreviousComment + "<br/>Code review tool : Media file size is too large.<br /> Please consider compressing files. Recommended file size < 300kb : " + UnCheckedMedia;
                    }
                }

                if (UnCheckedMedia != null && UnCheckedMedia != "")
                {
                    ConcernedreviewItem = GetEntityDatas(ServiceObject, "cat_reviewitem", new Guid(ConcernedreviewItem.Attributes["cat_reviewitemid"].ToString()));

                    newDatas = new Dictionary<string, object>();

                    newDatas.Add("cat_reviewitemstatus", TheStatus);
                    newDatas.Add("cat_comment", UnCheckedMedia);

                    myOperator.QueryUpdate("cat_reviewitem", newDatas, ConcernedreviewItem);
                }

                return true;

            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in ProcessFileSizeAssetsAutoFail; Message : {ex.Message}");
                return false;
            }
        }

        public static bool ProcessSettingsAutoFail(IOrganizationService ServiceObject, DataverseOperator myOperator, Guid reviewGuid, List<string> ToCheck, ITracingService tracingService = null)
        {

            Dictionary<string, object> newDatas;
            bool IsPresent;
            string UnCheckedSettings = "";
            OptionSetValue TheStatus;

            List<Entity> results;
            List<Entity> SettingsChecker;
            Entity ConcernedreviewItem;
            Entity ConcernedPattern;

            FetchXmlFormatter xmlFetcher;

            try
            {
                xmlFetcher = new FetchXmlFormatter("cat_rev_appsettings");
                xmlFetcher.AddFieldColumn("cat_lb_parametername");
                xmlFetcher.AddFieldColumn("cat_lb_parametervalue");
                xmlFetcher.AddFieldColumn("cat_rel_appsettings_review");

                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_rel_appsettings_review", "eq", reviewGuid.ToString());
                string strFetchXMLRevAppsettings = xmlFetcher.GenerateFetchXmltString();
                if (tracingService != null) tracingService.Trace($"Fetching cat_rev_appsettings; FetchXML : {strFetchXMLRevAppsettings}");

                SettingsChecker = myOperator.QuerySelect(strFetchXMLRevAppsettings);

                foreach (string OneSettingToCheck in ToCheck)
                {
                    IsPresent = false;

                    foreach (Entity oneSettingPresent in SettingsChecker)
                    {

                        if (OneSettingToCheck == oneSettingPresent.Attributes["cat_lb_parametername"].ToString())
                        {
                            if (oneSettingPresent.Attributes["cat_lb_parametervalue"].ToString() == "true")
                            {
                                IsPresent = true;
                            }
                            break;
                        }

                    }

                    if (!IsPresent)
                    {
                        if (UnCheckedSettings.Trim() == "")
                        {
                            UnCheckedSettings = OneSettingToCheck;
                        }
                        else
                        {
                            UnCheckedSettings += ", " + OneSettingToCheck;
                        }
                    }
                }

                if (UnCheckedSettings != "")
                {

                    TheStatus = new OptionSetValue(695100003);
                    UnCheckedSettings = "Code review tool : Advanced Settings. Please consider turning on the following settings : " + UnCheckedSettings;

                    xmlFetcher = new FetchXmlFormatter("cat_pattern");
                    xmlFetcher.AddFieldColumn("cat_patternid");
                    xmlFetcher.AddFieldColumn("cat_name");
                    xmlFetcher.MaxRows = 1;
                    xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                    xmlFetcher.OMyFilter.AddFilter("cat_name", "eq", "app-AppSettings");
                    results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                    ConcernedPattern = results.First();


                    xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                    xmlFetcher.AddFieldColumn("cat_reviewitemid");
                    xmlFetcher.MaxRows = 1;
                    xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                    xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
                    xmlFetcher.OMyFilter.AddFilter("cat_pattern", "eq", ConcernedPattern.Attributes["cat_patternid"].ToString());

                    results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                    if (results != null && results.Count > 0)
                    {
                        ConcernedreviewItem = results.First();

                        ConcernedreviewItem = GetEntityDatas(ServiceObject, "cat_reviewitem", new Guid(ConcernedreviewItem.Attributes["cat_reviewitemid"].ToString()));

                        newDatas = new Dictionary<string, object>
                        {
                            { "cat_reviewitemstatus", TheStatus },
                            { "cat_comment", UnCheckedSettings }
                        };

                        myOperator.QueryUpdate("cat_reviewitem", newDatas, ConcernedreviewItem);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in ProcessSettingsAutoFail; Message : {ex.Message}");
                return false;
            }
        }

        public static void ProcessReviewItemsAutoFail(DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService = null)
        {
            List<Entity> resultsAppChecker;
            bool IsRuleRefFounded = false;
            try
            {
                // Fecth Rewview Items
                FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                xmlFetcher.AddFieldColumn("cat_review");
                xmlFetcher.AddFieldColumn("cat_pattern");
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
                string strFetchXMLReviewItem = xmlFetcher.GenerateFetchXmltString();
                if (tracingService != null) tracingService.Trace($"Fetching cat_reviewitem; FetchXML : {strFetchXMLReviewItem}");
                List<Entity> results = myOperator.QuerySelect(strFetchXMLReviewItem);

                xmlFetcher = new FetchXmlFormatter("cat_rev_rulesreferences_patterns");
                xmlFetcher.AddFieldColumn("cat_patternid");
                xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
                string strFetchXMLRulesreferencesPatterns = xmlFetcher.GenerateFetchXmltString();
                if (tracingService != null) tracingService.Trace($"Fetching cat_rev_rulesreferences_patterns; FetchXML : {strFetchXMLRulesreferencesPatterns}");
                List<Entity> ListRulesReferencePatterns = myOperator.QuerySelect(strFetchXMLRulesreferencesPatterns);
                string cat_rev_appchecker_rulesreferencesid = "";

                OptionSetValue TheStatus;
                Dictionary<string, object> newParams;
                Dictionary<string, object> newDatas;

                Guid CreatedreviewItem;
                Guid patternGuid;

                foreach (Entity oneRes in results)
                {
                    patternGuid = oneRes.GetAttributeValue<EntityReference>("cat_pattern").Id;

                    List<Entity> ConflictRefPatterns = ListRulesReferencePatterns.Where(x => x.Attributes["cat_patternid"].ToString() == patternGuid.ToString()).ToList();

                    if (ConflictRefPatterns.Count() > 0)
                    {
                        IsRuleRefFounded = false;

                        foreach (Entity OneConflict in ConflictRefPatterns)
                        {
                            xmlFetcher = new FetchXmlFormatter("cat_rev_appcheckerresult_review");
                            xmlFetcher.AddFieldColumn("cat_rev_appcheckerresult_reviewid");
                            xmlFetcher.AddFieldColumn("cat_lb_ruleid_result");
                            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                            xmlFetcher.OMyFilter.AddFilter("cat_relappchecker_resultreview_review", "eq", reviewGuid.ToString());
                            xmlFetcher.OMyFilter.AddFilter("cat_rel_appchecker_resultreview_rules", "eq", OneConflict.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());
                            resultsAppChecker = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                            cat_rev_appchecker_rulesreferencesid = "";
                            IsRuleRefFounded = (resultsAppChecker.Count() > 0);

                            CreatedreviewItem = new Guid(oneRes.Attributes["cat_reviewitemid"].ToString());

                            if (IsRuleRefFounded)
                            {
                                TheStatus = new OptionSetValue(695100003);
                                newDatas = new Dictionary<string, object>
                            {
                                { "cat_reviewitemstatus", TheStatus },
                                { "cat_comment", "Code review tool : Errors or warnings from App Checker Results : " + resultsAppChecker[0].Attributes["cat_lb_ruleid_result"].ToString() }
                            };

                                myOperator.QueryUpdate("cat_reviewitem", newDatas, oneRes);
                            }

                            cat_rev_appchecker_rulesreferencesid = OneConflict.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString();

                            foreach (Entity OneAppRes in resultsAppChecker)
                            {
                                newParams = new Dictionary<string, object>();

                                EntityReference reviewitemRef = new EntityReference("cat_reviewitem", CreatedreviewItem);

                                newParams.Add("cat_reviewitem", reviewitemRef);

                                myOperator.QueryUpdate("cat_rev_appcheckerresult_review", newParams, OneAppRes);
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in ProcessReviewItemsAutoFail; Message : {ex.Message}");
                throw ex;
            }
        }

        public static void ProcessReviewItemsStatus(DataverseOperator myOperator, Guid reviewGuid)
        {

            List<Entity> resultsAppChecker;
            bool IsRuleRefFounded = false;
            FetchXmlFormatter xmlFetcher = new FetchXmlFormatter("cat_pattern");
            xmlFetcher.AddFieldColumn("cat_patternid");
            xmlFetcher.AddFieldColumn("cat_name");
            List<Entity> results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            List<Entity> resultsReviews;

            Random MyRand = new Random();

            xmlFetcher = new FetchXmlFormatter("cat_rev_rulesreferences_patterns");
            xmlFetcher.AddFieldColumn("cat_patternid");
            xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
            List<Entity> ListRulesReferencePatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            string cat_rev_appchecker_rulesreferencesid = "";
            Microsoft.Xrm.Sdk.OptionSetValue TheStatus;
            Dictionary<string, object> newParams;
            Dictionary<string, object> newDatas;
            EntityReference ReviewRef;
            EntityReference PatternRef;
            Guid CreatedreviewItem;
            foreach (Entity oneRes in results)
            {
                System.Threading.Thread.Sleep(MyRand.Next(10, 500));

                xmlFetcher = new FetchXmlFormatter("cat_reviewitem");
                xmlFetcher.AddFieldColumn("cat_reviewitemid");
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter("cat_pattern", "eq", oneRes.Attributes["cat_patternid"].ToString());
                xmlFetcher.OMyFilter.AddFilter("cat_review", "eq", reviewGuid.ToString());
                resultsReviews = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
                if (resultsReviews.Count() == 0)
                {

                    System.Threading.Thread.Sleep(MyRand.Next(10, 500));

                    List<Entity> ConflictRefPatterns = ListRulesReferencePatterns.Where(x => x.Attributes["cat_patternid"].ToString() == oneRes.Attributes["cat_patternid"].ToString()).ToList();

                    if (ConflictRefPatterns.Count() == 0)
                    {
                        newDatas = new Dictionary<string, object>();

                        ReviewRef = new EntityReference("cat_review", reviewGuid);
                        newDatas.Add("cat_review", ReviewRef);
                        PatternRef = new EntityReference("cat_pattern", new Guid(oneRes.Attributes["cat_patternid"].ToString()));
                        newDatas.Add("cat_pattern", PatternRef);
                        newDatas.Add("cat_reviewitemstatus", new OptionSetValue(695100001));

                        CreatedreviewItem = myOperator.QueryCreate("cat_reviewitem", newDatas);
                    }
                    else
                    {
                        IsRuleRefFounded = false;

                        foreach (Entity OneConflict in ConflictRefPatterns)
                        {
                            xmlFetcher = new FetchXmlFormatter("cat_rev_appcheckerresult_review");
                            xmlFetcher.AddFieldColumn("cat_rev_appcheckerresult_reviewid");
                            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                            xmlFetcher.OMyFilter.AddFilter("cat_relappchecker_resultreview_review", "eq", reviewGuid.ToString());
                            xmlFetcher.OMyFilter.AddFilter("cat_rel_appchecker_resultreview_rules", "eq", OneConflict.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());
                            resultsAppChecker = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                            cat_rev_appchecker_rulesreferencesid = "";
                            IsRuleRefFounded = (resultsAppChecker.Count() > 0);

                            if (IsRuleRefFounded)
                            {
                                TheStatus = new Microsoft.Xrm.Sdk.OptionSetValue(695100003);
                            }
                            else
                            {
                                TheStatus = new Microsoft.Xrm.Sdk.OptionSetValue(695100001);
                            }

                            cat_rev_appchecker_rulesreferencesid = OneConflict.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString();
                            newDatas = new Dictionary<string, object>();

                            ReviewRef = new EntityReference("cat_review", reviewGuid);
                            newDatas.Add("cat_review", ReviewRef);
                            PatternRef = new EntityReference("cat_pattern", new Guid(oneRes.Attributes["cat_patternid"].ToString()));
                            newDatas.Add("cat_pattern", PatternRef);
                            newDatas.Add("cat_reviewitemstatus", TheStatus);

                            CreatedreviewItem = myOperator.QueryCreate("cat_reviewitem", newDatas);

                            foreach (Entity OneAppRes in resultsAppChecker)
                            {
                                newParams = new Dictionary<string, object>();

                                EntityReference reviewitemRef = new EntityReference("cat_reviewitem", CreatedreviewItem);//new Guid(results.First().Attributes["cat_reviewitemid"].ToString()));
                                newParams.Add("cat_reviewitem", reviewitemRef);

                                myOperator.QueryUpdate("cat_rev_appcheckerresult_review", newParams, OneAppRes);
                            }

                            break;

                        }
                    }
                }
            }
        }

        public static void ProcessMediaFiles(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService = null)
        {
            try
            {
                Dictionary<string, object> newDatas = new Dictionary<string, object>();
                foreach (KeyValuePair<Microsoft.PowerPlatform.Formulas.Tools.Utility.FilePath, Microsoft.PowerPlatform.Formulas.Tools.FileEntry> OneMedia in msApp._assetFiles)
                {
                    newDatas.Add("cat_lb_namemedia", OneMedia.Value.Name);
                    newDatas.Add("cat_nb_mediasize", OneMedia.Value.RawBytes.Length);

                    EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                    newDatas.Add("cat_rel_mediafile_review", ReviewRef);

                    myOperator.QueryCreate("cat_rev_mediafiles", newDatas, tracingService);
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in ProcessMediaFiles; Message : {ex.Message}");
            }
        }

        public static List<Variable> ExtractVariablesFromAPropertyList(List<ListeSimplifiedcreens> LesProprietes, string ScreenName, string ControlName, List<Variable> VarList)
        {

            string[] ListSplited;
            string[] SplitersSet = { ",Set(", ";Set(", " Set(" }, SplitersSeparators = { ",", ";" };
            string VarToAdd;

            //int NbLengthScript, ibutee;

            foreach (ListeSimplifiedcreens OneProp in LesProprietes)
            {

                ListSplited = OneProp.CodeValue.Split(SplitersSet, StringSplitOptions.None);
                if (ListSplited.Count() > 1)
                {
                    for (int i = 0; i < ListSplited.Count(); i++)
                    {
                        if (i % 2 > 0)
                        {
                            try
                            {
                                VarToAdd = ListSplited[i].Split(SplitersSeparators, StringSplitOptions.None)[0];
                            }
                            catch (Exception ex)
                            {
                                VarToAdd = "";
                            }

                            if (VarList.Where(x => x.VariableName == VarToAdd).ToList().Count() == 0 && VarToAdd != "")
                            {
                                VarList.Add(new Variable(VarToAdd, ScreenName));
                            }
                        }
                    }
                }
            }


            return VarList;
        }


        public static List<ListeSimplifiedcreens> GetFromIrObject(List<Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode> ListProperties, string ScreenName, string ControlName = "")
        {
            List<ListeSimplifiedcreens> ListScreens;
            ListScreens = new List<ListeSimplifiedcreens>();

            foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode PropNode in ListProperties)
            {
                ListScreens.Add(new ListeSimplifiedcreens(ScreenName, ControlName, PropNode.Identifier, PropNode.Expression.Expression));
            }

            return ListScreens;
        }

        public static void ProcessVariables(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid)
        {

            List<Variable> VarList = new List<Variable>();
            List<Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> ControlsOfTheScreen;
            List<ListeSimplifiedcreens> PropertiesScreen = new List<ListeSimplifiedcreens>();

            foreach (KeyValuePair<string, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> OneScreen in msApp._screens)
            {

                ControlsOfTheScreen = new List<Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode>();
                ControlsOfTheScreen.Add(OneScreen.Value);
                ControlsOfTheScreen = OneScreen.Value.Children.Flatten(FuncList => FuncList.Children).ToList();


                foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode PropNode in OneScreen.Value.Properties)
                {
                    PropertiesScreen.Add(new ListeSimplifiedcreens(OneScreen.Value.Name.Identifier, "Screen", PropNode.Identifier, PropNode.Expression.Expression));
                }

                foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode OneNode in ControlsOfTheScreen)
                {
                    PropertiesScreen.AddRange(DataAccessLogic.GetFromIrObject(OneNode.Properties.ToList(), OneScreen.Value.Name.Identifier, ""));
                }


            }

            List<Variable> ListVar = ListeSimplifiedcreens.GetListScreensVariable(PropertiesScreen);
            Dictionary<string, object> newDatas;

            foreach (Variable UneVariable in ListVar)
            {
                newDatas = new Dictionary<string, object>();
                newDatas.Add("cat_lbnomvariable", UneVariable.VariableName);
                newDatas.Add("cat_lb_listscreens", UneVariable.ScreenListName);

                EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_variable_review", ReviewRef);

                myOperator.QueryCreate("cat_rev_variables", newDatas);
            }

        }


        public static void ProcessDataFiles(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid)
        {

            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            Guid MediaFileGUID;

            foreach (KeyValuePair<string, List<DataSourceEntry>> GrpDatasource in msApp.GetDataSources())
            {

                DataSourceEntry OneDatasource = GrpDatasource.Value.Last();

                if (OneDatasource.ExtensionData != null && OneDatasource.ExtensionData.ContainsKey("IsSampleData"))
                {
                    if (OneDatasource.ExtensionData["IsSampleData"].ValueKind == System.Text.Json.JsonValueKind.False)
                    {

                        newDatas.Add("cat_lb_namedatasource", OneDatasource.Name);
                        newDatas.Add("cat_lb_datasetname", OneDatasource.DatasetName);
                        newDatas.Add("cat_lb_typedatasource", OneDatasource.Type);
                        newDatas.Add("cat_lb_displaynamedatasource", OneDatasource.RelatedEntityName);

                        EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                        newDatas.Add("cat_rel_datasources_review", ReviewRef);

                        MediaFileGUID = myOperator.QueryCreate("cat_rev_datasources", newDatas);

                    }
                }
                else
                {
                    newDatas.Add("cat_lb_namedatasource", OneDatasource.Name);
                    newDatas.Add("cat_lb_datasetname", OneDatasource.DatasetName);
                    newDatas.Add("cat_lb_typedatasource", OneDatasource.Type);
                    newDatas.Add("cat_lb_displaynamedatasource", OneDatasource.RelatedEntityName);

                    EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                    newDatas.Add("cat_rel_datasources_review", ReviewRef);

                    MediaFileGUID = myOperator.QueryCreate("cat_rev_datasources", newDatas);
                }
                newDatas = new Dictionary<string, object>();

            }

        }

        public static void ProcessScreenControls(DataverseOperator myOperator, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode listControls, Guid reviewGuid, Guid screenGuid, CanvasDocument msApp, ITracingService tracingservice = null)
        {
            string ListErrors = "";

            if (listControls.Properties.ToList().Count() > 0)
            {
                tracingservice.Trace("==> Controls Found: {0}", listControls.Properties.ToList().Count());
                ListErrors = ImportProperties(listControls.Properties.ToList(), listControls.Name.Identifier, "", reviewGuid, screenGuid, Guid.Empty, myOperator, tracingservice, msApp, false);
            }

            if (listControls.Children.ToList().Count() > 0)
            {
                tracingservice.Trace("==> Childrens Found: {0}", listControls.Children.ToList().Count());
                ListErrors = ImportSubControls(listControls.Name.Identifier, listControls.Children.ToList(), myOperator, reviewGuid, screenGuid, Guid.Empty, tracingservice, msApp, false, ListErrors);
            }

            if (ListErrors != "")
            {
                FetchXmlFormatter MyFetcher = new FetchXmlFormatter("cat_rev_screens");
                MyFetcher.AddFieldColumn("cat_rev_screensid");
                MyFetcher.OMyFilter.StrLogicalOperator = "and";
                MyFetcher.MaxRows = 1;
                MyFetcher.OMyFilter.AddFilter("cat_rev_screensid", "eq", screenGuid.ToString());
                List<Entity> results = myOperator.QuerySelect(MyFetcher.GenerateFetchXmltString());

                Random MyRand = new Random();
                System.Threading.Thread.Sleep(MyRand.Next(100, 400));
                Dictionary<string, object> newDatas = new Dictionary<string, object>
                {
                    { "cat_txt_listfails", ListErrors }
                };
                if (tracingservice != null) tracingservice.Trace($"Updating cat_txt_listfails column of Rev_screens with {ListErrors}");
                myOperator.QueryUpdate("cat_rev_screens", newDatas, results.First(), tracingservice);
            }
            else
            {
                if (tracingservice != null) tracingservice.Trace($"No errors found on the screen");
            }
        }

        private static int CountTotalControls(int LastRetNbCtrl, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode TheControl)
        {

            int RetNbCtrl = LastRetNbCtrl;

            if (TheControl.Children != null)
            {
                RetNbCtrl = RetNbCtrl + TheControl.Children.ToList().Count;

                foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode OneChildren in TheControl.Children.ToList())
                {
                    RetNbCtrl = CountTotalControls(RetNbCtrl, OneChildren);
                }
            }

            return RetNbCtrl;

        }

        public static void ProcessPCFCreation(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService = null)
        {
            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            foreach (KeyValuePair<string, Microsoft.PowerPlatform.Formulas.Tools.Schemas.PcfControl.PcfControl> OnePCF in msApp._pcfControls)
            {
                string propertiesPcf = "";
                try
                {
                    foreach (Microsoft.PowerPlatform.Formulas.Tools.Schemas.PcfControl.Property OneProp in OnePCF.Value.Properties)
                    {
                        if (propertiesPcf == "")
                        {
                            propertiesPcf = OneProp.Name;
                        }
                        else
                        {
                            propertiesPcf += ", " + OneProp.Name;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (tracingService != null) tracingService.Trace($"Error in ProcessPCFCreation; Message : {ex.Message}");
                    propertiesPcf = "";
                }

                newDatas = new Dictionary<string, object>
                {
                    { "cat_lbnamepcf", OnePCF.Value.Name },
                    { "cat_cd_versionpcf", OnePCF.Value.Version },
                    { "cat_lb_propertiespcf", propertiesPcf }
                };
                EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_rel_pcf_review", ReviewRef);

                myOperator.QueryCreate("cat_rev_pcfcontrols", newDatas);
            }
        }

        private static void LoadScreenCollection(Dictionary<string, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> ScreensList, string TypeScreens, DataverseOperator myOperator, Guid reviewGuid, Dictionary<string, double> ScreenOrders, ITracingService tracingService = null)
        {
            int indexNum;
            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            int TotalControls;

            try
            {
                foreach (KeyValuePair<string, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> OneScreen in ScreensList)
                {

                    TotalControls = 0;

                    if (ScreenOrders.Keys.Contains(OneScreen.Key))
                    {
                        indexNum = Convert.ToInt32(ScreenOrders[OneScreen.Key]);
                    }
                    else
                    {
                        indexNum = 0;
                    }

                    Console.WriteLine("==> Processing screen: {0}", OneScreen.Key);
                    newDatas = new Dictionary<string, object>
                {
                    { "cat_lb_namescreen", OneScreen.Key },
                    { "cat_lb_layoutnamescreen", "" },
                    { "cat_lb_stylenamescreen", OneScreen.Value.Name.Kind.TypeName },
                    { "cat_nb_publishorderindexscreen", indexNum },
                    { "cat_cd_typeelement", TypeScreens }
                };
                    if (OneScreen.Value.Children != null)
                    {
                        TotalControls = CountTotalControls(OneScreen.Value.Children.Count, OneScreen.Value);
                        newDatas.Add("cat_nb_controls", TotalControls);
                        // OneScreen.Value.Children.Count);
                    }

                    EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                    newDatas.Add("cat_rel_screen_review", ReviewRef);

                    myOperator.QueryCreate("cat_rev_screens", newDatas);
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in LoadScreenCollection; Message : {ex.Message}");
                throw;
            }
        }

        public static void ProcessScreenCreation(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingService = null)
        {

            LoadScreenCollection(msApp._screens, "Screen", myOperator, reviewGuid, msApp._entropy.PublishOrderIndices, tracingService);
            LoadScreenCollection(msApp._components, "Component", myOperator, reviewGuid, new Dictionary<string, double>(), tracingService);
            ProcessPCFCreation(msApp, myOperator, reviewGuid, tracingService);

            /*
            int indexNum;
            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            int TotalControls;

            foreach (KeyValuePair<string, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> OneScreen in msApp._screens)
            {
                
                TotalControls = 0;

                if (msApp._entropy.PublishOrderIndices.Keys.Contains(OneScreen.Key))
                {
                    indexNum = Convert.ToInt32(msApp._entropy.PublishOrderIndices[OneScreen.Key]);
                }
                else
                {
                    indexNum = 0;
                }

                newDatas = new Dictionary<string, object>();
                Console.WriteLine("==> Processing screen: {0}", OneScreen.Key);
                newDatas.Add("cat_lb_namescreen", OneScreen.Key);
                newDatas.Add("cat_lb_layoutnamescreen", "");
                newDatas.Add("cat_lb_stylenamescreen", OneScreen.Value.Name.Kind.TypeName);
                newDatas.Add("cat_nb_publishorderindexscreen", indexNum);
                newDatas.Add("cat_cd_typeelement", "screen");
                if (OneScreen.Value.Children != null)
                {
                    TotalControls = CountTotalControls(OneScreen.Value.Children.Count, OneScreen.Value);
                    newDatas.Add("cat_nb_controls", TotalControls);
                    // OneScreen.Value.Children.Count);
                }
                
                EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_rel_screen_review", ReviewRef);

                myOperator.QueryCreate("cat_rev_screens", newDatas);

            }
            */
        }

        public static void LoadApptoSharedVariable(ITracingService tracingService, IPluginExecutionContext context, DataverseOperator myOperator, Guid reviewGuid, string uriMsapp)
        {
            // Print Shared Variables
            if (context.SharedVariables != null)
            {
                tracingService.Trace($"Shared variables count {context.SharedVariables.Count}");
                if (context.SharedVariables.Count > 0)
                {
                    tracingService.Trace("Printing Shared Variables");
                    foreach (var kvp in context.SharedVariables)
                    {
                        tracingService.Trace($"Key = {kvp.Key}");
                    }
                }
            }

            // Print Parent Shared Variables
            if (context.ParentContext.SharedVariables != null)
            {
                tracingService.Trace($"Parent shared variables count {context.ParentContext.SharedVariables.Count}");
                if (context.ParentContext.SharedVariables.Count > 0)
                {
                    tracingService.Trace("Printing parent Shared Variables");
                    foreach (var kvp in context.ParentContext.SharedVariables)
                    {
                        tracingService.Trace($"Key = {kvp.Key}");
                    }
                }
            }

            // Obtain the app payload from the execution context shared variables.
            tracingService.Trace($"Checking availability of app-{reviewGuid} in Shared Variables");
            string appPayloadBase64 = string.Empty;
            if (context.SharedVariables.Contains($"app-{reviewGuid}"))
            {
                tracingService.Trace($"app-{reviewGuid} found in Shared Variables");
                appPayloadBase64 = (string)context.SharedVariables[$"app-{reviewGuid}"];
            }
            else
            {
                tracingService.Trace($"app-{reviewGuid} not found in Shared Variables");
            }

            if (string.IsNullOrEmpty(appPayloadBase64))
            {
                // Get canvas app base 64 string
                appPayloadBase64 = myOperator.GetAppsPayloadBase64(myOperator, reviewGuid, tracingService, uriMsapp);
                // Add to shared variable
                if (!string.IsNullOrEmpty(appPayloadBase64))
                {
                    if (context.SharedVariables.Contains($"app-{reviewGuid}"))
                    {
                        tracingService.Trace($"Adding app-{reviewGuid} to EXISTING Shared Variables");
                        context.SharedVariables[$"app-{reviewGuid}"] = (Object)appPayloadBase64;
                    }
                    else
                    {
                        tracingService.Trace($"Adding app-{reviewGuid} to NEW Shared Variables");
                        context.SharedVariables.Add($"app-{reviewGuid}", (Object)appPayloadBase64);
                    }
                }
                else
                {
                    tracingService.Trace($"App payload is null; Not adding app-{reviewGuid} to Shared Variables");
                }
            }
        }

        public static string SyncAppPayloadtoDataverse(ITracingService tracingService, Entity entReview, DataverseOperator myOperator, string uriMsapp)
        {
            string appPayloadBase64 = string.Empty;
            // Obtain the app payload from the execution context shared variables.
            if (tracingService != null) tracingService.Trace($"Checking availability of payload in {entReview["cat_name"]} review annotation");
            try
            {
                try
                {
                    var qeNotes = new QueryExpression { EntityName = "annotation", ColumnSet = new ColumnSet("filename", "annotationid", "documentbody") };
                    qeNotes.Criteria.AddCondition("filename", ConditionOperator.Equal, $"cat_review_{entReview.Id}");
                    var collNotes = myOperator.getService().RetrieveMultiple(qeNotes);

                    if (collNotes != null && collNotes.Entities.Count > 0)
                    {
                        appPayloadBase64 = collNotes[0].Attributes["documentbody"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    if (tracingService != null) tracingService.Trace($"Error reading review annotation; Message : {ex.Message}");
                }

                if (!string.IsNullOrEmpty(appPayloadBase64))
                {
                    if (tracingService != null) tracingService.Trace($"App Payload exists in {entReview["cat_name"]} Annotation; Payload length : {appPayloadBase64.Length}");
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in SyncAppPayloadtoDataverse; Message : {ex.Message}");
                throw;
            }

            return appPayloadBase64;
        }

        public static string SyncAppPayloadtoDataverse_(ITracingService tracingService, Entity entReview, DataverseOperator myOperator, string uriMsapp)
        {
            string appPayloadBase64 = string.Empty;
            // Obtain the app payload from the execution context shared variables.
            if (tracingService != null) tracingService.Trace($"Checking availability of payload in {entReview["cat_name"]} review");
            try
            {
                if (entReview.Contains("cat_apppayload") && entReview["cat_apppayload"] != null)
                {
                    tracingService.Trace($"App payload available");
                    appPayloadBase64 = entReview["cat_apppayload"].ToString();
                }
                else
                {
                    tracingService.Trace($"App payload not available");
                }

                if (string.IsNullOrEmpty(appPayloadBase64))
                {
                    // Get canvas app base 64 string
                    appPayloadBase64 = myOperator.GetAppsPayloadBase64(myOperator, entReview.Id, tracingService, uriMsapp);
                    if (!string.IsNullOrEmpty(appPayloadBase64))
                    {
                        var colsReview = new Dictionary<string, object>
                    {
                        { "cat_apppayload", appPayloadBase64 }
                    };

                        // Add payload to Review record only if length is valid
                        if (appPayloadBase64.Length < 1048000)
                        {
                            if (tracingService != null) tracingService.Trace($"Updating Review {entReview["cat_name"]} with payload length : {appPayloadBase64.Length}");
                            myOperator.QueryUpdate("cat_rev_appchecker_rulesreferences", colsReview, entReview);
                        }
                        else
                        {
                            if (tracingService != null) tracingService.Trace($"Can not update Review {entReview["cat_name"]} with over limit payload length : {appPayloadBase64.Length}");
                        }
                    }
                    else
                    {
                        if (tracingService != null) tracingService.Trace($"App payload is null; Not adding to Review entity");
                    }
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in SyncAppPayloadtoDataverse; Message : {ex.Message}");
                throw;
            }

            return appPayloadBase64;
        }

        public static void LogPlugginAction(DataverseOperator MyOperator, string NomAction, int NbAction)
        {

            //cr7a3_plugginlogs
            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            newDatas = new Dictionary<string, object>
            {
                { "cr7a3_lbtache", NomAction },
                { "cr7a3_nb_dept", NbAction }
            };
            //MyOperator.QueryCreate("cr7a3_plugginlogs", newDatas);
        }

        public static void ProcessScreens(CanvasDocument msApp, DataverseOperator myOperator, Guid reviewGuid, ITracingService tracingservice = null)
        {
            int indexNum;
            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            Guid ScreenGuid;
            foreach (KeyValuePair<string, Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> OneScreen in msApp._screens)
            {

                if (msApp._entropy.PublishOrderIndices.Keys.Contains(OneScreen.Key))
                {
                    indexNum = Convert.ToInt32(msApp._entropy.PublishOrderIndices[OneScreen.Key]);
                }
                else
                {
                    indexNum = 0;
                }

                Console.WriteLine("==> Processing screen: {0}", OneScreen.Key);
                newDatas.Add("cat_lb_namescreen", OneScreen.Key);
                newDatas.Add("cat_lb_layoutnamescreen", "");
                newDatas.Add("cat_lb_stylenamescreen", OneScreen.Value.Name.Kind.TypeName);
                newDatas.Add("cat_nb_publishorderindexscreen", indexNum);

                EntityReference ReviewRef = new EntityReference("cat_review", reviewGuid);
                newDatas.Add("cat_rel_screen_review", ReviewRef);

                ScreenGuid = myOperator.QueryCreate("cat_rev_screens", newDatas);

                newDatas = new Dictionary<string, object>();

                if (OneScreen.Value.Properties.ToList().Count() > 0)
                {
                    ImportProperties(OneScreen.Value.Properties.ToList(), OneScreen.Key, "", reviewGuid, ScreenGuid, Guid.Empty, myOperator, tracingservice, msApp, false);
                }

                if (OneScreen.Value.Children.ToList().Count() > 0)
                {
                    ImportSubControls(OneScreen.Key, OneScreen.Value.Children.ToList(), myOperator, reviewGuid, ScreenGuid, Guid.Empty, tracingservice, msApp, false, "");
                }
            }

        }


        public static void CleanExistingTables(DataverseOperator myOperator)
        {

            PurgeTable("cat_rev_mediafiles", "cat_rev_mediafilesid", "cat_rel_mediafile_review", myOperator);
            //Cleaning datasources
            PurgeTable("cat_rev_datasources", "cat_rev_datasourcesid", "cat_rel_datasources_review", myOperator);

            //Clean Screen Loading
            PurgeTable("cat_rev_screens", "cat_rev_screensid", "cat_rel_screen_review", myOperator);
            PurgeTable("cat_rev_controls", "cat_rev_controlsid", "cat_rel_control_review", myOperator);

            PurgeTable("cat_rev_codeparts", "cat_rev_controlsid", "cat_rel_control_review", myOperator);

            PurgeTable("cat_rev_propertiescode", "cat_rev_propertiescodeid", "cat_rel_properties_review", myOperator);

            //Cleaning reviewItems
            PurgeTable("cat_reviewitem", "cat_reviewitemid", "cat_review", myOperator);
            PurgeTable("cat_rev_codeparts", "cat_rev_codepartsid", "cat_fk_codepart_reviewitem", myOperator);


            //Cleaning appResults
            PurgeTable("cat_rev_appcheckermessagesarguments", "cat_rev_appcheckermessagesargumentsid", "cat_rel_appcheckerargument_review", myOperator);
            PurgeTable("cat_rev_appchecker_results", "cat_rev_appchecker_resultsid", "cat_rel_appchecker_result_review", myOperator);//cat_Rev_AppChecker_Results_Review
            PurgeTable("cat_rev_appcheckerresult_review", "cat_rev_appcheckerresult_reviewid", "cat_relappchecker_resultreview_review", myOperator);

            //Cleaning AppSettings
            //PurgeTable("cat_rev_appsettings", "cat_rev_appsettingsid", "cat_rel_appsettings_review", myOperator);

        }
        public static void CleanExistingTables(DataverseOperator myOperator, Guid reviewGuid)
        {

            PurgeTable("cat_rev_mediafiles", reviewGuid, "cat_rev_mediafilesid", "cat_rel_mediafile_review", myOperator);
            //Cleaning datasources
            PurgeTable("cat_rev_datasources", reviewGuid, "cat_rev_datasourcesid", "cat_rel_datasources_review", myOperator);

            //Clean Screen Loading
            PurgeTable("cat_rev_screens", reviewGuid, "cat_rev_screensid", "cat_rel_screen_review", myOperator);
            PurgeTable("cat_rev_controls", reviewGuid, "cat_rev_controlsid", "cat_rel_control_review", myOperator);

            PurgeTable("cat_rev_codeparts", reviewGuid, "cat_rev_controlsid", "cat_rel_control_review", myOperator);

            PurgeTable("cat_rev_propertiescode", reviewGuid, "cat_rev_propertiescodeid", "cat_rel_properties_review", myOperator);

            //Cleaning reviewItems
            PurgeTable("cat_reviewitem", reviewGuid, "cat_reviewitemid", "cat_review", myOperator);


            //Cleaning appResults
            PurgeTable("cat_rev_appcheckermessagesarguments", reviewGuid, "cat_rev_appcheckermessagesargumentsid", "cat_rel_appcheckerargument_review", myOperator);
            PurgeTable("cat_rev_appchecker_results", reviewGuid, "cat_rev_appchecker_resultsid", "cat_rel_appchecker_result_review", myOperator);//cat_Rev_AppChecker_Results_Review
            PurgeTable("cat_rev_appcheckerresult_review", reviewGuid, "cat_rev_appcheckerresult_reviewid", "cat_relappchecker_resultreview_review", myOperator);

            //Cleaning AppSettings
            PurgeTable("cat_rev_appsettings", reviewGuid, "cat_rev_appsettingsid", "cat_rel_appsettings_review", myOperator);

        }

        public static string ImportSubControls(string StrNameScreen, List<Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode> ListControls, DataverseOperator MyOperator, Guid GReview, Guid GScreen, Guid GControl, ITracingService tracingservice, CanvasDocument msApp, bool isControlNested, string CurentErrorsList)
        {
            //Guid GuidNvControl = Guid.NewGuid();
            Dictionary<string, object> newDatas = null;
            string TmpFail = string.Empty;

            foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.BlockNode SubControl in ListControls)
            {
                TmpFail = "";
                newDatas = new Dictionary<string, object>
                {
                    { "cat_lb_typecontrol", SubControl.Name.Kind.TypeName },
                    { "cat_lb_namecontrol", SubControl.Name.Identifier },
                    { "cat_nb_publishorderindexcontrol", 1 }
                    //,{ "cat_rev_controlsid", GuidNvControl}
                };

                EntityReference reviewitemRef = new EntityReference("cat_review", GReview);
                newDatas.Add("cat_rel_control_review", reviewitemRef);

                EntityReference ScreenRef = new EntityReference("cat_rev_screens", GScreen);
                newDatas.Add("cat_rel_controls_screens", ScreenRef);

                if (GControl != Guid.Empty)
                {
                    EntityReference ControlRef = new EntityReference("cat_rev_controls", GControl);
                    newDatas.Add("cat_rel_controls_parent", ControlRef);
                }

                Guid GuidNvControl = MyOperator.QueryCreate("cat_rev_controls", newDatas, tracingservice);
                //BulkRecordstoCreate.Add(MyOperator.GetEntityToCreate("cat_rev_controls", newDatas));

                bool IsNested = (isControlNested || SubControl.Properties.Where(x => x.Identifier.ToString() == "Items").ToList().Count > 0);

                if (SubControl.Properties.Count() > 0)
                {
                    TmpFail = ImportProperties(SubControl.Properties.ToList(), StrNameScreen, SubControl.Name.Identifier, GReview, GScreen, GuidNvControl, MyOperator, tracingservice, msApp, isControlNested);
                    if (TmpFail.Trim() != "")
                    {
                        if (CurentErrorsList == "")
                        {
                            CurentErrorsList += TmpFail;
                        }
                        else
                        {
                            CurentErrorsList += "____" + TmpFail;
                        }
                    }
                }

                if (SubControl.Children.Count() > 0)
                {
                    CurentErrorsList = ImportSubControls(StrNameScreen, SubControl.Children.ToList(), MyOperator, GReview, GScreen, GuidNvControl, tracingservice, msApp, IsNested, CurentErrorsList);
                }
            }

            return CurentErrorsList;
        }

        public static void PurgeTable(string StrTableName, string StrColIdName, string StrColRelReviewName, DataverseOperator MyOperator)
        {
            FetchXmlFormatter MyFetcher = MyFetcher = new FetchXmlFormatter(StrTableName);
            MyFetcher.AddFieldColumn(StrColRelReviewName);
            MyFetcher.OMyFilter.StrLogicalOperator = "and";
            MyFetcher.OMyFilter.AddFilter(StrColRelReviewName, "null");
            List<Entity> results = MyOperator.QuerySelect(MyFetcher.GenerateFetchXmltString());

            foreach (Entity oneRes in results)
            {
                MyOperator.QueryDelete(StrTableName, new Guid(oneRes.Attributes[StrColIdName].ToString()));
            }
        }

        public static void PurgeTable(string StrTableName, Guid GuidReview, string StrColIdName, string StrColRelReviewName, DataverseOperator MyOperator)
        {

            FetchXmlFormatter MyFetcher = new FetchXmlFormatter(StrTableName);
            MyFetcher.AddFieldColumn(StrColRelReviewName);
            MyFetcher.OMyFilter.StrLogicalOperator = "and";
            MyFetcher.OMyFilter.AddFilter(StrColRelReviewName, "eq", GuidReview.ToString());
            List<Entity> results = results = MyOperator.QuerySelect(MyFetcher.GenerateFetchXmltString());

            foreach (Entity oneRes in results)
            {
                MyOperator.QueryDelete(StrTableName, new Guid(oneRes.Attributes[StrColIdName].ToString()));
            }

        }

        public static List<CodeFail> CheckForStaticPatternsInProperty(string Propertycode, string Propertyname, CanvasDocument msApp)
        {
            List<CodeFail> ListFails = new List<CodeFail>();
            //Check for N+1 Call   app-CheckForNplusOneCalls

            //Check for First(Filter   app-FormulaOptimization-FirstFilter

            //Check for Nested Filter    app-FormulaOptimization-NestedFilter

            //API Calls in patches       app-FormulaOptimization-Patch

            //app-DataLoadingStrategy

            return ListFails;
        }

        public static bool IsPropertyToImport(string PropertyScript, string PropertyName, List<DataSourceElement> LDatasources)
        {
            bool bImportThisProperty;
            int NbLengthScript = PropertyScript.Length;
            List<string> PropertiesWhiteList = new List<string> { "Image" };
            bImportThisProperty = NbLengthScript > 40 || PropertiesWhiteList.Contains(PropertyName);
            if (!bImportThisProperty)
            {
                foreach (DataSourceElement OneDatasource in LDatasources)
                {
                    if (PropertyScript.Contains(OneDatasource.lb_namedatasource))
                    {
                        bImportThisProperty = true;
                        break;
                    }
                }
            }
            return bImportThisProperty;
        }

        public static string ImportProperties(List<Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode> ListProperties, string StrNameScreen, string StrNameControl, Guid GReview, Guid GScreen, Guid GControl, DataverseOperator MyOperator, ITracingService tracingservice, CanvasDocument msApp, bool isControlNested)
        {
            string retFails = string.Empty;
            int NbLengthScript;
            Dictionary<string, object> newDatas;
            AutoFailElement FailElmt;
            int ibutee;
            Guid GuidProperty;
            //bool isControlNested = false;
            var PropertiesToAvoid = new List<string> { "X", "Y", "PaddingBottom", "PaddingTop", "PaddingLeft", "PaddingRight", "Height", "Width", "HoverBorderColor", "BorderColor", "FocusedBorderColor", "PressedFill", "HoverFill", "PressedBorderColor", "PressedColor", "Size", "DisabledBorderColor", "LoadingSpinnerColor", "DisabledFill" };
            var LDatasources = PowerAppsParser.GetListDataSourceElements(msApp);
            int indexNum = 0;
            try
            {
                foreach (Microsoft.PowerPlatform.Formulas.Tools.IR.PropertyNode OneProp in ListProperties)
                {
                    if (!PropertiesToAvoid.Contains(OneProp.Identifier.ToString()))
                    {
                        newDatas = new Dictionary<string, object>();

                        string StrCleanedScript = OneProp.Expression.Expression.ToString().Replace("\r", " ").Replace("\n", " ").Replace("\t", " ");
                        NbLengthScript = OneProp.Expression.Expression.Length;
                        ibutee = NbLengthScript >= 25000 ? 25000 : NbLengthScript;

                        //if (NbLengthScript > 40 || PropertiesWhiteList.Contains(OneProp.Identifier.ToString()))
                        if (IsPropertyToImport(OneProp.Expression.Expression, OneProp.Identifier.ToString(), LDatasources))
                        {
                            if (msApp._entropy.PublishOrderIndices.Keys.Contains(StrNameScreen))
                            {
                                indexNum = Convert.ToInt32(msApp._entropy.PublishOrderIndices[StrNameScreen]);
                            }
                            //tracingservice.Trace(DateTime.Now.ToString("MM/dd/yyy HH:mm:ss.fff") + " -DEBUT-, control name :  " + StrNameControl + ", property name :  " + OneProp.Identifier.ToString());

                            PowerAppsParser myparser = new PowerAppsParser(OneProp.Expression.Expression.ToString(), LDatasources, OneProp.Identifier.ToString(), StrNameControl, isControlNested, indexNum);

                            //tracingservice.Trace(DateTime.Now.ToString("MM/dd/yyy HH:mm:ss.fff") + " -FIN-, control name :  " + StrNameControl + ", property name :  " + OneProp.Identifier.ToString());

                            Guid newPropertyCodeId = Guid.NewGuid();
                            newDatas.Add("cat_nb_codesize", NbLengthScript);
                            newDatas.Add("cat_lb_invariantscript_property_cleaned", StrCleanedScript.Substring(0, ibutee));
                            newDatas.Add("cat_lb_invariantscript_property", OneProp.Expression.Expression.Substring(0, ibutee));
                            newDatas.Add("cat_lb_nameproperty", OneProp.Identifier.ToString());
                            newDatas.Add("cat_lb_namescreen_property", StrNameScreen);
                            newDatas.Add("cat_lb_namecontrol_property", StrNameControl);
                            newDatas.Add("cat_lb_ruleprovidertype_property", "");
                            newDatas.Add("cat_rev_propertiescodeid", newPropertyCodeId);

                            EntityReference reviewRef = new EntityReference("cat_review", GReview);
                            newDatas.Add("cat_rel_properties_review", reviewRef);

                            EntityReference ScreenRef = new EntityReference("cat_rev_screens", GScreen);
                            newDatas.Add("cat_rel_properties_screens", ScreenRef);

                            if (GControl != Guid.Empty)
                            {
                                EntityReference ControlRef = new EntityReference("cat_rev_controls", GControl);
                                newDatas.Add("cat_rel_properties_controls", ControlRef);
                            }

                            //if (tracingservice != null) tracingservice.Trace($"Adding record {BulkRecordstoCreate.Count + 1} to create");
                            //BulkRecordstoCreate.Add(MyOperator.GetEntityToCreate("cat_rev_propertiescode", newDatas));
                            GuidProperty = MyOperator.QueryCreate("cat_rev_propertiescode", newDatas, tracingservice);

                            foreach (CodeFail onefail in myparser.ListOfFails)
                            {
                                //FailElmt = new AutoFailElement(onefail.patternName, GuidProperty.ToString(), onefail.failMessage, StrNameScreen, StrNameControl, OneProp.Identifier.ToString(), OneProp.Expression.Expression.Substring(0, ibutee));
                                FailElmt = new AutoFailElement(onefail.patternName, newPropertyCodeId.ToString(), onefail.failMessage, StrNameScreen, StrNameControl, OneProp.Identifier.ToString(), OneProp.Expression.Expression.Substring(0, ibutee));

                                if (retFails == "")
                                {
                                    retFails = FailElmt.lbCompletestring;
                                }
                                else
                                {
                                    retFails += "____" + FailElmt.lbCompletestring;
                                }
                            }
                        }
                    }
                }

                //BulkCreateRecords(MyOperator, tracingservice, listEntitiestoCreate);
            }
            catch (Exception ex)
            {
                if (tracingservice != null) tracingservice.Trace($"Error in ImportProperties; Message : {ex.Message}");
                throw;
            }

            return retFails;
        }

        public static void BulkCreateRecords(DataverseOperator MyOperator, ITracingService tracingservice, List<Entity> listEntitiestoCreate)
        {
            if (listEntitiestoCreate.Count == 0) return;

            // Create an ExecuteMultipleRequest object.
            var requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            if (tracingservice != null) tracingservice.Trace($"Creating {listEntitiestoCreate.Count} records");
            // Add a CreateRequest for each entity to the request collection.
            foreach (var entity in listEntitiestoCreate)
            {
                CreateRequest createRequest = new CreateRequest { Target = entity };
                requestWithResults.Requests.Add(createRequest);
            }

            // Clear the list
            listEntitiestoCreate.Clear();

            // Execute all the requests in the request collection using a single web method call.
            var responseWithResults = (ExecuteMultipleResponse)MyOperator.getService().Execute(requestWithResults);
        }

        public static void Usage()
        {
            Console.WriteLine(
                @"Usage

                -unpack PathToApp.msapp PathToNewSourceFolder
                -unpack PathToApp.msapp  // infers source folder
                -pack  NewPathToApp.msapp PathToSourceFolder
                -make PathToCreateApp.msapp PathToPkgFolder PathToPaFile

                ");
        }

        public static Entity GetEntityFromARelatedOne(IOrganizationService ServiceObject, Entity RealtedEntity, string RelationColumn, string MainTableName, ITracingService tracingService = null)
        {
            try
            {
                Guid MainGuid = (RealtedEntity.Attributes[RelationColumn] as EntityReference).Id;

                Entity myEntity = null;

                if (MainTableName == "cat_review")
                {
                    myEntity = ServiceObject.Retrieve(MainTableName, MainGuid, new ColumnSet("cat_msapp_document_uri", "cat_reviewid", "cat_apppayload", "cat_name", "cat_rev_reviews_apps", "cat_chc_statutimportglobal"));
                }
                else if (MainTableName == "cat_rev_apps")
                {
                    myEntity = ServiceObject.Retrieve(MainTableName, MainGuid, new ColumnSet("cat_chx_app_status", "cat_rev_apps_solutionreview", "cat_rev_appsid"));
                }
                else
                {
                    myEntity = ServiceObject.Retrieve(MainTableName, MainGuid, new ColumnSet(true));
                }

                return myEntity;
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in GetEntityFromARelatedOne; Message : {ex.Message}");
                return new Entity();
            }
        }

        public static Entity GetEntityDatas(IOrganizationService ServiceObject, string StrEntityName, Guid TheGuid, ITracingService tracingService = null)
        {
            Entity MyEntity;
            try
            {
                if (StrEntityName == "cat_review")
                {
                    MyEntity = ServiceObject.Retrieve(StrEntityName, TheGuid, new ColumnSet("cat_msapp_document_uri", "cat_reviewid", "cat_apppayload", "cat_name", "cat_rev_reviews_apps"));
                }
                else if (StrEntityName == "cat_reviewrequest")
                {
                    MyEntity = ServiceObject.Retrieve(StrEntityName, TheGuid, new ColumnSet("cat_requeststatus", "cat_chc_appcheckerstatus", "cat_review", "cat_reviewrequestid"));
                }
                else
                {
                    MyEntity = ServiceObject.Retrieve(StrEntityName, TheGuid, new ColumnSet(true));
                }
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in GetEntityDatas; Message : {ex.Message}");
                throw ex;
            }
            return MyEntity;
        }

        /// <summary>
        /// Sets SolutionReview Status To Error and populates 'Error Message'
        /// </summary>
        /// <param name="myOperator">Dataverse Operator</param>
        /// <param name="SolutionReviewId">Solution Review Id</param>
        /// <param name="errorMessage">Error Message</param>
        public static void SetSolutionReviewStatusToError(DataverseOperator myOperator, Guid SolutionReviewId, string errorMessage = "")
        {
            Entity entSolutionReview = new Entity("cat_rev_solutionreview", SolutionReviewId);
            OptionSetValue OptionReviewError = new OptionSetValue(341200000);
            // Set Rev_SolutionReview Chc_SolutionReview_Status as 'Error'
            Dictionary<string, object> newDatas = new Dictionary<string, object>
            {
                { "cat_chc_solutionreview_status", OptionReviewError },
                { "cat_errordetails", errorMessage }
            };

            myOperator.QueryUpdate("cat_rev_solutionreview", newDatas, entSolutionReview);
        }

        public static bool UpdateReviewStatus(DataverseOperator myOperator, Guid reviewGuid, Object CodeStatus, string columnstatusname, string EntityName = "cat_review", ITracingService tracingService = null)
        {
            try
            {
                Dictionary<string, object> newDatas = new Dictionary<string, object>
                {
                    { columnstatusname, CodeStatus }
                };

                return myOperator.QueryUpdateStatus(EntityName, newDatas, reviewGuid);
            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in UpdateReviewStatus; EntityName : {EntityName}; Columnstatusname : {columnstatusname}; CodeStatus : {CodeStatus}");
                return false;
            }
        }

        /// <summary>
        /// Match the AppVersion with Web Resource 'App Version' and refreshes Patterns
        /// </summary>
        /// <param name="MyOperator">Dataverse Operator</param>
        /// <param name="existingPatterns">Cahced Patterns</param>
        /// <returns>Refreshed or Not</returns>
        public static bool ProcessInitialLoading(DataverseOperator MyOperator, List<Entity> existingPatterns = null, ITracingService tracingService = null)
        {
            // Fetch Active Patterns
            string XmlTxt;
            // Fetch 'Rev Settings' and read the 'AppVersion'
            int currentversion = 0;
            if (tracingService != null) tracingService.Trace($"Fetching cat_rev_settings");
            FetchXmlFormatter MyFetcher = new FetchXmlFormatter("cat_rev_settings");
            MyFetcher.AddFieldColumn("cat_lb_settingname");
            MyFetcher.AddFieldColumn("cat_lb_settingvalue");
            MyFetcher.OMyFilter.StrLogicalOperator = "and";
            MyFetcher.MaxRows = 1;
            MyFetcher.OMyFilter.AddFilter("cat_lb_settingname", "eq", "AppVersion");
            List<Entity> resultsVersion = MyOperator.QuerySelect(MyFetcher.GenerateFetchXmltString());
            Entity RowVersion = null;
            if (resultsVersion.Count > 0)
            {
                RowVersion = resultsVersion.First();
                if (resultsVersion.First().Attributes.Contains("cat_lb_settingvalue"))
                {
                    currentversion = Convert.ToInt32(resultsVersion.First().Attributes["cat_lb_settingvalue"].ToString());
                }
            }
            else
            {
                if (tracingService != null) tracingService.Trace($"No cat_rev_settings fetched");
            }

            if (tracingService != null) tracingService.Trace($"AppVersion : {currentversion}");

            // cat_patterns_rules_v2
            if (tracingService != null) tracingService.Trace($"Fetching webresource content of cat_patterns_rules_v2");
            // Read Web Resource with Rules Content
            XmlTxt = GetWebRessourceContent(MyOperator);
            // if (tracingService != null) tracingService.Trace($"Content of cat_patterns_rules_v2 : {XmlTxt}");
            XmlSerializer serializer = new XmlSerializer(typeof(RootXml));
            StringReader reader = new StringReader(XmlTxt);
            RootXml ElementsXml = (RootXml)serializer.Deserialize(reader);

            // If web Resource file version greater than Current version reload Patterns
            if (!existingPatterns.Any() || ElementsXml.Version > currentversion)
            {
                if (tracingService != null) tracingService.Trace($"Webresource version {ElementsXml.Version} is greater than App Version {currentversion} in Rev_Settings table");
                if (tracingService != null) tracingService.Trace("Refreshing Patterns");
                return ImportXmlRulesAndPatterns(MyOperator, ElementsXml, currentversion, RowVersion, existingPatterns, tracingService);
            }
            else
            {
                if (tracingService != null) tracingService.Trace("No Patterns Refresh Required");
                return false;
            }
        }

        /// <summary>
        /// Read the Pattern Rules Web Resource File
        /// </summary>
        /// <param name="myOperator">Dataverse Operator</param>
        /// <returns>Content of webresource file</returns>
        public static string GetWebRessourceContent(DataverseOperator myOperator)
        {
            EntityCollection webResourceCollection = myOperator.GetAWebRessource("webresource", "name", "cat_patterns_rules_v2");

            var webResource = (Entity)webResourceCollection.Entities[0];

            byte[] binary = Convert.FromBase64String(webResource.Attributes["content"].ToString());
            string resourceContent = UnicodeEncoding.UTF8.GetString(binary);
            return resourceContent;
        }

        public static List<Entity> DoesValueExistsInColumn(DataverseOperator myOperator, string ValueToCheck, string TableName, string ColumnName)
        {
            try
            {
                FetchXmlFormatter xmlFetcher = new FetchXmlFormatter(TableName);
                xmlFetcher.AddFieldColumn(ColumnName);
                xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                xmlFetcher.OMyFilter.AddFilter(ColumnName, "eq", ValueToCheck);
                List<Entity> results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                return results;

            }
            catch (Exception ex)
            {
                return new List<Entity>();
            }

        }

        /// <summary>
        /// Updates the Patterns from Web Resource
        /// </summary>
        /// <param name="myOperator">Dataverse Operator</param>
        /// <param name="ElementsXml">Elements Xml</param>
        /// <param name="Newversion">New Version</param>
        /// <param name="Version">Version</param>
        /// <param name="existingPatterns">Cahced Patterns</param>
        /// <returns>Refreshed Patterns or Not</returns>
        public static bool ImportXmlRulesAndPatterns(DataverseOperator myOperator, RootXml ElementsXml, int Newversion, Entity Version = null, List<Entity> existingPatterns = null, ITracingService tracingService = null)
        {
            Dictionary<string, object> newDatas = new Dictionary<string, object>();
            Guid GPattern;
            Guid GRule;
            Guid GRessource;
            FetchXmlFormatter xmlFetcher;
            List<Entity> results;
            List<Guid> ListToRelate;
            List<Guid> ListToUnRelate;
            Entity PatternFounded, RuleFounded, ResourceFounded;

            List<Entity> resultsPatterns = existingPatterns;

            if (tracingService != null) tracingService.Trace("Fetching cat_rev_appchecker_rulesreferences");
            // Fetch Rev_appchecker_rulesreferences
            xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_rulesreferences");
            xmlFetcher.AddFieldColumn("cat_lb_ruleid_ref");
            xmlFetcher.AddFieldColumn("cat_lb_componenttype");
            xmlFetcher.AddFieldColumn("cat_lb_level_ref");
            xmlFetcher.AddFieldColumn("cat_lb_whyfix");
            xmlFetcher.AddFieldColumn("cat_lb_primarycategory");
            List<Entity> resultsRules = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            if (tracingService != null) tracingService.Trace($"resultsRules count : {resultsRules.Count}");

            if (tracingService != null) tracingService.Trace("Fetching cat_resource");
            // Fetch Resource
            xmlFetcher = new FetchXmlFormatter("cat_resource");
            xmlFetcher.AddFieldColumn("cat_pattern");
            xmlFetcher.AddFieldColumn("cat_url");
            xmlFetcher.AddFieldColumn("crfd9_lb_nomressource");
            List<Entity> resultsResources = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            if (tracingService != null) tracingService.Trace($"resultsResources count : {resultsResources.Count}");

            if (tracingService != null) tracingService.Trace("Fetching cat_rev_rulesreferences_patterns");
            // Fetch Rev_rulesreferences_patterns
            xmlFetcher = new FetchXmlFormatter("cat_rev_rulesreferences_patterns");
            xmlFetcher.AddFieldColumn("cat_patternid");
            xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
            List<Entity> ListRulesReferencePatterns = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());
            if (tracingService != null) tracingService.Trace($"ListRulesReferencePatterns count : {ListRulesReferencePatterns.Count}");

            List<Entity> ListAfterCheck;
            List<ResourceXml> ListRessource = new List<ResourceXml>();

            try
            {
                foreach (RuleXml oneRule in ElementsXml.Rules.Rule)
                {
                    RuleFounded = resultsRules.Find(x => x.Attributes["cat_lb_ruleid_ref"].ToString() == oneRule.Name);
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_ruleid_ref", oneRule.Name },
                        { "cat_lb_componenttype", oneRule.ComponentType },
                        { "cat_lb_level_ref", oneRule.Level },
                        { "cat_lb_whyfix", oneRule.WhyFix },
                        { "cat_lb_primarycategory", oneRule.PrimaryCategory }
                    };

                    if (RuleFounded != null)
                    {
                        myOperator.QueryUpdate("cat_rev_appchecker_rulesreferences", newDatas, RuleFounded);
                    }
                    else
                    {
                        GRule = myOperator.QueryCreate("cat_rev_appchecker_rulesreferences", newDatas);
                    }
                }

                foreach (Pattern onePattern in ElementsXml.Patterns.Pattern)
                {
                    //Mehdi, I think this lambda query may fail and then we add instead of update
                    PatternFounded = resultsPatterns?.Find(x => x.Attributes["cat_name"].ToString() == onePattern.Name);
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_name", onePattern.Name },
                        { "cat_description", onePattern.Description },
                        { "cat_title", onePattern.Title },
                        { "cat_category", new OptionSetValue(onePattern.Category) },
                        { "cat_severity", new OptionSetValue(onePattern.Severity) },
                        { "cat_value", onePattern.Value },
                        { "cat_patterntype", new OptionSetValue(onePattern.PatternType) }
                    };

                    if (PatternFounded != null)
                    {
                        if (tracingService != null) tracingService.Trace($"{onePattern.Name} Pattern found and updating");
                        myOperator.QueryUpdate("cat_pattern", newDatas, PatternFounded);
                        GPattern = PatternFounded.Id;
                    }
                    else
                    {
                        if (tracingService != null) tracingService.Trace($"{onePattern.Name} Pattern not found and creating");
                        GPattern = myOperator.QueryCreate("cat_pattern", newDatas);
                    }

                    if (onePattern.Resources != null)
                    {
                        foreach (ResourceXml OneResource in onePattern.Resources.Resource)
                        {
                            ResourceFounded = resultsResources.Find(x => x.Attributes["cat_url"].ToString() == OneResource.Url);
                            newDatas = new Dictionary<string, object>
                            {
                                { "cat_url", OneResource.Url },
                                { "crfd9_lb_nomressource", OneResource.Title }
                            };

                            EntityReference RessourceRefMain = new EntityReference("cat_pattern", GPattern);
                            newDatas.Add("cat_pattern", RessourceRefMain);

                            if (ResourceFounded != null)
                            {
                                myOperator.QueryUpdate("cat_resource", newDatas, ResourceFounded);
                                GRessource = ResourceFounded.Id;
                            }
                            else
                            {
                                GRessource = myOperator.QueryCreate("cat_resource", newDatas);
                            }
                        }
                    }
                }

                foreach (Pattern onePattern in ElementsXml.Patterns.Pattern)
                {
                    ListToRelate = new List<Guid>();
                    ListToUnRelate = new List<Guid>();
                    xmlFetcher = new FetchXmlFormatter("cat_pattern")
                    {
                        MaxRows = 1
                    };
                    xmlFetcher.AddFieldColumn("cat_patternid");
                    xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                    xmlFetcher.OMyFilter.AddFilter("cat_name", "eq", onePattern.Name);
                    results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                    GPattern = new Guid(results.First().Attributes["cat_patternid"].ToString());

                    foreach (RuleXml oneRulePattern in onePattern.Rules.Rule)
                    {
                        if (oneRulePattern.Name != null)
                        {
                            xmlFetcher = new FetchXmlFormatter("cat_rev_appchecker_rulesreferences")
                            {
                                MaxRows = 1
                            };
                            xmlFetcher.AddFieldColumn("cat_rev_appchecker_rulesreferencesid");
                            xmlFetcher.OMyFilter.StrLogicalOperator = "and";
                            xmlFetcher.OMyFilter.AddFilter("cat_lb_ruleid_ref", "eq", oneRulePattern.Name);
                            results = myOperator.QuerySelect(xmlFetcher.GenerateFetchXmltString());

                            GRule = new Guid(results.First().Attributes["cat_rev_appchecker_rulesreferencesid"].ToString());
                            ListToRelate.Add(GRule);
                        }
                    }

                    ListAfterCheck = ListRulesReferencePatterns.Where(x => x.Attributes["cat_patternid"].ToString() == GPattern.ToString()).ToList();

                    foreach (Entity OneEntity in ListAfterCheck)
                    {
                        ListToUnRelate.Add(new Guid(OneEntity.Attributes["cat_rev_appchecker_rulesreferencesid"].ToString()));
                    }

                    if (ListToUnRelate.Count > 0)
                    {
                        myOperator.QueryUnRelate("cat_Rev_RulesReferences_Patterns", "cat_rev_appchecker_rulesreferences", ListToUnRelate, "cat_pattern", GPattern);
                    }

                    if (ListToRelate.Count > 0)
                    {
                        myOperator.QueryRelate("cat_Rev_RulesReferences_Patterns", "cat_rev_appchecker_rulesreferences", ListToRelate, "cat_pattern", GPattern);
                    }

                }

                Guid GPSetting;
                if (Version == null)
                {
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_settingname", "AppVersion" },
                        { "cat_lb_settingvalue", ElementsXml.Version.ToString() }
                    };

                    GPSetting = myOperator.QueryCreate("cat_rev_settings", newDatas);
                }
                else
                {
                    newDatas = new Dictionary<string, object>
                    {
                        { "cat_lb_settingname", "AppVersion" },
                        { "cat_lb_settingvalue", ElementsXml.Version.ToString() }
                    };

                    myOperator.QueryUpdate("cat_rev_settings", newDatas, Version);
                }

                return true;

            }
            catch (Exception ex)
            {
                if (tracingService != null) tracingService.Trace($"Error in ImportXmlRulesAndPatterns; Message : {ex.Message}");
                return false;
            }
        }
    }
}