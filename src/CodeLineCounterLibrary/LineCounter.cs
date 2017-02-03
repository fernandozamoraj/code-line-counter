using System;
using System.IO;
using System.Collections;

namespace CodeLineCounterLibrary
{
	public class LineCounter
	{
		private static LineCounter _Instance = null;

		private LineCounter()
		{
		
		}

		public static LineCounter CreateLineCounter()
		{
			if(_Instance == null)
			{
				_Instance = new LineCounter();
			}

			return _Instance;
		}

		/// <summary>
		/// Gets a line parser 
		/// </summary>
		/// <returns>Line Parser</returns>
		public ILineParser GetLineParser()
		{
			return LineParserImpl.GetLineParser();
		}

		/// <summary>
		/// Method to retrieve a file parser
		/// </summary>
		/// <returns></returns>
		public IFileParser GetFileParser()
		{
			return new FileParserImpl();
		}

		/// <summary>
		/// Method to parse the file
		/// </summary>
		/// <param name="path">Full file path</param>
		/// <returns>line count interface</returns>
		public ILineCount ParseFile(string path)
		{
			IFileParser fileParser = GetFileParser();

			return fileParser.Parse(path);
		}

		/// <summary>
		/// Method that parses several files
		/// </summary>
		/// <param name="files">Array of file names</param>
		/// <returns>Line count</returns>
		public ILineCount ParseFiles(string[] files)
		{
			LineCountImp lineCount = new LineCountImp();

			foreach(string file in files)
			{
				ILineCount temp = ParseFile(file);

				lineCount.Add(temp);			
			}

			return lineCount;
		}

		/// <summary>
		/// Parses the files for counting within a given directory. Subfolders are not included.
		/// </summary>
		/// <param name="directory">Full path of the directory to parse</param>
		/// <param name="OnProgress">Call back delegate for providing progress information</param>
		/// <returns>Line count object</returns>
		public ILineCount ParseDir(string directory, ProgressDelegate OnProgress)
		{
			return ParseDir(directory, false, OnProgress);
		}

		/// <summary>
		/// Parses directory
		/// </summary>
		/// <param name="directory">Full folder path</param>
		/// <param name="includeSubFolders">True if subfolders should be included</param>
		/// <param name="OnProgress">Call back delegate for providing progress information</param>
		/// <returns>Line Count Interface</returns>
		public ILineCount ParseDir(string directory, bool includeSubFolders, ProgressDelegate OnProgress)
		{
			LineCountImp lineCount = new LineCountImp();
			ArrayList alFolders = new ArrayList();
            LineCounterProgresArgs args = new LineCounterProgresArgs();
			int fileCount = 0;

			args.CurrentLineCount = lineCount;
			
			if(OnProgress != null)
			{
				args.Status = ProgressStatus.Started;
				args.CurrentMessage = "Process started";
				OnProgress(args);
				args.Status = ProgressStatus.MidProcess;
			}
			
			if(includeSubFolders)
			{
				GetDirectories(directory, alFolders, OnProgress);
			}
			else
			{
				alFolders.Add(directory);
			}
			
			args.TotalFolders = alFolders.Count;
			args.CurrentMessage = "Total Folders: " + alFolders.Count;

			if(OnProgress != null)
			{
				OnProgress(args);
			}

			foreach(string folder in alFolders)
			{
				args.CurrentFile = 0;
				args.CurrentFolder++;
				args.FolderName = folder;
                string[] files = null;

               
				string[] fileExtensions = new string[]{"*.java","*.cs", "*.c", "*.cpp", "*.vb"};

				foreach(string fileExtension in fileExtensions)
				{
					try
					{
						files = System.IO.Directory.GetFiles(folder, fileExtension);
					}
					catch(Exception exc)
					{
						Console.WriteLine(exc.ToString());
						continue;
					}
					args.TotalFilesInCurrentFolder = files.Length;

					foreach(string file in files)
					{
						#region Call Back OnProgress
						if(OnProgress != null)
						{
							args.CurrentFile++;
							args.FileName = file;
							args.CurrentMessage = "Processing File: " + file;
							OnProgress(args);
						}
						#endregion

						ILineCount temp = ParseFile(file);
						lineCount.Add(temp);
						fileCount++;
					}
				}
			}

			if(OnProgress != null)
			{
				args.Status = ProgressStatus.Finished;
				args.CurrentMessage = string.Format("Process Finished! \r\nTotal Folders Processed: {0} \r\nTotal Files Processed: {1}", alFolders.Count, fileCount);
				OnProgress(args);
			}
			
			return lineCount;
		}

		/// <summary>
		/// Method for retriveing the sub directories within this folder.
		/// Method is recursive and retrieves all sub folders. 
		/// </summary>
		/// <param name="root">Full folder path</param>
		/// <param name="alFolders">Array list to store the folders in</param>
		/// <param name="OnProgress">Call back method to provide progress information</param>
		public void GetDirectories(string root, ArrayList alFolders,  ProgressDelegate OnProgress)
		{
			if(OnProgress != null)
			{
				CodeLineCounterLibrary.LineCounterProgresArgs args = new LineCounterProgresArgs();
				args.CurrentMessage = "Querying Folder: " + root;
				OnProgress(args);
			}

			alFolders.Add(root);
            string[] folders = System.IO.Directory.GetDirectories(root);

			foreach(string folder in folders)
			{
				try
				{
					GetDirectories(folder, alFolders, OnProgress);
				}
				catch(Exception exc)
				{
					Console.WriteLine(exc.Message);
				}
			}
		}
	}
}
