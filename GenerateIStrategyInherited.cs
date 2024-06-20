using System;
using System.IO;
using System.Windows.Forms;

namespace CRA.ModelLayer.ACC
{
    internal class GenerateIStrategyInherited
    {
         #region Constructor

        internal GenerateIStrategyInherited(APIdefinition apidef)
        {
            _api = apidef;
            Generate();
        }

         #endregion

        private readonly APIdefinition _api;
        internal string ReturnMessage = "There was an error generating and saving the interface file";

        private void Generate()
        {
            string fileInterfaceName = "IStrategy" + _api.InterfaceStrategyPostfix + ".cs";
            if (File.Exists(APIdefinition.InterfaceStrategyTemplateFile))
            {
                StreamReader sr = new StreamReader(APIdefinition.InterfaceStrategyTemplateFile);
                StreamWriter sw = new StreamWriter(_api.SaveDirectory + @"\" + fileInterfaceName, false);
                string line;
                try
                {
                    //StreamReader sr = new StreamReader(APIdefinition.InterfaceStrategyTemplateFile);
                    //StreamWriter sw = new StreamWriter(_api.SaveDirectory + @"\" + fileInterfaceName, false);
                    //string line;
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
                            // Add using CRA.AgroManagement if used
                        else if (line.Contains("using CRA.ModelLayer.Strategy") & _api.ActEvents)
                            sw.WriteLine("using CRA.AgroManagement;");
                            // Namespace
                        else if (line.Contains("$$namespace$$"))
                            line = line.Replace("$$namespace$$", _api.Namespace);
                        else if (line.Contains("$$classdescription$$"))
                            line = line.Replace("$$classdescription$$", _api.Namespace + " component model interface");
                            // Interface name
                        else if (line.Contains("$$IstrategyComponent$$"))
                            line = line.Replace("$$IstrategyComponent$$", "IStrategy" + _api.InterfaceStrategyPostfix);
                            // Method 
                        else if (line.Contains("$$methodname$$"))
                            line = line.Replace("$$methodname$$", _api.MethodName);
                            // Signature no precondition parameters
                        else if (line.Contains("$$methodsignature$$"))
                        {
                            line = line.Replace("$$methodsignature$$", _api.MethodParameters);
                        }
                            // Parameters description
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
                            // Parameters description tests
                        else if (line.Contains("$$parameterdescriptionstests$$"))
                        {
                            foreach (string k in _api.ParamDescriptionKeys())
                            {
                                string replacement = line;
                                replacement = replacement.Replace("$$parameterdescriptionstests$$",
                                    "/// <param name=" + k + ">" + _api.GetParamDescriptionFor(k) + "</param>");
                                sw.WriteLine(replacement);
                            }
                            write = false;
                        }
                            // Call with no precondition parameters
                        else if (line.Contains("$$methodcall$$"))
                        {
                            string replacement = "(st,";
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
                            // Call tests of pre- post-conditions
                        else if (line.Contains("$$methodcallwithpreconditionsparameters$$"))
                        {
                            string methodTests = _api.MethodParameters;
                            if (methodTests.Contains("ActEvents ae"))
                            {
                                methodTests = methodTests.Replace("ActEvents ae", "string callID");
                            }
                            else
                            {
                                methodTests = methodTests.Replace(")", ", string callID)");
                            }

                            line = line.Replace("$$methodcallwithpreconditionsparameters$$", methodTests);
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
                throw new Exception("The file " + APIdefinition.InterfaceStrategyTemplateFile +
                                    " provided in the ACC installation is no longer available in the execution directory.");
            }
            ReturnMessage = "File " + fileInterfaceName + " saved!";
        }
    }
}
