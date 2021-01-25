Public Class login
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        login_valid = oUser.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            MessageBox.Show("selamat datang")
            Form1.Show()
            Me.Hide()
        ElseIf txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Silahkan inputkan username dan password anda.")
            txtUsername.Clear()
            txtPassword.Clear()
        Else
            MessageBox.Show("Akun tidak terdaftar!")
            txtUsername.Clear()
            txtPassword.Clear()
        End If
    End Sub
End Class