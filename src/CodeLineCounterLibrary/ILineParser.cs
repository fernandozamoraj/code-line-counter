using System;

namespace CodeLineCounterLibrary
{
	/// <summary>
	/// Summary description for IParser.
	/// </summary>
	public interface ILineParser
	{
		LineType Parse(string line);		
	}
}
