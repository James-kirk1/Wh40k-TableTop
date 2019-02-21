Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Public Class Space_Marine_Army_Selection
    Public units As New DataTable


    Private Sub Space_Marine_Army_Selection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
        Dim RaceNumber As Integer = 0 '' number as it appears in "Groups & Units"
        Dim ChapterList As XmlNodeList = doc.SelectNodes("/Data")
        For Each element As XmlElement In ChapterList



            If element.ChildNodes(RaceNumber).Attributes("Name").Value = "Imperium_1" Then
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
                Select Case Race_Selection_Form.playeronerace
                    Case Is = 12
                        For z As Integer = 1 To 14
                            For y As Integer = 0 To (element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes().Count - 1)
                                For x As Integer = 0 To (element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes().Count - 1)
                                    Try
                                        Select Case element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes().Count
                                            Case Is = 3
                                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml)
                                            Case Is = 6
                                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml)
                                            Case Is = 9
                                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                                   element.ChildNodes(RaceNumber).ChildNodes(1).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml)
                                            Case Is = 12
                                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(1).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(9).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(10).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(11).InnerXml)
                                            Case Is = 15
                                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(1).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(9).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(10).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(11).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(12).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(13).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(14).InnerXml)
                                            Case Is = 18
                                                units.Rows.Add(Regex.Replace(element.ChildNodes(RaceNumber).ChildNodes(1).ChildNodes(y).ChildNodes(x).Attributes("Name").Value, "_", " "), _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(0).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(1).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(2).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(3).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(4).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(5).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(6).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(7).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(8).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(9).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(10).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(11).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(12).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(13).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(14).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(15).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(16).InnerXml, _
                                   element.ChildNodes(RaceNumber).ChildNodes(z).ChildNodes(y).ChildNodes(x).ChildNodes(17).InnerXml)
                                        End Select
                                    Catch
                                    End Try

                                Next
                            Next
                        Next
                End Select

            End If
        Next
        For x = 0 To units.Rows.Count - 1
            If units.Rows(x).Item(0) = "The Emperors Champion" Then
                units.Rows(x).Item(0) = "The Emperor's Champion"
            End If
            If units.Rows(x).Item(0) = "Vulkan Hestan" Then
                units.Rows(x).Item(0) = "Vulkan He'stan"
            End If
            If units.Rows(x).Item(0) = "Korsarro Khan" Then
                units.Rows(x).Item(0) = "Kor'sarro Khan"
            End If
            If units.Rows(x).Item(0) = "Korsarro Khan on Moondrakkan" Then
                units.Rows(x).Item(0) = "Kor'sarro Khan on Moondrakkan"
            End If
        Next
        For x = 0 To units.Rows.Count - 1
            ComboBox1.Items.Add(units.Rows(x).Item(0))
        Next






        ComboBox1.Sorted = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Dim maxnumber As Integer = 0
        'Try

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
                Case Is = "Imperial Space Marine"
                    If ListBox1.Items.Item(x).ToString.Contains("Imperial Space Marine") Then
                        donotadd = True
                    End If
                Case Is = "Chapter Ancient"
                    If ListBox1.Items.Item(x).ToString.Contains("Chapter Ancient") Then
                        donotadd = True
                    End If
                Case Is = "Chapter Champion"
                    If ListBox1.Items.Item(x).ToString.Contains("Chapter Champion") Then
                        donotadd = True
                    End If
                Case Is = "Roboute Guilliman"
                    If ListBox1.Items.Item(x).ToString.Contains("Roboute Guilliman") Then
                        donotadd = True
                    End If
                Case Is = "Marneus Calgar", "Marneus Calgar in Artificer Armour"
                    If ListBox1.Items.Item(x).ToString.Contains("Marneus Calgar") Then
                        donotadd = True
                    End If
                Case Is = "Captain Sicarius"
                    If ListBox1.Items.Item(x).ToString.Contains("Captain Sicarius") Then
                        donotadd = True
                    End If
                Case Is = "Chief Librarian Tigurius"
                    If ListBox1.Items.Item(x).ToString.Contains("Chief Librarian Tigurius") Then
                        donotadd = True
                    End If
                Case Is = "Chaplain Cassius"
                    If ListBox1.Items.Item(x).ToString.Contains("Chaplain Cassius") Then
                        donotadd = True
                    End If
                Case Is = "Sergeant Telion"
                    If ListBox1.Items.Item(x).ToString.Contains("Sergeant Telion") Then
                        donotadd = True
                    End If
                Case Is = "Sergeant Chronus"
                    If ListBox1.Items.Item(x).ToString.Contains("Sergeant Chronus") Then
                        donotadd = True
                    End If
                Case Is = "Captain Lysander"
                    If ListBox1.Items.Item(x).ToString.Contains("Captain Lysander") Then
                        donotadd = True
                    End If
                Case Is = "Pedro Cantor"
                    If ListBox1.Items.Item(x).ToString.Contains("Pedro Cantor") Then
                        donotadd = True
                    End If
                Case Is = "High Marshal Helbrecht"
                    If ListBox1.Items.Item(x).ToString.Contains("High Marshal Helbrecht") Then
                        donotadd = True
                    End If
                Case Is = "The Emperor's Champion"
                    If ListBox1.Items.Item(x).ToString.Contains("The Emperor's Champion") Then
                        donotadd = True
                    End If
                Case Is = "Chaplain Grimaldus"
                    If ListBox1.Items.Item(x).ToString.Contains("Chaplain Grimaldus") Then
                        donotadd = True
                    End If
                Case Is = "Cenobyte Servitors"
                    If ListBox1.Items.Item(x).ToString.Contains("Cenobyte Servitors") Then
                        donotadd = True
                    End If
                Case Is = "Kayvaan Shrike"
                    If ListBox1.Items.Item(x).ToString.Contains("Kayvaan Shrike") Then
                        donotadd = True
                    End If
                Case Is = "Vulkan He'Stan"
                    If ListBox1.Items.Item(x).ToString.Contains("Vulkan He'Stan") Then
                        donotadd = True
                    End If
                Case Is = "Kor'Sarro Khan", "Kor'sarro Khan on Moondrakkan"
                    If ListBox1.Items.Item(x).ToString.Contains("Kor'Sarro Khan") Then
                        donotadd = True
                    End If
                Case Is = "Commander Dante"
                    If ListBox1.Items.Item(x).ToString.Contains("Commander Dante") Then
                        donotadd = True
                    End If
                Case Is = "Tycho"
                    If ListBox1.Items.Item(x).ToString.Contains("Tycho") Then
                        donotadd = True
                    End If
                Case Is = "Chief Librarian Mephiston"
                    If ListBox1.Items.Item(x).ToString.Contains("Chief Librarian Mephiston") Then
                        donotadd = True
                    End If
                Case Is = "The Sanguinor"
                    If ListBox1.Items.Item(x).ToString.Contains("The Sanguinor") Then
                        donotadd = True
                    End If
                Case Is = "Astorath"
                    If ListBox1.Items.Item(x).ToString.Contains("Astorath") Then
                        donotadd = True
                    End If
                Case Is = "Brother Corbulo"
                    If ListBox1.Items.Item(x).ToString.Contains("Brother Corbulo") Then
                        donotadd = True
                    End If
                Case Is = "Lemartes"
                    If ListBox1.Items.Item(x).ToString.Contains("Lemartes") Then
                        donotadd = True
                    End If
                Case Is = "Azrael"
                    If ListBox1.Items.Item(x).ToString.Contains("Azrael") Then
                        donotadd = True
                    End If
                Case Is = "Belial"
                    If ListBox1.Items.Item(x).ToString.Contains("Belial") Then
                        donotadd = True
                    End If
                Case Is = "Sammael on Covex", "Sammael in Sableclaw"
                    If ListBox1.Items.Item(x).ToString.Contains("Sammael") Then
                        donotadd = True
                    End If
                Case Is = "Asmodai"
                    If ListBox1.Items.Item(x).ToString.Contains("Asmodai") Then
                        donotadd = True
                    End If
                Case Is = "Ezekiel"
                    If ListBox1.Items.Item(x).ToString.Contains("Ezekiel") Then
                        donotadd = True
                    End If
                Case Is = "Deathwing Ancient"
                    If ListBox1.Items.Item(x).ToString.Contains("Deathwing Ancient") Then
                        donotadd = True
                    End If
                Case Is = "Deathwing Champion"
                    If ListBox1.Items.Item(x).ToString.Contains("Deathwing Champion") Then
                        donotadd = True
                    End If
                Case Is = "Ravenwing Ancient"
                    If ListBox1.Items.Item(x).ToString.Contains("Ravenwing Ancient") Then
                        donotadd = True
                    End If
                Case Is = "Ravenwing Champion"
                    If ListBox1.Items.Item(x).ToString.Contains("Ravenwing Champion") Then
                        donotadd = True
                    End If
                Case Is = "Logan Grimnar", "Logan Grimnar on Stormrider"
                    If ListBox1.Items.Item(x).ToString.Contains("Logan Grimnar") Then
                        donotadd = True
                    End If
                Case Is = "Ragnar Blackmane"
                    If ListBox1.Items.Item(x).ToString.Contains("Ragnar Blackmane") Then
                        donotadd = True
                    End If
                Case Is = "Krom Dragongaze"
                    If ListBox1.Items.Item(x).ToString.Contains("Krom Dragongaze") Then
                        donotadd = True
                    End If
                Case Is = "Harald Deathwolf"
                    If ListBox1.Items.Item(x).ToString.Contains("Harald Deathwolf") Then
                        donotadd = True
                    End If
                Case Is = "Canis Wolfborn"
                    If ListBox1.Items.Item(x).ToString.Contains("Canis Wolfborn") Then
                        donotadd = True
                    End If
                Case Is = "Njal Stormcaller"
                    If ListBox1.Items.Item(x).ToString.Contains("Njal Stormcaller") Then
                        donotadd = True
                    End If
                Case Is = "Ulrik The Slayer"
                    If ListBox1.Items.Item(x).ToString.Contains("Ulrik The Slayer") Then
                        donotadd = True
                    End If
                Case Is = "Bjorn the Fell-Handed"
                    If ListBox1.Items.Item(x).ToString.Contains("Bjorn the Fell-Handed") Then
                        donotadd = True
                    End If
                Case Is = "Lukas the Trickster"
                    If ListBox1.Items.Item(x).ToString.Contains("Lukas the Trickster") Then
                        donotadd = True
                    End If
                Case Is = "Murderfang"
                    If ListBox1.Items.Item(x).ToString.Contains("Murderfang") Then
                        donotadd = True
                    End If
                Case Is = "Arjac Rockfist"
                    If ListBox1.Items.Item(x).ToString.Contains("Arjac Rockfist") Then
                        donotadd = True
                    End If
                Case Is = "Watch Captain Artemis"
                    If ListBox1.Items.Item(x).ToString.Contains("Watch Captain Artemis") Then
                        donotadd = True
                    End If
                Case Is = "Lord Kaldor Draigo"
                    If ListBox1.Items.Item(x).ToString.Contains("Lord Kaldor Draigo") Then
                        donotadd = True
                    End If
                Case Is = "Grand Master Voldus"
                    If ListBox1.Items.Item(x).ToString.Contains("Grand Master Voldus") Then
                        donotadd = True
                    End If
                Case Is = "Brother-Captain Stern"
                    If ListBox1.Items.Item(x).ToString.Contains("Brother-Captain Stern") Then
                        donotadd = True
                    End If
                Case Is = "Castellan Crowe"
                    If ListBox1.Items.Item(x).ToString.Contains("Castellan Crowe") Then
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
                    If Team_Setup.playeronearmy = "" Then
                        Team_Setup.playeronearmy = ListBox1.Items.Item(x)
                    Else
                        Team_Setup.playeronearmy = Team_Setup.playeronearmy & "~" & ListBox1.Items.Item(x)
                    End If
                Next
                'Console.WriteLine(Team_Setup.playeronearmy)
                'Case Is = 2
                '    Team_Setup.playertwoarmy = ListBox1.Text
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

        Space_Marines_Weapons_Selection.Show()
        Space_Marines_Weapons_Selection.BringToFront()
        'For Each item As String In ListBox1.Items
        '    Console.Write(item & "~")
        'Next

        'Space_Marines_Weapons_Selection.Show()

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Select Case ComboBox1.Text
            Case Is = "Crusader Squad"
                If NumericUpDown3.Value = 1 Then
                    NumericUpDown1.Maximum = 9
                ElseIf NumericUpDown3.Value = 0 Then
                    NumericUpDown1.Maximum = 10
                End If
            Case Is = "Deathwatch Kill Team"
                'if watch seargent is present
                Select Case NumericUpDown3.Value
                    Case Is = 0
                        NumericUpDown4.Maximum = 5
                        Select Case NumericUpDown4.Value
                            Case Is = 0
                                NumericUpDown5.Maximum = 5
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 5
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 4
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 3
                                    Case Is = 3
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 4
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 5
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 1
                                NumericUpDown5.Maximum = 4
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 4
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 3
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 3
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 4
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 2
                                NumericUpDown5.Maximum = 3
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 3
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 3
                                        NumericUpDown6.Maximum = 0

                                End Select
                            Case Is = 3
                                NumericUpDown5.Maximum = 2
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 4
                                NumericUpDown5.Maximum = 1
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 5
                                NumericUpDown5.Maximum = 0
                                NumericUpDown6.Maximum = 0
                        End Select


                    Case Is = 1
                        NumericUpDown4.Maximum = 4
                        Select Case NumericUpDown4.Value
                            Case Is = 0
                                NumericUpDown5.Maximum = 4
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 4
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 3
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 3
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 4
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 1
                                NumericUpDown5.Maximum = 3
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 3
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 3
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 2
                                NumericUpDown5.Maximum = 2
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 3
                                NumericUpDown5.Maximum = 1
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 4
                                NumericUpDown5.Maximum = 0
                                NumericUpDown6.Maximum = 0
                        End Select
                    Case Is = 2
                        NumericUpDown4.Maximum = 3
                        Select Case NumericUpDown4.Value
                            Case Is = 0
                                NumericUpDown5.Maximum = 3
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 3
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 3
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 1
                                NumericUpDown5.Maximum = 2
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 2
                                NumericUpDown5.Maximum = 1
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 3
                                NumericUpDown5.Maximum = 0
                                NumericUpDown6.Maximum = 0
                        End Select
                    Case Is = 3
                        NumericUpDown4.Maximum = 2
                        Select Case NumericUpDown4.Value
                            Case Is = 0
                                NumericUpDown5.Maximum = 2
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 2
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 2
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 1
                                NumericUpDown5.Maximum = 1
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 2
                                NumericUpDown5.Maximum = 0
                                NumericUpDown6.Maximum = 0
                        End Select
                    Case Is = 4
                        NumericUpDown4.Maximum = 1
                        Select Case NumericUpDown4.Value
                            Case Is = 0
                                NumericUpDown5.Maximum = 1
                                Select Case NumericUpDown5.Value
                                    Case Is = 0
                                        NumericUpDown6.Maximum = 1
                                    Case Is = 1
                                        NumericUpDown6.Maximum = 0
                                End Select
                            Case Is = 1
                                NumericUpDown5.Maximum = 0
                                NumericUpDown6.Maximum = 0
                        End Select
                    Case Is = 5
                        NumericUpDown4.Maximum = 0
                        NumericUpDown5.Maximum = 0
                        NumericUpDown6.Maximum = 0

                    Case Is = 6
                        NumericUpDown4.Maximum = 0
                        NumericUpDown5.Maximum = 0
                        NumericUpDown6.Maximum = 0

                End Select
        End Select
    End Sub
End Class