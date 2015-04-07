# cslua
C# version of LUA

The repo is mainly build a clone of LUA 5.2 in C# in order to enable the C# projects having a script language to extend. This includes the windows phone project, CoreCLR projects.

The code mainly inherits from UniLua.

Test Status
===========
Passed:
bitwise.lua
goto.lua
sort.lua
verybig.lua

Missing Features:
calls.lua
main.lua
locale.lua
literals.lua
files.lua
all.lua
attrib.lua

Assert Fail:
big.lua
nextvar.lua
vararg.lua
coroutine.lua
