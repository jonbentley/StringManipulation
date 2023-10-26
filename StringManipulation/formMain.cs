
namespace StringManipulation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using Components;

    using Extensions;

    /// <summary>
    /// form main
    /// </summary>
    public partial class FormMain : Form
    {
        private StringManipulationComponent StringManipulationComponent;
        private XmlUtilitiesComponent XmlUtilitiesComponent;

        public FormMain()
        {
            this.InitializeComponent();
            this.StringManipulationComponent = new StringManipulationComponent();
            this.XmlUtilitiesComponent = new XmlUtilitiesComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = $@"String Manipulation : {Application.ProductVersion}";
            this.RefreshCounts();
            this.simpleEditorDisplay.Dock = DockStyle.Fill;
            this.simpleEditorDisplay.Focus();

        }

        private void btnDeleteEmptyLines_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.DeleteEmptyLines(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void DeleteLinesContaining_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.DeleteLinesContaining(this.simpleEditorDisplay.Text, this.txtSearchStringA.Text, this.chkCaseSensitive.Checked);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnDeleteLinesNOTContaining_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.DeleteLinesNotContaining(this.simpleEditorDisplay.Text, this.txtSearchStringA.Text, this.chkCaseSensitive.Checked);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.Trim(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnTrimBeforeFirst_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.TrimBeforeFirst(this.simpleEditorDisplay.Text, this.txtSearchStringA.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnTrimAfterFirst_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.TrimAfterFirst(this.simpleEditorDisplay.Text, this.txtSearchStringA.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnSortAscendingString_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.SortAscendingString(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnSortDescendingString_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.SortDescendingString(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnSortAscendingNumeric_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.SortAscendingNumeric(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnSortDescendingNumeric_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.SortDescendingNumeric(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnSortLineLength_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.SortLineLength(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnReverseOrder_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.ReverseCurrentOrder(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnRemoveDuplicates_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.RemoveDuplicates(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnFindAllItemsThatAreDuplicates_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.FindAllItemsThatAreDuplicates(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnCountOccurrences_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.CountOccurrences(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnFindUnique_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.FindUniqueItems(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.Sum(this.simpleEditorDisplay.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        /// <summary>
        /// Insert the specified string at the beginning of each line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInsertAtStartOfEachLine_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.InsertAtStartOfEachLine(this.simpleEditorDisplay.Text, this.txtStringToInsertC.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnInsertAtEndOfEachLine_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.InsertAtEndOfEachLine(this.simpleEditorDisplay.Text, this.txtStringToInsertC.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void BtnInsertAtPosition_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtPositionNumberB.Text, out int position))
            {
                MessageBox.Show(string.Format("The position specified '{0}' is not an integer", this.txtPositionNumberB.Text));
                return;
            }

            var result = this.StringManipulationComponent.InsertAtPosition(this.simpleEditorDisplay.Text, position, this.txtStringToInsertC.Text);

            int countLinesTooShort = result.Item2;

            this.simpleEditorDisplay.Text = result.Item1;
            this.RefreshCounts();

            if (countLinesTooShort > 0)
            {
                MessageBox.Show($@"There are {countLinesTooShort} lines which are too short. These have had '<line too short>' appended to them (so they stand out)");
            }
        }

        private void btnXmlSortNodes_Click(object sender, EventArgs e)
        {
            var result = this.XmlUtilitiesComponent.SortXmlNodes(this.simpleEditorDisplay.Text);

            if (result.Item1 == false)
            {
                MessageBox.Show($@"Invalid Xml{Environment.NewLine}{Environment.NewLine}{result.Item2}");
                return;
            }

            this.simpleEditorDisplay.Text = result.Item3;
            this.RefreshCounts();
        }

        private void BtnPasteUnProcessed_Click(object sender, EventArgs e)
        {
            this.simpleEditorDisplay.Text = Clipboard.GetText();
            this.RefreshCounts();
        }

        private void BtnSelectAllProcessed_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(this.simpleEditorDisplay.Text);
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            this.simpleEditorDisplay.Text = string.Empty;
            this.RefreshCounts();
        }

        private void RefreshCounts()
        {
            // set the counts. 
            this.lblRowCount.Text = string.IsNullOrEmpty(this.simpleEditorDisplay.Text) ? "0" : this.simpleEditorDisplay.Text.StringToList().Count.ToString("N0");

            this.lblList1Count.Text = string.IsNullOrEmpty(this.simpleEditorList1.Text) ? "0" : this.simpleEditorList1.Text.StringToList().Count.ToString("N0");
            this.lblList2Count.Text = string.IsNullOrEmpty(this.simpleEditorList2.Text) ? "0" : this.simpleEditorList2.Text.StringToList().Count.ToString("N0");

            this.simpleEditorDisplay.Focus();
        }

        private void TxtListToBeProcessed_TextChanged(object sender, EventArgs e)
        {
            this.RefreshCounts();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            this.simpleEditorDisplay.Undo();
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            this.simpleEditorDisplay.Redo();
        }

        // only allow numeric in Position text box
        private void txtPositionNumberB_TextChanged(object sender, EventArgs e)
        {
            string actualData = string.Empty;
            char[] enteredData = this.txtPositionNumberB.Text.ToCharArray();
            foreach (char aChar in enteredData.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualData = actualData + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                }
            }

            this.txtPositionNumberB.Text = actualData;
        }

        private void btnList1NotList2_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.List1NotList2(this.simpleEditorList1.Text, this.simpleEditorList2.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnList2NotList1_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.List1NotList2(this.simpleEditorList2.Text, this.simpleEditorList1.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        private void btnList1AndList2_Click(object sender, EventArgs e)
        {
            var result = this.StringManipulationComponent.List1AndList2(this.simpleEditorList1.Text, this.simpleEditorList2.Text);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        // Put all the text onto one line
        private void btnOneLine_Click(object sender, EventArgs e)
        {
            var result = this.simpleEditorDisplay.Text.Replace(Environment.NewLine, string.Empty);
            this.simpleEditorDisplay.Text = result;
            this.RefreshCounts();
        }

        /// <summary>
        /// For each file in the clipboard (assuming CTRL+C from Windows Explorer)
        /// paste the contents to the end of the text
        ///
        /// A list of files copied to the clipboard is simply an array of file names
        /// added to the clipboard with the data type FileDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppendFileContents_Click(object sender, EventArgs e)
        {
            const string prefix = ">>>>>>>>>>>>>>>>>>>>> ";

            // Check there are files on the clipboard to copy
            if (!Clipboard.ContainsData(DataFormats.FileDrop))
            {
                MessageBox.Show(@"There are no files in the clipboard to append. Open Windows Explorer, select the files you want to append, copy them (Ctrl+c), then click 'Append'. The files are processed in alphabetical order, and the merged contents put in the text box above.");
                return;
            }

            // Get all the files in the clipboard.
            // File order seems random, so sort it
            string[] fileNamesToAppend = (string[]) Clipboard.GetData(DataFormats.FileDrop);
            var fileNamesToAppendSorted = fileNamesToAppend.ToList();
            fileNamesToAppendSorted.Sort();

            // list the files to append
            // it's easy to delete these later if you don't want this to stay
            // simply delete all lines containing whatever the prefix is
            this.AppendTextAfterNewLine ($"{prefix}Appending the following files");
            fileNamesToAppendSorted.ForEach(this.AppendTextAfterNewLine);

            // Read each file and append
            foreach (string fileToAppend in fileNamesToAppendSorted)
            {
                string text = System.IO.File.ReadAllText(fileToAppend);
                this.AppendTextAfterNewLine($"{prefix}{fileToAppend}");
                this.AppendTextAfterNewLine(text);
            }

            MessageBox.Show($@"{fileNamesToAppendSorted.Count} file(s) appended.{Environment.NewLine}Perform a{Environment.NewLine}{Environment.NewLine}'Line Commands > Delete lines containing {prefix}'{Environment.NewLine}{Environment.NewLine}to remove the annotations.");
        }

        // Append the text, after a new line
        private void AppendTextAfterNewLine(string textToAppend)
        {
            this.simpleEditorDisplay.Text += Environment.NewLine + textToAppend;
            this.RefreshCounts();
        }

        private void btnReplaceStringWithNewLine_Click(object sender, EventArgs e)
        {
            try
            {
                var result = this.StringManipulationComponent.FindAndReplace(this.simpleEditorDisplay.Text, this.txtFindText.Text, Environment.NewLine, this.GetNthOccurrence(), this.GetColumnStartNumber(), this.GetColumnEndNumber());
                this.simpleEditorDisplay.Text = result;
                this.RefreshCounts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReplaceNewLineWithString_Click(object sender, EventArgs e)
        {
            try
            {
                var result = this.StringManipulationComponent.FindAndReplace(this.simpleEditorDisplay.Text, Environment.NewLine, this.txtFindText.Text, this.GetNthOccurrence(), this.GetColumnStartNumber(), this.GetColumnEndNumber());
                this.simpleEditorDisplay.Text = result;
                this.RefreshCounts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            try
            {
                var result = this.StringManipulationComponent.FindAndReplace(this.simpleEditorDisplay.Text, this.txtFindText.Text, this.txtReplaceText.Text, this.GetNthOccurrence(), this.GetColumnStartNumber(), this.GetColumnEndNumber());
                this.simpleEditorDisplay.Text = result;
                this.RefreshCounts();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private int GetNthOccurrence()
        {
            return ConvertStringToInt(this.txtNthOccurrence.Text);
        }
        private int GetColumnStartNumber()
        {
            return ConvertStringToInt(this.txtColumnStartNumber.Text);
        }
        private int GetColumnEndNumber()
        {
            return ConvertStringToInt(this.txtColumnEndNumber.Text);
        }

        private int ConvertStringToInt(string input)
        {
            if (int.TryParse(input, out int convertedResult))
            {
                return convertedResult;
            }

            return 0;
        }

        private void btnNimbleText_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://www.nimbletext.com/Live");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops" + Environment.NewLine + ex);
            }
        }

        private void btnList1Clear_Click(object sender, EventArgs e)
        {
            this.simpleEditorList1.Text = string.Empty;
            this.RefreshCounts();
        }

        private void btnList2Clear_Click(object sender, EventArgs e)
        {
            this.simpleEditorList2.Text = string.Empty;
            this.RefreshCounts();
        }

        private void btnList1Paste_Click(object sender, EventArgs e)
        {
            this.simpleEditorList1.Text = Clipboard.GetText();
            this.RefreshCounts();
        }

        private void btnList2Paste_Click(object sender, EventArgs e)
        {
            this.simpleEditorList2.Text = Clipboard.GetText();
            this.RefreshCounts();
        }

        private void btnList1Copy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(this.simpleEditorList1.Text);
        }

        private void btnList2Copy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(this.simpleEditorList2.Text);
        }

        // only allow numeric in text box
        private void txtNthOccurrence_TextChanged(object sender, EventArgs e)
        {
            string actualData = string.Empty;
            char[] enteredData = this.txtNthOccurrence.Text.ToCharArray();
            foreach (char aChar in enteredData.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualData = actualData + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                }
            }

            this.txtNthOccurrence.Text = actualData;
        }

        // only allow numeric in text box
        private void txtColumnStartNumber_TextChanged(object sender, EventArgs e)
        {
            string actualData = string.Empty;
            char[] enteredData = this.txtColumnStartNumber.Text.ToCharArray();
            foreach (char aChar in enteredData.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualData = actualData + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                }
            }

            this.txtColumnStartNumber.Text = actualData;
        }

        // only allow numeric in text box
        private void txtColumnEndNumber_TextChanged(object sender, EventArgs e)
        {
            string actualData = string.Empty;
            char[] enteredData = this.txtColumnEndNumber.Text.ToCharArray();
            foreach (char aChar in enteredData.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualData = actualData + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                }
            }

            this.txtColumnEndNumber.Text = actualData;
        }
    }
}
