Imports System.Data
Imports System.Drawing

Partial Class whodat
    Inherits System.Web.UI.Page
    Public CMN As Common
    Public data As DB

    Private Sub GoodButton_Click(sender As Object, e As EventArgs) Handles btnGood.Click
        data = New DB
        CMN = New Common
        Dim UID As String = Trim(UCase(USREnter.Text))
        Dim UPW As String = Trim(USRpass.Text)
        Dim SQL As String = ""
        Dim USERNAME As String = ""
        Dim DT As DataTable
        Dim bSuccess As Boolean = False
        If USREnter.Text = "" Then Exit Sub

        SQL = "SELECT U.FIRSTNAME + ' ' + U.LASTNAME AS UNAME, U.USERPASS " &
                "FROM USERS U " &
               "WHERE U.USER_ID = '" & UID & "' " &
                 "AND U.USERPASS = '" & UPW & "'"
        Try
            DT = data.GetTable(SQL)
            If DT.Rows.Count <= 0 Then
                USREnter.ForeColor = Color.Red
                USREnter.Text = "Invalid Username or Password"
                'MsgBox("Invalid Username or Password" & vbCrLf & "Please try again")
                'USREnter.Text = ""
                USRpass.Text = ""
            Else
                USERNAME = DT.Rows(0).Item("UNAME")
                Response.Cookies("P2D")("UID") = UID
                Response.Cookies("P2D")("UPW") = UPW
                Response.Cookies("P2D")("UNM") = USERNAME
                Response.Cookies("P2D").Expires = DateTime.Now.AddDays(1000)
                bSuccess = True
            End If
        Catch ex As Exception

        End Try
        If bSuccess Then
            Response.Redirect("Default.aspx")
        End If

    End Sub

End Class
