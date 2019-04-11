Imports System.Text.RegularExpressions
Public Class Space_Marines_Weapons_Selection
    Dim line As Integer = 0
    ' Dim stringinput As String = "Thunderfire Cannon~Vanguard Veteran Squad 4~Venerable Dreadnought~Vindicator"
    'Dim str As New List(Of String) 'String ' = Team_Setup.playeronearmy.ToString.Split("~") 'stringinput.Split("~") ''
    Dim Imp1Name As String

    Dim figcount As Integer = 0 '' for counting figs in squad
    Dim maxnumberoffigs As Integer = 0
    Dim nameofsquad As String = ""
    Dim miscstuff1 As Boolean = False
    Dim thirdunit As Integer = 0
    Dim fourthunit As Integer = 0
    Dim fifthunit As Integer = 0
    Dim sixthunit As Integer = 0
    Dim groupstorage(8)() As String
    Private Sub Btn_NextSquad_Click(sender As System.Object, e As System.EventArgs) Handles Btn_NextSquad.Click

        Select Case nameofsquad
            Case Is = "Dreadnought"
                If ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
                    Exit Sub
                End If
            Case Is = "Venerable Dreadnought"
                If ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
                    Exit Sub
                End If
            Case Is = "Contemptor Dreadnought"
                If ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
                    Exit Sub
                End If
            Case Is = "Death Company"
                If ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Chainsword and Bolt pistol" & Chr(34) & " or the " & Chr(34) & "Chainsword" & Chr(34) & " not both")
                    Exit Sub
                ElseIf ComboBox2.SelectedIndex > -1 And ComboBox1.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Chainsword and Bolt pistol" & Chr(34) & " or the " & Chr(34) & "Bolt pistol" & Chr(34) & " not both")
                    Exit Sub
                End If
            Case Is = "Furioso Dreadnought"
                If ComboBox5.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace the " & Chr(34) & "Furioso fist" & Chr(34) & " and either the " & Chr(34) & "Storm bolter" & Chr(34) & " or the " & Chr(34) & "Meltagun" & Chr(34) & " not all")
                    Exit Sub
                End If
            Case Is = "Deathwing Apothecary"
                If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Power fist and Storm bolter" & Chr(34) & " or the " & Chr(34) & "Power fist" & Chr(34) & " not both")
                    Exit Sub
                End If
        End Select
        Dim storagelist As New System.Collections.Specialized.StringCollection
        ''adding to transfer string
        If Label2.Visible Then
            Imp1Name = Regex.Replace(Label2.Text, "Model: ", "")
        Else
            Imp1Name = nameofsquad
        End If
        If ComboBox1.Visible = True Then
            If ComboBox1.SelectedIndex > -1 Then
                storagelist.Add(ComboBox1.Text)
            ElseIf Label3.Visible = True Then
                storagelist.Add(Label3.Text)
            End If
        End If
        If ComboBox2.Visible = True Then
            If ComboBox2.SelectedIndex > -1 Then
                storagelist.Add(ComboBox2.Text)
            ElseIf Label4.Visible = True Then
                storagelist.Add(Label4.Text)
            End If
        End If
        If ComboBox3.Visible = True Then
            If ComboBox3.SelectedIndex > -1 Then
                storagelist.Add(ComboBox3.Text)
            ElseIf Label5.Visible = True Then
                storagelist.Add(Label5.Text)
            End If
        End If
        If ComboBox4.Visible = True Then
            If ComboBox4.SelectedIndex > -1 Then
                storagelist.Add(ComboBox4.Text)
            ElseIf Label6.Visible = True Then
                storagelist.Add(Label6.Text)
            End If
        End If
        If ComboBox5.Visible = True Then
            If ComboBox5.SelectedIndex > -1 Then
                storagelist.Add(ComboBox5.Text)
            ElseIf Label7.Visible = True Then
                storagelist.Add(Label7.Text)
            End If
        End If


        '' ''If ComboBox1.SelectedIndex > -1 And Label3.Visible = True And ComboBox1.Visible = True Then
        '' ''    storagelist.Add(ComboBox1.Text)
        '' ''ElseIf Label3.Visible = True And ComboBox1.SelectedIndex = -1 Then
        '' ''    storagelist.Add(Label3.Text)
        '' ''ElseIf Label3.Visible = False And ComboBox1.Visible = True And ComboBox1.SelectedIndex > -1 Then
        '' ''    storagelist.Add(ComboBox1.Text)
        '' ''End If
        ' ''If ComboBox2.SelectedIndex > -1 And Label4.Visible = True Then
        ' ''    storagelist.Add(ComboBox2.Text)
        ' ''ElseIf Label4.Visible = True And ComboBox2.SelectedIndex = -1 Then
        ' ''    storagelist.Add(Label4.Text)
        ' ''ElseIf Label4.Visible = False And ComboBox2.Visible = True And ComboBox2.SelectedIndex > -1 Then
        ' ''    storagelist.Add(ComboBox2.Text)
        ' ''End If
        ' ''If ComboBox3.SelectedIndex > -1 And Label5.Visible = True Then
        ' ''    storagelist.Add(ComboBox3.Text)
        ' ''ElseIf Label5.Visible = True And ComboBox3.SelectedIndex = -1 Then
        ' ''    storagelist.Add(Label5.Text)
        ' ''ElseIf Label5.Visible = False And ComboBox3.Visible = True And ComboBox3.SelectedIndex > -1 Then
        ' ''    storagelist.Add(ComboBox3.Text)
        ' ''End If
        ' ''If ComboBox4.SelectedIndex > -1 And Label6.Visible = True Then
        ' ''    storagelist.Add(ComboBox4.Text)
        ' ''ElseIf Label6.Visible = True And ComboBox4.SelectedIndex = -1 Then
        ' ''    storagelist.Add(Label6.Text)
        ' ''ElseIf Label6.Visible = False And ComboBox4.Visible = True And ComboBox4.SelectedIndex > -1 Then
        ' ''    storagelist.Add(ComboBox4.Text)
        ' ''End If
        ' ''If ComboBox5.SelectedIndex > -1 And Label7.Visible = True Then
        ' ''    storagelist.Add(ComboBox5.Text)
        ' ''ElseIf Label7.Visible = True And ComboBox5.SelectedIndex = -1 Then
        ' ''    storagelist.Add(Label7.Text)
        ' ''ElseIf Label7.Visible = False And ComboBox5.Visible = True And ComboBox5.SelectedIndex > -1 Then
        ' ''    storagelist.Add(ComboBox5.Text)
        ' ''End If
        If CheckBox1.Checked = True Then
            storagelist.Add(CheckBox1.Text)
        End If
        If CheckBox2.Checked = True Then
            storagelist.Add(CheckBox2.Text)
        End If
        If CheckBox3.Checked = True Then
            storagelist.Add(CheckBox3.Text)
        End If
        If CheckBox4.Checked = True Then
            storagelist.Add(CheckBox4.Text)
        End If
        For x As Integer = 0 To storagelist.Count - 1
            If storagelist(x).Contains("two") Then
                storagelist(x) = storagelist(x).Replace("two ", "").Substring(0, storagelist(x).Replace("two ", "").Length - 1)
                storagelist.Add(storagelist(x))
            End If
        Next


        Functions.addModelToArmyList(nameofsquad, Functions.Groupid, Imp1Name, storagelist)
        Functions.Groupid += 1
        'storagelist.Clear()
        ''reset sequence
        For Each cont As Control In Me.Controls
            cont.Visible = False
        Next
        Btn_NextSquad.Visible = True
        Btn_NextModel.Visible = True
        Label1.Visible = True
        Btn_NextSquad.Enabled = True
        Btn_NextModel.Enabled = False
        If line > listallModels.Count - 1 Then
            WeaponsSelectionToMap()
            Me.Close()
        Else
            nameofsquad = ""
            Dim part As New List(Of String)
            Try
                part.AddRange(Functions.listallModels(line).Split(" "))
            Catch ex As Exception
                part.Add(Functions.listallModels(line))
            End Try
            maxnumberoffigs = 0
            For parta As Integer = 0 To part.Count - 1
                If IsNumeric(part(parta)) = True Then
                   
                    If maxnumberoffigs = 0 Then

                        maxnumberoffigs = part(parta)
                        figcount = 1
                        Exit For
                    ElseIf thirdunit = 0 Then
                        thirdunit = part(parta)
                    ElseIf fourthunit = 0 Then
                        fourthunit = part(parta)
                    ElseIf fifthunit = 0 Then
                        fifthunit = part(parta)
                    ElseIf sixthunit = 0 Then
                        sixthunit = part(parta)
                    End If
                Else
                    If parta <> 0 Then
                        nameofsquad += " " & part(parta)
                    Else
                        nameofsquad += part(parta)
                    End If
                    figcount = 0
                End If
            Next
            If figcount >= maxnumberoffigs Then
                Btn_NextSquad.Enabled = True
                Btn_NextModel.Enabled = False
            Else
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
            End If
            If figcount = 0 Then
                Label1.Text = "Group Name: " & nameofsquad
            Else
                Label1.Text = "Group Name: " & nameofsquad & " " & figcount
            End If
            line += 1
        End If
        ComboBox1.Items.Clear()
        ComboBox1.ResetText()
        ComboBox2.Items.Clear()
        ComboBox2.ResetText()
        ComboBox3.Items.Clear()
        ComboBox3.ResetText()
        ComboBox4.Items.Clear()
        ComboBox4.ResetText()
        ComboBox5.Items.Clear()
        ComboBox5.ResetText()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        miscstuff1 = False
        ''''''
        Select Case nameofsquad
            Case Is = "Captain"
                Label3.Visible = True
                Label3.Text = "Chainsword"
                Label4.Visible = True
                Label4.Text = "Master-crafted boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox1.Items.Add("Relic blade")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Captain in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Power sword"
                Label4.Visible = True
                Label4.Text = "Storm bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox1.Items.Add("Relic blade")
                ComboBox1.Items.Add("Chainfist")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Terminator_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
            Case Is = "Captain in Cataphractii Armour"
                Label3.Visible = True
                Label3.Text = "Power sword"
                Label4.Visible = True
                Label4.Text = "Combi-bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Relic blade")
                ComboBox1.Items.Add("Chainfist")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
            Case Is = "Captain in Gravis Armour"
                Label3.Visible = True
                Label3.Text = "This may not alter their wargear options."
            Case Is = "Captain on Bike"
                Label3.Visible = True
                Label3.Text = "Chain sword"
                Label4.Visible = True
                Label4.Text = "Master-crafted boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
            Case Is = "Librarian"
                Label3.Visible = True
                Label3.Text = "Force stave"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Force axe")
                ComboBox1.Items.Add("Force sword")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Librarian in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Force stave"
                Label4.Visible = True
                Label4.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Force axe")
                ComboBox1.Items.Add("Force sword")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Storm shield")
            Case Is = "Librarian on Bike"
                Label3.Visible = True
                Label3.Text = "Force stave"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Force axe")
                ComboBox1.Items.Add("Force sword")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
            Case Is = "Techmarine"
                Label3.Visible = True
                Label3.Text = "Power axe"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                Label5.Visible = True
                Label5.Text = "Servo-arm"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Conversion beamer")
                ComboBox3.Items.Add("Servo-harness")
            Case Is = "Servitors"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs = 4
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Servo-arm"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Heavy bolter")
                ComboBox1.Items.Add("Plasma cannon")
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Techmarine on Bike"
                Label3.Visible = True
                Label3.Text = "Power axe"
                Label4.Visible = True
                Label4.Text = "Bolt Pistol"
                Label5.Visible = True
                Label5.Text = "Servo-arm"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Conversion beamer")
                ComboBox3.Items.Add("Servo-harness")
            Case Is = "Chaplain"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
                ComboBox1.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Chaplain in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Storm Bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Combi_Weapons(str))
                Next
            Case Is = "Chaplain on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
                ComboBox1.Items.Add("Power fist")
            Case Is = "Apothecary"
                Label3.Visible = True
                Label3.Text = "This may not alter their wargear options."
            Case Is = "Apothecary on Bike"
                Label3.Visible = True
                Label3.Text = "This may not alter their wargear options."
            Case Is = "Primaris Lieutenants"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Master-crafted auto bolt rifle"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
            Case Is = "Company Ancient"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
            Case Is = "Company Ancient on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
            Case Is = "Primaris Ancient"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Company Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Company Champion on Bike"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Company Veterans"
                Label2.Visible = True
                Label2.Text = "Model: Veteran Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox1.Items.Add("Boltgun")
            Case Is = "Company Veterans on Bike"
                Label2.Visible = True
                Label2.Text = "Model: Veteran Biker Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Tactical Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Scout Squad"
                Label2.Visible = True
                Label2.Text = "Model: Scout Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Boltgun"
                ComboBox2.Items.Add("Sniper rifle")
                ComboBox2.Items.Add("Astartes shotgun")
                ComboBox2.Items.Add("Combat knife")
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Camo Cloak"
            Case Is = "Intercessor Squad"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Imperial Space Marine"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Honour Guard"
                figcount = 1
                maxnumberoffigs = 2
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label3.Visible = True
                Label3.Text = "Power axe"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power lance")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Relic blade")
            Case Is = "Chapter Ancient"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chapter Champion"
                Label3.Visible = True
                Label3.Text = "Power axe"
                Label4.Visible = True
                Label4.Text = "Boltgun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power lance")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Thunder hammer")
                ComboBox1.Items.Add("Relic blade")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Champion's blade")
            Case Is = "Centurion Assault Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Centurion Sergeant"
                Label3.Visible = True
                Label3.Text = "two Flamers"
                Label4.Visible = True
                Label4.Text = "Centurion assault launcher"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Meltaguns")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Hurricane bolter")
            Case Is = "Sternguard Veteran Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Veteran Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Special issue boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox1.Items.Remove("Thunder hammer")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Items.Remove("Thunder hammer")
            Case Is = "Vanguard Veteran Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Veteran Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox1.Items.Add("Relic blade")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox2.Items.Add("Storm shield")
                ComboBox2.Items.Add("Relic blade")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
                CheckBox2.Visible = True
                CheckBox2.Text = "Melta Bomb"
            Case Is = "Dreadnought"
                Label3.Visible = True
                Label3.Text = "Assault cannon"
                Label4.Visible = True
                Label4.Text = "Dreadnought combat weapon and Storm bolter"
                Label5.Visible = True
                Label5.Text = "Storm bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Dreadnought_Heavy_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Dreadnought_Heavy_Weapons(str))
                Next
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Missile launcher")
                ComboBox2.Items.Add("Twin Autocannon")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
            Case Is = "Venerable Dreadnought"
                Label3.Visible = True
                Label3.Text = "Assault cannon"
                Label4.Visible = True
                Label4.Text = "Dreadnought combat weapon and Storm bolter"
                Label5.Visible = True
                Label5.Text = "Storm bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Dreadnought_Heavy_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Dreadnought_Heavy_Weapons(str))
                Next
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Missile launcher")
                ComboBox2.Items.Add("Twin Autocannon")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
            Case Is = "Contemptor Dreadnought"
                Label3.Visible = True
                Label3.Text = "Assault cannon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Kheres pattern assault cannon")
            Case Is = "Contemptor Dreadnought"
                Label3.Visible = True
                Label3.Text = "Seismic Hammer"
                Label4.Visible = True
                Label4.Text = "Dreadnought combat weapon and Storm bolter"
                Label5.Visible = True
                Label5.Text = "Storm bolter"
                Label6.Visible = True
                Label6.Text = "Meltagun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Dreadnought Chainfist")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Hurricane bolter")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
                ComboBox4.Visible = True
                ComboBox4.Items.Add("Heavy flamer")
                CheckBox1.Visible = True
                CheckBox1.Text = "two Hunter-killer missiles"
                CheckBox2.Visible = True
                CheckBox2.Text = "Ironclad Assault Launchers"
            Case Is = "Terminator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Terminator Sergeant"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Terminator Assault Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Terminator Sergeant"
                Label3.Visible = True
                Label3.Text = "two Lightning claws"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer and Storm Shield")
            Case Is = "Cataphractii Terminator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Cataphractii Sergeant"
                Label3.Visible = True
                Label3.Text = "Power Sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainfist")
                ComboBox1.Items.Add("Power fist")
                ComboBox1.Items.Add("Lightning claw")
                CheckBox1.Visible = True
                CheckBox1.Text = "Grenade Harness"
            Case Is = "Tartaros Terminator Squad"
                'skipped cus'
            Case Is = "Assault Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Combat Shield"
                CheckBox2.Visible = True
                CheckBox2.Text = "Melta Bombs"
            Case Is = "Inceptor Squad"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Scout Bike Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Scout Biker Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Bike Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Biker Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Attack Bike Squad"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Land Speeder Storm"
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox1.Items.Add("Assault cannon")
            Case Is = "Land Speeders"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy bolter")
                ComboBox2.Items.Add("Typhoon missile launcher")
                ComboBox2.Items.Add("Multi-melta")
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox2.Items.Add("Assault cannon")
            Case Is = "Rhino"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Rhino Primaris"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
            Case Is = "Razorback"
                Label3.Visible = True
                Label3.Text = "Twin Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Twin Lascannon")
                ComboBox1.Items.Add("Twin Assault cannon")
                ComboBox1.Items.Add("Lascannon and Twin Plasma gun ")
                ComboBox1.Items.Add("Twin Heavy flamer")
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Drop Pod"
                Label3.Visible = True
                Label3.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Deathwind launcher")
            Case Is = "Stormhawk Interceptor"
                Label3.Visible = True
                Label3.Text = "two Heavy bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Skyhammer missile launcher")
                ComboBox1.Items.Add("Typhoon  missile launcher")
                Label4.Visible = True
                Label4.Text = "Icarus stormcannon"
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Las-talon")
            Case Is = "Stormtalon Gunship"
                Label3.Visible = True
                Label3.Text = "two Heavy bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Skyhammer missile launcher")
                ComboBox1.Items.Add("Typhoon  missile launcher")
                ComboBox1.Items.Add("two Lascannons")
            Case Is = "Devastator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Sergeant"
                Label3.Visible = True
                Label3.Text = "Boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Centurion Devastator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Centurion Sergeant"
                Label3.Visible = True
                Label3.Text = "Hurricane bolter"
                Label3.Visible = True
                Label3.Text = "two Heavy Bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Centurion missile launcher")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Lascannons")
                ComboBox2.Items.Add("Grav-cannon and grav-amp")
            Case Is = "Hellblaster Squad"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Thunderfire Cannon"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Predator"
                Label3.Visible = True
                Label3.Text = "Predator autocannon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Twin Lascannon")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Lascannons")
                ComboBox2.Items.Add("two Heavy bolters")
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Whirlwind"
                Label3.Visible = True
                Label3.Text = "Whirlwind vengeance launcher"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Whirlwind castellan launcher")
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Vindicator"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Hunter"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Stalker"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Stormraven Gunship"
                Label3.Visible = True
                Label3.Text = "Twin Assault cannon"
                Label4.Visible = True
                Label4.Text = "Twin Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Twin Lascannon")
                ComboBox1.Items.Add("Twin Heavy plasma cannon")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Twin Multi-melta")
                ComboBox2.Items.Add("Typhoon missile launcher")
                CheckBox1.Visible = True
                CheckBox1.Text = "two Hurricane bolters"
            Case Is = "Land Raider"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Land Raider Crusader"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Land Raider Redeemer"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Land Raider Excelsior"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
                CheckBox4.Visible = True
                CheckBox4.Text = "Combi-plasma"
            Case Is = "Roboute Guilliman"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Marneus Calgar"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Marneus Calgar in Artificer Armour"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Captain Sicarus"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chief Librarian Tigurius"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chaplain Cassius"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sergeant Telion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
                ''Sergeant Chronus Skipped cus'
            Case Is = "Tyrannic War Veterans"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Terminus Ultra"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Captain Lysander"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Pedro Kantor"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "High Marshal Helbrecht"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "The Emperor's Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chaplain Grimaldus"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Cenobyte Servitors"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Crusader Squad"
                figcount = 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                If fourthunit > 0 Then
                    Label2.Visible = True
                    Label2.Text = "Model: Sword Brother"
                    Label3.Visible = True
                    Label3.Text = "Bolt pistol"
                    Label4.Visible = True
                    Label4.Text = "Boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                        ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                    Next
                    For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                        ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                    Next
                    ComboBox2.Visible = True
                    For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                        ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                    Next
                Else
                    Label2.Visible = True
                    Label2.Text = "Model: Initiate"
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Items.Add("Chainsword")
                End If
            Case Is = "Kayvann Shrike"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Vulkan He'stan"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Kor'sarro Khan", "Kor'sarro Khan"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Damned Legionaires"
                Label2.Visible = True
                Label2.Text = "Model: Initiate"
                Label3.Visible = True
                Label3.Text = "Boltgun"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainsword")
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power axe")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Power fist")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Plasma pistol")
                ComboBox2.Items.Add("Storm bolter")
            Case Is = "Commander Dante"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Captain Tycho", "Tycho the Lost"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Librarian Dreadnought"
                Label3.Visible = True
                Label3.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox1.Items.Add("Meltagun")
            Case Is = "Chief Librarian Mephiston"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "The Sanguinor"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Astorath"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sanguinary Priest"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = False
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump pack"
            Case Is = "Sanguinary Priest on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = False
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
            Case Is = "Brother Corbulo"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sanguinary Guard Ancient"
                Label3.Visible = True
                Label3.Text = "Angelus boltgun"
                Label4.Visible = True
                Label4.Text = "Encarmine sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Inferno pistol")
                ComboBox1.Items.Add("Plasma pistol")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Encarmine axe")
                ComboBox2.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Death mask"
            Case Is = "Terminator Ancient"
                Label3.Visible = True
                Label3.Text = "Lightning claw"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer")
            Case Is = "Death Company"
                Label3.Visible = True
                Label3.Text = "Chainsword and Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                Label5.Visible = True
                Label5.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Boltgun")
                ComboBox2.Items.Add("Hand flamer")
                ComboBox2.Items.Add("Inferno pistol")
                ComboBox2.Items.Add("Plasma pistol")
                ComboBox2.Items.Add("Power sword")
                ComboBox2.Items.Add("Power axe")
                ComboBox2.Items.Add("Power maul")
                ComboBox2.Items.Add("Power fist")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Power sword")
                ComboBox3.Items.Add("Power axe")
                ComboBox3.Items.Add("Power maul")
                ComboBox3.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Lemartes"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sanguinary Guard"
                figcount = 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label3.Visible = True
                Label3.Text = "Angelus boltgun"
                Label4.Visible = True
                Label4.Text = "Encarmine sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Inferno pistol")
                ComboBox1.Items.Add("Plasma pistol")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Encarmine axe")
                ComboBox2.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Death mask"
            Case Is = "Death Company Dreadnought"
                Label3.Visible = True
                Label3.Text = "two Furioso fists"
                Label4.Visible = True
                Label4.Text = "Storm Bolter"
                Label5.Visible = True
                Label5.Text = "Meltagun"
                Label5.Visible = True
                Label5.Text = "Smoke Launchers"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Blood talons")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
                ComboBox4.Visible = True
                ComboBox4.Items.Add("Magna-grapple")
            Case Is = "Furioso Dreadnought"
                Label3.Visible = True
                Label3.Text = "two Furioso fists"
                Label4.Visible = True
                Label4.Text = "Storm Bolter"
                Label5.Visible = True
                Label5.Text = "Meltagun"
                Label6.Visible = True
                Label6.Text = "Smoke Launchers"
                Label7.Visible = True
                Label7.Text = "one Furioso fist and either its Storm bolter or its Meltagun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Blood talons")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
                ComboBox4.Visible = True
                ComboBox4.Items.Add("Magna-grapple")
                ComboBox5.Visible = True
                ComboBox5.Items.Add("Frag Cannon")
            Case Is = "Baal Predator"
                Label3.Visible = True
                Label3.Text = "Twin Assault cannon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Flamestorm cannon")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Heavy flamer")
                ComboBox2.Items.Add("two Heavy bolters")
            Case Is = "Gabriel Seth"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Azrael"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Belial"
                Label3.Visible = True
                Label3.Text = "Storm bolter and Sword of Silence"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Lightning claws")
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
            Case Is = "Sammael on Corvex"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sammael in Sableclaw"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Interrogator-Chaplain"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Power fist"
            Case Is = "Interrogator-Chaplain in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Lightning claw")
                ComboBox1.Items.Add("Power fist")
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
            Case Is = "Interrogator-Chaplain on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Power fist"
            Case Is = "Asmodai"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Ezekiel"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Deathwing Apothecary"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Deathwing Ancient"
                Label3.Visible = True
                Label3.Text = "Power fist and Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Lightning claws")
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
                Label3.Visible = True
                Label3.Text = "Power fist"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainfist")
            Case Is = "Deathwing Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Deathwing Terminator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Deathwing Sergeant"
                Label3.Visible = True
                Label3.Text = "Power sword and Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
                ComboBox1.Items.Add("two Lightning claws")
                CheckBox1.Visible = True
                CheckBox1.Text = "Accompanied by a Watcher in the Dark"
            Case Is = "Deathwing Knights"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
                CheckBox1.Visible = True
                CheckBox1.Text = "Accompanied by a Watcher in the Dark"
            Case Is = "Ravenwing Apothecary"
                Label3.Visible = True
                Label3.Text = "Plasma talon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Ravenwing Grenade Launcher")
            Case Is = "Ravenwing Ancient"
                Label3.Visible = True
                Label3.Text = "Plasma talon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Ravenwing Grenade Launcher")
            Case Is = "Ravenwing Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Ravenwing Bike Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Ravenwing Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Ravenwing Attack Bike Squad"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Ravenwing Land Speeders"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy bolter")
                ComboBox2.Items.Add("Typhoon missile launcher")
                ComboBox2.Items.Add("Multi-melta")
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox2.Items.Add("Assault cannon")
            Case Else
                Console.WriteLine(nameofsquad & " is not available atm")
        End Select
        If figcount >= maxnumberoffigs Then
            Btn_NextSquad.Enabled = True
            Btn_NextModel.Enabled = False
        Else
            Btn_NextSquad.Enabled = False
            Btn_NextModel.Enabled = True
        End If

    End Sub

    Private Sub Weapons_Selection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        For Each cont As Control In Me.Controls
            cont.Visible = False
        Next
        Btn_NextSquad.Enabled = True
        Btn_NextModel.Enabled = False
        Label1.Visible = True
        nameofsquad = ""
        'Console.WriteLine(Race_Selection_Form.Playerid)
        'Select Case Race_Selection_Form.Playerid
        '    Case Is = 1
        '        str = Team_Setup.playeronearmy '.Split("~")
        '    Case Is = 2
        '        str = Team_Setup.playertwoarmy '.Split("~")
        '    Case Is = 3
        '        str = Team_Setup.playerthreearmy '.Split("~")
        '    Case Is = 4
        '        str = Team_Setup.playerfourarmy '.Split("~")
        '    Case Is = 5
        '        str = Team_Setup.playerfivearmy '.Split("~")
        '    Case Is = 6
        '        str = Team_Setup.playersixarmy '.Split("~")
        '    Case Is = 7
        '        str = Team_Setup.playersevenarmy '.Split("~")
        '    Case Is = 8
        '        str = Team_Setup.playereightarmy '.Split("~")
        'End Select
        'For z As Integer = 0 To str.Count - 1

        '    groupstorage(Race_Selection_Form.Playerid.ToString)(z) = str(z).ToString

        'Next z

        Dim part As New List(Of String)
        Try
            part.AddRange(Functions.listallModels(0).Split(" "))
        Catch ex As Exception
            part.AddRange(Functions.listallModels)
        End Try
        For parta As Integer = 0 To part.Count - 1
            If IsNumeric(part(parta)) = True Then
                If maxnumberoffigs = 0 Then
                    maxnumberoffigs = part(parta)
                    figcount = 1
                ElseIf thirdunit = 0 Then
                    thirdunit = part(parta)
                ElseIf fourthunit = 0 Then
                    fourthunit = part(parta)
                ElseIf fifthunit = 0 Then
                    fifthunit = part(parta)
                ElseIf sixthunit = 0 Then
                    sixthunit = part(parta)
                End If




                ''''''''Exit For
            Else
                If parta <> 0 Then
                    nameofsquad += " " & part(parta)
                Else
                    nameofsquad += part(parta)
                End If
                maxnumberoffigs = 0
                figcount = 0
            End If
        Next
        'If figcount >= maxnumberoffigs Then
        '    Btn_NextSquad.Enabled = True
        '    Btn_NextModel.Enabled = False
        'Else
        '    Btn_NextSquad.Enabled = False
        '    Btn_NextModel.Enabled = True
        'End If
        line += 1

        Btn_NextSquad.Visible = True
        Btn_NextModel.Visible = True
        Timer1.Enabled = True
        Timer1.Start()
        Timer1.Interval = 1

        Select Case nameofsquad
            Case Is = "Captain"
                Label3.Visible = True
                Label3.Text = "Chainsword"
                Label4.Visible = True
                Label4.Text = "Master-crafted boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox1.Items.Add("Relic blade")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Captain in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Power sword"
                Label4.Visible = True
                Label4.Text = "Storm bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox1.Items.Add("Relic blade")
                ComboBox1.Items.Add("Chainfist")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Terminator_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
            Case Is = "Captain in Cataphractii Armour"
                Label3.Visible = True
                Label3.Text = "Power sword"
                Label4.Visible = True
                Label4.Text = "Combi-bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Relic blade")
                ComboBox1.Items.Add("Chainfist")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
            Case Is = "Captain in Gravis Armour"
                Label3.Visible = True
                Label3.Text = "This may not alter their wargear options."
            Case Is = "Captain on Bike"
                Label3.Visible = True
                Label3.Text = "Chain sword"
                Label4.Visible = True
                Label4.Text = "Master-crafted boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
            Case Is = "Librarian"
                Label3.Visible = True
                Label3.Text = "Force stave"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Force axe")
                ComboBox1.Items.Add("Force sword")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Librarian in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Force stave"
                Label4.Visible = True
                Label4.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Force axe")
                ComboBox1.Items.Add("Force sword")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Storm shield")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Librarian on Bike"
                Label3.Visible = True
                Label3.Text = "Force stave"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Force axe")
                ComboBox1.Items.Add("Force sword")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
            Case Is = "Techmarine"
                Label3.Visible = True
                Label3.Text = "Power axe"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                Label5.Visible = True
                Label5.Text = "Servo-arm"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Conversion beamer")
                ComboBox3.Items.Add("Servo-harness")
            Case Is = "Servitors"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs = 4
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Servo-arm"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Heavy bolter")
                ComboBox1.Items.Add("Plasma cannon")
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Techmarine on Bike"
                Label3.Visible = True
                Label3.Text = "Power axe"
                Label4.Visible = True
                Label4.Text = "Bolt Pistol"
                Label5.Visible = True
                Label5.Text = "Servo-arm"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox2.Items.Add("Boltgun")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Conversion beamer")
                ComboBox3.Items.Add("Servo-harness")
            Case Is = "Chaplain"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
                ComboBox1.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Chaplain in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Storm Bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Combi_Weapons(str))
                Next
            Case Is = "Chaplain on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
                ComboBox1.Items.Add("Power fist")
            Case Is = "Apothecary"
                Label3.Visible = True
                Label3.Text = "This may not alter their wargear options."
            Case Is = "Apothecary on Bike"
                Label3.Visible = True
                Label3.Text = "This may not alter their wargear options."
            Case Is = "Primaris Lieutenants"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Master-crafted auto bolt rifle"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
            Case Is = "Company Ancient"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
            Case Is = "Company Ancient on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Boltgun")
            Case Is = "Primaris Ancient"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Company Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Company Champion on Bike"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Company Veterans"
                Label2.Visible = True
                Label2.Text = "Model: Veteran Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox1.Items.Add("Boltgun")
            Case Is = "Company Veterans on Bike"
                Label2.Visible = True
                Label2.Text = "Model: Veteran Biker Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Tactical Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Scout Squad"
                Label2.Visible = True
                Label2.Text = "Model: Scout Sergeant"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                maxnumberoffigs += 1
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Boltgun"
                ComboBox2.Items.Add("Sniper rifle")
                ComboBox2.Items.Add("Astartes shotgun")
                ComboBox2.Items.Add("Combat knife")
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Camo Cloak"
            Case Is = "Intercessor Squad"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Imperial Space Marine"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Honour Guard"
                figcount = 1
                maxnumberoffigs = 2
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label3.Visible = True
                Label3.Text = "Power axe"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power lance")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Relic blade")
            Case Is = "Chapter Ancient"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chapter Champion"
                Label3.Visible = True
                Label3.Text = "Power axe"
                Label4.Visible = True
                Label4.Text = "Boltgun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power lance")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Thunder hammer")
                ComboBox1.Items.Add("Relic blade")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Champion's blade")
            Case Is = "Centurion Assault Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Centurion Sergeant"
                Label3.Visible = True
                Label3.Text = "two Flamers"
                Label4.Visible = True
                Label4.Text = "Centurion assault launcher"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Meltaguns")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Hurricane bolter")
            Case Is = "Sternguard Veteran Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Veteran Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Special issue boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox1.Items.Remove("Thunder hammer")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
                ComboBox2.Items.Remove("Thunder hammer")
            Case Is = "Vanguard Veteran Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Veteran Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox1.Items.Add("Relic blade")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox2.Items.Add("Storm shield")
                ComboBox2.Items.Add("Relic blade")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
                CheckBox2.Visible = True
                CheckBox2.Text = "Melta Bomb"
            Case Is = "Dreadnought"
                Label3.Visible = True
                Label3.Text = "Assault cannon"
                Label4.Visible = True
                Label4.Text = "Dreadnought combat weapon and Storm bolter"
                Label5.Visible = True
                Label5.Text = "Storm bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Dreadnought_Heavy_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Dreadnought_Heavy_Weapons(str))
                Next
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Missile launcher")
                ComboBox2.Items.Add("Twin Autocannon")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
            Case Is = "Venerable Dreadnought"
                Label3.Visible = True
                Label3.Text = "Assault cannon"
                Label4.Visible = True
                Label4.Text = "Dreadnought combat weapon and Storm bolter"
                Label5.Visible = True
                Label5.Text = "Storm bolter"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Dreadnought_Heavy_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Dreadnought_Heavy_Weapons(str))
                Next
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Missile launcher")
                ComboBox2.Items.Add("Twin Autocannon")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
            Case Is = "Contemptor Dreadnought"
                Label3.Visible = True
                Label3.Text = "Assault cannon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Kheres pattern assault cannon")
            Case Is = "Contemptor Dreadnought"
                Label3.Visible = True
                Label3.Text = "Seismic Hammer"
                Label4.Visible = True
                Label4.Text = "Dreadnought combat weapon and Storm bolter"
                Label5.Visible = True
                Label5.Text = "Storm bolter"
                Label6.Visible = True
                Label6.Text = "Meltagun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Dreadnought Chainfist")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Hurricane bolter")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
                ComboBox4.Visible = True
                ComboBox4.Items.Add("Heavy flamer")
                CheckBox1.Visible = True
                CheckBox1.Text = "two Hunter-killer missiles"
                CheckBox2.Visible = True
                CheckBox2.Text = "Ironclad Assault Launchers"
            Case Is = "Terminator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Terminator Sergeant"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Terminator Assault Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Terminator Sergeant"
                Label3.Visible = True
                Label3.Text = "two Lightning claws"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer and Storm Shield")
            Case Is = "Cataphractii Terminator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Cataphractii Sergeant"
                Label3.Visible = True
                Label3.Text = "Power Sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainfist")
                ComboBox1.Items.Add("Power fist")
                ComboBox1.Items.Add("Lightning claw")
                CheckBox1.Visible = True
                CheckBox1.Text = "Grenade Harness"
            Case Is = "Tartaros Terminator Squad"
                'skipped cus'
            Case Is = "Assault Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Combat Shield"
                CheckBox2.Visible = True
                CheckBox2.Text = "Melta Bombs"
            Case Is = "Inceptor Squad"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Scout Bike Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Scout Biker Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Bike Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Biker Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Attack Bike Squad"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Land Speeder Storm"
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox1.Items.Add("Assault cannon")
            Case Is = "Land Speeders"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy bolter")
                ComboBox2.Items.Add("Typhoon missile launcher")
                ComboBox2.Items.Add("Multi-melta")
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox2.Items.Add("Assault cannon")
            Case Is = "Rhino"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Rhino Primaris"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
            Case Is = "Razorback"
                Label3.Visible = True
                Label3.Text = "Twin Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Twin Lascannon")
                ComboBox1.Items.Add("Twin Assault cannon")
                ComboBox1.Items.Add("Lascannon and Twin Plasma gun ")
                ComboBox1.Items.Add("Twin Heavy flamer")
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Drop Pod"
                Label3.Visible = True
                Label3.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Deathwind launcher")
            Case Is = "Stormhawk Interceptor"
                Label3.Visible = True
                Label3.Text = "two Heavy bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Skyhammer missile launcher")
                ComboBox1.Items.Add("Typhoon  missile launcher")
                Label4.Visible = True
                Label4.Text = "Icarus stormcannon"
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Las-talon")
            Case Is = "Stormtalon Gunship"
                Label3.Visible = True
                Label3.Text = "two Heavy bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Skyhammer missile launcher")
                ComboBox1.Items.Add("Typhoon  missile launcher")
                ComboBox1.Items.Add("two Lascannons")
            Case Is = "Devastator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Sergeant"
                Label3.Visible = True
                Label3.Text = "Boltgun"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Centurion Devastator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Centurion Sergeant"
                Label3.Visible = True
                Label3.Text = "Hurricane bolter"
                Label3.Visible = True
                Label3.Text = "two Heavy Bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Centurion missile launcher")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Lascannons")
                ComboBox2.Items.Add("Grav-cannon and grav-amp")
            Case Is = "Hellblaster Squad"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Thunderfire Cannon"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Predator"
                Label3.Visible = True
                Label3.Text = "Predator autocannon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Twin Lascannon")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Lascannons")
                ComboBox2.Items.Add("two Heavy bolters")
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Whirlwind"
                Label3.Visible = True
                Label3.Text = "Whirlwind vengeance launcher"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Whirlwind castellan launcher")
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Vindicator"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Hunter"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Stalker"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
            Case Is = "Stormraven Gunship"
                Label3.Visible = True
                Label3.Text = "Twin Assault cannon"
                Label4.Visible = True
                Label4.Text = "Twin Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Twin Lascannon")
                ComboBox1.Items.Add("Twin Heavy plasma cannon")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Twin Multi-melta")
                ComboBox2.Items.Add("Typhoon missile launcher")
                CheckBox1.Visible = True
                CheckBox1.Text = "two Hurricane bolters"
            Case Is = "Land Raider"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Land Raider Crusader"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Land Raider Redeemer"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Land Raider Excelsior"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
                CheckBox4.Visible = True
                CheckBox4.Text = "Combi-plasma"
            Case Is = "Roboute Guilliman"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Marneus Calgar"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Marneus Calgar in Artificer Armour"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Captain Sicarus"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chief Librarian Tigurius"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chaplain Cassius"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sergeant Telion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
                ''Sergeant Chronus Skipped cus'
            Case Is = "Tyrannic War Veterans"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Terminus Ultra"
                CheckBox1.Visible = True
                CheckBox1.Text = "Hunter-killer missile"
                CheckBox2.Visible = True
                CheckBox2.Text = "Storm bolter"
                CheckBox3.Visible = True
                CheckBox3.Text = "Multi-melta"
            Case Is = "Captain Lysander"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Pedro Kantor"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "High Marshal Helbrecht"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "The Emperor's Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Chaplain Grimaldus"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Cenobyte Servitors"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Crusader Squad"
                figcount = 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                If fourthunit > 0 Then
                    Label2.Visible = True
                    Label2.Text = "Model: Sword Brother"
                    Label3.Visible = True
                    Label3.Text = "Bolt pistol"
                    Label4.Visible = True
                    Label4.Text = "Boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                        ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                    Next
                    For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                        ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                    Next
                    ComboBox2.Visible = True
                    For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                        ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
                    Next
                Else
                    Label2.Visible = True
                    Label2.Text = "Model: Initiate"
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Items.Add("Chainsword")
                End If
            Case Is = "Kayvann Shrike"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Vulkan He'stan"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Kor'sarro Khan", "Kor'sarro Khan"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Damned Legionaires"
                Label2.Visible = True
                Label2.Text = "Model: Initiate"
                Label3.Visible = True
                Label3.Text = "Boltgun"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainsword")
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power axe")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Power fist")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Plasma pistol")
                ComboBox2.Items.Add("Storm bolter")
            Case Is = "Commander Dante"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Captain Tycho", "Tycho the Lost"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Librarian Dreadnought"
                Label3.Visible = True
                Label3.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox1.Items.Add("Meltagun")
            Case Is = "Chief Librarian Mephiston"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "The Sanguinor"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Astorath"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sanguinary Priest"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = False
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump pack"
            Case Is = "Sanguinary Priest on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = False
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
            Case Is = "Brother Corbulo"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sanguinary Guard Ancient"
                Label3.Visible = True
                Label3.Text = "Angelus boltgun"
                Label4.Visible = True
                Label4.Text = "Encarmine sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Inferno pistol")
                ComboBox1.Items.Add("Plasma pistol")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Encarmine axe")
                ComboBox2.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Death mask"
            Case Is = "Terminator Ancient"
                Label3.Visible = True
                Label3.Text = "Lightning claw"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer")
            Case Is = "Death Company"
                Label3.Visible = True
                Label3.Text = "Chainsword and Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                Label5.Visible = True
                Label5.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Boltgun")
                ComboBox2.Items.Add("Hand flamer")
                ComboBox2.Items.Add("Inferno pistol")
                ComboBox2.Items.Add("Plasma pistol")
                ComboBox2.Items.Add("Power sword")
                ComboBox2.Items.Add("Power axe")
                ComboBox2.Items.Add("Power maul")
                ComboBox2.Items.Add("Power fist")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Power sword")
                ComboBox3.Items.Add("Power axe")
                ComboBox3.Items.Add("Power maul")
                ComboBox3.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
            Case Is = "Lemartes"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sanguinary Guard"
                figcount = 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label3.Visible = True
                Label3.Text = "Angelus boltgun"
                Label4.Visible = True
                Label4.Text = "Encarmine sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Inferno pistol")
                ComboBox1.Items.Add("Plasma pistol")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Encarmine axe")
                ComboBox2.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Death mask"
            Case Is = "Death Company Dreadnought"
                Label3.Visible = True
                Label3.Text = "two Furioso fists"
                Label4.Visible = True
                Label4.Text = "Storm Bolter"
                Label5.Visible = True
                Label5.Text = "Meltagun"
                Label5.Visible = True
                Label5.Text = "Smoke Launchers"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Blood talons")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
                ComboBox4.Visible = True
                ComboBox4.Items.Add("Magna-grapple")
            Case Is = "Furioso Dreadnought"
                Label3.Visible = True
                Label3.Text = "two Furioso fists"
                Label4.Visible = True
                Label4.Text = "Storm Bolter"
                Label5.Visible = True
                Label5.Text = "Meltagun"
                Label6.Visible = True
                Label6.Text = "Smoke Launchers"
                Label7.Visible = True
                Label7.Text = "one Furioso fist and either its Storm bolter or its Meltagun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Blood talons")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Heavy flamer")
                ComboBox4.Visible = True
                ComboBox4.Items.Add("Magna-grapple")
                ComboBox5.Visible = True
                ComboBox5.Items.Add("Frag Cannon")
            Case Is = "Baal Predator"
                Label3.Visible = True
                Label3.Text = "Twin Assault cannon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Flamestorm cannon")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Heavy flamer")
                ComboBox2.Items.Add("two Heavy bolters")
            Case Is = "Gabriel Seth"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Azrael"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Belial"
                Label3.Visible = True
                Label3.Text = "Storm bolter and Sword of Silence"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Lightning claws")
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
            Case Is = "Sammael on Corvex"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Sammael in Sableclaw"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Interrogator-Chaplain"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Power fist"
            Case Is = "Interrogator-Chaplain in Terminator Armour"
                Label3.Visible = True
                Label3.Text = "Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Lightning claw")
                ComboBox1.Items.Add("Power fist")
                For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
                Next
            Case Is = "Interrogator-Chaplain on Bike"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Power fist"
            Case Is = "Asmodai"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Ezekiel"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Deathwing Apothecary"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Deathwing Ancient"
                Label3.Visible = True
                Label3.Text = "Power fist and Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Lightning claws")
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
                Label3.Visible = True
                Label3.Text = "Power fist"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainfist")
            Case Is = "Deathwing Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Deathwing Terminator Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Deathwing Sergeant"
                Label3.Visible = True
                Label3.Text = "Power sword and Storm bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
                ComboBox1.Items.Add("two Lightning claws")
                CheckBox1.Visible = True
                CheckBox1.Text = "Accompanied by a Watcher in the Dark"
            Case Is = "Deathwing Knights"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
                CheckBox1.Visible = True
                CheckBox1.Text = "Accompanied by a Watcher in the Dark"
            Case Is = "Ravenwing Apothecary"
                Label3.Visible = True
                Label3.Text = "Plasma talon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Ravenwing Grenade Launcher")
            Case Is = "Ravenwing Ancient"
                Label3.Visible = True
                Label3.Text = "Plasma talon"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Ravenwing Grenade Launcher")
            Case Is = "Ravenwing Champion"
                Label3.Visible = True
                Label3.Text = "This unit may not alter their wargear options."
            Case Is = "Ravenwing Bike Squad"
                figcount = 1
                maxnumberoffigs += 1
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                Label2.Visible = True
                Label2.Text = "Model: Ravenwing Sergeant"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
                Next
                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
                Next
            Case Is = "Ravenwing Attack Bike Squad"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Ravenwing Land Speeders"
                Btn_NextSquad.Enabled = False
                Btn_NextModel.Enabled = True
                figcount = 1
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy bolter")
                ComboBox2.Items.Add("Typhoon missile launcher")
                ComboBox2.Items.Add("Multi-melta")
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox2.Items.Add("Assault cannon")
            Case Else
                Console.WriteLine(nameofsquad & " is not available atm")
        End Select
        If maxnumberoffigs = 0 Then
            Label1.Text = "Group Name: " & nameofsquad
        Else
            Label1.Text = "Group Name: " & nameofsquad & " " & figcount
        End If
        If figcount >= maxnumberoffigs Then
            Btn_NextSquad.Enabled = True
            Btn_NextModel.Enabled = False
        Else
            Btn_NextSquad.Enabled = False
            Btn_NextModel.Enabled = True
        End If
        ComboBox1.Sorted = True
        ComboBox2.Sorted = True
        ComboBox3.Sorted = True
        ComboBox4.Sorted = True
        ComboBox5.Sorted = True
        Dim i As Integer = 0
        Do Until i + 1 >= ComboBox1.Items.Count
            If ComboBox1.Items.Item(i) = ComboBox1.Items.Item(i + 1) Then
                ComboBox1.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox2.Items.Count
            If ComboBox2.Items.Item(i) = ComboBox2.Items.Item(i + 1) Then
                ComboBox2.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox3.Items.Count
            If ComboBox3.Items.Item(i) = ComboBox3.Items.Item(i + 1) Then
                ComboBox3.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox4.Items.Count
            If ComboBox4.Items.Item(i) = ComboBox4.Items.Item(i + 1) Then
                ComboBox4.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox5.Items.Count
            If ComboBox5.Items.Item(i) = ComboBox5.Items.Item(i + 1) Then
                ComboBox5.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        If figcount = 0 Then
            Label1.Text = "Group Name: " & nameofsquad
        Else
            Label1.Text = "Group Name: " & nameofsquad & " " & figcount
        End If
    End Sub

    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    If Label1.Text = "Group Name: Captain in Terminator Armour" And ComboBox1.Text = "Power fist" Then
    '        CheckBox1.Visible = True
    '        CheckBox1.Text = "Wrist-mounted Grenade Launcher"
    '    Else
    '        CheckBox1.Visible = False
    '    End If
    'End Sub

    Private Sub Btn_NextModel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_NextModel.Click
        ''''''

        Select Case nameofsquad
            Case Is = "Death Company"
                If ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Chainsword and Bolt pistol" & Chr(34) & " or the " & Chr(34) & "Chainsword" & Chr(34) & " not both")
                    Exit Sub
                ElseIf ComboBox2.SelectedIndex > -1 And ComboBox1.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Chainsword and Bolt pistol" & Chr(34) & " or the " & Chr(34) & "Bolt pistol" & Chr(34) & " not both")
                    Exit Sub
                End If
            Case Is = "Deathwing Terminator Squad"
                If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 Or ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Power fist and Storm bolter" & Chr(34) & " or the " & Chr(34) & "Power fist" & Chr(34) & " and the " & Chr(34) & "Storm Bolter" & Chr(34) & " not both")
                    Exit Sub
                End If
            Case Is = "Scout Squad"
                If ComboBox1.SelectedIndex > -1 And ComboBox2.Text = "Sniper Rifle" Then
                    MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
                    Exit Sub
                End If
        End Select
        ''adding to transfer string
        Dim storagelist As New System.Collections.Specialized.StringCollection
        If Label2.Visible Then
            Imp1Name = Regex.Replace(Label2.Text, "Model: ", "")
        Else
            Imp1Name = nameofsquad
        End If

        If ComboBox1.SelectedIndex > -1 And Label3.Visible = True Then
            storagelist.Add(ComboBox1.Text)
        ElseIf Label3.Visible = True And ComboBox1.SelectedIndex = -1 Then
            storagelist.Add(Label3.Text)
        ElseIf Label3.Visible = False And ComboBox1.Visible = True And ComboBox1.SelectedIndex > -1 Then
            storagelist.Add(ComboBox1.Text)
        End If
        If ComboBox2.SelectedIndex > -1 And Label4.Visible = True Then
            storagelist.Add(ComboBox2.Text)
        ElseIf Label4.Visible = True And ComboBox2.SelectedIndex = -1 Then
            storagelist.Add(Label4.Text)
        ElseIf Label4.Visible = False And ComboBox2.Visible = True And ComboBox2.SelectedIndex > -1 Then
            storagelist.Add(ComboBox2.Text)
        End If
        If ComboBox3.SelectedIndex > -1 And Label5.Visible = True Then
            storagelist.Add(ComboBox3.Text)
        ElseIf Label5.Visible = True And ComboBox3.SelectedIndex = -1 Then
            storagelist.Add(Label5.Text)
        ElseIf Label5.Visible = False And ComboBox3.Visible = True And ComboBox3.SelectedIndex > -1 Then
            storagelist.Add(ComboBox3.Text)
        End If
        If ComboBox4.SelectedIndex > -1 And Label6.Visible = True Then
            storagelist.Add(ComboBox4.Text)
        ElseIf Label6.Visible = True And ComboBox4.SelectedIndex = -1 Then
            storagelist.Add(Label6.Text)
        ElseIf Label6.Visible = False And ComboBox4.Visible = True And ComboBox4.SelectedIndex > -1 Then
            storagelist.Add(ComboBox4.Text)
        End If
        If ComboBox5.SelectedIndex > -1 And Label7.Visible = True Then
            storagelist.Add(ComboBox5.Text)
        ElseIf Label7.Visible = True And ComboBox5.SelectedIndex = -1 Then
            storagelist.Add(Label7.Text)
        ElseIf Label7.Visible = False And ComboBox5.Visible = True And ComboBox5.SelectedIndex > -1 Then
            storagelist.Add(ComboBox5.Text)
        End If
        If CheckBox1.Checked = True Then
            storagelist.Add(CheckBox1.Text)
        End If
        If CheckBox2.Checked = True Then
            storagelist.Add(CheckBox2.Text)
        End If
        If CheckBox3.Checked = True Then
            storagelist.Add(CheckBox3.Text)
        End If
        If CheckBox4.Checked = True Then
            storagelist.Add(CheckBox4.Text)
        End If
        For x As Integer = 0 To storagelist.Count - 1
            If storagelist(x).Contains("two") Then
                storagelist(x).Replace("two ", "")
                storagelist.Add(storagelist(x))
            End If
        Next

        Functions.addModelToArmyList(nameofsquad, Functions.Groupid, Imp1Name, storagelist)
        'Functions.Groupid += 1


        figcount += 1
        
        ''reset sequence
        ComboBox1.Items.Clear()
        ComboBox1.ResetText()
        ComboBox2.Items.Clear()
        ComboBox2.ResetText()
        ComboBox3.Items.Clear()
        ComboBox3.ResetText()
        ComboBox4.Items.Clear()
        ComboBox4.ResetText()
        ComboBox5.Items.Clear()
        ComboBox5.ResetText()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        For Each cont As Control In Me.Controls
            cont.Visible = False
        Next
        Label1.Visible = True
        Btn_NextModel.Visible = True
        Btn_NextSquad.Visible = True
        Select Case nameofsquad
            Case Is = "Servitors"
                If figcount <= 2 Then
                    Label3.Visible = True
                    Label3.Text = "Servo-arm"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Heavy Bolter")
                    ComboBox1.Items.Add("Plasma Cannon")
                    ComboBox1.Items.Add("Multi-melta")
                Else
                    Label3.Visible = False
                    ComboBox1.Visible = False
                End If
            Case Is = "Primaris Lieutenants"
                Label3.Visible = True
                Label3.Text = "Master-crafted auto bolt rifle"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
            Case Is = "Company Veterans"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Veteran"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Storm shield")
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Storm shield")
                ComboBox2.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Special_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Special_Weapons(str))
                Next
            Case Is = "Company Veterans on Bike"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Veteran"
                Label3.Visible = True
                Label3.Text = "Bolt Pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Storm shield")
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                ComboBox2.Items.Add("Storm shield")
                ComboBox2.Items.Add("Boltgun")
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Combi_Weapons(str))
                Next
                For str As Integer = 0 To SM_Special_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Special_Weapons(str))
                Next
            Case Is = "Tactical Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine"
                If maxnumberoffigs < 10 And figcount = 2 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_Special_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Special_Weapons(str))
                    Next
                    For str As Integer = 0 To SM_Heavy_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Heavy_Weapons(str))
                    Next
                End If
                If maxnumberoffigs = 10 And figcount = 3 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_Heavy_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Heavy_Weapons(str))
                    Next
                ElseIf maxnumberoffigs = 10 And figcount = 4 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_Special_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Special_Weapons(str))
                    Next
                End If
            Case Is = "Scout Squad"
                Label2.Visible = True
                Label2.Text = "Model: Scout"
                Label3.Visible = True
                Label3.Text = "Boltgun"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Sniper rifle")
                ComboBox1.Items.Add("Astartes shotgun")
                ComboBox1.Items.Add("Combat knife")
                If figcount = 2 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Heavy Bolter")
                    ComboBox1.Items.Add("Missile Launcher")
                End If
                CheckBox1.Visible = True
                CheckBox1.Text = "Camo Cloak"
            Case Is = "Honour Guard"
                Label3.Visible = True
                Label3.Text = "Power axe"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Power sword")
                ComboBox1.Items.Add("Power lance")
                ComboBox1.Items.Add("Power maul")
                ComboBox1.Items.Add("Relic blade")
            Case Is = "Centurion Assault Squad"
                Label2.Visible = True
                Label2.Text = "Model: Centurion"
                Label3.Visible = True
                Label3.Text = "two Flamers"
                Label4.Visible = True
                Label4.Text = "Centurion assault launcher"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("two Meltaguns")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Hurricane bolter")
            Case Is = "Sternguard Veteran Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Veteran"
                If figcount = 2 Or figcount = 3 Then
                    Label3.Visible = True
                    Label3.Text = "Special issue boltgun"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Heavy flamer")
                    For str As Integer = 0 To SM_Special_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Special_Weapons(str))
                    Next
                    For str As Integer = 0 To SM_Heavy_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Heavy_Weapons(str))
                    Next
                    For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Combi_Weapons(str))
                    Next
                Else
                    Label3.Visible = True
                    Label3.Text = "Special issue boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_Combi_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Combi_Weapons(str))
                    Next
                End If


            Case Is = "Vanguard Veteran Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Veteran"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Chainsword"
                ComboBox1.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox1.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox1.Items.Add(SM_Melee_Weapons(str))
                Next
                ComboBox1.Items.Add("Storm shield")
                ComboBox2.Visible = True
                For str As Integer = 0 To SM_Pistols.Count - 1
                    ComboBox2.Items.Add(SM_Pistols(str))
                Next
                For str As Integer = 0 To SM_Melee_Weapons.Count - 1
                    ComboBox2.Items.Add(SM_Melee_Weapons(str))
                Next
                CheckBox1.Visible = True
                CheckBox1.Text = "Jump Pack"
                If CheckBox2.Checked = True Then
                    miscstuff1 = True
                    CheckBox2.Visible = False
                End If
                If miscstuff1 = True Then
                    CheckBox2.Visible = False
                End If
            Case Is = "Terminator Squad"
                Label2.Visible = True
                Label2.Text = "Model: Terminator"
                Label3.Visible = True
                Label3.Text = "Power fist"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainfist")
                If figcount = 2 Or figcount = 10 Then
                    Label4.Visible = True
                    Label4.Text = "Storm Bolter"
                    ComboBox2.Visible = True
                    For str As Integer = 0 To SM_Terminator_Heavy_Weapons.Count - 1
                        ComboBox2.Items.Add(SM_Terminator_Heavy_Weapons(str))
                    Next
                End If
            Case Is = "Terminator Assault Squad"
                Label2.Visible = True
                Label2.Text = "Model: Terminator"
                Label3.Visible = True
                Label3.Text = "two Lightning claws"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer and Storm Shield")
            Case Is = "Cataphractii Terminator Squad"
                Label2.Visible = True
                Label2.Text = "Model: Cataphractii Terminator"
                Label3.Visible = True
                Label3.Text = "Combi-bolter"
                Label4.Visible = True
                Label4.Text = "Power fist"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Lightning claw")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Chainfist")
                ComboBox2.Items.Add("Lightning claw")
                If figcount = 2 Or figcount = 10 Then
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Heavy flamer")
                End If
            Case Is = "Tartaros Terminator Squad"
                ''skipped cus'
            Case Is = "Assault Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine"
                If figcount = 2 Or figcount = 3 Then
                    Label3.Visible = True
                    Label3.Text = "Bolt-pistol and Chainsword"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Flamer")
                    ComboBox1.Items.Add("Plasma pistol and Chainsword")
                End If
                If maxnumberoffigs = 5 And figcount = 4 Then
                    Label3.Visible = True
                    Label3.Text = "Bolt-pistol and Chainsword"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Eviscerator")
                ElseIf maxnumberoffigs = 10 And (figcount = 4 Or figcount = 5) Then
                    Label3.Visible = True
                    Label3.Text = "Bolt-pistol and Chainsword"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Eviscerator")
                End If
            Case Is = "Scout Bike Squad"
                Label2.Visible = True
                Label2.Text = "Model: Scout Biker"
                If figcount = 2 Or figcount = 3 Or figcount = 4 Then
                    Label3.Visible = True
                    Label3.Text = "Bike's Twin Boltgun"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Astartes Grenade launcher")
                End If
            Case Is = "Bike Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine Biker"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                If figcount = 2 Or figcount = 3 Then
                    For str As Integer = 0 To SM_Special_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Special_Weapons(str))
                    Next
                End If
                If thirdunit <> 0 Then
                    Label2.Visible = True
                    Label2.Text = "Model: Attack Bike"
                    Label3.Visible = True
                    Label3.Text = "Heavy Bolter"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Multi-melta")
                End If
            Case Is = "Attack Bike Squad"
                Label2.Visible = True
                Label2.Text = "Model: Attack Bike"
                Label3.Visible = True
                Label3.Text = "Heavy Bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Land Speeders"
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy bolter")
                ComboBox2.Items.Add("Typhoon missile launcher")
                ComboBox2.Items.Add("Multi-melta")
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox2.Items.Add("Assault cannon")
            Case Is = "Devastator Squad"
                Label2.Visible = True
                Label2.Text = "Model: Space Marine"
                If figcount = 2 Or figcount = 3 Or figcount = 4 Or figcount = 5 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Visible = True
                    For str As Integer = 0 To SM_Heavy_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Heavy_Weapons(str))
                    Next
                End If
            Case Is = "Centurion Devastator Squad"
                Label2.Visible = True
                Label2.Text = "Model: Centurion"
                Label3.Visible = True
                Label3.Text = "Hurricane bolter"
                Label3.Visible = True
                Label3.Text = "two Heavy Bolters"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Centurion missile launcher")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("two Lascannons")
                ComboBox2.Items.Add("Grav-cannon and grav-amp")
            Case Is = "Crusader Squad"
                If figcount <= (maxnumberoffigs + fourthunit) Then
                    ''initiate
                    Label2.Visible = True
                    Label2.Text = "Model: Initiate"
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Chainsword")
                    If figcount = 2 Then
                        For str As Integer = 0 To SM_Special_Weapons.Count - 1
                            ComboBox1.Items.Add(SM_Special_Weapons(str))
                        Next
                    ElseIf figcount = 3 Then
                        For str As Integer = 0 To SM_Heavy_Weapons.Count - 1
                            ComboBox1.Items.Add(SM_Heavy_Weapons(str))
                        Next
                        ComboBox1.Items.Add("Power sword")
                        ComboBox1.Items.Add("Power axe")
                        ComboBox1.Items.Add("Power maul")
                        ComboBox1.Items.Add("Power fist")
                    End If
                ElseIf figcount <= (maxnumberoffigs + fourthunit + thirdunit) Then
                    ''neophyte
                    Label2.Visible = True
                    Label2.Text = "Model: Neophyte"
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Items.Add("Astartes shotgun")
                    ComboBox1.Items.Add("Combat knife")
                End If
            Case Is = "Damned Legionaires"
                If figcount = 2 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Items.Add("Flamer")
                    ComboBox1.Items.Add("Melta gun")
                    ComboBox1.Items.Add("Plasma gun")
                ElseIf figcount = 3 Then
                    Label3.Visible = True
                    Label3.Text = "Boltgun"
                    ComboBox1.Items.Add("Heavy flamer")
                    ComboBox1.Items.Add("Multi-melta")
                End If
            Case Is = "Death Company"
                Label3.Visible = True
                Label3.Text = "Chainsword and Bolt pistol"
                Label4.Visible = True
                Label4.Text = "Bolt pistol"
                Label5.Visible = True
                Label5.Text = "Chainsword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Boltgun")
                ComboBox2.Items.Add("Hand flamer")
                ComboBox2.Items.Add("Inferno pistol")
                ComboBox2.Items.Add("Plasma pistol")
                ComboBox2.Items.Add("Power sword")
                ComboBox2.Items.Add("Power axe")
                ComboBox2.Items.Add("Power maul")
                ComboBox2.Items.Add("Power fist")
                ComboBox3.Visible = True
                ComboBox3.Items.Add("Power sword")
                ComboBox3.Items.Add("Power axe")
                ComboBox3.Items.Add("Power maul")
                ComboBox3.Items.Add("Power fist")
            Case Is = "Sanguinary Guard"
                Label3.Visible = True
                Label3.Text = "Angelus boltgun"
                Label4.Visible = True
                Label4.Text = "Encarmine sword"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Inferno pistol")
                ComboBox1.Items.Add("Plasma pistol")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Encarmine axe")
                ComboBox2.Items.Add("Power fist")
                CheckBox1.Visible = True
                CheckBox1.Text = "Death mask"
            Case Is = "Deathwing Terminator Squad"
                Label2.Visible = True
                Label2.Text = "Model: Deathwing Terminator"
                Label3.Visible = True
                Label3.Text = "Power fist and Storm bolter"
                Label4.Visible = True
                Label4.Text = "Power fist"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Thunder hammer and Storm shield")
                ComboBox1.Items.Add("two Lightning claws")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Chainfist")
                If (maxnumberoffigs >= 5 And figcount = 2) Or (maxnumberoffigs = 10 And figcount = 6) Then
                    CheckBox1.Visible = True
                    CheckBox1.Text = "Cyclone missile launcher"
                    Label5.Visible = True
                    Label5.Text = "Storm bolter"
                    ComboBox3.Visible = True
                    ComboBox3.Items.Add("Plasma cannon")
                    For str As Integer = 0 To SM_Terminator_Heavy_Weapons.Count - 1
                        ComboBox3.Items.Add(SM_Terminator_Heavy_Weapons(str))
                    Next
                End If
            Case Is = "Ravenwing Bike Squad"
                Label2.Visible = True
                Label2.Text = "Model: Ravenwing Biker"
                Label3.Visible = True
                Label3.Text = "Bolt pistol"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Chainsword")
                If figcount = 2 Or figcount = 3 Then
                    For str As Integer = 0 To SM_Special_Weapons.Count - 1
                        ComboBox1.Items.Add(SM_Special_Weapons(str))
                    Next
                End If
                If thirdunit <> 0 Then
                    Label2.Visible = True
                    Label2.Text = "Model: Attack Bike"
                    Label3.Visible = True
                    Label3.Text = "Heavy Bolter"
                    ComboBox1.Visible = True
                    ComboBox1.Items.Add("Multi-melta")
                End If
            Case Is = "Ravenwing Attack Bike Squad"
                Label2.Visible = True
                Label2.Text = "Model: Attack Bike"
                Label3.Visible = True
                Label3.Text = "Heavy Bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
            Case Is = "Ravenwing Land Speeders"
                Label3.Visible = True
                Label3.Text = "Heavy bolter"
                ComboBox1.Visible = True
                ComboBox1.Items.Add("Multi-melta")
                ComboBox1.Items.Add("Heavy flamer")
                ComboBox2.Visible = True
                ComboBox2.Items.Add("Heavy bolter")
                ComboBox2.Items.Add("Typhoon missile launcher")
                ComboBox2.Items.Add("Multi-melta")
                ComboBox2.Items.Add("Heavy flamer")
                ComboBox2.Items.Add("Assault cannon")
        End Select
        If figcount >= maxnumberoffigs Then
            Btn_NextSquad.Enabled = True
            Btn_NextModel.Enabled = False
        Else
            Btn_NextSquad.Enabled = False
            Btn_NextModel.Enabled = True
        End If
        Dim i As Integer = 0
        Do Until i + 1 >= ComboBox1.Items.Count
            If ComboBox1.Items.Item(i) = ComboBox1.Items.Item(i + 1) Then
                ComboBox1.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox2.Items.Count
            If ComboBox2.Items.Item(i) = ComboBox2.Items.Item(i + 1) Then
                ComboBox2.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox3.Items.Count
            If ComboBox3.Items.Item(i) = ComboBox3.Items.Item(i + 1) Then
                ComboBox3.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox4.Items.Count
            If ComboBox4.Items.Item(i) = ComboBox4.Items.Item(i + 1) Then
                ComboBox4.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        i = 0
        Do Until i + 1 >= ComboBox5.Items.Count
            If ComboBox5.Items.Item(i) = ComboBox5.Items.Item(i + 1) Then
                ComboBox5.Items.RemoveAt(i + 1)
            End If
            i += 1
        Loop
        If figcount >= maxnumberoffigs + thirdunit + fourthunit + fifthunit + sixthunit Then
            Label1.Text = "Group Name: " & nameofsquad & " " & figcount
            figcount = 0
            Btn_NextSquad.Enabled = True
            Btn_NextModel.Enabled = False
        Else
            Label1.Text = "Group Name: " & nameofsquad & " " & figcount
        End If
    End Sub

End Class