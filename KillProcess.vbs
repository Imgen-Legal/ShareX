On Error Resume Next

Const PROCESS_NAME = "ShareX" 

Set objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")

Set colItems = objWMIService.ExecQuery("Select * from Win32_Process Where Name = '" & PROCESS_NAME & ".exe'")

For Each objItem in colItems
    objItem.Terminate()
Next

Set colItems = Nothing
Set objWMIService = Nothing
