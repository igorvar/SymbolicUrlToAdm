using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GenerateSymbolicUrlAdmFilesImportt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            DataGridViewExtention.NumericColumn col = new DataGridViewExtention.NumericColumn();
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.Name = clmnSequence.Name;
            col.HeaderText = clmnSequence.HeaderText;
            col.SortMode = clmnSequence.SortMode;
            int clmnIndex = clmnSequence.Index;
            dgArguments.Columns.RemoveAt(clmnIndex);
            this.dgArguments.Columns.Insert(clmnIndex, col);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string sessionName;
            string folder;
            //fileDialogSessionName.Filter = txtSessionName.Text + "*.* files | " + txtSessionName.Text + "*.*|All files (*.*)|*.*";
            //saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            fileDialogSessionName.FileName = txtUrlName.Text;
            if (fileDialogSessionName.ShowDialog() != DialogResult.OK)
                return;
            FileInfo fi = new FileInfo(fileDialogSessionName.FileName);
            
            if (fi.Exists)
            {
                MessageBox.Show("Please enter name of files groop");
                return;
            }
            sessionName = fi.Name;
            folder = fi.Directory.FullName + @"\";

            XmlDocument mainDoc = new XmlDocument();
            mainDoc.Load("Example_Symbolic_URL.xml");
            XmlNode nd;
            nd = mainDoc.SelectSingleNode("/SiebelMessage/_sblesc_und_undPROPERTIES_und_und/SessionId");
            nd.InnerText = sessionName;

            nd = mainDoc.SelectSingleNode("/SiebelMessage/_sblesc_und_undPROPERTIES_und_und/TransactionLogFileName");
            nd.InnerText = sessionName;

            nd = mainDoc.SelectSingleNode("/SiebelMessage/EAIMessage/ListOfWI_spcSymbolic_spcURL/WI_spcSymbolic_spcURL/_sblesc_und_undPROPERTIES_und_und/URL");
            nd.InnerText = txtURL.Text;

            nd = mainDoc.SelectSingleNode("/SiebelMessage/EAIMessage/ListOfWI_spcSymbolic_spcURL/WI_spcSymbolic_spcURL/_sblesc_und_undPROPERTIES_und_und/SSO_spcDisposition");
            nd.InnerText = cmdSsoDisposition.Text;

            nd = mainDoc.SelectSingleNode("/SiebelMessage/EAIMessage/ListOfWI_spcSymbolic_spcURL/WI_spcSymbolic_spcURL/_sblesc_und_undPROPERTIES_und_und/Name");
            nd.InnerText = txtUrlName.Text;

            XmlNode ndArguments = mainDoc.SelectSingleNode("/SiebelMessage/EAIMessage/ListOfWI_spcSymbolic_spcURL/WI_spcSymbolic_spcURL/ListOfWI_spcSymbolic_spcURL_spcArgument");
            ndArguments.RemoveAll();
            for (int i = 0; i < dgArguments.RowCount - 1; i++)
            {
                XmlNode ndRow = mainDoc.CreateNode(XmlNodeType.Element, "WI_spcSymbolic_spcURL_spcArgument", "");
                XmlNode ndRowSub = mainDoc.CreateNode(XmlNodeType.Element, "_sblesc_und_undPROPERTIES_und_und", "");

                

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Append_spcas_spcArgument","");
                nd.InnerText = ((bool)dgArguments[clmnAppendAsArgument.Name, i].Value) ? "Y": "N";
                ndRowSub.AppendChild(nd);

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Required_spcArgument", "");
                nd.InnerText = ((bool)dgArguments[clmnRequiredArgument.Name, i].Value) ? "Y" : "N";
                ndRowSub.AppendChild(nd);

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Argument_spcType", "");
                nd.InnerText = (String)dgArguments[clmnArgumentType.Name, i].Value;
                ndRowSub.AppendChild(nd);

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Sequence_spcNumber", "");
                nd.InnerText = ((int)dgArguments[clmnSequence.Name, i].Value).ToString();
                ndRowSub.AppendChild(nd);

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Substitute_spcin_spcText", "");
                nd.InnerText = ((bool)dgArguments[clmnSubstituateInText.Name, i].Value) ? "Y" : "N";
                ndRowSub.AppendChild(nd);

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Argument_spcValue", "");
                nd.InnerText = (String)dgArguments[clmnArgumentValue.Name, i].Value;
                ndRowSub.AppendChild(nd);

                nd = mainDoc.CreateNode(XmlNodeType.Element, "Name", "");
                nd.InnerText = (String)dgArguments[clmnName.Name, i].Value;
                ndRowSub.AppendChild(nd);

                ndRow.AppendChild(ndRowSub);
                ndArguments.AppendChild(ndRow);
            }

            string datafileName = sessionName + "_Symbolic_URL.xml";
            mainDoc.PreserveWhitespace = !false;
            mainDoc.Save(folder + datafileName);
            

            XmlDocument desDoc = new XmlDocument();
            desDoc.Load("Example_Symbolic_URL_des.xml");
            nd = desDoc.SelectSingleNode("/ADMDeploymentUnit/DeploymentType[@Name='Symbolic URL']/Object/@Name");
            nd.Value = txtUrlName.Text;
            desDoc.Save(folder + sessionName + "_Symbolic_URL_des.xml");

            File.WriteAllText(folder + sessionName + ".ini", datafileName, Encoding.UTF8);
            /*using (FileStream fs = File.Create(folder + sessionName + ".ini"))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(datafileName);
                fs.Write(info, 0, info.Length);
            }*/

        }
        
        private void dgArguments_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[clmnAppendAsArgument.Name].Value = true;
            e.Row.Cells[clmnArgumentType.Name].Value = "Constant";
            e.Row.Cells[clmnRequiredArgument.Name].Value = true;
            e.Row.Cells[clmnSubstituateInText.Name].Value = false;
            e.Row.Cells[clmnArgumentType.Name].Value = _lastArgumentType;
            int maxSequence = 0;
            
            for (int i = 0; i < dgArguments.RowCount; i++)
            {
                if (dgArguments[clmnSequence.Name, i].Value == null || dgArguments.Rows[i].IsNewRow)
                    continue;
                maxSequence = Math.Max((int)dgArguments[clmnSequence.Name, i].Value, maxSequence);
            }
            //e.Row.Cells[clmnSequence.Name].ValueType = typeof(int);
            e.Row.Cells[clmnSequence.Name].Value = maxSequence + 10;

        }
        string _lastArgumentType;
        private void dgArguments_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //dgArguments[1,1].ErrorText
            
            /*if (dgArguments.Columns[e.ColumnIndex].Name == clmnSequence.Name)
            {
                int val = 0;
                if (false == int.TryParse(e.FormattedValue.ToString(), out val))
                {
                    dgArguments.Rows[e.RowIndex].ErrorText = "Only integer";
                    //dgArguments[e.ColumnIndex,e.RowIndex].ErrorText = "Only integer";
                    
                    e.Cancel = true;
                }
            }*/
            _lastArgumentType = (string)dgArguments[clmnArgumentType.Name, e.RowIndex].Value;
        }

        private void dgArguments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgArguments.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void Form1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("Test");
            }
        }

        private void btnRemoveArgument_Click(object sender, EventArgs e)
        {
            //for (int i  dgArguments.SelectedRows
            for (int i = dgArguments.SelectedRows.Count - 1; i >= 0; i--)
                if (!dgArguments.SelectedRows[0].IsNewRow)
                    dgArguments.Rows.RemoveAt(dgArguments.SelectedRows[i].Index);
            
        }
        private void txtUrlName_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUrlName.Text, @"^ITO\s\S+"))
            {
                e.Cancel = true;
                txtUrlName.Select(0, 3);
                errorProvider1.SetError(txtUrlName, "Name must be started from 'ITO'");
            }
        }
        private void txtURL_Validating(object sender, CancelEventArgs e)
        {
            //if (!Uri.IsWellFormedUriString(txtURL.Text, UriKind.Absolute))
            if(! System.Text.RegularExpressions.Regex.IsMatch(txtURL.Text, @"^http(s)?://.*", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                e.Cancel = true;
                txtURL.Select(0, txtURL.Text.Length);
                errorProvider1.SetError(txtURL, "Invalid URL");
            }
        }

        

        private void Control_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError((Control)sender, "");
        }

        private void dgArguments_Validating(object sender, CancelEventArgs e)
        {
            string[] argumentNames = new string[dgArguments.RowCount - 1];
            int[] sequences = new int[dgArguments.RowCount - 1];
            
            for (int i = 0; i < dgArguments.RowCount; i++)
            {
                if (dgArguments.Rows[i].IsNewRow) continue;
                dgArguments.Rows[i].ErrorText = "";

                if (string.IsNullOrEmpty((string)dgArguments[clmnName.Name, i].Value))
                    dgArguments.Rows[i].ErrorText = "Name is mandatory\n";
                if (string.IsNullOrEmpty((string)dgArguments[clmnArgumentType.Name, i].Value))
                    dgArguments.Rows[i].ErrorText += "Type is mandatory\n";
                if (string.IsNullOrEmpty((string)dgArguments[clmnArgumentValue.Name, i].Value) && (string)dgArguments[clmnArgumentType.Name,i].Value != "Language Value")
                    dgArguments.Rows[i].ErrorText += "Argument Value is mandatory\n";
                for (int j = 0; j < i; j++)
                    if ((string)dgArguments[clmnName.Name, i].Value == argumentNames[j])
                    {
                        dgArguments.Rows[i].ErrorText += "Name same as in row " + (j + 1).ToString() + "\n";
                        dgArguments.Rows[j].ErrorText += "Name same as in row " + (i + 1).ToString() + "\n";
                    }
                argumentNames[i] = (string)dgArguments[clmnName.Name, i].Value;

                for (int j = 0; j < i; j++)
                    if ((int)dgArguments[clmnSequence.Name, i].Value == sequences[j])
                    {
                        dgArguments.Rows[i].ErrorText += "Sequences same as in row " + (j + 1).ToString() + "\n";
                        dgArguments.Rows[j].ErrorText += "Sequences same as in row " + (i + 1).ToString() + "\n";
                    }
                sequences[i] = (int)dgArguments[clmnSequence.Name, i].Value;

                //if (!string.IsNullOrEmpty(dgArguments.Rows[i].ErrorText)) e.Cancel = true;
            }
        }
    }
}
