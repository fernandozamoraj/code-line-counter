using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CodeLineCounterApp
{
	/// <summary>
	/// Summary description for LineCount.
	/// </summary>
	public class LineCountControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtComments;
		private System.Windows.Forms.TextBox txtCodeLines;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.Label label3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtOtherLines;
		private System.Windows.Forms.Label label4;

		private CodeLineCounterLibrary.ILineCount _LineCount;

		public CodeLineCounterLibrary.ILineCount LineCount
		{
			get
			{
				return _LineCount;
			}
			set
			{
				_LineCount = value;

				UpdateControl();
			}
		}

		private void UpdateControl()
		{
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(UpdateControl));                
            }
            else
            {
                if (LineCount != null)
                {
                    string format = "###,###,###,###,###;Zero";

                    this.txtCodeLines.Text = this.LineCount.CodeLines.ToString(format);
                    this.txtComments.Text = this.LineCount.CommentLines.ToString(format);
                    this.txtOtherLines.Text = this.LineCount.OtherLines.ToString(format);
                    this.txtTotal.Text = this.LineCount.TotalLines.ToString(format);
                }
                else
                {
                    this.txtCodeLines.Text = "0";
                    this.txtComments.Text = "0";
                    this.txtOtherLines.Text = "0";
                    this.txtTotal.Text = "0";
                }

                Refresh();
            }

			
		}

		public LineCountControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.txtCodeLines = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtOtherLines = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Comments:";
			// 
			// txtComments
			// 
			this.txtComments.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtComments.Location = new System.Drawing.Point(88, 8);
			this.txtComments.Name = "txtComments";
			this.txtComments.Size = new System.Drawing.Size(144, 20);
			this.txtComments.TabIndex = 1;
			this.txtComments.Text = "";
			this.txtComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCodeLines
			// 
			this.txtCodeLines.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtCodeLines.Location = new System.Drawing.Point(88, 37);
			this.txtCodeLines.Name = "txtCodeLines";
			this.txtCodeLines.Size = new System.Drawing.Size(144, 20);
			this.txtCodeLines.TabIndex = 3;
			this.txtCodeLines.Text = "";
			this.txtCodeLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Code Lines:";
			// 
			// txtTotal
			// 
			this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtTotal.Location = new System.Drawing.Point(88, 95);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(144, 20);
			this.txtTotal.TabIndex = 5;
			this.txtTotal.Text = "";
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Total Lines:";
			// 
			// txtOtherLines
			// 
			this.txtOtherLines.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtOtherLines.Location = new System.Drawing.Point(88, 66);
			this.txtOtherLines.Name = "txtOtherLines";
			this.txtOtherLines.Size = new System.Drawing.Size(144, 20);
			this.txtOtherLines.TabIndex = 7;
			this.txtOtherLines.Text = "";
			this.txtOtherLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Other Lines:";
			// 
			// LineCountControl
			// 
			this.Controls.Add(this.txtOtherLines);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCodeLines);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtComments);
			this.Controls.Add(this.label1);
			this.Name = "LineCountControl";
			this.Size = new System.Drawing.Size(248, 128);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
