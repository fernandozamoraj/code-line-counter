using System;

namespace CodeLineCounterLibrary
{
	internal class LineCountImp : ILineCount
	{
		public LineCountImp()
		{
			_CommentLines = 0;
			_CodeLines = 0;
			_OtherLines = 0;
		}
		//Fields
		private long _CommentLines;
		private long _CodeLines;
		private long _OtherLines;
		
		#region ILineCount
		//ILineCount
		public long OtherLines
		{
			get
			{
				return _OtherLines;
			}
		}
		public long CommentLines				
		{
			get
			{
				return _CommentLines;
			}
		}

		public long CodeLines
		{
			get
			{
				return _CodeLines;
			}
		}

		public long TotalLines
		{
			get
			{
				return _CommentLines + _CodeLines + _OtherLines;
			}
		}
		#endregion

		public void SetLine(LineType lineType)
		{
			switch(lineType)
			{
				case LineType.BeginComment: 
				case LineType.EndComment: 
				case LineType.LineComment: _CommentLines++; break;
				case LineType.Code: _CodeLines++; break; 
				default: _OtherLines++; break;
			}
		}

		public void Add(ILineCount lineCount)
		{
			this._CodeLines    += lineCount.CodeLines;
			this._CommentLines += lineCount.CommentLines;
			this._OtherLines   += lineCount.OtherLines;
		}
	}

}
