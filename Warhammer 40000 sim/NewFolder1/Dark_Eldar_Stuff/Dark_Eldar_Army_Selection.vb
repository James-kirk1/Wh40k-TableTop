Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Public Class Dark_Eldar_Army_Selection
    Public units As New DataTable

    Private Sub Dark_Eldar_Army_Selection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        units.Columns.Add("GroupName")
        units.Columns.Add("UnitName1")
        units.Columns.Add("MinNumber1")
        units.Columns.Add("MaxNumber1")
        units.Columns.Add("UnitName2")
        units.Columns.Add("MinNumber2")
        units.Columns.Add("MaxNumber2")
        units.Columns.Add("UnitName3")
        units.Columns.Add("MinNumber3")
        units.Columns.Add("MaxNumber3")
        units.Columns.Add("UnitName4")
        units.Columns.Add("MinNumber4")
        units.Columns.Add("MaxNumber4")
        units.Columns.Add("UnitName5")
        units.Columns.Add("MinNumber5")
        units.Columns.Add("MaxNumber5")
        units.Columns.Add("UnitName6")
        units.Columns.Add("MinNumber6")
        units.Columns.Add("MaxNumber6")
        'Race_Selection_Form.playeronerace = 15
        Dim doc As New XmlDocument()
        doc.LoadXml(My.Resources.Groups___Units)
        Dim RaceNumber As Integer = 1 '' number as it appears in "Groups & Units"
        Dim ChapterList As XmlNodeList = doc.SelectNodes("/Data")
        For Each element As XmlElement In ChapterList



            If element.ChildNodes(RaceNumber).Attributes("Name").Value = "DarkEldar" Then
                For y As Integer = 0 To (element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes().Count - 1)
                    For x As Integer = 0 To (element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes().Count - 1)
                        Select Case element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes().Count
                            Case Is = 3
                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml)
                            Case Is = 6
                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml)
                            Case Is = 9
                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml)
                            Case Is = 12
                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(9).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(10).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(11).InnerXml)
                            Case Is = 15
                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(9).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(10).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(11).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(12).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(13).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(14).InnerXml)
                            Case Is = 18
                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(9).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(10).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(11).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(12).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(13).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(14).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(15).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(16).InnerXml, _
                   element.ChildNodes(RaceNumber).ChildNodes(0).ChildNodes(y).ChildNodes(x).ChildNodes(17).InnerXml)
                        End Select


                    Next
                Next
            End If
        Next
        For x = 0 To units.Rows.Count - 1
            If units.Rows(x).Item(0) = "UrGhul" Then
                units.Rows(x).Item(0) = "Ur-Ghul"
            End If
        
        Next
        For x = 0 To units.Rows.Count - 1
            ComboBox1.Items.Add(units.Rows(x).Item(0))
        Next
        ComboBox1.Sorted = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        NumericUpDown1.Visible = False
        Label1.Visible = False
        NumericUpDown2.Visible = False
        Label2.Visible = False
        NumericUpDown3.Visible = False
        Label3.Visible = False
        NumericUpDown4.Visible = False
        Label4.Visible = False
        NumericUpDown5.Visible = False
        Label5.Visible = False
        NumericUpDown6.Visible = False
        Label6.Visible = False



        For a As Integer = 0 To units.Rows.Count - 1
            If ComboBox1.Text = units.Rows(a).Item(0) Then
                If units.Rows(a).Item(2) <> units.Rows(a).Item(3) Then
                    Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                    NumericUpDown1.Minimum = units.Rows(a).Item(2)
                    NumericUpDown1.Maximum = units.Rows(a).Item(3)
                    NumericUpDown1.Value = units.Rows(a).Item(2)
                    NumericUpDown1.Visible = True
                    Label1.Visible = True
                End If

            End If
        Next
        Try
            For a As Integer = 0 To units.Rows.Count - 1

                If ComboBox1.Text = units.Rows(a).Item(0) Then
                    Dim number As Integer = 0

                    If units.Rows(a).Item(2) <> units.Rows(a).Item(3) Then
                        number += 1

                    End If
                    If units.Rows(a).Item(5) <> units.Rows(a).Item(6) Then
                        number += 1

                    End If

                    Select Case number
                        Case Is = 1
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                        Case Is = 2
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True

                    End Select
                End If
            Next
        Catch
        End Try
        Try
            For a As Integer = 0 To units.Rows.Count - 1
                If ComboBox1.Text = units.Rows(a).Item(0) Then
                    Dim number As Integer = 0
                    If units.Rows(a).Item(2) <> units.Rows(a).Item(3) Then
                        number += 1

                    End If
                    If units.Rows(a).Item(5) <> units.Rows(a).Item(6) Then
                        number += 1

                    End If
                    If units.Rows(a).Item(8) <> units.Rows(a).Item(9) Then
                        number += 1

                    End If
                    Select Case number
                        Case Is = 1
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True

                        Case Is = 2
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                        Case Is = 3
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"
                            Label3.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(7) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown3.Minimum = units.Rows(a).Item(8)
                            NumericUpDown3.Maximum = units.Rows(a).Item(9)
                            NumericUpDown3.Value = units.Rows(a).Item(8)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                            NumericUpDown3.Visible = True
                            Label3.Visible = True
                    End Select
                End If
            Next
        Catch
        End Try
        Try
            For a As Integer = 0 To units.Rows.Count - 1
                If ComboBox1.Text = units.Rows(a).Item(0) Then
                    Dim number As Integer = 0
                    If units.Rows(a).Item(2) <> units.Rows(a).Item(3) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(5) <> units.Rows(a).Item(6) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(8) <> units.Rows(a).Item(9) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(11) <> units.Rows(a).Item(12) Then
                        number += 1
                    End If
                    Select Case number
                        Case Is = 1
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True

                        Case Is = 2
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True

                        Case Is = 3
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"
                            Label3.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(7) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown3.Minimum = units.Rows(a).Item(8)
                            NumericUpDown3.Maximum = units.Rows(a).Item(9)
                            NumericUpDown3.Value = units.Rows(a).Item(8)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                            NumericUpDown3.Visible = True
                            Label3.Visible = True
                        Case Is = 4
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"
                            Label3.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(7) & ":"
                            Label4.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(10) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown3.Minimum = units.Rows(a).Item(8)
                            NumericUpDown3.Maximum = units.Rows(a).Item(9)
                            NumericUpDown3.Value = units.Rows(a).Item(8)
                            NumericUpDown3.Minimum = units.Rows(a).Item(11)
                            NumericUpDown3.Maximum = units.Rows(a).Item(12)
                            NumericUpDown3.Value = units.Rows(a).Item(11)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                            NumericUpDown3.Visible = True
                            Label3.Visible = True
                            NumericUpDown4.Visible = True
                            Label4.Visible = True
                    End Select
                End If
            Next
        Catch
        End Try
        Try
            For a As Integer = 0 To units.Rows.Count - 1
                If ComboBox1.Text = units.Rows(a).Item(0) Then
                    Dim number As Integer = 0
                    If units.Rows(a).Item(2) <> units.Rows(a).Item(3) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(5) <> units.Rows(a).Item(6) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(8) <> units.Rows(a).Item(9) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(11) <> units.Rows(a).Item(12) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(14) <> units.Rows(a).Item(15) Then
                        number += 1
                    End If
                    If units.Rows(a).Item(17) <> units.Rows(a).Item(18) Then
                        number += 1
                    End If
                    Select Case number
                        Case Is = 1
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                        Case Is = 2
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                        Case Is = 3
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"
                            Label3.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(7) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown3.Minimum = units.Rows(a).Item(8)
                            NumericUpDown3.Maximum = units.Rows(a).Item(9)
                            NumericUpDown3.Value = units.Rows(a).Item(8)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                            NumericUpDown3.Visible = True
                            Label3.Visible = True
                        Case Is = 4
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"
                            Label3.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(7) & ":"
                            Label4.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(10) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown3.Minimum = units.Rows(a).Item(8)
                            NumericUpDown3.Maximum = units.Rows(a).Item(9)
                            NumericUpDown3.Value = units.Rows(a).Item(8)
                            NumericUpDown4.Minimum = units.Rows(a).Item(11)
                            NumericUpDown4.Maximum = units.Rows(a).Item(12)
                            NumericUpDown4.Value = units.Rows(a).Item(11)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                            NumericUpDown3.Visible = True
                            Label3.Visible = True
                            NumericUpDown4.Visible = True
                            Label4.Visible = True
                        Case Is = 6
                            Label1.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(1) & ":"
                            Label2.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(4) & ":"
                            Label3.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(7) & ":"
                            Label4.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(10) & ":"
                            Label5.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(13) & ":"
                            Label6.Text = "Number of " & Environment.NewLine & units.Rows(a).Item(16) & ":"

                            NumericUpDown1.Minimum = units.Rows(a).Item(2)
                            NumericUpDown1.Maximum = units.Rows(a).Item(3)
                            NumericUpDown1.Value = units.Rows(a).Item(2)
                            NumericUpDown2.Minimum = units.Rows(a).Item(5)
                            NumericUpDown2.Maximum = units.Rows(a).Item(6)
                            NumericUpDown2.Value = units.Rows(a).Item(5)
                            NumericUpDown3.Minimum = units.Rows(a).Item(8)
                            NumericUpDown3.Maximum = units.Rows(a).Item(9)
                            NumericUpDown3.Value = units.Rows(a).Item(8)
                            NumericUpDown4.Minimum = units.Rows(a).Item(11)
                            NumericUpDown4.Maximum = units.Rows(a).Item(12)
                            NumericUpDown4.Value = units.Rows(a).Item(11)
                            NumericUpDown5.Minimum = units.Rows(a).Item(14)
                            NumericUpDown5.Maximum = units.Rows(a).Item(15)
                            NumericUpDown5.Value = units.Rows(a).Item(14)
                            NumericUpDown6.Minimum = units.Rows(a).Item(17)
                            NumericUpDown6.Maximum = units.Rows(a).Item(18)
                            NumericUpDown6.Value = units.Rows(a).Item(17)
                            NumericUpDown1.Visible = True
                            Label1.Visible = True
                            NumericUpDown2.Visible = True
                            Label2.Visible = True
                            NumericUpDown3.Visible = True
                            Label3.Visible = True
                            NumericUpDown4.Visible = True
                            Label4.Visible = True
                            NumericUpDown5.Visible = True
                            Label5.Visible = True
                            NumericUpDown6.Visible = True
                            Label6.Visible = True
                    End Select
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub Btn_addtoroster_Click(sender As System.Object, e As System.EventArgs) Handles Btn_addtoroster.Click
        '''' special cases first then general cases next
        Dim donotadd As Boolean = False
        For x As Integer = 0 To ListBox1.Items.Count - 1
            Select Case ComboBox1.Text
                Case Is = "Lelith Hesperax"
                    If ListBox1.Items.Item(x).ToString.Contains("Lelith Hesperax") Then
                        donotadd = True
                    End If
                Case Is = "Urien Rakarth"
                    If ListBox1.Items.Item(x).ToString.Contains("Urien Rakarth") Then
                        donotadd = True
                    End If
                Case Is = "Drazhar"
                    If ListBox1.Items.Item(x).ToString.Contains("Drazhar") Then
                        donotadd = True
                    End If
            End Select


        Next

        ''end of only one unit allowed


        If donotadd = True Then
            MsgBox("Only one of this unit allowed!")
        Else
            If NumericUpDown6.Visible = True Then
                ListBox1.Items.Add(ComboBox1.Text & " " & NumericUpDown1.Text & " " & NumericUpDown2.Text & " " & NumericUpDown3.Text & " " & NumericUpDown4.Text & " " & NumericUpDown5.Text & " " & NumericUpDown6.Text)
            ElseIf NumericUpDown5.Visible = True Then
                ListBox1.Items.Add(ComboBox1.Text & " " & NumericUpDown1.Text & " " & NumericUpDown2.Text & " " & NumericUpDown3.Text & " " & NumericUpDown4.Text & " " & NumericUpDown5.Text)
            ElseIf NumericUpDown4.Visible = True Then
                ListBox1.Items.Add(ComboBox1.Text & " " & NumericUpDown1.Text & " " & NumericUpDown2.Text & " " & NumericUpDown3.Text & " " & NumericUpDown4.Text)
            ElseIf NumericUpDown3.Visible = True Then
                ListBox1.Items.Add(ComboBox1.Text & " " & NumericUpDown1.Text & " " & NumericUpDown2.Text & " " & NumericUpDown3.Text)
            ElseIf NumericUpDown2.Visible = True Then
                ListBox1.Items.Add(ComboBox1.Text & " " & NumericUpDown1.Text & " " & NumericUpDown2.Text)
            ElseIf NumericUpDown1.Visible = True Then
                ListBox1.Items.Add(ComboBox1.Text & " " & NumericUpDown1.Text)
            Else
                ListBox1.Items.Add(ComboBox1.Text)
            End If
        End If


    End Sub

    Private Sub Btn_finished_Click(sender As System.Object, e As System.EventArgs) Handles Btn_finished.Click
        Select Case Race_Selection_Form.Playerid
            Case Is = 1
                For x = 0 To ListBox1.Items.Count - 1
                    If Team_Setup.playeronearmy.Count = 0 Then
                        Team_Setup.playeronearmy.Add(ListBox1.Items.Item(x))
                    End If
                Next
                'Console.WriteLine(Team_Setup.playeronearmy)
            Case Is = 2
                For x = 0 To ListBox1.Items.Count - 1
                    If Team_Setup.playertwoarmy.Count = 0 Then
                        Team_Setup.playertwoarmy.Add(ListBox1.Items.Item(x))
                    End If
                Next
                'Case Is = 3
                '    Team_Setup.playerthreearmy = ListBox1.Text
                'Case Is = 4
                '    Team_Setup.playerfourarmy = ListBox1.Text
                'Case Is = 5
                '    Team_Setup.playerfivearmy = ListBox1.Text
                'Case Is = 6
                '    Team_Setup.playersixarmy = ListBox1.Text
                'Case Is = 7
                '    Team_Setup.playersevenarmy = ListBox1.Text
                'Case Is = 8
                '    Team_Setup.playereightarmy = ListBox1.Text
        End Select

        Dark_Eldar_Weapons_Selection.Show()
        Dark_Eldar_Weapons_Selection.BringToFront()
        'For Each item As String In ListBox1.Items
        '    Console.Write(item & "~")
        'Next

        'Space_Marines_Weapons_Selection.Show()

    End Sub
End Class