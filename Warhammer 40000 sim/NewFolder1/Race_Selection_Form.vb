Imports System.IO
Public Class Race_Selection_Form
    Public UnitsSaveFilename As String = Application.StartupPath & "\MostRecentSaveUnits.bin"
    Public ScenerySaveFilename As String = Application.StartupPath & "\MostRecentSaveScenery.bin"
    Public Loadrecentgame As Boolean = False
    Public Playerid As Integer = 1
    Public maxplayers As Integer = 2
    Public playeronerace As Integer = 0
    Public playertworace As Integer = 0
    Public playerthreerace As Integer = 0
    Public playerfourrace As Integer = 0
    Public playerfiverace As Integer = 0
    Public playersixrace As Integer = 0
    Public playersevenrace As Integer = 0
    Public playereightrace As Integer = 0
    Public unitid As Integer
    Public mapheight1 As Integer
    Public mapwidth1 As Integer
    Dim usedeploymentmaps As Boolean
    Public setdeploymentmap As Integer = 0
    Dim Introtext As String = "Current Date: 1 768 998.M41" & vbCrLf & "Galactic Position: UL/XIS/GIN/378/253" & vbCrLf & "Planet Name: NATIS" & vbCrLf & "Planetary Size: Medium 35 000km at Equator" & vbCrLf & "Moons: 4" & vbCrLf & "Class: Developing" & vbCrLf & "Tech Level: Industrial" & vbCrLf & "Star size: Medium" & vbCrLf & "Designation: Adeptus Astartes Recruitment World" & vbCrLf & "Previous Class: Feudal Jungle/Desert World" & vbCrLf & "Inhabitants: Imperial Citizens, Natis Fusiliers PDF" & vbCrLf & "Notable Visitors: Survivors of Order of the Lazuline Reliquary, Space Marines of the Doom Wyverns Chapter"
    '"Current Date: 1 768 998.M41" & vbCrLf & "Planet: NATIS" & vbCrLf & "Designation: Recruitment and Developing Industrial World" & vbCrLf & "Previous Class: Feudal Jungle/Desert World" & vbCrLf & "Inhabitants: Imperial Citzens, Natis Fuiliers PDF" & vbCrLf & "Notable Visitors: Survivors of Order of the Lazuline Reliquary, Space Marines of the Doom Wyverns Chapter" & vbCrLf & "Reason for Visit: Currently Unknown for Adeptus Sororitas otherwise Training new Initiates for the Space Marines"
    Dim introtextcounter As Integer = 0




    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Console.WriteLine(Application.StartupPath & " " & Application.ExecutablePath)
        Console.WriteLine(aunitfromallunit(1, 1))
        GeneratePlanetDescription()
        'Console.WriteLine(SaveFilename)
        If File.Exists(UnitsSaveFilename) And File.Exists(ScenerySaveFilename) Then
            If MsgBox("Do you want to load most recent save", MsgBoxStyle.YesNo, "Setup") = 6 Then
                Loadrecentgame = True
            End If
        End If





        Try
            If MsgBox("Use Deployment zones/maps?", MsgBoxStyle.YesNo, "Setup") = 6 Then
                usedeploymentmaps = True

deployment:
                ''spearhead,dawn of war, search and destroy,hammer and anvil,frontline assault,vanguard strike
                setdeploymentmap = CInt(InputBox("Use a specific map?: " & vbCrLf & "1 for Spearhead, 2 for Dawn of War, 3 for Search and Destroy, 4 for Hammer and Anvil, 5 for Frontline Assault, 6 for Vanguard Strike, 7 for Random Map"))
                If setdeploymentmap < 1 Or setdeploymentmap > 7 Then
                    MsgBox("Error input outside bounds please try again")
                    GoTo deployment
                End If
                If setdeploymentmap = 7 Then
                    setdeploymentmap = rolld(6)
                    Console.WriteLine("Rolling for deployment zone map")
                End If
            Else
                usedeploymentmaps = False
                setdeploymentmap = 0
            End If

        Catch ex As Exception
            MsgBox("Error input outside bounds please try again")
            GoTo deployment
        End Try
        Try
