using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CodeLineCounterLibrary;

namespace CodeLineCounterApp
{
	/// <summary>
	/// Summary description for Form1.
    /// testing for git
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chbxIncludeSubFolders;
		private System.Windows.Forms.RadioButton rdoFile;
		private System.Windows.Forms.RadioButton rdoFolder;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lblProgressMessage;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ToolTip toolTip1;
		private CodeLineCounterApp.LineCountControl lineCountControl1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lineCountControl1 = new CodeLineCounterApp.LineCountControl();
            this.lblProgressMessage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.chbxIncludeSubFolders = new System.Windows.Forms.CheckBox();
            this.rdoFolder = new System.Windows.Forms.RadioButton();
            this.rdoFile = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblProgressMessage);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 304);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lineCountControl1);
            this.groupBox3.Location = new System.Drawing.Point(8, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 152);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // lineCountControl1
            // 
            this.lineCountControl1.LineCount = null;
            this.lineCountControl1.Location = new System.Drawing.Point(8, 16);
            this.lineCountControl1.Name = "lineCountControl1";
            this.lineCountControl1.Size = new System.Drawing.Size(248, 128);
            this.lineCountControl1.TabIndex = 0;
            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProgressMessage.Location = new System.Drawing.Point(8, 176);
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new System.Drawing.Size(664, 56);
            this.lblProgressMessage.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 240);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(664, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(600, 272);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtPath);
            this.groupBox2.Controls.Add(this.chbxIncludeSubFolders);
            this.groupBox2.Controls.Add(this.rdoFolder);
            this.groupBox2.Controls.Add(this.rdoFile);
            this.groupBox2.Location = new System.Drawing.Point(280, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 152);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Options";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(368, 120);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(8, 120);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(352, 20);
            this.txtPath.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtPath, "NONE");
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // chbxIncludeSubFolders
            // 
            this.chbxIncludeSubFolders.Location = new System.Drawing.Point(16, 72);
            this.chbxIncludeSubFolders.Name = "chbxIncludeSubFolders";
            this.chbxIncludeSubFolders.Size = new System.Drawing.Size(128, 24);
            this.chbxIncludeSubFolders.TabIndex = 5;
            this.chbxIncludeSubFolders.Text = "Include Sub Folders";
            // 
            // rdoFolder
            // 
            this.rdoFolder.Location = new System.Drawing.Point(16, 48);
            this.rdoFolder.Name = "rdoFolder";
            this.rdoFolder.Size = new System.Drawing.Size(64, 24);
            this.rdoFolder.TabIndex = 4;
            this.rdoFolder.Text = "Folder";
            this.rdoFolder.CheckedChanged += new System.EventHandler(this.rdoFolder_CheckedChanged);
            // 
            // rdoFile
            // 
            this.rdoFile.Location = new System.Drawing.Point(16, 24);
            this.rdoFile.Name = "rdoFile";
            this.rdoFile.Size = new System.Drawing.Size(48, 24);
            this.rdoFile.TabIndex = 3;
            this.rdoFile.Text = "File";
            this.rdoFile.CheckedChanged += new System.EventHandler(this.rdoFile_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 326);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "C# Code Line Counter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void ParseFile()
		{
			
			LineCounter lineCounter = LineCounter.CreateLineCounter();

			lineCountControl1.LineCount = lineCounter.ParseFile(txtPath.Text);
		}

		private void ParseFolder()
		{
			lock(this)
			{
				LineCounter lineCounter = LineCounter.CreateLineCounter();
				lineCountControl1.LineCount = lineCounter.ParseDir(txtPath.Text, chbxIncludeSubFolders.Checked, new CodeLineCounterLibrary.ProgressDelegate(OnProgress));
			}
		}

		private int _CurrentFolder = 0;

		private void OnProgress(CodeLineCounterLibrary.LineCounterProgresArgs args)
		{
            if (this.InvokeRequired)
            {
                BeginInvoke( (MethodInvoker)delegate
                                                {
                                                    OnProgress(args);
                                                });
            }
		    else{
                if (_CurrentFolder != args.CurrentFolder)
                {
                    progressBar1.Maximum = args.TotalFolders;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = args.CurrentFolder;
                    _CurrentFolder = args.CurrentFolder;
                }

                if (args.Status == ProgressStatus.Finished)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                if (args.Status == ProgressStatus.Started)
                {
                    progressBar1.Value = progressBar1.Minimum;
                }

                lineCountControl1.LineCount = args.CurrentLineCount;
                lblProgressMessage.Text = args.CurrentMessage;
                lblProgressMessage.Refresh();
		    }

		}

		private void rdoFolder_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoFolder.Checked)
			{
				if(rdoFile.Checked == true)
				{
					rdoFile.Checked = false;
					
				}
			}

			txtPath.Text = "";
			chbxIncludeSubFolders.Enabled = rdoFolder.Checked;;
		}

		private void rdoFile_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdoFile.Checked)
			{
				if(rdoFolder.Checked == true)
				{
					rdoFolder.Checked = false;
				}				
			}

			chbxIncludeSubFolders.Enabled = !rdoFile.Checked;
			txtPath.Text = "";
		
		}

		private void btnRun_Click(object sender, System.EventArgs e)
		{
			if(txtPath.Text == null || txtPath.Text == string.Empty)
			{
				btnBrowse_Click(btnBrowse, new EventArgs());
			}

			lock(this)
			{
				
				System.Threading.Thread t = null;

				if(rdoFile.Checked)
				{
					t = new System.Threading.Thread(new System.Threading.ThreadStart(ParseFile));				
				}
				if(rdoFolder.Checked)
				{
					t = new System.Threading.Thread(new System.Threading.ThreadStart(ParseFolder));
				}

				if(t != null)
				{
					t.Start();
				}
			}
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			if(rdoFolder.Checked)
			{
				if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
				{
					txtPath.Text = folderBrowserDialog1.SelectedPath;
				}
			}
			if(rdoFile.Checked)
			{
				if(openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					txtPath.Text = openFileDialog1.FileName;
				}
			}
		}

		private void txtPath_TextChanged(object sender, System.EventArgs e)
		{
			toolTip1.SetToolTip((Control)sender, ((TextBox)(sender)).Text);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			rdoFolder.Checked = true;
			chbxIncludeSubFolders.Checked = true;
		}
	}
}
