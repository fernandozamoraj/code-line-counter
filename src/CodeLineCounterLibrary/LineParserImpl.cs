using System;

namespace CodeLineCounterLibrary
{
	/// <summary>
	/// Summary description for LineParserImp.
	/// </summary>
	
	#region LineParserImpl
	/// <summary>
	/// Summary description for LineParserImpl.
	/// </summary>
	internal class LineParserImpl : ILineParser
	{
		private static LineParserImpl _Instance = null;

		private LineParserImpl()
		{
				
		}

		public static ILineParser GetLineParser()
		{
			if(_Instance == null)
			{
				_Instance = new LineParserImpl();
			}

			return _Instance;
		}

		#region IParser Members
		public CodeLineCounterLibrary.LineType Parse(string line)
		{	
			LineType lineType = LineType.Unassigned;

			string temp = line.TrimStart();

			if(temp.Trim() == string.Empty)
			{
				lineType = LineType.Blank;
			}
			else if(temp.StartsWith("#region"))
			{
				lineType = LineType.BeginRegion;
			}
			else if(temp.StartsWith("#endregion"))
			{
				lineType = LineType.EndRegion;
			}
			else if(temp.StartsWith("//"))
			{
				lineType = LineType.LineComment;
			}
			else if(temp.StartsWith("/*"))
			{
				int startIndex = 0;
				bool commentClosed = false;

				commentClosed = CommentClosed(temp, startIndex);
			
				if(commentClosed)
				{
					lineType = LineType.LineComment;
				}
				else
				{
					lineType = LineType.BeginComment;
				}
			}
			else if(temp.EndsWith("*/"))
			{
				lineType = LineType.EndComment;		 
			}	
			else if(temp.IndexOf("/*") > 0)
			{
				int startIndex = 1;
				bool commentClosed = false;

				commentClosed = CommentClosed(temp, startIndex);
			
				if(commentClosed)
				{
					lineType = LineType.Code;
				}
				else
				{
					lineType = LineType.BeginComment;
				}				
			}
			else if(temp.IndexOf("*/") > -1)
			{
				lineType = LineType.EndComment;
			}
			else 
			{
				lineType = LineType.Code;
			}

			return lineType;
		}

		public bool CommentClosed(string line, int startIndex)
		{
			string temp = line;
			bool commentClosed = false;

			while(temp.IndexOf("/*", startIndex) > -1)
			{
				commentClosed = false;
				startIndex = temp.IndexOf("*/", startIndex+2);

				if(startIndex < 0)
				{
					break;
				}
				else
				{
					//Found the closing tag to that comment
					commentClosed = true;
				}
			}

			return commentClosed;			
		}

		#endregion
	}
	#endregion
}
