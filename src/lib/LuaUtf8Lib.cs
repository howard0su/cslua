namespace UniLua
{
	using System;
	using System.Diagnostics;
	using System.IO;
	
	internal class LuaUtf8Lib
	{
		public const string LIB_NAME = "utf8";

		public static int OpenLib( ILuaState lua )
		{
			NameFuncPair[] define = new NameFuncPair[]
			{
				new NameFuncPair("char", Utf8_Char),
				new NameFuncPair("charpattern", Utf8_CharPattern),
				new NameFuncPair("codes", Utf8_Codes),
				new NameFuncPair("codepoint", Utf8_CodePoint),
				new NameFuncPair("len", Utf8_Len),
				new NameFuncPair("offset", Utf8_Offset),
			};

			lua.L_NewLib( define );
			return 1;
		}

		private static int Utf8_Char( ILuaState lua )
		{
			throw new NotImplementedException();
		}

		private static int Utf8_CharPattern( ILuaState lua )
		{
			throw new NotImplementedException();
		}

		private static int Utf8_Codes( ILuaState lua )
		{
			throw new NotImplementedException();
		}

		private static int Utf8_CodePoint( ILuaState lua )
		{
			throw new NotImplementedException();
		}

		private static int Utf8_Len( ILuaState lua )
		{
			throw new NotImplementedException();
		}

		private static int Utf8_Offset( ILuaState lua )
		{
			throw new NotImplementedException();
		}
	}
}