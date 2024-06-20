using System;
using System.IO;
using System.Windows.Forms;

namespace CRA.ModelLayer.ACC
{
    internal class GenerateTraceHelper
    {
        #region Constructor

        internal GenerateTraceHelper(APIdefinition apidef)
        {
            _api = apidef;
            Generate();
        }

        #endregion

        private readonly APIdefinition _api;
        internal string ReturnMessage = "There was an error generating and saving the Trace helper file";

        private void Generate()
        {
            string fileTraceName = "TraceHelper.cs";
            if (File.Exists(APIdefinition.TraceHelperTemplateFile))
            {
                StreamReader sr = new StreamReader(APIdefinition.TraceHelperTemplateFile);
                StreamWriter sw = new StreamWriter(_api.SaveDirectory + @"\" + fileTraceName, false);
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
                        else if (line.Contains("$$namespace$$"))
                            line = line.Replace("$$namespace$$", _api.Namespace);
                       
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
                throw new Exception("The file " + APIdefinition.TraceHelperTemplateFile +
                                    " provided in the ACC installation is no longer available in the execution directory.");
            }
            ReturnMessage = "File " + fileTraceName + " saved!";
        }
    }
}
