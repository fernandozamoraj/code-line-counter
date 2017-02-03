using System;

namespace CodeLineCounterLibrary
{
	/// <summary>
	/// Summary description for ILineCount.
	/// </summary>
	public interface ILineCount
	{
		long CommentLines{get;}
		long CodeLines{get;}
		long OtherLines{get;}
		long TotalLines{get;}
	}
}
