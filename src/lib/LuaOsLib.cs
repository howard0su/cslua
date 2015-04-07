
namespace UniLua
{
	using System;
	using System.Diagnostics;
	using System.IO;
	
	internal class LuaOSLib
	{
		public const string LIB_NAME = "os";

		public static int OpenLib( ILuaState lua )
		{
			NameFuncPair[] define = new NameFuncPair[]
			{
				new NameFuncPair("clock", 	OS_Clock),
				new NameFuncPair("time", 	OS_Time),
				new NameFuncPair("setlocale", OS_SetLocale),
				new NameFuncPair("execute", OS_Execute),
				new NameFuncPair("tmpname", OS_TmpName),
				new NameFuncPair("remove", OS_Remove),
			};

			lua.L_NewLib( define );
			return 1;
		}

		private static int OS_Clock( ILuaState lua )
		{
			lua.PushNumber( Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds );
			return 1;
		}

		private static int OS_Time( ILuaState lua )
		{
			// TODO:
			lua.PushNumber(DateTime.Now.Ticks / 1000000000);
			return 1;
		}

		private static int OS_SetLocale( ILuaState lua )
		{
			lua.PushNumber( Process.GetCurrentProcess().TotalProcessorTime.TotalSeconds );
			return 1;
		}

		private static int OS_Execute( ILuaState lua )
		{
			var cmd = lua.L_OptString(1, null);
			if (cmd == null)
			{
				lua.PushBoolean(true);
			}
			else
			{
				throw new NotImplementedException();
			}
			return 1;
		}

		private static int OS_TmpName( ILuaState lua )
		{
			lua.PushString( Path.GetTempFileName() );
			return 1;
		}
		
		private static int OS_Remove( ILuaState lua )
		{
			var file = lua.L_CheckString(1);
			File.Delete(file);
			return 1;
		}
	}
}

