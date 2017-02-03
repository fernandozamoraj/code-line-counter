using System;
using System.IO;

namespace CodeLineCounterLibrary
{
	/// <summary>
	/// Summary description for IFileParser.
	/// </summary>
	public interface IFileParser
	{
		ILineCount Parse(FileStream fileStream);
		ILineCount Parse(string filePath);
	}
}
