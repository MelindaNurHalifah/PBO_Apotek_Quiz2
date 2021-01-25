Public Class transaksi
    Dim strsql As String
    Dim info As String
    Private _kode_transaksi As String
    Private _kode_obat As String
    Private _harga As Integer
    Private _jumlah As Integer
    Private _total As Integer
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_transaksi()
        Get
            Return _kode_transaksi
        End Get
        Set(ByVal value)
            _kode_transaksi = value
        End Set
    End Property
    Public Property kode_obat()
        Get
            Return _kode_obat
        End Get
        Set(ByVal value)
            _kode_obat = value
        End Set
    End Property
    Public Property harga()
        Get
            Return _harga
        End Get
        Set(ByVal value)
            _harga = value
        End Set
    End Property
    Public Property jumlah()
        Get
            Return _jumlah
        End Get
        Set(ByVal value)
            _jumlah = value
        End Set
    End Property
    Public Property total()
        Get
            Return _total
        End Get
        Set(ByVal value)
            _total = value
        End Set
    End Property
    Public Sub GetAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "select kode_transaksi,kode_obat,harga,jumlah,total from transaksi"
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
        strsql = "insert into transaksi(kode_transaksi,kode_obat,harga,jumlah,total) values ('" & _kode_transaksi & "','" & _kode_obat & "','" & _harga & "','" & _jumlah & "','" & _total & "')"
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
        strsql = "DELETE FROM transaksi WHERE kode_transaksi='" & _kode_transaksi & "'"
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
    Public Sub cariobat(ByVal kodbat As String)
        DBConnect()
        strsql = "SELECT * FROM obat WHERE kode_obat='" & kodbat & "'"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        DR = mycommand.ExecuteReader
        If (DR.HasRows = True) Then
            obat_baru = False
            DR.Read()
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Obat Tidak Ditemukan.")
            obat_baru = True
        End If
        DBDisconnect()
    End Sub
End Class
