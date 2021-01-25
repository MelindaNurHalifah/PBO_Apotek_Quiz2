Imports System.Data.OleDb
Imports System.Security.Cryptography

Module MyMod
    Public mycommand As New System.Data.OleDb.OleDbCommand
    Public myadapter As New System.Data.OleDb.OleDbDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.OleDb.OleDbDataReader
    Public SQL As String
    Public conn As New OleDbConnection
    Public cn As New Connection
    Public oUser As New User
    Public otrans As New transaksi
    Public oobat As New obat
    Public oKemasan As New kemasan
    Public dokter_baru As Boolean
    Public obat_baru As Boolean
    Public oDokter As New dokter
    Public kemasan_baru As Boolean
    Public login_valid As Boolean
    Public trans_baru As Boolean
    Public r As Random = New Random
    Public Sub DBConnect()
        cn.DataSource = "C:\Users\Ros\Documents\praktek.accdb"

        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Public Function RNG()
        Dim res As Double
        res = r.Next(100000, 999999)
        Return res
    End Function
End Module
