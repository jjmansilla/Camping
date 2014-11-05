Public Class Loggin

    Dim bbdd As AccesoDatos

    Private Sub Loggin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        bbdd = New AccesoDatos
        bbdd.conectar()
    End Sub

    Private Sub BtCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtCancelar.Click
        TxtUsuario.Text = ""
        TxtContrasena.Text = ""
    End Sub

    Private Sub BtAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtAceptar.Click

        Dim buscar As DataSet = bbdd.Buscar("Select * from login where NombreUser ='" & TxtUsuario.Text & "' and  password ='" & TxtContrasena.Text & "'")
        Dim exist = existe(buscar)

        If (TxtUsuario.Text.Equals("") And TxtContrasena.Text.Equals("")) Then
            MsgBox("Introduzca Usuario y Contraseña")
        ElseIf (TxtUsuario.Text.Equals("")) Then
            MsgBox("Introduzca Usuario")
        ElseIf (TxtContrasena.Text.Equals("")) Then
            MsgBox("Introduzca contraseña")
        Else
            If (exist = True) Then
                Principal.Show()
                Me.Close()
            Else
                MsgBox("Usuario o contraseña invalida")
            End If
        End If
    End Sub

    Private Function existe(sender As DataSet)
        If (sender.Tables(0).Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
