using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CRA.ModelLayer.ACC
{
    internal delegate void ParamsDescriptionChangedHandler(APIdefinition aPIdefinition);

    public class APIdefinition
    {
        #region Events

        internal event ParamsDescriptionChangedHandler ParamsDescriptionChanged;
        internal event ParamsDescriptionChangedHandler ActEventsChanged;
        internal event ParamsDescriptionChangedHandler MethodParametersChanged;

        #endregion Events

        #region Fields

        internal const string InterfaceStrategyTemplateFile = "TemplateIStrategyComponent.txt";
        internal const string APITemplateFile = "TemplateAPI.txt";
        internal const string TraceHelperTemplateFile = "TemplateTraceHelper.txt";
        internal const string AuthorSettings = "AuthorSettings.xml";

        internal string Namespace;
        internal string SaveDirectory;

        internal string InterfaceStrategyPostfix;
        internal string MethodName;
        private string _MethodParameters;
        private Dictionary<string, KeyValuePair<string, string>> ParamDescriptions = new Dictionary<string, KeyValuePair<string, string>>();
        private Dictionary<string, string> ClassDescriptions = new Dictionary<string, string>();
        private bool _ActEvents;
        internal List<string> DomainClasses = new List<string>();

        internal string AuthorNameLastname;
        internal string Email;
        internal string Institution;
        internal string URL;
        internal DataSet AuthorData = new DataSet();
        internal DataSet ACCDefinitions = new DataSet();

        private bool changeEventsOnMethodParameters = true;
        internal bool signatureAlreadyChanging = false;

        #endregion

        #region Constructor

        internal APIdefinition()
        {
            string path = String.Empty;
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            //    path = ad.DataDirectory + @"\";
            //}
            if (File.Exists(path + AuthorSettings))
            {
                // Load Author data
                AuthorData.ReadXml(AuthorSettings);
                AuthorNameLastname = AuthorData.Tables[0].Rows[0][0].ToString();
                Email = AuthorData.Tables[0].Rows[0][1].ToString();
                Institution = AuthorData.Tables[0].Rows[0][2].ToString();
                URL = AuthorData.Tables[0].Rows[0][3].ToString();
                // DataSet to save validation
                ACCDefinitions.Tables.Add("AuthorData");
                ACCDefinitions.Tables["AuthorData"].Columns.Add("AuthorNameLastname");
                ACCDefinitions.Tables["AuthorData"].Columns.Add("Email");
                ACCDefinitions.Tables["AuthorData"].Columns.Add("Date");
                ACCDefinitions.Tables.Add("Definitions");
                ACCDefinitions.Tables["Definitions"].Columns.Add("Field");
                ACCDefinitions.Tables["Definitions"].Columns.Add("Value");
                ACCDefinitions.Tables.Add("DomainClasses");
                ACCDefinitions.Tables["Definitions"].Columns.Add("ClassName");
                ACCDefinitions.Tables["Definitions"].Columns.Add("Instance");
                ACCDefinitions.Tables["Definitions"].Columns.Add("Description");
            }

            ParamsDescriptionChanged += APIdefinitionParamsDescriptionChanged;
            ActEventsChanged += APIdefinitionParamsDescriptionChanged;
        }

        private void APIdefinitionParamsDescriptionChanged(APIdefinition aPIdefinition)
        {
            changeEventsOnMethodParameters = false;
            MethodParameters = GetNewSignature();
            changeEventsOnMethodParameters = true;
        }

        internal string GetNewSignature()
        {
            StringBuilder stringBuilder = new StringBuilder("(");
            string space = "";
            foreach (var kvp in ParamDescriptions)
            {
                stringBuilder.Append(space).Append(kvp.Value.Value).Append(" ").Append(kvp.Key);
                space = ", ";
            }
            if (_ActEvents)
            {
                stringBuilder.Append(space).Append("ActEvents ae");
            }
            stringBuilder.Append(");");
            return stringBuilder.ToString();
        }

        private Dictionary<string, string> _ParseSignature(string signature, string oldSignature)
        {
            if (!signature.Trim().StartsWith("(")) throw new SignatureParsingException("The signature must start with (", oldSignature);
            if (!signature.Trim().EndsWith(";"))
            {
                throw new SignatureParsingException("The signature must end with );", oldSignature);
            }
            else
            {
                string temp = signature.Trim();
                temp = temp.Substring(0, temp.LastIndexOf(";"));
                if (!temp.Trim().EndsWith(")")) throw new SignatureParsingException("The signature must end with );", oldSignature);
            }

            string newSignature = signature.Trim();
            newSignature = newSignature.Substring(0, newSignature.LastIndexOf(";"));
            newSignature = newSignature.Substring(newSignature.IndexOf("(") + 1);
            newSignature = newSignature.Trim();
            newSignature = newSignature.Substring(0, newSignature.LastIndexOf(")"));

            string[] parameters = newSignature.Split(new char[] { ',' });
            Dictionary<string, string> parametersDictionary = new Dictionary<string, string>();
            if (parameters.Length == 1 && parameters[0].Trim().Equals("")) return parametersDictionary;

            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");

            foreach (var kvp in parameters)
            {
                string[] parameterCouple = kvp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parameterCouple.Length != 2) throw new SignatureParsingException(kvp + " is not a valid parameter declaration", oldSignature);
                string className = parameterCouple[0].Trim();
                string paramName = parameterCouple[1].Trim();
                if (!provider.IsValidIdentifier(className)) throw new SignatureParsingException(className + " is not a valid identifier", oldSignature);
                if (!DomainClasses.Contains(className) && (!className.Equals("ActEvents"))) throw new SignatureParsingException(className + " is not one of the selected Domain Classes", oldSignature);
                if (!provider.IsValidIdentifier(paramName)) throw new SignatureParsingException(paramName + " is not a valid identifier", oldSignature);
                if (parametersDictionary.ContainsKey(paramName)) throw new SignatureParsingException(paramName + " is a duplicated identifier", oldSignature);
                parametersDictionary.Add(paramName, className);
            }

            return parametersDictionary;
        }

        internal string MethodParameters
        {
            get
            {
                return _MethodParameters;
            }
            set
            {
                if (signatureAlreadyChanging) return;
                signatureAlreadyChanging = true;
                string oldValue = _MethodParameters;
                string newValue = value;
                Dictionary<string, string> newDictionary = _ParseSignature(newValue, oldValue);
                var kvp = newDictionary.Where(x => x.Value.Equals("ActEvents")).LastOrDefault();
                bool _OldActEvents = _ActEvents;
                if (kvp.Key != null)
                {
                    newDictionary.Remove(kvp.Key);
                    ActEvents = true;
                }
                else
                {
                    ActEvents = false;
                }
                _MethodParameters = value;
                ParamDescriptions = newDictionary.ToDictionary(kv => kv.Key, kv => new KeyValuePair<string, string>(ClassDescriptions[kv.Value], kv.Value));
                if (changeEventsOnMethodParameters) MethodParametersChanged?.Invoke(this);
                signatureAlreadyChanging = false;
            }
        }

        internal bool ActEvents
        {
            get
            {
                return _ActEvents;
            }
            set
            {
                _ActEvents = value;
                ActEventsChanged?.Invoke(this);
            }
        }

        #region Class Description

        internal void AddClassDescription(string className, string description)
        {
            ClassDescriptions.Add(className, description);
        }

        internal void ClearClassDescriptions()
        {
            ClassDescriptions = new Dictionary<string, string>();
        }

        internal IEnumerable<string> ClassDescriptionKeys()
        {
            return ClassDescriptions.Keys;
        }

        internal string GetClassDescriptionFor(string className)
        {
            return ClassDescriptions[className];
        }

        internal bool RemoveClassDescriptionFor(string className)
        {
            return ClassDescriptions.Remove(className);
        }

        #endregion Class Description

        #region Param Description

        internal void AddParamDescription(string instanceName, string description, string className)
        {
            ParamDescriptions.Add(instanceName, new KeyValuePair<string, string>(description, className));
            ParamsDescriptionChanged?.Invoke(this);
        }

        internal void ClearParamDescriptions()
        {
            ParamDescriptions = new Dictionary<string, KeyValuePair<string, string>>();
            ParamsDescriptionChanged?.Invoke(this);
        }

        internal IEnumerable<string> ParamDescriptionKeys()
        {
            return ParamDescriptions.Keys;
        }

        internal string GetParamDescriptionFor(string instanceName)
        {
            return ParamDescriptions[instanceName].Key;
        }

        internal string GetParamClassFor(string instanceName)
        {
            return ParamDescriptions[instanceName].Value;
        }

        internal bool RemoveParamDescriptionFor(string instanceName)
        {
            bool removed = ParamDescriptions.Remove(instanceName);
            if (removed) ParamsDescriptionChanged?.Invoke(this);
            return removed;
        }

        #endregion Param Description

        #endregion


    }
}
