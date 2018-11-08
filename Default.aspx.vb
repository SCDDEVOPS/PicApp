Imports System.Data
Imports System.Drawing
Partial Class _Default
    Inherits Page
    Public CMN As Common
    Public data As DB

    Private Sub ProcInit(sender As Object, e As EventArgs) Handles Me.Init
        data = New DB
        CMN = New Common
        Dim UID As String = ""
        Dim upw As String = ""
        Dim PALUSER As String = "Demo User"
        USERNAME.Text = ""
        If Request.Cookies("P2D") Is Nothing Then
            ' NEED YOU TO LOG IN - DO WE NEED TO LOG OUT ???
            Response.Redirect("whodat.aspx")
        Else
            UID = Server.HtmlEncode(Request.Cookies("P2D")("UID"))
            upw = Server.HtmlEncode(Request.Cookies("P2D")("UPW"))
            PALUSER = Server.HtmlEncode(Request.Cookies("P2D")("UNM"))
            USERNAME.Text = PALUSER
        End If


    End Sub

    Private Sub JobEnter_CheckME(sender As Object, e As EventArgs) Handles JobEnter.TextChanged
        Dim T As TextBox = sender
        Dim SQL As String = ""
        Dim DT As DataTable
        Dim bSuccess As Boolean = False
        SQL = "SELECT C.NAME " &
                "FROM MAS_TRAV M " &
                "LEFT JOIN CLIENT C ON C.CLIENTNBR = M.ENDCLIENT " &
               "WHERE M.TRAVEL_TYPE = 'V' " &
                 "AND M.TRAVELORD = '" & Trim(UCase(T.Text)) & "'"
        Try
            DT = data.GetTable(SQL)
            If DT.Rows.Count <= 0 Then
                pnlValid.Visible = True
                btnBad.Visible = False
                btnGood.Visible = False
                lCompany.ForeColor = Color.Red
                lCompany.Text = "Order Not Found! - Try Again."
                T.Text = ""
                T.Focus()
            Else
                lCompany.ForeColor = Color.Black
                lCompany.Text = DT.Rows(0).Item("NAME")

                '                Dim JH As New HiddenField()
                Session("JHOLD") = T.Text
                '                JH = Me.Page.Master.FindControl("jhold")
                '                JH.Value = T.Text

                pnlValid.Visible = True
                btnGood.Visible = True
                btnBad.Visible = True
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GoodButton_Click(sender As Object, e As EventArgs) Handles btnGood.Click

        Response.Redirect("ScanPic.aspx")
        CMN._JobEntry = JobEnter.Text

    End Sub
    Private Sub BadButton_Click(sender As Object, e As EventArgs) Handles btnBad.Click
        pnlValid.Visible = False
        JobEnter.Text = ""
        JobEnter.Focus()
    End Sub

    Private Sub JobEnter_Init(sender As Object, e As EventArgs) Handles JobEnter.Init

    End Sub
End Class