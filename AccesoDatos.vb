Imports MySql.Data.MySqlClient

Public Class AccesoDatos
    Dim txtConexion As String
    Dim conexion As New MySqlConnection

    Public Sub conectar()
        txtConexion = "Server=127.0.0.1; " & _
        "Database=Camping; Uid=root; Pwd=;"

        conexion = New MySqlConnection(txtConexion)
        conexion.Open()
    End Sub

    Public Function Buscar(ByVal Cons As String) As DataSet

        Dim ds As New DataSet

        Dim adap As New MySqlDataAdapter(Cons, conexion)

        If (conexion.State = ConnectionState.Closed) Then
            conexion.Open()
        End If

        adap.Fill(ds, "Tabla")

        conexion.Close()

        Return ds

    End Function
End Class
