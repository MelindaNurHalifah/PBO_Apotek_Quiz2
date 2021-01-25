Public Class obat
    Dim strsql As String
    Dim info As String
    Private _kode_obat As String
    Private _nama_obat As String
    Private _bentuk_obat As String
    Private _harga_obat As Integer
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_obat()
        Get
            Return _kode_obat
        End Get
        Set(ByVal value)
            _kode_obat = value
        End Set
    End Property
    Public Property nama_obat()
        Get
            Return _nama_obat
        End Get
        Set(ByVal value)
            _nama_obat = value
        End Set
    End Property
    Public Property bentuk_obat()
        Get
            Return _bentuk_obat
        End Get
        Set(ByVal value)
            _bentuk_obat = value
        End Set
    End Property
    Public Property harga_obat()
        Get
            Return _harga_obat
        End Get
        Set(ByVal value)
            _harga_obat = value
        End Set
    End Property
    Public Sub GetAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "select kode_obat,nama_obat,bentuk_obat,harga from obat"
            mycommand.Connection = conn
            mycommand.CommandText = strsql
            mydata.Clear()
            myadapter.SelectCommand = mycommand
            myadapter.Fill(mydata)
            With dg
                .DataSource = mydata
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        '   If (obat_baru = True) Then
        strsql = "insert into obat(kode_obat,nama_obat,bentuk_obat,harga) values ('" & _kode_obat & "','" & _nama_obat & "','" & _bentuk_obat & "','" & _harga_obat & "')"
        info = "INSERT"
        '      Else
        '       strsql = "update obat set kode_obat='" & _kode_obat & "', nama_obat='" & _nama_obat & "', bentuk_obat='" & _bentuk_obat & "', harga='" & _harga_obat & "' where kode_obat='" & _kode_obat & "'"
        '       info = "UPDATE"
        '      End If
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Hapus()
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM obat WHERE kode_obat='" & _kode_obat & "'"
        info = "DELETE"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub cariobat(ByVal snim As String)
        DBConnect()
        strsql = "SELECT * FROM obat WHERE kode_obat='" & _kode_obat & "'"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        DR = mycommand.ExecuteReader
        If (DR.HasRows = True) Then
            obat_baru = False
            DR.Read()
            kode_obat = Convert.ToString((DR("kode_obat")))
            nama_obat = Convert.ToString((DR("nama_obat")))
            bentuk_obat = Convert.ToString((DR("bentuk_obat")))
            harga_obat = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            obat_baru = True
        End If
        DBDisconnect()
    End Sub
End Class
