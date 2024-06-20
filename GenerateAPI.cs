using System;
using System.IO;
using System.Windows.Forms;

namespace CRA.ModelLayer.ACC
{
    internal class GenerateAPI
    {
        #region Constructor

        internal GenerateAPI(APIdefinition apidef)
        {
            _api = apidef;
            Generate();
        }

        #endregion

        private readonly APIdefinition _api;
        internal string ReturnMessage = "There was an error generating and saving the API file";

        private void Generate()
        {
            string fileApiName = _api.Namespace;
            if (fileApiName.Contains(".Interfaces")) fileApiName = fileApiName.Replace(".Interfaces", String.Empty);
            int pos1 = fileApiName.LastIndexOf(".");
            fileApiName = fileApiName.Substring(pos1 + 1) + "API.cs";
            if (File.Exists(APIdefinition.APITemplateFile))
            {
                    StreamReader sr = new StreamReader(APIdefinition.APITemplateFile);
                    StreamWriter sw = new StreamWriter(_api.SaveDirectory + @"\" + fileApiName, false);
                    string line;
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        bool write = true;
                        // Author's data
                        if (line.Contains("$$author$$")) line = line.Replace("$$author$$", _api.AuthorNameLastname);
                        else if (line.Contains("$$email$$")) line = line.Replace("$$email$$", _api.Email);
                        else if (line.Contains("$$institution$$"))
                            line = line.Replace("$$institution$$", _api.Institution);
                        else if (line.Contains("$$url$$")) line = line.Replace("$$url$$", _api.URL);
                        else if (line.Contains("$$date$$")) line = line.Replace("$$date$$", DateTime.Now.ToString());
                        else if (line.Contains("using CRA.ModelLayer.Core") & _api.ActEvents)
                            sw.WriteLine("using CRA.AgroManagement;");
                        else if (line.Contains("$$namespace$$"))
                            line = line.Replace("$$namespace$$", _api.Namespace);
                        else if (line.Contains("$$classdescription$$"))
                            line = line.Replace("$$classdescription$$", _api.Namespace + " component API");
                        else if (line.Contains("$$methodname$$"))
                            line = line.Replace("$$methodname$$", _api.MethodName);
                        // Signature no precondition parameters
                        else if (line.Contains("$$methodsignature$$"))
                        {
                            /* DFa - 11/6/2014 - begin */
                            /* old - begin */
                            //string signatureAPI = "(IStrategy" + _api.InterfaceStrategyPostfix + " st," +
                            //                      _api.MethodParameters.Substring(1);
                            /* old - end */
                            string signatureAPI = "(IStrategy" + _api.InterfaceStrategyPostfix + " st," +
                                                  _api.MethodParameters.Substring(1).Replace(";", "");
                            /* DFa - 11/6/2014 - end */
                            line = line.Replace("$$methodsignature$$", signatureAPI);
                        }
                        // Signature with precondition parameters
                        else if (line.Contains("$$methodsignaturewithpreconditionsparameters$$"))
                        {
                            /* DFa - 11/6/2014 - begin */
                            /* old - begin */
                            //string signatureAPI = "(IStrategy" + _api.InterfaceStrategyPostfix + " st," +
                            //                      _api.MethodParameters.Substring(1, _api.MethodParameters.Length-3) 
                            //                      + ", bool saveLog, string callID);";
                            /* old - end */
                            string signatureAPI = "(IStrategy" + _api.InterfaceStrategyPostfix + " st," +
                                                  _api.MethodParameters.Substring(1, _api.MethodParameters.Length - 3)
                                                  + ", bool saveLog, string callID)";
                            /* DFa - 11/6/2014 - end */
                            line = line.Replace("$$methodsignaturewithpreconditionsparameters$$", signatureAPI);
                        }
                        else if (line.Contains("$$APIclassname$$"))
                        {
                            string clsName = _api.Namespace;
                            if (clsName.Contains(".Interfaces")) clsName = clsName.Replace(".Interfaces", "");
                            int pos = clsName.LastIndexOf(".");
                            clsName = clsName.Substring(pos + 1) + "API";
                            pos = clsName.IndexOf(".");
                            clsName = clsName.Substring(pos + 1);
                            line = line.Replace("$$APIclassname$$",
                                clsName);
                        }
                        // It will replace twice
                        else if (line.Contains("$$parameterdescriptions$$"))
                        {
                            foreach (string k in _api.ParamDescriptionKeys())
                            {
                                string replacement = line;
                                replacement = replacement.Replace("$$parameterdescriptions$$",
                                    "/// <param name=" + k + ">" + _api.GetParamDescriptionFor(k) + "</param>");
                                sw.WriteLine(replacement);
                            }
                            if (_api.ActEvents)
                            {
                                string replacement = line.Replace("$$parameterdescriptions$$",
                                    "/// <param name=ae>AgroManagement objects of impact parameters</param>");
                                sw.WriteLine(replacement);
                            }
                            write = false;
                        }
                        // Call with no precondition parameters
                        else if (line.Contains("$$methodcall$$"))
                        {
                            /* DFa - 11/6/2014 - begin */
                            /* old - begin */
                            //string replacement ="(st,";
                            /* old - end */
                            string replacement = "(";
                            /* DFa - 11/6/2014 - end */
                            foreach (string k in _api.ParamDescriptionKeys())
                            {
                                replacement += " " + k + ",";
                            }
                            if (_api.ActEvents) replacement += " ae);";
                            else replacement = replacement.Substring(0, replacement.Length - 1) + ");";
                            replacement = line.Replace("$$methodcall$$", replacement);
                            sw.WriteLine(replacement);
                            write = false;
                        }
                        // Call with precondition parameters
                        else if (line.Contains("$$methodcallwithpreconditionsparameters$$"))
                        {
                            /* DFa - 11/6/2014 - begin */
                            /* old - begin */
                            //string replacement = "(st,";
                            /* old - end */
                            string replacement = "(";
                            /* DFa - 11/6/2014 - end */
                            foreach (string k in _api.ParamDescriptionKeys())
                            {
                                replacement += " " + k + ",";
                            }
                            replacement = replacement + " callID);";
                            replacement = line.Replace("$$methodcallwithpreconditionsparameters$$", replacement);
                            sw.WriteLine(replacement);
                            write = false;
                        }

                        if (write)
                        {
                            sw.WriteLine(line);
                        }
                    }
                sw.Flush();
                }
                catch (Exception e)
                {
                    /* DFa - if the exception is managed this way, real causes of it are completely hidden by a non-informative message */
                    MessageBox.Show("There was an error while generating code. \t\nThe most likely cause is that method parameters where wrongly hand-editing. \t\nReset domain classes and try again.",
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /* DFa - 19/06/2014 - begin */
                finally
                {
                    sw.Close();
                }
                /* DFa - 19/06/2014 - end */
            }
            else
            {
                throw new Exception("The file " + APIdefinition.APITemplateFile +
                                    " provided in the ACC installation is no longer available in the execution directory.");
            }
            ReturnMessage = "File " + fileApiName + " saved!";
        }
    }
}
