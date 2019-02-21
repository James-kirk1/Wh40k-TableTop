Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing.Drawing2D

Public Class Map
    Public aspectratio As Decimal
    Dim mapwidth As Decimal
    Dim mapheight As Decimal
    Dim number As Integer
    Dim oldcenterx As Integer
    Dim oldcentery As Integer
    Dim radius As Integer
    Dim phasenumber As Integer = 0
    Dim off As Point
    Dim oldcornerx As Integer
    Dim oldcornery As Integer
    Dim phasename As String = "Deployment Phase"
    Dim basewidth As Decimal
    Dim baseheight As Decimal
    Dim oldcenterxforcircle As Integer
    Dim oldcenteryforcircle As Integer
    Dim notvisible As Boolean = False
    Public AllWargear As New DataTable
    Dim currentteam As Integer
    Dim fromleftcolumncounter As Integer = 1
    Dim fromrightcolumncounter As Integer = 1
    Dim damagephases As Boolean = False
    Dim leadershipphases As Boolean = False
    Dim unitfortransferinginfo As Integer
    Private Property pageready As Boolean = False
    Dim countdamage As Integer
    Dim unitidentifier As New DataTable
    Dim groupidentifier As New DataTable
    '   Dim stringtester() As String = {"1", "2", "3"}
    Public Coordinates(100) As Point
    Dim listofallweapons As String
    Dim numberofhitrolls As Integer = 1
    Dim numberofwoundrolls As Integer = 0
    Dim numberofsaverolls As Integer = 1
    Dim autohit As Boolean = False
    Dim strength As Integer = 8
    Public toughness As Integer = 8
    Public save As Integer = 8
    Dim ap As Integer = 0
    Dim damage As Integer = 1
    Dim applyadditionalmortalwound As Boolean = False
    Public hitrollmodifer As Integer = 0
    Public hitroll As Integer
    Public woundroll As Integer
    Dim incover As Boolean = False

    Dim id As Integer = 1
    Public nomoretargets As Boolean = False

    Dim rnd As New Random
    Dim minfromleft As Decimal = 6 * aspectratio
    Dim minfromright As Decimal = 6 * aspectratio
    Dim minfromtop As Decimal = 3 * aspectratio
    Dim minfrombottom As Decimal = 3 * aspectratio
    Dim leftcornerofscenery As Integer = 0
    Dim topcornerofscenery As Integer = 0
    Dim numberofobjects As Integer = 10
    Dim marginofscenery As Integer = 1 * aspectratio
    Dim errorcounter As Integer = 0
    Dim errorflag As Boolean = False

 
    Private Sub Map_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.I Then
            Unit_Information.Visible = True
        End If
    End Sub
    Private Sub Map_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Unit_Information.Visible = False
    End Sub

    'Private WithEvents ThisPicBoxInfoForUnits2 As New PicBoxInfo()
    Private Sub Map_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

       




















        'AddHandler MyBase.Paint, AddressOf Choose_and_calc_deployment_zones
        Dim height As Integer
        unitidentifier.Columns.Add("modelidentifier")
        'unitidentifier.Columns.Add("modelplayeridentifier")
        unitidentifier.Columns.Add("modelgroupidentifer")
        unitidentifier.Columns.Add("leadership")
        groupidentifier.Columns.Add("groupid").DataType = GetType(Integer)
        groupidentifier.Columns.Add("leadership")
        groupidentifier.Columns.Add("groupmodelslostthisturn")
        groupidentifier.Columns.Add("groupmodelslostintotal")
        Me.Top = 0
        Me.Left = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.StartPosition = FormStartPosition.CenterScreen
        Unit_Information.Visible = False
        Dim screenheight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim screenwidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Me.Width = screenwidth
        Me.Height = screenheight
        mapwidth = Math.Floor(Me.Width / Race_Selection_Form.mapwidth1)
        mapheight = Math.Floor(Me.Height / Race_Selection_Form.mapheight1)
        If mapheight > mapwidth Then
            aspectratio = mapwidth
        Else
            aspectratio = mapheight
        End If
        Me.Width = aspectratio * Race_Selection_Form.mapwidth1
        Me.Height = aspectratio * Race_Selection_Form.mapheight1


        ''senery section
        minfromleft = 6 * aspectratio
        minfromright = 6 * aspectratio
        minfromtop = 3 * aspectratio
        minfrombottom = 3 * aspectratio
        numberofobjects = 20
        marginofscenery = 1 * aspectratio

        Dim counterofobjects As Integer = 0
        Dim sceneryobject As New Scenery
        Dim srlatch As Boolean = True ' simple set-reset switch
        Randomize()
        'Dim refreshbutton As New Button
        'Me.Controls.Add(refreshbutton)
        'AddHandler refreshbutton.Click, AddressOf resetscenery
        Do While counterofobjects <= numberofobjects - 1
            leftcornerofscenery = rnd.Next(minfromleft, mirror_pointx(minfromright))
            topcornerofscenery = rnd.Next(minfromtop, mirror_pointy(minfrombottom))

