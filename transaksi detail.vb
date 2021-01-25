Public Class transaksi_detail
    Dim strsql As String
    Dim info As String
    Private _kode_nomor_bukti As String
    Private _kode_kode_obat As String
    Private _kode_nama_obat As String
    Private _kode_jumlah As Integer
    Private _kode_satuan As String
    Private _kode_harga As Integer
    Private _kode_subtotal As Integer
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False

    Public Property kode_nomor_bukti()
        Get
            Return _kode_nomor_bukti
        End Get
        Set(ByVal value)
            _kode_nomor_bukti = value
        End Set
    End Property

    Public Property kode_kode_obat()
        Get
            Return _kode_kode_obat
        End Get
        Set(ByVal value)
            _kode_kode_obat = value
        End Set
    End Property
    Public Property kode_nama_obat()
        Get
            Return _kode_nama_obat
        End Get
        Set(ByVal value)
            _kode_nama_obat = value
        End Set
    End Property
    Public Property kode_jumlah()
        Get
            Return _kode_jumlah
        End Get
        Set(ByVal value)
            _kode_jumlah = value
        End Set
    End Property
    Public Property kode_satuan()
        Get
            Return _kode_satuan
        End Get
        Set(ByVal value)
            _kode_satuan = value
        End Set
    End Property
    Public Property kode_harga()
        Get
            Return _kode_harga
        End Get
        Set(ByVal value)
            _kode_harga = value
        End Set
    End Property
    Public Property kode_subtotal()
        Get
            Return _kode_subtotal
        End Get
        Set(ByVal value)
            _kode_subtotal = value
        End Set

    End Property
    Public Sub GetAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "select nomor_bukti,kode_obat,nama_obat,jumlah,satuan,harga,subtotal from penjualan_detail"
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
        DBConnect()
        strsql = "insert into penjualan_detail(nomor_bukti,kode_obat,nama_obat,jumlah,satuan,harga,subtotal) values ('" & _kode_nomor_bukti & "','" & _kode_kode_obat & "','" & _kode_nama_obat & "','" & _kode_jumlah & "','" & _kode_satuan & "','" & _kode_harga & "','" & _kode_subtotal & "')"
        info = "INSERT"
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
End Class
