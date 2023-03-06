using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.PowerPlatform.Formulas.Tools;
using System.Text.RegularExpressions;

namespace ParserTester
{

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
            List<AutoFailPattern> PatternsToCheck = new List<AutoFailPattern>();
            PatternsToCheck.Add(new AutoFailPattern("app-CheckForNplusOneCalls", true));
            PatternsToCheck.Add(new AutoFailPattern("app-FormulaOptimization-NestedFilter", true));
            PatternsToCheck.Add(new AutoFailPattern("app-FormulaOptimization-Patch", true));
            PatternsToCheck.Add(new AutoFailPattern("app-FormulaOptimization-FirstFilter", true));
            PatternsToCheck.Add(new AutoFailPattern("app-FormulaOptimization-UseStartsWith", true));

            PatternsToCheck.Add(new AutoFailPattern("app-FormulaOptimization-NestedApiCalls", true));
            PatternsToCheck.Add(new AutoFailPattern("app-CodeReadability", true));
            PatternsToCheck.Add(new AutoFailPattern("app-ErrorHandling", true));
            PatternsToCheck.Add(new AutoFailPattern("app-DataLoadingStrategy", true));
            PatternsToCheck.Add(new AutoFailPattern("app-ConcurrentCall", false, "Code review tool : This app does not does not make use of Concurrent function. Please consider use it to ensure external database or API requests are performed in parallel."));

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
            char[] formulaschars = { '=', '>', '<', '&', '|', '+', ' ' ,'\r', '\n', '\t' };

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
        static string CustomStripComments(string code)
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

            code =Regex.Replace(code,
    blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
    me => {
        if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
            return me.Value.StartsWith("//") ? Environment.NewLine : "";
        // Keep the literal strings
        return me.Value;
    },
    RegexOptions.Singleline);

            return code;
        }
        

        static string StripComments(string code)
        {
           // var re = @"\/\*[\s\S]*?\*\/|([^:]|^)\/\/.*$";
            
            var re = @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/";
            //var re = @"(//[\t|\s|\w|\d|\.]*[\r\n|\n])|([\s|\t]*/\*[\t|\s|\w|\W|\d|\.|\r|\n]*\*/)|(\<[!%][ \r\n\t]*(--([^\-]|[\r\n]|-[^\-])*--[ \r\n\t%]*)\>)";
            code = Regex.Replace(code, "<svg(.|\n)*?</svg>", "svg image");

            //Regex myreg = new Regex(re);

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
                Console.WriteLine(ex.Message);
            }


        }

        private void SearchNplusOneCalls()
        {

            List<string> ListNPlus = PowerAppsParser.getListFunctions("nplusun");
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

            List<string> ListNestedIf = getListFunctions("nestingFunctions");
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

            List<string> ListLoadingFunctions = PowerAppsParser.getListFunctions("LoadingFunctions");
            List<string> ListLocalFunction = new List<string>();

            if (this.IndiceScreen == 0)
            {
                List<string> ListNavigationFunctions = PowerAppsParser.getListFunctions("Navigation");

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

            List<string> ListNestedOut = getListFunctions("concurrentTrackedFunction");
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

            ListPatchOut = this.ListFunctions.Flatten(FunctionNesting => FunctionNesting.Parameters)
                            .Where(FunctionsPatch => FunctionsPatch.ElementType == "Function" && FunctionsPatch.ElementName == "Patch")
                                .Flatten(FunctionNested => FunctionNested.Parameters)
                                .Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false)
                    .ToList();

            if (ListPatchOut.Count > 0)
            {
                ListIfError = this.ListFunctions
                    .Flatten(FunctionsPatch => FunctionsPatch.Parameters).Where(FunctionsPatch => FunctionsPatch.ElementType == "Function" && FunctionsPatch.ElementName == "IfError").ToList();


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
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Patch functions on external datasources. Consider using IfError() to implement error handling", "app-ErrorHandling", this.NameControl));
            }

        }


        private void SearchNestedFilters()
        {

            List<string> ListNestedOut = getListFunctions("nestedSearchout");
            List<string> ListNestedIn = getListFunctions("nestedSearchin");
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
                //.Flatten(DatasourceExt => DatasourceExt.Parameters).Where(DatasourceExt => DatasourceExt.ElementType == "Datasource" && DatasourceExt.IsLocal == false).ToList());
            }


            if (ListKo2.Count > 0)
            {
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool : Nested search operations found. Consider not using Filter/Search targeting external datasources inside another Filter/ForAll/Search", "app-FormulaOptimization-NestedFilter", this.NameControl));
            }

        }

        private void SearchnestedApiCalls()
        {
            //app-FormulaOptimization-NestedApiCalls
            List<string> ListNestedOut = PowerAppsParser.getListFunctions("nestedCallout");
            List<string> ListNestedIn = PowerAppsParser.getListFunctions("nestedCallin");
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

            List<string> ListPatch = PowerAppsParser.getListFunctions("patch");
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
                this.ListOfFails.Add(new CodeFail(this.CodeCleanedProperty, "Code review tool :Additional API calls found within a Patch statement. Consider not refactoring out the API Call from the Patch", "app-FormulaOptimization-Patch", this.NameControl));
            }


        }

        private void SearchFirstFilter()
        {

            List<string> ListFirst = PowerAppsParser.getListFunctions("first");
            List<string> ListFFilter = PowerAppsParser.getListFunctions("firstfilter");
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

        public static List<string> getListFunctions(string typeFunctions)
        {
            List<string> RetLst = new List<string>();
            switch (typeFunctions)
            {
                case "nestedSearchin":
                    RetLst.Add("Filter");
                    RetLst.Add("Search");
                    RetLst.Add("LookUp");
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
                case "Navigation":
                    RetLst.Add("Navigate");
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

            }

            return RetLst;
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


}
