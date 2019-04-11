'Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Module Functions
    Public playeroneracetext As String = "Not Playing"
    Public playertworacetext As String = "Not Playing"
    Public playerthreeracetext As String = "Not Playing"
    Public playerfourracetext As String = "Not Playing"
    Public playerfiveracetext As String = "Not Playing"
    Public playersixracetext As String = "Not Playing"
    Public playersevenracetext As String = "Not Playing"
    Public playereightracetext As String = "Not Playing"
    Dim PlanetName As String
    Dim PlanetType As String
    Dim PlanetDescription As String
    Dim NumberofMoonsandDescription As String
    Dim SegmentumName As String
    Dim NumberofOtherPlanetsandDescription As String
    Dim StarType As String
    Dim counter As Integer = 0
    Dim j As Integer = 0
    Public team As Integer = 1
    Dim fromleftcolumncounter As Integer = 1
    Dim fromrightcolumncounter As Integer = 1
    Public ModelsandWeapons As New List(Of ModelsAndWeaponsForTransferingtoMap)
    Public listallModels As New List(Of String)
    Public Groupid As Integer = 1
    ''' <summary>
    ''' Will roll a {number} sided die/dice and returns a random number between 1 and {number}.
    ''' </summary>
    ''' <param name="Maxfaces"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function rolld(ByVal Maxfaces As Integer) '' 
        Randomize()
        Dim random As New Random
        Dim roll As Integer = random.Next(1, Maxfaces)
        'random = Math.Ceiling(Rnd() * number)
        Console.WriteLine("rolled a " & Maxfaces & "-sided dice and got " & roll)
        Return roll
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Unit"></param>
    ''' <param name="Target"></param>
    ''' <param name="Weapon"></param>
    ''' <param name="BallisticSkill"></param>
    ''' <param name="Reroll"></param>
    ''' <param name="Advanced"></param>
    ''' <param name="Moved"></param>
    ''' <param name="AutoHit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Rolltohit(ByVal Unit As String, ByVal Target As String, ByVal Weapon As String, ByVal BallisticSkill As Integer, Optional Reroll As Boolean = False, Optional Advanced As Boolean = False, Optional Moved As Boolean = False, Optional AutoHit As Boolean = False)


        Console.WriteLine(Unit & "'s " & Weapon & " vs " & Target)
        If AutoHit = True Then
            Console.WriteLine("Autohits")
            Return True
        End If
Reroll:
        Map.hitroll = rolld(6)
        'Map.hitroll = 6 '''''''''''''

        Map.hitrollmodifer += WargearandWeaponStats.assault(Advanced)
        Map.hitrollmodifer += WargearandWeaponStats.heavy(Moved)

        If Map.hitroll = 1 Then
            Console.WriteLine("Miss with a roll of: " & Map.hitroll)
            If Reroll = True Then
                Console.WriteLine("Rerolling...")
                Reroll = False
                GoTo Reroll
            End If
            Return False
        Else

            Select Case Map.hitrollmodifer
                Case Is < 0
                    If Map.hitroll + Map.hitrollmodifer < BallisticSkill Then
                        Console.WriteLine("Miss with a roll of: " & Map.hitroll & " and modifier(s) of :" & Map.hitrollmodifer)

                        'noreroll
                        Return False
                        'fail
                    Else 'If hitroll + hitrollmodifiers >= BallisticSkill Then
                        Console.WriteLine("Hit with a roll of: " & Map.hitroll & " and modifier(s) of :" & Map.hitrollmodifer)
                        Return True
                        'pass
                    End If
                Case Is > 0
                    If Map.hitroll + Map.hitrollmodifer < BallisticSkill Then
                        Console.WriteLine("Miss with a roll of: " & Map.hitroll & " and modifier(s) of :" & Map.hitrollmodifer)

                        'reroll
                        If Reroll = True Then
                            Console.WriteLine("Rerolling...")
                            Reroll = False
                            GoTo Reroll
                        End If
                        Return False
                        'fail
                    Else 'If hitroll + hitrollmodifiers >= BallisticSkill Then
                        Console.WriteLine("Hit with a roll of: " & Map.hitroll & " and modifier(s) of :" & Map.hitrollmodifer)
                        Return True
                        'pass
                    End If
                Case Is = 0
                    If Map.hitroll + Map.hitrollmodifer < BallisticSkill Then
                        Console.WriteLine("Miss with a roll of: " & Map.hitroll)

                        'reroll
                        If Reroll = True Then
                            Console.WriteLine("Rerolling...")
                            Reroll = False
                            GoTo Reroll
                        End If
                        Return False
                        'fail
                    Else 'If hitroll + hitrollmodifiers >= BallisticSkill Then
                        Console.WriteLine("Hit with a roll of: " & Map.hitroll)
                        Return True
                        'pass
                    End If
                Case Else
                    Console.WriteLine("Error Found in roll to hit")

                    Return False

            End Select

        End If



    End Function
    Function Rolltowound(ByVal Strength As Integer, ByVal Toughness As Integer)
        Dim strengthvstoughness As Decimal = Strength / Toughness
        Map.woundroll = rolld(6)
        Dim woundneeded As Integer = 2
        Select Case strengthvstoughness
            Case Is > 1
                If strengthvstoughness >= 2 Then
                    woundneeded = 2
                Else
                    woundneeded = 3
                End If

            Case Is = 1
                woundneeded = 4
            Case Is < 1
                If strengthvstoughness <= 0.5 Then
                    woundneeded = 5
                Else
                    woundneeded = 6
                End If
        End Select

        If Map.woundroll >= woundneeded Then
            Console.WriteLine("Wounded with a roll of: " & Map.woundroll)
            Return True
        Else
            Console.WriteLine("No wound with a roll of: " & Map.woundroll)
            Return False

        End If
    End Function
    Function savingthrow(ByVal armourpen As Integer, ByVal save As Integer, ByVal cover As Boolean, Optional invunsave As Integer = 8)
        Dim saveroll As Integer = rolld(6)
        Dim incover As Integer = 0
        If cover = True Then
            incover = 1
        Else
            incover = 0
        End If
        If saveroll >= save + Math.Abs(armourpen) - incover Then
            Console.WriteLine("Saved with a roll of: " & saveroll)

            Return True
        ElseIf saveroll >= invunsave Then
            Console.WriteLine("Saved with a roll of: " & saveroll & " used invunlerable save")

            Return True
        Else
            Console.WriteLine("Not saved with a roll of: " & saveroll)
            'Console.WriteLine("-1 wounds (dies)")
            Return False
        End If

    End Function
    Sub RaceSelectiontoTeamSelection()
        Race_Selection_Form.Timer1.Enabled = False
        Race_Selection_Form.Timer2.Enabled = False
        Race_Selection_Form.Timer1.Stop()
        Race_Selection_Form.Timer2.Stop()
        'from last player to team setup
        If Race_Selection_Form.Playerid = Race_Selection_Form.maxplayers Then
            Race_Selection_Form.Playerid = 1
            Race_Selection_Form.Timer1.Enabled = False
            For Each a As Form In My.Application.OpenForms
                a.Hide()
                a.SendToBack()
            Next
            Team_Setup.Show()
            Team_Setup.BringToFront()
            Select Case Race_Selection_Form.playeronerace
                Case Is = 1
                    playeroneracetext = "Orks"
                Case Is = 2
                    playeroneracetext = "Eldar"
                Case Is = 4
                    playeroneracetext = "Imperial Guard"
                Case Is = 5
                    playeroneracetext = "Tau"
                Case Is = 6
                    playeroneracetext = "Necrons"
                Case Is = 7
                    playeroneracetext = "Dark Eldar"
                Case Is = 8
                    playeroneracetext = "Sisters of Battle"
                Case Is = 9
                    playeroneracetext = "Tyranids"
                Case Is = 10
                    playeroneracetext = "Chaos Daemons"
                Case Is = 11
                    playeroneracetext = "Inquisition"
                Case Is = 12
                    playeroneracetext = "Space Marines"
                Case Is = 0
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"

            End Select
            Select Case Race_Selection_Form.playertworace
                Case Is = 1
                    playertworacetext = "Orks"
                Case Is = 2
                    playertworacetext = "Eldar"
                Case Is = 4
                    playertworacetext = "Imperial Guard"
                Case Is = 5
                    playertworacetext = "Tau"
                Case Is = 6
                    playertworacetext = "Necrons"
                Case Is = 7
                    playertworacetext = "Dark Eldar"
                Case Is = 8
                    playertworacetext = "Sisters of Battle"
                Case Is = 9
                    playertworacetext = "Tyranids"
                Case Is = 10
                    playertworacetext = "Chaos Daemons"
                Case Is = 11
                    playertworacetext = "Inquisition"
                Case Is = 12
                    playertworacetext = "Space Marines"
                Case Is = 0
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
            End Select
            Select Case Race_Selection_Form.playerthreerace
                Case Is = 1
                    playerthreeracetext = "Orks"
                Case Is = 2
                    playerthreeracetext = "Eldar"
                Case Is = 4
                    playerthreeracetext = "Imperial Guard"
                Case Is = 5
                    playerthreeracetext = "Tau"
                Case Is = 6
                    playerthreeracetext = "Necrons"
                Case Is = 7
                    playerthreeracetext = "Dark Eldar"
                Case Is = 8
                    playerthreeracetext = "Sisters of Battle"
                Case Is = 9
                    playerthreeracetext = "Tyranids"
                Case Is = 10
                    playerthreeracetext = "Chaos Daemons"
                Case Is = 11
                    playerthreeracetext = "Inquisition"
                Case Is = 12
                    playerthreeracetext = "Space Marines"
                Case Is = 0
                    playerthreeracetext = "Not Playing"
                Case Else
                    playerthreeracetext = "Not Playing"
            End Select
            Select Case Race_Selection_Form.playerfourrace
                Case Is = 1
                    playerfourracetext = "Orks"
                Case Is = 2
                    playerfourracetext = "Eldar"
                Case Is = 4
                    playerfourracetext = "Imperial Guard"
                Case Is = 5
                    playerfourracetext = "Tau"
                Case Is = 6
                    playerfourracetext = "Necrons"
                Case Is = 7
                    playerfourracetext = "Dark Eldar"
                Case Is = 8
                    playerfourracetext = "Sisters of Battle"
                Case Is = 9
                    playerfourracetext = "Tyranids"
                Case Is = 10
                    playerfourracetext = "Chaos Daemons"
                Case Is = 11
                    playerfourracetext = "Inquisition"
                Case Is = 12
                    playerfourracetext = "Space Marines"
                Case Is = 0
                    playerfourracetext = "Not Playing"
                Case Else
                    playerfourracetext = "Not Playing"
            End Select
            Select Case Race_Selection_Form.playerfiverace
                Case Is = 1
                    playerfiveracetext = "Orks"
                Case Is = 2
                    playerfiveracetext = "Eldar"
                Case Is = 4
                    playerfiveracetext = "Imperial Guard"
                Case Is = 5
                    playerfiveracetext = "Tau"
                Case Is = 6
                    playerfiveracetext = "Necrons"
                Case Is = 7
                    playerfiveracetext = "Dark Eldar"
                Case Is = 8
                    playerfiveracetext = "Sisters of Battle"
                Case Is = 9
                    playerfiveracetext = "Tyranids"
                Case Is = 10
                    playerfiveracetext = "Chaos Daemons"
                Case Is = 11
                    playerfiveracetext = "Inquisition"
                Case Is = 12
                    playerfiveracetext = "Space Marines"
                Case Is = 0
                    playerfiveracetext = "Not Playing"
                Case Else
                    playerfiveracetext = "Not Playing"
            End Select
            Select Case Race_Selection_Form.playersixrace
                Case Is = 1
                    playersixracetext = "Orks"
                Case Is = 2
                    playersixracetext = "Eldar"
                Case Is = 4
                    playersixracetext = "Imperial Guard"
                Case Is = 5
                    playersixracetext = "Tau"
                Case Is = 6
                    playersixracetext = "Necrons"
                Case Is = 7
                    playersixracetext = "Dark Eldar"
                Case Is = 8
                    playersixracetext = "Sisters of Battle"
                Case Is = 9
                    playersixracetext = "Tyranids"
                Case Is = 10
                    playersixracetext = "Chaos Daemons"
                Case Is = 11
                    playersixracetext = "Inquisition"
                Case Is = 12
                    playersixracetext = "Space Marines"
                Case Is = 0
                    playersixracetext = "Not Playing"
                Case Else
                    playersixracetext = "Not Playing"
            End Select
            Select Case Race_Selection_Form.playersevenrace
                Case Is = 1
                    playersevenracetext = "Orks"
                Case Is = 2
                    playersevenracetext = "Eldar"
                Case Is = 4
                    playersevenracetext = "Imperial Guard"
                Case Is = 5
                    playersevenracetext = "Tau"
                Case Is = 6
                    playersevenracetext = "Necrons"
                Case Is = 7
                    playersevenracetext = "Dark Eldar"
                Case Is = 8
                    playersevenracetext = "Sisters of Battle"
                Case Is = 9
                    playersevenracetext = "Tyranids"
                Case Is = 10
                    playersevenracetext = "Chaos Daemons"
                Case Is = 11
                    playersevenracetext = "Inquisition"
                Case Is = 12
                    playersevenracetext = "Space Marines"
                Case Is = 0
                    playersevenracetext = "Not Playing"
                Case Else
                    playersevenracetext = "Not Playing"
            End Select
            Select Case Race_Selection_Form.playereightrace
                Case Is = 1
                    playereightracetext = "Orks"
                Case Is = 2
                    playereightracetext = "Eldar"
                Case Is = 4
                    playereightracetext = "Imperial Guard"
                Case Is = 5
                    playereightracetext = "Tau"
                Case Is = 6
                    playereightracetext = "Necrons"
                Case Is = 7
                    playereightracetext = "Dark Eldar"
                Case Is = 8
                    playereightracetext = "Sisters of Battle"
                Case Is = 9
                    playereightracetext = "Tyranids"
                Case Is = 10
                    playereightracetext = "Chaos Daemons"
                Case Is = 11
                    playereightracetext = "Inquisition"
                Case Is = 12
                    playereightracetext = "Space Marines"
                Case Is = 0
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
            End Select
        Else
            'Chaos_Space_Marine_Chapter_Form.Hide()
            'Chaos_Space_Marine_Chapter_Form.SendToBack()
            'Race_Selection_Form.Show()
            Race_Selection_Form.BringToFront()
            'Space_Marine_Chapter_Form.Hide()
            'Space_Marine_Chapter_Form.SendToBack()
        End If
        Race_Selection_Form.Playerid += 1


    End Sub
    Sub TeamSelectiontoArmySelection()

        ''from team setup to first player race army selection from
        Console.WriteLine("Player One is " & playeroneracetext & " and is in team " & Team_Setup.playeroneteam)
        Console.WriteLine("Player Two is " & playertworacetext & " and is in team " & Team_Setup.playertwoteam)
        Console.WriteLine("Player Three is " & playerthreeracetext & " and is in team " & Team_Setup.playerthreeteam)
        Console.WriteLine("Player Four is " & playerfourracetext & " and is in team " & Team_Setup.playerfourteam)
        Console.WriteLine("Player Five is " & playerfiveracetext & " and is in team " & Team_Setup.playerfiveteam)
        Console.WriteLine("Player Six is " & playersixracetext & " and is in team " & Team_Setup.playersixteam)
        Console.WriteLine("Player Seven is " & playersevenracetext & " and is in team " & Team_Setup.playerseventeam)
        Console.WriteLine("Player Eight is " & playereightracetext & " and is in team " & Team_Setup.playereightteam)
        Race_Selection_Form.Playerid = 1
        For Each a As Form In My.Application.OpenForms
            a.Hide()
            a.SendToBack()
        Next

        Select Case Race_Selection_Form.playeronerace
            Case Is = 1
            Case Is = 2
            Case Is = 3
            Case Is = 4
            Case Is = 5
            Case Is = 6
            Case Is = 7
                Dark_Eldar_Army_Selection.Show()
                Dark_Eldar_Army_Selection.BringToFront()
                Team_Setup.Hide()
                Team_Setup.SendToBack()
            Case Is = 8
            Case Is = 9
            Case Is = 10
            Case Is = 11
            Case Is = 12
                Space_Marine_Army_Selection.Show()
                Space_Marine_Army_Selection.BringToFront()
                Team_Setup.Hide()
                Team_Setup.SendToBack()
        End Select
        ' Race_Selection_Form.Playerid += 1
    End Sub
    Sub WeaponsSelectionToMap()
        listallModels.Clear()
        Select Case Race_Selection_Form.Playerid
            Case Is = 1
                Team_Setup.playeronearmy.AddRange(ModelsandWeapons)
            Case Is = 2
                Team_Setup.playertwoarmy.AddRange(ModelsandWeapons)
            Case Is = 3
                Team_Setup.playerthreearmy.AddRange(ModelsandWeapons)
            Case Is = 4
                Team_Setup.playerfourarmy.AddRange(ModelsandWeapons)
            Case Is = 5
                Team_Setup.playerfivearmy.AddRange(ModelsandWeapons)
            Case Is = 6
                Team_Setup.playersixarmy.AddRange(ModelsandWeapons)
            Case Is = 7
                Team_Setup.playersevenarmy.AddRange(ModelsandWeapons)
            Case Is = 8
                Team_Setup.playereightarmy.AddRange(ModelsandWeapons)
        End Select
        ''from weapons selection to map
        Dim Dark_Eldar_Army_Selection As New Dark_Eldar_Army_Selection
        Dim Dark_Eldar_Weapons_Selection As New Dark_Eldar_Weapons_Selection
        Dim Space_Marine_Army_Selection As New Space_Marine_Army_Selection
        Dim Space_Marines_Weapons_Selection As New Space_Marines_Weapons_Selection
        For model As Integer = 0 To ModelsandWeapons.Count - 1
            Console.WriteLine(ModelsandWeapons(model).GroupID & " " & ModelsandWeapons(model).GroupName & " " & ModelsandWeapons(model).Name)
            For weaponsandabilities As Integer = 0 To ModelsandWeapons(model).WeaponsandAbilities.Count - 1
                Console.WriteLine(" -- " & ModelsandWeapons(model).WeaponsandAbilities(weaponsandabilities))
            Next
        Next
        Race_Selection_Form.Playerid += 1
        ModelsandWeapons.Clear()
        For Each a As Form In My.Application.OpenForms
            a.Hide()
            a.SendToBack()
        Next
        If Race_Selection_Form.Playerid > Race_Selection_Form.maxplayers Then
            Map.Show()
            Map.BringToFront()
            Race_Selection_Form.Playerid = 1
            Exit Sub
        End If
        Select Case Race_Selection_Form.Playerid
            Case Is = 2
                Select Case Race_Selection_Form.playertworace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
            Case Is = 3
                Select Case Race_Selection_Form.playerthreerace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
            Case Is = 4
                Select Case Race_Selection_Form.playerfourrace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
            Case Is = 5
                Select Case Race_Selection_Form.playerfiverace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
            Case Is = 6
                Select Case Race_Selection_Form.playersixrace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
            Case Is = 7
                Select Case Race_Selection_Form.playersevenrace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
            Case Is = 8
                Select Case Race_Selection_Form.playereightrace
                    Case Is = 1
                    Case Is = 2
                    Case Is = 3
                    Case Is = 4
                    Case Is = 5
                    Case Is = 6
                    Case Is = 7
                        Dark_Eldar_Army_Selection.Show()
                        Dark_Eldar_Army_Selection.BringToFront()
                    Case Is = 8
                    Case Is = 9
                    Case Is = 10
                    Case Is = 11
                    Case Is = 12
                        Space_Marine_Army_Selection.Show()
                        Space_Marine_Army_Selection.BringToFront()
                End Select
        End Select


    End Sub
    Function IsBetween(Value As Integer, LowerValue As Integer, UpperValue As Integer) As Boolean
        If Value >= LowerValue And Value <= UpperValue Then
            Return True
        Else
            Return False
        End If

    End Function

    Function CustomMsgbox(ByVal prompt As String, ByVal button1name As String, ByVal button2name As String, Optional button3name As String = Nothing) As Integer
        CustomMessageBox.Label1.Text = prompt
        If button3name <> Nothing Then
            CustomMessageBox.Button1.Text = button1name
            CustomMessageBox.Button2.Text = button2name
            CustomMessageBox.Button3.Text = button3name
        Else
            CustomMessageBox.Button1.Text = button1name
            CustomMessageBox.Button2.Text = button2name
            CustomMessageBox.Button3.Visible = False
        End If
        ' CustomMessageBox.Button2.Text = button1name
        CustomMessageBox.ShowDialog(Map)
        Return CustomMessageBox.buttonid
    End Function


    Function denythewitch(ByVal roll As Integer, Optional numberofdice As Integer = 2)
        Select Case numberofdice
            Case Is = 1
                If rolld(6) > roll Then
                    Return True
                Else
                    Return False
                End If
            Case Is = 2
                If rolld(6) + rolld(6) > roll Then
                    Return True
                Else
                    Return False
                End If
            Case Is = 3
                If rolld(6) + rolld(6) + rolld(6) > roll Then
                    Return True
                Else
                    Return False
                End If
            Case Is = 4
                If rolld(6) + rolld(6) + rolld(6) + rolld(6) > roll Then
                    Return True
                Else
                    Return False
                End If
            Case Else
                ''
                Return False
        End Select



    End Function
    '<Extension()> _
    'Public Sub Add(Of T)(ByRef arr As T(), item As T)
    '    Array.Resize(arr, arr.Length + 1)
    '    arr(arr.Length - 1) = item
    'End Sub
    '<Extension()> _
    'Public Sub RemoveAt(Of T)(ByRef a() As T, ByVal index As Integer)
    '    ' Move elements after "index" down 1 position.
    '    Array.Copy(a, index + 1, a, index, UBound(a) - index)
    '    ' Shorten by 1 element.
    '    ReDim Preserve a(UBound(a) - 1)
    'End Sub
    'Function combinationofnumbers(ByRef input() As Integer, ByVal total As Integer)
    '    Dim output() As Integer = {}
    '    input.Reverse()
    '    total -= input(0)
    '    If total <= 0 Then
    '        output.Add(input.Count)
    '        Return output ''kill on one dice
    '    Else
    '        total -= input(1)
    '        If total = 0 Then
    '            output.Add(input.Count - 1)
    '            Return output
    '        Else

    '            total -= input(2)
    '            If total = 0 Then
    '                output.Add(input.Count - 2)
    '                Return output

    '            End If
    '        End If
    '    End If





    '    Return True
    'End Function

    Function aunitfromallunit(ByVal armyid As Integer, ByVal idofunit As Integer) As String
        'ReDim Weaponslist(0) 'preserve?
        'If line.Contains("@") Then
        '    str2 = line.Split("@")
        '    Unitname = str2(0)
        '    If str2(1).Contains("$") Then 'shows all weapons
        '        Weaponslist = str2(1).Split("$")
        '    Else ''shows only one weapon
        '        Weaponslist(0) = str2(1)
        '    End If
        'Else
        '    str2(0) = line
        '    Unitname = str2(0)
        '    'str.Length = 1
        '    Weaponslist(0) = ""
        'End If
        'Dim units(1, 3) As String
        Dim storage As String = ""
        'Select Case armyid
        '    Case Is = 1
        '        storage = Team_Setup.playeronearmy
        '    Case Is = 2
        '        storage = Team_Setup.playertwoarmy
        '    Case Is = 3
        '        storage = Team_Setup.playerthreearmy
        '    Case Is = 4
        '        storage = Team_Setup.playerfourarmy
        '    Case Is = 5
        '        storage = Team_Setup.playerfivearmy
        '    Case Is = 6
        '        storage = Team_Setup.playersixarmy
        '    Case Is = 7
        '        storage = Team_Setup.playersevenarmy
        '    Case Is = 8
        '        storage = Team_Setup.playereightarmy
        'End Select

        Try
            Dim allunit() As String = storage.Split("~")
            'Dim units(allunit.Length() - 1, 3) As String

            Return allunit(idofunit)




        Catch ex As Exception
            Return Nothing '"error","error"
        End Try
    End Function

    Function groupfromaunit(ByVal armyid As Integer, ByVal idofunit As Integer) As String

        Dim unitgroup() As String = aunitfromallunit(armyid, idofunit).Split(":")
        Return unitgroup(0)
    End Function
    ''narative part
    Sub GeneratePlanetDescription()
        GeneratePlanetName()
        GenerateWorldType()
        GenerateNumberofOtherPlanet()
        GenerateMoons()
        GenerateSegmentumName()
        GenerateStarType()
        Console.WriteLine("The Planet " & PlanetName & " is " & PlanetType & " in a " & NumberofOtherPlanetsandDescription & " located in the " & SegmentumName & ". " & NumberofMoonsandDescription & " orbit this planet and " & PlanetName & " orbits a " & StarType) ''The Planet <name> is <type> in a <Modifier> solar system filled with <numberofplanets>. <Moons> orbit the planet and <name> orbits a <startype>.

        ''Intros taken from Youtube Videos WITHOUT permission using DIYcaptions.com. Text likely to have spelling/grammer mistakes or information about specifc scenarios
        Dim rnd As New Random
        Dim maxnumberofworldtypes As Integer = 12
retryintro:
        Select Case rnd.Next(1, maxnumberofworldtypes)
            Case Is = 1
                If PlanetType = 4 Then
                    Console.WriteLine("This is a place where the mightiest heroes of the Imperium are laid to rest; there are no towns, no villages. It is a green pristine planet full of tombs, full of graves. It is a hallowed place, it is an untouched place. There's some ancient ruins here but apart from that no one walks on the surface of this planet and so it's green and fecundant and ample pickings for any fleet.") '' taken from youtube id: Cu0lY7TukYs @ Winters SEO
                Else
                    GoTo retryintro
                End If
            Case Is = 2
                Console.WriteLine("On this hallowed ground, ancient Imperial tomes tells of a battle between two factions who fought for centries vying for control of this stratgic asset. As this war raged on, only the greatest of warriors were left to fight. To the victor go the spoil, the defeated, eternal pain.")
            Case Is = 3
                Console.WriteLine("Once a Majestic sight to all who truly belived, now a desolate battleground where many guardsman have laid down there life to avert an alien incursion.")
            Case Is = 4
                Console.WriteLine(Chr(34) & "Forward, the Light Brigade!" & vbCrLf & "Charge for the guns!" & Chr(34) & " he said." & vbCrLf & "Into the valley of Death" & vbCrLf & "Rode the six hundred.")
            Case Is = 5
                If PlanetName = "Kidron" Then
                    Console.WriteLine("The Imperial planet of Kidron is located within the heart of the Shalim star system. Great mineral wealth lies within the Mattaniah Mountain range of the Southern continent.  This great wealth has attracted the attention of many alien races.  Evidence exists throughout the Mattaniah Mountains that the region has been occupied at various times by Ork, Tau, Eldar, Necron, and Chaos forces.  While a few pockets of vegetation can be found in the Valley of Achor, which is set at the bed of the Mattaniah Mountains, most of the region is a lifeless wilderness, polluted with poisonous soil.")  'taken from http://soulstorm-maps.com/Rescue%20Mission.htm
                End If
            Case Is = 6
                Console.WriteLine("Life is obviously impossible on this planet and will always be impossible. The conditions are too violent, there are no places life could be created and anything that reaches the planet is destroyed in its violence. A violence that is strangely beautiful, yet eerily frightening.")
            Case Is = 7
                Console.WriteLine("The violent nature of this planet is so devastating it might one day mean the end of the moons and planets around it. Not only is life impossible on this planet or around it, it could very well be the end of any chance of life in this solar system.")
            Case Is = 8
                Console.WriteLine("The conditions on this planet may not be ideal, they're good enough to sustain life. Unfortunately it has yet to do so, but the future of this planet is very promising. If nothing else, it would be perfect as a new home for an advanced species.")
            Case Is = 9
                Console.WriteLine("Surprisingly, life hasn't managed to find its way on this planet. The conditions are perfect however, so all it takes now is time and the right trigger. Once life does find its way here, it would certainly flourish and hopefully give birth to spectacular species.")
            Case Is = 10
                Console.WriteLine("Although extremely violent, this planet holds many resources which could be of the utmost importance to some species. With the right technology, battling the elements on this planet shouldn't be too much of a challenge.")
            Case Is = 11
                Console.WriteLine("It's obvious life on this planet is impossible, but the planet does hold the key to whether or not life will exist on the planets around it. This planet shields some of the other planets from an asteroid field which crosses every few decades. When this happens, small pieces are scattered through this solar system, but the vast majority are caught by this planet. Those pieces that do get scattered are usually not big enough to destroy the other planets, while at the same time potentially holding the right materials or even lifeforms to begin the process of life on those other planets.")
            Case Is = 12
                Console.WriteLine("While life will never be possible on this planet, it does offer a unique sight in the night sky of nearby planets. Its colors and distance to the planets around it occasionally makes the night quite magical on those planets, especially those with an atmosphere.")
                ''submit a description by going to www.ineedhelpsettingthisup.com or go to indiegogo
            Case Else
                GoTo retryintro
        End Select
        Console.WriteLine()
    End Sub
    Sub GenerateWorldType()
        Dim rnd As New Random
        Dim maxnumberofworldtypes As Integer = 4

        Randomize()
        Select Case rnd.Next(1, maxnumberofworldtypes)
            Case Is = 1
                PlanetType = "a Desert World"
            Case Is = 2
                PlanetType = "an Ice World"
            Case Is = 3
                PlanetType = "a Jungle World"
            Case Is = 4
                PlanetType = "an Ocean World with several small islands and continents"
        End Select


    End Sub
    Sub GeneratePlanetName()
        Dim rnd As New Random
        Dim MaxnumberofPlanetNames As Integer = 51

        Randomize()
        Select Case rnd.Next(1, MaxnumberofPlanetNames)
            Case Is = 1
                PlanetName = "Gallifrey"
            Case Is = 2
                PlanetName = "Nagronides"
            Case Is = 3
                PlanetName = "Idaturn"
            Case Is = 4
                PlanetName = "Pundolla"
            Case Is = 5
                PlanetName = "Olneon"
            Case Is = 6
                PlanetName = "Ounus"
            Case Is = 7
                PlanetName = "Natis"
            Case Is = 8
                PlanetName = "Mepavis"
            Case Is = 9
                PlanetName = "Phegiruta"
            Case Is = 10
                PlanetName = "Crora 6E"
            Case Is = 11
                PlanetName = "Drarvis W5"
            Case Is = 12
                PlanetName = "Librabos"
            Case Is = 13
                PlanetName = "Osupra"
            Case Is = 14
                PlanetName = "Revadus"
            Case Is = 15
                PlanetName = "Xizars"
            Case Is = 16
                PlanetName = "Conus"
            Case Is = 17
                PlanetName = "Gninerus"
            Case Is = 18
                PlanetName = "Lluvuclite"
            Case Is = 19
                PlanetName = "Dao DAP"
            Case Is = 20
                PlanetName = "Thilia 9HR1"
            Case Is = 21
                PlanetName = "Balnebos"
            Case Is = 22
                PlanetName = "Nacreunia"
            Case Is = 23
                PlanetName = "Vebiea"
            Case Is = 24
                PlanetName = "Codriea"
            Case Is = 25
                PlanetName = "Yuestea"
            Case Is = 26
                PlanetName = "Nolara"
            Case Is = 27
                PlanetName = "Dremohiri"
            Case Is = 28
                PlanetName = "Grariyama"
            Case Is = 29
                PlanetName = "Certh WNP3"
            Case Is = 30
                PlanetName = "Phiuq LM"
            Case Is = 31
                PlanetName = "Cendipra"
            Case Is = 32
                PlanetName = "Vuzeopra"
            Case Is = 33
                PlanetName = "Pindiea"
            Case Is = 34
                PlanetName = "Almone"
            Case Is = 35
                PlanetName = "Rainerth"
            Case Is = 36
                PlanetName = "Hoanus"
            Case Is = 37
                PlanetName = "Zavonides"
            Case Is = 38
                PlanetName = "Loucury"
            Case Is = 39
                PlanetName = "Brarvis 3Z"
            Case Is = 40
                PlanetName = "Zippe 5W"
            Case Is = 41
                PlanetName = "Thigravis"
            Case Is = 42
                PlanetName = "Cochuacury"
            Case Is = 43
                PlanetName = "Lollion"
            Case Is = 44
                PlanetName = "Itharvis"
            Case Is = 45
                PlanetName = "Lanides"
            Case Is = 46
                PlanetName = "Chaihines"
            Case Is = 47
                PlanetName = "Guberilia"
            Case Is = 48
                PlanetName = "Bicetania"
            Case Is = 49
                PlanetName = "Siea K6T"
            Case Is = 50
                PlanetName = "Gippe 76Z7"
            Case Is = 51
                PlanetName = "Kidron"
        End Select
    End Sub
    Sub GenerateSegmentumName()
        Dim rnd As New Random
        Dim MaxnumberofSegmentums As Integer = 7

        Randomize()
        Select Case rnd.Next(1, MaxnumberofSegmentums)
            Case Is = 1
                SegmentumName = "Ultima Segmentum"
            Case Is = 2
                SegmentumName = "Segmentum Solar"
            Case Is = 3
                SegmentumName = "Segmentum Tempestus"
            Case Is = 4
                SegmentumName = "Segmentum Solar"
            Case Is = 5
                SegmentumName = "Segmentum Pacificus"
            Case Is = 6
                SegmentumName = "Segmentum Obscurus"
            Case Is = 7
                SegmentumName = "Eastern Fringe"

        End Select
    End Sub
    Sub GenerateNumberofOtherPlanet()
        Dim rnd As New Random
        Dim maxnumberofotherplanets As Integer = 34

        Dim modifier As String = ""
        Randomize()
        Select Case rnd.Next(1, 6)
            Case Is = 1
                modifier = "tiny "
            Case Is = 2
                modifier = "small "
            Case Is = 3
                modifier = "thinly populated "
            Case Is = 4
                modifier = "fairly small "
            Case Is = 5
                modifier = "huge "
            Case Is = 6
                modifier = "densly populated "

        End Select


        Select Case rnd.Next(0, maxnumberofotherplanets)
            Case Is = 0
                NumberofOtherPlanetsandDescription = modifier & "solar system"
            Case Is = 1
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with one other planet"
            Case Is = 2
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with two other planets"
            Case Is = 3
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with three other planets"
            Case Is = 4
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with four other planets"
            Case Is = 6
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with six other planets"
            Case Is = 7
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with seven other planets"
            Case Is = 8
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with eight other planets"
            Case Is = 9
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with nine other planets"
            Case Is = 10
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with ten other planets"
            Case Is = 11
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with eleven other planets"
            Case Is = 12
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twelve other planets"
            Case Is = 13
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with thirteen other planets"
            Case Is = 14
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with fourteen other planets"
            Case Is = 15
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with fifteen other planets"
            Case Is = 16
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with sixteen other planets"
            Case Is = 17
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with seventeen other planets"
            Case Is = 18
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with eighteen other planets"
            Case Is = 19
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with nineteen other planets"
            Case Is = 20
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty other planets"
            Case Is = 21
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-one other planets"
            Case Is = 22
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-two other planets"
            Case Is = 23
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-three other planets"
            Case Is = 24
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-four other planets"
            Case Is = 25
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-five other planets"
            Case Is = 26
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-six other planets"
            Case Is = 27
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-seven other planets"
            Case Is = 28
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-eight other planets"
            Case Is = 29
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with twenty-nine other planets"
            Case Is = 30
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with thirty other planets"
            Case Is = 31
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with thirty-one other planets"
            Case Is = 32
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with thirty-two other planets"
            Case Is = 33
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with thirty-three other planets"
            Case Is = 34
                NumberofOtherPlanetsandDescription = modifier & "solar system filled with thirty-four other planets"
        End Select


    End Sub
    Sub GenerateMoons()
        Dim rnd As New Random
        Dim maxnumberofmoons As Integer = 11
        Randomize()

        Select Case rnd.Next(0, maxnumberofmoons)
            Case Is = 0
                NumberofMoonsandDescription = "No moons"
            Case Is = 1
                NumberofMoonsandDescription = "One moon"
            Case Is = 2
                NumberofMoonsandDescription = "Two moons"
            Case Is = 3
                NumberofMoonsandDescription = "Three moons"
            Case Is = 4
                NumberofMoonsandDescription = "Four moons"
            Case Is = 6
                NumberofMoonsandDescription = "Six moons"
            Case Is = 7
                NumberofMoonsandDescription = "Seven moons"
            Case Is = 8
                NumberofMoonsandDescription = "Eight moons"
            Case Is = 9
                NumberofMoonsandDescription = "Nine moons"
            Case Is = 10
                NumberofMoonsandDescription = "Ten moons"
            Case Is = 11
                NumberofMoonsandDescription = "Eleven moons"
        End Select
    End Sub
    Sub GenerateStarType()
        Dim rnd As New Random
        Dim maxnumberofstartypes As Integer = 13
        Randomize()

        Select Case rnd.Next(0, maxnumberofstartypes)
            Case Is = 0
                StarType = "Blue Star"
            Case Is = 1
                StarType = "Yellow Dwarf"
            Case Is = 2
                StarType = "Orange Dwarf"
            Case Is = 3
                StarType = "Red Dwarf"
            Case Is = 4
                StarType = "Blue Giant"
            Case Is = 6
                StarType = "Blue Supergiant"
            Case Is = 7
                StarType = "Red Giant"
            Case Is = 8
                StarType = "Red Supergiant"
            Case Is = 9
                StarType = "Brown Dwarf"
            Case Is = 10
                StarType = "White Dwarf"
            Case Is = 11
                StarType = "Neutron Star"
            Case Is = 12
                StarType = "Black Dwarf"
            Case Is = 13
                StarType = "Black Hole"
        End Select


    End Sub

    Sub AddSceneryToMap(ByVal fromleft As Integer, ByVal fromtop As Integer, ByVal width As Integer, ByVal height As Integer, ByVal IsLOSBlocking As Boolean, ByVal isCover As Boolean, ByVal CoverValue As Integer, ByVal isMovementReducing As Boolean, ByVal MovementValue As Integer) ', ByVal rotation As Integer)

        Dim sceneryobject As New Scenery
        'Console.WriteLine("Left:" & fromleft & "Top:" & fromtop)
        ''placement
        sceneryobject.Left = fromleft
        sceneryobject.Top = fromtop
        sceneryobject.Width = width
        sceneryobject.Height = height

        sceneryobject.isLOSBlocking = IsLOSBlocking
        sceneryobject.isCover = isCover
        sceneryobject.CoverValue = CoverValue
        sceneryobject.isMovementReducing = isMovementReducing
        sceneryobject.MovementValue = MovementValue
        ''implemnt type of scenario ie batlescarred,industrial (buildings and pipes), rural,middleofknowwhere,roads ruins,swamp,rocks,mountains,lakes,defenselines,chaotic/warpstorm
        'Console.WriteLine(System.Text.RegularExpressions.Regex.Replace(IO.Path.GetFullPath(My.Resources.ResourceManager.BaseName), "WindowsApplication1.Resources", "") & "square_rounded_512_brown.png")



        Map.Controls.Add(sceneryobject)

    End Sub
    Sub AddUnitToMap(ByVal ID As Integer, ByVal name As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal visible As Boolean, ByVal ispsyker As Boolean, ByVal M As Integer, ByVal WS As Integer, ByVal BS As Integer, ByVal S As Integer, ByVal T As Integer, ByVal CurrW As Integer, ByVal MaxW As Integer, ByVal MortW As Integer, ByVal A As Integer, ByVal LD As Integer, ByVal Sv As Integer, ByVal weapons As System.Collections.Specialized.StringCollection, ByVal teamid As Integer, Optional CanMove As Boolean = True, Optional CanShoot As Boolean = False, Optional hasmoved As Boolean = True, Optional hasadvanced As Boolean = False, Optional istarget As Boolean = True, Optional isshooting As Boolean = False, Optional isselectedtobetarget As Boolean = True, Optional isselectedtobeshooting As Boolean = False, Optional abilities() As String = Nothing, Optional psykerpowers() As String = Nothing, Optional numberofpsykerpowers As Integer = 0, Optional numberofdenythewitch As Integer = 0, Optional ISv As Integer = 20, Optional factiontags() As String = Nothing, Optional rotation As Integer = 0, Optional exploded As Boolean = False)
        Dim unitaspb As New Model
        unitaspb.Identifier = ID
        unitaspb.NameofModel = name
        unitaspb.Left = x
        unitaspb.Top = y
        unitaspb.Width = width
        unitaspb.Height = height
        unitaspb.Visible = visible
        unitaspb.Psyker = ispsyker
        unitaspb.MoveDistance = M
        unitaspb.WeaponSkill = WS
        unitaspb.BallisticSkill = BS
        unitaspb.Strength = S
        unitaspb.Toughness = T
        unitaspb.CurrentWounds = CurrW
        unitaspb.MaxWounds = MaxW
        unitaspb.MortalWounds = MortW
        unitaspb.Attacks = A
        unitaspb.Leadership = LD
        unitaspb.Save = Sv
        unitaspb.Weapons = weapons
        unitaspb.TeamId = teamid
        unitaspb.CanMove = CanMove
        unitaspb.Canshoot = CanShoot
        unitaspb.hasmoved = hasmoved
        unitaspb.hasadvanced = hasadvanced
        unitaspb.istarget = istarget
        unitaspb.isshooting = isshooting
        unitaspb.isselectedtobetarget = isselectedtobetarget
        unitaspb.isselectedtobeshooting = isselectedtobeshooting
        unitaspb.abilities = abilities
        unitaspb.psykerpowers = psykerpowers
        unitaspb.numberofpsykerpowers = numberofpsykerpowers
        unitaspb.numberofdenythewitch = numberofdenythewitch
        unitaspb.invulnerablesave = ISv
        unitaspb.factiontags = factiontags
        unitaspb.exploded = exploded
        unitaspb.SizeMode = PictureBoxSizeMode.StretchImage

        If teamid = 1 Then
            unitaspb.Image = My.Resources.square_rounded_512_green
        ElseIf teamid = 2 Then
            unitaspb.Image = My.Resources.square_rounded_512_red
        End If
        'unitaspb.rotation=90
        AddHandler unitaspb.MouseHover, AddressOf Map.unitaspb_MouseHover
        AddHandler unitaspb.MouseLeave, AddressOf Map.unitaspb_MouseLeave
        AddHandler unitaspb.MouseUp, AddressOf Map.unitaspb_MouseUp
        AddHandler unitaspb.MouseClick, AddressOf Map.Unit_MouseClick
        Map.Controls.Add(unitaspb)
        Console.WriteLine("Successfully added " & unitaspb.NameofModel & " to the Map")
    End Sub
    Function centrepointininchesx() As Integer
        Return CInt(map.Width / 2) / map.aspectratio
    End Function
    Function centrepointininchesy() As Integer
        Return CInt(map.Height / 2) / map.aspectratio
    End Function
    Function centrepointactualdimensionsx() As Integer
        Return CInt(map.Width / 2)
    End Function
    Function centrepointactualdimensionsy() As Integer
        Return CInt(map.Height / 2)
    End Function

    Function mirror_pointx(ByVal x As Integer) As Integer
        Return CInt(Map.Width - x)
    End Function
    Function mirror_pointy(ByVal y As Integer) As Integer
        Return CInt(Map.Height - y)
    End Function
    Sub Target_selection()
        Map.Coordinates.Clear()
        counter = 0
        For Each targetcont In Map.Controls
            If TypeOf targetcont Is Model Then
                If targetcont.istarget = True And targetcont.visible = True Then

                    If counter = 0 Then ''making sure the target have the same T and S Values
                        Map.toughness = targetcont.toughness
                        Map.save = targetcont.save
                    End If
                    If targetcont.toughness <> Map.toughness Then
                        MsgBox("Please select units with the same toughness characteristic.")
                        Exit Sub
                    End If
                    If targetcont.save <> Map.save Then
                        MsgBox("Please select units with the same save characteristic.")
                        Exit Sub
                    End If
                    Dim ThisPicBoxInfoForUnits As New PicBoxInfo
                    With ThisPicBoxInfoForUnits
                        .Width = targetcont.Width
                        .Height = targetcont.Height
                        .Name = targetcont.Name
                        .Left = targetcont.left
                        .Top = targetcont.top
                        .nameofmodel = targetcont.nameofmodel
                        .Sizemode = targetcont.sizemode
                        .Identifier = targetcont.identifier
                    End With
                    Map.Coordinates.Add(ThisPicBoxInfoForUnits)
                    counter += 1
                    Map.nomoretargets = False
                End If
            End If
        Next
    End Sub
    Function calcdistancebetweentwocentres(ByVal unit1x As Integer, ByVal unit1y As Integer, ByVal unit2x As Integer, ByVal unit2y As Integer) As Double
        Console.WriteLine("Distance between two objects: " & Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / Map.aspectratio)
        Return Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / Map.aspectratio
    End Function
    Function calcdistancebetweentwoobjectedges(ByVal unit1x As Integer, ByVal unit1y As Integer, ByVal unit2x As Integer, ByVal unit2y As Integer, ByVal unit1width As Integer, ByVal unit1height As Integer, ByVal unit2width As Integer, ByVal unit2height As Integer, Optional unit1shape As String = "Round", Optional unit2shape As String = "Round") As Double
        Console.WriteLine("Distance between two objects: " & Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / Map.aspectratio)
        Return Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / Map.aspectratio
    End Function
    Sub WeaponsTable(ByVal WeaponName As String)
        Try
            Select Case WeaponName
                ''SM general weapons
                Case Is = "Assault bolter"
                    Map.AllWargear.Rows.Add("Assault bolter", 18, "Assault", 3, 5, -1, 1)
                Case Is = "Assault cannon"
                    Map.AllWargear.Rows.Add("Assault cannon", 24, "Heavy", 6, 6, -1, 1)
                Case Is = "Astartes grenade launcher"
Astartesgrenadelauncher:
                    Select Case CustomMsgbox("Frag or krak grenade", "Frag Grenade", "Krak Grenade")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Astartes grenade launcher - Frag grenade", 24, "Assault", rolld(6), 3, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Astartes grenade launcher - Krak grenade", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo Astartesgrenadelauncher
                    End Select
                Case Is = "Astartes shotgun"
                    Map.AllWargear.Rows.Add("Astartes shotgun", 12, "Assault", 2, 4, 0, 1)
                Case Is = "Bolt pistol"
                    Map.AllWargear.Rows.Add("Bolt pistol", 12, "Pistol", 1, 4, 0, 1)
                Case Is = "Bolt rifle"
                    Map.AllWargear.Rows.Add("Bolt rifle", 30, "Rapid Fire", 1, 4, -1, 1)
                Case Is = "Boltgun"
                    Map.AllWargear.Rows.Add("Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                Case Is = "Boltstorm gauntlet"
                    Map.AllWargear.Rows.Add("Boltstorm gauntlet (shooting)", 12, "Pistol", 3, 4, 0, 1)
                Case Is = "Centurion missile launcher"
                    Map.AllWargear.Rows.Add("Centurion missile launcher", 36, "Assault", rolld(3), 8, -2, rolld(3))
                Case Is = "Cerberus launcher"
                    Map.AllWargear.Rows.Add("Cerberus launcher", 18, "Heavy", rolld(6), 4, 0, 1)
                Case Is = "Combi-bolter"
                    Map.AllWargear.Rows.Add("Combi-bolter", 24, "Rapid Fire", 2, 4, 0, 1)
                Case Is = "Combi-flamer"
combiflamer:
                    Select Case CustomMsgbox("Boltgun, flamer or both", "Combi-flamer - Boltgun", "Combi-flamer - Flamer", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Combi-flamer - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 8, "Assault", rolld(6), 4, 0, 1)
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo combiflamer
                            'Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo combiflamer
                    End Select
                    'Map.AllWargear.Rows.Add("Combi-flamer - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 8, "Assault", rolld(6), 4, 0, 1)
                Case Is = "Combi-grav"
combigrav:
                    Select Case CustomMsgbox("Boltgun, Grav-gun or both", "Boltgun", "Grav-gun", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Combi-grav - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Combi-grav - Grav-gun", 18, "Rapid Fire", 1, 5, -3, 1)
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo combigrav
                            'Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo combigrav
                    End Select
                    'Map.AllWargear.Rows.Add("Combi-grav - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Combi-grav - Grav-gun", 18, "Rapid Fire", 1, 5, -3, 1)
                Case Is = "Combi-melta"
combimelta:
                    Select Case CustomMsgbox("Boltgun, Meltagun or both", "Boltgun", "Meltagun", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Combi-melta - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Combi-melta - Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo combimelta
                            'Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo combimelta
                    End Select
                    'Map.AllWargear.Rows.Add("Combi-melta - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Combi-melta - Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Combi-plasma"
combiplasma:
                    Select Case CustomMsgbox("Boltgun, Plasma gun or both", "Boltgun", "Plasma gun", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Combi-plasma - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Combi-plasma - Plasma gun", 24, "Rapid Fire", 1, 7, -3, 1)
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo combiplasma
                            'Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo combiplasma
                    End Select
                    'Map.AllWargear.Rows.Add("Combi-plasma - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Combi-plasma - Plasma gun", 24, "Rapid Fire", 1, 7, -3, 1)
                Case Is = "Conversion beamer"
                    Map.AllWargear.Rows.Add("Conversion beamer", 42, "Heavy", rolld(3), 6, 0, 1)
                Case Is = "Cyclone missile launcher"
cyclonemissilelauncher:
                    Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Cyclone missile launcher - Frag missile", 36, "Heavy", rolld(3) + rolld(3), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Cyclone missile launcher - Krak missile", 36, "Heavy", 2, 8, -2, rolld(6))
                        Case Else
                            GoTo cyclonemissilelauncher
                    End Select
                Case Is = "Deathwind launcher"
                    Map.AllWargear.Rows.Add("Deathwind launcher", 12, "Assault", rolld(6), 5, 0, 1)
                Case Is = "Demolisher cannon"
                    Map.AllWargear.Rows.Add("Demolisher cannon", 24, "Heavy", rolld(3), 10, -3, rolld(6))
                Case Is = "Disintergration combi-gun"
disintergrationcombigun:
                    Select Case CustomMsgbox("Boltgun, Disintegration gun or both", "Boltgun", "Disintegration gun", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Disintegration combi-gun - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Disintegration combi-gun - Disintegration gun", 18, "Rapid Fire", 1, 5, -3, rolld(6))
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo disintergrationcombigun
                            'Map.AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo disintergrationcombigun
                    End Select
                    'Map.AllWargear.Rows.Add("Disintegration combi-gun - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Disintegration combi-gun - Disintegration gun", 18, "Rapid Fire", 1, 5, -3, rolld(6))
                Case Is = "Disintegration pistol"
                    Map.AllWargear.Rows.Add("Disintegration pistol", 9, "Pistol", 1, 5, -3, rolld(6))
                Case Is = "Flamer"
                    Map.AllWargear.Rows.Add("Flamer", 8, "Assault", rolld(6), 4, 0, 1)
                Case Is = "Flamestorm cannon"
                    Map.AllWargear.Rows.Add("Flamestorm cannon", 8, "Heavy", rolld(6), 6, -2, 2)
                Case Is = "Frag grenade"
                    Map.AllWargear.Rows.Add("Frag grenade", 6, "Grenade", rolld(6), 3, 0, 1)
                Case Is = "Grav-pistol"
                    Map.AllWargear.Rows.Add("Grav-pistol", 12, "Pistol", 1, 5, -3, 1)
                Case Is = "Grav-cannon and grav-amp"
                    Map.AllWargear.Rows.Add("Grav-cannon and grav-amp", 24, "Heavy", 4, 5, -3, 1)
                Case Is = "Grav-gun"
                    Map.AllWargear.Rows.Add("Grav-gun", 18, "Rapid Fire", 1, 5, -3, 1)
                Case Is = "Grenade harness"
                    Map.AllWargear.Rows.Add("Grenade harness", 12, "Assault", rolld(6), 4, -1, 1)
                Case Is = "Heavy bolter"
                    Map.AllWargear.Rows.Add("Heavy bolter", 36, "Heavy", 3, 5, -1, 1)
                Case Is = "Heavy flamer"
                    Map.AllWargear.Rows.Add("Heavy flamer", 8, "Heavy", rolld(6), 5, -1, 1)
                Case Is = "Heavy plasma cannon"
heavyplasmacannon:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Heavy plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                        Case Else
                            GoTo heavyplasmacannon
                    End Select
                    'Map.AllWargear.Rows.Add("Heavy plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                Case Is = "Hunter-killer missile"
                    Map.AllWargear.Rows.Add("Hunter-killer missile", 48, "Heavy", 1, 8, -2, rolld(6))
                Case Is = "Hurricane bolter"
                    Map.AllWargear.Rows.Add("Hurricane bolter", 24, "Rapid Fire", 6, 4, 0, 1)
                Case Is = "Icarus stormcannon"
                    Map.AllWargear.Rows.Add("Icarus stormcannon", 48, "Heavy", 3, 7, -1, 2)
                Case Is = "Kheres pattern assault cannon"
                    Map.AllWargear.Rows.Add("Kheres pattern assault cannon", 24, "Heavy", 6, 7, -1, 1)
                Case Is = "Krak grenade"
                    Map.AllWargear.Rows.Add("Krak grenade", 6, "Grenade", 1, 6, -1, rolld(3))
                Case Is = "Las-talon"
                    Map.AllWargear.Rows.Add("Las-talon", 24, "Heavy", 2, 9, -3, rolld(6))
                Case Is = "Lascannon"
                    Map.AllWargear.Rows.Add("Lascannon", 48, "Heavy", 1, 9, -3, rolld(6))
                Case Is = "Master-crafted auto bolt rifle"
                    Map.AllWargear.Rows.Add("Master-crafted auto bolt rifle", 24, "Assault", 2, 4, 0, 2)
                Case Is = "Master-crafted boltgun"
                    Map.AllWargear.Rows.Add("Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                Case Is = "Melta bomb"
                    Map.AllWargear.Rows.Add("Melta bomb", 4, "Grenade", 1, 8, -4, rolld(6))
                Case Is = "Meltagun"
                    Map.AllWargear.Rows.Add("Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Missile launcher"
missilelauncher:
                    Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Missile launcher - Frag missile", 48, "Heavy", rolld(6), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Missile launcher - Krak missile", 48, "Heavy", 1, 8, -2, rolld(6))
                        Case Else
                            GoTo missilelauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Missile launcher - Frag missile", 48, "Heavy", rolld(6), 4, 0, 1)
                    ' Map.AllWargear.Rows.Add("Missile launcher - Krak missile", 48, "Heavy", 1, 8, -2, rolld(6))
                Case Is = "Multi-melta"
                    Map.AllWargear.Rows.Add("Multi-melta", 24, "Heavy", 1, 8, -4, rolld(6))
                Case Is = "Orbital array"
                    Map.AllWargear.Rows.Add("Orbital array", 72, "Heavy", rolld(3), 10, -4, rolld(6))
                Case Is = "Plasma blaster"
plasmablaster:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma blaster - Standard", 18, "Assault", 2, 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma blaster - Supercharge", 18, "Assault", 2, 8, -3, 2)
                        Case Else
                            GoTo plasmablaster
                    End Select
                    'Map.AllWargear.Rows.Add("Plasma blaster - Standard", 18, "Assault", 2, 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Plasma blaster - Supercharge", 18, "Assault", 2, 8, -3, 2)
                Case Is = "Plasma cannon"
plasmacannon:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                        Case Else
                            GoTo plasmacannon
                    End Select
                Case Is = "Plasma cutter"
plasmacutter:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                        Case Else
                            GoTo plasmacutter
                    End Select
                Case Is = "Plasma gun"
plasmagun:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma gun - Standard", 24, "Rapid Fire", 1, 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma gun - Supercharge", 24, "Rapid Fire", 1, 8, -3, 2)
                        Case Else
                            GoTo plasmagun
                    End Select
                Case Is = "Plasma incinerator"
plasmaincinerator:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma incinerator - Standard", 30, "Rapid Fire", 1, 7, -4, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma incinerator - Supercharge", 30, "Rapid Fire", 1, 8, -4, 2)
                        Case Else
                            GoTo plasmaincinerator
                    End Select
                Case Is = "Plasma pistol"
plasmapistol:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma pistol - Standard", 12, "Pistol", 1, 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma pistol - Supercharge", 12, "Pistol", 1, 8, -3, 2)
                        Case Else
                            GoTo plasmapistol
                    End Select
                Case Is = "Predator autocannon"
                    Map.AllWargear.Rows.Add("Predator autocannon", 48, "Heavy", rolld(3) + rolld(3), 7, -1, 3)
                Case Is = "Reaper autocannon"
                    Map.AllWargear.Rows.Add("Reaper autocannon", 36, "Heavy", 4, 7, -1, 1)
                Case Is = "Skyhammer missile launcher"
                    Map.AllWargear.Rows.Add("Skyhammer missile launcher", 60, "Heavy", 3, 7, -1, rolld(3))
                Case Is = "Skyspear missile launcher"
                    Map.AllWargear.Rows.Add("Skyspear missile launcher", 60, "Heavy", 1, 9, -3, rolld(6))
                Case Is = "Sniper rifle"
                    Map.AllWargear.Rows.Add("Sniper rifle", 36, "Heavy", 1, 4, 0, 1)
                Case Is = "Special issue boltgun"
                    Map.AllWargear.Rows.Add("Special issue boltgun", 30, "Rapid Fire", 1, 4, -2, 1)
                Case Is = "Storm bolter"
                    Map.AllWargear.Rows.Add("Storm bolter", 24, "Rapid Fire", 2, 4, 0, 1)
                Case Is = "Stormstrike missile launcher"
                    Map.AllWargear.Rows.Add("Stormstrike missile launcher", 72, "Heavy", 1, 8, -3, 3)
                Case Is = "Thunderfire cannon"
                    Map.AllWargear.Rows.Add("Thunderfire cannon", 60, "Heavy", rolld(3) + rolld(3) + rolld(3) + rolld(3), 5, 0, 1)
                Case Is = "Twin assault cannon"
                    Map.AllWargear.Rows.Add("Twin assault cannon", 24, "Heavy", 12, 6, -1, 6) ' 1)
                Case Is = "Twin autocannon"
                    Map.AllWargear.Rows.Add("Twin autocannon", 48, "Heavy", 4, 7, -1, 2)
                Case Is = "Twin boltgun"
                    Map.AllWargear.Rows.Add("Twin boltgun", 24, "Rapid Fire", 2, 4, 0, 1)
                Case Is = "Twin heavy bolter"
                    Map.AllWargear.Rows.Add("Twin heavy bolter", 36, "Heavy", 6, 5, -1, 1)
                Case Is = "Twin heavy flamer"
                    Map.AllWargear.Rows.Add("Twin heavy flamer", 8, "Heavy", rolld(6) + rolld(6), 5, -1, 1)
                Case Is = "Twin heavy plasma cannon"
twinheavyplasmacannon:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Twin heavy plasma cannon - Standard", 36, "Heavy", rolld(3) + rolld(3), 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Twin heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3) + rolld(3), 8, -3, 2)
                        Case Else
                            GoTo twinheavyplasmacannon
                    End Select
                    'Map.AllWargear.Rows.Add("Twin heavy plasma cannon - Standard", 36, "Heavy", rolld(3) + rolld(3), 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Twin heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3) + rolld(3), 8, -3, 2)
                Case Is = "Twin lascannon"
                    Map.AllWargear.Rows.Add("Twin lascannon", 48, "Heavy", 2, 9, -3, rolld(6))
                Case Is = "Twin multi-melta"
                    Map.AllWargear.Rows.Add("Twin multi-melta", 24, "Heavy", 2, 8, -4, rolld(6))
                Case Is = "Twin plasma gun"
twinplasmagun:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Twin plasma gun - Standard", 24, "Rapid Fire", 2, 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Twin plasma gun - Supercharge", 24, "Rapid Fire", 2, 8, -3, 2)
                        Case Else
                            GoTo twinplasmagun
                    End Select
                    'Map.AllWargear.Rows.Add("Twin plasma gun - Standard", 24, "Rapid Fire", 2, 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Twin plasma gun - Supercharge", 24, "Rapid Fire", 2, 8, -3, 2)
                Case Is = "Typhoon missile launcher"
typhoonmissilelauncher:
                    Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Typhoon missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Typhoon missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                        Case Else
                            GoTo typhoonmissilelauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Typhoon missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Typhoon missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                Case Is = "Volkite charger"
                    Map.AllWargear.Rows.Add("Volkite charger", 15, "Heavy", 2, 5, 0, 2)
                Case Is = "Whirlwind castellan launcher"
                    Map.AllWargear.Rows.Add("Whirlwind castellan launcher", 72, "Heavy", rolld(6) + rolld(6), 6, 0, 1)
                Case Is = "Whirlwind vengeance launcher"
                    Map.AllWargear.Rows.Add("Whirlwind vengeance launcher", 72, "Heavy", rolld(3) + rolld(3), 7, -1, 2)
                Case Is = "Wrist-mounted grenade launcher"
                    Map.AllWargear.Rows.Add("Wrist-mounted grenade launcher", 12, "Assault", rolld(3), 4, -1, 1)
                Case Is = "Gauntlets of Ultramar"
                    Map.AllWargear.Rows.Add("Gauntlets of Ultramar (shooting)", 24, "Rapid Fire", 2, 4, -1, 2)
                Case Is = "Hand of Dominion"
                    Map.AllWargear.Rows.Add("Hand of Dominion (shooting)", 24, "Rapid Fire", 3, 6, -1, 2)
                Case Is = "Infernus"
infernus:
                    Select Case CustomMsgbox("Flamer or Master-crafted boltgun", "Flamer", "Master-crafted boltgun")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Infernus - Flamer", 24, "Assault", rolld(6), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Infernus - Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                        Case Else
                            GoTo infernus
                    End Select
                    'Map.AllWargear.Rows.Add("Infernus - Flamer", 24, "Assault", rolld(6), 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Infernus - Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                Case Is = "Quietus"
                    Map.AllWargear.Rows.Add("Quietus", 36, "Heavy", 2, 4, -1, rolld(3))
                Case Is = "Dorn's arrow"
                    Map.AllWargear.Rows.Add("Dorn's arrow", 24, "Assault", 4, 4, -1, 1)
                Case Is = "Gauntlet of the forge"
                    Map.AllWargear.Rows.Add("Gauntlet of the Forge", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Angelus boltgun"
                    Map.AllWargear.Rows.Add("Angelus boltgun", 12, "Assault", 2, 4, -1, 1)
                Case Is = "Blood Song"
bloodsong:
                    Select Case CustomMsgbox("Master-crafted boltgun or Meltagun", "Master-crafted boltgun", "Meltagun")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Blood Song -  Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Blood Song -  Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Else
                            GoTo bloodsong
                    End Select
                    'Map.AllWargear.Rows.Add("Blood Song -  Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                    'Map.AllWargear.Rows.Add("Blood Song -  Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Frag cannon"
                    Map.AllWargear.Rows.Add("Frag cannon", 8, "Assault", rolld(6) + rolld(6), 6, -1, 1)
                Case Is = "Hand flamer"
                    Map.AllWargear.Rows.Add("Hand flamer", 6, "Pistol", rolld(3), 3, 0, 1)
                Case Is = "Inferno pistol"
                    Map.AllWargear.Rows.Add("Inferno pistol", 6, "Pistol", 1, 8, -4, rolld(6))
                Case Is = "Avenger mega bolter"
                    Map.AllWargear.Rows.Add("Avenger mega bolter", 36, "Heavy", 10, 6, -1, 1)
                Case Is = "Blacksword missile launcher"
                    Map.AllWargear.Rows.Add("Blacksword missile launcher", 36, "Heavy", 1, 7, -3, 2)
                Case Is = "The Deliverer"
                    Map.AllWargear.Rows.Add("The Deliverer", 12, "Pistol", 1, 4, -1, 2)
                Case Is = "Lion's Wrath"
lionswrath:
                    Select Case CustomMsgbox("Master-crafted boltgun, Standard or Supercharge", "Master-crafted boltgun", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma gun - Standard", 24, "Rapid Fire", 1, 7, -3, 1)
                        Case Is = 4
                            Map.AllWargear.Rows.Add("Plasma gun - Supercharge", 24, "Rapid Fire", 1, 8, -3, 2)
                        Case Else
                            GoTo lionswrath
                    End Select
                    'Map.AllWargear.Rows.Add("Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                    'Map.AllWargear.Rows.Add("Plasma gun - Standard", 24, "Rapid Fire", 1, 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Plasma gun - Supercharge", 24, "Rapid Fire", 1, 8, -3, 2)
                Case Is = "Plasma storm battery"
plasmastormbattery:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma storm battery - Standard", 36, "Heavy", rolld(6), 7, -3, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma storm battery - Supercharge", 36, "Heavy", rolld(6), 8, -3, 3)
                        Case Else
                            GoTo plasmastormbattery
                    End Select
                    'Map.AllWargear.Rows.Add("Plasma storm battery - Standard", 36, "Heavy", rolld(6), 7, -3, 2)
                    'Map.AllWargear.Rows.Add("Plasma storm battery - Supercharge", 36, "Heavy", rolld(6), 8, -3, 3)
                Case Is = "Plasma talon"
plasmatalon:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Plasma talon - Standard", 36, "Assault", 2, 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Plasma talon - Supercharge", 36, "Assault", 2, 8, -3, 2)
                        Case Else
                            GoTo plasmatalon
                    End Select
                    Map.AllWargear.Rows.Add("Plasma talon - Standard", 36, "Assault", 2, 7, -3, 1)
                    Map.AllWargear.Rows.Add("Plasma talon - Supercharge", 36, "Assault", 2, 8, -3, 2)
                Case Is = "Ravenwing grenade launcher"
ravenwinggrenadelauncher:
                    Select Case CustomMsgbox("Frag or krak shell", "Frag shell", "Krak shell")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Ravenwing grenade launcher - Frag shell", 36, "Assault", rolld(6), 3, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Ravenwing grenade launcher - Krak shell", 36, "Assault", 2, 6, -1, rolld(3))
                        Case Else
                            GoTo ravenwinggrenadelauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Ravenwing grenade launcher - Frag shell", 36, "Assault", rolld(6), 3, 0, 1)
                    'Map.AllWargear.Rows.Add("Ravenwing grenade launcher - Krak shell", 36, "Assault", 2, 6, -1, rolld(3))
                Case Is = "Redemption missile silo"
redemptionmissilesilo:
                    Select Case CustomMsgbox("Fragstorm or krakstorm missile", "Fragstorm missile", "krakstorm missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Redemption missile silo - Fragstorm missile", 96, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Redemption missile silo - Krakstorm missile", 96, "Heavy", rolld(6), 8, -3, rolld(3))
                        Case Else
                            GoTo redemptionmissilesilo
                    End Select
                    'Map.AllWargear.Rows.Add("Redemption missile silo - Fragstorm missile", 96, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Redemption missile silo - Krakstorm missile", 96, "Heavy", rolld(6), 8, -3, rolld(3))
                Case Is = "Rift cannon"
                    Map.AllWargear.Rows.Add("Rift cannon", 18, "Heavy", rolld(3), 10, -3, 3)
                Case Is = "Twin Icarus lascannon"
                    Map.AllWargear.Rows.Add("Twin Icarus lascannon", 96, "Heavy", rolld(6) + rolld(6), 9, -3, rolld(6))
                Case Is = "Twin storm bolter"
                    Map.AllWargear.Rows.Add("Twin storm bolter", 24, "Rapid Fire", 4, 4, 0, 1)
                Case Is = "Foehammer (shooting)"
                    Map.AllWargear.Rows.Add("Foehammer (shooting)", 12, "Assault", 1, 4, -3, rolld(3)) 'strength x2
                Case Is = "Helfrost cannon"
helfrostcannon:
                    Select Case CustomMsgbox("Dispersed or Focused beam", "Dispersed beam", "Focused beam")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Helfrost cannon - Dispersed beam", 24, "Heavy", rolld(3), 6, -2, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Helfrost cannon - Focused beam", 24, "Heavy", 1, 8, -4, rolld(6))
                        Case Else
                            GoTo helfrostcannon
                    End Select
                    'Map.AllWargear.Rows.Add("Helfrost cannon - Dispersed beam", 24, "Heavy", rolld(3), 6, -2, 1)
                    'Map.AllWargear.Rows.Add("Helfrost cannon - Focused beam", 24, "Heavy", 1, 8, -4, rolld(6))
                Case Is = "Helfrost destructor"
helfrostdestructor:
                    Select Case CustomMsgbox("Dispersed or Focused beam", "Dispersed beam", "Focused beam")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Helfrost destructor - Dispersed beam", 24, "Heavy", rolld(3) + rolld(3) + rolld(3), 6, -2, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Helfrost destructor - Focused beam", 24, "Heavy", 3, 8, -4, rolld(6))
                        Case Else
                            GoTo helfrostdestructor
                    End Select
                    'Map.AllWargear.Rows.Add("Helfrost destructor - Dispersed beam", 24, "Heavy", rolld(3) + rolld(3) + rolld(3), 6, -2, 2)
                    'Map.AllWargear.Rows.Add("Helfrost destructor - Focused beam", 24, "Heavy", 3, 8, -4, rolld(6))
                Case Is = "Helfrost pistol"
                    Map.AllWargear.Rows.Add("Helfrost pistol", 12, "Pistol", 1, 8, -4, rolld(3))
                Case Is = "Nightwing"
                    Map.AllWargear.Rows.Add("Nightwing", 12, "Assault", rolld(6), 3, 0, 1)
                Case Is = "Stormfrag auto-launcher"
                    Map.AllWargear.Rows.Add("Stormfrag auto-launcher", 12, "Assault", rolld(3), 4, 0, 1)
                Case Is = "Blackstar rocket launcher"
blackstarrocketlauncher:
                    Select Case CustomMsgbox("Corvid or Dracos warhead", "Corvid warhead", "Dracos warhead")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Blackstar rocket launcher - Corvid warhead", 30, "Heavy", rolld(6), 6, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Blackstar rocket launcher - Dracos warhead", 30, "Heavy", rolld(6), 4, 0, 1)
                        Case Else
                            GoTo blackstarrocketlauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Blackstar rocket launcher - Corvid warhead", 30, "Heavy", rolld(6), 6, -1, 1)
                    'Map.AllWargear.Rows.Add("Blackstar rocket launcher - Dracos warhead", 30, "Heavy", rolld(6), 4, 0, 1)
                Case Is = "Deathwatch frag cannon"
deathwatchfragcannon:
                    Select Case CustomMsgbox("Frag round or Shell", "Frag round", "Shell")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Deathwatch frag cannon - Frag round", 8, "Assault", rolld(6) + rolld(6), 6, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Deathwatch frag cannon - Shell", 24, "Assault", 2, 6, -1, 1)
                        Case Else
                            GoTo deathwatchfragcannon
                    End Select
                    'Map.AllWargear.Rows.Add("Deathwatch frag cannon - Frag round", 8, "Assault", rolld(6) + rolld(6), 6, -1, 1)
                    'Map.AllWargear.Rows.Add("Deathwatch frag cannon - Shell", 24, "Assault", 2, 6, -1, 1)
                Case Is = "Deathwatch shotgun"
deathwatchshotgun:
                    Select Case CustomMsgbox("Cryptclearer round, Xenopurge slug or Wyrmsbreath shell", "Cryptclearer round", "Xenopurge slug", "Wyrmsbreath shell")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Deathwatch shotgun - Cryptclearer round", 16, "Assault", 2, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Deathwatch shotgun - Xenopurge slug", 16, "Assault", 2, 4, -1, 1)
                        Case Is = 4
                            Map.AllWargear.Rows.Add("Deathwatch shotgun - Wyrmsbreath shell", 7, "Assault", rolld(6), 3, 0, 1)
                        Case Else
                            GoTo deathwatchshotgun
                    End Select
                    'Map.AllWargear.Rows.Add("Deathwatch shotgun - Cryptclearer round", 16, "Assault", 2, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Deathwatch shotgun - Xenopurge slug", 16, "Assault", 2, 4, -1, 1)
                    'Map.AllWargear.Rows.Add("Deathwatch shotgun - Wyrmsbreath shell", 7, "Assault", rolld(6), 3, 0, 1)
                Case Is = "Guardian spear (shooting)"
                    Map.AllWargear.Rows.Add("Guardian spear (shooting)", 24, "Rapid fire", 1, 4, -1, 2)
                Case Is = "Hellfire Extremis"
hellfireextremis:
                    Select Case CustomMsgbox("Hellfire flamer or Boltgun", "Hellfire flamer", "Boltgun")
                        Case Is = 2
                            Console.WriteLine("currently not implented")
                            GoTo hellfireextremis
                            'Map.AllWargear.Rows.Add("Hellfire Extremis - Hellfire flamer", 8, "Assault", rolld(6), *, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Hellfire Extremis - Boltgun", 24, "Rapid fire", 1, 4, 0, 1)
                        Case Else
                            GoTo hellfireextremis
                    End Select
                    ' 'Map.AllWargear.Rows.Add("Hellfire Extremis - Hellfire flamer", 8, "Assault", rolld(6), *, 0, 1)
                    ' Map.AllWargear.Rows.Add("Hellfire Extremis - Boltgun", 24, "Rapid fire", 1, 4, 0, 1)
                Case Is = "Infernus heavy bolter"
infernusheavybolter:
                    Select Case CustomMsgbox("Infernus heavy Bolter or Infernus heavy flamer", "Infernus heavy Bolter", "Infernus heavy flamer")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Infernus heavy bolter - Heavy bolter", 36, "Heavy", 3, 5, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Infernus heavy bolter - Heavy flamer", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo infernusheavybolter
                        Case Else
                            GoTo infernusheavybolter
                    End Select
                    'Map.AllWargear.Rows.Add("Infernus heavy bolter - Heavy bolter", 36, "Heavy", 3, 5, -1, 1)
                    'Map.AllWargear.Rows.Add("Infernus heavy bolter - Heavy flamer", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Stalker pattern boltgun"
                    Map.AllWargear.Rows.Add("Stalker pattern boltgun", 30, "Heavy", 2, 4, 0, 1)
                    'imperium2
                Case Is = "Artillery barrage"
                    Map.AllWargear.Rows.Add("Artillery barrage", 100, "Heavy", rolld(6), 8, -2, rolld(3))
                Case Is = "Autocannon"
                    Map.AllWargear.Rows.Add("Autocannon", 48, "Heavy", 2, 7, -1, 2)
                Case Is = "Bale Eye"
                    Map.AllWargear.Rows.Add("Bale Eye", 6, "Pistol", 1, 3, -2, 1)
                Case Is = "Baneblade cannon"
                    Map.AllWargear.Rows.Add("Baneblade cannon", 72, "Heavy", rolld(6) + rolld(6), 9, -3, 3)
                Case Is = "Battle cannon"
                    Map.AllWargear.Rows.Add("Battle cannon", 72, "Heavy", rolld(6), 8, -2, rolld(3))
                Case Is = "Demolition charge"
                    Map.AllWargear.Rows.Add("Demolition charge", 6, "Grenade", rolld(6), 8, -3, rolld(3))
                Case Is = "Earthshaker cannon"
                    Map.AllWargear.Rows.Add("Earthshaker cannon", 240, "Heavy", rolld(6), 9, -2, rolld(3))
                Case Is = "Eradicator nova cannon"
                    Map.AllWargear.Rows.Add("Eradicator nova cannon", 36, "Heavy", rolld(6), 6, -2, rolld(3))
                Case Is = "Executioner plasma cannon"
executionerplasmacannon:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Executioner plasma cannon - Standard", 36, "Heavy", rolld(6), 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Executioner plasma cannon - Supercharge", 36, "Heavy", rolld(6), 8, -3, 2)
                        Case Else
                            GoTo executionerplasmacannon
                    End Select
                    'Map.AllWargear.Rows.Add("Executioner plasma cannon - Standard", 36, "Heavy", rolld(6), 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Executioner plasma cannon - Supercharge", 36, "Heavy", rolld(6), 8, -3, 2)
                Case Is = "Exterminator autocannon"
                    Map.AllWargear.Rows.Add("Exterminator autocannon", 48, "Heavy", 4, 7, -1, 2)
                Case Is = "Frag bomb"
                    Map.AllWargear.Rows.Add("Frag bomb", 6, "Grenade", rolld(6), 4, 0, 1)
                Case Is = "Grenade launcher"
grenadelauncher:
                    Select Case CustomMsgbox("Frag or krak grenade", "Frag grenade", "Krak grenade")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Grenade launcher - Frag grenade", 24, "Assault", rolld(6), 3, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Grenade launcher - Krak grenade", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Else
                            GoTo grenadelauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Grenade launcher - Frag grenade", 24, "Assault", rolld(6), 3, 0, 1)
                    'Map.AllWargear.Rows.Add("Grenade launcher - Krak grenade", 24, "Assault", 1, 6, -1, rolld(3))
                Case Is = "Grenadier gauntlet"
                    Map.AllWargear.Rows.Add("Grenadier gauntlet", 12, "Assault", rolld(6), 4, 0, 1)
                Case Is = "Heavy stubber"
                    Map.AllWargear.Rows.Add("Heavy stubber", 36, "Heavy", 3, 4, 0, 1)
                Case Is = "Hellhammer cannon"
                    Map.AllWargear.Rows.Add("Hellhammer cannon", 36, "Heavy", rolld(6) + rolld(6), 10, -4, 3)
                Case Is = "Hellstrike missiles"
                    Map.AllWargear.Rows.Add("Hellstrike missiles", 72, "Heavy", 1, 8, -2, rolld(6))
                Case Is = "Hot-shot lasgun"
                    Map.AllWargear.Rows.Add("Hot-shot lasgun", 18, "Rapid Fire", 1, 3, -2, 1)
                Case Is = "Hot-shot laspistol"
                    Map.AllWargear.Rows.Add("Hot-shot laspistol", 6, "Pistol", 1, 3, -2, 1)
                Case Is = "Hot-shot volley gun"
                    Map.AllWargear.Rows.Add("Hot-shot volley gun", 24, "Heavy", 4, 4, -2, 1)
                Case Is = "Hydra quad autocannon"
                    Map.AllWargear.Rows.Add("Hydra quad autocannon", 72, "Heavy", 8, 7, -1, 2)
                Case Is = "Inferno cannon"
                    Map.AllWargear.Rows.Add("Inferno cannon", 16, "Heavy", rolld(6), 6, -1, 2)
                Case Is = "Lasgun"
                    Map.AllWargear.Rows.Add("Lasgun", 24, "Rapid Fire", 1, 3, 0, 1)
                Case Is = "Lasgun array"
                    Map.AllWargear.Rows.Add("Lasgun array", 24, "Rapid Fire", 3, 3, 0, 1)
                Case Is = "Laspistol"
                    Map.AllWargear.Rows.Add("Laspistol", 12, "Pistol", 1, 3, 0, 1)
                Case Is = "Magma cannon"
                    Map.AllWargear.Rows.Add("Magma cannon", 60, "Heavy", rolld(6), 10, -5, rolld(6))
                Case Is = "Melta cannon"
                    Map.AllWargear.Rows.Add("Melta cannon", 24, "Heavy", rolld(3), 8, -4, rolld(6))
                Case Is = "Mortar"
                    Map.AllWargear.Rows.Add("Mortar", 48, "Heavy", rolld(6), 4, 0, 1)
                Case Is = "Multi-laser"
                    Map.AllWargear.Rows.Add("Multi-laser", 36, "Heavy", 3, 6, 0, 1)
                Case Is = "Multiple rocket pod"
                    Map.AllWargear.Rows.Add("Multiple rocket pod", 36, "Heavy", rolld(6), 5, -1, 1)
                Case Is = "Payback"
                    Map.AllWargear.Rows.Add("Payback", 36, "Assault", 3, 5, -2, 1)
                Case Is = "Punisher gatling cannon"
                    Map.AllWargear.Rows.Add("Punisher gatling cannon", 24, "Heavy", 20, 5, 0, 1)
                Case Is = "Quake cannon"
                    Map.AllWargear.Rows.Add("Quake cannon", 140, "Heavy", rolld(6), 14, -4, rolld(6))
                Case Is = "Ripper gun"
                    Map.AllWargear.Rows.Add("Ripper gun", 12, "Assault", 3, 5, 0, 1)
                Case Is = "Shotgun"
                    Map.AllWargear.Rows.Add("Shotgun", 12, "Assault", 2, 3, 0, 1)
                Case Is = "Storm eagle rockets"
                    Map.AllWargear.Rows.Add("Storm eagle rockets", 120, "Heavy", rolld(6) + rolld(6), 10, -2, rolld(3))
                Case Is = "Stormsword siege cannon"
                    Map.AllWargear.Rows.Add("Stormsword siege cannon", 36, "Heavy", rolld(6), 10, -4, rolld(6))
                Case Is = "Taurox battle cannon"
                    Map.AllWargear.Rows.Add("Taurox battle cannon", 48, "Heavy", rolld(6), 7, -1, rolld(3))
                Case Is = "Taurox gatling cannon"
                    Map.AllWargear.Rows.Add("Taurox gatling cannon", 24, "Heavy", 20, 4, 0, 1)
                Case Is = "Taurox missile launcher"
tauroxmissilelauncher:
                    Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Taurox missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Taurox missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                        Case Else
                            GoTo tauroxmissilelauncher
                    End Select
                    ' Map.AllWargear.Rows.Add("Taurox missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Taurox missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                Case Is = "Tremor cannon"
                    Map.AllWargear.Rows.Add("Tremor cannon", 60, "Heavy", rolld(6) + rolld(6), 8, -2, 3)
                Case Is = "Vanquisher battle cannon"
                    Map.AllWargear.Rows.Add("Vanquisher battle cannon", 72, "Heavy", 1, 8, -3, rolld(6))
                Case Is = "Volcano cannon"
                    Map.AllWargear.Rows.Add("Volcano cannon", 120, "Heavy", rolld(6), 16, -5, rolld(6) + rolld(6))
                Case Is = "Vulcan mega-bolter"
                    Map.AllWargear.Rows.Add("Vulcan mega-bolter", 60, "Heavy", 20, 6, -2, 2)
                Case Is = "Wyvern quad stormshard mortar"
                    Map.AllWargear.Rows.Add("Wyvern quad stormshard mortar", 48, "Heavy", rolld(6) + rolld(6) + rolld(6) + rolld(6), 4, 0, 1)
                Case Is = "Aeldari missile launcher"
aeldarimissilelauncher:
                    Select Case CustomMsgbox("Sunburst or Starshot missile", "Sunburst missile", "Starshot missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6), 4, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Aeldari missile launcher - Starshot missile", 48, "Heavy", 1, 8, -2, rolld(6))
                        Case Else
                            GoTo aeldarimissilelauncher
                    End Select
                    ' Map.AllWargear.Rows.Add("Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6), 4, -1, 1)
                    'Map.AllWargear.Rows.Add("Aeldari missile launcher - Starshot missile", 48, "Heavy", 1, 8, -2, rolld(6))
                Case Is = "Avenger shuriken catapult"
                    Map.AllWargear.Rows.Add("Avenger shuriken catapult", 18, "Assault", 2, 4, 0, 1)
                Case Is = "Bright lance"
                    Map.AllWargear.Rows.Add("Bright lance", 36, "Heavy", 1, 8, -4, rolld(6))
                Case Is = "Chainsabres (shooting)"
                    Map.AllWargear.Rows.Add("Chainsabres (shooting)", 12, "Pistol", 2, 4, 0, 1)
                Case Is = "Death spinner"
                    Map.AllWargear.Rows.Add("Death spinner", 12, "Assault", 2, 6, 0, 1)
                Case Is = "Doomweaver"
                    Map.AllWargear.Rows.Add("Doomweaver", 48, "Heavy", rolld(6) + rolld(6), 7, 0, 2)
                Case Is = "Dragon’s breath flamer"
                    Map.AllWargear.Rows.Add("Dragon’s breath flamer", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "D-cannon"
                    Map.AllWargear.Rows.Add("D-cannon", 24, "Heavy", rolld(3), 10, -4, rolld(6))
                Case Is = "D-scythe"
                    Map.AllWargear.Rows.Add("D-scythe", 8, "Assault", rolld(3), 10, -4, 1)
                Case Is = "The Eye of Wrath"
                    Map.AllWargear.Rows.Add("The Eye of Wrath", 3, "Pistol", rolld(6), 6, -2, 1)
                Case Is = "Firepike"
                    Map.AllWargear.Rows.Add("Firepike", 18, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Fusion gun"
                    Map.AllWargear.Rows.Add("Fusion gun", 12, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Fusion pistol"
                    Map.AllWargear.Rows.Add("Fusion pistol", 6, "Pistol", 1, 8, -4, rolld(6))
                Case Is = "Hawk’s talon"
                    Map.AllWargear.Rows.Add("Hawk’s talon", 24, "Assault", 4, 5, 0, 1)
                Case Is = "Heavy D-scythe"
                    Map.AllWargear.Rows.Add("Heavy D-scythe", 16, "Assault", rolld(3), 10, -4, 2)
                Case Is = "Heavy wraithcannon"
                    Map.AllWargear.Rows.Add("Heavy wraithcannon", 36, "Assault", 2, 10, -4, rolld(6))
                Case Is = "Lasblaster"
                    Map.AllWargear.Rows.Add("Lasblaster", 24, "Rapid Fire", 2, 3, 0, 1)
                Case Is = "Laser lance (shooting)"
                    Map.AllWargear.Rows.Add("Laser lance (shooting)", 6, "Assault", 1, 6, -4, 2)
                Case Is = "The Maugetar (shooting)"
themaugetar:
                    Select Case CustomMsgbox("Shrieker or Shuriken", "Shrieker", "Shuriken")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("The Maugetar (shooting) - Shrieker", 36, "Assault", 1, 6, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("The Maugetar (shooting) - Shuriken", 36, "Assault", 4, 6, -1, 1)
                        Case Else
                            GoTo themaugetar
                    End Select
                    Map.AllWargear.Rows.Add("The Maugetar (shooting) - Shrieker", 36, "Assault", 1, 6, -1, 1)
                    'Case Is = "- Shuriken"
                    Map.AllWargear.Rows.Add("The Maugetar (shooting) - Shuriken", 36, "Assault", 4, 6, -1, 1)
                Case Is = "Prism cannon"
prismcannon:
                    Select Case CustomMsgbox("Dispersed, Focused or Lance", "Dispersed", "Focused", "Lance")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Prism cannon - Dispersed", 60, "Heavy", rolld(6), 6, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Prism cannon - Focused", 60, "Heavy", rolld(3), 9, -4, rolld(3))
                        Case Is = 4
                            Map.AllWargear.Rows.Add("Prism cannon - Lance", 60, "Heavy", 1, 12, -5, rolld(6))
                        Case Else
                            GoTo prismcannon
                    End Select
                    'Map.AllWargear.Rows.Add("Prism cannon - Dispersed", 60, "Heavy", rolld(6), 6, -3, 1)
                    'Map.AllWargear.Rows.Add("Prism cannon - Focused", 60, "Heavy", rolld(3), 9, -4, rolld(3))
                    'Map.AllWargear.Rows.Add("Prism cannon - Lance", 60, "Heavy", 1, 12, -5, rolld(6))
                Case Is = "Pulse laser"
                    Map.AllWargear.Rows.Add("Pulse laser", 48, "Heavy", 2, 8, -3, 3)
                Case Is = "Ranger long rifle"
                    Map.AllWargear.Rows.Add("Ranger long rifle", 36, "Heavy", 1, 4, 0, 1)
                Case Is = "Reaper launcher"
reaperlauncher:
                    Select Case CustomMsgbox("Starshot or Starswarm missile", "Starshot missile", "Starswarm missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Reaper launcher - Starshot missile", 48, "Heavy", 1, 8, -2, 3)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Reaper launcher - Starswarm missile", 48, "Heavy", 2, 5, -2, 2)
                        Case Else
                            GoTo reaperlauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Reaper launcher - Starshot missile", 48, "Heavy", 1, 8, -2, 3)
                    'Map.AllWargear.Rows.Add("Reaper launcher - Starswarm missile", 48, "Heavy", 2, 5, -2, 2)
                Case Is = "Scatter laser"
                    Map.AllWargear.Rows.Add("Scatter laser", 36, "Heavy", 4, 6, 0, 1)
                Case Is = "Scorpion’s claw (shooting)"
                    Map.AllWargear.Rows.Add("Scorpion’s claw (shooting)", 12, "Assault", 2, 4, 0, 1)
                Case Is = "Shadow weaver"
                    Map.AllWargear.Rows.Add("Shadow weaver", 48, "Heavy", rolld(6), 6, 0, 1)
                Case Is = "Shuriken cannon"
                    Map.AllWargear.Rows.Add("Shuriken cannon", 24, "Assault", 3, 6, 0, 1)
                Case Is = "Shuriken catapult"
                    Map.AllWargear.Rows.Add("Shuriken catapult", 12, "Assault", 2, 4, 0, 1)
                Case Is = "Shuriken pistol"
                    Map.AllWargear.Rows.Add("Shuriken pistol", 12, "Pistol", 1, 4, 0, 1)
                Case Is = "Singing spear (shooting)"
                    Map.AllWargear.Rows.Add("Singing spear (shooting)", 12, "Assault", 1, 9, 0, rolld(3))
                Case Is = "Spinneret rifle"
                    Map.AllWargear.Rows.Add("Spinneret rifle", 18, "Rapid Fire", 1, 6, -4, 1)
                Case Is = "Star lance (shooting)"
                    Map.AllWargear.Rows.Add("Star lance (shooting)", 6, "Assault", 1, 8, -4, 2)
                Case Is = "Starcannon"
                    Map.AllWargear.Rows.Add("Starcannon", 36, "Heavy", 2, 6, -3, 3)
                Case Is = "Sunburst grenade"
                    Map.AllWargear.Rows.Add("Sunburst grenade", 6, "Grenade", rolld(6), 4, -1, 1)
                Case Is = "Suncannon"
                    Map.AllWargear.Rows.Add("Suncannon", 48, "Heavy", rolld(6) + rolld(6), 6, -3, rolld(3))
                Case Is = "Sunrifle"
                    Map.AllWargear.Rows.Add("Sunrifle", 24, "Assault", 4, 3, -2, 1)
                Case Is = "Tempest launcher"
                    Map.AllWargear.Rows.Add("Tempest launcher", 36, "Heavy", rolld(6) + rolld(6), 4, -2, 1)
                Case Is = "Triskele (shooting)"
                    Map.AllWargear.Rows.Add("Triskele (shooting)", 12, "Assault", 3, 3, -2, 1)
                Case Is = "Twin Aeldari missile launcher"
twinaeldarimissilelauncher:
                    Select Case CustomMsgbox("Sunburst or Starshot missile", "Sunburst missile", "Starshot missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Twin Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6) + rolld(6), 4, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Twin Aeldari missile launcher - Starshot missile", 48, "Heavy", 2, 8, -2, rolld(6))
                        Case Else
                            GoTo twinaeldarimissilelauncher
                    End Select
                    'Map.AllWargear.Rows.Add("Twin Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6) + rolld(6), 4, -1, 1)
                    'Map.AllWargear.Rows.Add("Twin Aeldari missile launcher - Starshot missile", 48, "Heavy", 2, 8, -2, rolld(6))
                Case Is = "Twin bright lance"
                    Map.AllWargear.Rows.Add("Twin bright lance", 36, "Heavy", 2, 8, -4, rolld(6))
                Case Is = "Twin scatter laser"
                    Map.AllWargear.Rows.Add("Twin scatter laser", 36, "Heavy", 8, 6, 0, 1)
                Case Is = "Twin shuriken cannon"
                    Map.AllWargear.Rows.Add("Twin shuriken cannon", 24, "Assault", 6, 6, 0, 1)
                Case Is = "Twin shuriken catapult"
                    Map.AllWargear.Rows.Add("Twin shuriken catapult", 12, "Assault", 4, 4, 0, 1)
                Case Is = "Twin starcannon"
                    Map.AllWargear.Rows.Add("Twin starcannon", 36, "Heavy", 4, 6, -3, 3)
                Case Is = "Vibro cannon"
                    Map.AllWargear.Rows.Add("Vibro cannon", 48, "Heavy", 1, 7, -1, rolld(3))
                Case Is = "Voidbringer"
                    Map.AllWargear.Rows.Add("Voidbringer", 48, "Heavy", 1, 4, -3, rolld(3))
                Case Is = "The Wailing Doom (shooting)"
                    Map.AllWargear.Rows.Add("The Wailing Doom (shooting)", 12, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Wraithcannon"
                    Map.AllWargear.Rows.Add("Wraithcannon", 12, "Assault", 1, 10, -4, rolld(6))
                Case Is = "Baleblast"
                    Map.AllWargear.Rows.Add("Baleblast", 18, "Assault", 2, 4, -1, 1)
                Case Is = "Blast pistol"
                    Map.AllWargear.Rows.Add("Blast pistol", 6, "Pistol", 1, 8, -4, rolld(3))
                Case Is = "Blaster"
                    Map.AllWargear.Rows.Add("Blaster", 18, "Assault", 1, 8, -4, rolld(3))
                Case Is = "Casket of Flensing"
                    Map.AllWargear.Rows.Add("Casket of Flensing", 12, "Assault", rolld(6) + rolld(6), 3, -2, 1)
                Case Is = "Dark lance"
                    Map.AllWargear.Rows.Add("Dark lance", 36, "Heavy", 1, 8, -4, rolld(6))
                Case Is = "Dark scythe"
                    Map.AllWargear.Rows.Add("Dark scythe", 24, "Assault", rolld(3), 8, -4, rolld(3))
                Case Is = "Darklight grenade"
                    Map.AllWargear.Rows.Add("Darklight grenade", 6, "Grenade", rolld(6), 4, -1, 1)
                Case Is = "Disintegrator cannon"
                    Map.AllWargear.Rows.Add("Disintegrator cannon", 36, "Assault", 3, 5, -3, 2)
                Case Is = "Eyeburst"
                    Map.AllWargear.Rows.Add("Eyeburst", 9, "Assault", 4, 4, -2, 1)
                Case Is = "Haywire blaster"
                    Map.AllWargear.Rows.Add("Haywire blaster", 24, "Assault", 1, 4, -1, 1)
                Case Is = "Heat lance"
                    Map.AllWargear.Rows.Add("Heat lance", 18, "Assault", 1, 6, -5, rolld(6))
                Case Is = "Hexrifle"
                    Map.AllWargear.Rows.Add("Hexrifle", 36, "Heavy", 1, 4, -1, 1)
                Case Is = "Phantasm grenade launcher"
                    Map.AllWargear.Rows.Add("Phantasm grenade launcher", 18, "Assault", rolld(3), 1, 0, 1)
                Case Is = "Razorwing missiles"
razorwingmissiles:
                    Select Case CustomMsgbox("Monoscythe or Shatterfield missile", "Monoscythe missile", "Shatterfield missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Razorwing missiles - Monoscythe missile", 48, "Assault", rolld(6), 6, 0, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Razorwing missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                        Case Else
                            GoTo razorwingmissiles
                    End Select
                    'Map.AllWargear.Rows.Add("Razorwing missiles - Monoscythe missile", 48, "Assault", rolld(6), 6, 0, 2)
                    'Map.AllWargear.Rows.Add("Razorwing missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                Case Is = "Shredder"
                    Map.AllWargear.Rows.Add("Shredder", 12, "Assault", rolld(3), 6, 0, 1)
                Case Is = "Spirit syphon"
                    Map.AllWargear.Rows.Add("Spirit syphon", 8, "Assault", rolld(6), 3, -2, 1)
                Case Is = "Spirit vortex"
                    Map.AllWargear.Rows.Add("Spirit vortex", 18, "Assault", rolld(6), 3, -2, 1)
                Case Is = "Stinger pod"
                    Map.AllWargear.Rows.Add("Stinger pod", 24, "Assault", rolld(6) + rolld(6), 5, 0, 1)
                Case Is = "Void lance"
                    Map.AllWargear.Rows.Add("Void lance", 36, "Assault", 1, 9, -4, rolld(6))
                Case Is = "Voidraven missiles"
voidravenmissiles:
                    Select Case CustomMsgbox("Implosion or Shatterfield missile", "Implosion missile", "Shatterfield missile")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Voidraven missiles - Implosion missile", 48, "Assault", rolld(3), 6, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Voidraven missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                        Case Else
                            GoTo voidravenmissiles
                    End Select
                    'Map.AllWargear.Rows.Add("Voidraven missiles - Implosion missile", 48, "Assault", rolld(3), 6, -3, 1)
                    'Map.AllWargear.Rows.Add("Voidraven missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                Case Is = "Haywire cannon"
                    Map.AllWargear.Rows.Add("Haywire cannon", 24, "Heavy", rolld(3), 4, -1, 1)
                Case Is = "Neuro disruptor"
                    Map.AllWargear.Rows.Add("Neuro disruptor", 12, "Pistol", 1, 3, -3, rolld(3))
                Case Is = "Prismatic cannon"
prismaticcannon:
                    Select Case CustomMsgbox("Dispersed, Focused or Lance", "Dispersed", "Focused", "Lance")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Prismatic cannon - Dispersed", 24, "Heavy", rolld(6), 4, -2, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Prismatic cannon - Focused", 24, "Heavy", rolld(3), 6, -3, rolld(3))
                        Case Is = 4
                            Map.AllWargear.Rows.Add("Prismatic cannon - Lance", 24, "Heavy", 1, 8, -4, rolld(6))
                        Case Else
                            GoTo prismaticcannon
                    End Select
                    'Map.AllWargear.Rows.Add("Prismatic cannon - Dispersed", 24, "Heavy", rolld(6), 4, -2, 1)
                    'Map.AllWargear.Rows.Add("Prismatic cannon - Focused", 24, "Heavy", rolld(3), 6, -3, rolld(3))
                    'Map.AllWargear.Rows.Add("Prismatic cannon - Lance", 24, "Heavy", 1, 8, -4, rolld(6))
                Case Is = "Prismatic grenade"
                    Map.AllWargear.Rows.Add("Prismatic grenade", 6, "Grenade", rolld(6), 4, -1, 1)
                Case Is = "Shrieker cannon"
shriekercannon:
                    Select Case CustomMsgbox("Shrieker or Shuriken", "Shrieker", "Shuriken")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Shrieker cannon - Shrieker", 24, "Assault", 1, 6, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Shrieker cannon - Shuriken", 24, "Assault", 3, 6, 0, 1)
                        Case Else
                            GoTo shriekercannon
                    End Select
                    'Map.AllWargear.Rows.Add("Shrieker cannon - Shrieker", 24, "Assault", 1, 6, 0, 1)
                    'Map.AllWargear.Rows.Add("Shrieker cannon - Shuriken", 24, "Assault", 3, 6, 0, 1)
                Case Is = "Star bolas"
                    Map.AllWargear.Rows.Add("Star bolas", 12, "Grenade", rolld(3), 6, -3, 1)
                Case Is = "Death ray"
                    Map.AllWargear.Rows.Add("Death ray", 24, "Heavy", rolld(3), 10, -4, rolld(6))
                Case Is = "Doomsday cannon"
doomsdaycannon:
                    Select Case CustomMsgbox("Low or High power", "Low", "High")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Doomsday cannon - Low power", 24, "Heavy", rolld(3), 8, -2, rolld(3))
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Doomsday cannon - High power", 72, "Heavy", rolld(3), 10, -5, rolld(6))
                        Case Else
                            GoTo doomsdaycannon
                    End Select
                    'Map.AllWargear.Rows.Add("Doomsday cannon - Low power", 24, "Heavy", rolld(3), 8, -2, rolld(3))
                    'Map.AllWargear.Rows.Add("Doomsday cannon - High power", 72, "Heavy", rolld(3), 10, -5, rolld(6))
                Case Is = "Eldritch Lance (shooting)"
                    Map.AllWargear.Rows.Add("Eldritch Lance (shooting)", 36, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Gauntlet of fire"
                    Map.AllWargear.Rows.Add("Gauntlet of fire", 8, "Assault", rolld(6), 4, 0, 1)
                Case Is = "Gauss blaster"
                    Map.AllWargear.Rows.Add("Gauss blaster", 24, "Rapid Fire", 1, 5, -2, 1)
                Case Is = "Gauss cannon"
                    Map.AllWargear.Rows.Add("Gauss cannon", 24, "Heavy", 2, 5, -3, rolld(3))
                Case Is = "Gauss flayer"
                    Map.AllWargear.Rows.Add("Gauss flayer", 24, "Rapid Fire", 1, 4, -1, 1)
                Case Is = "Gauss flayer array"
                    Map.AllWargear.Rows.Add("Gauss flayer array", 24, "Rapid Fire", 5, 4, -1, 1)
                Case Is = "Gauss flux arc"
                    Map.AllWargear.Rows.Add("Gauss flux arc", 24, "Heavy", 3, 5, -2, 1)
                Case Is = "Heat ray"
heatray:
                    Select Case CustomMsgbox("Dispersed or Focused", "Dispersed", "Focused")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Heat ray - Dispersed", 8, "Heavy", rolld(6), 5, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Heat ray - Focused", 24, "Heavy", 2, 8, -4, rolld(6))
                        Case Else
                            GoTo cyclicionblaster
                    End Select
                    ' Map.AllWargear.Rows.Add("Heat ray - Dispersed", 8, "Heavy", rolld(6), 5, -1, 1)
                    'Map.AllWargear.Rows.Add("Heat ray - Focused", 24, "Heavy", 2, 8, -4, rolld(6))
                Case Is = "Heavy gauss cannon"
                    Map.AllWargear.Rows.Add("Heavy gauss cannon", 36, "Heavy", 1, 9, -4, rolld(6))
                Case Is = "Particle beamer"
                    Map.AllWargear.Rows.Add("Particle beamer", 24, "Assault", 3, 6, 0, 1)
                Case Is = "Particle caster"
                    Map.AllWargear.Rows.Add("Particle caster", 12, "Pistol", 1, 6, 0, 1)
                Case Is = "Particle shredder"
                    Map.AllWargear.Rows.Add("Particle shredder", 24, "Heavy", 6, 7, -1, rolld(3))
                Case Is = "Particle whip"
                    Map.AllWargear.Rows.Add("Particle whip", 24, "Heavy", 6, 8, -2, rolld(3))
                Case Is = "Rod of covenant (shooting)"
                    Map.AllWargear.Rows.Add("Rod of covenant (shooting)", 12, "Assault", 1, 5, -3, 1)
                Case Is = "Staff of light (shooting)"
                    Map.AllWargear.Rows.Add("Staff of light (shooting)", 12, "Assault", 3, 5, -2, 1)
                Case Is = "Staff of the Destroyer (shooting)"
                    Map.AllWargear.Rows.Add("Staff of the Destroyer (shooting)", 18, "Assault", 3, 6, -3, 2)
                Case Is = "Synaptic disintegrator"
                    Map.AllWargear.Rows.Add("Synaptic disintegrator", 24, "Rapid Fire", 1, 4, 0, 1)
                Case Is = "Tachyon arrow"
                    Map.AllWargear.Rows.Add("Tachyon arrow", 120, "Assault", 1, 10, -5, rolld(6))
                Case Is = "Tesla cannon"
                    Map.AllWargear.Rows.Add("Tesla cannon", 24, "Assault", 3, 6, 0, 1)
                Case Is = "Tesla carbine"
                    Map.AllWargear.Rows.Add("Tesla carbine", 24, "Assault", 2, 5, 0, 1)
                Case Is = "Tesla destructor"
                    Map.AllWargear.Rows.Add("Tesla destructor", 24, "Assault", 4, 7, 0, 1)
                Case Is = "Tesla sphere"
                    Map.AllWargear.Rows.Add("Tesla sphere", 24, "Assault", 5, 7, 0, 1)
                Case Is = "Transdimensional beamer"
                    Map.AllWargear.Rows.Add("Transdimensional beamer", 12, "Heavy", rolld(3), 4, -3, 1)
                Case Is = "Twin heavy gauss cannon"
                    Map.AllWargear.Rows.Add("Twin heavy gauss cannon", 36, "Heavy", 2, 9, -4, rolld(6))
                Case Is = "Twin tesla destructor"
                    Map.AllWargear.Rows.Add("Twin tesla destructor", 24, "Assault", 8, 7, 0, 1)
                Case Is = "Big shoota"
                    Map.AllWargear.Rows.Add("Big shoota", 36, "Assault", 3, 5, 0, 1)
                Case Is = "Burna (shooting)"
                    Map.AllWargear.Rows.Add("Burna (shooting)", 8, "Assault", rolld(3), 4, 0, 1)
                Case Is = "Dakkagun"
                    Map.AllWargear.Rows.Add("Dakkagun", 18, "Assault", 3, 5, 0, 1)
                Case Is = "Deffgun"
                    Map.AllWargear.Rows.Add("Deffgun", 48, "Heavy", rolld(3), 7, -1, 2)
                Case Is = "Deffkannon"
                    Map.AllWargear.Rows.Add("Deffkannon", 72, "Heavy", rolld(6), 10, -4, rolld(6))
                Case Is = "Deffstorm mega-shoota"
                    Map.AllWargear.Rows.Add("Deffstorm mega-shoota", 36, "Heavy", rolld(6) + rolld(6) + rolld(6), 6, -1, 1)
                Case Is = "Grot blasta"
                    Map.AllWargear.Rows.Add("Grot blasta", 12, "Pistol", 1, 3, 0, 1)
                Case Is = "Grotzooka"
                    Map.AllWargear.Rows.Add("Grotzooka", 18, "Heavy", rolld(3) + rolld(3), 6, 0, 1)
                Case Is = "Kannon"
kannon:
                    Select Case CustomMsgbox("Frag or Shell", "Frag", "Shell")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Kannon - Frag", 36, "Heavy", rolld(6), 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Kannon - Shell", 36, "Heavy", 1, 8, -2, rolld(6))
                        Case Else
                            GoTo kannon
                    End Select
                    'Map.AllWargear.Rows.Add("Kannon - Frag", 36, "Heavy", rolld(6), 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Kannon - Shell", 36, "Heavy", 1, 8, -2, rolld(6))
                Case Is = "Killkannon"
                    Map.AllWargear.Rows.Add("Killkannon", 24, "Heavy", rolld(6), 7, -2, 2)
                Case Is = "Kombi-weapon with rokkit launcha" '- Rokkit launcha"
Kombiweaponwithrokkitlauncha:
                    Select Case CustomMsgbox("Rokkit launcha, Shoota or both", "Rokkit launcha", "Shoota", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Kombi-weapon - Rokkit launcha", 24, "Assault", 1, 8, -2, 3)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Kombi-weapon - Shoota", 18, "Assault", 2, 4, 0, 1)
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo Kombiweaponwithrokkitlauncha
                        Case Else
                            GoTo Kombiweaponwithrokkitlauncha
                    End Select
                    ' Map.AllWargear.Rows.Add("Kombi-weapon - Rokkit launcha", 24, "Assault", 1, 8, -2, 3)
                    ' Case Is = "- Shoota"
                    ' Map.AllWargear.Rows.Add("Kombi-weapon - Shoota", 18, "Assault", 2, 4, 0, 1)
                Case Is = "Kombi-weapon with skorcha"
Kombiweaponwithskorcha:
                    Select Case CustomMsgbox("Rokkit launcha, Shoota or both", "Rokkit launcha", "Shoota", "Both")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Kombi-weapon with skorcha - Shoota", 18, "Assault", 2, 4, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Kombi-weapon with skorcha - Skorcha", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = 4
                            MsgBox("Both has not yet been implemented, please select another")
                            GoTo Kombiweaponwithskorcha
                        Case Else
                            GoTo Kombiweaponwithskorcha
                    End Select
                    'Map.AllWargear.Rows.Add("Kombi-weapon with skorcha - Shoota", 18, "Assault", 2, 4, 0, 1)
                    'Map.AllWargear.Rows.Add("Kombi-weapon with skorcha - Skorcha", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Kopta rokkits"
                    Map.AllWargear.Rows.Add("Kopta rokkits", 24, "Assault", 2, 8, -2, 3)
                Case Is = "Kustom mega-blasta"
                    Map.AllWargear.Rows.Add("Kustom mega-blasta", 24, "Assault", 1, 8, -3, rolld(3))
                Case Is = "Kustom mega-kannon"
                    Map.AllWargear.Rows.Add("Kustom mega-kannon", 36, "Heavy", rolld(6), 8, -3, rolld(3))
                Case Is = "Kustom mega-slugga"
                    Map.AllWargear.Rows.Add("Kustom mega-slugga", 12, "Pistol", 1, 8, -3, rolld(3))
                Case Is = "Kustom shoota"
                    Map.AllWargear.Rows.Add("Kustom shoota", 18, "Assault", 4, 4, 0, 1)
                Case Is = "Lobba"
                    Map.AllWargear.Rows.Add("Lobba", 48, "Heavy", rolld(6), 5, 0, 1)
                Case Is = "Pair of rokkit pistols"
                    Map.AllWargear.Rows.Add("Pair of rokkit pistols", 12, "Pistol", 2, 7, -2, rolld(3))
                Case Is = "Rack of rokkits"
                    Map.AllWargear.Rows.Add("Rack of rokkits", 24, "Assault", 2, 8, -2, 3)
                Case Is = "Da Rippa"
darippa:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Da Rippa - Standard", 24, "Heavy", 3, 7, -3, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Da Rippa - Supercharge", 24, "Heavy", 3, 8, -3, 3)
                        Case Else
                            GoTo darippa
                    End Select
                    ' Map.AllWargear.Rows.Add("Da Rippa - Standard", 24, "Heavy", 3, 7, -3, 2)
                    ' Map.AllWargear.Rows.Add("Da Rippa - Supercharge", 24, "Heavy", 3, 8, -3, 3)
                Case Is = "Rokkit launcha"
                    Map.AllWargear.Rows.Add("Rokkit launcha", 24, "Assault", 1, 8, -2, 3)
                Case Is = "Shokk attack gun"
                    Map.AllWargear.Rows.Add("Shokk attack gun", 60, "Heavy", rolld(6), rolld(6) + rolld(6), -5, rolld(3))
                Case Is = "Shoota"
                    Map.AllWargear.Rows.Add("Shoota", 18, "Assault", 2, 4, 0, 1)
                Case Is = "Skorcha"
                    Map.AllWargear.Rows.Add("Skorcha", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Skorcha missile"
                    Map.AllWargear.Rows.Add("Skorcha missile", 24, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Slugga"
                    Map.AllWargear.Rows.Add("Slugga", 12, "Pistol", 1, 4, 0, 1)
                Case Is = "Snazzgun"
                    Map.AllWargear.Rows.Add("Snazzgun", 24, "Heavy", 3, 5, -2, 1)
                Case Is = "Squig bomb"
                    Map.AllWargear.Rows.Add("Squig bomb", 18, "Assault", 1, 8, -2, rolld(6))
                Case Is = "Stikkbomb"
                    Map.AllWargear.Rows.Add("Stikkbomb", 6, "Grenade", rolld(6), 3, 0, 1)
                Case Is = "Stikkbomb flinga"
                    Map.AllWargear.Rows.Add("Stikkbomb flinga", 12, "Assault", rolld(6) + rolld(6), 3, 0, 1)
                Case Is = "Supa shoota"
                    Map.AllWargear.Rows.Add("Supa shoota", 36, "Assault", 3, 6, -1, 1)
                Case Is = "Supa-gatler"
                    Map.AllWargear.Rows.Add("Supa-gatler", 48, "Heavy", rolld(6) + rolld(6), 7, -2, 1)
                Case Is = "Supa-rokkit"
                    Map.AllWargear.Rows.Add("Supa-rokkit", 100, "Heavy", rolld(3), 8, -2, rolld(6))
                Case Is = "Tankbusta bomb"
                    Map.AllWargear.Rows.Add("Tankbusta bomb", 6, "Grenade", rolld(3), 8, -2, rolld(6))
                Case Is = "Tellyport blasta"
                    Map.AllWargear.Rows.Add("Tellyport blasta", 12, "Assault", rolld(3), 8, -2, 1)
                Case Is = "Tellyport mega-blasta"
                    Map.AllWargear.Rows.Add("Tellyport mega-blasta", 24, "Assault", rolld(3), 8, -2, 1)
                Case Is = "Traktor kannon"
                    Map.AllWargear.Rows.Add("Traktor kannon", 36, "Heavy", 1, 8, -2, rolld(3))
                Case Is = "Twin big shoota"
                    Map.AllWargear.Rows.Add("Twin big shoota", 36, "Assault", 6, 5, 0, 1)
                Case Is = "Wazbom mega-kannon"
                    Map.AllWargear.Rows.Add("Wazbom mega-kannon", 36, "Heavy", rolld(3), 8, -3, rolld(3))
                Case Is = "Zzap gun"
                    Map.AllWargear.Rows.Add("Zzap gun", 36, "Heavy", 1, rolld(6) + rolld(6), -3, 3)
                Case Is = "Airbursting fragmentation projector"
                    Map.AllWargear.Rows.Add("Airbursting fragmentation projector", 18, "Assault", rolld(6), 4, 0, 1)
                Case Is = "Burst cannon"
                    Map.AllWargear.Rows.Add("Burst cannon", 18, "Assault", 4, 5, 0, 1)
                Case Is = "Cluster rocket system"
                    Map.AllWargear.Rows.Add("Cluster rocket system", 48, "Heavy", rolld(6) + rolld(6) + rolld(6) + rolld(6), 5, 0, 1)
                Case Is = "Cyclic ion blaster"
cyclicionblaster:
                    Select Case CustomMsgbox("Standard or Overcharge", "Standard", "Overcharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Cyclic ion blaster - Standard", 18, "Assault", 3, 7, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Cyclic ion blaster - Overcharge", 18, "Assault", rolld(3), 8, -1, rolld(3))
                        Case Else
                            GoTo cyclicionblaster
                    End Select
                    'Map.AllWargear.Rows.Add("Cyclic ion blaster - Standard", 18, "Assault", 3, 7, -1, 1)
                    'Map.AllWargear.Rows.Add("Cyclic ion blaster - Overcharge", 18, "Assault", rolld(3), 8, -1, rolld(3))
                Case Is = "Cyclic ion raker"
cyclicionraker:
                    Select Case CustomMsgbox("Standard or Overcharge", "Standard", "Overcharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Cyclic ion raker - Standard", 24, "Heavy", 6, 7, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Cyclic ion raker - Overcharge", 24, "Heavy", rolld(6), 8, -1, rolld(3))
                        Case Else
                            GoTo cyclicionraker
                    End Select
                    'Map.AllWargear.Rows.Add("Cyclic ion raker - Standard", 24, "Heavy", 6, 7, -1, 1)
                    'Map.AllWargear.Rows.Add("Cyclic ion raker - Overcharge", 24, "Heavy", rolld(6), 8, -1, rolld(3))
                Case Is = "Fusion blaster"
                    Map.AllWargear.Rows.Add("Fusion blaster", 18, "Assault", 1, 8, -4, rolld(6))
                Case Is = "Fusion collider"
                    Map.AllWargear.Rows.Add("Fusion collider", 18, "Heavy", rolld(3), 8, -4, rolld(6))
                Case Is = "Heavy burst cannon"
heavyburstcannon:
                    Select Case CustomMsgbox("Standard or Nova-charge", "Standard", "Nova-charge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Heavy burst cannon - Standard", 36, "Heavy", 8, 6, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Heavy burst cannon - Nova-charge", 36, "Heavy", 12, 6, -2, 1)
                        Case Else
                            GoTo heavyburstcannon
                    End Select
                    'Map.AllWargear.Rows.Add("Heavy burst cannon - Standard", 36, "Heavy", 8, 6, -1, 1)
                    'Map.AllWargear.Rows.Add("Heavy burst cannon - Nova-charge", 36, "Heavy", 12, 6, -2, 1)
                Case Is = "Heavy rail rifle"
                    Map.AllWargear.Rows.Add("Heavy rail rifle", 60, "Heavy", 2, 8, -4, rolld(6))
                Case Is = "High-output burst cannon"
                    Map.AllWargear.Rows.Add("High-output burst cannon", 18, "Assault", 8, 5, 0, 1)
                Case Is = "High-yield missile pod"
                    Map.AllWargear.Rows.Add("High-yield missile pod", 36, "Heavy", 4, 7, -1, rolld(3))
                Case Is = "Ion accelerator"
ionaccelerator:
                    Select Case CustomMsgbox("Standard, Overcharge or Nova-charge", "Standard", "Overcharge", "Nova-charge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Ion accelerator - Standard", 72, "Heavy", 3, 7, -3, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Ion accelerator - Overcharge", 72, "Heavy", rolld(6), 8, -3, rolld(3))
                        Case Is = 4
                            Map.AllWargear.Rows.Add("Ion accelerator - Nova-charge", 72, "Heavy", rolld(6), 9, -3, 3)
                        Case Else
                            GoTo ionaccelerator
                    End Select
                    'Map.AllWargear.Rows.Add("Ion accelerator - Standard", 72, "Heavy", 3, 7, -3, 1)
                    'Map.AllWargear.Rows.Add("Ion accelerator - Overcharge", 72, "Heavy", rolld(6), 8, -3, rolld(3))
                    'Map.AllWargear.Rows.Add("Ion accelerator - Nova-charge", 72, "Heavy", rolld(6), 9, -3, 3)
                Case Is = "Ion cannon"
ioncannon:
                    Select Case CustomMsgbox("Standard or Overcharge", "Standard", "Overcharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Ion cannon - Standard", 60, "Heavy", 3, 7, -2, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Ion cannon - Overcharge", 60, "Heavy", rolld(3), 8, -2, 3)
                        Case Else
                            GoTo ioncannon
                    End Select
                    ' Map.AllWargear.Rows.Add("Ion cannon - Standard", 60, "Heavy", 3, 7, -2, 2)
                    ' Map.AllWargear.Rows.Add("Ion cannon - Overcharge", 60, "Heavy", rolld(3), 8, -2, 3)
                Case Is = "Ion rifle"
ionrifle:
                    Select Case CustomMsgbox("Standard or Overcharge", "standard", "Overcharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Ion rifle - Standard", 30, "Rapid Fire", 1, 7, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Ion rifle - Overcharge", 30, "Heavy", rolld(3), 8, -1, 1)
                        Case Else
                            GoTo ionrifle
                    End Select
                    ' Map.AllWargear.Rows.Add("Ion rifle - Standard", 30, "Rapid Fire", 1, 7, -1, 1)
                    'Map.AllWargear.Rows.Add("Ion rifle - Overcharge", 30, "Heavy", rolld(3), 8, -1, 1)
                Case Is = "Kroot gun"
                    Map.AllWargear.Rows.Add("Kroot gun", 48, "Rapid Fire", 1, 7, -1, rolld(3))
                Case Is = "Kroot rifle (shooting)"
                    Map.AllWargear.Rows.Add("Kroot rifle (shooting)", 24, "Rapid Fire", 1, 4, 0, 1)
                Case Is = "Longshot pulse rifle"
                    Map.AllWargear.Rows.Add("Longshot pulse rifle", 48, "Rapid Fire", 1, 5, 0, 1)
                Case Is = "Missile pod"
                    Map.AllWargear.Rows.Add("Missile pod", 36, "Assault", 2, 7, -1, rolld(3))
                Case Is = "Neutron blaster"
                    Map.AllWargear.Rows.Add("Neutron blaster", 18, "Assault", 2, 5, -2, 1)
                Case Is = "Plasma rifle"
                    Map.AllWargear.Rows.Add("Plasma rifle", 24, "Rapid Fire", 1, 6, -3, 1)
                Case Is = "Pulse blastcannon"
pulseblastcannon:
                    Select Case CustomMsgbox("Close, Medium or Long range", "Close range", "Medium range", "Long range")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Pulse blastcannon - Close range", 10, "Heavy", 2, 14, -4, 6)
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Pulse blastcannon - Medium range", 20, "Heavy", 4, 12, -2, 3)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Pulse blastcannon - Long range", 30, "Heavy", 6, 10, 0, 1)
                        Case Else
                            GoTo pulseblastcannon
                    End Select
                    'Map.AllWargear.Rows.Add("Pulse blastcannon - Close range", 10, "Heavy", 2, 14, -4, 6)
                    'Map.AllWargear.Rows.Add("Pulse blastcannon - Medium range", 20, "Heavy", 4, 12, -2, 3)
                    'Map.AllWargear.Rows.Add("Pulse blastcannon - Long range", 30, "Heavy", 6, 10, 0, 1)
                Case Is = "Pulse blaster"
pulseblaster:
                    Select Case CustomMsgbox("Close, Medium or Long range", "Close range", "Medium range", "Long range")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Pulse blaster - Close range", 5, "Assault", 2, 6, -2, 1)
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Pulse blaster - Medium range", 10, "Assault", 2, 5, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Pulse blaster - Long range", 15, "Assault", 2, 4, 0, 1)
                        Case Else
                            GoTo pulseblaster
                    End Select
                    'Map.AllWargear.Rows.Add("Pulse blaster - Close range", 5, "Assault", 2, 6, -2, 1)
                    'Map.AllWargear.Rows.Add("Pulse blaster - Medium range", 10, "Assault", 2, 5, -1, 1)
                    'Map.AllWargear.Rows.Add("Pulse blaster - Long range", 15, "Assault", 2, 4, 0, 1)
                Case Is = "Pulse carbine"
                    Map.AllWargear.Rows.Add("Pulse carbine", 18, "Assault", 2, 5, 0, 1)
                Case Is = "Pulse driver cannon"
                    Map.AllWargear.Rows.Add("Pulse driver cannon", 72, "Heavy", rolld(3), 10, -3, rolld(6))
                Case Is = "Pulse pistol"
                    Map.AllWargear.Rows.Add("Pulse pistol", 12, "Pistol", 1, 5, 0, 1)
                Case Is = "Pulse rifle"
                    Map.AllWargear.Rows.Add("Pulse rifle", 30, "Rapid Fire", 1, 5, 0, 1)
                Case Is = "Quad ion turret"
quadionturret:
                    Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Quad ion turret - Standard", 30, "Heavy", 4, 7, -1, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Quad ion turret - Overcharge", 30, "Heavy", rolld(6), 8, -1, rolld(3))
                        Case Else
                            GoTo quadionturret
                    End Select
                    Map.AllWargear.Rows.Add("Quad ion turret - Standard", 30, "Heavy", 4, 7, -1, 1)
                    Map.AllWargear.Rows.Add("Quad ion turret - Overcharge", 30, "Heavy", rolld(6), 8, -1, rolld(3))
                Case Is = "Rail rifle"
                    Map.AllWargear.Rows.Add("Rail rifle", 30, "Rapid Fire", 1, 6, -4, rolld(3))
                Case Is = "Railgun"
railgun:
                    Select Case CustomMsgbox("Solid shot or Submunitions", "Solid shot", "Submunitions")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Railgun - Solid shot", 72, "Heavy", 1, 10, -4, rolld(6))
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Railgun - Submunitions", 72, "Heavy", rolld(6), 6, -1, 1)
                        Case Else
                            GoTo railgun
                    End Select
                    'Map.AllWargear.Rows.Add("Railgun - Solid shot", 72, "Heavy", 1, 10, -4, rolld(6))
                    'Map.AllWargear.Rows.Add("Railgun - Submunitions", 72, "Heavy", rolld(6), 6, -1, 1)
                Case Is = "Smart missile system"
                    Map.AllWargear.Rows.Add("Smart missile system", 30, "Heavy", 4, 5, 0, 1)
                Case Is = "Supremacy railgun"
                    Map.AllWargear.Rows.Add("Supremacy railgun", 72, "Heavy", 2, 10, -4, rolld(6))
                Case Is = "Barbed strangler"
                    Map.AllWargear.Rows.Add("Barbed strangler", 36, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Bio-electric pulse"
                    Map.AllWargear.Rows.Add("Bio-electric pulse", 12, "Assault", 6, 5, 0, 1)
                Case Is = "Bio-electric pulse with containment spines"
                    Map.AllWargear.Rows.Add("Bio-electric pulse with containment spines", 12, "Assault", 12, 5, 0, 1)
                Case Is = "Bio-plasma"
                    Map.AllWargear.Rows.Add("Bio-plasma", 12, "Assault", rolld(3), 7, -3, 1)
                Case Is = "Bio-plasmic cannon"
                    Map.AllWargear.Rows.Add("Bio-plasmic cannon", 36, "Heavy", 6, 7, -3, 2)
                Case Is = "Choking spores"
                    Map.AllWargear.Rows.Add("Choking spores", 12, "Assault", rolld(6), 3, 0, rolld(3))
                Case Is = "Deathspitter"
                    Map.AllWargear.Rows.Add("Deathspitter", 18, "Assault", 3, 5, -1, 1)
                Case Is = "Deathspitter with slimer maggots"
                    Map.AllWargear.Rows.Add("Deathspitter with slimer maggots", 18, "Assault", 3, 7, -1, 1)
                Case Is = "Devourer"
                    Map.AllWargear.Rows.Add("Devourer", 18, "Assault", 3, 4, 0, 1)
                Case Is = "Devourer with brainleech worms"
                    Map.AllWargear.Rows.Add("Devourer with brainleech worms", 18, "Assault", 3, 6, 0, 1)
                Case Is = "Drool cannon"
                    Map.AllWargear.Rows.Add("Drool cannon", 8, "Assault", rolld(6), 6, -1, 1)
                Case Is = "Flamespurt"
                    Map.AllWargear.Rows.Add("Flamespurt", 10, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Fleshborer"
                    Map.AllWargear.Rows.Add("Fleshborer", 12, "Assault", 1, 4, 0, 1)
                Case Is = "Fleshborer hive"
                    Map.AllWargear.Rows.Add("Fleshborer hive", 18, "Heavy", 20, 5, 0, 1)
                Case Is = "Grasping tongue"
                    Map.AllWargear.Rows.Add("Grasping tongue", 12, "Assault", 1, 6, -3, rolld(3))
                Case Is = "Heavy venom cannon"
                    Map.AllWargear.Rows.Add("Heavy venom cannon", 36, "Assault", rolld(3), 9, -1, rolld(3))
                Case Is = "Impaler cannon"
                    Map.AllWargear.Rows.Add("Impaler cannon", 36, "Heavy", 2, 8, -2, rolld(3))
                Case Is = "Rupture cannon"
                    Map.AllWargear.Rows.Add("Rupture cannon", 48, "Heavy", 2, 10, -1, 2)
                Case Is = "Shockcannon"
                    Map.AllWargear.Rows.Add("Shockcannon", 24, "Assault", rolld(3), 7, -1, rolld(3))
                Case Is = "Spike rifle"
                    Map.AllWargear.Rows.Add("Spike rifle", 18, "Assault", 1, 3, 0, 1)
                Case Is = "Spinemaws"
                    Map.AllWargear.Rows.Add("Spinemaws", 6, "Pistol", 4, 2, 0, 1)
                Case Is = "Stinger salvo"
                    Map.AllWargear.Rows.Add("Stinger salvo", 18, "Assault", 4, 5, -1, 1)
                Case Is = "Stranglethorn cannon"
                    Map.AllWargear.Rows.Add("Stranglethorn cannon", 36, "Assault", rolld(6), 7, -1, 2)
                Case Is = "Strangleweb"
                    Map.AllWargear.Rows.Add("Strangleweb", 8, "Assault", rolld(3), 2, 0, 1)
                Case Is = "Tentaclids"
                    Map.AllWargear.Rows.Add("Tentaclids", 36, "Assault", 2, 5, 0, 1)
                Case Is = "Venom cannon"
                    Map.AllWargear.Rows.Add("Venom cannon", 36, "Assault", rolld(3), 8, -1, 1)
                Case Is = "Autogun"
                    Map.AllWargear.Rows.Add("Autogun", 24, "Rapid Fire", 1, 3, 0, 1)
                Case Is = "Autopistol"
                    Map.AllWargear.Rows.Add("Autopistol", 12, "Pistol", 1, 3, 0, 1)
                Case Is = "Blasting charge"
                    Map.AllWargear.Rows.Add("Blasting charge", 6, "Grenade", rolld(6), 3, 0, 1)
                Case Is = "Cache of demolition charges"
                    Map.AllWargear.Rows.Add("Cache of demolition charges", 6, "Assault", rolld(6), 8, -3, rolld(3))
                Case Is = "Clearance incinerator"
                    Map.AllWargear.Rows.Add("Clearance incinerator", 12, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Demolition charges"
                    Map.AllWargear.Rows.Add("Demolition charges", 6, "Assault", rolld(6), 8, -3, rolld(3))
                Case Is = "Heavy mining laser"
                    Map.AllWargear.Rows.Add("Heavy mining laser", 36, "Heavy", 1, 9, -3, rolld(6))
                Case Is = "Heavy seismic cannon"
heavyseismiccannon:
                    Select Case CustomMsgbox("Long or Short-wave", "Long-wave", "Short-wave")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Heavy seismic cannon - Long-wave", 24, "Heavy", 4, 4, -1, 2)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Heavy seismic cannon - Short-wave", 12, "Heavy", 2, 8, -2, 3)
                        Case Else
                            GoTo heavyseismiccannon
                    End Select
                    'Map.AllWargear.Rows.Add("Heavy seismic cannon - Long-wave", 24, "Heavy", 4, 4, -1, 2)
                    'Map.AllWargear.Rows.Add("Heavy seismic cannon - Short-wave", 12, "Heavy", 2, 8, -2, 3)
                Case Is = "Mining laser"
                    Map.AllWargear.Rows.Add("Mining laser", 24, "Heavy", 1, 9, -3, rolld(3))
                Case Is = "Needle pistol"
                    Map.AllWargear.Rows.Add("Needle pistol", 12, "Pistol", 1, 1, 0, 1)
                Case Is = "Seismic cannon"
seismiccannon:
                    Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Seismic cannon - Long-wave", 24, "Heavy", 4, 3, 0, 1)
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Seismic cannon - Short-wave", 12, "Heavy", 2, 6, -1, 2)
                        Case Else
                            GoTo seismiccannon
                    End Select
                    'Map.AllWargear.Rows.Add("Seismic cannon - Long-wave", 24, "Heavy", 4, 3, 0, 1)
                    'Map.AllWargear.Rows.Add("Seismic cannon - Short-wave", 12, "Heavy", 2, 6, -1, 2)
                Case Is = "Baleflamer"
                    Map.AllWargear.Rows.Add("Baleflamer", 18, "Assault", rolld(6), 6, -2, 2)
                Case Is = "Blastmaster"
blastmaster:
                    Select Case CustomMsgbox("Single or Varied frequency", "Single frequency", "Varied frequency")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Blastmaster - Single frequency", 48, "Heavy", rolld(3), 8, -2, rolld(3))
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Blastmaster - Varied frequency", 36, "Assault", rolld(6), 4, -1, 1)
                        Case Else
                            GoTo blastmaster
                    End Select
                    ' Map.AllWargear.Rows.Add("Blastmaster - Single frequency", 48, "Heavy", rolld(3), 8, -2, rolld(3))
                    ' Map.AllWargear.Rows.Add("Blastmaster - Varied frequency", 36, "Assault", rolld(6), 4, -1, 1)
                Case Is = "Blight grenade"
                    Map.AllWargear.Rows.Add("Blight grenade", 6, "Grenade", rolld(6), 3, 0, 1)
                Case Is = "Blight launcher"
                    Map.AllWargear.Rows.Add("Blight launcher", 24, "Assault", 2, 6, -2, rolld(3))
                Case Is = "Cypher’s bolt pistol"
                    Map.AllWargear.Rows.Add("Cypher’s bolt pistol", 16, "Pistol", 3, 4, -1, 1)
                Case Is = "Cypher’s plasma pistol"
                    Map.AllWargear.Rows.Add("Cypher’s plasma pistol", 12, "Pistol", 2, 8, -3, 2)
                Case Is = "The Destroyer Hive"
                    Map.AllWargear.Rows.Add("The Destroyer Hive", 6, "Pistol", rolld(6) + rolld(6), 4, -3, 1)
                Case Is = "Doom siren"
                    Map.AllWargear.Rows.Add("Doom siren", 8, "Assault", rolld(3), 5, -2, 1)
                Case Is = "Ectoplasma cannon"
                    Map.AllWargear.Rows.Add("Ectoplasma cannon", 24, "Heavy", rolld(3), 7, -3, rolld(3))
                Case Is = "Hades autocannon"
                    Map.AllWargear.Rows.Add("Hades autocannon", 36, "Heavy", 4, 8, -1, 2)
                Case Is = "Hades gatling cannon"
                    Map.AllWargear.Rows.Add("Hades gatling cannon", 48, "Heavy", 12, 8, -2, 2)
                Case Is = "Havoc launcher"
                    Map.AllWargear.Rows.Add("Havoc launcher", 48, "Heavy", rolld(6), 5, 0, 1)
                Case Is = "Heavy warpflamer"
                    Map.AllWargear.Rows.Add("Heavy warpflamer", 8, "Heavy", rolld(6), 5, -2, 1)
                Case Is = "Helbrute plasma cannon"
                    Map.AllWargear.Rows.Add("Helbrute plasma cannon", 36, "Heavy", rolld(3), 8, -3, 2)
                Case Is = "Hellfyre missile rack"
                    Map.AllWargear.Rows.Add("Hellfyre missile rack", 24, "Heavy", 2, 8, -2, rolld(3))
                Case Is = "Ichor cannon"
                    Map.AllWargear.Rows.Add("Ichor cannon", 48, "Heavy", rolld(6), 7, -4, rolld(3))
                Case Is = "Inferno bolt pistol"
                    Map.AllWargear.Rows.Add("Inferno bolt pistol", 12, "Pistol", 1, 4, -2, 1)
                Case Is = "Inferno boltgun"
                    Map.AllWargear.Rows.Add("Inferno boltgun", 24, "Rapid Fire", 1, 4, -2, 1)
                Case Is = "Inferno combi-bolter"
                    Map.AllWargear.Rows.Add("Inferno combi-bolter", 24, "Rapid Fire", 2, 4, -2, 1)
                Case Is = "Khârn’s plasma pistol"
                    Map.AllWargear.Rows.Add("Khârn’s plasma pistol", 12, "Pistol", 1, 8, -3, 2)
                Case Is = "Magma cutter"
                    Map.AllWargear.Rows.Add("Magma cutter", 6, "Pistol", 1, 8, -4, 3)
                Case Is = "Skullhurler"
                    Map.AllWargear.Rows.Add("Skullhurler", 60, "Heavy", rolld(6), 9, -3, rolld(3))
                Case Is = "Sonic blaster"
                    Map.AllWargear.Rows.Add("Sonic blaster", 24, "Assault", 3, 4, 0, 1)
                Case Is = "Soulreaper cannon"
                    Map.AllWargear.Rows.Add("Soulreaper cannon", 24, "Heavy", 4, 5, -3, 1)
                Case Is = "Talon of Horus (shooting)"
                    Map.AllWargear.Rows.Add("Talon of Horus (shooting)", 24, "Rapid Fire", 2, 4, -1, rolld(3))
                Case Is = "Tyrant’s Claw (shooting)"
                    Map.AllWargear.Rows.Add("Tyrant’s Claw (shooting)", 9, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Warp bolter"
                    Map.AllWargear.Rows.Add("Warp bolter", 24, "Assault", 2, 4, -1, 2)
                Case Is = "Warpflame pistol"
                    Map.AllWargear.Rows.Add("Warpflame pistol", 6, "Pistol", rolld(6), 3, -2, 1)
                Case Is = "Warpflamer"
                    Map.AllWargear.Rows.Add("Warpflamer", 8, "Assault", rolld(6), 4, -2, 1)
                Case Is = "Bellow of endless fury"
                    Map.AllWargear.Rows.Add("Bellow of endless fury", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Bloodflail"
                    Map.AllWargear.Rows.Add("Bloodflail", 8, "Assault", 1, 1, -3, 3)
                Case Is = "Coruscating flames"
                    Map.AllWargear.Rows.Add("Coruscating flames", 18, "Assault", 2, 3, 0, 1)
                Case Is = "Death’s heads"
                    Map.AllWargear.Rows.Add("Death’s heads", 12, "Assault", 2, 4, 0, 1)
                Case Is = "Fire of Tzeentch"
fireoftzeentch:
                    Select Case CustomMsgbox("Blue or Pink", "Blue", "Pink")
                        Case Is = 2
                            Map.AllWargear.Rows.Add("Fire of Tzeentch - Blue", 18, "Heavy", rolld(3), 9, -4, rolld(3))
                        Case Is = 3
                            Map.AllWargear.Rows.Add("Fire of Tzeentch - Pink", 8, "Pistol", rolld(6), 5, -2, 1)
                        Case Else
                            GoTo fireoftzeentch
                    End Select
                    ' Map.AllWargear.Rows.Add("Fire of Tzeentch - Blue", 18, "Heavy", rolld(3), 9, -4, rolld(3))
                    ' Map.AllWargear.Rows.Add("Fire of Tzeentch - Pink", 8, "Pistol", rolld(6), 5, -2, 1)
                Case Is = "Flickering flames"
                    Map.AllWargear.Rows.Add("Flickering flames", 8, "Pistol", rolld(6), 4, -1, 1)
                Case Is = "Harvester cannon"
                    Map.AllWargear.Rows.Add("Harvester cannon", 48, "Heavy", 3, 7, -1, rolld(3))
                Case Is = "Hellfire"
                    Map.AllWargear.Rows.Add("Hellfire", 8, "Assault", rolld(6), 5, -1, 1)
                Case Is = "Lashes of torment"
                    Map.AllWargear.Rows.Add("Lashes of torment", 6, "Assault", rolld(6), 4, 0, 1)
                Case Is = "Phlegm bombardment"
                    Map.AllWargear.Rows.Add("Phlegm bombardment", 36, "Heavy", rolld(3), 8, -2, 3)
                Case Is = "Skull cannon"
                    Map.AllWargear.Rows.Add("Skull cannon", 36, "Heavy", rolld(3), 8, -1, rolld(3))
                Case Is = "Avenger gatling cannon"
                    Map.AllWargear.Rows.Add("Avenger gatling cannon", 36, "Heavy", 12, 6, -2, 2)
                Case Is = "Ironstorm missile pod"
                    Map.AllWargear.Rows.Add("Ironstorm missile pod", 72, "Heavy", rolld(6), 5, -1, 2)
                Case Is = "Rapid-fire battle cannon"
                    Map.AllWargear.Rows.Add("Rapid-fire battle cannon", 72, "Heavy", rolld(6) + rolld(6), 8, -2, rolld(3))
                Case Is = "Stormspear rocket pod"
                    Map.AllWargear.Rows.Add("Stormspear rocket pod", 48, "Heavy", 3, 8, -2, rolld(6))
                Case Is = "Thermal cannon"
                    Map.AllWargear.Rows.Add("Thermal cannon", 36, "Heavy", rolld(3), 9, -4, rolld(6))
                Case Is = "Twin Icarus autocannon"
                    Map.AllWargear.Rows.Add("Twin Icarus autocannon", 48, "Heavy", 4, 7, -1, 2)
                Case Is = "Icarus lascannon"
                    Map.AllWargear.Rows.Add("Icarus lascannon", 96, "Heavy", 1, 9, -3, rolld(6))
                Case Is = "Quad-gun"
                    Map.AllWargear.Rows.Add("Quad-gun", 48, "Heavy", 8, 7, -1, 1)
                Case Is = "Super Duper Mega Weapon"
                    Map.AllWargear.Rows.Add("Super Duper Mega Weapon", 60, "Rapid Fire", 100, 100, -10, 100)
                Case Else
                    'handles stuff like camo cloak
                    MsgBox("That is not a weapon, please select a weapon!")
                    Map.skipshooting = True
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
                    '######################################################################################
            End Select
        Catch ex As Exception
            MsgBox("You need to select a weapon, stupid!")
            Map.skipshooting = True
        End Try
    End Sub
    Function closestunit(ByVal selectedunit As Object) '''' finds closest unit to selected unit
        Dim centerx As Integer
        Dim centery As Integer
        Dim closestdistance As Double
        Dim distance As Double
        Dim targetunitx As Integer
        Dim targetunity As Integer
        Dim identstorage As Integer = ""
        centerx = selectedunit.left + selectedunit.Width / 2
        centery = selectedunit.top + selectedunit.Height / 2
        For Each cnt In Map.Controls
            If TypeOf cnt Is Model Then
                targetunitx = cnt.left + cnt.Width / 2
                targetunity = cnt.top + cnt.Height / 2
                distance = calcdistancebetweentwoobjects(centerx, centery, targetunitx, targetunity)
                If distance < closestdistance Or closestdistance = "" Then
                    identstorage = cnt.identifier
                End If
            End If
        Next
        Return identstorage
    End Function
    Function calcdistancebetweentwoobjects(ByVal unit1x As Integer, ByVal unit1y As Integer, ByVal unit2x As Integer, ByVal unit2y As Integer) As Double
        Console.WriteLine("Distance between two objects: " & Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / Map.aspectratio)
        Return Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / Map.aspectratio
    End Function
    Sub TransferUnits(ByVal ListofUnits As List(Of ModelsAndWeaponsForTransferingtoMap))
        Dim left As Integer = 0
        Dim top As Integer = 0

        Map.heightofmap = 0
        For model As Integer = 0 To ListofUnits.Count - 1
            Console.WriteLine(ListofUnits(model).GroupID & " " & ListofUnits(model).GroupName & " " & ListofUnits(model).Name)
            For weaponsandabilities As Integer = 0 To ListofUnits(model).WeaponsandAbilities.Count - 1
                Console.WriteLine(" -- " & ListofUnits(model).WeaponsandAbilities(weaponsandabilities))


                Dim lines = My.Resources.Units_Info_for_WH40K.Split(CChar(vbCrLf))
                Dim fullunit As String = ""
                Dim unitinfo() As String = {}
                For Each line1 In lines
                    If line1 <> "" Then

                        '            '' Console.WriteLine(line1)
                        fullunit = line1.Replace(vbLf, "")
                        unitinfo = fullunit.Split(",")

                        If fullunit.Split(",")(0) = ListofUnits(model).Name Then
                            If ListofUnits(model).GroupID = team Then
                                Map.groupidentifier.Rows.Add(team, 0, 0, 0) ' just set the leadership to something
                                team += 1
                            End If
                            If Map.currentteam = Team_Setup.playeroneteam Then
                                If (10 + Map.heightofmap + (unitinfo(1) * Map.aspectratio)) >= Map.Height Then 'if get to bottom of the page/screen
                                    Map.heightofmap = 0
                                    fromleftcolumncounter += 1
                                End If
                                left = (fromleftcolumncounter * (6.7 * Map.aspectratio) + 2) - (6.7 * Map.aspectratio) '4.15 is the width of the largest unit currently ingame
                            Else ''team <> player 1's
                                If (10 + Map.heightofmap + (unitinfo(1) * Map.aspectratio)) >= Map.Height Then 'if get to bottom of the page/screen
                                    Map.heightofmap = 0
                                    fromrightcolumncounter += 1
                                End If
                                left = Map.Width - (fromrightcolumncounter * ((6.7 * Map.aspectratio) + 2)) + ((6.7 * Map.aspectratio) - (unitinfo(1) * Map.aspectratio))
                            End If
                            top = 2 + Map.heightofmap
                            Map.heightofmap = top + unitinfo(2) * Map.aspectratio
                            AddUnitToMap(j, unitinfo(0), left, top, unitinfo(1) * Map.aspectratio, unitinfo(2) * Map.aspectratio, True, False, unitinfo(3) * Map.aspectratio, unitinfo(4), unitinfo(5), unitinfo(6), unitinfo(7), unitinfo(8), unitinfo(8), 0, unitinfo(9), unitinfo(10), unitinfo(11), ListofUnits(model).WeaponsandAbilities, Map.currentteam)
                            j = j + 1
                        End If
                    End If
                Next
            Next
        Next

        ' '' ''Dim AllUnitList As New List(Of String)(ListofUnits.Split("~"c))
        ' '' ''Dim SeperateNamesAndWeapons As New List(Of String) ' name and weapons
        ' '' ''Dim Weaponslist As New List(Of String) ' weapon list of models
        ' '' ''For Each UnitnameandWeapons As String In AllUnitList
       
        ' '' ''    SeperateNamesAndWeapons.Clear()
        ' '' ''    Weaponslist.Clear()

        ' '' ''    If UnitnameandWeapons.Contains("@") Then
        ' '' ''        SeperateNamesAndWeapons.AddRange(UnitnameandWeapons.Split("@"))

        ' '' ''        If SeperateNamesAndWeapons.Contains("$") Then 'shows all weapons
        ' '' ''            Weaponslist.AddRange(SeperateNamesAndWeapons(1).Split("$"))
        ' '' ''        Else ''shows only one weapon
        ' '' ''            Weaponslist.Add(SeperateNamesAndWeapons(1))
        ' '' ''        End If
        ' '' ''    Else
        ' '' ''        SeperateNamesAndWeapons.Add(UnitnameandWeapons)

        ' '' ''    End If
        ' '' ''    'Dim unitaspb As New Model

        ' '' ''    '    unitaspb.Identifier = j
        ' '' ''    '    '' unitaspb.weapons(0) = ""
        ' '' ''    '    ''unitaspb.playerIdentifier = Race_Selection_Form.Playerid
        

    End Sub
    Sub addModelToArmyList(ByVal groupname As String, ByVal groupid As Integer, ByVal Model As String, ByVal weaponsorabilities As System.Collections.Specialized.StringCollection)

        'Model = Regex.Replace(Model, "~", "")
        'Console.WriteLine(Model)
        Dim thismodelsandweaponsfortransferngtomap As New ModelsAndWeaponsForTransferingtoMap
        With thismodelsandweaponsfortransferngtomap
            .GroupName = groupname
            .GroupID = groupid
            .Name = Model
            .WeaponsandAbilities = weaponsorabilities
        End With
        For x = 0 To weaponsorabilities.Count - 1
            Console.WriteLine(weaponsorabilities(x))
        Next
        ModelsandWeapons.Add(thismodelsandweaponsfortransferngtomap)






    End Sub
    Function IsLOSBlocking(ByVal Unit1x As Integer, ByVal Unit1y As Integer, ByVal Unit1width As Integer, ByVal Unit1height As Integer, ByVal Unit2x As Integer, ByVal Unit2y As Integer, ByVal Unit2width As Integer, ByVal Unit2height As Integer, ByVal SceneryObjects As List(Of PicBoxInfo)) As Boolean
        For Each point1 In All4Corners(Unit1x, Unit1y, Unit1width, Unit1height)

            For Each pont2 In All4Corners(Unit2x, Unit2y, Unit2width, Unit2height)

            Next


        Next

        Return False
    End Function
    Function All4Corners(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
        Dim pointarray As New List(Of Point)
        Dim newpoint As Point
        Dim squarex As New List(Of Integer)

        Dim squarey As New List(Of Integer)
        squarex.Add(x)
        squarex.Add(x + w)
        squarey.Add(y)
        squarey.Add(y + h)
        For Each x In squarex
            For Each y In squarey
                newpoint.X = x
                newpoint.Y = y
                pointarray.Add(newpoint)
            Next
        Next

        Return pointarray
    End Function
End Module
