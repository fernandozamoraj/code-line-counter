using System;
using System.IO;

namespace CodeLineCounterLibrary
{
	internal class FileParserImpl: IFileParser
	{
		#region IFileParser
		/// <summary>
		/// Parses the file 
		/// </summary>
		/// <param name="filePath">Full file path of the file</param>
		/// <returns></returns>
		ILineCount IFileParser.Parse(string filePath)
		{
			ILineCount lineCount;

			using(StreamReader sr = new StreamReader(filePath))
			{
				lineCount = ((IFileParser)(this)).Parse((FileStream)sr.BaseStream);
			}

			return lineCount;
		}

		/// <summary>
		/// Parses a file
		/// </summary>
		/// <param name="fileStream">file stream</param>
		/// <returns></returns>
		ILineCount IFileParser.Parse(FileStream fileStream)
		{
			LineCounter lineCounter = LineCounter.CreateLineCounter();

			ILineParser lineParser = lineCounter.GetLineParser();
			fileStream.Position = 0;
			LineCountImp lineCount = new LineCountImp();
		
			if(fileStream.CanRead)
			{
				StreamReader sr = new StreamReader(fileStream);

				bool inComment = false;

				while(sr.Peek() > -1)
				{
					string line = sr.ReadLine();
					LineType lineType = lineParser.Parse(line);

					if(lineType == LineType.BeginComment)
					{
						inComment = true;
					}
					
					lineCount.SetLine((inComment ? LineType.LineComment : lineType));

					if(lineType == LineType.EndComment)
					{
						inComment = false;
					}
				}
			}

			return lineCount;
		}
		#endregion
	}
}
