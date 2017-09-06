Namespace MyCTS.Components

    Public Class MySabreAPI
        Public Const VENDOR As String = "MySabre API Development Team"
        Public Const APPNAME As String = "MySabre API Sample"
        Public Const APPVERSION As String = "1.0"

        Public Const WAIT_FAILED As Integer = &HFFFFFFFF
        Public Const WAIT_OBJECT_0 As Integer = &H0&
        Public Const WAIT_ABANDONED As Integer = &H80&
        Public Const WAIT_TIMEOUT As Integer = &H102&
        Public Const EVENT_ALL_ACCESS As Integer = &H1F0003&

        Public Structure SECURITY_ATTRIBUTES
            Public nLength As Integer
            Public lpSecurityDescriptor As Integer
            Public bInheritHandle As Integer
        End Structure

        Public Declare Function clientConnect Lib "emuapi.dll" (ByVal VendorName As String, ByVal VendorPcc As String, ByVal ApplicationName As String, ByVal ApplicationVersion As String, ByVal Token As String, ByVal TokenLengh As Integer, ByVal ApiRequest As Integer, ByRef Apisupport As Integer) As Integer
        Public Declare Function clientDisconnect Lib "emuapi.dll" () As Integer
        Public Declare Function sendCommandToHost1 Lib "emuapi.dll" (ByVal message As String, ByVal show As Integer) As Integer
        Public Declare Function sendCommandToHost2 Lib "emuapi.dll" (ByVal message As String, ByVal showCommand As Integer, ByVal showResponse As Integer) As Integer
        Public Declare Function sendCommandToHost Lib "emuapi.dll" (ByVal message As String) As Integer
        Public Declare Function sendCommandToEmulator Lib "emuapi.dll" (ByVal message As String) As Integer
        Public Declare Function sendMsg Lib "emuapi.dll" (ByVal message As String, ByVal show As Integer) As Integer
        Public Declare Function receiveMsg Lib "emuapi.dll" (ByVal buffer As String, ByVal length As Integer, ByRef actualLength As Integer, ByVal eomChar As String, ByVal c1c2Char As String, ByVal timeout As Long) As Integer
        Public Declare Function sendReceiveMsg Lib "emuapi.dll" (ByVal message As String, ByVal msgLength As Integer, ByVal buffer As String, ByVal bufLength As Integer, ByRef actualLength As Integer, ByVal eomChar As String, ByVal c1c2 As String, ByVal timeout As Long) As Integer
        Public Declare Function getLineIaTa Lib "emuapi.dll" (ByVal buffer As String, ByRef length As Integer) As Integer
        Public Declare Function getLastErrorCode Lib "emuapi.dll" () As Integer
        Public Declare Function getLastError Lib "emuapi.dll" (ByVal buffer As String, ByRef length As Integer) As Integer
        Public Declare Function sendMessageToEmulator Lib "emuapi.dll" (ByVal message As String) As Integer
        Public Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Long, ByVal lpProcName As String) As Long
        Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Long
        Public Declare Function FreeLibrary Lib "kernel32.dll" (ByVal hModule As Integer) As Boolean
        'Declare Function GetModuleHandleExA Lib "kernel32.dll" (ByVal dwFlags As Integer, ByVal ModuleName As String, ByRef phModule As IntPtr) As Boolean
        Public Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Integer


        Public Declare Function CreateEvent Lib "kernel32" Alias "CreateEventA" _
            (ByRef lpEventAttributes As SECURITY_ATTRIBUTES, ByVal bManualReset As Integer, _
             ByVal bInitialState As Integer, ByVal lpName As String) As Integer


        Public Declare Function WaitForMultipleObjects Lib "kernel32" (ByVal nCount As Integer, _
                ByRef lpHandles As Integer, ByVal bWaitAll As Integer, ByVal dwMilliseconds _
                As Integer) As Integer

        Public Declare Function OpenEvent Lib "kernel32" Alias "OpenEventA" _
        (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, _
        ByVal lpName As String) _
        As Integer


        Public Declare Function WaitForSingleObject Lib "kernel32" (ByVal _
        hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer

        Public Declare Function ResetEvent Lib "kernel32" (ByVal hEvent As Long) As Long

        Public Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Long

    End Class

End Namespace