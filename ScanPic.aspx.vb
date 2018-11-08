Imports System.Web.UI.WebControls
Imports System.Net
Imports System.IO
Imports System.Diagnostics

Partial Class ScanPic
    Inherits System.Web.UI.Page

    Public Sub New()

    End Sub

    Private Sub ProcInit(sender As Object, e As EventArgs) Handles Me.Init

        JOBSHOW.Text = Session("JHOLD")

        If FUP.HasFile Then
            ' MsgBox("i have you now")
        End If

    End Sub

    Private Sub FUPLOAD(SENDER As Object, E As EventArgs) Handles FUP.Load
        Dim ID As Integer = 0
        If FUP.HasFile Then
            For Each F As HttpPostedFile In FUP.PostedFiles
                Dim EXT As String = System.IO.Path.GetExtension(F.FileName)
                ID += 1
                'Bob Changed the below code to add in the date to the filename
                'and to remove the "." being added in.  11/8/2018
                F.SaveAs(MapPath("~/jobimage/" & UCase(JOBSHOW.Text) & "_P2D_" & Format(Now, "MMddyyyy") & "_" & Format(Now, "hhmmss") & "_" & Format(ID, "00") & EXT))
            Next
        End If

        ShowImages()

    End Sub

    Private Sub ShowImages()
        Dim DI As DirectoryInfo
        DI = New DirectoryInfo(MapPath("~/jobimage/"))
        Dim FL As FileInfo() = DI.GetFiles(JOBSHOW.Text & "*.*")
        ''ID = 0
        'Dim files As New List(Of ListItem)()
        Dim Photos As New List(Of String)
        For Each FI As FileInfo In FL
            Dim fileName As String = FI.Name
            'files.Add(New ListItem(fileName, "~/jobimage/" + fileName))
            Photos.Add("~/jobimage/" + UCase(fileName))  'Made filename uppercase for ease of reading BA 11/8/2018
            ''ID += 1
            ''Dim IMG As System.Web.UI.WebControls.Image = CType(FindControl("p0" + ID.ToString), System.Web.UI.WebControls.Image)
            ''IMG.ImageUrl = Server.MapPath("~/jobimage/" & FI.Name)
        Next
        LVIEW.DataSource = Photos
        LVIEW.DataBind()

    End Sub
    Private Sub DLFiles(sender As Object, e As EventArgs) Handles DLImg.Click
        Dim DI As DirectoryInfo
        DI = New DirectoryInfo(MapPath("~/jobimage/"))
        Dim FL As FileInfo() = DI.GetFiles(JOBSHOW.Text & "*.*")
        ''ID = 0
        Dim JN As String = UCase(JOBSHOW.Text)
        Dim YR As String = "20" & Mid(JN, 2, 2)
        Dim CopyToPath As String = "C:\Paladin\Documents\" & YR & "\"
        If Not Directory.Exists(CopyToPath) Then
            Directory.CreateDirectory(CopyToPath)
        End If
        CopyToPath = "C:\Paladin\Documents\" & YR & "\" & JN & "\"
        If Not Directory.Exists(CopyToPath) Then
            Directory.CreateDirectory(CopyToPath)
        End If

        Dim files As New List(Of ListItem)()
        Dim ID As Integer = 0
        For Each FI As FileInfo In FL
            Dim fileName As String = FI.Name
            Do While File.Exists(CopyToPath & fileName)
                ID += 1
                fileName = Path.GetFileNameWithoutExtension(FI.Name) & Format(ID, "00") & "." & Path.GetExtension(FI.Name)
            Loop
            File.Copy(MapPath("~/jobimage/" & FI.Name), CopyToPath & fileName)
            File.Delete(MapPath("~/jobimage/" & FI.Name))
        Next

        Response.Redirect("default.aspx")

    End Sub

End Class
