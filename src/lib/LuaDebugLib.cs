
namespace UniLua
{
	internal class LuaDebugLib
	{
		public const string LIB_NAME = "debug";

		public static int OpenLib( ILuaState lua )
		{
			NameFuncPair[] define = new NameFuncPair[]
			{
				new NameFuncPair( "traceback", 	DBG_Traceback	),
				new NameFuncPair( "upvalueid", 	DBG_UpValueId	),
				new NameFuncPair( "getinfo", 	DBG_GetInfo 	),
			};

			lua.L_NewLib( define );
			return 1;
		}

		private static int DBG_Traceback( ILuaState lua )
		{
			return 0;
		}

		private static int DBG_UpValueId( ILuaState lua )
		{
			lua.PushNumber(1);
			return 1;
		}

		private static int DBG_GetInfo( ILuaState lua )
		{
			LuaDebug ar = new LuaDebug();
			int level = lua.L_CheckInteger(1);
			if( lua.GetStack( level, ar ) ) //
			{
				((LuaState)lua).GetInfo( "Sl", ar );

				lua.NewTable();
				lua.PushString("currentline");
				lua.PushNumber(ar.CurrentLine);
				lua.SetTable(-2);
				lua.PushString("source");
				lua.PushString(ar.Source);
				lua.SetTable(-2);
			}
			else
			{
				lua.PushNil();
			}
			return 1;
		}
	}
}

