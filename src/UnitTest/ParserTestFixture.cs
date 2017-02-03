using System;
using NUnit;
using NUnit.Core;
using NUnit.Framework;
using CodeLineCounterLibrary;


namespace UnitTest
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	[TestFixture()]
	public class ParserTestFixture
	{
	
		ILineParser _Parser = null;
		LineCounter _LineCounter = LineCounter.CreateLineCounter();

		public ParserTestFixture()
		{
			
		}

		[SetUp]
		public void SetUp()
		{

			_Parser = _LineCounter.GetLineParser();
		}

		[Test]
		public void TestBegindAndEndComment()
		{
			LineType lineType = LineType.Unassigned;

			lineType = _Parser.Parse("/*Some comment code*/");
			Assert.IsTrue(lineType == LineType.LineComment, "Line should be a full comment");
			
			lineType = _Parser.Parse("void foo(int x, int y, /*int z*/);");
			Assert.IsTrue(lineType == LineType.Code, "Line is code");

			lineType = _Parser.Parse("void foo(int x, int y, /*)");
			Assert.IsTrue(lineType == LineType.BeginComment, "Line type should be begin comment");

			lineType = _Parser.Parse("/*sfsfsdfsdf*/some code/*klsflsfd*/");
			Assert.IsTrue(lineType == LineType.LineComment, "Line type should be line comment");
		}
	}
}
