using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRA.ModelLayer.ACC
{
    public partial class ACC : Form
    {
        public ACC()
        {
            Api = new APIdefinition();
            Api.MethodParametersChanged += Api_MethodParametersChanged;
            if (File.Exists("Lutil.lsf"))
            {
                MLLicense fr = new MLLicense(Api);
                fr.ShowDialog();
            }
            InitializeComponent();
        }

        private void Api_MethodParametersChanged(APIdefinition aPIdefinition)
        {
            txtParameters.Text = aPIdefinition.MethodParameters;
        }

        internal APIdefinition Api;

        private void btnHelp_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox(Api);
            ab.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadDomainClasses_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"C# Domain Classes | *.cs";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bool idomainclass = false;
                string dnamespace = String.Empty;
                string DomainClassName = openFileDialog1.FileName;
                /* DFa - 5/6/2014 - potentially the class name can be different from the file name but this case is not managed */
                int pos = DomainClassName.LastIndexOf(@"\");
                DomainClassName = DomainClassName.Substring(pos + 1);
                pos = DomainClassName.LastIndexOf(".");
                DomainClassName = DomainClassName.Substring(0, pos);
                /* DFa - 5/6/2014 - begin */
                /* if ActEvents is managed via CheckBox, having a Domain Class with the same name will surely mess up things - later */
                //if (DomainClassName.Trim().Equals("ActEvents")) throw new Exception("Cannot add a Domain Class named ActEvents");
                /* DFa - 5/6/2014 - end */
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Get namespace
                        if (line.Contains("namespace"))
                        {
                            dnamespace = line.Replace("namespace", String.Empty);
                            if (dnamespace.Contains("{"))
                            {
                                dnamespace = dnamespace.Replace("{", String.Empty);
                            }
                            dnamespace = dnamespace.Trim();
                        }
                        // Get class description
                        if (line.Contains("<summary>"))
                        {
                            if (line.Contains("<summary>") && line.Contains("</summary>")) // Class description on same line
                            {
                                int pos1 = line.IndexOf(">");
                                int pos2 = line.LastIndexOf("<");
                                // Extract Domain Class description
                                line = line.Substring(pos1 + 1, (line.Length - pos1) - (line.Length - pos2) - 1);
                                Api.AddClassDescription(DomainClassName, line);
                            }
                            else // Class description on 3 lines
                            {
                                line = sr.ReadLine();
                                // Extract Domain Class descritption
                                Api.AddClassDescription(DomainClassName, line.Substring(5));
                            }
                        }
                        // Check if IDomainClass is implemented
                        if (line.Contains("IDomainClass"))
                        {
                            idomainclass = true;
                            break;
                        }
                        
                    }
                }
                
                if (idomainclass)
                {
                    // Adds to list box (event synchronize Api)
                    listBox1.Items.Add(DomainClassName);
                    // Adds to label
                    lblNamespace.Text = dnamespace;
                    Api.DomainClasses.Add(DomainClassName);
                }
                else
                {
                    throw new Exception("The file selected is not a domain class\t\n (it does not realize CRA.ModelLayer.Strategy.IDomainClass");
                }
            }
            
        }


        #region Synchronize with instance of APIdefinition

        private void lblNamespace_TextChanged(object sender, EventArgs e)
        {
            Api.Namespace = lblNamespace.Text;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /* DFa 4/6/2014 - begin */
            /* old - begin */
            string cls = listBox1.SelectedItem.ToString();
            string comma = String.Empty;
            int length = txtParameters.Text.Length;
            if (length != 3) // Initial conditions
                comma = ",";
            string inst = cls.Substring(0, 1).ToLower();

            /* DFa - 5/6/2014 - begin - TEMPORARY (see DFa - 17/6/2014 comment) - case where inst is last parameter not managed.
             More generally, if there are more than 2 Domain Classes with same initial letter this crashes anyway.
             added method to derive new name */
            /* old - begin */
            //if (txtParameters.Text.Contains(inst + ","))
            //    inst = inst + "1"; // for two instances of the same class
            /* old - end */
            if (Api.ParamDescriptionKeys().Contains(inst))
            {
                int i = 1;
                while (Api.ParamDescriptionKeys().Contains(inst + i)) i++;
                inst = inst + i;
            }
            /* DFa - 5/6/2014 - end */

            /* DFa - 17/6/2014
             * 1 - changing parameters names in the editable txtParameters does not affect the signature produced.
             * This because changes in the text are not reflected in changes in the internal dictionary representing
             * parameters names and types (Api.ParamDescriptions)
             * 
             * 2 - txtParameters text is changed in response of GUI events instead of in response of
             * changes in Api.ParamDescriptions. This can result in disalignment
             * between the textual representation and the internal dictionary, as in the following use case:
             * 
             * a - A domain class is selected in listBox1, a new parameter appears in the signature.
             * b - The user checks "ActEvents" by mistake, a new parameter (ae) is added in the signature.
             * c - Another domain class is selected in listBox1, a new parameter appears in the signature.
             * d - The user unchecks "ActEvents".
             * 
             * At this point, the signature's textual representation is completely broken.
             * 
             * 3 - to solve the last 2 points, an MVC architecture should be put in place, with Api.ParamDescriptions
             * acting as the Model and txtParameters acting as the View. Changes in the txtParameters should only
             * occur in response to changes in Api.ParamDescriptions, and if editing is performed manually (as for
             * example changing a parameter name), this should first result in a change in Api.ParamDescriptions (on lost focus) that
             * then triggers the real change in txtParameters. This allows for example to check for parameters name duplication and 
             * other checks before accepting the change.
             * 
             * Methods (not finished yet) to be used in this case are added but commented with DFa - MVC
             */
            //txtParameters.Text = txtParameters.Text.Substring(0, length - 2) + comma
            //                     + " " + cls + " "
            //                     + inst + ");";
            // Pair the name of the instance to the class description, for <summary> comment on code generation
            Api.AddParamDescription(inst, Api.GetClassDescriptionFor(cls), cls);
            //Api.MethodParameters = txtParameters.Text;
            /* old - end */
            /* DFa - MVC - begin */
            //string cls = listBox1.SelectedItem.ToString();
            //Api.ParamDescriptions = _GetNewParametersDictionary(Api.ParamDescriptions, cls);
            //Api.MethodParameters = _GetMethodSignature(Api.ParamDescriptions);
            //txtParameters.Text = Api.MethodParameters;
            /* DFa - MVC - end */
            /* DFa 4/6/2014 - end */
        }

        /* DFa 4/6/2014 - begin */
        /* DFa - MVC - begin */
        //private Dictionary<string, string> _GetNewParametersDictionary(Dictionary<string, string> parameters, string newClassName)
        //{
        //    return _GetNewParametersDictionary(parameters, newClassName, newClassName.Substring(0, 1).ToLower());
        //}

        //private Dictionary<string, string> _GetNewParametersDictionary(Dictionary<string, string> parameters, string newClassName, string parameterName)
        //{
        //    if (!parameters.Keys.Contains(parameterName))
        //    {
        //        parameters.Add(parameterName, newClassName);
        //    }
        //    else
        //    {
        //        int i = 1;
        //        while (parameters.Keys.Contains(parameterName + i)) i++;
        //        parameters.Add(parameterName + i, newClassName);
        //    }
        //    return parameters;
        //}

        //private string _GetMethodSignature(Dictionary<string, string> parameters)
        //{
        //    StringBuilder builder = new StringBuilder("(");
        //    int i = 0;
        //    foreach (var kvp in parameters)
        //    {
        //        builder.Append(kvp.Value).Append(" ").Append(kvp.Key);
        //        i++;
        //        if (i < parameters.Count - 1)
        //        {
        //            builder.Append(", ");
        //        }
        //    }
        //    builder.Append(");");
        //    return builder.ToString();
        //}

        //private Dictionary<string, string> _ParseSignature(string signature)
        //{
        //    if (!signature.Trim().StartsWith("(")) throw new SignatureParsingException("The signature must start with (");
        //    if (!signature.Trim().EndsWith(";"))
        //    {
        //        throw new SignatureParsingException("The signature must end with );");
        //    }
        //    else
        //    {
        //        string temp = signature.Trim();
        //        temp = temp.Substring(0, temp.LastIndexOf(";"));
        //        if (!temp.Trim().EndsWith(")")) throw new SignatureParsingException("The signature must end with );");
        //    }

        //    string newSignature = signature.Trim();
        //    newSignature = newSignature.Substring(0, newSignature.LastIndexOf(";"));
        //    newSignature = newSignature.Substring(newSignature.IndexOf("(") + 1);
        //    newSignature = signature.Trim();
        //    newSignature = newSignature.Substring(0, newSignature.LastIndexOf(")"));

        //    string[] parameters = newSignature.Split(new char[] { ',' });
        //    Dictionary<string, string> parametersDictionary = new Dictionary<string, string>();

        //    CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");

        //    foreach (var kvp in parameters)
        //    {
        //        string[] parameterCouple = kvp.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        //        if (parameterCouple.Length != 2) throw new SignatureParsingException(kvp + " is not a valid parameter declaration");
        //        string className = parameterCouple[0].Trim();
        //        string paramName = parameterCouple[1].Trim();
        //        if (provider.IsValidIdentifier(className)) throw new SignatureParsingException(className + " is not a valid identifier");
        //        if (!Api.DomainClasses.Contains(className) && (!className.Equals("ActEvents"))) throw new SignatureParsingException(className + " is not one of the selected Domain Classes");
        //        if (provider.IsValidIdentifier(paramName)) throw new SignatureParsingException(paramName + " is not a valid identifier");
        //        if (parametersDictionary.ContainsKey(paramName)) throw new SignatureParsingException(paramName + " is a duplicated identifier");
        //        parametersDictionary.Add(paramName, className);
        //    }

        //    return parametersDictionary;
        //}

        /* DFa - MVC - end */

        /* DFa 4/6/2014 - end */
        
        private void chkIncludeAgromanagementActEvents_CheckedChanged(object sender, EventArgs e)
        {
            Api.ActEvents = chkIncludeAgromanagementActEvents.Checked;
        }

        #endregion

        private void btnResetDomainClasses_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //txtParameters.Text = "();";
            Api.DomainClasses.Clear();
            Api.ClearClassDescriptions();
            Api.ClearParamDescriptions();
            Api.MethodParameters = "();";
            this.chkIncludeAgromanagementActEvents.Checked = false;
            lblNamespace.Text = String.Empty;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {           
            Validate val = new Validate(Api);
            if (val.ValidationSuccess == ModelLayer.ACC.Validate.ValidationResult.Ok)
            {
                string SuccessMessage = String.Empty;

                folderBrowserDialog1.ShowDialog();
                Api.SaveDirectory = folderBrowserDialog1.SelectedPath;
                SuccessMessage = "Class files were saved at:\t\n" +
                                 Api.SaveDirectory + "\t\n\t\n";

                GenerateAPI gapi = new GenerateAPI(Api);
                SuccessMessage += gapi.ReturnMessage;

                GenerateIStrategyInherited ginhe = new GenerateIStrategyInherited(Api);
                SuccessMessage += "\t\n" + ginhe.ReturnMessage;

                GenerateTraceHelper gtrhe = new GenerateTraceHelper(Api);
                SuccessMessage += "\t\n" + gtrhe.ReturnMessage;

                MessageBox.Show(SuccessMessage, "Source code saved!", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(val.ReturnMessage, "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeveloper_Click(object sender, EventArgs e)
        {
            DeveloperData dd = new DeveloperData(Api);
            dd.ShowDialog();
        }

        private void txtIStrategyPostfix_TextChanged(object sender, EventArgs e)
        {
            Api.InterfaceStrategyPostfix = txtIStrategyPostfix.Text;
        }

        private void cmbMainMethod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMainMethod.SelectedItem != null)
                {
                    Api.MethodName = cmbMainMethod.SelectedItem.ToString();
                }
            }
            catch
            {
                if (dataSetACCDefinitions.Tables["Specifications"].Rows.Count > 0)
                {
                    Api.MethodName =
                        dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_MainMethod"].ToString();
                }
            }
        }
        

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            // Clean dataset values
            dataSetACCDefinitions.Tables["Specifications"].Rows.Clear();
            dataSetACCDefinitions.Tables["DomainClasses"].Rows.Clear();
            // Set filename
            saveFileDialog1.Filter = "ACC - API definition file |*.xml";
            saveFileDialog1.Title = "(Save API definiton file name)";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblXMLFileName.Text = saveFileDialog1.FileName;
                // Get values from controls
                DataRow dr = dataSetACCDefinitions.Tables["Specifications"].NewRow();
                dr["Col_FileName"] = lblXMLFileName.Text;
                dr["Col_Postfix"] = txtIStrategyPostfix.Text;
                dr["Col_MainMethod"] = cmbMainMethod.Text;
                dr["Col_MethodParameters"] = txtParameters.Text;
                dr["Col_NameSpace"] = lblNamespace.Text;
                dataSetACCDefinitions.Tables["Specifications"].Rows.Add(dr);

                foreach (object t in listBox1.Items)
                {
                    dr = dataSetACCDefinitions.Tables["DomainClasses"].NewRow();
                    dr["Col_ClassFileNames"] = t.ToString();
                    dataSetACCDefinitions.Tables["DomainClasses"].Rows.Add(dr);
                }

                foreach (string key in Api.ClassDescriptionKeys())
                {
                    dr = dataSetACCDefinitions.Tables["ClassDescriptions"].NewRow();
                    dr["ClassName"] = key;
                    dr["ClassDescription"] = Api.GetClassDescriptionFor(key);
                    dataSetACCDefinitions.Tables["ClassDescriptions"].Rows.Add(dr);
                }

                foreach (string key in Api.ParamDescriptionKeys())
                {
                    dr = dataSetACCDefinitions.Tables["ParamDescriptions"].NewRow();
                    dr["ParamName"] = key;
                    dr["ClassDescription"] = Api.GetParamDescriptionFor(key);
                    dr["ClassName"] = Api.GetParamClassFor(key);
                    dataSetACCDefinitions.Tables["ParamDescriptions"].Rows.Add(dr);
                }

                dataSetACCDefinitions.WriteXml(lblXMLFileName.Text);
                MessageBox.Show("File " + lblXMLFileName.Text + " saved!");
            }
        }

        private void btnOpenACCDefinition_Click(object sender, EventArgs e)
        {
            // open dialog
            openFileDialog1.Filter = "ACC - API definition file |*.xml";
            openFileDialog1.Title = "(Save API definiton file name)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    listBox1.Items.Clear();
                    Api.DomainClasses = new List<string>();
                    Api.ClearClassDescriptions();
                    Api.ClearParamDescriptions();
                    // Clean dataset values
                    dataSetACCDefinitions.Tables["Specifications"].Rows.Clear();
                    dataSetACCDefinitions.Tables["DomainClasses"].Rows.Clear();
                    dataSetACCDefinitions.Tables["ClassDescriptions"].Rows.Clear();
                    dataSetACCDefinitions.Tables["ParamDescriptions"].Rows.Clear();
                    dataSetACCDefinitions.ReadXml(openFileDialog1.FileName);
                    // set values to controls
                    lblXMLFileName.Text = dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_FileName"].ToString();
                    txtIStrategyPostfix.Text = dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_Postfix"].ToString();
                    cmbMainMethod.Text = dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_MainMethod"].ToString();
                    txtParameters.Text = dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_MethodParameters"].ToString();
                    lblNamespace.Text = dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_NameSpace"].ToString();

                    foreach (DataRow r in dataSetACCDefinitions.Tables["DomainClasses"].Rows)
                    {
                        Api.DomainClasses.Add(r[0].ToString());
                    }

                    foreach (DataRow r in dataSetACCDefinitions.Tables["ClassDescriptions"].Rows)
                    {
                        string key = r["ClassName"].ToString();
                        string value = r["ClassDescription"].ToString();
                        Api.AddClassDescription(key, value);
                    }

                    foreach (DataRow r in dataSetACCDefinitions.Tables["ParamDescriptions"].Rows)
                    {
                        string ParamName = r["ParamName"].ToString();
                        string ClassDescription = r["ClassDescription"].ToString();
                        string ClassName = r["ClassName"].ToString();
                        Api.AddParamDescription(ParamName, ClassDescription, ClassName);
                    }

                    Api.MethodParameters = dataSetACCDefinitions.Tables["Specifications"].Rows[0]["Col_MethodParameters"].ToString();

                    foreach (DataRow r in dataSetACCDefinitions.Tables["DomainClasses"].Rows)
                    {
                        listBox1.Items.Add(r[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("The file selected is not a valid ACC API definition file");
                }
            }
        }

        private void txtParameters_Leave(object sender, EventArgs e)
        {
            try
            {
                Api.MethodParameters = txtParameters.Text;
            }
            catch (SignatureParsingException spe)
            {
                MessageBox.Show(this, spe.Message + "\n\nPress OK to restore old correct signature:\n\n" + spe.OldSignature, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Api.signatureAlreadyChanging = false;
                Api.MethodParameters = spe.OldSignature;
            }
        }
    }
}
