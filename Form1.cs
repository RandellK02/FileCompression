using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using Microsoft.VisualBasic.FileIO;

namespace FileCompression
{
	/// <summary>
	/// File Explorer Alternate
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        #region vars
        private System.Windows.Forms.Button btnCompress;
		private System.Windows.Forms.TreeView tv1;
		private System.Windows.Forms.ListBox lstFiles;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblDir;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCreated;
		private System.Windows.Forms.Label lblAccess;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblModified;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button Decompress;
        private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private GroupBox groupBox5;
        private ImageList imageList1;
        private BackgroundWorker backgroundWorker1;
        private BackgroundWorker backgroundWorker2;
        private FolderBrowserDialog folderBrowserDialog1;
        private RichTextBox richTextBox1;
        private MenuItem exitMenuItem;
        private Button exportBtn;
        private BackgroundWorker backgroundWorker3;
        private MenuItem menuItem2;
        private MenuItem inheritenceCheck;
        private IContainer components;
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Form1()
		{
			InitializeComponent();
            this.tv1.BeforeExpand += tv1_BeforeExpand;
            this.tv1.AfterCollapse += tv1_AfterCollapse;
            this.tv1.Click += tv1_Click;
            this.tv1.CheckBoxes = false;
		}

        /// <summary>
        /// Event for clicking nodes on the tree view. This event makes sure no other object is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tv1_Click(object sender, EventArgs e)
        {
            if (this.lstFiles.SelectedItem != null)
                lstFiles.SelectedItem = null;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tv1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblModified = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Decompress = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.inheritenceCheck = new System.Windows.Forms.MenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv1
            // 
            this.tv1.AllowDrop = true;
            this.tv1.CheckBoxes = true;
            this.tv1.ImageIndex = 0;
            this.tv1.ImageList = this.imageList1;
            this.tv1.Location = new System.Drawing.Point(32, 27);
            this.tv1.Name = "tv1";
            this.tv1.SelectedImageIndex = 0;
            this.tv1.Size = new System.Drawing.Size(256, 277);
            this.tv1.TabIndex = 0;
            this.tv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "Document.ico");
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(29, 21);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(98, 34);
            this.btnCompress.TabIndex = 2;
            this.btnCompress.Text = "Compress";
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(357, 424);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 34);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.ColumnWidth = 100;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.Location = new System.Drawing.Point(288, 27);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.ScrollAlwaysVisible = true;
            this.lstFiles.Size = new System.Drawing.Size(176, 277);
            this.lstFiles.TabIndex = 4;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblModified);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblAccess);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCreated);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.lblDir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 232);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lblModified
            // 
            this.lblModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModified.Location = new System.Drawing.Point(72, 188);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(215, 23);
            this.lblModified.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Modified";
            // 
            // lblAccess
            // 
            this.lblAccess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccess.Location = new System.Drawing.Point(72, 156);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(215, 23);
            this.lblAccess.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Access";
            // 
            // lblCreated
            // 
            this.lblCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreated.Location = new System.Drawing.Point(72, 124);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(215, 23);
            this.lblCreated.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Created";
            // 
            // lblSize
            // 
            this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSize.Location = new System.Drawing.Point(72, 92);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(215, 23);
            this.lblSize.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Size(Byte)";
            // 
            // lblFile
            // 
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFile.Location = new System.Drawing.Point(72, 60);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(215, 23);
            this.lblFile.TabIndex = 3;
            // 
            // lblDir
            // 
            this.lblDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDir.Location = new System.Drawing.Point(72, 16);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(215, 39);
            this.lblDir.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "File";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dir";
            // 
            // Decompress
            // 
            this.Decompress.Location = new System.Drawing.Point(357, 384);
            this.Decompress.Name = "Decompress";
            this.Decompress.Size = new System.Drawing.Size(98, 34);
            this.Decompress.TabIndex = 6;
            this.Decompress.Text = "Decompress";
            this.Decompress.Click += new System.EventHandler(this.Decompress_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(357, 464);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBox);
            this.groupBox2.Location = new System.Drawing.Point(495, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 232);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Content";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(10, 16);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBox.Size = new System.Drawing.Size(556, 200);
            this.txtBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(16, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 304);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Explorer";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.exportBtn);
            this.groupBox4.Controls.Add(this.btnCompress);
            this.groupBox4.Location = new System.Drawing.Point(328, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 232);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Action";
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(29, 188);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(98, 34);
            this.exportBtn.TabIndex = 7;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.exitMenuItem});
            this.menuItem1.Text = "FIle";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 0;
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Location = new System.Drawing.Point(495, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(572, 304);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Permissions";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(556, 277);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.inheritenceCheck});
            this.menuItem2.Text = "View";
            // 
            // inheritenceCheck
            // 
            this.inheritenceCheck.Index = 0;
            this.inheritenceCheck.Text = "Inheritence";
            this.inheritenceCheck.Click += new System.EventHandler(this.inheritenceCheck_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Decompress);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tv1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "File Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        #endregion

        void tv1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode newSelected = e.Node;
            if(newSelected.FirstNode.Text.Equals("")){
                // Delete the temp node that makes this node expandable
                newSelected.FirstNode.Remove();
                FillDirectory(newSelected.FullPath, newSelected);
            }
        }

        private void tv1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode selected = e.Node;

            if (selected.Nodes.Count > 0)
            {
                for (int i = selected.Nodes.Count - 1; i >= 0; i--)
                {
                    selected.Nodes[i].Remove();
                }

                selected.Nodes.Add("");
            }
        }
		
            
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
            //FileExplorer.ExcelExport.Excel();
		}

		

		private void Form1_Load(object sender, System.EventArgs e)
		{
			btnShowFiles_Click(null, null);
			
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				TreeNode node = e.Node;
				string strFullPath = node.FullPath;
				DisplayFiles(strFullPath);
				lblDir.Text = tv1.SelectedNode.FullPath;
				lblFile.Text = "";
                richTextBox1.Text = "";

				DirectoryInfo fi = new DirectoryInfo(strFullPath);
                System.Security.AccessControl.DirectorySecurity dirSec = fi.GetAccessControl(AccessControlSections.Access);
                    
                // Show the ACEs of the ACL
                //
                int i = 0;
                string stringBuilder = "";
                string stringBuilder2 = ""; // Build detailed list
                foreach (FileSystemAccessRule rule in dirSec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {
                    // Remove Duplicates
                    if(!rule.PropagationFlags.ToString().Equals("None"))
                        continue;

                    if (inheritenceCheck.Checked)
                    {
                        if (!rule.IsInherited)
                        {
                            stringBuilder += "!Inherited--";
                        }
                    }
                    
                    stringBuilder += rule.IdentityReference.ToString() + "\n";
                    stringBuilder2 += string.Format("[{0}] - File path {1} {2} access to {3}\n", i++, rule.AccessControlType == AccessControlType.Allow ? "grants" : "denies", 
                                                  rule.FileSystemRights, rule.IdentityReference);
                   
                }

                richTextBox1.Text += stringBuilder;
                richTextBox1.Text += "\nDetails:\n";
                richTextBox1.Text += stringBuilder2;
				lblFile.Text = "";
				lblSize.Text = "";
				lblCreated.Text = fi.CreationTime.ToString();
				lblAccess.Text = fi.LastAccessTime.ToString();
				lblModified.Text = fi.LastWriteTime.ToString();

			}
			catch{}

		}

		private void DisplayFiles(string dirName)
		{
			try
			{
				lstFiles.Items.Clear();
				// test to see if directory exists
				DirectoryInfo dir = new DirectoryInfo(dirName);

				// fill the Files listbox
				foreach(FileInfo fi in dir.GetFiles())
				{
					lstFiles.Items.Add(fi.Name);
				}
			}
			catch(Exception ex)
			{
				ex.ToString();
			}
		}


		private void btnCompress_Click(object sender, System.EventArgs e)
		{
            if (tv1.SelectedNode != null)
            {
                try
                {
                    Form2.Show("Compressing folder...");
                    backgroundWorker1.RunWorkerAsync(tv1.SelectedNode.FullPath);
                }
                catch
                { }
            }
		}

		private void btnShowFiles_Click(object sender, System.EventArgs e)
		{
			try
			{
                TreeNode node;
                DirectoryInfo dir;
				tv1.Nodes.Clear();
				lstFiles.Items.Clear();
				string[] drives = Environment.GetLogicalDrives();
				foreach ( string drv in drives)
				{
					node = new TreeNode();
					node.Text = drv;
                    node.Tag = drv;
					tv1.Nodes.Add(node);
                    try
                    {
                        dir = new DirectoryInfo(drv);

                        if (dir.GetDirectories().Length != 0)
                            node.Nodes.Add(new TreeNode());
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
				}
			}
			catch(Exception ex)
			{
				ex.ToString();
			}
		}

        private void FillDirectory(string strFullPath, TreeNode parent)
		{
            TreeNode child;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(strFullPath);
                if (!dir.Exists)
                    throw new DirectoryNotFoundException
                        ("directory does not exist:" + strFullPath);
            

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                try
                {
                    child = new TreeNode();

                    if (inheritenceCheck.Checked)
                    {
                        DirectoryInfo fi = new DirectoryInfo(di.FullName);
                        System.Security.AccessControl.DirectorySecurity dirSec = fi.GetAccessControl(AccessControlSections.Access);
                        if (dirSec.GetAccessRules(false, true, typeof(System.Security.Principal.SecurityIdentifier)).Count <= 0)
                        {
                            // -- has no inherited permissions
                            child.BackColor = Color.Aqua;
                        }
                    }

                    child.Text = di.Name;
                    child.Tag = di.FullName;
                    child.ImageKey = "Folder";

                    // Check for children of child, put temp node to make cur node expandable
                    if (di.GetDirectories().Length != 0)
                    {
                        child.Nodes.Add(new TreeNode());
                    }
                    parent.Nodes.Add(child);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
		}

		private void lstFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				lblDir.Text = tv1.SelectedNode.FullPath;
				string path = Path.Combine(tv1.SelectedNode.FullPath, lstFiles.SelectedItem.ToString());
				
				FileInfo fi = new FileInfo(path);

				lblFile.Text = lstFiles.SelectedItem.ToString();
				lblSize.Text = fi.Length.ToString();
				lblCreated.Text = fi.CreationTime.ToString();
				lblAccess.Text = fi.LastAccessTime.ToString();
				lblModified.Text = fi.LastWriteTime.ToString();
				txtBox.Text = "";

				StreamReader rstr = fi.OpenText();
				string []sline = new string[65535];

				// max lines a text box can hold

				int count = 0;

				if (rstr != null)
				{
					count = 0;
					sline[count++] = rstr.ReadLine();
					while (sline[count-1] != null)
					{                              
						sline[count++] = rstr.ReadLine();
						if (count >= 65536) break;
					}
					rstr.Close();

					string []finalSize = new string[count];

					// find exact size of line array otherwise blank

					// blank lines will show up in editor

					for (int i = 0; i < count; i++)

						finalSize[i]=sline[i];

					txtBox.Lines = finalSize;

				}
			}
			catch{}
		}

		private void btnCopy_Click(object sender, System.EventArgs e)
		{
            if (lstFiles.SelectedItem == null)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileSystem.CopyDirectory(tv1.SelectedNode.FullPath, folderBrowserDialog1.SelectedPath, UIOption.AllDialogs);
                }
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = this.lstFiles.SelectedItem.ToString();
                    string fromPath = Path.Combine(this.tv1.SelectedNode.FullPath, fileName);
                    string toPath = folderBrowserDialog1.SelectedPath + @"\" + fileName;
                    FileSystem.CopyFile(fromPath, toPath, UIOption.AllDialogs);
                }
            }
		}

		private void Decompress_Click(object sender, System.EventArgs e)
		{
            Form2.Show("Decompressing folder...");
            backgroundWorker2.RunWorkerAsync(tv1.SelectedNode.FullPath);
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (lstFiles.SelectedItem == null)
                {
                    if (MessageBox.Show("Are you sure you want to delete this direcotry?", "Delete Directory", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Directory.Delete(this.tv1.SelectedNode.FullPath, true);
                        this.tv1.SelectedNode.Remove();
                    }
                }
                else
                {
                    string path = Path.Combine(tv1.SelectedNode.FullPath, lstFiles.SelectedItem.ToString());
                    File.Delete(path);
                }
                
				DisplayFiles(tv1.SelectedNode.FullPath);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        /// <summary>
        /// Redacted. Exchanged for Export button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		///private void btnRefresh_Click(object sender, System.EventArgs e)
		///{
		///    DisplayFiles(tv1.SelectedNode.FullPath);
		///}

        #region Compress Background Workers
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                lzwHelper.Compress.CompressFolder((string)e.Argument);
            }
            catch { throw; }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Form2.Hide();
            DisplayFiles(tv1.SelectedNode.FullPath);
        }
        #endregion

        #region Decompress Background Workers
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            lzwHelper.Decompress.DecompressFolder((string)e.Argument);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Form2.Hide();
            DisplayFiles(tv1.SelectedNode.FullPath);
        }
        #endregion

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This event will put the selected folder, and its subfolders up to 4 levels,
        /// into a Datatable. It will be sent to the ExcelExport class where it will
        /// place the data into a formatted excel workseet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportBtn_Click(object sender, EventArgs e)
        {
            Form2.Show("Generating Report...");
            backgroundWorker3.RunWorkerAsync(this.tv1.SelectedNode);
        }
        
        private void FillTable(ref DataTable table, string filePath, int levels)
        {
            try
            {
                levels--;
                if (levels == 0)
                    return;

                DirectoryInfo dir = new DirectoryInfo(filePath);
                System.Security.AccessControl.DirectorySecurity dirSec;
                String extractedRule;
                Boolean firstLoop = true;

                if (!dir.Exists)
                    throw new DirectoryNotFoundException("directory does not exist");

                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    dirSec = subdir.GetAccessControl(AccessControlSections.Access);
                    foreach (FileSystemAccessRule rule in dirSec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                    {
                        // Remove Duplicates
                        if (!rule.PropagationFlags.ToString().Equals("None"))
                            continue;

                        extractedRule = ExtractFiller(rule.IdentityReference.ToString()).ToUpper();
                        if (extractedRule.Equals(""))
                            continue;
                        if (firstLoop)
                        {
                            table.Rows.Add(subdir.FullName, "");    // add line after directory
                            table.Rows.Add("", extractedRule);
                            firstLoop = false;
                            
                        }
                        else
                            table.Rows.Add("", extractedRule);
                    }
                    firstLoop = true;
                    FillTable(ref table, subdir.FullName, levels);
                }
            }
            catch { }
        }

        /// <summary>
        /// This method will extract out "ITSERVICES\" before each user name.
        /// It will also extract some non user names before putting it in the table.
        /// </summary>
        /// <param name="p">rule to be split</param>
        /// <returns>splitted rule</returns>
        private string ExtractFiller(string rule)
        {
            char delim = '\\';
            string[] words = rule.Split(delim);
            if (words.Length == 1)
                return "";
            else if (words[1].Equals("Administrators") || words[1].Equals("Authenticated Users") || words[1].Equals("Users") ||
                     words[1].Equals("SPIntCrawl") || words[1].Equals("Domain Admins") || words[1].Equals("dtFerret"))
                return "";
            else
                return words[1];
        }

        #region Export Background Worker
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable table = new DataTable();
            TreeNode activeNode = (TreeNode)e.Argument;
            DirectoryInfo dir = new DirectoryInfo(activeNode.Tag.ToString());
            Boolean firstLoop = true;

            FileExplorer.ExportLevels tempForm = new FileExplorer.ExportLevels();
            tempForm.ShowDialog();
            if (tempForm.DialogResult == DialogResult.OK)
            {
                int levels = int.Parse(tempForm.comboBox1.SelectedItem.ToString());

                // Table Headings
                table.Columns.Add("DIRECTORY NAME", typeof(string));
                table.Columns.Add("GROUP RIGHTS", typeof(string));

                // Active node's Permissions
                System.Security.AccessControl.DirectorySecurity dirSec = dir.GetAccessControl();
                String extractedRule;
                foreach (FileSystemAccessRule rule in dirSec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {
                    // Remove Duplicates
                    if (!rule.PropagationFlags.ToString().Equals("None"))
                        continue;

                    extractedRule = ExtractFiller(rule.IdentityReference.ToString()).ToUpper();
                    if (extractedRule.Equals(""))
                        continue;

                    if (firstLoop)
                    {
                        table.Rows.Add(dir, "");    // add line after directory
                        table.Rows.Add("", extractedRule);
                        firstLoop = false;
                    }
                    else
                        table.Rows.Add("", extractedRule);
                }

                FillTable(ref table, activeNode.Tag.ToString(), levels);
                FileExplorer.ExcelExport.Export(table);
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Form2.Hide();
        }
        #endregion

        private void inheritenceCheck_Click(object sender, EventArgs e)
        {
            inheritenceCheck.Checked = !inheritenceCheck.Checked;
        }
    }
}