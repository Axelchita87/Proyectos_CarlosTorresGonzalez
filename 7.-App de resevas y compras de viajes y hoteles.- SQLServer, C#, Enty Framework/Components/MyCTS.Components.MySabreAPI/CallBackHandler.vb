Namespace MyCTS.Components
    Public Module CallBackHandler
        Public Delegate Function MySabreCallback(ByVal messageType As Integer, ByVal message As String) As Integer
        Public Delegate Function MySabreSharedSessionCallback(ByVal messageType As Integer, ByVal message As String) As Integer
        Public Delegate Function MySabreMarkupCallback(ByVal messageType As Integer, ByVal message As String, ByVal properties As String) As Integer
        Public Declare Function beginSabreTrafficListener_stdcall Lib "emuapi.dll" (ByVal trafficType As Integer, ByVal listener As MySabreCallback) As Integer
        Public Declare Function endSabreTrafficListener_stdcall Lib "emuapi.dll" (ByVal listener As MySabreCallback) As Integer
        Public Declare Function registerSabreMarkup_stdcall Lib "emuapi.dll" (ByVal tempSabreMarkupHandler As MySabreMarkupCallback, ByVal properties As String) As Integer
        Public Declare Function unRegisterSabreMarkup Lib "emuapi.dll" () As Integer
        Public Declare Function sendMarkup Lib "emuapi.dll" (ByVal properties As String) As Integer

        Public Declare Function lockSession_stdcall Lib "emuapi.dll" (ByVal listener As MySabreSharedSessionCallback) As Integer
        Public Declare Function unlockSession_stdcall Lib "emuapi.dll" (ByVal listener As MySabreSharedSessionCallback) As Integer
    End Module
End Namespace

