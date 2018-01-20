using System;

namespace CodeLineCounterLibrary
{
	/// <summary>
	/// Summary description for LineType.
	/// </summary>
	public enum LineType
	{
		Unassigned,
		BeginComment,
		LineComment,
		Blank,
		Code,
		EndComment,
        BeginRegion,
		EndRegion,
	}
    //
}
