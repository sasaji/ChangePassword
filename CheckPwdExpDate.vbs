domain = "00148-BPR"
user = "A0000001"
Set obj = GetObject("WinNT://" & domain & "/" & user & ", user")
WScript.Echo obj.Name
WScript.Echo obj.PasswordExpirationDate
