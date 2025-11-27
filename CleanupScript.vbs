Dim filesys
Set filesys = CreateObject("Scripting.FileSystemObject")

Dim WshShell
Set WshShell = CreateObject("WScript.Shell")

Dim baseFolder
baseFolder = WshShell.ExpandEnvironmentStrings("%USERPROFILE%") & "\Documents\ImgenShareX\"

Dim filesToDelete(4)
filesToDelete(0) = "ApplicationConfig.json"
filesToDelete(1) = "AuthTokens.json"
filesToDelete(2) = "History.json"
filesToDelete(3) = "HotkeysConfig.json"
filesToDelete(4) = "UploadersConfig.json"

Dim i
Dim filePath

For i = 0 To UBound(filesToDelete)
    filePath = baseFolder & filesToDelete(i)
    
    If filesys.FileExists(filePath) Then
        filesys.DeleteFile filePath, True 
    End If
Next

Set filesys = Nothing
Set WshShell = Nothing