mapwidth:
            mapwidth1 = Convert.ToInt16(InputBox("What is the Map width (in inches)?", "Setup", "72"))
            If mapwidth1 > 120 Then
                MsgBox("More than one hundered and twenty inches for map width is not currently supported. Please Try Again")
                GoTo mapwidth
            End If
        Catch ex As Exception
            MsgBox("Invalid Input. Try Again")
            GoTo mapwidth
        End Try

        Try
mapheight:
            mapheight1 = Convert.ToInt16(InputBox("What is the Map height (in inches)?", "Setup", "48"))
            If mapheight1 > 80 Then
                MsgBox("More than eighty inches for map height is not not currently supported. Please Try Again")
                GoTo mapheight
            End If
        Catch ex As Exception
            MsgBox("Invalid Input. Try Again")
            GoTo mapheight

        End Try


        Try
EntermaxPlayers:
            maxplayers = Convert.ToInt16(InputBox("How many Players?", "Setup", "2"))
            If maxplayers > 8 Then
                MsgBox("More than eight players is not currently supported. Please Try Again")
                GoTo EntermaxPlayers
            End If
        Catch ex As Exception
            MsgBox("Invalid Input. Try Again")
            GoTo EntermaxPlayers
        End Try
        Timer1.Enabled = True
        Timer1.Start()
        Timer2.Enabled = True
        Timer2.Start()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub Player1_Race_Selection_Enter(sender As System.Object, e As System.EventArgs) Handles MyBase.Enter
        Label1.Text = "Player " & Playerid & " Select your race"
    End Sub

    Private Sub Race_Space_Marines_Click(sender As System.Object, e As System.EventArgs) Handles Race_Space_Marines.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 12
            Case Is = 2
                playertworace = 12
            Case Is = 3
                playerthreerace = 12
            Case Is = 4
                playerfourrace = 12
            Case Is = 5
                playerfiverace = 12
            Case Is = 6
                playersixrace = 12
            Case Is = 7
                playersevenrace = 12
            Case Is = 8
                playereightrace = 12
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Orks_Click(sender As System.Object, e As System.EventArgs) Handles Race_Orks.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 1
            Case Is = 2
                playertworace = 1
            Case Is = 3
                playerthreerace = 1
            Case Is = 4
                playerfourrace = 1
            Case Is = 5
                playerfiverace = 1
            Case Is = 6
                playersixrace = 1
            Case Is = 7
                playersevenrace = 1
            Case Is = 8
                playereightrace = 1
        End Select
        RaceSelectiontoTeamSelection()
        Map.Show()
        Map.BringToFront()

       
    End Sub

    Private Sub Race_Eldar_Click(sender As System.Object, e As System.EventArgs) Handles Race_Eldar.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 2
            Case Is = 2
                playertworace = 2
            Case Is = 3
                playerthreerace = 2
            Case Is = 4
                playerfourrace = 2
            Case Is = 5
                playerfiverace = 2
            Case Is = 6
                playersixrace = 2
            Case Is = 7
                playersevenrace = 2
            Case Is = 8
                playereightrace = 2
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Chaos_Space_Marines_Click(sender As System.Object, e As System.EventArgs) Handles Race_Chaos_Space_Marines.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 3
            Case Is = 2
                playertworace = 3
            Case Is = 3
                playerthreerace = 3
            Case Is = 4
                playerfourrace = 3
            Case Is = 5
                playerfiverace = 3
            Case Is = 6
                playersixrace = 3
            Case Is = 7
                playersevenrace = 3
            Case Is = 8
                playereightrace = 3
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Imperial_Guard_Click(sender As System.Object, e As System.EventArgs) Handles Race_Imperial_Guard.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 4
            Case Is = 2
                playertworace = 4
            Case Is = 3
                playerthreerace = 4
            Case Is = 4
                playerfourrace = 4
            Case Is = 5
                playerfiverace = 4
            Case Is = 6
                playersixrace = 4
            Case Is = 7
                playersevenrace = 4
            Case Is = 8
                playereightrace = 4
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Tau_Click(sender As System.Object, e As System.EventArgs) Handles Race_Tau.Click
       
        Select Case Playerid
            Case Is = 1
                playeronerace = 5
            Case Is = 2
                playertworace = 5
            Case Is = 3
                playerthreerace = 5
            Case Is = 4
                playerfourrace = 5
            Case Is = 5
                playerfiverace = 5
            Case Is = 6
                playersixrace = 5
            Case Is = 7
                playersevenrace = 5
            Case Is = 8
                playereightrace = 5
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Necrons_Click(sender As System.Object, e As System.EventArgs) Handles Race_Necrons.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 6
            Case Is = 2
                playertworace = 6
            Case Is = 3
                playerthreerace = 6
            Case Is = 4
                playerfourrace = 6
            Case Is = 5
                playerfiverace = 6
            Case Is = 6
                playersixrace = 6
            Case Is = 7
                playersevenrace = 6
            Case Is = 8
                playereightrace = 6
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Dark_Eldar_Click(sender As System.Object, e As System.EventArgs) Handles Race_Dark_Eldar.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 7
            Case Is = 2
                playertworace = 7
            Case Is = 3
                playerthreerace = 7
            Case Is = 4
                playerfourrace = 7
            Case Is = 5
                playerfiverace = 7
            Case Is = 6
                playersixrace = 7
            Case Is = 7
                playersevenrace = 7
            Case Is = 8
                playereightrace = 7
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_SoB_Click(sender As System.Object, e As System.EventArgs) Handles Race_SoB.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 8
            Case Is = 2
                playertworace = 8
            Case Is = 3
                playerthreerace = 8
            Case Is = 4
                playerfourrace = 8
            Case Is = 5
                playerfiverace = 8
            Case Is = 6
                playersixrace = 8
            Case Is = 7
                playersevenrace = 8
            Case Is = 8
                playereightrace = 8
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Tyranids_Click(sender As System.Object, e As System.EventArgs) Handles Race_Tyranids.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 9
            Case Is = 2
                playertworace = 9
            Case Is = 3
                playerthreerace = 9
            Case Is = 4
                playerfourrace = 9
            Case Is = 5
                playerfiverace = 9
            Case Is = 6
                playersixrace = 9
            Case Is = 7
                playersevenrace = 9
            Case Is = 8
                playereightrace = 9
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Chaos_Daemons_Click(sender As System.Object, e As System.EventArgs) Handles Race_Chaos_Daemons.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 10
            Case Is = 2
                playertworace = 10
            Case Is = 3
                playerthreerace = 10
            Case Is = 4
                playerfourrace = 10
            Case Is = 5
                playerfiverace = 10
            Case Is = 6
                playersixrace = 10
            Case Is = 7
                playersevenrace = 10
            Case Is = 8
                playereightrace = 10
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Race_Inquisition_Click(sender As System.Object, e As System.EventArgs) Handles Race_Inquisition.Click
        Select Case Playerid
            Case Is = 1
                playeronerace = 11
            Case Is = 2
                playertworace = 11
            Case Is = 3
                playerthreerace = 11
            Case Is = 4
                playerfourrace = 11
            Case Is = 5
                playerfiverace = 11
            Case Is = 6
                playersixrace = 11
            Case Is = 7
                playersevenrace = 11
            Case Is = 8
                playereightrace = 11
        End Select
        RaceSelectiontoTeamSelection()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = "Player " & Playerid & " Select your race"
    End Sub
    
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Label2.Text = Introtext.Substring(0, introtextcounter)
        introtextcounter += 1
        Dim random As New Random
        Timer2.Interval = random.Next(100, 122)
        If introtextcounter > Introtext.Length Then
            Timer2.Stop()
            Timer2.Enabled = False
        End If
    End Sub
End Class
