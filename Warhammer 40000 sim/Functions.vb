Imports System.Runtime.CompilerServices

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
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
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
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
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
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
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
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
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
                    playereightracetext = "Not Playing"
                Case Else
                    playereightracetext = "Not Playing"
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
        ''from weapons selection to map
        Dim Dark_Eldar_Army_Selection As New Dark_Eldar_Army_Selection
        Dim Dark_Eldar_Weapons_Selection As New Dark_Eldar_Weapons_Selection
        Dim Space_Marine_Army_Selection As New Space_Marine_Army_Selection
        Dim Space_Marines_Weapons_Selection As New Space_Marines_Weapons_Selection
        Race_Selection_Form.Playerid += 1

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
        Select Case armyid
            Case Is = 1
                storage = Team_Setup.playeronearmy
            Case Is = 2
                storage = Team_Setup.playertwoarmy
            Case Is = 3
                storage = Team_Setup.playerthreearmy
            Case Is = 4
                storage = Team_Setup.playerfourarmy
            Case Is = 5
                storage = Team_Setup.playerfivearmy
            Case Is = 6
                storage = Team_Setup.playersixarmy
            Case Is = 7
                storage = Team_Setup.playersevenarmy
            Case Is = 8
                storage = Team_Setup.playereightarmy
        End Select

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
    Sub SavetoFile()
        'For Each cnt In Map.Controls
        '    If TypeOf cnt Is Unit Then
        '        Console.WriteLine(cnt.
        '    End If
        'Next

    End Sub

    ''saving functions
    Function Str2Hex(ByVal Input As String)
        Dim output As String = String.Join("", Input.Select(Function(c) Conversion.Hex(AscW(c)).PadLeft(2, "0")).ToArray())
        Return output
    End Function
    ''loadingfunctions
    Function Hex2Str(ByVal Input As String)
        Dim text As New System.Text.StringBuilder(Input.Length \ 2)
        For i As Integer = 0 To Input.Length - 1 Step 2
            text.Append(Chr(Convert.ToByte(Input.Substring(i, 2), 16)))
        Next
        Console.WriteLine(text.ToString)
        Return text.ToString

    End Function


    Sub AddSceneryToMap(ByVal fromleft As Integer, ByVal fromtop As Integer, ByVal type As Integer, ByVal rotation As Integer)

        Dim sceneryobject As New Scenery
        Console.WriteLine("Left:" & fromleft & "Top:" & fromtop)
        ''placement
        sceneryobject.Left = fromleft
        sceneryobject.Top = fromtop
        ''implemnt type of scenario ie batlescarred,industrial (buildings and pipes), rural,middleofknowwhere,roads ruins,swamp,rocks,mountains,lakes,defenselines,chaotic/warpstorm
        'Console.WriteLine(System.Text.RegularExpressions.Regex.Replace(IO.Path.GetFullPath(My.Resources.ResourceManager.BaseName), "WindowsApplication1.Resources", "") & "square_rounded_512_brown.png")
        sceneryobject.Image = My.Resources.square_rounded_512_brown ''brown ideally

        sceneryobject.SizeMode = PictureBoxSizeMode.StretchImage
        Map.Controls.Add(sceneryobject)

    End Sub
    Sub AddUnitToMap(ByVal ID As Integer, ByVal name As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal visible As Boolean, ByVal ispsyker As Boolean, ByVal M As Integer, ByVal WS As Integer, ByVal BS As Integer, ByVal S As Integer, ByVal T As Integer, ByVal CurrW As Integer, ByVal MaxW As Integer, ByVal MortW As Integer, ByVal A As Integer, ByVal LD As Integer, ByVal Sv As Integer, ByVal weapons() As String, ByVal teamid As Integer, Optional CanMove As Boolean = True, Optional CanShoot As Boolean = False, Optional hasmoved As Boolean = True, Optional hasadvanced As Boolean = False, Optional istarget As Boolean = True, Optional isshooting As Boolean = False, Optional isselectedtobetarget As Boolean = True, Optional isselectedtobeshooting As Boolean = False, Optional abilities() As String = Nothing, Optional psykerpowers() As String = Nothing, Optional numberofpsykerpowers As Integer = 0, Optional numberofdenythewitch As Integer = 0, Optional ISv As Integer = 20, Optional factiontags() As String = Nothing, Optional rotation As Integer = 0, Optional exploded As Boolean = False)
        Dim unitaspb As New Unit
        unitaspb.Identifier = ID
        unitaspb.Tag = name
        unitaspb.Left = x
        unitaspb.Top = y
        unitaspb.Width = width
        unitaspb.Height = height
        unitaspb.Psyker = ispsyker
        unitaspb.MoveDistance = m
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
        Console.WriteLine("Successfully added " & unitaspb.Tag & " to the Map")
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
        counter = 0
        ReDim Map.Coordinates(counter)
        For Each targetcont In Map.Controls
            If TypeOf targetcont Is Unit Then
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
                    Map.Coordinates(counter) = New Point(targetcont.left, targetcont.top)
                    counter += 1
                    ReDim Preserve Map.Coordinates(counter)
                    Map.nomoretargets = False
                End If
            End If
        Next
    End Sub
End Module