recheck:
            ''checking for collisions
            For Each cnt In Me.Controls
                If TypeOf cnt Is Scenery Then
                    If IsBetween(leftcornerofscenery, cnt.left - sceneryobject.Width - marginofscenery, cnt.left + cnt.Width + marginofscenery) And IsBetween(topcornerofscenery, cnt.top - sceneryobject.Height - marginofscenery, cnt.top + cnt.Height + marginofscenery) Then
                        Console.WriteLine("Error finding space for new scenery object")
                        leftcornerofscenery = rnd.Next(minfromleft, mirror_pointx(minfromright))
                        topcornerofscenery = rnd.Next(minfromtop, mirror_pointy(minfrombottom))
                        srlatch = False
                        GoTo recheck
                    Else
                        srlatch = True

                    End If
                End If
            Next
            If srlatch Then
                counterofobjects += 1
                AddSceneryToMap(leftcornerofscenery, topcornerofscenery, 0, 0)
            End If



        Loop




















        '1:Captain in Terminator Armour@Thunder hammer$Super Duper Mega Weapon~1:Captain in Terminator Armour@Thunder hammer$Super Duper Mega Weapon~2:Librarian in Terminator Armour@Plasma cannon~3:Scout Sergeant~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~4:Veteran Sergeant~4:Space Marine Veteran~4:Space Marine Veteran@Plasma cannon~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran@~4:Space Marine Veteran~4:Space Marine Veteran~5:Apothecary~6:Space Marine Sergeant@Combi-flamer~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~7:Space Marine Sergeant@Combi-flamer$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~8:Whirlwind@Hunter-killer missile$Storm bolter~9:Stormtalon Gunship@two Lascannons$Hunter-killer missile$Storm bolter


        Race_Selection_Form.Playerid = 1
        Team_Setup.playeronearmy = "1:Captain in Terminator Armour@Thunder hammer$Plasma gun~1:Captain in Terminator Armour@Thunder hammer$Plasma gun~2:Librarian in Terminator Armour@Plasma cannon~3:Scout Sergeant~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~4:Veteran Sergeant~4:Space Marine Veteran~4:Space Marine Veteran@Plasma cannon~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran@~4:Space Marine Veteran~4:Space Marine Veteran~5:Apothecary~6:Space Marine Sergeant@Combi-flamer~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~7:Space Marine Sergeant@Combi-flamer$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~8:Whirlwind@Hunter-killer missile$Storm bolter~9:Stormtalon Gunship@two Lascannons$Hunter-killer missile$Storm bolter"
        Team_Setup.playertwoarmy = "1:Grey Knight Apothecary~2:Archon~3:Grey Knight Apothecary~4:Captain~5:Captain~6:Captain~7:Sergeant~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman" '~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader"
        Team_Setup.playeroneteam = 1
        Team_Setup.playertwoteam = 2
        TSMI_Apply_Damage.Enabled = False
        TSMI_Model_flees.Enabled = False
        Dim j As Integer = 0
        Dim team As Integer = 1
        'Console.WriteLine(Race_Selection_Form.maxplayers)
        Label2.Text = "Current Phase: " & phasename
        For players = 1 To Race_Selection_Form.maxplayers
            height = 0
            Race_Selection_Form.Playerid = players
            'Next
            Console.WriteLine(Race_Selection_Form.Playerid)
            Dim storage As String = ""
            Select Case Race_Selection_Form.Playerid
                Case Is = 1
                    currentteam = Team_Setup.playeroneteam
                    storage = Team_Setup.playeronearmy
                Case Is = 2
                    currentteam = Team_Setup.playertwoteam
                    storage = Team_Setup.playertwoarmy
                Case Is = 3
                    currentteam = Team_Setup.playerthreeteam
                    storage = Team_Setup.playerthreearmy
                Case Is = 4
                    currentteam = Team_Setup.playerfourteam
                    storage = Team_Setup.playerfourarmy
                Case Is = 5
                    currentteam = Team_Setup.playerfiveteam
                    storage = Team_Setup.playerfivearmy
                Case Is = 6
                    currentteam = Team_Setup.playersixteam
                    storage = Team_Setup.playersixarmy
                Case Is = 7
                    currentteam = Team_Setup.playerseventeam
                    storage = Team_Setup.playersevenarmy
                Case Is = 8
                    currentteam = Team_Setup.playereightteam
                    storage = Team_Setup.playereightarmy
            End Select
            Dim str() As String = storage.ToString.Split("~") 'stores models
            Dim str2() As String = {""} ' name and weapons
            Dim Weaponslist() As String = {""} ' weapon list of models
            Dim str4() As String = {""}
            Dim Unitname As String
            For Each line As String In str
                ''Console.WriteLine(Functions.aunitfromallunit()

                Dim left As Integer = 0
                Dim top As Integer = 0
                ReDim Weaponslist(0) 'preserve?
                If line.Contains("@") Then
                    str2 = line.Split("@")
                    Unitname = str2(0)
                    If str2(1).Contains("$") Then 'shows all weapons
                        Weaponslist = str2(1).Split("$")
                    Else ''shows only one weapon
                        Weaponslist(0) = str2(1)
                    End If
                Else
                    str2(0) = line
                    Unitname = str2(0)
                    ''str.Length = 1
                    Weaponslist(0) = ""
                End If
                Dim unitaspb As New Unit
                unitaspb.Identifier = j
                '' unitaspb.weapons(0) = ""
                ''unitaspb.playerIdentifier = Race_Selection_Form.Playerid
                Dim lines = My.Resources.Units_Info_for_WH40K.Split(CChar(vbCrLf))
                Dim fullunit As String = ""
                Dim unitinfo() As String = {}
                For Each line1 In lines
                    If line1 <> "" Then
                        '' Console.WriteLine(line1)
                        fullunit = line1.Replace(vbLf, "")
                        unitinfo = fullunit.Split(",")
                        ''If unitinfo(10) <= 7 Then
                        ''    Console.WriteLine(unitinfo(0))
                        ''End If
                        ''Console.WriteLine(fullunit.Split(",")(0) & " and " & fullunit.Split(",").ToString & "end")
                        If fullunit.Split(",")(0) = str2(0).Split(":")(1) Then


                            unitinfo = fullunit.Split(",")
                            ''Console.WriteLine(str2(0) & " has been added.")
                            ReDim unitaspb.abilities(0)
                            unitaspb.NameofModel = unitinfo(0)
                            unitaspb.Width = unitinfo(1) * aspectratio
                            unitaspb.Height = unitinfo(2) * aspectratio
                            unitaspb.MoveDistance = unitinfo(3) * aspectratio
                            unitaspb.WeaponSkill = unitinfo(4)
                            unitaspb.BallisticSkill = unitinfo(5)
                            unitaspb.Strength = unitinfo(6)
                            unitaspb.Toughness = unitinfo(7)
                            unitaspb.MaxWounds = unitinfo(8)
                            unitaspb.CurrentWounds = unitinfo(8)  'number of remaining wounds left
                            ''Console.WriteLine(unitaspb.MaxWounds & unitaspb.CurrentWounds)
                            unitaspb.Attacks = unitinfo(9)
                            unitaspb.Leadership = unitinfo(10)
                            unitaspb.Save = unitinfo(11)
                            unitidentifier.Rows.Add(j, str2(0).Split(":")(0), unitaspb.Leadership)
                            unitaspb.TeamId = Race_Selection_Form.Playerid
                            If Weaponslist.Count > 0 Then
                                ReDim unitaspb.Weapons(1)
                                For x = 0 To Weaponslist.Count - 1
                                    ReDim Preserve unitaspb.Weapons(x + 1)
                                    unitaspb.Weapons(x) = Weaponslist(x)
                                    'If unitaspb.listofallweapons = "" Then
                                    '    unitaspb.listofallweapons += Weaponslist(x)
                                    'Else
                                    '    unitaspb.listofallweapons += "," & vbCrLf & Weaponslist(x)
                                    'End If
                                Next
                            End If
                            ''If unitaspb.nameofmodel = "Librarian in Terminator Armour" Or unitaspb.nameofmodel = "Scout Sergeant" Or unitaspb.nameofmodel = "Scout" Then
                            ''    unitaspb.abilities(0) = "Explodes"
                            ''End If
                            'Console.WriteLine(unitaspb.weapons.Count & "," & unitaspb.weapons.Length)
                            unitaspb.Weapons = Weaponslist
                            'unitaspb.weapons.l
                            ' unitaspb.has()
                            If str2(0).Split(":")(0) = team Then
                                groupidentifier.Rows.Add(team, 0, 0, 0) ' just set the leadership to something
                                team += 1
                            End If

                            If currentteam = Team_Setup.playeroneteam Then
                                If Race_Selection_Form.Playerid = 1 Then ''player 1 
                                    unitaspb.Image = My.Resources.square_rounded_512_green
                                Else
                                    unitaspb.Image = My.Resources.square_rounded_512_blue 'team 1 player >1/ally
                                End If
                                If (10 + height + unitaspb.Height) >= Me.Height Then 'if get to bottom of the page/screen
                                    height = 0
                                    fromleftcolumncounter += 1
                                End If
                                left = (fromleftcolumncounter * (4.15 * aspectratio) + 2) - (4.15 * aspectratio) '4.15 is the width of the largest unit currently ingame
                            Else ''team <> player 1's
                                If (10 + height + unitaspb.Height) >= Me.Height Then 'if get to bottom of the page/screen
                                    height = 0
                                    fromrightcolumncounter += 1
                                End If
                                left = Me.Width - (fromrightcolumncounter * ((4.15 * aspectratio) + 2)) + ((4.15 * aspectratio) - unitaspb.Width)
                                unitaspb.Image = My.Resources.square_rounded_512_red
                            End If

                            'AddUnitToMap(j, unitinfo(0), left, top, False, unitinfo(3) * aspectratio, unitinfo(4), unitinfo(5), unitinfo(6), unitinfo(7), unitinfo(8), unitinfo(8), 0, unitinfo(9), unitinfo(10), unitinfo(11), Weaponslist)

                        End If
                    End If



                Next
                ''startofposition
                Select Case Race_Selection_Form.setdeploymentmap
                    Case Is = 1
                        Console.WriteLine("Spearhead Assault")
                    Case Is = 2
                        Console.WriteLine("Dawn of War")
                    Case Is = 3
                        Console.WriteLine("Search and Destroy")
                    Case Is = 4
                        Console.WriteLine("Hammer and Anvil")
                    Case Is = 5
                        Console.WriteLine("Front-line Assault")
                    Case Is = 6
                        Console.WriteLine("Vanguard Strike")
                    Case Else
                End Select
                ''currently here and not in case else ^ for testing purposes

                top = 2 + height
                height = Top + unitaspb.Height
                unitaspb.Left = left
                unitaspb.Top = top
                ''endof position
                ''startofotherproperties
                unitaspb.CanMove = True
                unitaspb.Canshoot = False
                unitaspb.MortalWounds = 0
                ''endofotherproperties
                unitaspb.SizeMode = PictureBoxSizeMode.StretchImage
                ''startof teamcalculation
                ''endofteamcalculation

                AddHandler unitaspb.MouseHover, AddressOf unitaspb_MouseHover
                AddHandler unitaspb.MouseLeave, AddressOf unitaspb_MouseLeave
                AddHandler unitaspb.MouseUp, AddressOf unitaspb_MouseUp
                AddHandler unitaspb.MouseClick, AddressOf Unit_MouseClick

                
                'Console.WriteLine(unitaspb.nameofmodel)
                Me.Controls.Add(unitaspb)

                j = j + 1
                '' Console.WriteLine(Me.Width)
                '' Console.WriteLine(unitaspb.Left)
            Next
        Next
        AllWargear.Columns.Add("Name")
        AllWargear.Columns.Add("Range")
        AllWargear.Columns.Add("Type")
        AllWargear.Columns.Add("Number")
        AllWargear.Columns.Add("Strength")
        AllWargear.Columns.Add("Armour Penetration")
        AllWargear.Columns.Add("Damage")
        Race_Selection_Form.Hide()
        Race_Selection_Form.Timer1.Stop()
        Console.WriteLine("###")
        If Race_Selection_Form.Loadrecentgame Then
            For i = Me.Controls.Count - 1 To 0 Step -1
                If TypeName(Me.Controls.Item(i)) = "Unit" Then
                    Me.Controls.RemoveAt(i)
                End If
                'Me.Controls.Remove(cnt)
                'End If
            Next
            Dim StringListforUnits As New List(Of picboxinfo)()
            'Dim PicBoxListforScenery As New List(Of PicBoxInfo)()
            Dim ScenerySaveFileStream As Stream = File.Open(Race_Selection_Form.ScenerySaveFilename, FileMode.Open, FileAccess.Read)
            Dim UnitsSaveFileStream As Stream = File.Open(Race_Selection_Form.UnitsSaveFilename, FileMode.Open, FileAccess.Read)

            Dim Deserializer As New BinaryFormatter
            'For Each cnt In Me.Controls
            ' If TypeOf cnt Is Unit Then

            StringListforUnits = Deserializer.Deserialize(UnitsSaveFileStream)

            'Dim ThisPicBoxInfoForUnits As New PicBoxInfo
            'Console.WriteLine(List(of String) Deserializer.Deserialize())
            For i = 0 To StringListforUnits.Count - 1
                'Dim cnt As New Unit

                With StringListforUnits(i)
                    AddUnitToMap(.Identifier, .nameofmodel, .Left, .Top, .Width, .Height, .visible, .Psyker, .MoveDistance, .WeaponSkill, .BallisticSkill, .Strength, .Toughness, .CurrentWounds, .MaxWounds, .MortalWounds, .Attacks, .Leadership, .Save, .Weapons, .TeamId, .CanMove, .Canshoot, .hasmoved, .hasadvanced, .istarget, .isshooting, .isselectedtobetarget, .isselectedtobeshooting, .abilities, .psykerpowers, .numberofpsykerpowers, .numberofdenythewitch, .invulnerablesave, .factiontags, .exploded)
                    'cnt.Width = .Width
                    'cnt.Height = .Height
                    'cnt.Name = .Name
                    'cnt.Left = .Left
                    'cnt.Top = .Top
                    'cnt.NameofModel = .nameofmodel
                    'cnt.SizeMode = .Sizemode
                    'cnt.Identifier = .Identifier


                    'cnt.MoveDistance = .MoveDistance
                    'cnt.Identifier = .Identifier
                    'cnt.CanMove = .CanMove
                    'cnt.Canshoot = .Canshoot
                    'cnt.WeaponSkill = .WeaponSkill
                    'cnt.BallisticSkill = .BallisticSkill
                    'cnt.Strength = .Strength
                    'cnt.Toughness = .Toughness
                    'cnt.CurrentWounds = .CurrentWounds
                    'cnt.MaxWounds = .MaxWounds
                    'cnt.MortalWounds = .MortalWounds
                    'cnt.Attacks = .Attacks
                    'cnt.Leadership = .Leadership
                    'cnt.Save = .Save
                    'cnt.invulnerablesave = .invulnerablesave
                    'cnt.Psyker = .Psyker


                    'cnt.Weapons() = .Weapons
                    'cnt.hasadvanced = .hasadvanced
                    'cnt.hasmoved = .hasmoved
                    'cnt.isshooting = .isshooting
                    'cnt.istarget = .istarget
                    'cnt.isselectedtobeshooting = .isselectedtobeshooting
                    'cnt.isselectedtobetarget = .isselectedtobetarget

                    'cnt.abilities() = .abilities

                    ''cnt.psykerpowers() = '.psykerpowers

                    ''cnt.factiontags() = '.factiontags
                    'cnt.numberofpsykerpowers = .numberofpsykerpowers
                    'cnt.numberofdenythewitch = .numberofdenythewitch
                    'cnt.exploded = .exploded
                    'cnt.TeamId = .TeamId

                    'cnt.Visible = .visible

                End With
                'Me.Controls.Add(cnt)

              
            Next
            ' End If
            'Invalidate()


            'If TypeOf cnt Is Scenery Then
            '    Dim ThisPicBoxInfoForScenery As New PicBoxInfo
            '    With ThisPicBoxInfoForScenery
            '        .Width = cnt.Width
            '        .Height = cnt.Height
            '        .Name = cnt.Name
            '        .Left = cnt.left
            '        .Top = cnt.top
            '        .nameofmodel = cnt.nameofmodel
            '        .Sizemode = cnt.sizemode
            '    End With
            '    PicBoxListforScenery.Add(ThisPicBoxInfoForScenery)
            'End If
            ' Next
            'End If
            ' Serializer.Serialize(UnitsSaveFileStream, PicBoxListforUnits)
            ' Serializer.Serialize(ScenerySaveFileStream, PicBoxListforScenery)
            ScenerySaveFileStream.Close()
            UnitsSaveFileStream.Close()
        End If
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                Console.WriteLine(cnt.nameofmodel & " " & cnt.left & " " & cnt.top & " " & cnt.visible & " " & cnt.identifier)
            End If
        Next
    End Sub
    Public Sub Unit_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        ' Console.WriteLine(sender.nameofmodel)
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If damagephases = True And leadershipphases = False Then
                TSMI_Apply_Damage.Enabled = True
                TSMI_Model_flees.Enabled = False
                'If sender.currentwounds <
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Unit Then
                        If cnt.isselectedtobetarget = True And cnt.currentwounds > 0 Then
                            If cnt.currentwounds < cnt.maxwounds And cnt.identifier <> unitfortransferinginfo Then
                                MsgBox("Selected unit already has an injured model, applying damage to that model instead", 33)
                                unitfortransferinginfo = cnt.identifier
                                ' Dim c As Control = CType(sender, Control)
                                ContextMenuStrip1.Show(cnt, e.Location)
                                Exit Sub
                            Else
                                unitfortransferinginfo = cnt.identifier
                                ' Dim c As Control = CType(sender, Control)
                                ContextMenuStrip1.Show(cnt, e.Location)
                                Exit Sub
                            End If
                        End If
                    End If
                Next
            ElseIf leadershipphases = True And damagephases = False Then ''leadership section
                TSMI_Apply_Damage.Enabled = False
                TSMI_Model_flees.Enabled = True
                ''''''''''''''''''''''''''''''
                'For Each cnt In Me.Controls
                '    If TypeOf cnt Is Unit Then
                '        If cnt.isselectedtobetarget = True Then
                '            If cnt.currentwounds < cnt.maxwounds And cnt.currentwounds > 0 Then
                '                MsgBox("Selected unit already has an injured model, removing that model instead", 33)
                '                unitfortransferinginfo = cnt.identifier
                '                ' Dim c As Control = CType(sender, Control)
                '                ContextMenuStrip1.Show(cnt, e.Location)
                '                Exit Sub
                '            Else
                '                unitfortransferinginfo = cnt.identifier
                '                ' Dim c As Control = CType(sender, Control)
                '                ContextMenuStrip1.Show(cnt, e.Location)
                '                Exit Sub
                '            End If
                '        End If
                '    End If
                'Next
            ElseIf leadershipphases = False And damagephases = False Then
                If sender.isselectedtobeshooting = True Then
                    TSMI_ShootingSelect.Enabled = False
                    TSMI_ShootingCancel.Enabled = True
                End If
                If sender.isselectedtobeshooting = False Then
                    TSMI_ShootingCancel.Enabled = False
                    TSMI_ShootingSelect.Enabled = True
                End If
                If sender.isselectedtobetarget = True Then
                    TSMI_TargetSelect.Enabled = False
                    TSMI_TargetCancel.Enabled = True
                End If
                If sender.isselectedtobetarget = False Then
                    TSMI_TargetCancel.Enabled = False
                    TSMI_TargetSelect.Enabled = True
                End If
                unitfortransferinginfo = sender.identifier
                'Dim c As Control = CType(sender, Control)
                ContextMenuStrip2.Show(sender, e.Location)
                Exit Sub
            End If
        End If
    End Sub
    Public Sub unitaspb_MouseHover(ByVal sender As Object, e As System.EventArgs)
        Unit_Information.Visible = True
        If sender.left < Me.Width / 2 Then
            Unit_Information.Left = Me.Width - 12 - Unit_Information.Width
        Else
            Unit_Information.Left = 12
        End If
        If TypeOf sender Is Unit And sender.CanMove = True Then
            oldcornerx = sender.left
            oldcornery = sender.top
            radius = sender.movedistance
            oldcenterx = oldcornerx + sender.width / 2
            oldcentery = oldcornery + sender.height / 2
            oldcenterxforcircle = oldcenterx - radius
            oldcenteryforcircle = oldcentery - radius
            AddHandler Me.Paint, AddressOf Map_Paint
        End If
        Dim listofallweapons As String = ""
        For x = 0 To sender.weapons.length - 1
            If listofallweapons = "" Then
                listofallweapons = sender.weapons(x)
            Else
                listofallweapons = listofallweapons & ", " & sender.weapons(x)
            End If
        Next
        Label2.Text = "Name: " & sender.nameofmodel & vbCrLf & "Coordinates: " & oldcenterx & ", " & oldcentery & vbCrLf & "Movement Distance: " & sender.movedistance / aspectratio & vbCrLf & "Wounds: " & sender.CurrentWounds & vbCrLf & "Moveable: " & sender.canmove & vbCrLf & "Can Shoot: " & sender.canshoot
        Me.Invalidate()
    End Sub
    Private Sub Map_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawEllipse(Pens.Black, oldcenterxforcircle, oldcenteryforcircle, radius * 2, radius * 2)
    End Sub
    Public Sub unitaspb_MouseLeave(sender As Object, e As System.EventArgs)
        If TypeOf sender Is Unit Then
            RemoveHandler Me.Paint, AddressOf Map_Paint
        End If
        Me.Invalidate()
        Unit_Information.Visible = False
    End Sub
    Private Sub BtnNxtPhase_Click(sender As System.Object, e As System.EventArgs) Handles BtnNxtPhase.Click
        damagephases = False
        TSMI_Apply_Damage.Enabled = False
        TSMI_Model_flees.Enabled = False
        phasenumber += 1
        If phasenumber >= 7 Then
            phasenumber = 1
        End If
        Select Case phasenumber
            Case Is = 1
                phasename = "Movement Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Unit Then
                        cnt.CanMove = True
                        cnt.canshoot = False
                    End If
                Next
            Case Is = 2
                phasename = "Psychic Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Unit Then
                        cnt.CanMove = False
                        cnt.canshoot = False
                    End If
                Next
                UseSelectedWeapon.Text = "Use Selected Psychic Power"
            Case Is = 3
                phasename = "Shooting Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Unit Then
                        cnt.CanMove = False
                        cnt.canshoot = True
                    End If
                Next
                UseSelectedWeapon.Text = "Use Selected Weapon"
            Case Is = 4
                phasename = "Charge Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Unit Then
                        cnt.CanMove = False
                        cnt.canshoot = False
                    End If
                Next
                UseSelectedWeapon.Text = "Charge Selected Unit"
            Case Is = 5
                phasename = "Fight Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Unit Then
                        cnt.CanMove = False
                        cnt.canshoot = False
                    End If
                Next
                UseSelectedWeapon.Text = "Fight Selected Unit"
            Case Is = 6
                phasename = "Morale Phase"
                Dim maxleadershipingroup As Integer
                Dim storedgroupid As Integer = 0
                Dim modelslostintotal As Integer = 0
                For model As Integer = 0 To unitidentifier.Rows.Count - 1 ''determines highest leadership in group
                    If unitidentifier.Rows(model).Item(1) <> storedgroupid Then 'is model in part of new group
                        maxleadershipingroup = unitidentifier.Rows(model).Item(2) '' set group leadership as this models ld
                        For groupid As Integer = 0 To groupidentifier.Rows.Count - 1
                            If groupid = storedgroupid Then
                                modelslostintotal = groupidentifier.Rows(storedgroupid).Item(3)
                                groupidentifier.Rows.RemoveAt(0)
                                groupidentifier.Rows.Add(storedgroupid + 1, maxleadershipingroup, 0, modelslostintotal)
                                'Console.WriteLine(storedgroupid + 1 & "," & maxleadershipingroup & "," & "0" & "," & modelslostintotal)
                            End If
                        Next
                        storedgroupid += 1
                    Else
                        ''unlikely the below happens 
                        If unitidentifier.Rows(model).Item(2) > maxleadershipingroup Then 'does model have better leadership
                            maxleadershipingroup = unitidentifier.Rows(model).Item(2) '' set group leadership as this models ld
                        End If
                    End If
                Next
                groupidentifier.DefaultView.Sort = "groupid"
                groupidentifier = groupidentifier.DefaultView.ToTable
                'For x = 0 To groupidentifier.Rows.Count - 1
                '    Console.WriteLine(groupidentifier.Rows(x).Item(0) & "," & groupidentifier.Rows(x).Item(1) & "," & groupidentifier.Rows(x).Item(2) & "," & groupidentifier.Rows(x).Item(3))
                'Next
                For Each cnt In Me.Controls ' add all loses inc from previous turns 
                    If TypeOf cnt Is Unit Then
                        cnt.CanMove = False
                        cnt.canshoot = False
                        'is model dead
                        For getgroup As Integer = 0 To groupidentifier.Rows.Count - 1
                            If cnt.visible = False Then
                                If groupidentifier.Rows(getgroup).Item(0) = unitidentifier.Rows(cnt.identifier).Item(1) Then 'find the units group 
                                    'Console.WriteLine(cnt.identifier & "," & getgroup)
                                    groupidentifier.Rows(getgroup).Item(2) += 1
                                End If
                            End If
                            'groupidentifier.Rows(getgroup).Item(2) -= groupidentifier.Rows(getgroup).Item(3)
                        Next
                    End If
                Next
                For getgroup As Integer = 0 To groupidentifier.Rows.Count - 1 ' remove loses from previous turns
                    groupidentifier.Rows(getgroup).Item(2) -= groupidentifier.Rows(getgroup).Item(3)
                Next
                For grouptestleadership = 0 To groupidentifier.Rows.Count - 1
                    If groupidentifier.Rows(grouptestleadership).Item(2) + 6 >= groupidentifier.Rows(grouptestleadership).Item(1) Then
                        MsgBox("One or more units have lost models therefore a leadership test is required", MsgBoxStyle.OkOnly)
                        Dim leadershiproll As Integer = rolld(6)
                        If groupidentifier.Rows(grouptestleadership).Item(2) + leadershiproll > groupidentifier.Rows(grouptestleadership).Item(1) Then
                            Dim losses As Integer = groupidentifier.Rows(grouptestleadership).Item(2) + leadershiproll - groupidentifier.Rows(grouptestleadership).Item(1)
                            leadershipphases = True
                            MsgBox("Unit " & grouptestleadership & "requires " & losses & "models to " & Chr(34) & "run away" & Chr(34) & ".", MsgBoxStyle.OkOnly)
                            pagewaiter()
                            ''put losses due to moral here
                        End If
                    End If
                Next
                For resetmodels As Integer = 0 To groupidentifier.Rows.Count - 1
                    groupidentifier.Rows(resetmodels).Item(3) += CInt(groupidentifier.Rows(resetmodels).Item(2))
                    groupidentifier.Rows(resetmodels).Item(2) = 0
                Next
                'For x = 0 To groupidentifier.Rows.Count - 1
                '    Console.WriteLine(groupidentifier.Rows(x).Item(0) & "," & groupidentifier.Rows(x).Item(1) & "," & groupidentifier.Rows(x).Item(2) & "," & groupidentifier.Rows(x).Item(3))
                'Next
        End Select
        Label2.Text = "Current Phase: " & phasename
    End Sub
    Public Sub unitaspb_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If TypeOf sender Is Unit And sender.canmove = True Then
            Dim newcornerx As Integer = sender.left
            Dim newcornery As Integer = sender.top
            Dim newcenterx As Integer = newcornerx + sender.width / 2
            Dim newcentery As Integer = newcornery + sender.height / 2
            Dim actualdistance As Double = Math.Sqrt((newcenterx - oldcenterx) ^ 2 + (newcentery - oldcentery) ^ 2)
            If actualdistance > sender.movedistance Then
                Dim gradient As Double = (newcentery - oldcentery) / (newcenterx - oldcenterx)
                Dim angle As Double = Math.Atan(gradient)
                Dim left As Integer = oldcenterx + sender.movedistance * Math.Cos(angle)
                Dim top As Integer = oldcentery + sender.movedistance * Math.Sin(angle)
                sender.top = sender.movedistance * Math.Sin(angle) + oldcornery
                sender.left = sender.movedistance * Math.Cos(angle) + oldcornerx
                'Console.WriteLine(sender.left & sender.top)
            End If
        End If
        If sender.canmove Then
            sender.canmove = False
        End If
    End Sub
    Private Sub Map_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        'Console.WriteLine(e.Location.X & e.Location.Y)
        If e.Button = Windows.Forms.MouseButtons.Right And notvisible Then
            notvisible = False
            Unit_Information.Visible = True
            If Cursor.Position.X < Me.Width / 2 Then
                Unit_Information.Left = 12
            Else
                Unit_Information.Left = Me.Width - 12 - Unit_Information.Width
            End If
            Label2.Text = "Current Phase: " & phasename
        Else
            notvisible = True
            Unit_Information.Visible = False
        End If
    End Sub
    Private Sub UseSelectedWeapon_Click(sender As System.Object, e As System.EventArgs) Handles UseSelectedWeapon.Click


        Select Case phasenumber
            Case Is = 2 'psychic phase
                Dim a As Integer = rolld(6) ''rolling to pass test
                Dim b As Integer = rolld(6)
                If a + b = 2 Or a + b = 12 Then
                    ''perils of the warp
                Else ''passes psychic test
                    Select Case InputBox("Psychic Power", , "Smite")
                        Case Is = "Smite"
                        Case Is = "Stream of Corruption"
                            If a + b > 5 Then
                                If denythewitch(a + b) = True Then
                                End If
                            End If
                            'if numberofselectedmodels < 10 then
                            'target.wounds-=rolld(3)
                            'else
                            'target.wounds-=rolld(6)
                            'end if
                        Case Is = "Fleshy Abundance"
                            If a + b > 5 Then
                            End If
                        Case Is = "Nurgle's Rot"
                            If a + b > 7 Then
                            End If
                        Case Is = "Shrivelling Pox"
                            If a + b > 6 Then
                            End If
                        Case Is = "Virulent Blessing"
                            If a + b > 7 Then
                            End If
                        Case Is = "Miasma of Pestilence"
                            If a + b > 6 Then
                            End If
                        Case Is = "Cacophonic Choir"
                            If a + b > 7 Then
                            End If
                        Case Is = "Symphony of Pain"
                            If a + b > 6 Then
                            End If
                        Case Is = "Hysterical Frenzy"
                            If a + b > 8 Then
                            End If
                        Case Is = "Delightful Agonies"
                            If a + b > 5 Then
                            End If
                        Case Is = "Pavane of Slaanesh"
                            If a + b > 6 Then
                            End If
                        Case Is = "Phantasmagoria"
                            If a + b > 6 Then
                            End If
                        Case Is = "Boon of Change"
                            If a + b > 7 Then
                            End If
                        Case Is = "Bolt of Change"
                            If a + b > 9 Then
                            End If
                        Case Is = "Gaze of Fate"
                            If a + b > 6 Then
                            End If
                        Case Is = "Treason of Tzeentch"
                            If a + b > 8 Then
                            End If
                        Case Is = "Flickering Flames"
                            If a + b > 5 Then
                            End If
                        Case Is = "Infernal Gateway"
                            If a + b > 8 Then
                            End If
                        Case Is = "Infernal Gaze"
                            If a + b > 5 Then
                            End If
                        Case Is = "Death Hex"
                            If a + b > 8 Then
                            End If
                        Case Is = "Gift of Chaos"
                            If a + b > 6 Then
                            End If
                        Case Is = "Prescience"
                            If a + b > 7 Then
                            End If
                        Case Is = "Diabolic Strength"
                            If a + b > 6 Then
                            End If
                        Case Is = "Warptime"
                            If a + b > 6 Then
                            End If
                        Case Is = "Gift of Contagion"
                            If a + b > 7 Then
                            End If
                        Case Is = "Plague Wind"
                            If a + b > 5 Then
                            End If
                        Case Is = "Blades of Putrefaction"
                            If a + b > 5 Then
                            End If
                        Case Is = "Putrescent Vitality"
                            If a + b > 6 Then
                            End If
                        Case Is = "Curse of the Leper"
                            If a + b > 7 Then
                            End If
                        Case Is = "Tzeentch’s Firestorm"
                            If a + b > 7 Then
                            End If
                        Case Is = "Boon of Mutation"
                            If a + b > 7 Then
                            End If
                        Case Is = "Glamour of Tzeentch"
                            If a + b > 7 Then
                            End If
                        Case Is = "Doombolt"
                            If a + b > 9 Then
                            End If
                        Case Is = "Temporal Manipulation"
                            If a + b > 6 Then
                            End If
                        Case Is = "Weaver of Fates"
                            If a + b > 6 Then
                            End If
                        Case Is = "Conceal/Reveal"
                            If a + b > 6 Then
                            End If
                        Case Is = "Embolden/Horrify"
                            If a + b > 6 Then
                            End If
                        Case Is = "Enhance/Drain"
                            If a + b > 7 Then
                            End If
                        Case Is = "Protect/Jinx"
                            If a + b > 7 Then
                            End If
                        Case Is = "Quicken/Restrain"
                            If a + b > 7 Then
                            End If
                        Case Is = "Empower/Enervate"
                            If a + b > 6 Then
                            End If
                        Case Is = "Guide"
                            If a + b > 7 Then
                            End If
                        Case Is = "Doom"
                            If a + b > 7 Then
                            End If
                        Case Is = "Fortune"
                            If a + b > 7 Then
                            End If
                        Case Is = "Executioner"
                            If a + b > 7 Then
                            End If
                        Case Is = "Will of Asuryan"
                            If a + b > 5 Then
                            End If
                        Case Is = "Mind War"
                            If a + b > 7 Then
                            End If
                        Case Is = "Twilight Pathways"
                            If a + b > 6 Then
                            End If
                        Case Is = "Fog of Dreams"
                            If a + b > 7 Then
                            End If
                        Case Is = "Mirror of Minds"
                            If a + b > 8 Then
                            End If
                        Case Is = "Gaze of Ynnead"
                            If a + b > 8 Then
                            End If
                        Case Is = "Ancestors' Grace"
                            If a + b > 5 Then
                            End If
                        Case Is = "Word of the Phoenix"
                            If a + b > 6 Then
                            End If
                        Case Is = "Veil of Time"
                            If a + b > 6 Then
                            End If
                        Case Is = "Might of Heroes"
                            If a + b > 6 Then
                            End If
                        Case Is = "Psychic Scourge"
                            If a + b > 6 Then
                            End If
                        Case Is = "Fury of the Ancients"
                            If a + b > 7 Then
                            End If
                        Case Is = "Psychic Fortress"
                            If a + b > 5 Then
                            End If
                        Case Is = "Null Zone"
                            If a + b > 8 Then
                            End If
                        Case Is = "Quickening"
                            If a + b > 7 Then
                            End If
                        Case Is = "Unleash Rage"
                            If a + b > 6 Then
                            End If
                        Case Is = "Shield of Sanguinius"
                            If a + b > 6 Then
                            End If
                        Case Is = "Blood Boil"
                            If a + b > 6 Then
                            End If
                        Case Is = "Blood Lance"
                            If a + b > 6 Then
                            End If
                        Case Is = "Wings of Sanguinius"
                            If a + b > 5 Then
                            End If
                        Case Is = "Mind Worm"
                            If a + b > 6 Then
                            End If
                        Case Is = "Aversion"
                            If a + b > 6 Then
                            End If
                        Case Is = "Righteous Repugnance"
                            If a + b > 7 Then
                            End If
                        Case Is = "Trephination"
                            If a + b > 7 Then
                            End If
                        Case Is = "Engulfing Fear"
                            If a + b > 6 Then
                            End If
                        Case Is = "Mind Wipe"
                            If a + b > 7 Then
                            End If
                        Case Is = "Purge Soul"
                            If a + b > 5 Then
                            End If
                        Case Is = "Gate of Infinity"
                            If a + b > 6 Then
                            End If
                        Case Is = "Hammerhand"
                            If a + b > 6 Then
                            End If
                        Case Is = "Sanctuary"
                            If a + b > 6 Then
                            End If
                        Case Is = "Astral Aim"
                            If a + b > 5 Then
                            End If
                        Case Is = "Vortex of Doom"
                            If a + b > 8 Then
                            End If
                        Case Is = "Storm Caller"
                            If a + b > 6 Then
                            End If
                        Case Is = "Tempest's Wrath"
                            If a + b > 6 Then
                            End If
                        Case Is = "Jaws of the World Wolf"
                            If a + b > 7 Then
                            End If
                        Case Is = "Terrifying Visions"
                            If a + b > 7 Then
                            End If
                        Case Is = "Gaze of the Emperor"
                            If a + b > 6 Then
                            End If
                        Case Is = "Psychic Barrier"
                            If a + b > 6 Then
                            End If
                        Case Is = "Nightshroud"
                            If a + b > 6 Then
                            End If
                        Case Is = "Mental Fortitude"
                            If a + b > 4 Then
                            End If
                        Case Is = "Psychic Maelstrom"
                            If a + b > 7 Then
                            End If
                        Case Is = "Terrify"
                            If a + b > 6 Then
                            End If
                        Case Is = "Dominate"
                            If a + b > 7 Then
                            End If
                        Case Is = "'Eadbanger"
                            If a + b > 6 Then
                            End If
                        Case Is = "Warpath"
                            If a + b > 7 Then
                            End If
                        Case Is = "Da Jump"
                            If a + b > 7 Then
                            End If
                        Case Is = "Dominion"
                            If a + b > 5 Then
                            End If
                        Case Is = "Catalyst"
                            If a + b > 6 Then
                            End If
                        Case Is = "The Horror"
                            If a + b > 6 Then
                            End If
                        Case Is = "Onslaught"
                            If a + b > 6 Then
                            End If
                        Case Is = "Paroxysm"
                            If a + b > 5 Then
                            End If
                        Case Is = "Psychic Scream"
                            If a + b > 5 Then
                            End If
                        Case Is = "Mass Hypnosis"
                            If a + b > 7 Then
                            End If
                        Case Is = "Mind Control"
                            If a + b > 6 Then
                            End If
                        Case Is = "Might From Beyond"
                    End Select
                End If
            Case Is = 3
                Try
                    Select Case ActiveWeaponsList.SelectedItem.ToString 'InputBox("weapon name", , "Super Duper Mega Weapon")
                        ''SM general weapons
                        Case Is = "Assault bolter"
                            AllWargear.Rows.Add("Assault bolter", 18, "Assault", 3, 5, -1, 1)
                        Case Is = "Assault cannon"
                            AllWargear.Rows.Add("Assault cannon", 24, "Heavy", 6, 6, -1, 1)
                        Case Is = "Astartes grenade launcher"
Astartesgrenadelauncher:
                            Select Case CustomMsgbox("Frag or krak grenade", "Frag Grenade", "Krak Grenade")
                                Case Is = 2
                                    AllWargear.Rows.Add("Astartes grenade launcher - Frag grenade", 24, "Assault", rolld(6), 3, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Astartes grenade launcher - Krak grenade", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo Astartesgrenadelauncher
                            End Select
                        Case Is = "Astartes shotgun"
                            AllWargear.Rows.Add("Astartes shotgun", 12, "Assault", 2, 4, 0, 1)
                        Case Is = "Bolt pistol"
                            AllWargear.Rows.Add("Bolt pistol", 12, "Pistol", 1, 4, 0, 1)
                        Case Is = "Bolt rifle"
                            AllWargear.Rows.Add("Bolt rifle", 30, "Rapid Fire", 1, 4, -1, 1)
                        Case Is = "Boltgun"
                            AllWargear.Rows.Add("Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = "Boltstorm gauntlet"
                            AllWargear.Rows.Add("Boltstorm gauntlet (shooting)", 12, "Pistol", 3, 4, 0, 1)
                        Case Is = "Centurion missile launcher"
                            AllWargear.Rows.Add("Centurion missile launcher", 36, "Assault", rolld(3), 8, -2, rolld(3))
                        Case Is = "Cerberus launcher"
                            AllWargear.Rows.Add("Cerberus launcher", 18, "Heavy", rolld(6), 4, 0, 1)
                        Case Is = "Combi-bolter"
                            AllWargear.Rows.Add("Combi-bolter", 24, "Rapid Fire", 2, 4, 0, 1)
                        Case Is = "Combi-flamer"
combiflamer:
                            Select Case CustomMsgbox("Boltgun, flamer or both", "Combi-flamer - Boltgun", "Combi-flamer - Flamer", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Combi-flamer - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Combi-flamer - Flamer", 8, "Assault", rolld(6), 4, 0, 1)
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo combiflamer
                                    'AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo combiflamer
                            End Select
                            'AllWargear.Rows.Add("Combi-flamer - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                            'AllWargear.Rows.Add("Combi-flamer - Flamer", 8, "Assault", rolld(6), 4, 0, 1)
                        Case Is = "Combi-grav"
combigrav:
                            Select Case CustomMsgbox("Boltgun, Grav-gun or both", "Boltgun", "Grav-gun", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Combi-grav - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Combi-grav - Grav-gun", 18, "Rapid Fire", 1, 5, -3, 1)
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo combigrav
                                    'AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo combigrav
                            End Select
                            'AllWargear.Rows.Add("Combi-grav - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                            'AllWargear.Rows.Add("Combi-grav - Grav-gun", 18, "Rapid Fire", 1, 5, -3, 1)
                        Case Is = "Combi-melta"
combimelta:
                            Select Case CustomMsgbox("Boltgun, Meltagun or both", "Boltgun", "Meltagun", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Combi-melta - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Combi-melta - Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo combimelta
                                    'AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo combimelta
                            End Select
                            'AllWargear.Rows.Add("Combi-melta - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                            'AllWargear.Rows.Add("Combi-melta - Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Combi-plasma"
combiplasma:
                            Select Case CustomMsgbox("Boltgun, Plasma gun or both", "Boltgun", "Plasma gun", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Combi-plasma - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Combi-plasma - Plasma gun", 24, "Rapid Fire", 1, 7, -3, 1)
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo combiplasma
                                    'AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo combiplasma
                            End Select
                            'AllWargear.Rows.Add("Combi-plasma - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                            'AllWargear.Rows.Add("Combi-plasma - Plasma gun", 24, "Rapid Fire", 1, 7, -3, 1)
                        Case Is = "Conversion beamer"
                            AllWargear.Rows.Add("Conversion beamer", 42, "Heavy", rolld(3), 6, 0, 1)
                        Case Is = "Cyclone missile launcher"
cyclonemissilelauncher:
                            Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Cyclone missile launcher - Frag missile", 36, "Heavy", rolld(3) + rolld(3), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Cyclone missile launcher - Krak missile", 36, "Heavy", 2, 8, -2, rolld(6))
                                Case Else
                                    GoTo cyclonemissilelauncher
                            End Select
                        Case Is = "Deathwind launcher"
                            AllWargear.Rows.Add("Deathwind launcher", 12, "Assault", rolld(6), 5, 0, 1)
                        Case Is = "Demolisher cannon"
                            AllWargear.Rows.Add("Demolisher cannon", 24, "Heavy", rolld(3), 10, -3, rolld(6))
                        Case Is = "Disintergration combi-gun"
disintergrationcombigun:
                            Select Case CustomMsgbox("Boltgun, Disintegration gun or both", "Boltgun", "Disintegration gun", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Disintegration combi-gun - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Disintegration combi-gun - Disintegration gun", 18, "Rapid Fire", 1, 5, -3, rolld(6))
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo disintergrationcombigun
                                    'AllWargear.Rows.Add("Combi-flamer - Flamer", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo disintergrationcombigun
                            End Select
                            'AllWargear.Rows.Add("Disintegration combi-gun - Boltgun", 24, "Rapid Fire", 1, 4, 0, 1)
                            'AllWargear.Rows.Add("Disintegration combi-gun - Disintegration gun", 18, "Rapid Fire", 1, 5, -3, rolld(6))
                        Case Is = "Disintegration pistol"
                            AllWargear.Rows.Add("Disintegration pistol", 9, "Pistol", 1, 5, -3, rolld(6))
                        Case Is = "Flamer"
                            AllWargear.Rows.Add("Flamer", 8, "Assault", rolld(6), 4, 0, 1)
                        Case Is = "Flamestorm cannon"
                            AllWargear.Rows.Add("Flamestorm cannon", 8, "Heavy", rolld(6), 6, -2, 2)
                        Case Is = "Frag grenade"
                            AllWargear.Rows.Add("Frag grenade", 6, "Grenade", rolld(6), 3, 0, 1)
                        Case Is = "Grav-pistol"
                            AllWargear.Rows.Add("Grav-pistol", 12, "Pistol", 1, 5, -3, 1)
                        Case Is = "Grav-cannon and grav-amp"
                            AllWargear.Rows.Add("Grav-cannon and grav-amp", 24, "Heavy", 4, 5, -3, 1)
                        Case Is = "Grav-gun"
                            AllWargear.Rows.Add("Grav-gun", 18, "Rapid Fire", 1, 5, -3, 1)
                        Case Is = "Grenade harness"
                            AllWargear.Rows.Add("Grenade harness", 12, "Assault", rolld(6), 4, -1, 1)
                        Case Is = "Heavy bolter"
                            AllWargear.Rows.Add("Heavy bolter", 36, "Heavy", 3, 5, -1, 1)
                        Case Is = "Heavy flamer"
                            AllWargear.Rows.Add("Heavy flamer", 8, "Heavy", rolld(6), 5, -1, 1)
                        Case Is = "Heavy plasma cannon"
heavyplasmacannon:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Heavy plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                                Case Else
                                    GoTo heavyplasmacannon
                            End Select
                            'AllWargear.Rows.Add("Heavy plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                            'AllWargear.Rows.Add("Heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                        Case Is = "Hunter-killer missile"
                            AllWargear.Rows.Add("Hunter-killer missile", 48, "Heavy", 1, 8, -2, rolld(6))
                        Case Is = "Hurricane bolter"
                            AllWargear.Rows.Add("Hurricane bolter", 24, "Rapid Fire", 6, 4, 0, 1)
                        Case Is = "Icarus stormcannon"
                            AllWargear.Rows.Add("Icarus stormcannon", 48, "Heavy", 3, 7, -1, 2)
                        Case Is = "Kheres pattern assault cannon"
                            AllWargear.Rows.Add("Kheres pattern assault cannon", 24, "Heavy", 6, 7, -1, 1)
                        Case Is = "Krak grenade"
                            AllWargear.Rows.Add("Krak grenade", 6, "Grenade", 1, 6, -1, rolld(3))
                        Case Is = "Las-talon"
                            AllWargear.Rows.Add("Las-talon", 24, "Heavy", 2, 9, -3, rolld(6))
                        Case Is = "Lascannon"
                            AllWargear.Rows.Add("Lascannon", 48, "Heavy", 1, 9, -3, rolld(6))
                        Case Is = "Master-crafted auto bolt rifle"
                            AllWargear.Rows.Add("Master-crafted auto bolt rifle", 24, "Assault", 2, 4, 0, 2)
                        Case Is = "Master-crafted boltgun"
                            AllWargear.Rows.Add("Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                        Case Is = "Melta bomb"
                            AllWargear.Rows.Add("Melta bomb", 4, "Grenade", 1, 8, -4, rolld(6))
                        Case Is = "Meltagun"
                            AllWargear.Rows.Add("Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Missile launcher"
missilelauncher:
                            Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Missile launcher - Frag missile", 48, "Heavy", rolld(6), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Missile launcher - Krak missile", 48, "Heavy", 1, 8, -2, rolld(6))
                                Case Else
                                    GoTo missilelauncher
                            End Select
                            'AllWargear.Rows.Add("Missile launcher - Frag missile", 48, "Heavy", rolld(6), 4, 0, 1)
                            ' AllWargear.Rows.Add("Missile launcher - Krak missile", 48, "Heavy", 1, 8, -2, rolld(6))
                        Case Is = "Multi-melta"
                            AllWargear.Rows.Add("Multi-melta", 24, "Heavy", 1, 8, -4, rolld(6))
                        Case Is = "Orbital array"
                            AllWargear.Rows.Add("Orbital array", 72, "Heavy", rolld(3), 10, -4, rolld(6))
                        Case Is = "Plasma blaster"
plasmablaster:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma blaster - Standard", 18, "Assault", 2, 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma blaster - Supercharge", 18, "Assault", 2, 8, -3, 2)
                                Case Else
                                    GoTo plasmablaster
                            End Select
                            'AllWargear.Rows.Add("Plasma blaster - Standard", 18, "Assault", 2, 7, -3, 1)
                            'AllWargear.Rows.Add("Plasma blaster - Supercharge", 18, "Assault", 2, 8, -3, 2)
                        Case Is = "Plasma cannon"
plasmacannon:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                                Case Else
                                    GoTo plasmacannon
                            End Select
                        Case Is = "Plasma cutter"
plasmacutter:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma cannon - Standard", 36, "Heavy", rolld(3), 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma cannon - Supercharge", 36, "Heavy", rolld(3), 8, -3, 2)
                                Case Else
                                    GoTo plasmacutter
                            End Select
                        Case Is = "Plasma gun"
plasmagun:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma gun - Standard", 24, "Rapid Fire", 1, 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma gun - Supercharge", 24, "Rapid Fire", 1, 8, -3, 2)
                                Case Else
                                    GoTo plasmagun
                            End Select
                        Case Is = "Plasma incinerator"
plasmaincinerator:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma incinerator - Standard", 30, "Rapid Fire", 1, 7, -4, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma incinerator - Supercharge", 30, "Rapid Fire", 1, 8, -4, 2)
                                Case Else
                                    GoTo plasmaincinerator
                            End Select
                        Case Is = "Plasma pistol"
plasmapistol:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma pistol - Standard", 12, "Pistol", 1, 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma pistol - Supercharge", 12, "Pistol", 1, 8, -3, 2)
                                Case Else
                                    GoTo plasmapistol
                            End Select
                        Case Is = "Predator autocannon"
                            AllWargear.Rows.Add("Predator autocannon", 48, "Heavy", rolld(3) + rolld(3), 7, -1, 3)
                        Case Is = "Reaper autocannon"
                            AllWargear.Rows.Add("Reaper autocannon", 36, "Heavy", 4, 7, -1, 1)
                        Case Is = "Skyhammer missile launcher"
                            AllWargear.Rows.Add("Skyhammer missile launcher", 60, "Heavy", 3, 7, -1, rolld(3))
                        Case Is = "Skyspear missile launcher"
                            AllWargear.Rows.Add("Skyspear missile launcher", 60, "Heavy", 1, 9, -3, rolld(6))
                        Case Is = "Sniper rifle"
                            AllWargear.Rows.Add("Sniper rifle", 36, "Heavy", 1, 4, 0, 1)
                        Case Is = "Special issue boltgun"
                            AllWargear.Rows.Add("Special issue boltgun", 30, "Rapid Fire", 1, 4, -2, 1)
                        Case Is = "Storm bolter"
                            AllWargear.Rows.Add("Storm bolter", 24, "Rapid Fire", 2, 4, 0, 1)
                        Case Is = "Stormstrike missile launcher"
                            AllWargear.Rows.Add("Stormstrike missile launcher", 72, "Heavy", 1, 8, -3, 3)
                        Case Is = "Thunderfire cannon"
                            AllWargear.Rows.Add("Thunderfire cannon", 60, "Heavy", rolld(3) + rolld(3) + rolld(3) + rolld(3), 5, 0, 1)
                        Case Is = "Twin assault cannon"
                            AllWargear.Rows.Add("Twin assault cannon", 24, "Heavy", 12, 6, -1, 6) ' 1)
                        Case Is = "Twin autocannon"
                            AllWargear.Rows.Add("Twin autocannon", 48, "Heavy", 4, 7, -1, 2)
                        Case Is = "Twin boltgun"
                            AllWargear.Rows.Add("Twin boltgun", 24, "Rapid Fire", 2, 4, 0, 1)
                        Case Is = "Twin heavy bolter"
                            AllWargear.Rows.Add("Twin heavy bolter", 36, "Heavy", 6, 5, -1, 1)
                        Case Is = "Twin heavy flamer"
                            AllWargear.Rows.Add("Twin heavy flamer", 8, "Heavy", rolld(6) + rolld(6), 5, -1, 1)
                        Case Is = "Twin heavy plasma cannon"
twinheavyplasmacannon:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Twin heavy plasma cannon - Standard", 36, "Heavy", rolld(3) + rolld(3), 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Twin heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3) + rolld(3), 8, -3, 2)
                                Case Else
                                    GoTo twinheavyplasmacannon
                            End Select
                            'AllWargear.Rows.Add("Twin heavy plasma cannon - Standard", 36, "Heavy", rolld(3) + rolld(3), 7, -3, 1)
                            'AllWargear.Rows.Add("Twin heavy plasma cannon - Supercharge", 36, "Heavy", rolld(3) + rolld(3), 8, -3, 2)
                        Case Is = "Twin lascannon"
                            AllWargear.Rows.Add("Twin lascannon", 48, "Heavy", 2, 9, -3, rolld(6))
                        Case Is = "Twin multi-melta"
                            AllWargear.Rows.Add("Twin multi-melta", 24, "Heavy", 2, 8, -4, rolld(6))
                        Case Is = "Twin plasma gun"
twinplasmagun:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Twin plasma gun - Standard", 24, "Rapid Fire", 2, 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Twin plasma gun - Supercharge", 24, "Rapid Fire", 2, 8, -3, 2)
                                Case Else
                                    GoTo twinplasmagun
                            End Select
                            'AllWargear.Rows.Add("Twin plasma gun - Standard", 24, "Rapid Fire", 2, 7, -3, 1)
                            'AllWargear.Rows.Add("Twin plasma gun - Supercharge", 24, "Rapid Fire", 2, 8, -3, 2)
                        Case Is = "Typhoon missile launcher"
typhoonmissilelauncher:
                            Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Typhoon missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Typhoon missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                                Case Else
                                    GoTo typhoonmissilelauncher
                            End Select
                            'AllWargear.Rows.Add("Typhoon missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                            'AllWargear.Rows.Add("Typhoon missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                        Case Is = "Volkite charger"
                            AllWargear.Rows.Add("Volkite charger", 15, "Heavy", 2, 5, 0, 2)
                        Case Is = "Whirlwind castellan launcher"
                            AllWargear.Rows.Add("Whirlwind castellan launcher", 72, "Heavy", rolld(6) + rolld(6), 6, 0, 1)
                        Case Is = "Whirlwind vengeance launcher"
                            AllWargear.Rows.Add("Whirlwind vengeance launcher", 72, "Heavy", rolld(3) + rolld(3), 7, -1, 2)
                        Case Is = "Wrist-mounted grenade launcher"
                            AllWargear.Rows.Add("Wrist-mounted grenade launcher", 12, "Assault", rolld(3), 4, -1, 1)
                        Case Is = "Gauntlets of Ultramar"
                            AllWargear.Rows.Add("Gauntlets of Ultramar (shooting)", 24, "Rapid Fire", 2, 4, -1, 2)
                        Case Is = "Hand of Dominion"
                            AllWargear.Rows.Add("Hand of Dominion (shooting)", 24, "Rapid Fire", 3, 6, -1, 2)
                        Case Is = "Infernus"
infernus:
                            Select Case CustomMsgbox("Flamer or Master-crafted boltgun", "Flamer", "Master-crafted boltgun")
                                Case Is = 2
                                    AllWargear.Rows.Add("Infernus - Flamer", 24, "Assault", rolld(6), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Infernus - Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                                Case Else
                                    GoTo infernus
                            End Select
                            'AllWargear.Rows.Add("Infernus - Flamer", 24, "Assault", rolld(6), 4, 0, 1)
                            'AllWargear.Rows.Add("Infernus - Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                        Case Is = "Quietus"
                            AllWargear.Rows.Add("Quietus", 36, "Heavy", 2, 4, -1, rolld(3))
                        Case Is = "Dorn's arrow"
                            AllWargear.Rows.Add("Dorn's arrow", 24, "Assault", 4, 4, -1, 1)
                        Case Is = "Gauntlet of the forge"
                            AllWargear.Rows.Add("Gauntlet of the Forge", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Angelus boltgun"
                            AllWargear.Rows.Add("Angelus boltgun", 12, "Assault", 2, 4, -1, 1)
                        Case Is = "Blood Song"
bloodsong:
                            Select Case CustomMsgbox("Master-crafted boltgun or Meltagun", "Master-crafted boltgun", "Meltagun")
                                Case Is = 2
                                    AllWargear.Rows.Add("Blood Song -  Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Blood Song -  Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                                Case Else
                                    GoTo bloodsong
                            End Select
                            'AllWargear.Rows.Add("Blood Song -  Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                            'AllWargear.Rows.Add("Blood Song -  Meltagun", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Frag cannon"
                            AllWargear.Rows.Add("Frag cannon", 8, "Assault", rolld(6) + rolld(6), 6, -1, 1)
                        Case Is = "Hand flamer"
                            AllWargear.Rows.Add("Hand flamer", 6, "Pistol", rolld(3), 3, 0, 1)
                        Case Is = "Inferno pistol"
                            AllWargear.Rows.Add("Inferno pistol", 6, "Pistol", 1, 8, -4, rolld(6))
                        Case Is = "Avenger mega bolter"
                            AllWargear.Rows.Add("Avenger mega bolter", 36, "Heavy", 10, 6, -1, 1)
                        Case Is = "Blacksword missile launcher"
                            AllWargear.Rows.Add("Blacksword missile launcher", 36, "Heavy", 1, 7, -3, 2)
                        Case Is = "The Deliverer"
                            AllWargear.Rows.Add("The Deliverer", 12, "Pistol", 1, 4, -1, 2)
                        Case Is = "Lion's Wrath"
lionswrath:
                            Select Case CustomMsgbox("Master-crafted boltgun, Standard or Supercharge", "Master-crafted boltgun", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma gun - Standard", 24, "Rapid Fire", 1, 7, -3, 1)
                                Case Is = 4
                                    AllWargear.Rows.Add("Plasma gun - Supercharge", 24, "Rapid Fire", 1, 8, -3, 2)
                                Case Else
                                    GoTo lionswrath
                            End Select
                            'AllWargear.Rows.Add("Master-crafted boltgun", 24, "Rapid Fire", 1, 4, -1, 2)
                            'AllWargear.Rows.Add("Plasma gun - Standard", 24, "Rapid Fire", 1, 7, -3, 1)
                            'AllWargear.Rows.Add("Plasma gun - Supercharge", 24, "Rapid Fire", 1, 8, -3, 2)
                        Case Is = "Plasma storm battery"
plasmastormbattery:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma storm battery - Standard", 36, "Heavy", rolld(6), 7, -3, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma storm battery - Supercharge", 36, "Heavy", rolld(6), 8, -3, 3)
                                Case Else
                                    GoTo plasmastormbattery
                            End Select
                            'AllWargear.Rows.Add("Plasma storm battery - Standard", 36, "Heavy", rolld(6), 7, -3, 2)
                            'AllWargear.Rows.Add("Plasma storm battery - Supercharge", 36, "Heavy", rolld(6), 8, -3, 3)
                        Case Is = "Plasma talon"
plasmatalon:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Plasma talon - Standard", 36, "Assault", 2, 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Plasma talon - Supercharge", 36, "Assault", 2, 8, -3, 2)
                                Case Else
                                    GoTo plasmatalon
                            End Select
                            AllWargear.Rows.Add("Plasma talon - Standard", 36, "Assault", 2, 7, -3, 1)
                            AllWargear.Rows.Add("Plasma talon - Supercharge", 36, "Assault", 2, 8, -3, 2)
                        Case Is = "Ravenwing grenade launcher"
ravenwinggrenadelauncher:
                            Select Case CustomMsgbox("Frag or krak shell", "Frag shell", "Krak shell")
                                Case Is = 2
                                    AllWargear.Rows.Add("Ravenwing grenade launcher - Frag shell", 36, "Assault", rolld(6), 3, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Ravenwing grenade launcher - Krak shell", 36, "Assault", 2, 6, -1, rolld(3))
                                Case Else
                                    GoTo ravenwinggrenadelauncher
                            End Select
                            'AllWargear.Rows.Add("Ravenwing grenade launcher - Frag shell", 36, "Assault", rolld(6), 3, 0, 1)
                            'AllWargear.Rows.Add("Ravenwing grenade launcher - Krak shell", 36, "Assault", 2, 6, -1, rolld(3))
                        Case Is = "Redemption missile silo"
redemptionmissilesilo:
                            Select Case CustomMsgbox("Fragstorm or krakstorm missile", "Fragstorm missile", "krakstorm missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Redemption missile silo - Fragstorm missile", 96, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Redemption missile silo - Krakstorm missile", 96, "Heavy", rolld(6), 8, -3, rolld(3))
                                Case Else
                                    GoTo redemptionmissilesilo
                            End Select
                            'AllWargear.Rows.Add("Redemption missile silo - Fragstorm missile", 96, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                            'AllWargear.Rows.Add("Redemption missile silo - Krakstorm missile", 96, "Heavy", rolld(6), 8, -3, rolld(3))
                        Case Is = "Rift cannon"
                            AllWargear.Rows.Add("Rift cannon", 18, "Heavy", rolld(3), 10, -3, 3)
                        Case Is = "Twin Icarus lascannon"
                            AllWargear.Rows.Add("Twin Icarus lascannon", 96, "Heavy", rolld(6) + rolld(6), 9, -3, rolld(6))
                        Case Is = "Twin storm bolter"
                            AllWargear.Rows.Add("Twin storm bolter", 24, "Rapid Fire", 4, 4, 0, 1)
                        Case Is = "Foehammer (shooting)"
                            AllWargear.Rows.Add("Foehammer (shooting)", 12, "Assault", 1, 4, -3, rolld(3)) 'strength x2
                        Case Is = "Helfrost cannon"
helfrostcannon:
                            Select Case CustomMsgbox("Dispersed or Focused beam", "Dispersed beam", "Focused beam")
                                Case Is = 2
                                    AllWargear.Rows.Add("Helfrost cannon - Dispersed beam", 24, "Heavy", rolld(3), 6, -2, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Helfrost cannon - Focused beam", 24, "Heavy", 1, 8, -4, rolld(6))
                                Case Else
                                    GoTo helfrostcannon
                            End Select
                            'AllWargear.Rows.Add("Helfrost cannon - Dispersed beam", 24, "Heavy", rolld(3), 6, -2, 1)
                            'AllWargear.Rows.Add("Helfrost cannon - Focused beam", 24, "Heavy", 1, 8, -4, rolld(6))
                        Case Is = "Helfrost destructor"
helfrostdestructor:
                            Select Case CustomMsgbox("Dispersed or Focused beam", "Dispersed beam", "Focused beam")
                                Case Is = 2
                                    AllWargear.Rows.Add("Helfrost destructor - Dispersed beam", 24, "Heavy", rolld(3) + rolld(3) + rolld(3), 6, -2, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Helfrost destructor - Focused beam", 24, "Heavy", 3, 8, -4, rolld(6))
                                Case Else
                                    GoTo helfrostdestructor
                            End Select
                            'AllWargear.Rows.Add("Helfrost destructor - Dispersed beam", 24, "Heavy", rolld(3) + rolld(3) + rolld(3), 6, -2, 2)
                            'AllWargear.Rows.Add("Helfrost destructor - Focused beam", 24, "Heavy", 3, 8, -4, rolld(6))
                        Case Is = "Helfrost pistol"
                            AllWargear.Rows.Add("Helfrost pistol", 12, "Pistol", 1, 8, -4, rolld(3))
                        Case Is = "Nightwing"
                            AllWargear.Rows.Add("Nightwing", 12, "Assault", rolld(6), 3, 0, 1)
                        Case Is = "Stormfrag auto-launcher"
                            AllWargear.Rows.Add("Stormfrag auto-launcher", 12, "Assault", rolld(3), 4, 0, 1)
                        Case Is = "Blackstar rocket launcher"
blackstarrocketlauncher:
                            Select Case CustomMsgbox("Corvid or Dracos warhead", "Corvid warhead", "Dracos warhead")
                                Case Is = 2
                                    AllWargear.Rows.Add("Blackstar rocket launcher - Corvid warhead", 30, "Heavy", rolld(6), 6, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Blackstar rocket launcher - Dracos warhead", 30, "Heavy", rolld(6), 4, 0, 1)
                                Case Else
                                    GoTo blackstarrocketlauncher
                            End Select
                            'AllWargear.Rows.Add("Blackstar rocket launcher - Corvid warhead", 30, "Heavy", rolld(6), 6, -1, 1)
                            'AllWargear.Rows.Add("Blackstar rocket launcher - Dracos warhead", 30, "Heavy", rolld(6), 4, 0, 1)
                        Case Is = "Deathwatch frag cannon"
deathwatchfragcannon:
                            Select Case CustomMsgbox("Frag round or Shell", "Frag round", "Shell")
                                Case Is = 2
                                    AllWargear.Rows.Add("Deathwatch frag cannon - Frag round", 8, "Assault", rolld(6) + rolld(6), 6, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Deathwatch frag cannon - Shell", 24, "Assault", 2, 6, -1, 1)
                                Case Else
                                    GoTo deathwatchfragcannon
                            End Select
                            'AllWargear.Rows.Add("Deathwatch frag cannon - Frag round", 8, "Assault", rolld(6) + rolld(6), 6, -1, 1)
                            'AllWargear.Rows.Add("Deathwatch frag cannon - Shell", 24, "Assault", 2, 6, -1, 1)
                        Case Is = "Deathwatch shotgun"
deathwatchshotgun:
                            Select Case CustomMsgbox("Cryptclearer round, Xenopurge slug or Wyrmsbreath shell", "Cryptclearer round", "Xenopurge slug", "Wyrmsbreath shell")
                                Case Is = 2
                                    AllWargear.Rows.Add("Deathwatch shotgun - Cryptclearer round", 16, "Assault", 2, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Deathwatch shotgun - Xenopurge slug", 16, "Assault", 2, 4, -1, 1)
                                Case Is = 4
                                    AllWargear.Rows.Add("Deathwatch shotgun - Wyrmsbreath shell", 7, "Assault", rolld(6), 3, 0, 1)
                                Case Else
                                    GoTo deathwatchshotgun
                            End Select
                            'AllWargear.Rows.Add("Deathwatch shotgun - Cryptclearer round", 16, "Assault", 2, 4, 0, 1)
                            'AllWargear.Rows.Add("Deathwatch shotgun - Xenopurge slug", 16, "Assault", 2, 4, -1, 1)
                            'AllWargear.Rows.Add("Deathwatch shotgun - Wyrmsbreath shell", 7, "Assault", rolld(6), 3, 0, 1)
                        Case Is = "Guardian spear (shooting)"
                            AllWargear.Rows.Add("Guardian spear (shooting)", 24, "Rapid fire", 1, 4, -1, 2)
                        Case Is = "Hellfire Extremis"
hellfireextremis:
                            Select Case CustomMsgbox("Hellfire flamer or Boltgun", "Hellfire flamer", "Boltgun")
                                Case Is = 2
                                    Console.WriteLine("currently not implented")
                                    GoTo hellfireextremis
                                    'AllWargear.Rows.Add("Hellfire Extremis - Hellfire flamer", 8, "Assault", rolld(6), *, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Hellfire Extremis - Boltgun", 24, "Rapid fire", 1, 4, 0, 1)
                                Case Else
                                    GoTo hellfireextremis
                            End Select
                            ' 'AllWargear.Rows.Add("Hellfire Extremis - Hellfire flamer", 8, "Assault", rolld(6), *, 0, 1)
                            ' AllWargear.Rows.Add("Hellfire Extremis - Boltgun", 24, "Rapid fire", 1, 4, 0, 1)
                        Case Is = "Infernus heavy bolter"
infernusheavybolter:
                            Select Case CustomMsgbox("Infernus heavy Bolter or Infernus heavy flamer", "Infernus heavy Bolter", "Infernus heavy flamer")
                                Case Is = 2
                                    AllWargear.Rows.Add("Infernus heavy bolter - Heavy bolter", 36, "Heavy", 3, 5, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Infernus heavy bolter - Heavy flamer", 8, "Assault", rolld(6), 5, -1, 1)
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo infernusheavybolter
                                Case Else
                                    GoTo infernusheavybolter
                            End Select
                            'AllWargear.Rows.Add("Infernus heavy bolter - Heavy bolter", 36, "Heavy", 3, 5, -1, 1)
                            'AllWargear.Rows.Add("Infernus heavy bolter - Heavy flamer", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Stalker pattern boltgun"
                            AllWargear.Rows.Add("Stalker pattern boltgun", 30, "Heavy", 2, 4, 0, 1)
                            'imperium2
                        Case Is = "Artillery barrage"
                            AllWargear.Rows.Add("Artillery barrage", 100, "Heavy", rolld(6), 8, -2, rolld(3))
                        Case Is = "Autocannon"
                            AllWargear.Rows.Add("Autocannon", 48, "Heavy", 2, 7, -1, 2)
                        Case Is = "Bale Eye"
                            AllWargear.Rows.Add("Bale Eye", 6, "Pistol", 1, 3, -2, 1)
                        Case Is = "Baneblade cannon"
                            AllWargear.Rows.Add("Baneblade cannon", 72, "Heavy", rolld(6) + rolld(6), 9, -3, 3)
                        Case Is = "Battle cannon"
                            AllWargear.Rows.Add("Battle cannon", 72, "Heavy", rolld(6), 8, -2, rolld(3))
                        Case Is = "Demolition charge"
                            AllWargear.Rows.Add("Demolition charge", 6, "Grenade", rolld(6), 8, -3, rolld(3))
                        Case Is = "Earthshaker cannon"
                            AllWargear.Rows.Add("Earthshaker cannon", 240, "Heavy", rolld(6), 9, -2, rolld(3))
                        Case Is = "Eradicator nova cannon"
                            AllWargear.Rows.Add("Eradicator nova cannon", 36, "Heavy", rolld(6), 6, -2, rolld(3))
                        Case Is = "Executioner plasma cannon"
executionerplasmacannon:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Executioner plasma cannon - Standard", 36, "Heavy", rolld(6), 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Executioner plasma cannon - Supercharge", 36, "Heavy", rolld(6), 8, -3, 2)
                                Case Else
                                    GoTo executionerplasmacannon
                            End Select
                            'AllWargear.Rows.Add("Executioner plasma cannon - Standard", 36, "Heavy", rolld(6), 7, -3, 1)
                            'AllWargear.Rows.Add("Executioner plasma cannon - Supercharge", 36, "Heavy", rolld(6), 8, -3, 2)
                        Case Is = "Exterminator autocannon"
                            AllWargear.Rows.Add("Exterminator autocannon", 48, "Heavy", 4, 7, -1, 2)
                        Case Is = "Frag bomb"
                            AllWargear.Rows.Add("Frag bomb", 6, "Grenade", rolld(6), 4, 0, 1)
                        Case Is = "Grenade launcher"
grenadelauncher:
                            Select Case CustomMsgbox("Frag or krak grenade", "Frag grenade", "Krak grenade")
                                Case Is = 2
                                    AllWargear.Rows.Add("Grenade launcher - Frag grenade", 24, "Assault", rolld(6), 3, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Grenade launcher - Krak grenade", 24, "Assault", 1, 6, -1, rolld(3))
                                Case Else
                                    GoTo grenadelauncher
                            End Select
                            'AllWargear.Rows.Add("Grenade launcher - Frag grenade", 24, "Assault", rolld(6), 3, 0, 1)
                            'AllWargear.Rows.Add("Grenade launcher - Krak grenade", 24, "Assault", 1, 6, -1, rolld(3))
                        Case Is = "Grenadier gauntlet"
                            AllWargear.Rows.Add("Grenadier gauntlet", 12, "Assault", rolld(6), 4, 0, 1)
                        Case Is = "Heavy stubber"
                            AllWargear.Rows.Add("Heavy stubber", 36, "Heavy", 3, 4, 0, 1)
                        Case Is = "Hellhammer cannon"
                            AllWargear.Rows.Add("Hellhammer cannon", 36, "Heavy", rolld(6) + rolld(6), 10, -4, 3)
                        Case Is = "Hellstrike missiles"
                            AllWargear.Rows.Add("Hellstrike missiles", 72, "Heavy", 1, 8, -2, rolld(6))
                        Case Is = "Hot-shot lasgun"
                            AllWargear.Rows.Add("Hot-shot lasgun", 18, "Rapid Fire", 1, 3, -2, 1)
                        Case Is = "Hot-shot laspistol"
                            AllWargear.Rows.Add("Hot-shot laspistol", 6, "Pistol", 1, 3, -2, 1)
                        Case Is = "Hot-shot volley gun"
                            AllWargear.Rows.Add("Hot-shot volley gun", 24, "Heavy", 4, 4, -2, 1)
                        Case Is = "Hydra quad autocannon"
                            AllWargear.Rows.Add("Hydra quad autocannon", 72, "Heavy", 8, 7, -1, 2)
                        Case Is = "Inferno cannon"
                            AllWargear.Rows.Add("Inferno cannon", 16, "Heavy", rolld(6), 6, -1, 2)
                        Case Is = "Lasgun"
                            AllWargear.Rows.Add("Lasgun", 24, "Rapid Fire", 1, 3, 0, 1)
                        Case Is = "Lasgun array"
                            AllWargear.Rows.Add("Lasgun array", 24, "Rapid Fire", 3, 3, 0, 1)
                        Case Is = "Laspistol"
                            AllWargear.Rows.Add("Laspistol", 12, "Pistol", 1, 3, 0, 1)
                        Case Is = "Magma cannon"
                            AllWargear.Rows.Add("Magma cannon", 60, "Heavy", rolld(6), 10, -5, rolld(6))
                        Case Is = "Melta cannon"
                            AllWargear.Rows.Add("Melta cannon", 24, "Heavy", rolld(3), 8, -4, rolld(6))
                        Case Is = "Mortar"
                            AllWargear.Rows.Add("Mortar", 48, "Heavy", rolld(6), 4, 0, 1)
                        Case Is = "Multi-laser"
                            AllWargear.Rows.Add("Multi-laser", 36, "Heavy", 3, 6, 0, 1)
                        Case Is = "Multiple rocket pod"
                            AllWargear.Rows.Add("Multiple rocket pod", 36, "Heavy", rolld(6), 5, -1, 1)
                        Case Is = "Payback"
                            AllWargear.Rows.Add("Payback", 36, "Assault", 3, 5, -2, 1)
                        Case Is = "Punisher gatling cannon"
                            AllWargear.Rows.Add("Punisher gatling cannon", 24, "Heavy", 20, 5, 0, 1)
                        Case Is = "Quake cannon"
                            AllWargear.Rows.Add("Quake cannon", 140, "Heavy", rolld(6), 14, -4, rolld(6))
                        Case Is = "Ripper gun"
                            AllWargear.Rows.Add("Ripper gun", 12, "Assault", 3, 5, 0, 1)
                        Case Is = "Shotgun"
                            AllWargear.Rows.Add("Shotgun", 12, "Assault", 2, 3, 0, 1)
                        Case Is = "Storm eagle rockets"
                            AllWargear.Rows.Add("Storm eagle rockets", 120, "Heavy", rolld(6) + rolld(6), 10, -2, rolld(3))
                        Case Is = "Stormsword siege cannon"
                            AllWargear.Rows.Add("Stormsword siege cannon", 36, "Heavy", rolld(6), 10, -4, rolld(6))
                        Case Is = "Taurox battle cannon"
                            AllWargear.Rows.Add("Taurox battle cannon", 48, "Heavy", rolld(6), 7, -1, rolld(3))
                        Case Is = "Taurox gatling cannon"
                            AllWargear.Rows.Add("Taurox gatling cannon", 24, "Heavy", 20, 4, 0, 1)
                        Case Is = "Taurox missile launcher"
tauroxmissilelauncher:
                            Select Case CustomMsgbox("Frag or krak missile", "Frag missile", "Krak missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Taurox missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Taurox missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                                Case Else
                                    GoTo tauroxmissilelauncher
                            End Select
                            ' AllWargear.Rows.Add("Taurox missile launcher - Frag missile", 48, "Heavy", rolld(6) + rolld(6), 4, 0, 1)
                            'AllWargear.Rows.Add("Taurox missile launcher - Krak missile", 48, "Heavy", 2, 8, -2, rolld(6))
                        Case Is = "Tremor cannon"
                            AllWargear.Rows.Add("Tremor cannon", 60, "Heavy", rolld(6) + rolld(6), 8, -2, 3)
                        Case Is = "Vanquisher battle cannon"
                            AllWargear.Rows.Add("Vanquisher battle cannon", 72, "Heavy", 1, 8, -3, rolld(6))
                        Case Is = "Volcano cannon"
                            AllWargear.Rows.Add("Volcano cannon", 120, "Heavy", rolld(6), 16, -5, rolld(6) + rolld(6))
                        Case Is = "Vulcan mega-bolter"
                            AllWargear.Rows.Add("Vulcan mega-bolter", 60, "Heavy", 20, 6, -2, 2)
                        Case Is = "Wyvern quad stormshard mortar"
                            AllWargear.Rows.Add("Wyvern quad stormshard mortar", 48, "Heavy", rolld(6) + rolld(6) + rolld(6) + rolld(6), 4, 0, 1)
                        Case Is = "Aeldari missile launcher"
aeldarimissilelauncher:
                            Select Case CustomMsgbox("Sunburst or Starshot missile", "Sunburst missile", "Starshot missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6), 4, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Aeldari missile launcher - Starshot missile", 48, "Heavy", 1, 8, -2, rolld(6))
                                Case Else
                                    GoTo aeldarimissilelauncher
                            End Select
                            ' AllWargear.Rows.Add("Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6), 4, -1, 1)
                            'AllWargear.Rows.Add("Aeldari missile launcher - Starshot missile", 48, "Heavy", 1, 8, -2, rolld(6))
                        Case Is = "Avenger shuriken catapult"
                            AllWargear.Rows.Add("Avenger shuriken catapult", 18, "Assault", 2, 4, 0, 1)
                        Case Is = "Bright lance"
                            AllWargear.Rows.Add("Bright lance", 36, "Heavy", 1, 8, -4, rolld(6))
                        Case Is = "Chainsabres (shooting)"
                            AllWargear.Rows.Add("Chainsabres (shooting)", 12, "Pistol", 2, 4, 0, 1)
                        Case Is = "Death spinner"
                            AllWargear.Rows.Add("Death spinner", 12, "Assault", 2, 6, 0, 1)
                        Case Is = "Doomweaver"
                            AllWargear.Rows.Add("Doomweaver", 48, "Heavy", rolld(6) + rolld(6), 7, 0, 2)
                        Case Is = "Dragon’s breath flamer"
                            AllWargear.Rows.Add("Dragon’s breath flamer", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "D-cannon"
                            AllWargear.Rows.Add("D-cannon", 24, "Heavy", rolld(3), 10, -4, rolld(6))
                        Case Is = "D-scythe"
                            AllWargear.Rows.Add("D-scythe", 8, "Assault", rolld(3), 10, -4, 1)
                        Case Is = "The Eye of Wrath"
                            AllWargear.Rows.Add("The Eye of Wrath", 3, "Pistol", rolld(6), 6, -2, 1)
                        Case Is = "Firepike"
                            AllWargear.Rows.Add("Firepike", 18, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Fusion gun"
                            AllWargear.Rows.Add("Fusion gun", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Fusion pistol"
                            AllWargear.Rows.Add("Fusion pistol", 6, "Pistol", 1, 8, -4, rolld(6))
                        Case Is = "Hawk’s talon"
                            AllWargear.Rows.Add("Hawk’s talon", 24, "Assault", 4, 5, 0, 1)
                        Case Is = "Heavy D-scythe"
                            AllWargear.Rows.Add("Heavy D-scythe", 16, "Assault", rolld(3), 10, -4, 2)
                        Case Is = "Heavy wraithcannon"
                            AllWargear.Rows.Add("Heavy wraithcannon", 36, "Assault", 2, 10, -4, rolld(6))
                        Case Is = "Lasblaster"
                            AllWargear.Rows.Add("Lasblaster", 24, "Rapid Fire", 2, 3, 0, 1)
                        Case Is = "Laser lance (shooting)"
                            AllWargear.Rows.Add("Laser lance (shooting)", 6, "Assault", 1, 6, -4, 2)
                        Case Is = "The Maugetar (shooting)"
themaugetar:
                            Select Case CustomMsgbox("Shrieker or Shuriken", "Shrieker", "Shuriken")
                                Case Is = 2
                                    AllWargear.Rows.Add("The Maugetar (shooting) - Shrieker", 36, "Assault", 1, 6, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("The Maugetar (shooting) - Shuriken", 36, "Assault", 4, 6, -1, 1)
                                Case Else
                                    GoTo themaugetar
                            End Select
                            AllWargear.Rows.Add("The Maugetar (shooting) - Shrieker", 36, "Assault", 1, 6, -1, 1)
                            'Case Is = "- Shuriken"
                            AllWargear.Rows.Add("The Maugetar (shooting) - Shuriken", 36, "Assault", 4, 6, -1, 1)
                        Case Is = "Prism cannon"
prismcannon:
                            Select Case CustomMsgbox("Dispersed, Focused or Lance", "Dispersed", "Focused", "Lance")
                                Case Is = 2
                                    AllWargear.Rows.Add("Prism cannon - Dispersed", 60, "Heavy", rolld(6), 6, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Prism cannon - Focused", 60, "Heavy", rolld(3), 9, -4, rolld(3))
                                Case Is = 4
                                    AllWargear.Rows.Add("Prism cannon - Lance", 60, "Heavy", 1, 12, -5, rolld(6))
                                Case Else
                                    GoTo prismcannon
                            End Select
                            'AllWargear.Rows.Add("Prism cannon - Dispersed", 60, "Heavy", rolld(6), 6, -3, 1)
                            'AllWargear.Rows.Add("Prism cannon - Focused", 60, "Heavy", rolld(3), 9, -4, rolld(3))
                            'AllWargear.Rows.Add("Prism cannon - Lance", 60, "Heavy", 1, 12, -5, rolld(6))
                        Case Is = "Pulse laser"
                            AllWargear.Rows.Add("Pulse laser", 48, "Heavy", 2, 8, -3, 3)
                        Case Is = "Ranger long rifle"
                            AllWargear.Rows.Add("Ranger long rifle", 36, "Heavy", 1, 4, 0, 1)
                        Case Is = "Reaper launcher"
reaperlauncher:
                            Select Case CustomMsgbox("Starshot or Starswarm missile", "Starshot missile", "Starswarm missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Reaper launcher - Starshot missile", 48, "Heavy", 1, 8, -2, 3)
                                Case Is = 3
                                    AllWargear.Rows.Add("Reaper launcher - Starswarm missile", 48, "Heavy", 2, 5, -2, 2)
                                Case Else
                                    GoTo reaperlauncher
                            End Select
                            'AllWargear.Rows.Add("Reaper launcher - Starshot missile", 48, "Heavy", 1, 8, -2, 3)
                            'AllWargear.Rows.Add("Reaper launcher - Starswarm missile", 48, "Heavy", 2, 5, -2, 2)
                        Case Is = "Scatter laser"
                            AllWargear.Rows.Add("Scatter laser", 36, "Heavy", 4, 6, 0, 1)
                        Case Is = "Scorpion’s claw (shooting)"
                            AllWargear.Rows.Add("Scorpion’s claw (shooting)", 12, "Assault", 2, 4, 0, 1)
                        Case Is = "Shadow weaver"
                            AllWargear.Rows.Add("Shadow weaver", 48, "Heavy", rolld(6), 6, 0, 1)
                        Case Is = "Shuriken cannon"
                            AllWargear.Rows.Add("Shuriken cannon", 24, "Assault", 3, 6, 0, 1)
                        Case Is = "Shuriken catapult"
                            AllWargear.Rows.Add("Shuriken catapult", 12, "Assault", 2, 4, 0, 1)
                        Case Is = "Shuriken pistol"
                            AllWargear.Rows.Add("Shuriken pistol", 12, "Pistol", 1, 4, 0, 1)
                        Case Is = "Singing spear (shooting)"
                            AllWargear.Rows.Add("Singing spear (shooting)", 12, "Assault", 1, 9, 0, rolld(3))
                        Case Is = "Spinneret rifle"
                            AllWargear.Rows.Add("Spinneret rifle", 18, "Rapid Fire", 1, 6, -4, 1)
                        Case Is = "Star lance (shooting)"
                            AllWargear.Rows.Add("Star lance (shooting)", 6, "Assault", 1, 8, -4, 2)
                        Case Is = "Starcannon"
                            AllWargear.Rows.Add("Starcannon", 36, "Heavy", 2, 6, -3, 3)
                        Case Is = "Sunburst grenade"
                            AllWargear.Rows.Add("Sunburst grenade", 6, "Grenade", rolld(6), 4, -1, 1)
                        Case Is = "Suncannon"
                            AllWargear.Rows.Add("Suncannon", 48, "Heavy", rolld(6) + rolld(6), 6, -3, rolld(3))
                        Case Is = "Sunrifle"
                            AllWargear.Rows.Add("Sunrifle", 24, "Assault", 4, 3, -2, 1)
                        Case Is = "Tempest launcher"
                            AllWargear.Rows.Add("Tempest launcher", 36, "Heavy", rolld(6) + rolld(6), 4, -2, 1)
                        Case Is = "Triskele (shooting)"
                            AllWargear.Rows.Add("Triskele (shooting)", 12, "Assault", 3, 3, -2, 1)
                        Case Is = "Twin Aeldari missile launcher"
twinaeldarimissilelauncher:
                            Select Case CustomMsgbox("Sunburst or Starshot missile", "Sunburst missile", "Starshot missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Twin Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6) + rolld(6), 4, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Twin Aeldari missile launcher - Starshot missile", 48, "Heavy", 2, 8, -2, rolld(6))
                                Case Else
                                    GoTo twinaeldarimissilelauncher
                            End Select
                            'AllWargear.Rows.Add("Twin Aeldari missile launcher - Sunburst missile", 48, "Heavy", rolld(6) + rolld(6), 4, -1, 1)
                            'AllWargear.Rows.Add("Twin Aeldari missile launcher - Starshot missile", 48, "Heavy", 2, 8, -2, rolld(6))
                        Case Is = "Twin bright lance"
                            AllWargear.Rows.Add("Twin bright lance", 36, "Heavy", 2, 8, -4, rolld(6))
                        Case Is = "Twin scatter laser"
                            AllWargear.Rows.Add("Twin scatter laser", 36, "Heavy", 8, 6, 0, 1)
                        Case Is = "Twin shuriken cannon"
                            AllWargear.Rows.Add("Twin shuriken cannon", 24, "Assault", 6, 6, 0, 1)
                        Case Is = "Twin shuriken catapult"
                            AllWargear.Rows.Add("Twin shuriken catapult", 12, "Assault", 4, 4, 0, 1)
                        Case Is = "Twin starcannon"
                            AllWargear.Rows.Add("Twin starcannon", 36, "Heavy", 4, 6, -3, 3)
                        Case Is = "Vibro cannon"
                            AllWargear.Rows.Add("Vibro cannon", 48, "Heavy", 1, 7, -1, rolld(3))
                        Case Is = "Voidbringer"
                            AllWargear.Rows.Add("Voidbringer", 48, "Heavy", 1, 4, -3, rolld(3))
                        Case Is = "The Wailing Doom (shooting)"
                            AllWargear.Rows.Add("The Wailing Doom (shooting)", 12, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Wraithcannon"
                            AllWargear.Rows.Add("Wraithcannon", 12, "Assault", 1, 10, -4, rolld(6))
                        Case Is = "Baleblast"
                            AllWargear.Rows.Add("Baleblast", 18, "Assault", 2, 4, -1, 1)
                        Case Is = "Blast pistol"
                            AllWargear.Rows.Add("Blast pistol", 6, "Pistol", 1, 8, -4, rolld(3))
                        Case Is = "Blaster"
                            AllWargear.Rows.Add("Blaster", 18, "Assault", 1, 8, -4, rolld(3))
                        Case Is = "Casket of Flensing"
                            AllWargear.Rows.Add("Casket of Flensing", 12, "Assault", rolld(6) + rolld(6), 3, -2, 1)
                        Case Is = "Dark lance"
                            AllWargear.Rows.Add("Dark lance", 36, "Heavy", 1, 8, -4, rolld(6))
                        Case Is = "Dark scythe"
                            AllWargear.Rows.Add("Dark scythe", 24, "Assault", rolld(3), 8, -4, rolld(3))
                        Case Is = "Darklight grenade"
                            AllWargear.Rows.Add("Darklight grenade", 6, "Grenade", rolld(6), 4, -1, 1)
                        Case Is = "Disintegrator cannon"
                            AllWargear.Rows.Add("Disintegrator cannon", 36, "Assault", 3, 5, -3, 2)
                        Case Is = "Eyeburst"
                            AllWargear.Rows.Add("Eyeburst", 9, "Assault", 4, 4, -2, 1)
                        Case Is = "Haywire blaster"
                            AllWargear.Rows.Add("Haywire blaster", 24, "Assault", 1, 4, -1, 1)
                        Case Is = "Heat lance"
                            AllWargear.Rows.Add("Heat lance", 18, "Assault", 1, 6, -5, rolld(6))
                        Case Is = "Hexrifle"
                            AllWargear.Rows.Add("Hexrifle", 36, "Heavy", 1, 4, -1, 1)
                        Case Is = "Phantasm grenade launcher"
                            AllWargear.Rows.Add("Phantasm grenade launcher", 18, "Assault", rolld(3), 1, 0, 1)
                        Case Is = "Razorwing missiles"
razorwingmissiles:
                            Select Case CustomMsgbox("Monoscythe or Shatterfield missile", "Monoscythe missile", "Shatterfield missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Razorwing missiles - Monoscythe missile", 48, "Assault", rolld(6), 6, 0, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Razorwing missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                                Case Else
                                    GoTo razorwingmissiles
                            End Select
                            'AllWargear.Rows.Add("Razorwing missiles - Monoscythe missile", 48, "Assault", rolld(6), 6, 0, 2)
                            'AllWargear.Rows.Add("Razorwing missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                        Case Is = "Shredder"
                            AllWargear.Rows.Add("Shredder", 12, "Assault", rolld(3), 6, 0, 1)
                        Case Is = "Spirit syphon"
                            AllWargear.Rows.Add("Spirit syphon", 8, "Assault", rolld(6), 3, -2, 1)
                        Case Is = "Spirit vortex"
                            AllWargear.Rows.Add("Spirit vortex", 18, "Assault", rolld(6), 3, -2, 1)
                        Case Is = "Stinger pod"
                            AllWargear.Rows.Add("Stinger pod", 24, "Assault", rolld(6) + rolld(6), 5, 0, 1)
                        Case Is = "Void lance"
                            AllWargear.Rows.Add("Void lance", 36, "Assault", 1, 9, -4, rolld(6))
                        Case Is = "Voidraven missiles"
voidravenmissiles:
                            Select Case CustomMsgbox("Implosion or Shatterfield missile", "Implosion missile", "Shatterfield missile")
                                Case Is = 2
                                    AllWargear.Rows.Add("Voidraven missiles - Implosion missile", 48, "Assault", rolld(3), 6, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Voidraven missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                                Case Else
                                    GoTo voidravenmissiles
                            End Select
                            'AllWargear.Rows.Add("Voidraven missiles - Implosion missile", 48, "Assault", rolld(3), 6, -3, 1)
                            'AllWargear.Rows.Add("Voidraven missiles - Shatterfield missile", 48, "Assault", rolld(6), 7, -1, 1)
                        Case Is = "Haywire cannon"
                            AllWargear.Rows.Add("Haywire cannon", 24, "Heavy", rolld(3), 4, -1, 1)
                        Case Is = "Neuro disruptor"
                            AllWargear.Rows.Add("Neuro disruptor", 12, "Pistol", 1, 3, -3, rolld(3))
                        Case Is = "Prismatic cannon"
prismaticcannon:
                            Select Case CustomMsgbox("Dispersed, Focused or Lance", "Dispersed", "Focused", "Lance")
                                Case Is = 2
                                    AllWargear.Rows.Add("Prismatic cannon - Dispersed", 24, "Heavy", rolld(6), 4, -2, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Prismatic cannon - Focused", 24, "Heavy", rolld(3), 6, -3, rolld(3))
                                Case Is = 4
                                    AllWargear.Rows.Add("Prismatic cannon - Lance", 24, "Heavy", 1, 8, -4, rolld(6))
                                Case Else
                                    GoTo prismaticcannon
                            End Select
                            'AllWargear.Rows.Add("Prismatic cannon - Dispersed", 24, "Heavy", rolld(6), 4, -2, 1)
                            'AllWargear.Rows.Add("Prismatic cannon - Focused", 24, "Heavy", rolld(3), 6, -3, rolld(3))
                            'AllWargear.Rows.Add("Prismatic cannon - Lance", 24, "Heavy", 1, 8, -4, rolld(6))
                        Case Is = "Prismatic grenade"
                            AllWargear.Rows.Add("Prismatic grenade", 6, "Grenade", rolld(6), 4, -1, 1)
                        Case Is = "Shrieker cannon"
shriekercannon:
                            Select Case CustomMsgbox("Shrieker or Shuriken", "Shrieker", "Shuriken")
                                Case Is = 2
                                    AllWargear.Rows.Add("Shrieker cannon - Shrieker", 24, "Assault", 1, 6, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Shrieker cannon - Shuriken", 24, "Assault", 3, 6, 0, 1)
                                Case Else
                                    GoTo shriekercannon
                            End Select
                            'AllWargear.Rows.Add("Shrieker cannon - Shrieker", 24, "Assault", 1, 6, 0, 1)
                            'AllWargear.Rows.Add("Shrieker cannon - Shuriken", 24, "Assault", 3, 6, 0, 1)
                        Case Is = "Star bolas"
                            AllWargear.Rows.Add("Star bolas", 12, "Grenade", rolld(3), 6, -3, 1)
                        Case Is = "Death ray"
                            AllWargear.Rows.Add("Death ray", 24, "Heavy", rolld(3), 10, -4, rolld(6))
                        Case Is = "Doomsday cannon"
doomsdaycannon:
                            Select Case CustomMsgbox("Low or High power", "Low", "High")
                                Case Is = 2
                                    AllWargear.Rows.Add("Doomsday cannon - Low power", 24, "Heavy", rolld(3), 8, -2, rolld(3))
                                Case Is = 3
                                    AllWargear.Rows.Add("Doomsday cannon - High power", 72, "Heavy", rolld(3), 10, -5, rolld(6))
                                Case Else
                                    GoTo doomsdaycannon
                            End Select
                            'AllWargear.Rows.Add("Doomsday cannon - Low power", 24, "Heavy", rolld(3), 8, -2, rolld(3))
                            'AllWargear.Rows.Add("Doomsday cannon - High power", 72, "Heavy", rolld(3), 10, -5, rolld(6))
                        Case Is = "Eldritch Lance (shooting)"
                            AllWargear.Rows.Add("Eldritch Lance (shooting)", 36, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Gauntlet of fire"
                            AllWargear.Rows.Add("Gauntlet of fire", 8, "Assault", rolld(6), 4, 0, 1)
                        Case Is = "Gauss blaster"
                            AllWargear.Rows.Add("Gauss blaster", 24, "Rapid Fire", 1, 5, -2, 1)
                        Case Is = "Gauss cannon"
                            AllWargear.Rows.Add("Gauss cannon", 24, "Heavy", 2, 5, -3, rolld(3))
                        Case Is = "Gauss flayer"
                            AllWargear.Rows.Add("Gauss flayer", 24, "Rapid Fire", 1, 4, -1, 1)
                        Case Is = "Gauss flayer array"
                            AllWargear.Rows.Add("Gauss flayer array", 24, "Rapid Fire", 5, 4, -1, 1)
                        Case Is = "Gauss flux arc"
                            AllWargear.Rows.Add("Gauss flux arc", 24, "Heavy", 3, 5, -2, 1)
                        Case Is = "Heat ray"
heatray:
                            Select Case CustomMsgbox("Dispersed or Focused", "Dispersed", "Focused")
                                Case Is = 2
                                    AllWargear.Rows.Add("Heat ray - Dispersed", 8, "Heavy", rolld(6), 5, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Heat ray - Focused", 24, "Heavy", 2, 8, -4, rolld(6))
                                Case Else
                                    GoTo cyclicionblaster
                            End Select
                            ' AllWargear.Rows.Add("Heat ray - Dispersed", 8, "Heavy", rolld(6), 5, -1, 1)
                            'AllWargear.Rows.Add("Heat ray - Focused", 24, "Heavy", 2, 8, -4, rolld(6))
                        Case Is = "Heavy gauss cannon"
                            AllWargear.Rows.Add("Heavy gauss cannon", 36, "Heavy", 1, 9, -4, rolld(6))
                        Case Is = "Particle beamer"
                            AllWargear.Rows.Add("Particle beamer", 24, "Assault", 3, 6, 0, 1)
                        Case Is = "Particle caster"
                            AllWargear.Rows.Add("Particle caster", 12, "Pistol", 1, 6, 0, 1)
                        Case Is = "Particle shredder"
                            AllWargear.Rows.Add("Particle shredder", 24, "Heavy", 6, 7, -1, rolld(3))
                        Case Is = "Particle whip"
                            AllWargear.Rows.Add("Particle whip", 24, "Heavy", 6, 8, -2, rolld(3))
                        Case Is = "Rod of covenant (shooting)"
                            AllWargear.Rows.Add("Rod of covenant (shooting)", 12, "Assault", 1, 5, -3, 1)
                        Case Is = "Staff of light (shooting)"
                            AllWargear.Rows.Add("Staff of light (shooting)", 12, "Assault", 3, 5, -2, 1)
                        Case Is = "Staff of the Destroyer (shooting)"
                            AllWargear.Rows.Add("Staff of the Destroyer (shooting)", 18, "Assault", 3, 6, -3, 2)
                        Case Is = "Synaptic disintegrator"
                            AllWargear.Rows.Add("Synaptic disintegrator", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = "Tachyon arrow"
                            AllWargear.Rows.Add("Tachyon arrow", 120, "Assault", 1, 10, -5, rolld(6))
                        Case Is = "Tesla cannon"
                            AllWargear.Rows.Add("Tesla cannon", 24, "Assault", 3, 6, 0, 1)
                        Case Is = "Tesla carbine"
                            AllWargear.Rows.Add("Tesla carbine", 24, "Assault", 2, 5, 0, 1)
                        Case Is = "Tesla destructor"
                            AllWargear.Rows.Add("Tesla destructor", 24, "Assault", 4, 7, 0, 1)
                        Case Is = "Tesla sphere"
                            AllWargear.Rows.Add("Tesla sphere", 24, "Assault", 5, 7, 0, 1)
                        Case Is = "Transdimensional beamer"
                            AllWargear.Rows.Add("Transdimensional beamer", 12, "Heavy", rolld(3), 4, -3, 1)
                        Case Is = "Twin heavy gauss cannon"
                            AllWargear.Rows.Add("Twin heavy gauss cannon", 36, "Heavy", 2, 9, -4, rolld(6))
                        Case Is = "Twin tesla destructor"
                            AllWargear.Rows.Add("Twin tesla destructor", 24, "Assault", 8, 7, 0, 1)
                        Case Is = "Big shoota"
                            AllWargear.Rows.Add("Big shoota", 36, "Assault", 3, 5, 0, 1)
                        Case Is = "Burna (shooting)"
                            AllWargear.Rows.Add("Burna (shooting)", 8, "Assault", rolld(3), 4, 0, 1)
                        Case Is = "Dakkagun"
                            AllWargear.Rows.Add("Dakkagun", 18, "Assault", 3, 5, 0, 1)
                        Case Is = "Deffgun"
                            AllWargear.Rows.Add("Deffgun", 48, "Heavy", rolld(3), 7, -1, 2)
                        Case Is = "Deffkannon"
                            AllWargear.Rows.Add("Deffkannon", 72, "Heavy", rolld(6), 10, -4, rolld(6))
                        Case Is = "Deffstorm mega-shoota"
                            AllWargear.Rows.Add("Deffstorm mega-shoota", 36, "Heavy", rolld(6) + rolld(6) + rolld(6), 6, -1, 1)
                        Case Is = "Grot blasta"
                            AllWargear.Rows.Add("Grot blasta", 12, "Pistol", 1, 3, 0, 1)
                        Case Is = "Grotzooka"
                            AllWargear.Rows.Add("Grotzooka", 18, "Heavy", rolld(3) + rolld(3), 6, 0, 1)
                        Case Is = "Kannon"
kannon:
                            Select Case CustomMsgbox("Frag or Shell", "Frag", "Shell")
                                Case Is = 2
                                    AllWargear.Rows.Add("Kannon - Frag", 36, "Heavy", rolld(6), 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Kannon - Shell", 36, "Heavy", 1, 8, -2, rolld(6))
                                Case Else
                                    GoTo kannon
                            End Select
                            'AllWargear.Rows.Add("Kannon - Frag", 36, "Heavy", rolld(6), 4, 0, 1)
                            'AllWargear.Rows.Add("Kannon - Shell", 36, "Heavy", 1, 8, -2, rolld(6))
                        Case Is = "Killkannon"
                            AllWargear.Rows.Add("Killkannon", 24, "Heavy", rolld(6), 7, -2, 2)
                        Case Is = "Kombi-weapon with rokkit launcha" '- Rokkit launcha"
Kombiweaponwithrokkitlauncha:
                            Select Case CustomMsgbox("Rokkit launcha, Shoota or both", "Rokkit launcha", "Shoota", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Kombi-weapon - Rokkit launcha", 24, "Assault", 1, 8, -2, 3)
                                Case Is = 3
                                    AllWargear.Rows.Add("Kombi-weapon - Shoota", 18, "Assault", 2, 4, 0, 1)
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo Kombiweaponwithrokkitlauncha
                                Case Else
                                    GoTo Kombiweaponwithrokkitlauncha
                            End Select
                            ' AllWargear.Rows.Add("Kombi-weapon - Rokkit launcha", 24, "Assault", 1, 8, -2, 3)
                            ' Case Is = "- Shoota"
                            ' AllWargear.Rows.Add("Kombi-weapon - Shoota", 18, "Assault", 2, 4, 0, 1)
                        Case Is = "Kombi-weapon with skorcha"
Kombiweaponwithskorcha:
                            Select Case CustomMsgbox("Rokkit launcha, Shoota or both", "Rokkit launcha", "Shoota", "Both")
                                Case Is = 2
                                    AllWargear.Rows.Add("Kombi-weapon with skorcha - Shoota", 18, "Assault", 2, 4, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Kombi-weapon with skorcha - Skorcha", 8, "Assault", rolld(6), 5, -1, 1)
                                Case Is = 4
                                    MsgBox("Both has not yet been implemented, please select another")
                                    GoTo Kombiweaponwithskorcha
                                Case Else
                                    GoTo Kombiweaponwithskorcha
                            End Select
                            'AllWargear.Rows.Add("Kombi-weapon with skorcha - Shoota", 18, "Assault", 2, 4, 0, 1)
                            'AllWargear.Rows.Add("Kombi-weapon with skorcha - Skorcha", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Kopta rokkits"
                            AllWargear.Rows.Add("Kopta rokkits", 24, "Assault", 2, 8, -2, 3)
                        Case Is = "Kustom mega-blasta"
                            AllWargear.Rows.Add("Kustom mega-blasta", 24, "Assault", 1, 8, -3, rolld(3))
                        Case Is = "Kustom mega-kannon"
                            AllWargear.Rows.Add("Kustom mega-kannon", 36, "Heavy", rolld(6), 8, -3, rolld(3))
                        Case Is = "Kustom mega-slugga"
                            AllWargear.Rows.Add("Kustom mega-slugga", 12, "Pistol", 1, 8, -3, rolld(3))
                        Case Is = "Kustom shoota"
                            AllWargear.Rows.Add("Kustom shoota", 18, "Assault", 4, 4, 0, 1)
                        Case Is = "Lobba"
                            AllWargear.Rows.Add("Lobba", 48, "Heavy", rolld(6), 5, 0, 1)
                        Case Is = "Pair of rokkit pistols"
                            AllWargear.Rows.Add("Pair of rokkit pistols", 12, "Pistol", 2, 7, -2, rolld(3))
                        Case Is = "Rack of rokkits"
                            AllWargear.Rows.Add("Rack of rokkits", 24, "Assault", 2, 8, -2, 3)
                        Case Is = "Da Rippa"
darippa:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Da Rippa - Standard", 24, "Heavy", 3, 7, -3, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Da Rippa - Supercharge", 24, "Heavy", 3, 8, -3, 3)
                                Case Else
                                    GoTo darippa
                            End Select
                            ' AllWargear.Rows.Add("Da Rippa - Standard", 24, "Heavy", 3, 7, -3, 2)
                            ' AllWargear.Rows.Add("Da Rippa - Supercharge", 24, "Heavy", 3, 8, -3, 3)
                        Case Is = "Rokkit launcha"
                            AllWargear.Rows.Add("Rokkit launcha", 24, "Assault", 1, 8, -2, 3)
                        Case Is = "Shokk attack gun"
                            AllWargear.Rows.Add("Shokk attack gun", 60, "Heavy", rolld(6), rolld(6) + rolld(6), -5, rolld(3))
                        Case Is = "Shoota"
                            AllWargear.Rows.Add("Shoota", 18, "Assault", 2, 4, 0, 1)
                        Case Is = "Skorcha"
                            AllWargear.Rows.Add("Skorcha", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Skorcha missile"
                            AllWargear.Rows.Add("Skorcha missile", 24, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Slugga"
                            AllWargear.Rows.Add("Slugga", 12, "Pistol", 1, 4, 0, 1)
                        Case Is = "Snazzgun"
                            AllWargear.Rows.Add("Snazzgun", 24, "Heavy", 3, 5, -2, 1)
                        Case Is = "Squig bomb"
                            AllWargear.Rows.Add("Squig bomb", 18, "Assault", 1, 8, -2, rolld(6))
                        Case Is = "Stikkbomb"
                            AllWargear.Rows.Add("Stikkbomb", 6, "Grenade", rolld(6), 3, 0, 1)
                        Case Is = "Stikkbomb flinga"
                            AllWargear.Rows.Add("Stikkbomb flinga", 12, "Assault", rolld(6) + rolld(6), 3, 0, 1)
                        Case Is = "Supa shoota"
                            AllWargear.Rows.Add("Supa shoota", 36, "Assault", 3, 6, -1, 1)
                        Case Is = "Supa-gatler"
                            AllWargear.Rows.Add("Supa-gatler", 48, "Heavy", rolld(6) + rolld(6), 7, -2, 1)
                        Case Is = "Supa-rokkit"
                            AllWargear.Rows.Add("Supa-rokkit", 100, "Heavy", rolld(3), 8, -2, rolld(6))
                        Case Is = "Tankbusta bomb"
                            AllWargear.Rows.Add("Tankbusta bomb", 6, "Grenade", rolld(3), 8, -2, rolld(6))
                        Case Is = "Tellyport blasta"
                            AllWargear.Rows.Add("Tellyport blasta", 12, "Assault", rolld(3), 8, -2, 1)
                        Case Is = "Tellyport mega-blasta"
                            AllWargear.Rows.Add("Tellyport mega-blasta", 24, "Assault", rolld(3), 8, -2, 1)
                        Case Is = "Traktor kannon"
                            AllWargear.Rows.Add("Traktor kannon", 36, "Heavy", 1, 8, -2, rolld(3))
                        Case Is = "Twin big shoota"
                            AllWargear.Rows.Add("Twin big shoota", 36, "Assault", 6, 5, 0, 1)
                        Case Is = "Wazbom mega-kannon"
                            AllWargear.Rows.Add("Wazbom mega-kannon", 36, "Heavy", rolld(3), 8, -3, rolld(3))
                        Case Is = "Zzap gun"
                            AllWargear.Rows.Add("Zzap gun", 36, "Heavy", 1, rolld(6) + rolld(6), -3, 3)
                        Case Is = "Airbursting fragmentation projector"
                            AllWargear.Rows.Add("Airbursting fragmentation projector", 18, "Assault", rolld(6), 4, 0, 1)
                        Case Is = "Burst cannon"
                            AllWargear.Rows.Add("Burst cannon", 18, "Assault", 4, 5, 0, 1)
                        Case Is = "Cluster rocket system"
                            AllWargear.Rows.Add("Cluster rocket system", 48, "Heavy", rolld(6) + rolld(6) + rolld(6) + rolld(6), 5, 0, 1)
                        Case Is = "Cyclic ion blaster"
cyclicionblaster:
                            Select Case CustomMsgbox("Standard or Overcharge", "Standard", "Overcharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Cyclic ion blaster - Standard", 18, "Assault", 3, 7, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Cyclic ion blaster - Overcharge", 18, "Assault", rolld(3), 8, -1, rolld(3))
                                Case Else
                                    GoTo cyclicionblaster
                            End Select
                            'AllWargear.Rows.Add("Cyclic ion blaster - Standard", 18, "Assault", 3, 7, -1, 1)
                            'AllWargear.Rows.Add("Cyclic ion blaster - Overcharge", 18, "Assault", rolld(3), 8, -1, rolld(3))
                        Case Is = "Cyclic ion raker"
cyclicionraker:
                            Select Case CustomMsgbox("Standard or Overcharge", "Standard", "Overcharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Cyclic ion raker - Standard", 24, "Heavy", 6, 7, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Cyclic ion raker - Overcharge", 24, "Heavy", rolld(6), 8, -1, rolld(3))
                                Case Else
                                    GoTo cyclicionraker
                            End Select
                            'AllWargear.Rows.Add("Cyclic ion raker - Standard", 24, "Heavy", 6, 7, -1, 1)
                            'AllWargear.Rows.Add("Cyclic ion raker - Overcharge", 24, "Heavy", rolld(6), 8, -1, rolld(3))
                        Case Is = "Fusion blaster"
                            AllWargear.Rows.Add("Fusion blaster", 18, "Assault", 1, 8, -4, rolld(6))
                        Case Is = "Fusion collider"
                            AllWargear.Rows.Add("Fusion collider", 18, "Heavy", rolld(3), 8, -4, rolld(6))
                        Case Is = "Heavy burst cannon"
heavyburstcannon:
                            Select Case CustomMsgbox("Standard or Nova-charge", "Standard", "Nova-charge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Heavy burst cannon - Standard", 36, "Heavy", 8, 6, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Heavy burst cannon - Nova-charge", 36, "Heavy", 12, 6, -2, 1)
                                Case Else
                                    GoTo heavyburstcannon
                            End Select
                            'AllWargear.Rows.Add("Heavy burst cannon - Standard", 36, "Heavy", 8, 6, -1, 1)
                            'AllWargear.Rows.Add("Heavy burst cannon - Nova-charge", 36, "Heavy", 12, 6, -2, 1)
                        Case Is = "Heavy rail rifle"
                            AllWargear.Rows.Add("Heavy rail rifle", 60, "Heavy", 2, 8, -4, rolld(6))
                        Case Is = "High-output burst cannon"
                            AllWargear.Rows.Add("High-output burst cannon", 18, "Assault", 8, 5, 0, 1)
                        Case Is = "High-yield missile pod"
                            AllWargear.Rows.Add("High-yield missile pod", 36, "Heavy", 4, 7, -1, rolld(3))
                        Case Is = "Ion accelerator"
ionaccelerator:
                            Select Case CustomMsgbox("Standard, Overcharge or Nova-charge", "Standard", "Overcharge", "Nova-charge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Ion accelerator - Standard", 72, "Heavy", 3, 7, -3, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Ion accelerator - Overcharge", 72, "Heavy", rolld(6), 8, -3, rolld(3))
                                Case Is = 4
                                    AllWargear.Rows.Add("Ion accelerator - Nova-charge", 72, "Heavy", rolld(6), 9, -3, 3)
                                Case Else
                                    GoTo ionaccelerator
                            End Select
                            'AllWargear.Rows.Add("Ion accelerator - Standard", 72, "Heavy", 3, 7, -3, 1)
                            'AllWargear.Rows.Add("Ion accelerator - Overcharge", 72, "Heavy", rolld(6), 8, -3, rolld(3))
                            'AllWargear.Rows.Add("Ion accelerator - Nova-charge", 72, "Heavy", rolld(6), 9, -3, 3)
                        Case Is = "Ion cannon"
ioncannon:
                            Select Case CustomMsgbox("Standard or Overcharge", "Standard", "Overcharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Ion cannon - Standard", 60, "Heavy", 3, 7, -2, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Ion cannon - Overcharge", 60, "Heavy", rolld(3), 8, -2, 3)
                                Case Else
                                    GoTo ioncannon
                            End Select
                            ' AllWargear.Rows.Add("Ion cannon - Standard", 60, "Heavy", 3, 7, -2, 2)
                            ' AllWargear.Rows.Add("Ion cannon - Overcharge", 60, "Heavy", rolld(3), 8, -2, 3)
                        Case Is = "Ion rifle"
ionrifle:
                            Select Case CustomMsgbox("Standard or Overcharge", "standard", "Overcharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Ion rifle - Standard", 30, "Rapid Fire", 1, 7, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Ion rifle - Overcharge", 30, "Heavy", rolld(3), 8, -1, 1)
                                Case Else
                                    GoTo ionrifle
                            End Select
                            ' AllWargear.Rows.Add("Ion rifle - Standard", 30, "Rapid Fire", 1, 7, -1, 1)
                            'AllWargear.Rows.Add("Ion rifle - Overcharge", 30, "Heavy", rolld(3), 8, -1, 1)
                        Case Is = "Kroot gun"
                            AllWargear.Rows.Add("Kroot gun", 48, "Rapid Fire", 1, 7, -1, rolld(3))
                        Case Is = "Kroot rifle (shooting)"
                            AllWargear.Rows.Add("Kroot rifle (shooting)", 24, "Rapid Fire", 1, 4, 0, 1)
                        Case Is = "Longshot pulse rifle"
                            AllWargear.Rows.Add("Longshot pulse rifle", 48, "Rapid Fire", 1, 5, 0, 1)
                        Case Is = "Missile pod"
                            AllWargear.Rows.Add("Missile pod", 36, "Assault", 2, 7, -1, rolld(3))
                        Case Is = "Neutron blaster"
                            AllWargear.Rows.Add("Neutron blaster", 18, "Assault", 2, 5, -2, 1)
                        Case Is = "Plasma rifle"
                            AllWargear.Rows.Add("Plasma rifle", 24, "Rapid Fire", 1, 6, -3, 1)
                        Case Is = "Pulse blastcannon"
pulseblastcannon:
                            Select Case CustomMsgbox("Close, Medium or Long range", "Close range", "Medium range", "Long range")
                                Case Is = 2
                                    AllWargear.Rows.Add("Pulse blastcannon - Close range", 10, "Heavy", 2, 14, -4, 6)
                                Case Is = 2
                                    AllWargear.Rows.Add("Pulse blastcannon - Medium range", 20, "Heavy", 4, 12, -2, 3)
                                Case Is = 3
                                    AllWargear.Rows.Add("Pulse blastcannon - Long range", 30, "Heavy", 6, 10, 0, 1)
                                Case Else
                                    GoTo pulseblastcannon
                            End Select
                            'AllWargear.Rows.Add("Pulse blastcannon - Close range", 10, "Heavy", 2, 14, -4, 6)
                            'AllWargear.Rows.Add("Pulse blastcannon - Medium range", 20, "Heavy", 4, 12, -2, 3)
                            'AllWargear.Rows.Add("Pulse blastcannon - Long range", 30, "Heavy", 6, 10, 0, 1)
                        Case Is = "Pulse blaster"
pulseblaster:
                            Select Case CustomMsgbox("Close, Medium or Long range", "Close range", "Medium range", "Long range")
                                Case Is = 2
                                    AllWargear.Rows.Add("Pulse blaster - Close range", 5, "Assault", 2, 6, -2, 1)
                                Case Is = 2
                                    AllWargear.Rows.Add("Pulse blaster - Medium range", 10, "Assault", 2, 5, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Pulse blaster - Long range", 15, "Assault", 2, 4, 0, 1)
                                Case Else
                                    GoTo pulseblaster
                            End Select
                            'AllWargear.Rows.Add("Pulse blaster - Close range", 5, "Assault", 2, 6, -2, 1)
                            'AllWargear.Rows.Add("Pulse blaster - Medium range", 10, "Assault", 2, 5, -1, 1)
                            'AllWargear.Rows.Add("Pulse blaster - Long range", 15, "Assault", 2, 4, 0, 1)
                        Case Is = "Pulse carbine"
                            AllWargear.Rows.Add("Pulse carbine", 18, "Assault", 2, 5, 0, 1)
                        Case Is = "Pulse driver cannon"
                            AllWargear.Rows.Add("Pulse driver cannon", 72, "Heavy", rolld(3), 10, -3, rolld(6))
                        Case Is = "Pulse pistol"
                            AllWargear.Rows.Add("Pulse pistol", 12, "Pistol", 1, 5, 0, 1)
                        Case Is = "Pulse rifle"
                            AllWargear.Rows.Add("Pulse rifle", 30, "Rapid Fire", 1, 5, 0, 1)
                        Case Is = "Quad ion turret"
quadionturret:
                            Select Case CustomMsgbox("Standard or Supercharge", "Standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Quad ion turret - Standard", 30, "Heavy", 4, 7, -1, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Quad ion turret - Overcharge", 30, "Heavy", rolld(6), 8, -1, rolld(3))
                                Case Else
                                    GoTo quadionturret
                            End Select
                            AllWargear.Rows.Add("Quad ion turret - Standard", 30, "Heavy", 4, 7, -1, 1)
                            AllWargear.Rows.Add("Quad ion turret - Overcharge", 30, "Heavy", rolld(6), 8, -1, rolld(3))
                        Case Is = "Rail rifle"
                            AllWargear.Rows.Add("Rail rifle", 30, "Rapid Fire", 1, 6, -4, rolld(3))
                        Case Is = "Railgun"
railgun:
                            Select Case CustomMsgbox("Solid shot or Submunitions", "Solid shot", "Submunitions")
                                Case Is = 2
                                    AllWargear.Rows.Add("Railgun - Solid shot", 72, "Heavy", 1, 10, -4, rolld(6))
                                Case Is = 3
                                    AllWargear.Rows.Add("Railgun - Submunitions", 72, "Heavy", rolld(6), 6, -1, 1)
                                Case Else
                                    GoTo railgun
                            End Select
                            'AllWargear.Rows.Add("Railgun - Solid shot", 72, "Heavy", 1, 10, -4, rolld(6))
                            'AllWargear.Rows.Add("Railgun - Submunitions", 72, "Heavy", rolld(6), 6, -1, 1)
                        Case Is = "Smart missile system"
                            AllWargear.Rows.Add("Smart missile system", 30, "Heavy", 4, 5, 0, 1)
                        Case Is = "Supremacy railgun"
                            AllWargear.Rows.Add("Supremacy railgun", 72, "Heavy", 2, 10, -4, rolld(6))
                        Case Is = "Barbed strangler"
                            AllWargear.Rows.Add("Barbed strangler", 36, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Bio-electric pulse"
                            AllWargear.Rows.Add("Bio-electric pulse", 12, "Assault", 6, 5, 0, 1)
                        Case Is = "Bio-electric pulse with containment spines"
                            AllWargear.Rows.Add("Bio-electric pulse with containment spines", 12, "Assault", 12, 5, 0, 1)
                        Case Is = "Bio-plasma"
                            AllWargear.Rows.Add("Bio-plasma", 12, "Assault", rolld(3), 7, -3, 1)
                        Case Is = "Bio-plasmic cannon"
                            AllWargear.Rows.Add("Bio-plasmic cannon", 36, "Heavy", 6, 7, -3, 2)
                        Case Is = "Choking spores"
                            AllWargear.Rows.Add("Choking spores", 12, "Assault", rolld(6), 3, 0, rolld(3))
                        Case Is = "Deathspitter"
                            AllWargear.Rows.Add("Deathspitter", 18, "Assault", 3, 5, -1, 1)
                        Case Is = "Deathspitter with slimer maggots"
                            AllWargear.Rows.Add("Deathspitter with slimer maggots", 18, "Assault", 3, 7, -1, 1)
                        Case Is = "Devourer"
                            AllWargear.Rows.Add("Devourer", 18, "Assault", 3, 4, 0, 1)
                        Case Is = "Devourer with brainleech worms"
                            AllWargear.Rows.Add("Devourer with brainleech worms", 18, "Assault", 3, 6, 0, 1)
                        Case Is = "Drool cannon"
                            AllWargear.Rows.Add("Drool cannon", 8, "Assault", rolld(6), 6, -1, 1)
                        Case Is = "Flamespurt"
                            AllWargear.Rows.Add("Flamespurt", 10, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Fleshborer"
                            AllWargear.Rows.Add("Fleshborer", 12, "Assault", 1, 4, 0, 1)
                        Case Is = "Fleshborer hive"
                            AllWargear.Rows.Add("Fleshborer hive", 18, "Heavy", 20, 5, 0, 1)
                        Case Is = "Grasping tongue"
                            AllWargear.Rows.Add("Grasping tongue", 12, "Assault", 1, 6, -3, rolld(3))
                        Case Is = "Heavy venom cannon"
                            AllWargear.Rows.Add("Heavy venom cannon", 36, "Assault", rolld(3), 9, -1, rolld(3))
                        Case Is = "Impaler cannon"
                            AllWargear.Rows.Add("Impaler cannon", 36, "Heavy", 2, 8, -2, rolld(3))
                        Case Is = "Rupture cannon"
                            AllWargear.Rows.Add("Rupture cannon", 48, "Heavy", 2, 10, -1, 2)
                        Case Is = "Shockcannon"
                            AllWargear.Rows.Add("Shockcannon", 24, "Assault", rolld(3), 7, -1, rolld(3))
                        Case Is = "Spike rifle"
                            AllWargear.Rows.Add("Spike rifle", 18, "Assault", 1, 3, 0, 1)
                        Case Is = "Spinemaws"
                            AllWargear.Rows.Add("Spinemaws", 6, "Pistol", 4, 2, 0, 1)
                        Case Is = "Stinger salvo"
                            AllWargear.Rows.Add("Stinger salvo", 18, "Assault", 4, 5, -1, 1)
                        Case Is = "Stranglethorn cannon"
                            AllWargear.Rows.Add("Stranglethorn cannon", 36, "Assault", rolld(6), 7, -1, 2)
                        Case Is = "Strangleweb"
                            AllWargear.Rows.Add("Strangleweb", 8, "Assault", rolld(3), 2, 0, 1)
                        Case Is = "Tentaclids"
                            AllWargear.Rows.Add("Tentaclids", 36, "Assault", 2, 5, 0, 1)
                        Case Is = "Venom cannon"
                            AllWargear.Rows.Add("Venom cannon", 36, "Assault", rolld(3), 8, -1, 1)
                        Case Is = "Autogun"
                            AllWargear.Rows.Add("Autogun", 24, "Rapid Fire", 1, 3, 0, 1)
                        Case Is = "Autopistol"
                            AllWargear.Rows.Add("Autopistol", 12, "Pistol", 1, 3, 0, 1)
                        Case Is = "Blasting charge"
                            AllWargear.Rows.Add("Blasting charge", 6, "Grenade", rolld(6), 3, 0, 1)
                        Case Is = "Cache of demolition charges"
                            AllWargear.Rows.Add("Cache of demolition charges", 6, "Assault", rolld(6), 8, -3, rolld(3))
                        Case Is = "Clearance incinerator"
                            AllWargear.Rows.Add("Clearance incinerator", 12, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Demolition charges"
                            AllWargear.Rows.Add("Demolition charges", 6, "Assault", rolld(6), 8, -3, rolld(3))
                        Case Is = "Heavy mining laser"
                            AllWargear.Rows.Add("Heavy mining laser", 36, "Heavy", 1, 9, -3, rolld(6))
                        Case Is = "Heavy seismic cannon"
heavyseismiccannon:
                            Select Case CustomMsgbox("Long or Short-wave", "Long-wave", "Short-wave")
                                Case Is = 2
                                    AllWargear.Rows.Add("Heavy seismic cannon - Long-wave", 24, "Heavy", 4, 4, -1, 2)
                                Case Is = 3
                                    AllWargear.Rows.Add("Heavy seismic cannon - Short-wave", 12, "Heavy", 2, 8, -2, 3)
                                Case Else
                                    GoTo heavyseismiccannon
                            End Select
                            'AllWargear.Rows.Add("Heavy seismic cannon - Long-wave", 24, "Heavy", 4, 4, -1, 2)
                            'AllWargear.Rows.Add("Heavy seismic cannon - Short-wave", 12, "Heavy", 2, 8, -2, 3)
                        Case Is = "Mining laser"
                            AllWargear.Rows.Add("Mining laser", 24, "Heavy", 1, 9, -3, rolld(3))
                        Case Is = "Needle pistol"
                            AllWargear.Rows.Add("Needle pistol", 12, "Pistol", 1, 1, 0, 1)
                        Case Is = "Seismic cannon"
seismiccannon:
                            Select Case CustomMsgbox("Standard or Supercharge", "standard", "Supercharge")
                                Case Is = 2
                                    AllWargear.Rows.Add("Seismic cannon - Long-wave", 24, "Heavy", 4, 3, 0, 1)
                                Case Is = 3
                                    AllWargear.Rows.Add("Seismic cannon - Short-wave", 12, "Heavy", 2, 6, -1, 2)
                                Case Else
                                    GoTo seismiccannon
                            End Select
                            'AllWargear.Rows.Add("Seismic cannon - Long-wave", 24, "Heavy", 4, 3, 0, 1)
                            'AllWargear.Rows.Add("Seismic cannon - Short-wave", 12, "Heavy", 2, 6, -1, 2)
                        Case Is = "Baleflamer"
                            AllWargear.Rows.Add("Baleflamer", 18, "Assault", rolld(6), 6, -2, 2)
                        Case Is = "Blastmaster"
blastmaster:
                            Select Case CustomMsgbox("Single or Varied frequency", "Single frequency", "Varied frequency")
                                Case Is = 2
                                    AllWargear.Rows.Add("Blastmaster - Single frequency", 48, "Heavy", rolld(3), 8, -2, rolld(3))
                                Case Is = 3
                                    AllWargear.Rows.Add("Blastmaster - Varied frequency", 36, "Assault", rolld(6), 4, -1, 1)
                                Case Else
                                    GoTo blastmaster
                            End Select
                            ' AllWargear.Rows.Add("Blastmaster - Single frequency", 48, "Heavy", rolld(3), 8, -2, rolld(3))
                            ' AllWargear.Rows.Add("Blastmaster - Varied frequency", 36, "Assault", rolld(6), 4, -1, 1)
                        Case Is = "Blight grenade"
                            AllWargear.Rows.Add("Blight grenade", 6, "Grenade", rolld(6), 3, 0, 1)
                        Case Is = "Blight launcher"
                            AllWargear.Rows.Add("Blight launcher", 24, "Assault", 2, 6, -2, rolld(3))
                        Case Is = "Cypher’s bolt pistol"
                            AllWargear.Rows.Add("Cypher’s bolt pistol", 16, "Pistol", 3, 4, -1, 1)
                        Case Is = "Cypher’s plasma pistol"
                            AllWargear.Rows.Add("Cypher’s plasma pistol", 12, "Pistol", 2, 8, -3, 2)
                        Case Is = "The Destroyer Hive"
                            AllWargear.Rows.Add("The Destroyer Hive", 6, "Pistol", rolld(6) + rolld(6), 4, -3, 1)
                        Case Is = "Doom siren"
                            AllWargear.Rows.Add("Doom siren", 8, "Assault", rolld(3), 5, -2, 1)
                        Case Is = "Ectoplasma cannon"
                            AllWargear.Rows.Add("Ectoplasma cannon", 24, "Heavy", rolld(3), 7, -3, rolld(3))
                        Case Is = "Hades autocannon"
                            AllWargear.Rows.Add("Hades autocannon", 36, "Heavy", 4, 8, -1, 2)
                        Case Is = "Hades gatling cannon"
                            AllWargear.Rows.Add("Hades gatling cannon", 48, "Heavy", 12, 8, -2, 2)
                        Case Is = "Havoc launcher"
                            AllWargear.Rows.Add("Havoc launcher", 48, "Heavy", rolld(6), 5, 0, 1)
                        Case Is = "Heavy warpflamer"
                            AllWargear.Rows.Add("Heavy warpflamer", 8, "Heavy", rolld(6), 5, -2, 1)
                        Case Is = "Helbrute plasma cannon"
                            AllWargear.Rows.Add("Helbrute plasma cannon", 36, "Heavy", rolld(3), 8, -3, 2)
                        Case Is = "Hellfyre missile rack"
                            AllWargear.Rows.Add("Hellfyre missile rack", 24, "Heavy", 2, 8, -2, rolld(3))
                        Case Is = "Ichor cannon"
                            AllWargear.Rows.Add("Ichor cannon", 48, "Heavy", rolld(6), 7, -4, rolld(3))
                        Case Is = "Inferno bolt pistol"
                            AllWargear.Rows.Add("Inferno bolt pistol", 12, "Pistol", 1, 4, -2, 1)
                        Case Is = "Inferno boltgun"
                            AllWargear.Rows.Add("Inferno boltgun", 24, "Rapid Fire", 1, 4, -2, 1)
                        Case Is = "Inferno combi-bolter"
                            AllWargear.Rows.Add("Inferno combi-bolter", 24, "Rapid Fire", 2, 4, -2, 1)
                        Case Is = "Khârn’s plasma pistol"
                            AllWargear.Rows.Add("Khârn’s plasma pistol", 12, "Pistol", 1, 8, -3, 2)
                        Case Is = "Magma cutter"
                            AllWargear.Rows.Add("Magma cutter", 6, "Pistol", 1, 8, -4, 3)
                        Case Is = "Skullhurler"
                            AllWargear.Rows.Add("Skullhurler", 60, "Heavy", rolld(6), 9, -3, rolld(3))
                        Case Is = "Sonic blaster"
                            AllWargear.Rows.Add("Sonic blaster", 24, "Assault", 3, 4, 0, 1)
                        Case Is = "Soulreaper cannon"
                            AllWargear.Rows.Add("Soulreaper cannon", 24, "Heavy", 4, 5, -3, 1)
                        Case Is = "Talon of Horus (shooting)"
                            AllWargear.Rows.Add("Talon of Horus (shooting)", 24, "Rapid Fire", 2, 4, -1, rolld(3))
                        Case Is = "Tyrant’s Claw (shooting)"
                            AllWargear.Rows.Add("Tyrant’s Claw (shooting)", 9, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Warp bolter"
                            AllWargear.Rows.Add("Warp bolter", 24, "Assault", 2, 4, -1, 2)
                        Case Is = "Warpflame pistol"
                            AllWargear.Rows.Add("Warpflame pistol", 6, "Pistol", rolld(6), 3, -2, 1)
                        Case Is = "Warpflamer"
                            AllWargear.Rows.Add("Warpflamer", 8, "Assault", rolld(6), 4, -2, 1)
                        Case Is = "Bellow of endless fury"
                            AllWargear.Rows.Add("Bellow of endless fury", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Bloodflail"
                            AllWargear.Rows.Add("Bloodflail", 8, "Assault", 1, 1, -3, 3)
                        Case Is = "Coruscating flames"
                            AllWargear.Rows.Add("Coruscating flames", 18, "Assault", 2, 3, 0, 1)
                        Case Is = "Death’s heads"
                            AllWargear.Rows.Add("Death’s heads", 12, "Assault", 2, 4, 0, 1)
                        Case Is = "Fire of Tzeentch"
fireoftzeentch:
                            Select Case CustomMsgbox("Blue or Pink", "Blue", "Pink")
                                Case Is = 2
                                    AllWargear.Rows.Add("Fire of Tzeentch - Blue", 18, "Heavy", rolld(3), 9, -4, rolld(3))
                                Case Is = 3
                                    AllWargear.Rows.Add("Fire of Tzeentch - Pink", 8, "Pistol", rolld(6), 5, -2, 1)
                                Case Else
                                    GoTo fireoftzeentch
                            End Select
                            ' AllWargear.Rows.Add("Fire of Tzeentch - Blue", 18, "Heavy", rolld(3), 9, -4, rolld(3))
                            ' AllWargear.Rows.Add("Fire of Tzeentch - Pink", 8, "Pistol", rolld(6), 5, -2, 1)
                        Case Is = "Flickering flames"
                            AllWargear.Rows.Add("Flickering flames", 8, "Pistol", rolld(6), 4, -1, 1)
                        Case Is = "Harvester cannon"
                            AllWargear.Rows.Add("Harvester cannon", 48, "Heavy", 3, 7, -1, rolld(3))
                        Case Is = "Hellfire"
                            AllWargear.Rows.Add("Hellfire", 8, "Assault", rolld(6), 5, -1, 1)
                        Case Is = "Lashes of torment"
                            AllWargear.Rows.Add("Lashes of torment", 6, "Assault", rolld(6), 4, 0, 1)
                        Case Is = "Phlegm bombardment"
                            AllWargear.Rows.Add("Phlegm bombardment", 36, "Heavy", rolld(3), 8, -2, 3)
                        Case Is = "Skull cannon"
                            AllWargear.Rows.Add("Skull cannon", 36, "Heavy", rolld(3), 8, -1, rolld(3))
                        Case Is = "Avenger gatling cannon"
                            AllWargear.Rows.Add("Avenger gatling cannon", 36, "Heavy", 12, 6, -2, 2)
                        Case Is = "Ironstorm missile pod"
                            AllWargear.Rows.Add("Ironstorm missile pod", 72, "Heavy", rolld(6), 5, -1, 2)
                        Case Is = "Rapid-fire battle cannon"
                            AllWargear.Rows.Add("Rapid-fire battle cannon", 72, "Heavy", rolld(6) + rolld(6), 8, -2, rolld(3))
                        Case Is = "Stormspear rocket pod"
                            AllWargear.Rows.Add("Stormspear rocket pod", 48, "Heavy", 3, 8, -2, rolld(6))
                        Case Is = "Thermal cannon"
                            AllWargear.Rows.Add("Thermal cannon", 36, "Heavy", rolld(3), 9, -4, rolld(6))
                        Case Is = "Twin Icarus autocannon"
                            AllWargear.Rows.Add("Twin Icarus autocannon", 48, "Heavy", 4, 7, -1, 2)
                        Case Is = "Icarus lascannon"
                            AllWargear.Rows.Add("Icarus lascannon", 96, "Heavy", 1, 9, -3, rolld(6))
                        Case Is = "Quad-gun"
                            AllWargear.Rows.Add("Quad-gun", 48, "Heavy", 8, 7, -1, 1)
                        Case Is = "Super Duper Mega Weapon"
                            AllWargear.Rows.Add("Super Duper Mega Weapon", 60, "Rapid Fire", 100, 100, -10, 100)
                        Case Else
                            'handles stuff like camo cloak
                            MsgBox("That is not a weapon, please select a weapon!")
                            GoTo skipshooting

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
                    GoTo skipshooting
                End Try
                'If AllWargear.Rows(0).Item(2).ToString = "Assault" Then
                '    assault = WargearandWeaponStats.assault(sender.hasadvanced)
                'ElseIf AllWargear.Rows(0).Item(2).ToString = "Heavy" Then
                '    heavy = WargearandWeaponStats.heavy(sender.hasmoved)
                'End If
                'Console.WriteLine(AllWargear.Rows(0).Item(0).ToString)
                'Console.WriteLine(AllWargear.Rows(0).Item(0).ToString)
                'Console.WriteLine(AllWargear.Rows(0).Item(0).ToString)
                'Console.WriteLine(AllWargear.Rows(0).Item(0).ToString)
                Target_selection()
                Dim mortalwoundstoshooter As Boolean
                Unit_Information.Visible = False
                Dim Squadname As String = "Scouts"
                For Each shootingcont In Me.Controls
                    If TypeOf shootingcont Is Unit Then
                        If shootingcont.isshooting = True And shootingcont.visible = True Then
                            ''after hit roll checks
                            For z = 1 To Coordinates.Length - 1 '' checks range of all targets
                                'Console.WriteLine(calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y))
                                If calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y) > CInt(AllWargear.Rows(0).Item(1)) Then
                                    MsgBox("Some or all targeted units are outside the range of this weapon. Please select target inside the range of the chosen weapon")
                                    Exit Sub
                                End If
                                numberofhitrolls = AllWargear.Rows(0).Item(3).ToString
                                numberofwoundrolls = 0
                                numberofsaverolls = 0
                                strength = AllWargear.Rows(0).Item(4).ToString
                                ap = AllWargear.Rows(0).Item(5).ToString
                                damage = AllWargear.Rows(0).Item(6)
                                ''before hit roll checks
                                If AllWargear.Rows(0).Item(0).ToString = "Astartes shotgun" And (calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y) < CInt(AllWargear.Rows(0).Item(1)) / 2) Then
                                    strength += 1
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Conversion beamer" And (calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y) > CInt(AllWargear.Rows(0).Item(1)) / 2) Then
                                    strength = 8
                                    ap = -1
                                    damage = 2
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Demolisher cannon" And z >= 5 Then
                                    numberofhitrolls = rolld(6)
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Flamer" Or AllWargear.Rows(0).Item(0).ToString.Contains("flame") Or AllWargear.Rows(0).Item(0).ToString.Contains("Flame") Then
                                    autohit = True
                                End If
                                If AllWargear.Rows(0).Item(0).ToString.Contains("Grav") And save >= 3 Then
                                    damage = rolld(3)
                                End If
                                If AllWargear.Rows(0).Item(0).ToString.Contains("melta") Or AllWargear.Rows(0).Item(0).ToString.Contains("Melta") Or AllWargear.Rows(0).Item(0).ToString = "Inferno pistol" And Not (AllWargear.Rows(0).Item(0).ToString = "Melta bomb") And (calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y) < CInt(AllWargear.Rows(0).Item(1)) / 2) Then
                                    Dim a As Integer = rolld(6)
                                    Dim b As Integer = rolld(6)
                                    If a > b Then
                                        damage = a
                                    Else
                                        damage = b
                                    End If
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Icarus stormcannon" Or AllWargear.Rows(0).Item(0).ToString = "Skyhammer missile launcher" Or AllWargear.Rows(0).Item(0).ToString = "Skyspear missile launcher" Or AllWargear.Rows(0).Item(0).ToString = "Twin Icarus lascannon" Then
                                    If False Then
                                        hitrollmodifer += 1
                                    Else
                                        hitrollmodifer -= 1
                                    End If
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Orbital array" And z >= 10 Then
                                    numberofhitrolls = rolld(6)
                                End If
                                '' ''If AllWargear.Rows(0).Item(0).ToString = "Melta bomb" Then
                                '' ''    ''reroll failed wound rolls against vehicles.
                                '' ''End If
                                If AllWargear.Rows(0).Item(0).ToString = "Gauntlet of the Forge" Or AllWargear.Rows(0).Item(0).ToString = "Frag cannon" Then
                                    autohit = True
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Foehammer (shooting)" Then 'and CHARACTER or MONSTER then Or AllWargear.Rows(0).Item(0).ToString = "Frag cannon" Then
                                    autohit = True
                                End If
                            Next
                            mortalwoundstoshooter = False


                            '##############  DICE ROLLING STARTS HERE  ##############'
                            For x As Integer = 1 To numberofhitrolls ' number of shots
                                If Functions.Rolltohit(shootingcont.nameofmodel, Squadname, AllWargear.Rows(0).Item(0).ToString, shootingcont.ballisticskill, , , , autohit) Then
                                    numberofwoundrolls += 1
                                    If hitroll = 1 Then
                                        mortalwoundstoshooter = True
                                    End If
                                End If
                            Next
                            If numberofwoundrolls = 0 Then
                                Exit Sub
                            End If
                            ''after hit roll checks
                            ''before wound roll checks
                            For x As Integer = 1 To numberofwoundrolls
                                If Functions.Rolltowound(strength, toughness) Then
                                    numberofsaverolls += 1
                                End If
                            Next
                            If numberofsaverolls = 0 Then
                                Exit Sub
                            End If
                            ''after wound roll checks
                            ''before save roll checks
                            For x = 1 To numberofsaverolls
                                If Not Functions.savingthrow(ap, save, False) Then
                                    If AllWargear.Rows(0).Item(0).ToString = "Sniper rifle" And hitroll = 6 Then
                                        MsgBox("Please select a model to apply " & damage & " damage to and 1 mortal wound to")
                                    Else
                                        MsgBox("Please select a model to apply " & damage & " damage to")
                                    End If
                                    ''after save roll checks
                                    ''before damage applied checks
                                    damagephases = True
                                    countdamage = damage '
                                    pagewaiter()
                                End If
                                nomoretargets = True
                                Target_selection()
                                If nomoretargets Then
                                    MsgBox("There are no more targets so all remaining shots fizzle away.")
                                    Exit For
                                End If
                            Next
                            '##############  DICE ROLLING SNDS HERE  ##############'
                            ''after damage applied checks
                            Console.WriteLine("End of all Shots, now determining and damage to " & shootingcont.nameofmodel)
                            If AllWargear.Rows(0).Item(0).ToString = "Heavy plasma cannon - Supercharge" And mortalwoundstoshooter = True Then
                                shootingcont.currentwounds -= 1
                                mortalwoundstoshooter = False
                            ElseIf AllWargear.Rows(0).Item(0).ToString = "Plasma Storm battery - Supercharge" And mortalwoundstoshooter = True Then
                                shootingcont.currentwounds -= 3
                                mortalwoundstoshooter = False
                            ElseIf (AllWargear.Rows(0).Item(0).ToString.Contains("Plasma") Or AllWargear.Rows(0).Item(0).ToString.Contains("plasma")) And AllWargear.Rows(0).Item(0).ToString.Contains("Supercharge") And mortalwoundstoshooter = True Then
                                shootingcont.currentwounds = 0
                                mortalwoundstoshooter = False
                            End If
                        End If
                    End If
                Next
skipshooting:
            Case Is = 4
                Target_selection()
                Unit_Information.Visible = False
                Dim Squadname As String = "Scouts"
                For Each shootingcont In Me.Controls
                    If TypeOf shootingcont Is Unit Then
                        If shootingcont.isshooting = True And shootingcont.visible = True Then
                            ''after hit roll checks
                            For z = 1 To Coordinates.Length - 1 '' checks range of all targets
                                'Console.WriteLine(calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y))
                                If calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y) > CInt(AllWargear.Rows(0).Item(1)) Then
                                    MsgBox("Some or all targeted units are outside the range of this weapon. Please select target inside the range of the chosen weapon")
                                    Exit Sub
                                End If
                                
                            Next


                            '##############  DICE ROLLING STARTS HERE  ##############'
                            
                        End If
                    End If
                Next

        End Select

    End Sub
    Private Sub ShootUnit_Click(sender As System.Object, e As System.EventArgs) Handles ShootUnit.Click
        For Each shootingcont In Me.Controls
            If TypeOf shootingcont Is Unit Then
                If shootingcont.isselectedtobeshooting = True Then
                    shootingcont.isshooting = True
                    Console.WriteLine(shootingcont.nameofmodel & " is selected to be shooting")
                Else
                    shootingcont.isshooting = False
                End If
            End If
        Next
    End Sub
    Private Sub TargetUnit_Click(sender As System.Object, e As System.EventArgs) Handles TargetUnit.Click
        For Each targetcont In Me.Controls
            If TypeOf targetcont Is Unit Then
                If targetcont.isselectedtobetarget = True Then
                    targetcont.istarget = True
                    Console.WriteLine(targetcont.nameofmodel & " is selected to be one of the targets")
                Else
                    targetcont.istarget = False
                End If
            End If
        Next
    End Sub
    Private Sub TSMI_Apply_Damage_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_Apply_Damage.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.identifier = unitfortransferinginfo Then
                    Console.WriteLine("Checking for Disgustingly Resilience")
                    For x As Integer = 0 To cnt.abilities.length - 1
                        If cnt.abilities(x) <> "" Then
                            If cnt.abilities(x).contains("Disgustingly Resilient") Then
                                If rolld(6) >= 5 Then
                                    Console.WriteLine("Passed Disgustingly Resilient test, no damage dealt; now checking deaths.")
                                    GoTo Checkdeaths
                                End If
                            End If
                        End If
                    Next
                    cnt.CurrentWounds -= countdamage 'take away normal damage
                    If AllWargear.Rows(0).Item(0).ToString = "Sniper rifle" And hitroll = 6 Then
                        Console.WriteLine("Rolled a 6 to wound so applying mortal wound as well")
                        cnt.Mortalwounds += 1
                        cnt.currentwounds -= 1 ' take away mortal damage
                        Console.WriteLine("Damage Dealt : " & countdamage + 1)
                    ElseIf AllWargear.Rows(0).Item(0).ToString.Contains("Helfrost cannon") Or AllWargear.Rows(0).Item(0).ToString.Contains("Helfrost destructor") Then
                        If rolld(6) = 6 Then
                            cnt.Mortalwounds += 1
                            cnt.currentwounds -= 1 ' take away mortal damage
                            Console.WriteLine("Damage Dealt : " & countdamage + 1)
                        End If
                    Else
                        Console.WriteLine("Damage Dealt : " & countdamage)
                    End If
                End If
Checkdeaths:
                pageready = True
                damagephases = False

                checkdamage()
            End If
        Next
    End Sub
    Private Sub pagewaiter()
        While Not pageready
            Application.DoEvents()
        End While
        pageready = False
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
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
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
        Console.WriteLine("Distance between two objects: " & Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / aspectratio)
        Return Math.Sqrt((unit1x - unit2x) ^ 2 + (unit1y - unit2y) ^ 2) / aspectratio
    End Function
    Private Sub TSMI_Model_flees_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_Model_flees.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.identifier = unitfortransferinginfo Then
                    Console.WriteLine("Unit lost: " & cnt.nameofmodel)
                    cnt.visible = False
                    pageready = True
                    leadershipphases = False
                End If
            End If
        Next
    End Sub

    Private Sub Choose_and_calc_deployment_zones(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ''spearhead,dawn of war, search and destroy,hammer and anvil,frontline assault,vanguard strike
        Dim team1 As New List(Of Point)
        Dim team2 As New List(Of Point)
        Select Case Race_Selection_Form.setdeploymentmap
            Case Is = 1
                'Console.WriteLine("Spearhead Assault")
                'team1
                team1.Add(New Point(0, 0))
                team1.Add(New Point(12 * Me.aspectratio, 0))
                team1.Add(New Point((centrepointininchesx() - 9) * Me.aspectratio, centrepointactualdimensionsy()))
                team1.Add(New Point(12 * Me.aspectratio, Me.Height))
                team1.Add(New Point(0, Me.Height))
                e.Graphics.DrawPolygon(Pens.Black, team1.ToArray)
                'team2
                team2.Add(New Point(mirror_pointx(0), 0))
                team2.Add(New Point(mirror_pointx(12 * Me.aspectratio), 0))
                team2.Add(New Point(mirror_pointx((centrepointininchesx() - 9) * Me.aspectratio), centrepointactualdimensionsy()))
                team2.Add(New Point(mirror_pointx(12 * Me.aspectratio), Me.Height))
                team2.Add(New Point(mirror_pointx(0), Me.Height))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
                e.Graphics.DrawLine(Pens.Black, mirror_pointx(12 * Me.aspectratio), 0, mirror_pointx((centrepointininchesx() - 9) * Me.aspectratio), centrepointactualdimensionsy())
                e.Graphics.DrawLine(Pens.Black, mirror_pointx((centrepointininchesx() - 9) * Me.aspectratio), centrepointactualdimensionsy(), mirror_pointx(12 * Me.aspectratio), Me.Height)
            Case Is = 2
                ' Console.WriteLine("Dawn of War")
                'team1
                team1.Add(New Point(0, 0))
                team1.Add(New Point(0, (centrepointininchesy() - 12) * Me.aspectratio))
                team1.Add(New Point(Me.Width, (centrepointininchesy() - 12) * Me.aspectratio))
                team1.Add(New Point(Me.Width, 0))
                e.Graphics.DrawPolygon(Pens.Black, team1.ToArray)
                ' e.Graphics.DrawLine(Pens.Black, 0, (centrepointininchesy() - 12) * me.aspectratio, Me.Width, (centrepointininchesy() - 12) * me.aspectratio)
                'team2
                team2.Add(New Point(0, Me.Height))
                team2.Add(New Point(0, (centrepointininchesy() + 12) * Me.aspectratio))
                team2.Add(New Point(Me.Width, (centrepointininchesy() + 12) * Me.aspectratio))
                team2.Add(New Point(Me.Width, Me.Height))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
                'e.Graphics.DrawLine(Pens.Black, 0, (centrepointininchesy() + 12) * me.aspectratio, Me.Width, (centrepointininchesy() + 12) * me.aspectratio)
            Case Is = 3
                ' Console.WriteLine("Search and Destroy")
                'team1
                e.Graphics.DrawLine(Pens.Black, centrepointactualdimensionsx(), 0, centrepointactualdimensionsx(), (centrepointininchesy() - 9) * Me.aspectratio)
                e.Graphics.DrawArc(Pens.Black, (centrepointininchesx() - 9) * Me.aspectratio, (centrepointininchesy() - 9) * Me.aspectratio, 18 * Me.aspectratio, 18 * Me.aspectratio, 180, 90)
                e.Graphics.DrawLine(Pens.Black, (centrepointininchesx() - 9) * Me.aspectratio, centrepointactualdimensionsy(), 0, centrepointactualdimensionsy())
                'team2
                e.Graphics.DrawLine(Pens.Black, Me.Width, centrepointactualdimensionsy(), mirror_pointx((centrepointininchesx() - 9) * Me.aspectratio), centrepointactualdimensionsy())
                e.Graphics.DrawArc(Pens.Black, (centrepointininchesx() - 9) * Me.aspectratio, (centrepointininchesy() - 9) * Me.aspectratio, 18 * Me.aspectratio, 18 * Me.aspectratio, 0, 90)
                e.Graphics.DrawLine(Pens.Black, centrepointactualdimensionsx(), mirror_pointy((centrepointininchesy() - 9) * Me.aspectratio), centrepointactualdimensionsx(), Me.Height)
            Case Is = 4
                ' Console.WriteLine("Hammer and Anvil")
                'team 1
                team1.Add(New Point(0, 0))
                team1.Add(New Point((centrepointininchesx() - 12) * Me.aspectratio, 0))
                team1.Add(New Point((centrepointininchesx() - 12) * Me.aspectratio, Me.Height))
                team1.Add(New Point(0, Me.Height))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
                'e.Graphics.DrawLine(Pens.Black, (centrepointininchesx() - 12) * me.aspectratio, 0, (centrepointininchesx() - 12) * me.aspectratio, Me.Height)
                'team2
                team2.Add(New Point(mirror_pointx(0), 0))
                team2.Add(New Point(mirror_pointx((centrepointininchesx() - 12) * Me.aspectratio), 0))
                team2.Add(New Point(mirror_pointx((centrepointininchesx() - 12) * Me.aspectratio), Me.Height))
                team2.Add(New Point(mirror_pointx(0), Me.Height))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
                'e.Graphics.DrawLine(Pens.Black, (centrepointininchesx() + 12) * me.aspectratio, 0, (centrepointininchesx() + 12) * me.aspectratio, Me.Height)
            Case Is = 5
                '  Console.WriteLine("Front-line Assault")
                'team1
                team1.Add(New Point(0, 0))
                team1.Add(New Point(0, 6 * Me.aspectratio))
                team1.Add(New Point(centrepointactualdimensionsx(), (centrepointininchesy() - 9) * Me.aspectratio))
                team1.Add(New Point(Me.Width, 6 * Me.aspectratio))
                team1.Add(New Point(0, 6 * Me.aspectratio))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
                'team2
                team2.Add(New Point(0, mirror_pointy(0)))
                team2.Add(New Point(0, mirror_pointy(6 * Me.aspectratio)))
                team2.Add(New Point(centrepointactualdimensionsx(), mirror_pointy((centrepointininchesy() - 9) * Me.aspectratio)))
                team2.Add(New Point(Me.Width, mirror_pointy(6 * Me.aspectratio)))
                team2.Add(New Point(0, mirror_pointy(6 * Me.aspectratio)))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
            Case Is = 6
                '  Console.WriteLine("Vanguard Strike")
                Dim theta As Double '' clockwise angle from x-axis
                theta = Math.Atan(Me.Height / Me.Width)
                Dim xaxisdisplacement As Integer = CInt(12 * Me.aspectratio * (Math.Sin(theta)))
                Dim yaxisdisplacement As Integer = CInt(12 * Me.aspectratio * (Math.Sin(90 - theta)))
                'team1
                team1.Add(New Point(0, Me.Height))
                team1.Add(New Point(0, yaxisdisplacement))
                team1.Add(New Point(Me.Width - xaxisdisplacement, Me.Height))
                e.Graphics.DrawPolygon(Pens.Black, team1.ToArray)
                'team2
                team2.Add(New Point(mirror_pointx(0), mirror_pointy(Me.Height)))
                team2.Add(New Point(mirror_pointx(0), mirror_pointy(yaxisdisplacement)))
                team2.Add(New Point(mirror_pointx(Me.Width - xaxisdisplacement), mirror_pointy(Me.Height)))
                e.Graphics.DrawPolygon(Pens.Black, team2.ToArray)
            Case Else
        End Select
    End Sub
    Private Sub ShootingSelectToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_ShootingSelect.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.identifier = unitfortransferinginfo Then
                    cnt.isselectedtobeshooting = True
                End If
            End If
        Next
        For all = 0 To ActiveWeaponsList.Items.Count - 1 ''reset weapons
            ActiveWeaponsList.Items.RemoveAt(0)
        Next
        Dim foundweapon As Boolean = False
        For Each cnt In Me.Controls ''add new weapons
            If TypeOf cnt Is Unit Then
                If cnt.isselectedtobeshooting = True Then
                    For count2 = 0 To cnt.weapons.length - 1 ''2??dunno why this was here
                        If ActiveWeaponsList.Items.Count = 0 Then
                            foundweapon = False ''no weapons so auto add first weapon
                            GoTo addweapon
                        End If
                        'Console.WriteLine(ActiveWeaponsList.Items.Count & ActiveWeaponsList.Items(0))
                        For count1 = 0 To ActiveWeaponsList.Items.Count - 1
                            If cnt.weapons(count2) = ActiveWeaponsList.Items(count1) Or cnt.weapons(count2) = "" Then ' if item is already in list  and not last in list
                                foundweapon = True
                                Exit For
                            Else
                                foundweapon = False
                            End If
                        Next
addweapon:
                        If foundweapon = False Then
                            ActiveWeaponsList.Items.Add(cnt.weapons(count2))
                        End If
                    Next
                End If
            End If
        Next

    End Sub
    Private Sub ShootingCancelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_ShootingCancel.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.identifier = unitfortransferinginfo Then
                    cnt.isselectedtobeshooting = False
                End If
            End If
        Next
        For all = 0 To ActiveWeaponsList.Items.Count - 1 ''reset weapons
            ActiveWeaponsList.Items.RemoveAt(0)
        Next
        Dim foundweapon As Boolean = False
        For Each cnt In Me.Controls ''add new weapons
            If TypeOf cnt Is Unit Then
                If cnt.isselectedtobeshooting = True Then
                    For count2 = 0 To cnt.weapons.length - 2
                        If ActiveWeaponsList.Items.Count = 0 Then
                            foundweapon = False ''no weapons so auto add first weapon
                            GoTo addweapon
                        End If
                        'Console.WriteLine(ActiveWeaponsList.Items.Count & ActiveWeaponsList.Items(0))
                        For count1 = 0 To ActiveWeaponsList.Items.Count - 1
                            If cnt.weapons(count2) = ActiveWeaponsList.Items(count1) Then ' if item is already in list  and not last in list
                                foundweapon = True
                                Exit For
                            Else
                                foundweapon = False
                            End If
                        Next
addweapon:
                        If foundweapon = False Then
                            ActiveWeaponsList.Items.Add(cnt.weapons(count2))
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Private Sub ShootingCancelAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_ShootingCancelAll.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                cnt.isselectedtobeshooting = False
            End If
        Next
        For all = 0 To ActiveWeaponsList.Items.Count - 1 ''reset weapons
            ActiveWeaponsList.Items.RemoveAt(0)
        Next
    End Sub
    Private Sub TargetSelectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_TargetSelect.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.identifier = unitfortransferinginfo Then
                    cnt.isselectedtobetarget = True
                End If
            End If
        Next
    End Sub
    Private Sub TargetCancelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_TargetCancel.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.identifier = unitfortransferinginfo Then
                    cnt.isselectedtobetarget = False
                End If
            End If
        Next
    End Sub
    Private Sub TargetCancelAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_TargetCancelAll.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                cnt.isselectedtobetarget = False
            End If
        Next
    End Sub
    Private Sub checkdamage()
        Dim cnthasexplodes As Boolean = False
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                If cnt.currentwounds <= 0 Then
                    ''check abilites for explodes
                    For x As Integer = 0 To cnt.abilities.length - 1
                        ''    If cnt.abilities(x) <> Nothing Then
                        Try
                            If cnt.abilities(x).contains("Explodes") And cnt.visible = True Then
                                cnthasexplodes = True
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If cnt.exploded = False And cnt.visible = True And cnthasexplodes = True Then
                        ' If rolld(6) > 0 Then ' = 6 Then
                        cnthasexplodes = False
                        Console.WriteLine(cnt.nameofmodel & " explodes damaging nearby units")
                        cnt.exploded = True
                        For Each unit In Me.Controls
                            If TypeOf unit Is Unit Then
                                If calcdistancebetweentwoobjects(cnt.left + cnt.width / 2, cnt.top + cnt.height / 2, unit.left + unit.width / 2, unit.top + unit.height / 2) <= 3 And unit.exploded = False Then
                                    unit.currentwounds -= rolld(3)
                                    Console.WriteLine(unit.nameofmodel & " is damaged by the explosion")
                                    ' checkdamage() ''chain explodes togheter checker
                                    Exit For
                                End If
                            End If
                        Next
                        'End If
                    End If
                    If cnt.visible = True Then
                        Console.WriteLine(cnt.nameofmodel & " is now invisible")
                        cnt.visible = False
                        cnt.backcolor = SystemColors.Control
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub resetscenery(sender As System.Object, e As System.EventArgs)
        Functions.GeneratePlanetDescription()
    End Sub

    Private Sub Map_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' If File.Exists(Race_Selection_Form.SaveFilename) Then
        Dim PicBoxListforUnits As New List(Of PicBoxInfo)()
        Dim PicBoxListforScenery As New List(Of PicBoxInfo)()
        Dim ScenerySaveFileStream As Stream = File.Create(Race_Selection_Form.ScenerySaveFilename)
        Dim UnitsSaveFileStream As Stream = File.Create(Race_Selection_Form.UnitsSaveFilename)
        Dim Serializer As New BinaryFormatter
        For Each cnt In Me.Controls
            If TypeOf cnt Is Unit Then
                Dim ThisPicBoxInfoForUnits As New PicBoxInfo
                With ThisPicBoxInfoForUnits
                    .Width = cnt.Width
                    .Height = cnt.Height
                    .Name = cnt.Name
                    .Left = cnt.left
                    .Top = cnt.top
                    .nameofmodel = cnt.nameofmodel
                    .Sizemode = cnt.sizemode
                    .Identifier = cnt.identifier


                    .MoveDistance = cnt.MoveDistance
                    .Identifier = cnt.Identifier
                    .CanMove = cnt.CanMove
                    .Canshoot = cnt.Canshoot
                    .WeaponSkill = cnt.WeaponSkill
                    .BallisticSkill = cnt.BallisticSkill
                    .Strength = cnt.Strength
                    .Toughness = cnt.Toughness
                    .CurrentWounds = cnt.CurrentWounds
                    .MaxWounds = cnt.MaxWounds
                    .MortalWounds = cnt.MortalWounds
                    .Attacks = cnt.Attacks
                    .Leadership = cnt.Leadership
                    .Save = cnt.Save
                    .invulnerablesave = cnt.invulnerablesave
                    .Psyker = cnt.Psyker
                    ReDim .Weapons(cnt.weapons.length - 1)
                    ' Console.WriteLine(.Weapons & " " & cnt.weapons)
                    .Weapons = cnt.Weapons()
                    .hasadvanced = cnt.hasadvanced
                    .hasmoved = cnt.hasmoved
                    .isshooting = cnt.isshooting
                    .istarget = cnt.istarget
                    .isselectedtobeshooting = cnt.isselectedtobeshooting
                    .isselectedtobetarget = cnt.isselectedtobetarget
                    ReDim .abilities(cnt.abilities.length - 1)
                    .abilities = cnt.abilities()
                    'ReDim .psykerpowers(cnt.psykerpowers.length - 1)
                    '.psykerpowers = cnt.psykerpowers()
                    'ReDim .factiontags(cnt.factiontags.length - 1)
                    '.factiontags = cnt.factiontags()
                    .numberofpsykerpowers = cnt.numberofpsykerpowers
                    .numberofdenythewitch = cnt.numberofdenythewitch
                    .exploded = cnt.exploded
                    .TeamId = cnt.teamid



                    .visible = cnt.visible
                End With
                PicBoxListforUnits.Add(ThisPicBoxInfoForUnits)
            End If


            If TypeOf cnt Is Scenery Then
                Dim ThisPicBoxInfoForScenery As New PicBoxInfo
                With ThisPicBoxInfoForScenery
                    .Width = cnt.Width
                    .Height = cnt.Height
                    .Name = cnt.Name
                    .Left = cnt.left
                    .Top = cnt.top
                    .Tag = cnt.tag
                    .Sizemode = cnt.sizemode
                End With
                PicBoxListforScenery.Add(ThisPicBoxInfoForScenery)
            End If
        Next
        'End If
        Serializer.Serialize(UnitsSaveFileStream, PicBoxListforUnits)
        Serializer.Serialize(ScenerySaveFileStream, PicBoxListforScenery)
        ScenerySaveFileStream.Close()
        UnitsSaveFileStream.Close()
    End Sub
End Class