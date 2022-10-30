Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim con As SqlConnection = New SqlConnection("Data Source=LAPTOP-OJC1HEI8\SQLEXPRESS;Initial Catalog=DEMO;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("select NAME,ID,POSITION from Emp_detail where NAME=@NAME", con)
            cmd.Parameters.AddWithValue("NAME", TextBox1.Text)
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            If myreader.Read() Then
                TextBox1.Text = myreader("NAME")
                TextBox2.Text = myreader("ID")
                TextBox3.Text = myreader("POSITION")
            Else
                MessageBox.Show("No Data Found")
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim con As SqlConnection = New SqlConnection("Data Source=LAPTOP-OJC1HEI8\SQLEXPRESS;Initial Catalog=DEMO;Integrated Security=True")
            Dim cmd1 As New SqlCommand
        Dim myreader As SqlDataReader
        Try
            con.Open()
            Dim query As String
            query = "insert into Emp_detail(NAME,ID,POSITION) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "') "
            cmd1 = New SqlCommand(query, con)
            myreader = cmd1.ExecuteReader
            If myreader.Read() Then
                TextBox1.Text = myreader("NAME")
                TextBox2.Text = myreader("ID")
                TextBox3.Text = myreader("POSITION")
            Else
                MessageBox.Show("Fill the Data")
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class
