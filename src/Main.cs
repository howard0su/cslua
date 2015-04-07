namespace UniLua
{
	using System;

	public class Lua
	{
		public static int Main(string[] args)
		{
			string LuaScriptFile = null;
			string LuaScript = null;
			bool enterInteractive;

			// create Lua VM instance
			var Lua = LuaAPI.NewState();

			// load base libraries
			Lua.L_OpenLibs();

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i][0] == '-')
				{
					// this is an option
					switch(args[i])
					{
						case "-e":
						LuaScript = args[i + 1];
						break;

						case "-i":
						enterInteractive = true;
						break;

						case "-l":
						throw new NotImplementedException();
						break;

						case "-v":
						Console.WriteLine("Lua {0} Copyright (C) 2015 CSLua.org\n", LuaDef.LUA_VERSION);
						return 0;
					}
				}
				else
				{
					LuaScriptFile = args[i];
				}
			}

			// load and run Lua script file
			ThreadStatus status;
			if (LuaScript != null)
			{
				status = Lua.L_DoString(LuaScript);
			}
			else if (LuaScriptFile != null)
			{
				status = Lua.L_DoFile( LuaScriptFile );
			}
			else
			{
				throw new NotImplementedException("Interactive mode is not implemented");
			}

			// capture errors
			if( status != ThreadStatus.LUA_OK )
			{
			   Console.WriteLine( Lua.ToString(-1) );
			   return -1;
			}

			return 0;
		}
	}
}