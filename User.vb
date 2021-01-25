Public Class User
    Dim strsql As String
    Dim info As String
    Private _iduser As Integer
    Private _username As String
    Private _nama_lengkap As String
    Private _passwd As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property username()
        Get
            Return _username
        End Get
        Set(ByVal value)
            _username = value
        End Set
    End Property
    Public Property nama_lengkap()
        Get
            Return _nama_lengkap
        End Get
        Set(ByVal value)
            _nama_lengkap = value
        End Set
    End Property
    Public Property passwd()
        Get
            Return _passwd
        End Get
        Set(ByVal value)
            _passwd = value
        End Set
    End Property
    Public Function Login(ByVal uname As String, ByVal pwd As String) As Boolean
        Dim pwd_en As String
        pwd_en = getMD5Hash(pwd)
        DBConnect()
        strsql = "SELECT * FROM [user] WHERE username='" & uname & "' and pasSwd ='" & pwd_en & "'"

        myCommand.Connection = conn
        mycommand.CommandText = strsql
        DR = mycommand.ExecuteReader()
        If (DR.HasRows = True) Then
            login_valid = True
        Else
            login_valid = False
        End If
        DBDisconnect()
        Return login_valid
    End Function
    '  Public Sub Simpan()
    'Dim info As String
    '   DBConnect()
    '  If (user_baru = True) Then
    '     strsql = "Insert into penjualan_detail (nomor_bukti, kode_obat,nama_obat,jumlah,satuan,harga) values ('" & _username & "','" & _nama_lengkap & "','" & _passwd & "')"
    '    info = "INSERT"
    '    Else
    '       strsql = "update user set username='" & _username & "', nama_lengkap='" & _nama_lengkap & "', passwd='" & _passwd & "' where username='" & _username & "'"
    '      info = "UPDATE"
    '  End If
    ' myCommand.Connection = conn
    'myCommand.CommandText = strsql
    ' Try
    '    myCommand.ExecuteNonQuery()
    'Catch ex As Exception
    '   If (info = "INSERT") Then
    '      InsertState = False
    ' ElseIf (info = "UPDATE") Then
    '     UpdateState = False
    'Else
    ' End If
    'Finally
    '   If (info = "INSERT") Then
    '      InsertState = True
    ' ElseIf (info = "UPDATE") Then
    '    UpdateState = True
    'Else
    'End If
    ' End Try
    'DBDisconnect()
    'End Sub
End Class
