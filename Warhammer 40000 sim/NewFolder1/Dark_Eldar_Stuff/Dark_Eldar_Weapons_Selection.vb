Imports System.Text.RegularExpressions
Public Class Dark_Eldar_Weapons_Selection
    Dim line As Integer = 0
    ' Dim stringinput As String = "Thunderfire Cannon~Vanguard Veteran Squad 4~Venerable Dreadnought~Vindicator"
    Dim str As List(Of String) 'string ' = Team_Setup.playeronearmy.ToString.Split("~") 'stringinput.Split("~") ''
    Dim storagelist As List(Of String)
    Dim storage As String
    Dim figcount As Integer = 0 '' for counting figs in squad
    Dim maxnumberoffigs As Integer = 0
    Dim nameofsquad As String = ""
    Dim miscstuff1 As Boolean = False
    Dim thirdunit As Integer = 0
    Dim fourthunit As Integer = 0
    Dim fifthunit As Integer = 0
    Dim sixthunit As Integer = 0
    'Private Sub Btn_NextUnit_Click(sender As System.Object, e As System.EventArgs) Handles Btn_NextSquad.Click
    '    Select Case nameofsquad
    '        'Case Is = "Dreadnought"
    '        '    If ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
    '        '        Exit Sub
    '        '    End If
    '        'Case Is = "Venerable Dreadnought"
    '        '    If ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
    '        '        Exit Sub
    '        '    End If
    '        'Case Is = "Contemptor Dreadnought"
    '        '    If ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Dreadnought combat weapon and storm bolter" & Chr(34) & " or the " & Chr(34) & "Storm bolter" & Chr(34) & " not both")
    '        '        Exit Sub
    '        '    End If
    '        'Case Is = "Death Company"
    '        '    If ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Chainsword and Bolt pistol" & Chr(34) & " or the " & Chr(34) & "Chainsword" & Chr(34) & " not both")
    '        '        Exit Sub
    '        '    ElseIf ComboBox2.SelectedIndex > -1 And ComboBox1.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Chainsword and Bolt pistol" & Chr(34) & " or the " & Chr(34) & "Bolt pistol" & Chr(34) & " not both")
    '        '        Exit Sub
    '        '    End If
    '        'Case Is = "Furioso Dreadnought"
    '        '    If ComboBox5.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace the " & Chr(34) & "Furioso fist" & Chr(34) & " and either the " & Chr(34) & "Storm bolter" & Chr(34) & " or the " & Chr(34) & "Meltagun" & Chr(34) & " not all")
    '        '        Exit Sub
    '        '    End If
    '        'Case Is = "Deathwing Apothecary"
    '        '    If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 Then
    '        '        MsgBox("Error: With the current weapons setup, you must choose to replace either the " & Chr(34) & "Power fist and Storm bolter" & Chr(34) & " or the " & Chr(34) & "Power fist" & Chr(34) & " not both")
    '        '        Exit Sub
    '        '    End If
    '    End Select

    '    ''adding to transfer string
    '    If storage <> "" Then
    '        If Label2.Visible Then
    '            storage = storage & "~" & Regex.Replace(Label2.Text, "Model: ", "")
    '        Else
    '            storage = storage & "~" & nameofsquad
    '        End If
    '    Else
    '        If Label2.Visible Then
    '            storage = Regex.Replace(Label2.Text, "Model: ", "")
    '        Else
    '            storage = nameofsquad
    '        End If
    '    End If
    '    If ComboBox1.SelectedIndex > -1 Then
    '        storage = storage & "@" & ComboBox1.Text
    '    End If
    '    If ComboBox2.SelectedIndex > -1 Then
    '        storage = storage & "$" & ComboBox2.Text
    '    End If
    '    If ComboBox3.SelectedIndex > -1 Then
    '        storage = storage & "$" & ComboBox3.Text
    '    End If
    '    If ComboBox4.SelectedIndex > -1 Then
    '        storage = storage & "$" & ComboBox4.Text
    '    End If
    '    If ComboBox5.SelectedIndex > -1 Then
    '        storage = storage & "$" & ComboBox5.Text
    '    End If
    '    If CheckBox1.Checked = True And ComboBox1.SelectedIndex > -1 Then
    '        storage = storage & "$" & CheckBox1.Text
    '    ElseIf CheckBox1.Checked = True And ComboBox1.SelectedIndex <= -1 Then
    '        storage = storage & "@" & CheckBox1.Text
    '    End If
    '    If CheckBox2.Checked = True Then
    '        storage = storage & "$" & CheckBox2.Text
    '    End If
    '    If CheckBox3.Checked = True Then
    '        storage = storage & "$" & CheckBox3.Text
    '    End If
    '    If CheckBox4.Checked = True Then
    '        storage = storage & "$" & CheckBox4.Text
    '    End If

    '    'Console.WriteLine("asdfkjahsdf" & storage)
    '    ''reset sequence
    '    For Each cont As Control In Me.Controls
    '        cont.Visible = False
    '    Next
    '    Btn_NextSquad.Visible = True
    '    Btn_NextModel.Visible = True
    '    Label1.Visible = True
    '    Btn_NextSquad.Enabled = True
    '    Btn_NextModel.Enabled = False
    '    If line > str.Count - 1 Then
    '        Select Case Race_Selection_Form.Playerid
    '            Case Is = 1
    '                Team_Setup.playeronearmy = storage
    '            Case Is = 2
    '                Team_Setup.playertwoarmy = storage
    '            Case Is = 3
    '                Team_Setup.playerthreearmy = storage
    '            Case Is = 4
    '                Team_Setup.playerfourarmy = storage
    '            Case Is = 5
    '                Team_Setup.playerfivearmy = storage
    '            Case Is = 6
    '                Team_Setup.playersixarmy = storage
    '            Case Is = 7
    '                Team_Setup.playersevenarmy = storage
    '            Case Is = 8
    '                Team_Setup.playereightarmy = storage
    '        End Select



    '        WeaponsSelectionToMap()


    '    Else
    '        nameofsquad = ""
    '        Dim part() As String = str(line).Split(" ")
    '        For parta As Integer = 0 To part.Count - 1
    '            If IsNumeric(part(parta)) = True Then
    '                maxnumberoffigs = part(parta)
    '                Btn_NextSquad.Enabled = False
    '                Btn_NextModel.Enabled = True
    '                figcount = 1
    '                Exit For
    '            Else
    '                Btn_NextSquad.Enabled = True
    '                Btn_NextModel.Enabled = False
    '                If parta <> 0 Then
    '                    nameofsquad += " " & part(parta)
    '                Else
    '                    nameofsquad += part(parta)
    '                End If
    '                figcount = 0
    '            End If
    '        Next
    '        If figcount = 0 Then
    '            Label1.Text = "Group Name: " & nameofsquad
    '        Else
    '            Label1.Text = "Group Name: " & nameofsquad & " " & figcount
    '        End If
    '        line += 1
    '    End If
    '    ComboBox1.Items.Clear()
    '    ComboBox1.ResetText()
    '    ComboBox2.Items.Clear()
    '    ComboBox2.ResetText()
    '    ComboBox3.Items.Clear()
    '    ComboBox3.ResetText()
    '    ComboBox4.Items.Clear()
    '    ComboBox4.ResetText()
    '    ComboBox5.Items.Clear()
    '    ComboBox5.ResetText()
    '    miscstuff1 = False
    '    ''''''
    '    '    Select Case nameofsquad
    '    '        Case Is = "Captain"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Chainsword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Master-crafted boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Captain in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power sword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Terminator_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Captain in Cataphractii Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power sword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Combi-bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Captain in Gravis Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This may not alter their wargear options."
    '    '        Case Is = "Captain on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Chain sword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Master-crafted boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Librarian"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Force stave"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Force axe")
    '    '            ComboBox1.Items.Add("Force sword")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Librarian in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Force stave"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Force axe")
    '    '            ComboBox1.Items.Add("Force sword")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Storm shield")
    '    '        Case Is = "Librarian on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Force stave"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Force axe")
    '    '            ComboBox1.Items.Add("Force sword")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '        Case Is = "Techmarine"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Servo-arm"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Conversion beamer")
    '    '            ComboBox3.Items.Add("Servo-harness")
    '    '        Case Is = "Servitors"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs = 4
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Servo-arm"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Heavy bolter")
    '    '            ComboBox1.Items.Add("Plasma cannon")
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '        Case Is = "Techmarine on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt Pistol"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Servo-arm"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Conversion beamer")
    '    '            ComboBox3.Items.Add("Servo-harness")
    '    '        Case Is = "Chaplain"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Chaplain in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm Bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Terminator_Combi_Weapons(str))
    '    '            Next
    '    '        Case Is = "Chaplain on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '        Case Is = "Apothecary"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This may not alter their wargear options."
    '    '        Case Is = "Apothecary on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This may not alter their wargear options."
    '    '        Case Is = "Primaris Lieutenants"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Master-crafted auto bolt rifle"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Power sword")
    '    '        Case Is = "Company Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '        Case Is = "Company Ancient on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '        Case Is = "Primaris Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Company Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Company Champion on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Company Veterans"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '        Case Is = "Company Veterans on Bike"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Biker Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Tactical Squad"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Space Marine Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Scout Squad"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Scout Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Camo Cloak"
    '    '        Case Is = "Intercessor Squad"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Imperial Space Marine"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Honour Guard"
    '    '            figcount = 1
    '    '            maxnumberoffigs = 2
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Power sword")
    '    '            ComboBox1.Items.Add("Power lance")
    '    '            ComboBox1.Items.Add("Power maul")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '        Case Is = "Chapter Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chapter Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Power sword")
    '    '            ComboBox1.Items.Add("Power lance")
    '    '            ComboBox1.Items.Add("Power maul")
    '    '            ComboBox1.Items.Add("Thunder hammer")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Champion's blade")
    '    '        Case Is = "Centurion Assault Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Centurion Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Flamers"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Centurion assault launcher"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("two Meltaguns")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Hurricane bolter")
    '    '        Case Is = "Sternguard Veteran Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Special issue boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox1.Items.Remove("Thunder hammer")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Items.Remove("Thunder hammer")
    '    '        Case Is = "Vanguard Veteran Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Storm shield")
    '    '            ComboBox2.Items.Add("Relic blade")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Melta Bomb"
    '    '        Case Is = "Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Dreadnought combat weapon and Storm bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Dreadnought_Heavy_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Dreadnought_Heavy_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Missile launcher")
    '    '            ComboBox2.Items.Add("twin Autocannon")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '        Case Is = "Venerable Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Dreadnought combat weapon and Storm bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Dreadnought_Heavy_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Dreadnought_Heavy_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Missile launcher")
    '    '            ComboBox2.Items.Add("twin Autocannon")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '        Case Is = "Contemptor Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Assault cannon"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Kheres pattern assault cannon")
    '    '        Case Is = "Contemptor Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Seismic Hammer"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Dreadnought combat weapon and Storm bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Storm bolter"
    '    '            Label6.Visible = True
    '    '            Label6.Text = "Meltagun"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Dreadnought Chainfist")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Hurricane bolter")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '            ComboBox4.Visible = True
    '    '            ComboBox4.Items.Add("Heavy flamer")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "two Hunter-killer missiles"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Ironclad Assault Launchers"
    '    '        Case Is = "Terminator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Terminator Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Terminator Assault Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Terminator Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Lightning claws"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm Shield")
    '    '        Case Is = "Cataphractii Terminator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Cataphractii Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power Sword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            ComboBox1.Items.Add("Lightning claw")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Grenade Harness"
    '    '        Case Is = "Tartaros Terminator Squad"
    '    '            'skipped cus'
    '    '        Case Is = "Assault Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Space Marine Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Combat Shield"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Melta Bombs"
    '    '        Case Is = "Inceptor Squad"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Scout Bike Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Scout Biker Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Bike Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Biker Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Attack Bike Squad"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '        Case Is = "Land Speeder Storm"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Assault cannon")
    '    '        Case Is = "Land Speeders"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy bolter")
    '    '            ComboBox2.Items.Add("Typhoon missile launcher")
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Assault cannon")
    '    '        Case Is = "Rhino"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Rhino Primaris"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '        Case Is = "Razorback"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "twin Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("twin Lascannon")
    '    '            ComboBox1.Items.Add("twin Assault cannon")
    '    '            ComboBox1.Items.Add("Lascannon and twin Plasma gun ")
    '    '            ComboBox1.Items.Add("twin Heavy flamer")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Drop Pod"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Deathwind launcher")
    '    '        Case Is = "Stormhawk Interceptor"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Heavy bolters"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Skyhammer missile launcher")
    '    '            ComboBox1.Items.Add("Typhoon  missile launcher")
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Icarus stormcannon"
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Las-talon")
    '    '        Case Is = "Stormtalon Gunship"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Heavy bolters"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Skyhammer missile launcher")
    '    '            ComboBox1.Items.Add("Typhoon  missile launcher")
    '    '            ComboBox1.Items.Add("two Lascannons")
    '    '        Case Is = "Devastator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Space Marine Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Centurion Devastator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Centurion Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Hurricane bolter"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Heavy Bolters"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Centurion missile launcher")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("two Lascannons")
    '    '            ComboBox2.Items.Add("Grav-cannon and grav-amp")
    '    '        Case Is = "Hellblaster Squad"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Thunderfire Cannon"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Predator"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Predator autocannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("twin Lascannon")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("two Lascannons")
    '    '            ComboBox2.Items.Add("two Heavy bolters")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Whirlwind"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Whirlwind vengeance launcher"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Whirlwind castellan launcher")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Vindicator"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Hunter"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Stalker"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Stormraven Gunship"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "twin Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "twin Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("twin Lascannon")
    '    '            ComboBox1.Items.Add("twin Heavy plasma cannon")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("twin Multi-melta")
    '    '            ComboBox2.Items.Add("Typhoon missile launcher")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "two Hurricane bolters"
    '    '        Case Is = "Land Raider"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Land Raider Crusader"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Land Raider Redeemer"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Land Raider Excelsior"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '            CheckBox4.Visible = True
    '    '            CheckBox4.Text = "Combi-plasma"
    '    '        Case Is = "Roboute Guilliman"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Marneus Calgar"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Marneus Calgar in Artificer Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Captain Sicarus"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chief Librarian Tigurius"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chaplain Cassius"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sergeant Telion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '            ''Sergeant Chronus Skipped cus'
    '    '        Case Is = "Tyrannic War Veterans"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Terminus Ultra"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Captain Lysander"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Pedro Kantor"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "High Marshal Helbrecht"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "The Emperor's Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chaplain Grimaldus"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Cenobyte Servitors"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Crusader Squad"
    '    '            figcount = 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            If fourthunit > 0 Then
    '    '                Label2.Visible = True
    '    '                Label2.Text = "Model: Sword Brother"
    '    '                Label3.Visible = True
    '    '                Label3.Text = "Bolt pistol"
    '    '                Label4.Visible = True
    '    '                Label4.Text = "Boltgun"
    '    '                ComboBox1.Visible = True
    '    '                For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                    ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '                Next
    '    '                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                    ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '                Next
    '    '                ComboBox2.Visible = True
    '    '                For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                    ComboBox2.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '                Next
    '    '            Else
    '    '                Label2.Visible = True
    '    '                Label2.Text = "Model: Initiate"
    '    '                Label3.Visible = True
    '    '                Label3.Text = "Boltgun"
    '    '                ComboBox1.Items.Add("Chainsword")
    '    '            End If
    '    '        Case Is = "Kayvann Shrike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Vulkan He'stan"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Kor'sarro Khan", "Kor'sarro Khan"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Damned Legionaires"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Initiate"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Boltgun"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Chainsword")
    '    '            ComboBox1.Items.Add("Power sword")
    '    '            ComboBox1.Items.Add("Power axe")
    '    '            ComboBox1.Items.Add("Power maul")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Plasma pistol")
    '    '            ComboBox2.Items.Add("Storm bolter")
    '    '        Case Is = "Commander Dante"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Captain Tycho", "Tycho the Lost"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Librarian Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Meltagun")
    '    '        Case Is = "Chief Librarian Mephiston"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "The Sanguinor"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Astorath"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sanguinary Priest"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = False
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump pack"
    '    '        Case Is = "Sanguinary Priest on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = False
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Brother Corbulo"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sanguinary Guard Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Angelus boltgun"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Encarmine sword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Inferno pistol")
    '    '            ComboBox1.Items.Add("Plasma pistol")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Encarmine axe")
    '    '            ComboBox2.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Death mask"
    '    '        Case Is = "Terminator Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Lightning claw"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer")
    '    '        Case Is = "Death Company"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Chainsword and Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            ComboBox2.Items.Add("Hand flamer")
    '    '            ComboBox2.Items.Add("Inferno pistol")
    '    '            ComboBox2.Items.Add("Plasma pistol")
    '    '            ComboBox2.Items.Add("Power sword")
    '    '            ComboBox2.Items.Add("Power axe")
    '    '            ComboBox2.Items.Add("Power maul")
    '    '            ComboBox2.Items.Add("Power fist")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Power sword")
    '    '            ComboBox3.Items.Add("Power axe")
    '    '            ComboBox3.Items.Add("Power maul")
    '    '            ComboBox3.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Lemartes"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sanguinary Guard"
    '    '            figcount = 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Angelus boltgun"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Encarmine sword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Inferno pistol")
    '    '            ComboBox1.Items.Add("Plasma pistol")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Encarmine axe")
    '    '            ComboBox2.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Death mask"
    '    '        Case Is = "Death Company Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Furioso fists"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm Bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Meltagun"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Smoke Launchers"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Blood talons")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy flamer")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '            ComboBox4.Visible = True
    '    '            ComboBox4.Items.Add("Magna-grapple")
    '    '        Case Is = "Furioso Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Furioso fists"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm Bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Meltagun"
    '    '            Label6.Visible = True
    '    '            Label6.Text = "Smoke Launchers"
    '    '            Label7.Visible = True
    '    '            Label7.Text = "one Furioso fist and either its Storm bolter or its Meltagun"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Blood talons")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy flamer")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '            ComboBox4.Visible = True
    '    '            ComboBox4.Items.Add("Magna-grapple")
    '    '            ComboBox5.Visible = True
    '    '            ComboBox5.Items.Add("Frag Cannon")
    '    '        Case Is = "Baal Predator"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "twin Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Flamestorm cannon")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("two Heavy flamer")
    '    '            ComboBox2.Items.Add("two Heavy bolters")
    '    '        Case Is = "Gabriel Seth"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Azrael"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Belial"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter and Sword of Silence"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("two Lightning claws")
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm shield")
    '    '        Case Is = "Sammael on Corvex"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sammael in Sableclaw"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Interrogator-Chaplain"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Power fist"
    '    '        Case Is = "Interrogator-Chaplain in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Lightning claw")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            For str As Integer = 0 To SM_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Terminator_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Interrogator-Chaplain on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To SM_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(SM_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(SM_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Power fist"
    '    '        Case Is = "Asmodai"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Ezekiel"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Deathwing Apothecary"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Deathwing Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power fist and Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("two Lightning claws")
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm shield")
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power fist"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '        Case Is = "Deathwing Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Deathwing Terminator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Deathwing Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power sword and Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm shield")
    '    '            ComboBox1.Items.Add("two Lightning claws")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Accompanied by a Watcher in the Dark"
    '    '        Case Is = "Deathwing Knights"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Accompanied by a Watcher in the Dark"
    '    '        Case Is = "Ravenwing Apothecary"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Plasma talon"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Ravenwing Grenade Launcher")
    '    '        Case Is = "Ravenwing Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Plasma talon"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Ravenwing Grenade Launcher")
    '    '        Case Is = "Ravenwing Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Ravenwing Bike Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Ravenwing Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To SM_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To SM_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(SM_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Ravenwing Attack Bike Squad"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '        Case Is = "Ravenwing Land Speeders"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy bolter")
    '    '            ComboBox2.Items.Add("Typhoon missile launcher")
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Assault cannon")
    '    '        Case Else
    '    '            Console.WriteLine(nameofsquad & " is not available atm")
    '    '    End Select




    'End Sub

    'Private Sub Weapons_Selection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    For Each cont As Control In Me.Controls
    '        cont.Visible = False
    '    Next
    '    Btn_NextSquad.Enabled = True
    '    Btn_NextModel.Enabled = False
    '    Label1.Visible = True
    '    nameofsquad = ""
    '    'Console.WriteLine(Team_Setup.playeronearmy.ToString)
    '    Select Case Race_Selection_Form.Playerid
    '        Case Is = 1
    '            str = Team_Setup.playeronearmy
    '        Case Is = 2
    '            str = Team_Setup.playertwoarmy '.Split("~")
    '        Case Is = 3
    '            str = Team_Setup.playerthreearmy '.Split("~")
    '        Case Is = 4
    '            str = Team_Setup.playerfourarmy '.Split("~")
    '        Case Is = 5
    '            str = Team_Setup.playerfivearmy '.Split("~")
    '        Case Is = 6
    '            str = Team_Setup.playersixarmy '.Split("~")
    '        Case Is = 7
    '            str = Team_Setup.playersevenarmy '.Split("~")
    '        Case Is = 8
    '            str = Team_Setup.playereightarmy '.Split("~")
    '    End Select

    '    Dim part() As String = str(line).Split(" ")
    '    For parta As Integer = 0 To part.Count - 1
    '        If IsNumeric(part(parta)) = True Then
    '            If maxnumberoffigs = 0 Then
    '                maxnumberoffigs = part(parta)
    '                Btn_NextSquad.Enabled = False
    '                Btn_NextModel.Enabled = True
    '                figcount = 1
    '            ElseIf thirdunit = 0 Then
    '                thirdunit = part(parta)
    '            ElseIf fourthunit = 0 Then
    '                fourthunit = part(parta)
    '            ElseIf fifthunit = 0 Then
    '                fifthunit = part(parta)
    '            ElseIf sixthunit = 0 Then
    '                sixthunit = part(parta)
    '            End If




    '            'Exit For
    '        Else
    '            Btn_NextSquad.Enabled = True
    '            Btn_NextModel.Enabled = False
    '            If parta <> 0 Then
    '                nameofsquad += " " & part(parta)
    '            Else
    '                nameofsquad += part(parta)
    '            End If
    '            maxnumberoffigs = 0
    '            figcount = 0
    '        End If
    '    Next

    '    line += 1

    '    Btn_NextSquad.Visible = True
    '    Btn_NextModel.Visible = True
    '    Timer1.Enabled = True
    '    Timer1.Start()
    '    Timer1.Interval = 1

    '    '    Select Case nameofsquad
    '    '        Case Is = "Captain"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Chainsword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Master-crafted boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Captain in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power sword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Terminator_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Captain in Cataphractii Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power sword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Combi-bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Captain in Gravis Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This may not alter their wargear options."
    '    '        Case Is = "Captain on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Chain sword"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Master-crafted boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Librarian"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Force stave"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Force axe")
    '    '            ComboBox1.Items.Add("Force sword")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Librarian in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Force stave"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Force axe")
    '    '            ComboBox1.Items.Add("Force sword")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Storm shield")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Librarian on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Force stave"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Force axe")
    '    '            ComboBox1.Items.Add("Force sword")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '        Case Is = "Techmarine"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Servo-arm"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Conversion beamer")
    '    '            ComboBox3.Items.Add("Servo-harness")
    '    '        Case Is = "Servitors"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs = 4
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Servo-arm"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Heavy bolter")
    '    '            ComboBox1.Items.Add("Plasma cannon")
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '        Case Is = "Techmarine on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt Pistol"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Servo-arm"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Conversion beamer")
    '    '            ComboBox3.Items.Add("Servo-harness")
    '    '        Case Is = "Chaplain"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Chaplain in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm Bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Terminator_Combi_Weapons(str))
    '    '            Next
    '    '        Case Is = "Chaplain on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '        Case Is = "Apothecary"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This may not alter their wargear options."
    '    '        Case Is = "Apothecary on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This may not alter their wargear options."
    '    '        Case Is = "Primaris Lieutenants"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Master-crafted auto bolt rifle"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Power sword")
    '    '        Case Is = "Company Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '        Case Is = "Company Ancient on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '        Case Is = "Primaris Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Company Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Company Champion on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Company Veterans"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '        Case Is = "Company Veterans on Bike"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Biker Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Tactical Squad"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Space Marine Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Scout Squad"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Scout Sergeant"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            maxnumberoffigs += 1
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt Pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Camo Cloak"
    '    '        Case Is = "Intercessor Squad"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Imperial Space Marine"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Honour Guard"
    '    '            figcount = 1
    '    '            maxnumberoffigs = 2
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Power sword")
    '    '            ComboBox1.Items.Add("Power lance")
    '    '            ComboBox1.Items.Add("Power maul")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '        Case Is = "Chapter Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chapter Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power axe"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Power sword")
    '    '            ComboBox1.Items.Add("Power lance")
    '    '            ComboBox1.Items.Add("Power maul")
    '    '            ComboBox1.Items.Add("Thunder hammer")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Champion's blade")
    '    '        Case Is = "Centurion Assault Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Centurion Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Flamers"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Centurion assault launcher"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("two Meltaguns")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Hurricane bolter")
    '    '        Case Is = "Sternguard Veteran Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Special issue boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox1.Items.Remove("Thunder hammer")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox2.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '            ComboBox2.Items.Remove("Thunder hammer")
    '    '        Case Is = "Vanguard Veteran Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Veteran Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox1.Items.Add("Storm shield")
    '    '            ComboBox1.Items.Add("Relic blade")
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox2.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Items.Add("Storm shield")
    '    '            ComboBox2.Items.Add("Relic blade")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Melta Bomb"
    '    '        Case Is = "Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Dreadnought combat weapon and Storm bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Dreadnought_Heavy_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Dreadnought_Heavy_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Missile launcher")
    '    '            ComboBox2.Items.Add("twin Autocannon")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '        Case Is = "Venerable Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Dreadnought combat weapon and Storm bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Dreadnought_Heavy_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Dreadnought_Heavy_Weapons(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Missile launcher")
    '    '            ComboBox2.Items.Add("twin Autocannon")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '        Case Is = "Contemptor Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Assault cannon"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Kheres pattern assault cannon")
    '    '        Case Is = "Contemptor Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Seismic Hammer"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Dreadnought combat weapon and Storm bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Storm bolter"
    '    '            Label6.Visible = True
    '    '            Label6.Text = "Meltagun"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Dreadnought Chainfist")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Hurricane bolter")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '            ComboBox4.Visible = True
    '    '            ComboBox4.Items.Add("Heavy flamer")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "two Hunter-killer missiles"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Ironclad Assault Launchers"
    '    '        Case Is = "Terminator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Terminator Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Terminator Assault Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Terminator Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Lightning claws"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm Shield")
    '    '        Case Is = "Cataphractii Terminator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Cataphractii Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power Sword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            ComboBox1.Items.Add("Lightning claw")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Grenade Harness"
    '    '        Case Is = "Tartaros Terminator Squad"
    '    '            'skipped cus'
    '    '        Case Is = "Assault Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Space Marine Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            ComboBox2.Visible = True
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Combat Shield"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox1.Text = "Melta Bombs"
    '    '        Case Is = "Inceptor Squad"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Scout Bike Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Scout Biker Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Bike Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Biker Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Attack Bike Squad"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '        Case Is = "Land Speeder Storm"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Assault cannon")
    '    '        Case Is = "Land Speeders"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy bolter")
    '    '            ComboBox2.Items.Add("Typhoon missile launcher")
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Assault cannon")
    '    '        Case Is = "Rhino"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Rhino Primaris"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '        Case Is = "Razorback"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "twin Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("twin Lascannon")
    '    '            ComboBox1.Items.Add("twin Assault cannon")
    '    '            ComboBox1.Items.Add("Lascannon and twin Plasma gun ")
    '    '            ComboBox1.Items.Add("twin Heavy flamer")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Drop Pod"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Deathwind launcher")
    '    '        Case Is = "Stormhawk Interceptor"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Heavy bolters"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Skyhammer missile launcher")
    '    '            ComboBox1.Items.Add("Typhoon  missile launcher")
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Icarus stormcannon"
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Las-talon")
    '    '        Case Is = "Stormtalon Gunship"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Heavy bolters"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Skyhammer missile launcher")
    '    '            ComboBox1.Items.Add("Typhoon  missile launcher")
    '    '            ComboBox1.Items.Add("two Lascannons")
    '    '        Case Is = "Devastator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Space Marine Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Boltgun"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Centurion Devastator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Centurion Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Hurricane bolter"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Heavy Bolters"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Centurion missile launcher")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("two Lascannons")
    '    '            ComboBox2.Items.Add("Grav-cannon and grav-amp")
    '    '        Case Is = "Hellblaster Squad"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Thunderfire Cannon"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Predator"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Predator autocannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("twin Lascannon")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("two Lascannons")
    '    '            ComboBox2.Items.Add("two Heavy bolters")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Whirlwind"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Whirlwind vengeance launcher"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Whirlwind castellan launcher")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Vindicator"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Hunter"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Stalker"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '        Case Is = "Stormraven Gunship"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "twin Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "twin Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("twin Lascannon")
    '    '            ComboBox1.Items.Add("twin Heavy plasma cannon")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("twin Multi-melta")
    '    '            ComboBox2.Items.Add("Typhoon missile launcher")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "two Hurricane bolters"
    '    '        Case Is = "Land Raider"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Land Raider Crusader"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Land Raider Redeemer"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Land Raider Excelsior"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '            CheckBox4.Visible = True
    '    '            CheckBox4.Text = "Combi-plasma"
    '    '        Case Is = "Roboute Guilliman"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Marneus Calgar"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Marneus Calgar in Artificer Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Captain Sicarus"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chief Librarian Tigurius"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chaplain Cassius"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sergeant Telion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '            ''Sergeant Chronus Skipped cus'
    '    '        Case Is = "Tyrannic War Veterans"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Terminus Ultra"
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Hunter-killer missile"
    '    '            CheckBox2.Visible = True
    '    '            CheckBox2.Text = "Storm bolter"
    '    '            CheckBox3.Visible = True
    '    '            CheckBox3.Text = "Multi-melta"
    '    '        Case Is = "Captain Lysander"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Pedro Kantor"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "High Marshal Helbrecht"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "The Emperor's Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Chaplain Grimaldus"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Cenobyte Servitors"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Crusader Squad"
    '    '            figcount = 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            If fourthunit > 0 Then
    '    '                Label2.Visible = True
    '    '                Label2.Text = "Model: Sword Brother"
    '    '                Label3.Visible = True
    '    '                Label3.Text = "Bolt pistol"
    '    '                Label4.Visible = True
    '    '                Label4.Text = "Boltgun"
    '    '                ComboBox1.Visible = True
    '    '                For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                    ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '                Next
    '    '                For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                    ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '                Next
    '    '                ComboBox2.Visible = True
    '    '                For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                    ComboBox2.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '                Next
    '    '            Else
    '    '                Label2.Visible = True
    '    '                Label2.Text = "Model: Initiate"
    '    '                Label3.Visible = True
    '    '                Label3.Text = "Boltgun"
    '    '                ComboBox1.Items.Add("Chainsword")
    '    '            End If
    '    '        Case Is = "Kayvann Shrike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Vulkan He'stan"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Kor'sarro Khan", "Kor'sarro Khan"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Damned Legionaires"
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Initiate"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Boltgun"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Chainsword")
    '    '            ComboBox1.Items.Add("Power sword")
    '    '            ComboBox1.Items.Add("Power axe")
    '    '            ComboBox1.Items.Add("Power maul")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Plasma pistol")
    '    '            ComboBox2.Items.Add("Storm bolter")
    '    '        Case Is = "Commander Dante"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Captain Tycho", "Tycho the Lost"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Librarian Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Meltagun")
    '    '        Case Is = "Chief Librarian Mephiston"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "The Sanguinor"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Astorath"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sanguinary Priest"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = False
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump pack"
    '    '        Case Is = "Sanguinary Priest on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            Label4.Visible = False
    '    '            Label4.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox2.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Brother Corbulo"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sanguinary Guard Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Angelus boltgun"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Encarmine sword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Inferno pistol")
    '    '            ComboBox1.Items.Add("Plasma pistol")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Encarmine axe")
    '    '            ComboBox2.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Death mask"
    '    '        Case Is = "Terminator Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Lightning claw"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer")
    '    '        Case Is = "Death Company"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Chainsword and Bolt pistol"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Bolt pistol"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Chainsword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Boltgun")
    '    '            ComboBox2.Items.Add("Hand flamer")
    '    '            ComboBox2.Items.Add("Inferno pistol")
    '    '            ComboBox2.Items.Add("Plasma pistol")
    '    '            ComboBox2.Items.Add("Power sword")
    '    '            ComboBox2.Items.Add("Power axe")
    '    '            ComboBox2.Items.Add("Power maul")
    '    '            ComboBox2.Items.Add("Power fist")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Power sword")
    '    '            ComboBox3.Items.Add("Power axe")
    '    '            ComboBox3.Items.Add("Power maul")
    '    '            ComboBox3.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Jump Pack"
    '    '        Case Is = "Lemartes"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sanguinary Guard"
    '    '            figcount = 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Angelus boltgun"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Encarmine sword"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Inferno pistol")
    '    '            ComboBox1.Items.Add("Plasma pistol")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Encarmine axe")
    '    '            ComboBox2.Items.Add("Power fist")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Death mask"
    '    '        Case Is = "Death Company Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Furioso fists"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm Bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Meltagun"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Smoke Launchers"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Blood talons")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy flamer")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '            ComboBox4.Visible = True
    '    '            ComboBox4.Items.Add("Magna-grapple")
    '    '        Case Is = "Furioso Dreadnought"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "two Furioso fists"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Storm Bolter"
    '    '            Label5.Visible = True
    '    '            Label5.Text = "Meltagun"
    '    '            Label6.Visible = True
    '    '            Label6.Text = "Smoke Launchers"
    '    '            Label7.Visible = True
    '    '            Label7.Text = "one Furioso fist and either its Storm bolter or its Meltagun"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Blood talons")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy flamer")
    '    '            ComboBox3.Visible = True
    '    '            ComboBox3.Items.Add("Heavy flamer")
    '    '            ComboBox4.Visible = True
    '    '            ComboBox4.Items.Add("Magna-grapple")
    '    '            ComboBox5.Visible = True
    '    '            ComboBox5.Items.Add("Frag Cannon")
    '    '        Case Is = "Baal Predator"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "twin Assault cannon"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Flamestorm cannon")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("two Heavy flamer")
    '    '            ComboBox2.Items.Add("two Heavy bolters")
    '    '        Case Is = "Gabriel Seth"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Azrael"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Belial"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter and Sword of Silence"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("two Lightning claws")
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm shield")
    '    '        Case Is = "Sammael on Corvex"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Sammael in Sableclaw"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Interrogator-Chaplain"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Power fist"
    '    '        Case Is = "Interrogator-Chaplain in Terminator Armour"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Lightning claw")
    '    '            ComboBox1.Items.Add("Power fist")
    '    '            For str As Integer = 0 To sm_Terminator_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Terminator_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Terminator_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Terminator_Melee_Weapons(str))
    '    '            Next
    '    '        Case Is = "Interrogator-Chaplain on Bike"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Boltgun")
    '    '            For str As Integer = 0 To sm_Pistols.Count - 1
    '    '                ComboBox1.Items.Add(sm_Pistols(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Combi_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Combi_Weapons(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_Melee_Weapons.Count - 1
    '    '                ComboBox1.Items.Add(sm_Melee_Weapons(str))
    '    '            Next
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Power fist"
    '    '        Case Is = "Asmodai"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Ezekiel"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Deathwing Apothecary"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Deathwing Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power fist and Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("two Lightning claws")
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm shield")
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power fist"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Chainfist")
    '    '        Case Is = "Deathwing Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Deathwing Terminator Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Deathwing Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Power sword and Storm bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Thunder hammer and Storm shield")
    '    '            ComboBox1.Items.Add("two Lightning claws")
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Accompanied by a Watcher in the Dark"
    '    '        Case Is = "Deathwing Knights"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '            CheckBox1.Visible = True
    '    '            CheckBox1.Text = "Accompanied by a Watcher in the Dark"
    '    '        Case Is = "Ravenwing Apothecary"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Plasma talon"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Ravenwing Grenade Launcher")
    '    '        Case Is = "Ravenwing Ancient"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Plasma talon"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Ravenwing Grenade Launcher")
    '    '        Case Is = "Ravenwing Champion"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "This unit may not alter their wargear options."
    '    '        Case Is = "Ravenwing Bike Squad"
    '    '            figcount = 1
    '    '            maxnumberoffigs += 1
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            Label2.Visible = True
    '    '            Label2.Text = "Model: Ravenwing Sergeant"
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Bolt pistol"
    '    '            ComboBox1.Visible = True
    '    '            For str As Integer = 0 To sm_one_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_one_Sergeant_Equipment(str))
    '    '            Next
    '    '            For str As Integer = 0 To sm_two_Sergeant_Equipment.Count - 1
    '    '                ComboBox1.Items.Add(sm_two_Sergeant_Equipment(str))
    '    '            Next
    '    '        Case Is = "Ravenwing Attack Bike Squad"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '        Case Is = "Ravenwing Land Speeders"
    '    '            Btn_NextSquad.Enabled = False
    '    '            Btn_NextModel.Enabled = True
    '    '            figcount = 1
    '    '            Label3.Visible = True
    '    '            Label3.Text = "Heavy bolter"
    '    '            Label4.Visible = True
    '    '            Label4.Text = "Additional"
    '    '            ComboBox1.Visible = True
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox2.Visible = True
    '    '            ComboBox2.Items.Add("Heavy bolter")
    '    '            ComboBox2.Items.Add("Typhoon missile launcher")
    '    '            ComboBox1.Items.Add("Multi-melta")
    '    '            ComboBox1.Items.Add("Heavy flamer")
    '    '            ComboBox1.Items.Add("Assault cannon")
    '    '        Case Else
    '    '            Console.WriteLine(nameofsquad & " is not available atm")
    '    '    End Select
    '    If maxnumberoffigs = 0 Then
    '        Label1.Text = "Group Name: " & nameofsquad
    '    Else
    '        Label1.Text = "Group Name: " & nameofsquad & " " & figcount
    '    End If
    '    ComboBox1.Sorted = True
    '    ComboBox2.Sorted = True
    '    ComboBox3.Sorted = True
    '    ComboBox4.Sorted = True
    '    ComboBox5.Sorted = True
    '    Dim i As Integer = 0
    '    Do Until i + 1 >= ComboBox1.Items.Count
    '        If ComboBox1.Items.Item(i) = ComboBox1.Items.Item(i + 1) Then
    '            ComboBox1.Items.RemoveAt(i + 1)
    '        End If
    '        i += 1
    '    Loop
    '    i = 0
    '    Do Until i + 1 >= ComboBox2.Items.Count
    '        If ComboBox2.Items.Item(i) = ComboBox2.Items.Item(i + 1) Then
    '            ComboBox2.Items.RemoveAt(i + 1)
    '        End If
    '        i += 1
    '    Loop
    '    i = 0
    '    Do Until i + 1 >= ComboBox3.Items.Count
    '        If ComboBox3.Items.Item(i) = ComboBox3.Items.Item(i + 1) Then
    '            ComboBox3.Items.RemoveAt(i + 1)
    '        End If
    '        i += 1
    '    Loop
    '    i = 0
    '    Do Until i + 1 >= ComboBox4.Items.Count
    '        If ComboBox4.Items.Item(i) = ComboBox4.Items.Item(i + 1) Then
    '            ComboBox4.Items.RemoveAt(i + 1)
    '        End If
    '        i += 1
    '    Loop
    '    i = 0
    '    Do Until i + 1 >= ComboBox5.Items.Count
    '        If ComboBox5.Items.Item(i) = ComboBox5.Items.Item(i + 1) Then
    '            ComboBox5.Items.RemoveAt(i + 1)
    '        End If
    '        i += 1
    '    Loop
    '    If figcount = 0 Then
    '        Label1.Text = "Group Name: " & nameofsquad
    '    Else
    '        Label1.Text = "Group Name: " & nameofsquad & " " & figcount
    '    End If
    'End Sub

    Private Sub Dark_Eldar_Weapons_Selection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class