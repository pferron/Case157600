Imports System.Data.OleDb

Public Class MainForm

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        'retrieve the last rate file used
        My.Settings.LastRateFile = Me.cboRates.Text

        'Verify the Rate File is on the network
        If Not System.IO.Directory.Exists(My.Settings.RateFiles) Then
            MessageBox.Show("Unable to locate folder " & My.Settings.RateFiles & "Please ensure directory exists", _
                            "Missing Rate Files", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If


        'Verify CSO Database exists
        If Not System.IO.File.Exists(My.Settings.CSOdb) Then
            MessageBox.Show("Missiing CSO Database  ", "Missing Critical Data", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If

        'Verify FipscoCS database exists
        If Not System.IO.File.Exists(My.Settings.FipscoCSdb) Then
            MessageBox.Show("Missing FipscoCS Database  ", "Missing Critical Data", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If


        'Verity Rate file exists for selection
        If System.IO.File.Exists(My.Settings.RateFiles & "\" & My.Settings.LastRateFile & "\RateUpdt.dat") Then
            Call UpdateDb(My.Settings.RateFiles & "\" & My.Settings.LastRateFile & "\RateUpdt.dat", _
                          My.Settings.CSOdb, _
                          My.Settings.SystemWG, _
                          "Admin", _
                          "CSO2001")

            Call UpdateDb(My.Settings.RateFiles & "\" & My.Settings.LastRateFile & "\RateUpdt.dat", _
                          My.Settings.FipscoCSdb, _
                          My.Settings.FipscoWG, _
                          "Fipsco", _
                          "FipscoWin*")
        Else
            MessageBox.Show("No Rate File Exists for this Selection  ", "Rate Files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If

        'Verify UL Rate file exist for selection
        If System.IO.File.Exists(My.Settings.RateFiles & "\" & My.Settings.LastRateFile & "\RateUpdtUL.dat") Then
            Call UpdateDb(My.Settings.RateFiles & "\" & My.Settings.LastRateFile & "\RateUpdtUL.dat", _
                          My.Settings.CSOdb, _
                          My.Settings.SystemWG, _
                          "Admin", _
                          "CSO2001")
        Else
            MessageBox.Show("No Rate File Exists for this Selection  ", "Rate Files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If

        My.Settings.Save()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load Rates ComboBox
        Dim colFolders As New System.Collections.Generic.List(Of String)

        If System.IO.Directory.Exists(My.Settings.RateFiles) Then

            colFolders.AddRange(System.IO.Directory.GetDirectories(My.Settings.RateFiles))
        Else
            Me.Close()
            Return
        End If

        If colFolders.Count > 0 Then
            For Each strFolder As String In colFolders
                'Add items file as string to list control
                Me.cboRates.Items.Add(System.IO.Path.GetFileName(strFolder))
            Next
        End If

        Me.cboRates.Text = My.Settings.LastRateFile

    End Sub

    Private Sub UpdateDb(ByVal rateFile As String, ByVal sDatabase As String, ByVal sysDB As String, ByVal uid As String, ByVal pwd As String)


        Dim objConn As New OleDb.OleDbConnection
        Dim sql As String
        Dim objReader As New IO.StreamReader(rateFile)
        Dim objTrans As OleDb.OleDbTransaction



        If sDatabase = My.Settings.CSOdb Then

            objConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0" & _
                                       ";Data Source = " & sDatabase & _
                                       ";Jet OLEDB:Database Password=" & pwd

            objTrans = Nothing

            Try
                objConn.Open()
                objTrans = objConn.BeginTransaction()
                Using objUpdateCmd As New OleDb.OleDbCommand
                    objUpdateCmd.Connection = objConn

                    Do While objReader.Peek() <> -1
                        sql = objReader.ReadLine()

                        If InStr(sql, "rateInterest") > 0 Then
                            sql = Replace(sql, "rateInterest", "rate1")
                        End If


                        If Not sql.Contains("Rates") Then
                            objUpdateCmd.CommandText = sql
                            objUpdateCmd.CommandType = CommandType.Text
                            objUpdateCmd.Transaction = objTrans
                            objUpdateCmd.ExecuteNonQuery()
                        End If

                    Loop
                    objUpdateCmd.Dispose()
                End Using

                objTrans.Commit()

            Catch ex As OleDb.OleDbException
                If objTrans IsNot Nothing Then objTrans.Rollback()
                MessageBox.Show(ex.Message, "Database " & sDatabase & " Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Finally
                objReader.Close()
                objConn.Close()
            End Try

            Me.Close()

        End If






        If sDatabase = My.Settings.FipscoCSdb Then
            objConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0" & _
                                       ";Data Source = " & sDatabase & _
                                       ";Jet OLEDB:System Database=" & sysDB & _
                                       ";User ID=" & uid & _
                                       ";Password=" & pwd

            objTrans = Nothing

            Try

                objConn.Open()
                objTrans = objConn.BeginTransaction()

                Using objUpdateCmd As New OleDb.OleDbCommand
                    objUpdateCmd.Connection = objConn
                    objUpdateCmd.CommandText = "UPDATE Version SET StateDBRatesVersion=1"
                    objUpdateCmd.CommandType = CommandType.Text
                    objUpdateCmd.Transaction = objTrans
                    objUpdateCmd.ExecuteNonQuery()
                    objUpdateCmd.Dispose()
                End Using
                objTrans.Commit()

            Catch ex As OleDb.OleDbException
                If objTrans IsNot Nothing Then objTrans.Rollback()
                MessageBox.Show(ex.Message, "Database " & sDatabase & " Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Finally
                objConn.Close()
                objReader.Close()
            End Try


            Me.Close()

        End If

        System.Diagnostics.Process.Start("C:\Fipsco\Fiplog32.exe", "pgm=IEW")

    End Sub


End Class
