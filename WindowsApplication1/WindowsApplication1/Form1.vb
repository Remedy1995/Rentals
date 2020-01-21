
Imports System.Data.SqlClient

Public Class Form1

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim i As Integer
    Dim role As String

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=(localDB)\MSSQLLocalDB;AttachDbfilename=c:\users\remedy\documents\visual studio 2015\Projects\WindowsApplication1\WindowsApplication1\remdy.mdf;integrated Security=True"
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()


    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click







    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If con.State = ConnectionState.Open Then
            con.Close()

        End If
        con.Open()
        role = ""
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from registration where username='" + TextBox3.Text + "'and password='" + TextBox4.Text + "'"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While dr.Read
            role = dr.GetString(dr.GetOrdinal("role")).ToString

        End While


        If role.ToString() = "" Then
            MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf role.ToString() = "admin" Then
            Dim am = MDIParent1
            am.Show()
            Me.Hide()




        ElseIf role.ToString() = "user" Then
            Dim um = New UserMDI
            um.Show()
            Me.Hide()



        End If









    End Sub
End Class
