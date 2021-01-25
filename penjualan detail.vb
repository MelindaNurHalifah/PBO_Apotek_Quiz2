Public Class penjualan_detail


    Private Sub ClearEntry()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub Reload()
        otrans.GetAllData(DataGridView1)
    End Sub
    Private Sub simpantransaksi()
        otrans.kode_transaksi = TextBox1.Text
        otrans.kode_obat = TextBox2.Text
        otrans.harga = TextBox3.Text
        otrans.jumlah = TextBox4.Text
        otrans.total = TextBox5.Text
        trans_baru = True
        otrans.Simpan()
        ClearEntry()
        Reload()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub penjualan_detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Reload()

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If (e.KeyCode = Keys.Enter And TextBox2.Text <> "") Then
            otrans.cariobat(TextBox2.Text)
            If (obat_baru = True) Then
                TextBox2.Clear()
            Else
                tampilobat()
            End If
        End If
    End Sub

    Private Sub tampilobat()
        TextBox3.Text = otrans.harga
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub penjualan_detail_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim harga As Double
        Dim jumlah As Double
        Dim total As Double
        If TextBox3.Text = "" Or TextBox4.Text = "" Then
        Else
            harga = Convert.ToDouble(TextBox3.Text)
            jumlah = Convert.ToDouble(TextBox4.Text)
            total = harga * jumlah
            TextBox5.Text = CStr(total)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Isikan data dengan lengkap!", MsgBoxStyle.Exclamation, "Peringatan")
            ClearEntry()
            Reload()
        Else
            TextBox1.Text = RNG()
            simpantransaksi()
            MsgBox("Transaksi Berhasil", MsgBoxStyle.Exclamation, "Peringatan")

        End If
    End Sub
End Class