using System.ComponentModel;
using System.Windows.Forms;

namespace StringManipulation
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchStringA = new System.Windows.Forms.TextBox();
            this.btnDeleteLinesContaining = new System.Windows.Forms.Button();
            this.btnDeleteLInesNOTContaining = new System.Windows.Forms.Button();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.btnTrimBeforeFirst = new System.Windows.Forms.Button();
            this.btnTrimAfterLast = new System.Windows.Forms.Button();
            this.btnSortAscendingString = new System.Windows.Forms.Button();
            this.btnClearText = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnPasteUnProcessed = new System.Windows.Forms.Button();
            this.btnRemoveDuplicates = new System.Windows.Forms.Button();
            this.btnFindAllItemsThatAreDuplicates = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnInsertAtStartOfEachLine = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPositionNumberB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStringToInsertC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInsertAtPosition = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.btnTrim = new System.Windows.Forms.Button();
            this.btnDeleteBlankLines = new System.Windows.Forms.Button();
            this.btnList1NotList2 = new System.Windows.Forms.Button();
            this.btnList2NotList1 = new System.Windows.Forms.Button();
            this.btnList1AndList2 = new System.Windows.Forms.Button();
            this.btnOneLine = new System.Windows.Forms.Button();
            this.btnFindUnique = new System.Windows.Forms.Button();
            this.btnCountOccurrences = new System.Windows.Forms.Button();
            this.txtColumnStartNumber = new System.Windows.Forms.TextBox();
            this.txtColumnEndNumber = new System.Windows.Forms.TextBox();
            this.txtNthOccurrence = new System.Windows.Forms.TextBox();
            this.btnReplaceNewLineWith = new System.Windows.Forms.Button();
            this.btnAppendFileContents = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.simpleEditorDisplay = new EasyScintilla.SimpleEditor();
            this.pnlReadFile = new System.Windows.Forms.Panel();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pnlMainText = new System.Windows.Forms.Panel();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabPage_LineCommands = new System.Windows.Forms.TabPage();
            this.grpDeletingAndTrimming = new System.Windows.Forms.GroupBox();
            this.grpInserting = new System.Windows.Forms.GroupBox();
            this.tabPage_FileCommands = new System.Windows.Forms.TabPage();
            this.grpDuplicates = new System.Windows.Forms.GroupBox();
            this.grpSorting = new System.Windows.Forms.GroupBox();
            this.btnSortDescendingString = new System.Windows.Forms.Button();
            this.btnReverseOrder = new System.Windows.Forms.Button();
            this.btnSortLineLength = new System.Windows.Forms.Button();
            this.btnSortAscendingNumeric = new System.Windows.Forms.Button();
            this.btnSortDescendingNumeric = new System.Windows.Forms.Button();
            this.tabPage_ComparingLists = new System.Windows.Forms.TabPage();
            this.grpList2 = new System.Windows.Forms.GroupBox();
            this.lblList2Count = new System.Windows.Forms.Label();
            this.btnList2Copy = new System.Windows.Forms.Button();
            this.btnList2Paste = new System.Windows.Forms.Button();
            this.btnList2Clear = new System.Windows.Forms.Button();
            this.simpleEditorList2 = new EasyScintilla.SimpleEditor();
            this.grpList1 = new System.Windows.Forms.GroupBox();
            this.lblList1Count = new System.Windows.Forms.Label();
            this.btnList1Copy = new System.Windows.Forms.Button();
            this.btnList1Paste = new System.Windows.Forms.Button();
            this.btnList1Clear = new System.Windows.Forms.Button();
            this.simpleEditorList1 = new EasyScintilla.SimpleEditor();
            this.tabPage_XmlCommands = new System.Windows.Forms.TabPage();
            this.btnXmlSortNodes = new System.Windows.Forms.Button();
            this.tabPage_FindAndReplace = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReplaceNewLine = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReplaceText = new System.Windows.Forms.TextBox();
            this.txtFindText = new System.Windows.Forms.TextBox();
            this.tabPage_Other = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNimbleText = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlReadFile.SuspendLayout();
            this.pnlMainText.SuspendLayout();
            this.pnlDescription.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.tabControls.SuspendLayout();
            this.tabPage_LineCommands.SuspendLayout();
            this.grpDeletingAndTrimming.SuspendLayout();
            this.grpInserting.SuspendLayout();
            this.tabPage_FileCommands.SuspendLayout();
            this.grpDuplicates.SuspendLayout();
            this.grpSorting.SuspendLayout();
            this.tabPage_ComparingLists.SuspendLayout();
            this.grpList2.SuspendLayout();
            this.grpList1.SuspendLayout();
            this.tabPage_XmlCommands.SuspendLayout();
            this.tabPage_FindAndReplace.SuspendLayout();
            this.tabPage_Other.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-100, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder Name";
            // 
            // txtSearchStringA
            // 
            this.txtSearchStringA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchStringA.Location = new System.Drawing.Point(246, 81);
            this.txtSearchStringA.Name = "txtSearchStringA";
            this.txtSearchStringA.Size = new System.Drawing.Size(178, 22);
            this.txtSearchStringA.TabIndex = 7;
            // 
            // btnDeleteLinesContaining
            // 
            this.btnDeleteLinesContaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLinesContaining.Location = new System.Drawing.Point(12, 21);
            this.btnDeleteLinesContaining.Name = "btnDeleteLinesContaining";
            this.btnDeleteLinesContaining.Size = new System.Drawing.Size(226, 23);
            this.btnDeleteLinesContaining.TabIndex = 8;
            this.btnDeleteLinesContaining.Text = "Delete Lines Containing A";
            this.btnDeleteLinesContaining.UseVisualStyleBackColor = true;
            this.btnDeleteLinesContaining.Click += new System.EventHandler(this.DeleteLinesContaining_Click);
            // 
            // btnDeleteLInesNOTContaining
            // 
            this.btnDeleteLInesNOTContaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLInesNOTContaining.Location = new System.Drawing.Point(12, 51);
            this.btnDeleteLInesNOTContaining.Name = "btnDeleteLInesNOTContaining";
            this.btnDeleteLInesNOTContaining.Size = new System.Drawing.Size(226, 23);
            this.btnDeleteLInesNOTContaining.TabIndex = 9;
            this.btnDeleteLInesNOTContaining.Text = "Delete Lines NOT Containing A";
            this.btnDeleteLInesNOTContaining.UseVisualStyleBackColor = true;
            this.btnDeleteLInesNOTContaining.Click += new System.EventHandler(this.BtnDeleteLinesNOTContaining_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Location = new System.Drawing.Point(938, 9);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(48, 18);
            this.lblRowCount.TabIndex = 10;
            this.lblRowCount.Text = "Count";
            // 
            // btnTrimBeforeFirst
            // 
            this.btnTrimBeforeFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrimBeforeFirst.Location = new System.Drawing.Point(12, 111);
            this.btnTrimBeforeFirst.Name = "btnTrimBeforeFirst";
            this.btnTrimBeforeFirst.Size = new System.Drawing.Size(226, 23);
            this.btnTrimBeforeFirst.TabIndex = 12;
            this.btnTrimBeforeFirst.Text = "Trim Text Before First \"A\"...";
            this.toolTip1.SetToolTip(this.btnTrimBeforeFirst, "Always Case Sensitive");
            this.btnTrimBeforeFirst.UseVisualStyleBackColor = true;
            this.btnTrimBeforeFirst.Click += new System.EventHandler(this.BtnTrimBeforeFirst_Click);
            // 
            // btnTrimAfterLast
            // 
            this.btnTrimAfterLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrimAfterLast.Location = new System.Drawing.Point(12, 141);
            this.btnTrimAfterLast.Name = "btnTrimAfterLast";
            this.btnTrimAfterLast.Size = new System.Drawing.Size(226, 23);
            this.btnTrimAfterLast.TabIndex = 13;
            this.btnTrimAfterLast.Text = "Trim Text After First \"A\"...";
            this.toolTip1.SetToolTip(this.btnTrimAfterLast, "Always Case Sensitive");
            this.btnTrimAfterLast.UseVisualStyleBackColor = true;
            this.btnTrimAfterLast.Click += new System.EventHandler(this.BtnTrimAfterFirst_Click);
            // 
            // btnSortAscendingString
            // 
            this.btnSortAscendingString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortAscendingString.Location = new System.Drawing.Point(11, 31);
            this.btnSortAscendingString.Name = "btnSortAscendingString";
            this.btnSortAscendingString.Size = new System.Drawing.Size(188, 27);
            this.btnSortAscendingString.TabIndex = 14;
            this.btnSortAscendingString.Text = "Sort Ascending - Alphabetic";
            this.btnSortAscendingString.UseVisualStyleBackColor = true;
            this.btnSortAscendingString.Click += new System.EventHandler(this.BtnSortAscendingString_Click);
            // 
            // btnClearText
            // 
            this.btnClearText.Location = new System.Drawing.Point(330, 3);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(75, 31);
            this.btnClearText.TabIndex = 18;
            this.btnClearText.Text = "Clear";
            this.btnClearText.UseVisualStyleBackColor = true;
            this.btnClearText.Click += new System.EventHandler(this.BtnClearText_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(492, 3);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(75, 31);
            this.btnCopyAll.TabIndex = 17;
            this.btnCopyAll.Text = "Copy All";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.BtnSelectAllProcessed_Click);
            // 
            // btnPasteUnProcessed
            // 
            this.btnPasteUnProcessed.Location = new System.Drawing.Point(411, 3);
            this.btnPasteUnProcessed.Name = "btnPasteUnProcessed";
            this.btnPasteUnProcessed.Size = new System.Drawing.Size(75, 31);
            this.btnPasteUnProcessed.TabIndex = 19;
            this.btnPasteUnProcessed.Text = "Paste";
            this.btnPasteUnProcessed.UseVisualStyleBackColor = true;
            this.btnPasteUnProcessed.Click += new System.EventHandler(this.BtnPasteUnProcessed_Click);
            // 
            // btnRemoveDuplicates
            // 
            this.btnRemoveDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDuplicates.Location = new System.Drawing.Point(13, 31);
            this.btnRemoveDuplicates.Name = "btnRemoveDuplicates";
            this.btnRemoveDuplicates.Size = new System.Drawing.Size(180, 24);
            this.btnRemoveDuplicates.TabIndex = 20;
            this.btnRemoveDuplicates.Text = "Delete Duplicates";
            this.toolTip1.SetToolTip(this.btnRemoveDuplicates, "Remove duplicate items leaving just one of each");
            this.btnRemoveDuplicates.UseVisualStyleBackColor = true;
            this.btnRemoveDuplicates.Click += new System.EventHandler(this.BtnRemoveDuplicates_Click);
            // 
            // btnFindAllItemsThatAreDuplicates
            // 
            this.btnFindAllItemsThatAreDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindAllItemsThatAreDuplicates.Location = new System.Drawing.Point(13, 65);
            this.btnFindAllItemsThatAreDuplicates.Name = "btnFindAllItemsThatAreDuplicates";
            this.btnFindAllItemsThatAreDuplicates.Size = new System.Drawing.Size(180, 24);
            this.btnFindAllItemsThatAreDuplicates.TabIndex = 22;
            this.btnFindAllItemsThatAreDuplicates.Text = "Find Duplicates";
            this.toolTip1.SetToolTip(this.btnFindAllItemsThatAreDuplicates, "Find all occurrences of items that are duplicated. i.e. remove all unique items.");
            this.btnFindAllItemsThatAreDuplicates.UseVisualStyleBackColor = true;
            this.btnFindAllItemsThatAreDuplicates.Click += new System.EventHandler(this.BtnFindAllItemsThatAreDuplicates_Click);
            // 
            // btnSum
            // 
            this.btnSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSum.Location = new System.Drawing.Point(735, 19);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(126, 24);
            this.btnSum.TabIndex = 23;
            this.btnSum.Text = "Sum";
            this.toolTip1.SetToolTip(this.btnSum, "Assuming every line contains a number, add them up");
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.BtnSum_Click);
            // 
            // btnInsertAtStartOfEachLine
            // 
            this.btnInsertAtStartOfEachLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertAtStartOfEachLine.Location = new System.Drawing.Point(9, 54);
            this.btnInsertAtStartOfEachLine.Name = "btnInsertAtStartOfEachLine";
            this.btnInsertAtStartOfEachLine.Size = new System.Drawing.Size(230, 23);
            this.btnInsertAtStartOfEachLine.TabIndex = 24;
            this.btnInsertAtStartOfEachLine.Text = "Insert C at the Start Of Each Line";
            this.btnInsertAtStartOfEachLine.UseVisualStyleBackColor = true;
            this.btnInsertAtStartOfEachLine.Click += new System.EventHandler(this.BtnInsertAtStartOfEachLine_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "\"A\" - Search String";
            // 
            // txtPositionNumberB
            // 
            this.txtPositionNumberB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPositionNumberB.Location = new System.Drawing.Point(252, 33);
            this.txtPositionNumberB.Name = "txtPositionNumberB";
            this.txtPositionNumberB.Size = new System.Drawing.Size(70, 22);
            this.txtPositionNumberB.TabIndex = 26;
            this.txtPositionNumberB.TextChanged += new System.EventHandler(this.txtPositionNumberB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(252, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "\"B\" - Position Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(252, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "\"C\" - String to insert";
            // 
            // txtStringToInsertC
            // 
            this.txtStringToInsertC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStringToInsertC.Location = new System.Drawing.Point(250, 72);
            this.txtStringToInsertC.Name = "txtStringToInsertC";
            this.txtStringToInsertC.Size = new System.Drawing.Size(178, 22);
            this.txtStringToInsertC.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Insert C at the End Of Each Line";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnInsertAtEndOfEachLine_Click);
            // 
            // btnInsertAtPosition
            // 
            this.btnInsertAtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertAtPosition.Location = new System.Drawing.Point(9, 22);
            this.btnInsertAtPosition.Name = "btnInsertAtPosition";
            this.btnInsertAtPosition.Size = new System.Drawing.Size(230, 23);
            this.btnInsertAtPosition.TabIndex = 31;
            this.btnInsertAtPosition.Text = "Insert C after Position B";
            this.btnInsertAtPosition.UseVisualStyleBackColor = true;
            this.btnInsertAtPosition.Click += new System.EventHandler(this.BtnInsertAtPosition_Click);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Checked = true;
            this.chkCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaseSensitive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaseSensitive.Location = new System.Drawing.Point(378, 57);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(43, 20);
            this.chkCaseSensitive.TabIndex = 33;
            this.chkCaseSensitive.Text = "Aa";
            this.toolTip1.SetToolTip(this.chkCaseSensitive, "When deleting lines, are the searches for A case sensitive");
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // btnTrim
            // 
            this.btnTrim.Location = new System.Drawing.Point(12, 171);
            this.btnTrim.Name = "btnTrim";
            this.btnTrim.Size = new System.Drawing.Size(226, 23);
            this.btnTrim.TabIndex = 34;
            this.btnTrim.Text = "Trim";
            this.toolTip1.SetToolTip(this.btnTrim, "Remove spaces from the start and end of each line");
            this.btnTrim.UseVisualStyleBackColor = true;
            this.btnTrim.Click += new System.EventHandler(this.btnTrim_Click);
            // 
            // btnDeleteBlankLines
            // 
            this.btnDeleteBlankLines.Location = new System.Drawing.Point(12, 81);
            this.btnDeleteBlankLines.Name = "btnDeleteBlankLines";
            this.btnDeleteBlankLines.Size = new System.Drawing.Size(226, 23);
            this.btnDeleteBlankLines.TabIndex = 35;
            this.btnDeleteBlankLines.Text = "Delete Empty Lines";
            this.toolTip1.SetToolTip(this.btnDeleteBlankLines, "Delete lines that contain nothing, \"\", string.empty. Use Trim first if you want t" +
        "o delete blank lines too.");
            this.btnDeleteBlankLines.UseVisualStyleBackColor = true;
            this.btnDeleteBlankLines.Click += new System.EventHandler(this.btnDeleteEmptyLines_Click);
            // 
            // btnList1NotList2
            // 
            this.btnList1NotList2.Location = new System.Drawing.Point(53, 49);
            this.btnList1NotList2.Name = "btnList1NotList2";
            this.btnList1NotList2.Size = new System.Drawing.Size(177, 29);
            this.btnList1NotList2.TabIndex = 5;
            this.btnList1NotList2.Text = "List 1 Not List 2";
            this.toolTip1.SetToolTip(this.btnList1NotList2, "Find the items (rows) that are in list 1 but not in list 2");
            this.btnList1NotList2.UseVisualStyleBackColor = true;
            this.btnList1NotList2.Click += new System.EventHandler(this.btnList1NotList2_Click);
            // 
            // btnList2NotList1
            // 
            this.btnList2NotList1.Location = new System.Drawing.Point(53, 84);
            this.btnList2NotList1.Name = "btnList2NotList1";
            this.btnList2NotList1.Size = new System.Drawing.Size(177, 29);
            this.btnList2NotList1.TabIndex = 6;
            this.btnList2NotList1.Text = "List 2 Not List 1";
            this.toolTip1.SetToolTip(this.btnList2NotList1, "Find the items (rows) that are in list 2 but not in list 1");
            this.btnList2NotList1.UseVisualStyleBackColor = true;
            this.btnList2NotList1.Click += new System.EventHandler(this.btnList2NotList1_Click);
            // 
            // btnList1AndList2
            // 
            this.btnList1AndList2.Location = new System.Drawing.Point(53, 119);
            this.btnList1AndList2.Name = "btnList1AndList2";
            this.btnList1AndList2.Size = new System.Drawing.Size(177, 29);
            this.btnList1AndList2.TabIndex = 7;
            this.btnList1AndList2.Text = "List 1 and 2";
            this.toolTip1.SetToolTip(this.btnList1AndList2, "Find the items (rows) that are in both list 1 and list 2");
            this.btnList1AndList2.UseVisualStyleBackColor = true;
            this.btnList1AndList2.Click += new System.EventHandler(this.btnList1AndList2_Click);
            // 
            // btnOneLine
            // 
            this.btnOneLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOneLine.Location = new System.Drawing.Point(735, 49);
            this.btnOneLine.Name = "btnOneLine";
            this.btnOneLine.Size = new System.Drawing.Size(126, 24);
            this.btnOneLine.TabIndex = 30;
            this.btnOneLine.Text = "Onto  One Line";
            this.toolTip1.SetToolTip(this.btnOneLine, "Remove all line breaks and put every row onto a single line");
            this.btnOneLine.UseVisualStyleBackColor = true;
            this.btnOneLine.Click += new System.EventHandler(this.btnOneLine_Click);
            // 
            // btnFindUnique
            // 
            this.btnFindUnique.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindUnique.Location = new System.Drawing.Point(13, 133);
            this.btnFindUnique.Name = "btnFindUnique";
            this.btnFindUnique.Size = new System.Drawing.Size(180, 24);
            this.btnFindUnique.TabIndex = 31;
            this.btnFindUnique.Text = "Find Unique";
            this.toolTip1.SetToolTip(this.btnFindUnique, "Find rows that only appear once in the list. i.e. Delete all items that are dupli" +
        "cated.");
            this.btnFindUnique.UseVisualStyleBackColor = true;
            this.btnFindUnique.Click += new System.EventHandler(this.btnFindUnique_Click);
            // 
            // btnCountOccurrences
            // 
            this.btnCountOccurrences.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountOccurrences.Location = new System.Drawing.Point(13, 99);
            this.btnCountOccurrences.Name = "btnCountOccurrences";
            this.btnCountOccurrences.Size = new System.Drawing.Size(180, 24);
            this.btnCountOccurrences.TabIndex = 32;
            this.btnCountOccurrences.Text = "Count Occurrences";
            this.toolTip1.SetToolTip(this.btnCountOccurrences, "Find all occurrences of items that are duplicated. i.e. remove all unique items.");
            this.btnCountOccurrences.UseVisualStyleBackColor = true;
            this.btnCountOccurrences.Click += new System.EventHandler(this.btnCountOccurrences_Click);
            // 
            // txtColumnStartNumber
            // 
            this.txtColumnStartNumber.Location = new System.Drawing.Point(271, 145);
            this.txtColumnStartNumber.Name = "txtColumnStartNumber";
            this.txtColumnStartNumber.Size = new System.Drawing.Size(48, 26);
            this.txtColumnStartNumber.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtColumnStartNumber, "If specified, only search columns >= this number");
            this.txtColumnStartNumber.TextChanged += new System.EventHandler(this.txtColumnStartNumber_TextChanged);
            // 
            // txtColumnEndNumber
            // 
            this.txtColumnEndNumber.Location = new System.Drawing.Point(271, 177);
            this.txtColumnEndNumber.Name = "txtColumnEndNumber";
            this.txtColumnEndNumber.Size = new System.Drawing.Size(48, 26);
            this.txtColumnEndNumber.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtColumnEndNumber, "If specified, only search columns <= this number");
            this.txtColumnEndNumber.TextChanged += new System.EventHandler(this.txtColumnEndNumber_TextChanged);
            // 
            // txtNthOccurrence
            // 
            this.txtNthOccurrence.Location = new System.Drawing.Point(271, 113);
            this.txtNthOccurrence.Name = "txtNthOccurrence";
            this.txtNthOccurrence.Size = new System.Drawing.Size(48, 26);
            this.txtNthOccurrence.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtNthOccurrence, "If specified, only replace this occurrence number of the find string within each " +
        "line");
            this.txtNthOccurrence.TextChanged += new System.EventHandler(this.txtNthOccurrence_TextChanged);
            // 
            // btnReplaceNewLineWith
            // 
            this.btnReplaceNewLineWith.Location = new System.Drawing.Point(563, 34);
            this.btnReplaceNewLineWith.Name = "btnReplaceNewLineWith";
            this.btnReplaceNewLineWith.Size = new System.Drawing.Size(203, 30);
            this.btnReplaceNewLineWith.TabIndex = 12;
            this.btnReplaceNewLineWith.Text = "Replace Line Break With";
            this.toolTip1.SetToolTip(this.btnReplaceNewLineWith, "Replace all line breaks with the search text");
            this.btnReplaceNewLineWith.UseVisualStyleBackColor = true;
            this.btnReplaceNewLineWith.Click += new System.EventHandler(this.btnReplaceNewLineWithString_Click);
            // 
            // btnAppendFileContents
            // 
            this.btnAppendFileContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppendFileContents.Location = new System.Drawing.Point(734, 81);
            this.btnAppendFileContents.Name = "btnAppendFileContents";
            this.btnAppendFileContents.Size = new System.Drawing.Size(126, 24);
            this.btnAppendFileContents.TabIndex = 34;
            this.btnAppendFileContents.Text = "Append Files";
            this.toolTip1.SetToolTip(this.btnAppendFileContents, "Select files from Windows Explorer, Copy them (CTRL+C), and 'Append' will paste" +
        " the file contents into the pane above. The files are processed in alphabetical order.");
            this.btnAppendFileContents.UseVisualStyleBackColor = true;
            this.btnAppendFileContents.Click += new System.EventHandler(this.btnAppendFileContents_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(247, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHeading.Size = new System.Drawing.Size(457, 24);
            this.lblHeading.TabIndex = 32;
            this.lblHeading.Text = " A load of miscellaneous string manipulation functions";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // simpleEditorDisplay
            // 
            this.simpleEditorDisplay.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.simpleEditorDisplay.Location = new System.Drawing.Point(157, 40);
            this.simpleEditorDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.simpleEditorDisplay.Name = "simpleEditorDisplay";
            this.simpleEditorDisplay.Size = new System.Drawing.Size(351, 179);
            this.simpleEditorDisplay.Styler = null;
            this.simpleEditorDisplay.TabIndex = 1;
            this.simpleEditorDisplay.TextChanged += new System.EventHandler(this.TxtListToBeProcessed_TextChanged);
            // 
            // pnlReadFile
            // 
            this.pnlReadFile.Controls.Add(this.btnRedo);
            this.pnlReadFile.Controls.Add(this.lblRowCount);
            this.pnlReadFile.Controls.Add(this.label1);
            this.pnlReadFile.Controls.Add(this.btnUndo);
            this.pnlReadFile.Controls.Add(this.btnCopyAll);
            this.pnlReadFile.Controls.Add(this.btnPasteUnProcessed);
            this.pnlReadFile.Controls.Add(this.btnClearText);
            this.pnlReadFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReadFile.Location = new System.Drawing.Point(0, 38);
            this.pnlReadFile.Name = "pnlReadFile";
            this.pnlReadFile.Size = new System.Drawing.Size(1040, 40);
            this.pnlReadFile.TabIndex = 35;
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(93, 3);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(75, 31);
            this.btnRedo.TabIndex = 20;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.BtnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(12, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 31);
            this.btnUndo.TabIndex = 19;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // pnlMainText
            // 
            this.pnlMainText.Controls.Add(this.simpleEditorDisplay);
            this.pnlMainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainText.Location = new System.Drawing.Point(0, 78);
            this.pnlMainText.Name = "pnlMainText";
            this.pnlMainText.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMainText.Size = new System.Drawing.Size(1040, 276);
            this.pnlMainText.TabIndex = 1;
            this.pnlMainText.TabStop = true;
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.lblHeading);
            this.pnlDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescription.Location = new System.Drawing.Point(0, 0);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(1040, 38);
            this.pnlDescription.TabIndex = 37;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControls.Controls.Add(this.tabControls);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 354);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(5, 15, 5, 10);
            this.pnlControls.Size = new System.Drawing.Size(1040, 282);
            this.pnlControls.TabIndex = 38;
            // 
            // tabControls
            // 
            this.tabControls.Controls.Add(this.tabPage_LineCommands);
            this.tabControls.Controls.Add(this.tabPage_FileCommands);
            this.tabControls.Controls.Add(this.tabPage_ComparingLists);
            this.tabControls.Controls.Add(this.tabPage_XmlCommands);
            this.tabControls.Controls.Add(this.tabPage_FindAndReplace);
            this.tabControls.Controls.Add(this.tabPage_Other);
            this.tabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControls.Location = new System.Drawing.Point(5, 15);
            this.tabControls.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tabControls.Name = "tabControls";
            this.tabControls.Padding = new System.Drawing.Point(33, 3);
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(1028, 255);
            this.tabControls.TabIndex = 0;
            // 
            // tabPage_LineCommands
            // 
            this.tabPage_LineCommands.Controls.Add(this.grpDeletingAndTrimming);
            this.tabPage_LineCommands.Controls.Add(this.grpInserting);
            this.tabPage_LineCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_LineCommands.Location = new System.Drawing.Point(4, 29);
            this.tabPage_LineCommands.Name = "tabPage_LineCommands";
            this.tabPage_LineCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LineCommands.Size = new System.Drawing.Size(1020, 222);
            this.tabPage_LineCommands.TabIndex = 0;
            this.tabPage_LineCommands.Text = "Line Commands";
            this.tabPage_LineCommands.UseVisualStyleBackColor = true;
            // 
            // grpDeletingAndTrimming
            // 
            this.grpDeletingAndTrimming.Controls.Add(this.btnDeleteBlankLines);
            this.grpDeletingAndTrimming.Controls.Add(this.label3);
            this.grpDeletingAndTrimming.Controls.Add(this.btnTrim);
            this.grpDeletingAndTrimming.Controls.Add(this.chkCaseSensitive);
            this.grpDeletingAndTrimming.Controls.Add(this.btnDeleteLinesContaining);
            this.grpDeletingAndTrimming.Controls.Add(this.btnTrimAfterLast);
            this.grpDeletingAndTrimming.Controls.Add(this.txtSearchStringA);
            this.grpDeletingAndTrimming.Controls.Add(this.btnTrimBeforeFirst);
            this.grpDeletingAndTrimming.Controls.Add(this.btnDeleteLInesNOTContaining);
            this.grpDeletingAndTrimming.Location = new System.Drawing.Point(23, 6);
            this.grpDeletingAndTrimming.Name = "grpDeletingAndTrimming";
            this.grpDeletingAndTrimming.Size = new System.Drawing.Size(438, 210);
            this.grpDeletingAndTrimming.TabIndex = 2;
            this.grpDeletingAndTrimming.TabStop = false;
            this.grpDeletingAndTrimming.Text = "Deleting and Trimming";
            // 
            // grpInserting
            // 
            this.grpInserting.Controls.Add(this.button1);
            this.grpInserting.Controls.Add(this.txtStringToInsertC);
            this.grpInserting.Controls.Add(this.label4);
            this.grpInserting.Controls.Add(this.label5);
            this.grpInserting.Controls.Add(this.txtPositionNumberB);
            this.grpInserting.Controls.Add(this.btnInsertAtPosition);
            this.grpInserting.Controls.Add(this.btnInsertAtStartOfEachLine);
            this.grpInserting.Location = new System.Drawing.Point(482, 6);
            this.grpInserting.Name = "grpInserting";
            this.grpInserting.Size = new System.Drawing.Size(440, 128);
            this.grpInserting.TabIndex = 36;
            this.grpInserting.TabStop = false;
            this.grpInserting.Text = "Inserting";
            // 
            // tabPage_FileCommands
            // 
            this.tabPage_FileCommands.Controls.Add(this.btnAppendFileContents);
            this.tabPage_FileCommands.Controls.Add(this.grpDuplicates);
            this.tabPage_FileCommands.Controls.Add(this.btnOneLine);
            this.tabPage_FileCommands.Controls.Add(this.grpSorting);
            this.tabPage_FileCommands.Controls.Add(this.btnSum);
            this.tabPage_FileCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_FileCommands.Location = new System.Drawing.Point(4, 29);
            this.tabPage_FileCommands.Name = "tabPage_FileCommands";
            this.tabPage_FileCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FileCommands.Size = new System.Drawing.Size(1020, 222);
            this.tabPage_FileCommands.TabIndex = 1;
            this.tabPage_FileCommands.Text = "File Commands";
            this.tabPage_FileCommands.UseVisualStyleBackColor = true;
            // 
            // grpDuplicates
            // 
            this.grpDuplicates.Controls.Add(this.btnCountOccurrences);
            this.grpDuplicates.Controls.Add(this.btnRemoveDuplicates);
            this.grpDuplicates.Controls.Add(this.btnFindUnique);
            this.grpDuplicates.Controls.Add(this.btnFindAllItemsThatAreDuplicates);
            this.grpDuplicates.Location = new System.Drawing.Point(456, 9);
            this.grpDuplicates.Name = "grpDuplicates";
            this.grpDuplicates.Size = new System.Drawing.Size(206, 185);
            this.grpDuplicates.TabIndex = 32;
            this.grpDuplicates.TabStop = false;
            this.grpDuplicates.Text = "Duplicates";
            // 
            // grpSorting
            // 
            this.grpSorting.Controls.Add(this.btnSortDescendingString);
            this.grpSorting.Controls.Add(this.btnReverseOrder);
            this.grpSorting.Controls.Add(this.btnSortAscendingString);
            this.grpSorting.Controls.Add(this.btnSortLineLength);
            this.grpSorting.Controls.Add(this.btnSortAscendingNumeric);
            this.grpSorting.Controls.Add(this.btnSortDescendingNumeric);
            this.grpSorting.Location = new System.Drawing.Point(7, 9);
            this.grpSorting.Name = "grpSorting";
            this.grpSorting.Size = new System.Drawing.Size(437, 185);
            this.grpSorting.TabIndex = 29;
            this.grpSorting.TabStop = false;
            this.grpSorting.Text = "Sorting";
            // 
            // btnSortDescendingString
            // 
            this.btnSortDescendingString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortDescendingString.Location = new System.Drawing.Point(229, 32);
            this.btnSortDescendingString.Name = "btnSortDescendingString";
            this.btnSortDescendingString.Size = new System.Drawing.Size(191, 24);
            this.btnSortDescendingString.TabIndex = 24;
            this.btnSortDescendingString.Text = "Sort Descending - Alphabetic";
            this.btnSortDescendingString.UseVisualStyleBackColor = true;
            this.btnSortDescendingString.Click += new System.EventHandler(this.BtnSortDescendingString_Click);
            // 
            // btnReverseOrder
            // 
            this.btnReverseOrder.Location = new System.Drawing.Point(11, 136);
            this.btnReverseOrder.Name = "btnReverseOrder";
            this.btnReverseOrder.Size = new System.Drawing.Size(188, 29);
            this.btnReverseOrder.TabIndex = 28;
            this.btnReverseOrder.Text = "Reverse Current Order";
            this.btnReverseOrder.UseVisualStyleBackColor = true;
            this.btnReverseOrder.Click += new System.EventHandler(this.btnReverseOrder_Click);
            // 
            // btnSortLineLength
            // 
            this.btnSortLineLength.Location = new System.Drawing.Point(11, 101);
            this.btnSortLineLength.Name = "btnSortLineLength";
            this.btnSortLineLength.Size = new System.Drawing.Size(188, 29);
            this.btnSortLineLength.TabIndex = 27;
            this.btnSortLineLength.Text = "Sort Line Length";
            this.btnSortLineLength.UseVisualStyleBackColor = true;
            this.btnSortLineLength.Click += new System.EventHandler(this.btnSortLineLength_Click);
            // 
            // btnSortAscendingNumeric
            // 
            this.btnSortAscendingNumeric.Location = new System.Drawing.Point(11, 66);
            this.btnSortAscendingNumeric.Name = "btnSortAscendingNumeric";
            this.btnSortAscendingNumeric.Size = new System.Drawing.Size(188, 28);
            this.btnSortAscendingNumeric.TabIndex = 25;
            this.btnSortAscendingNumeric.Text = "Sort Ascending - Numeric";
            this.btnSortAscendingNumeric.UseVisualStyleBackColor = true;
            this.btnSortAscendingNumeric.Click += new System.EventHandler(this.btnSortAscendingNumeric_Click);
            // 
            // btnSortDescendingNumeric
            // 
            this.btnSortDescendingNumeric.Location = new System.Drawing.Point(229, 65);
            this.btnSortDescendingNumeric.Name = "btnSortDescendingNumeric";
            this.btnSortDescendingNumeric.Size = new System.Drawing.Size(191, 29);
            this.btnSortDescendingNumeric.TabIndex = 26;
            this.btnSortDescendingNumeric.Text = "Sort Descending - Numeric";
            this.btnSortDescendingNumeric.UseVisualStyleBackColor = true;
            this.btnSortDescendingNumeric.Click += new System.EventHandler(this.btnSortDescendingNumeric_Click);
            // 
            // tabPage_ComparingLists
            // 
            this.tabPage_ComparingLists.Controls.Add(this.btnList1AndList2);
            this.tabPage_ComparingLists.Controls.Add(this.btnList2NotList1);
            this.tabPage_ComparingLists.Controls.Add(this.btnList1NotList2);
            this.tabPage_ComparingLists.Controls.Add(this.grpList2);
            this.tabPage_ComparingLists.Controls.Add(this.grpList1);
            this.tabPage_ComparingLists.Location = new System.Drawing.Point(4, 29);
            this.tabPage_ComparingLists.Name = "tabPage_ComparingLists";
            this.tabPage_ComparingLists.Padding = new System.Windows.Forms.Padding(33, 3, 3, 3);
            this.tabPage_ComparingLists.Size = new System.Drawing.Size(1020, 222);
            this.tabPage_ComparingLists.TabIndex = 3;
            this.tabPage_ComparingLists.Text = "Comparing Lists";
            this.tabPage_ComparingLists.UseVisualStyleBackColor = true;
            // 
            // grpList2
            // 
            this.grpList2.Controls.Add(this.lblList2Count);
            this.grpList2.Controls.Add(this.btnList2Copy);
            this.grpList2.Controls.Add(this.btnList2Paste);
            this.grpList2.Controls.Add(this.btnList2Clear);
            this.grpList2.Controls.Add(this.simpleEditorList2);
            this.grpList2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpList2.Location = new System.Drawing.Point(674, 17);
            this.grpList2.Name = "grpList2";
            this.grpList2.Size = new System.Drawing.Size(297, 199);
            this.grpList2.TabIndex = 4;
            this.grpList2.TabStop = false;
            this.grpList2.Text = "List 2";
            // 
            // lblList2Count
            // 
            this.lblList2Count.AutoSize = true;
            this.lblList2Count.Location = new System.Drawing.Point(253, 168);
            this.lblList2Count.Name = "lblList2Count";
            this.lblList2Count.Size = new System.Drawing.Size(43, 18);
            this.lblList2Count.TabIndex = 5;
            this.lblList2Count.Text = "count";
            this.lblList2Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnList2Copy
            // 
            this.btnList2Copy.Location = new System.Drawing.Point(173, 163);
            this.btnList2Copy.Name = "btnList2Copy";
            this.btnList2Copy.Size = new System.Drawing.Size(75, 26);
            this.btnList2Copy.TabIndex = 3;
            this.btnList2Copy.Text = "Copy All";
            this.btnList2Copy.UseVisualStyleBackColor = true;
            this.btnList2Copy.Click += new System.EventHandler(this.btnList2Copy_Click);
            // 
            // btnList2Paste
            // 
            this.btnList2Paste.Location = new System.Drawing.Point(92, 163);
            this.btnList2Paste.Name = "btnList2Paste";
            this.btnList2Paste.Size = new System.Drawing.Size(75, 26);
            this.btnList2Paste.TabIndex = 2;
            this.btnList2Paste.Text = "Paste";
            this.btnList2Paste.UseVisualStyleBackColor = true;
            this.btnList2Paste.Click += new System.EventHandler(this.btnList2Paste_Click);
            // 
            // btnList2Clear
            // 
            this.btnList2Clear.Location = new System.Drawing.Point(10, 163);
            this.btnList2Clear.Name = "btnList2Clear";
            this.btnList2Clear.Size = new System.Drawing.Size(75, 26);
            this.btnList2Clear.TabIndex = 1;
            this.btnList2Clear.Text = "Clear";
            this.btnList2Clear.UseVisualStyleBackColor = true;
            this.btnList2Clear.Click += new System.EventHandler(this.btnList2Clear_Click);
            // 
            // simpleEditorList2
            // 
            this.simpleEditorList2.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.simpleEditorList2.Location = new System.Drawing.Point(6, 23);
            this.simpleEditorList2.Name = "simpleEditorList2";
            this.simpleEditorList2.Size = new System.Drawing.Size(280, 134);
            this.simpleEditorList2.Styler = null;
            this.simpleEditorList2.TabIndex = 0;
            // 
            // grpList1
            // 
            this.grpList1.Controls.Add(this.lblList1Count);
            this.grpList1.Controls.Add(this.btnList1Copy);
            this.grpList1.Controls.Add(this.btnList1Paste);
            this.grpList1.Controls.Add(this.btnList1Clear);
            this.grpList1.Controls.Add(this.simpleEditorList1);
            this.grpList1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpList1.Location = new System.Drawing.Point(361, 17);
            this.grpList1.Name = "grpList1";
            this.grpList1.Size = new System.Drawing.Size(297, 199);
            this.grpList1.TabIndex = 2;
            this.grpList1.TabStop = false;
            this.grpList1.Text = "List 1";
            // 
            // lblList1Count
            // 
            this.lblList1Count.AutoSize = true;
            this.lblList1Count.Location = new System.Drawing.Point(253, 168);
            this.lblList1Count.Name = "lblList1Count";
            this.lblList1Count.Size = new System.Drawing.Size(43, 18);
            this.lblList1Count.TabIndex = 4;
            this.lblList1Count.Text = "count";
            this.lblList1Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnList1Copy
            // 
            this.btnList1Copy.Location = new System.Drawing.Point(172, 163);
            this.btnList1Copy.Name = "btnList1Copy";
            this.btnList1Copy.Size = new System.Drawing.Size(75, 26);
            this.btnList1Copy.TabIndex = 3;
            this.btnList1Copy.Text = "Copy All";
            this.btnList1Copy.UseVisualStyleBackColor = true;
            this.btnList1Copy.Click += new System.EventHandler(this.btnList1Copy_Click);
            // 
            // btnList1Paste
            // 
            this.btnList1Paste.Location = new System.Drawing.Point(91, 163);
            this.btnList1Paste.Name = "btnList1Paste";
            this.btnList1Paste.Size = new System.Drawing.Size(75, 26);
            this.btnList1Paste.TabIndex = 2;
            this.btnList1Paste.Text = "Paste";
            this.btnList1Paste.UseVisualStyleBackColor = true;
            this.btnList1Paste.Click += new System.EventHandler(this.btnList1Paste_Click);
            // 
            // btnList1Clear
            // 
            this.btnList1Clear.Location = new System.Drawing.Point(9, 163);
            this.btnList1Clear.Name = "btnList1Clear";
            this.btnList1Clear.Size = new System.Drawing.Size(75, 26);
            this.btnList1Clear.TabIndex = 1;
            this.btnList1Clear.Text = "Clear";
            this.btnList1Clear.UseVisualStyleBackColor = true;
            this.btnList1Clear.Click += new System.EventHandler(this.btnList1Clear_Click);
            // 
            // simpleEditorList1
            // 
            this.simpleEditorList1.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.simpleEditorList1.Location = new System.Drawing.Point(6, 23);
            this.simpleEditorList1.Name = "simpleEditorList1";
            this.simpleEditorList1.Size = new System.Drawing.Size(280, 134);
            this.simpleEditorList1.Styler = null;
            this.simpleEditorList1.TabIndex = 0;
            // 
            // tabPage_XmlCommands
            // 
            this.tabPage_XmlCommands.Controls.Add(this.btnXmlSortNodes);
            this.tabPage_XmlCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_XmlCommands.Location = new System.Drawing.Point(4, 29);
            this.tabPage_XmlCommands.Name = "tabPage_XmlCommands";
            this.tabPage_XmlCommands.Size = new System.Drawing.Size(1020, 222);
            this.tabPage_XmlCommands.TabIndex = 2;
            this.tabPage_XmlCommands.Text = "XML Commands";
            this.tabPage_XmlCommands.UseVisualStyleBackColor = true;
            // 
            // btnXmlSortNodes
            // 
            this.btnXmlSortNodes.Location = new System.Drawing.Point(307, 78);
            this.btnXmlSortNodes.Name = "btnXmlSortNodes";
            this.btnXmlSortNodes.Size = new System.Drawing.Size(180, 23);
            this.btnXmlSortNodes.TabIndex = 0;
            this.btnXmlSortNodes.Text = "Sort Nodes and Attribtes";
            this.btnXmlSortNodes.UseVisualStyleBackColor = true;
            this.btnXmlSortNodes.Click += new System.EventHandler(this.btnXmlSortNodes_Click);
            // 
            // tabPage_FindAndReplace
            // 
            this.tabPage_FindAndReplace.Controls.Add(this.btnReplaceNewLineWith);
            this.tabPage_FindAndReplace.Controls.Add(this.label10);
            this.tabPage_FindAndReplace.Controls.Add(this.label9);
            this.tabPage_FindAndReplace.Controls.Add(this.label8);
            this.tabPage_FindAndReplace.Controls.Add(this.txtColumnStartNumber);
            this.tabPage_FindAndReplace.Controls.Add(this.txtColumnEndNumber);
            this.tabPage_FindAndReplace.Controls.Add(this.txtNthOccurrence);
            this.tabPage_FindAndReplace.Controls.Add(this.btnReplaceNewLine);
            this.tabPage_FindAndReplace.Controls.Add(this.btnReplaceAll);
            this.tabPage_FindAndReplace.Controls.Add(this.label7);
            this.tabPage_FindAndReplace.Controls.Add(this.label6);
            this.tabPage_FindAndReplace.Controls.Add(this.txtReplaceText);
            this.tabPage_FindAndReplace.Controls.Add(this.txtFindText);
            this.tabPage_FindAndReplace.Location = new System.Drawing.Point(4, 29);
            this.tabPage_FindAndReplace.Name = "tabPage_FindAndReplace";
            this.tabPage_FindAndReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FindAndReplace.Size = new System.Drawing.Size(1020, 222);
            this.tabPage_FindAndReplace.TabIndex = 5;
            this.tabPage_FindAndReplace.Text = "Find and Replace";
            this.tabPage_FindAndReplace.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Up to this column";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "From this column onwards";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Only nth Occurrence on line";
            // 
            // btnReplaceNewLine
            // 
            this.btnReplaceNewLine.Location = new System.Drawing.Point(354, 34);
            this.btnReplaceNewLine.Name = "btnReplaceNewLine";
            this.btnReplaceNewLine.Size = new System.Drawing.Size(203, 30);
            this.btnReplaceNewLine.TabIndex = 5;
            this.btnReplaceNewLine.Text = "Replace with Line Break";
            this.btnReplaceNewLine.UseVisualStyleBackColor = true;
            this.btnReplaceNewLine.Click += new System.EventHandler(this.btnReplaceStringWithNewLine_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(354, 76);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(203, 30);
            this.btnReplaceAll.TabIndex = 4;
            this.btnReplaceAll.Text = "Replace All";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Replace With";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Find";
            // 
            // txtReplaceText
            // 
            this.txtReplaceText.Location = new System.Drawing.Point(175, 80);
            this.txtReplaceText.Name = "txtReplaceText";
            this.txtReplaceText.Size = new System.Drawing.Size(144, 26);
            this.txtReplaceText.TabIndex = 1;
            // 
            // txtFindText
            // 
            this.txtFindText.Location = new System.Drawing.Point(175, 36);
            this.txtFindText.Name = "txtFindText";
            this.txtFindText.Size = new System.Drawing.Size(144, 26);
            this.txtFindText.TabIndex = 0;
            // 
            // tabPage_Other
            // 
            this.tabPage_Other.Controls.Add(this.label2);
            this.tabPage_Other.Controls.Add(this.btnNimbleText);
            this.tabPage_Other.Location = new System.Drawing.Point(4, 29);
            this.tabPage_Other.Name = "tabPage_Other";
            this.tabPage_Other.Size = new System.Drawing.Size(1020, 222);
            this.tabPage_Other.TabIndex = 4;
            this.tabPage_Other.Text = "Other";
            this.tabPage_Other.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "A brilliant site for taking a bit of skeleton / template text and repeating it fo" +
    "r multiple sets of data. Like a mail merge for developers. Just don\'t put any se" +
    "nsitive data into it!";
            // 
            // btnNimbleText
            // 
            this.btnNimbleText.Location = new System.Drawing.Point(51, 69);
            this.btnNimbleText.Name = "btnNimbleText";
            this.btnNimbleText.Size = new System.Drawing.Size(231, 28);
            this.btnNimbleText.TabIndex = 0;
            this.btnNimbleText.Text = "https://nimbletext.com/Live/";
            this.btnNimbleText.UseVisualStyleBackColor = true;
            this.btnNimbleText.Click += new System.EventHandler(this.btnNimbleText_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 636);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1040, 43);
            this.pnlFooter.TabIndex = 39;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 679);
            this.Controls.Add(this.pnlMainText);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlReadFile);
            this.Controls.Add(this.pnlDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "String Manipulation";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlReadFile.ResumeLayout(false);
            this.pnlReadFile.PerformLayout();
            this.pnlMainText.ResumeLayout(false);
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.tabControls.ResumeLayout(false);
            this.tabPage_LineCommands.ResumeLayout(false);
            this.grpDeletingAndTrimming.ResumeLayout(false);
            this.grpDeletingAndTrimming.PerformLayout();
            this.grpInserting.ResumeLayout(false);
            this.grpInserting.PerformLayout();
            this.tabPage_FileCommands.ResumeLayout(false);
            this.grpDuplicates.ResumeLayout(false);
            this.grpSorting.ResumeLayout(false);
            this.tabPage_ComparingLists.ResumeLayout(false);
            this.grpList2.ResumeLayout(false);
            this.grpList2.PerformLayout();
            this.grpList1.ResumeLayout(false);
            this.grpList1.PerformLayout();
            this.tabPage_XmlCommands.ResumeLayout(false);
            this.tabPage_FindAndReplace.ResumeLayout(false);
            this.tabPage_FindAndReplace.PerformLayout();
            this.tabPage_Other.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private TextBox txtSearchStringA;
        private Button btnDeleteLinesContaining;
        private Button btnDeleteLInesNOTContaining;
        private Label lblRowCount;
        private Button btnTrimBeforeFirst;
        private Button btnTrimAfterLast;
        private Button btnSortAscendingString;
        private Button btnClearText;
        private Button btnCopyAll;
        private Button btnPasteUnProcessed;
        private Button btnRemoveDuplicates;
        private Button btnFindAllItemsThatAreDuplicates;
        private Button btnSum;
        private Button btnInsertAtStartOfEachLine;
        private Label label3;
        private TextBox txtPositionNumberB;
        private Label label4;
        private Label label5;
        private TextBox txtStringToInsertC;
        private Button button1;
        private Button btnInsertAtPosition;
        private ToolTip toolTip1;
        private Label lblHeading;
        private CheckBox chkCaseSensitive;
        private EasyScintilla.SimpleEditor simpleEditorDisplay;
        private Panel pnlReadFile;
        private Panel pnlMainText;
        private Panel pnlDescription;
        private Panel pnlControls;
        private TabControl tabControls;
        private TabPage tabPage_LineCommands;
        private TabPage tabPage_FileCommands;
        private Panel pnlFooter;
        private Button btnUndo;
        private TabPage tabPage_XmlCommands;
        private Button btnRedo;
        private Button btnXmlSortNodes;
        private Button btnSortDescendingString;
        private Button btnTrim;
        private Button btnDeleteBlankLines;
        private Button btnSortDescendingNumeric;
        private Button btnSortAscendingNumeric;
        private Button btnReverseOrder;
        private Button btnSortLineLength;
        private GroupBox grpDeletingAndTrimming;
        private GroupBox grpInserting;
        private GroupBox grpSorting;
        private TabPage tabPage_ComparingLists;
        private Button btnList1AndList2;
        private Button btnList2NotList1;
        private Button btnList1NotList2;
        private GroupBox grpList2;
        private Button btnList2Copy;
        private Button btnList2Paste;
        private Button btnList2Clear;
        private EasyScintilla.SimpleEditor simpleEditorList2;
        private GroupBox grpList1;
        private Button btnList1Copy;
        private Button btnList1Paste;
        private Button btnList1Clear;
        private EasyScintilla.SimpleEditor simpleEditorList1;
        private Label lblList2Count;
        private Label lblList1Count;
        private Button btnOneLine;
        private Button btnFindUnique;
        private GroupBox grpDuplicates;
        private Button btnCountOccurrences;
        private TabPage tabPage_Other;
        private Label label2;
        private Button btnNimbleText;
        private TabPage tabPage_FindAndReplace;
        private Button btnReplaceNewLine;
        private Button btnReplaceAll;
        private Label label7;
        private Label label6;
        private TextBox txtReplaceText;
        private TextBox txtFindText;
        private Label label8;
        private TextBox txtColumnStartNumber;
        private TextBox txtColumnEndNumber;
        private TextBox txtNthOccurrence;
        private Label label10;
        private Label label9;
        private Button btnReplaceNewLineWith;
        private Button btnAppendFileContents;
    }
}

