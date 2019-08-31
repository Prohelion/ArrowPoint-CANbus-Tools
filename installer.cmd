call build.cmd

del Installer\ArrowPointCANBusTool.exe
del Installer\Prohelion.exe

copy /Y ArrowPoint-CANbus-Tools\bin\Release\ArrowPointCANBusTool.exe Installer

makensis Installer\CanBusTools.nsi