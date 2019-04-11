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
    Public currentteam As Integer
    Public heightofmap As Integer
    Dim damagephases As Boolean = False
    Dim leadershipphases As Boolean = False
    Dim unitfortransferinginfo As Integer
    Private Property pageready As Boolean = False
    Dim countdamage As Integer
    Public unitidentifier As New DataTable
    Public groupidentifier As New DataTable
    '   Dim stringtester() As String = {"1", "2", "3"}
    Public Coordinates As List(Of PicBoxInfo)
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
    Public skipshooting As Boolean = False
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
        Console.WriteLine(Me.Height)
        ''senery section
        minfromleft = 12 * aspectratio
        minfromright = 12 * aspectratio
        minfromtop = 3 * aspectratio
        minfrombottom = 3 * aspectratio
        numberofobjects = 6
        marginofscenery = 1 * aspectratio
        Dim counterofobjects As Integer = 0
        Dim sceneryobject As New Scenery
        Dim srlatch As Boolean = True ' simple set-reset switch
        Randomize()
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
                AddSceneryToMap(leftcornerofscenery, topcornerofscenery, 26, 26, False, False, 0, False, 0)
            End If
        Loop
        '1:Captain in Terminator Armour@Thunder hammer$Super Duper Mega Weapon~1:Captain in Terminator Armour@Thunder hammer$Super Duper Mega Weapon~2:Librarian in Terminator Armour@Plasma cannon~3:Scout Sergeant~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~4:Veteran Sergeant~4:Space Marine Veteran~4:Space Marine Veteran@Plasma cannon~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran@~4:Space Marine Veteran~4:Space Marine Veteran~5:Apothecary~6:Space Marine Sergeant@Combi-flamer~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~7:Space Marine Sergeant@Combi-flamer$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~8:Whirlwind@Hunter-killer missile$Storm bolter~9:Stormtalon Gunship@two Lascannons$Hunter-killer missile$Storm bolter
        Race_Selection_Form.Playerid = 1
        'Console.WriteLine(Team_Setup.playeronearmy.Count)
        'Dim temp As New List(Of List(Of String)) From {New List(Of String) From {("1:Apothecary")}, New List(Of String) From {("2:Captain"), ("Storm shield"), ("Thunder hammer")}}


        'Team_Setup.playeronearmy.Addrange(("1:Apothecary"),("2:Captain","Storm shield","Thunder hammer"),("3:Chaplain","Grav-pistol")) ~4:Company Ancient@Combi-grav~5:Company Champion~6:Space Marine Sergeant@Combi-grav~6:Space Marine@Grav-cannon And Grav-amp~6:Space Marine@Grav-cannon And Grav-amp~6:Space Marine@Grav-cannon And Grav-amp~6:Space Marine@Grav-cannon And Grav-amp~6:Space Marine~6:Space Marine~6:Space Marine~6:Space Marine~6:Space Marine~7:Land Speeders$Typhoon missile launcher~7:Land Speeders$Typhoon missile launcher~7:Land Speeders$Typhoon missile launcher~8:Predator@twin Lascannon$two Lascannons$Hunter-killer missile$Storm bolter~9:Scout Sergeant@Chainsword$Thunder hammer$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~9:Scout@Sniper rifle$Camo Cloak~10:Venerable Dreadnought@Twin lascannon~11:Whirlwind@Hunter-killer missile$Storm bolter~12:Techmarine@Chainsword$Combi-flamer$Conversion beamer~13:Space Marine Sergeant@Combi-grav$Power fist~13:Space Marine@Hunter-killer missile$Storm bolter~13:Space Marine@Grav-cannon and Grav-amp~13:Space Marine@Grav-gun~13:Space Marine~13:Space Marine~13:Space Marine~13:Space Marine~13:Space Marine~13:Space Marine~14:Veteran Sergeant@Combi-grav$Power axe~14:Space Marine Veteran@Grav-cannon And Grav-amp~14:Space Marine Veteran@Grav-cannon And Grav-amp~14:Space Marine Veteran@Combi-grav~14:Space Marine Veteran@Combi-grav~14:Space Marine Veteran@Combi-grav~14:Space Marine Veteran@Combi-grav~14:Space Marine Veteran@Combi-grav~14:Space Marine Veteran@Combi-grav~14:Space Marine Veteran@Combi-grav~15:Veteran Sergeant@Storm shield$Power Sword$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~15:Space Marine Veteran@Storm shield$Thunder hammer$Jump Pack$Melta Bomb~16:Terminator Sergeant@Lightning Claws~16:Terminator@Lightning Claws~16:Terminator@Lightning Claws~16:Terminator@Lightning Claws~16:Terminator@Lightning Claws~16:Terminator@Thunder Hammer$Storm Shield~16:Terminator@Thunder Hammer$Storm Shield~16:Terminator@Thunder Hammer$Storm Shield~16:Terminator@Thunder Hammer$Storm Shield~16:Terminator@Thunder Hammer$Storm Shield~17:Terminator Sergeant~17:Terminator@Cyclone missile launcher And Storm bolter~17:Terminator~17:Terminator~17:Terminator~17:Terminator~17:Terminator~17:Terminator~17:Terminator~17:Terminator~18:Stormraven Gunship@two Hurricane bolters$two Stormstrike Missile Launchers"
        'Team_Setup.playertwoarmy = "1:Grey Knight Apothecary~2:Archon~3:Grey Knight Apothecary~4:Captain~5:Captain~6:Captain~7:Sergeant~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman~7:Guardsman" '~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader~8:Knight Crusader"
        'Team_Setup.playeroneteam = 1
        'Team_Setup.playertwoteam = 2
        TSMI_Apply_Damage.Enabled = False
        TSMI_Model_flees.Enabled = False
        Dim j As Integer = 0
        'Dim team As Integer = 1
        'Console.WriteLine(Race_Selection_Form.maxplayers)
        Label2.Text = "Current Phase: " & phasename
        For players = 1 To Race_Selection_Form.maxplayers

            Race_Selection_Form.Playerid = players
            'Next
            'Console.WriteLine(Race_Selection_Form.Playerid)
            Dim storage As New List(Of ModelsAndWeaponsForTransferingtoMap)
            Select Case Race_Selection_Form.Playerid
                Case Is = 1
                    currentteam = Team_Setup.playeroneteam
                    storage.AddRange(Team_Setup.playeronearmy)
                Case Is = 2
                    currentteam = Team_Setup.playertwoteam
                    storage.AddRange(Team_Setup.playertwoarmy)
                Case Is = 3
                    currentteam = Team_Setup.playerthreeteam
                    storage.AddRange(Team_Setup.playerthreearmy)
                Case Is = 4
                    currentteam = Team_Setup.playerfourteam
                    storage.AddRange(Team_Setup.playerfourarmy)
                Case Is = 5
                    currentteam = Team_Setup.playerfiveteam
                    storage.AddRange(Team_Setup.playerfivearmy)
                Case Is = 6
                    currentteam = Team_Setup.playersixteam
                    storage.AddRange(Team_Setup.playersixarmy)
                Case Is = 7
                    currentteam = Team_Setup.playerseventeam
                    storage.AddRange(Team_Setup.playersevenarmy)
                Case Is = 8
                    currentteam = Team_Setup.playereightteam
                    storage.AddRange(Team_Setup.playereightarmy)
            End Select


            TransferUnits(storage)

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
        'Console.WriteLine("###")
        If Race_Selection_Form.Loadrecentgame Then
            For i = Me.Controls.Count - 1 To 0 Step -1
                If TypeName(Me.Controls.Item(i)) = "Unit" Then
                    Me.Controls.RemoveAt(i)
                End If
                'Me.Controls.Remove(cnt)
                'End If
            Next
            Dim StringListforUnits As New List(Of PicBoxInfo)()
            Dim StringListforScenery As New List(Of PicBoxInfo)()
            Dim ScenerySaveFileStream As Stream = File.Open(Race_Selection_Form.ScenerySaveFilename, FileMode.Open, FileAccess.Read)
            Dim UnitsSaveFileStream As Stream = File.Open(Race_Selection_Form.UnitsSaveFilename, FileMode.Open, FileAccess.Read)
            Dim Deserializer As New BinaryFormatter

            StringListforUnits = Deserializer.Deserialize(UnitsSaveFileStream)

            For i = 0 To StringListforUnits.Count - 1
                With StringListforUnits(i)
                    AddUnitToMap(.Identifier, .nameofmodel, .Left, .Top, .Width, .Height, .visible, .Psyker, .MoveDistance, .WeaponSkill, .BallisticSkill, .Strength, .Toughness, .CurrentWounds, .MaxWounds, .MortalWounds, .Attacks, .Leadership, .Save, .Weapons, .TeamId, .CanMove, .Canshoot, .hasmoved, .hasadvanced, .istarget, .isshooting, .isselectedtobetarget, .isselectedtobeshooting, .abilities, .psykerpowers, .numberofpsykerpowers, .numberofdenythewitch, .invulnerablesave, .factiontags, .exploded)
                End With
            Next

            For i = 0 To StringListforScenery.Count - 1
                With StringListforScenery(i)
                    AddSceneryToMap(.Left, .Top, 26, 26, False, False, 0, False, 0)
                End With
            Next
            Invalidate()
            ScenerySaveFileStream.Close()
            UnitsSaveFileStream.Close()
        End If
        
    End Sub
    Public Sub Unit_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        ' Console.WriteLine(sender.nameofmodel)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If damagephases = True And leadershipphases = False Then
                TSMI_Apply_Damage.Enabled = True
                TSMI_Model_flees.Enabled = False
                'If sender.currentwounds <
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
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
        If TypeOf sender Is Model And sender.CanMove = True Then
            oldcornerx = sender.left
            oldcornery = sender.top
            radius = sender.movedistance
            oldcenterx = oldcornerx + sender.width / 2
            oldcentery = oldcornery + sender.height / 2
            oldcenterxforcircle = oldcenterx - radius
            oldcenteryforcircle = oldcentery - radius
            AddHandler Me.Paint, AddressOf Map_Paint
        End If
        'Dim listofallweapons As String = ""
        'For x = 0 To sender.weapons.count - 1
        '    If listofallweapons = "" Then
        '        listofallweapons = sender.weapons(x)
        '    Else
        '        listofallweapons = listofallweapons & ", " & sender.weapons(x)
        '    End If
        'Next
        Label2.Text = "Name: " & sender.nameofmodel & vbCrLf & "Coordinates: " & oldcenterx & ", " & oldcentery & vbCrLf & "Movement Distance: " & sender.movedistance / aspectratio & vbCrLf & "Wounds: " & sender.CurrentWounds & vbCrLf & "Moveable: " & sender.canmove & vbCrLf & "Can Shoot: " & sender.canshoot
        Me.Invalidate()
    End Sub
    Private Sub Map_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawEllipse(Pens.Black, oldcenterxforcircle, oldcenteryforcircle, radius * 2, radius * 2)
    End Sub
    Public Sub unitaspb_MouseLeave(sender As Object, e As System.EventArgs)
        If TypeOf sender Is Model Then
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
                    If TypeOf cnt Is Model Then
                        cnt.CanMove = True
                        cnt.canshoot = False
                    End If
                Next
            Case Is = 2
                phasename = "Psychic Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        cnt.CanMove = False
                        cnt.canshoot = False
                    End If
                Next
                UseSelectedWeapon.Text = "Use Selected Psychic Power"
            Case Is = 3
                phasename = "Shooting Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        cnt.CanMove = False
                        cnt.canshoot = True
                    End If
                Next
                UseSelectedWeapon.Text = "Use Selected Weapon"
            Case Is = 4
                phasename = "Charge Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        cnt.CanMove = True
                        cnt.canshoot = True
                    End If
                Next
                UseSelectedWeapon.Text = "Charge Selected Unit"
            Case Is = 5
                phasename = "Fight Phase"
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        cnt.CanMove = True
                        cnt.canshoot = True
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
                    If TypeOf cnt Is Model Then
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
        If TypeOf sender Is Model And sender.canmove = True Then
            Dim newcornerx As Integer = sender.left
            Dim newcornery As Integer = sender.top
            Dim newcenterx As Integer = newcornerx + sender.width / 2
            Dim newcentery As Integer = newcornery + sender.height / 2
            Dim actualdistance As Double = Math.Sqrt((newcenterx - oldcenterx) * (newcenterx - oldcenterx) + (newcentery - oldcentery) * (newcentery - oldcentery))
            If actualdistance > sender.movedistance Then
                ''y=mx+c calc
                Dim dy As Double = (newcornery - oldcornery) / actualdistance
                Dim dx As Double = (newcornerx - oldcornerx) / actualdistance
                sender.top = oldcornery + sender.movedistance * dy
                sender.left = oldcornerx + sender.movedistance * dx


                'Dim angle As Double = Math.Atan(gradient)
                'Dim left As Integer = oldcenterx + sender.movedistance * Math.Cos(angle)
                'Dim top As Integer = oldcentery + sender.movedistance * Math.Sin(angle)
                '
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
                Functions.WeaponsTable(ActiveWeaponsList.SelectedIndex.ToString)
                'If AllWargear.Rows(0).Item(2).ToString = "Assault" Then
                '    assault = WargearandWeaponStats.assault(sender.hasadvanced)
                'ElseIf AllWargear.Rows(0).Item(2).ToString = "Heavy" Then
                '    heavy = WargearandWeaponStats.heavy(sender.hasmoved)
                'End If
                If skipshooting Then
                    GoTo skipshooting
                End If
                Target_selection()
                Dim mortalwoundstoshooter As Boolean
                Unit_Information.Visible = False
                Dim Squadname As String = "Scouts"
                For Each shootingcont In Me.Controls
                    If TypeOf shootingcont Is Model Then
                        If shootingcont.isshooting = True And shootingcont.visible = True Then
                            ''after hit roll checks
                            For z = 0 To Coordinates.Count - 1 '' checks range of all targets
                                'Console.WriteLine(calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).X, Coordinates(z).Y))
                                If calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).Left, Coordinates(z).Top) > CInt(AllWargear.Rows(0).Item(1)) Then
                                    MsgBox("Some or all targeted units are outside the range of this weapon. Please select target(s) inside the range of the chosen weapon")
                                    Exit Sub
                                End If
                                Dim losblocking As Boolean = False ' by default the unit(s) will be able to shoot
                                For Each sceneryobject In Me.Controls
                                    If TypeOf sceneryobject Is Scenery Then

                                    End If
                                Next
                                If losblocking = True Then
                                    MsgBox("Some or all targeted units are blocked by line of sight to shooting unit(s). Please select target(s) or shooter(s) that are visible to each other..")
                                    Exit Sub
                                End If
                                numberofhitrolls = AllWargear.Rows(0).Item(3).ToString
                                numberofwoundrolls = 0
                                numberofsaverolls = 0
                                strength = AllWargear.Rows(0).Item(4).ToString
                                ap = AllWargear.Rows(0).Item(5).ToString
                                damage = AllWargear.Rows(0).Item(6)
                                ''before hit roll checks
                                If AllWargear.Rows(0).Item(0).ToString = "Astartes shotgun" And (calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).Left, Coordinates(z).Top) < CInt(AllWargear.Rows(0).Item(1)) / 2) Then
                                    strength += 1
                                End If
                                If AllWargear.Rows(0).Item(0).ToString = "Conversion beamer" And (calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).Left, Coordinates(z).Top) > CInt(AllWargear.Rows(0).Item(1)) / 2) Then
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
                                If AllWargear.Rows(0).Item(0).ToString.Contains("melta") Or AllWargear.Rows(0).Item(0).ToString.Contains("Melta") Or AllWargear.Rows(0).Item(0).ToString = "Inferno pistol" And Not (AllWargear.Rows(0).Item(0).ToString = "Melta bomb") And (calcdistancebetweentwoobjects(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).Left, Coordinates(z).Top) < CInt(AllWargear.Rows(0).Item(1)) / 2) Then
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
            Case Is = 4 ''charge phase
                Target_selection()
                Unit_Information.Visible = False
                Dim distance As Decimal
                Dim longestdistance As Decimal = 0
                Dim shortestdistance As Decimal = Me.Width
                Dim Squadname As String = "Scouts"
                For Each shootingcont In Me.Controls
                    If TypeOf shootingcont Is Model Then
                        If shootingcont.isshooting = True And shootingcont.visible = True Then
                            ''after hit roll checks

                            For z = Coordinates.Count - 1 To 0 Step -1 '' checks range of all targets, reverse order because of removeat

                                distance = calcdistancebetweentwoobjectedges(shootingcont.left + shootingcont.width / 2, shootingcont.top + shootingcont.height / 2, Coordinates(z).Left, Coordinates(z).Top, shootingcont.width, shootingcont.height, Coordinates(z).Width, Coordinates(z).Height)
                                If longestdistance < distance Then
                                    longestdistance = distance
                                End If
                                If shortestdistance > distance Then
                                    shortestdistance = distance
                                End If
                            Next
                            If longestdistance > 12 Then
                                longestdistance = 12
                            End If

                            If shortestdistance < 1 Then
                                Console.WriteLine("Some Models are already in combat")
                            End If
                        End If
                    End If
                Next
                For z = Coordinates.Count - 1 To 0 Step -1
                    '#########~#@#@
                Next
                '##############  DICE ROLLING STARTS HERE  ##############'
                Dim a As Integer = rolld(6)
                Dim b As Integer = rolld(6)
                Dim c As Integer = rolld(6) '' some abilities require 3 rolls discarding the lowest
                'If shootingcont.abilities = "bla bla bla" Then code for 3 rolls discarding lowest
                '    If c > a Then
                '        a = c
                '    ElseIf c > b Then
                '        b = c
                '    End If
                'End If
                If a + b > Math.Round(longestdistance) Then
                    Console.WriteLine("All Units are in")
                ElseIf a + b < Math.Round(shortestdistance) Then
                    Console.WriteLine("No Units are in")
                End If
        End Select
    End Sub
    Private Sub ShootUnit_Click(sender As System.Object, e As System.EventArgs) Handles ShootUnit.Click
        Select Case phasenumber
            Case Is = 3
                For Each shootingcont In Me.Controls
                    If TypeOf shootingcont Is Model Then
                        If shootingcont.isselectedtobeshooting = True Then
                            shootingcont.isshooting = True
                            Console.WriteLine(shootingcont.nameofmodel & " is selected to be shooting")
                        Else
                            shootingcont.isshooting = False
                        End If
                    End If
                Next
            Case Is = 4
        End Select



    End Sub
    Private Sub TargetUnit_Click(sender As System.Object, e As System.EventArgs) Handles TargetUnit.Click
        Select Case phasenumber
            Case Is = 3
                For Each targetcont In Me.Controls
                    If TypeOf targetcont Is Model Then
                        If targetcont.isselectedtobetarget = True Then
                            targetcont.istarget = True
                            Console.WriteLine(targetcont.nameofmodel & " is selected to be one of the targets")
                        Else
                            targetcont.istarget = False
                        End If
                    End If
                Next
            Case Is = 4
        End Select
    End Sub
    Private Sub TSMI_Apply_Damage_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_Apply_Damage.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Model Then
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

    Private Sub TSMI_Model_flees_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_Model_flees.Click
        For Each cnt In Me.Controls
            If TypeOf cnt Is Model Then
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
        Select Case phasenumber
            Case Is = 3

                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
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
                    If TypeOf cnt Is Model Then
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
            Case Is = 4
        End Select
    End Sub
    Private Sub ShootingCancelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_ShootingCancel.Click
        Select Case phasenumber
            Case Is = 3
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
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
                    If TypeOf cnt Is Model Then
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
            Case Is = 4
        End Select
    End Sub
    Private Sub ShootingCancelAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_ShootingCancelAll.Click
        Select Case phasenumber
            Case Is = 3

                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        cnt.isselectedtobeshooting = False
                    End If
                Next
                For all = 0 To ActiveWeaponsList.Items.Count - 1 ''reset weapons
                    ActiveWeaponsList.Items.RemoveAt(0)
                Next
            Case Is = 4
        End Select
    End Sub
    Private Sub TargetSelectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_TargetSelect.Click
        Select Case phasenumber
            Case Is = 3

                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        If cnt.identifier = unitfortransferinginfo Then
                            cnt.isselectedtobetarget = True
                        End If
                    End If
                Next
            Case Is = 4
        End Select
    End Sub
    Private Sub TargetCancelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_TargetCancel.Click
        Select Case phasenumber
            Case Is = 3

                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        If cnt.identifier = unitfortransferinginfo Then
                            cnt.isselectedtobetarget = False
                        End If
                    End If
                Next
            Case Is = 4
        End Select
    End Sub
    Private Sub TargetCancelAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_TargetCancelAll.Click
        Select Case phasenumber
            Case Is = 3
                For Each cnt In Me.Controls
                    If TypeOf cnt Is Model Then
                        cnt.isselectedtobetarget = False
                    End If
                Next
            Case Is = 4
        End Select
    End Sub
    Private Sub checkdamage()
        Dim cnthasexplodes As Boolean = False
        For Each cnt In Me.Controls
            If TypeOf cnt Is Model Then
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
                            If TypeOf unit Is Model Then
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
        Dim PicBoxListforUnits As New List(Of PicBoxInfo)
        Dim PicBoxListforScenery As New List(Of PicBoxInfo)
        Dim ScenerySaveFileStream As Stream = File.Create(Race_Selection_Form.ScenerySaveFilename)
        Dim UnitsSaveFileStream As Stream = File.Create(Race_Selection_Form.UnitsSaveFilename)
        Dim Serializer As New BinaryFormatter
        For Each cnt In Me.Controls
            If TypeOf cnt Is Model Then
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
                    'ReDim .Weapons(cnt.weapons.length - 1)
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