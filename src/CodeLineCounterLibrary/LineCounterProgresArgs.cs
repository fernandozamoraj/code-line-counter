using System;

namespace CodeLineCounterLibrary
{
	/// <summary>
	/// Summary description for LineCounterProgresArgs.
	/// </summary>
	public class LineCounterProgresArgs
	{
		public LineCounterProgresArgs()
		{
			CurrentFolder = 0;
			TotalFolders  = 0;
			CurrentFile   = 0;
			FileName      = "";
			FolderName    = "";
			TotalFilesInCurrentFolder = 0;
			CurrentMessage = "";
		}

		private ProgressStatus _Status;
		public int CurrentFolder;
		public int TotalFolders;
		public int TotalFilesInCurrentFolder;
		public int CurrentFile;
		public string FileName;
		public string FolderName;
		private string _CurrentMessage;
		public ILineCount CurrentLineCount;

		public ProgressStatus Status
		{
			get
			{
				return _Status;
			}
			set
			{
				_Status = value;
			}
		}
		public string CurrentMessage
		{
			get
			{
				return _CurrentMessage;
			}
			set
			{
				_CurrentMessage = value;
			}
		}
	}
}
