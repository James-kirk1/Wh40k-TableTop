Public Class Team_Setup

    Public playeroneteam As Integer = 1
    Public playertwoteam As Integer = 2
    Public playerthreeteam As Integer = 0
    Public playerfourteam As Integer = 0
    Public playerfiveteam As Integer = 0
    Public playersixteam As Integer = 0
    Public playerseventeam As Integer = 0
    Public playereightteam As Integer = 0
    Public playeronearmy As String = "1:Captain in Terminator Armour@Thunder hammer$Super Duper Mega Weapon~1:Captain in Terminator Armour@Thunder hammer$Super Duper Mega Weapon~2:Librarian in Terminator Armour@Plasma cannon~3:Scout Sergeant~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~3:Scout~4:Veteran Sergeant~4:Space Marine Veteran~4:Space Marine Veteran@Plasma cannon~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran~4:Space Marine Veteran@~4:Space Marine Veteran~4:Space Marine Veteran~5:Apothecary~6:Space Marine Sergeant@Combi-flamer~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@Heavy bolter~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~6:Space Marine@~7:Space Marine Sergeant@Combi-flamer$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@Missile launcher$~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~7:Space Marine@~8:Whirlwind@Hunter-killer missile$Storm bolter~9:Stormtalon Gunship@two Lascannons$Hunter-killer missile$Storm bolter"
    Public playertwoarmy As String
    Public playerthreearmy As String
    Public playerfourarmy As String
    Public playerfivearmy As String
    Public playersixarmy As String
    Public playersevenarmy As String
    Public playereightarmy As String
    Private Sub Team_Setup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        If Race_Selection_Form.maxplayers < 8 Then
            Player8race.Text = "Closed"
            NumericUpDown8.Enabled = False
            If Race_Selection_Form.maxplayers < 7 Then
                Player7race.Text = "Closed"
                NumericUpDown7.Enabled = False
                If Race_Selection_Form.maxplayers < 6 Then
                    Player6race.Text = "Closed"
                    NumericUpDown6.Enabled = False
                    If Race_Selection_Form.maxplayers < 5 Then
                        Player5race.Text = "Closed"
                        NumericUpDown5.Enabled = False
                        If Race_Selection_Form.maxplayers < 4 Then
                            Player4race.Text = "Closed"
                            NumericUpDown4.Enabled = False
                            If Race_Selection_Form.maxplayers < 3 Then
                                Player3race.Text = "Closed"
                                NumericUpDown3.Enabled = False
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Select Case Race_Selection_Form.playeronerace
            Case Is = 1
                Player1race.Text = "Orks"
            Case Is = 2
                Player1race.Text = "Eldar"
            Case Is = 4
                Player1race.Text = "Imperial Guard"
            Case Is = 5
                Player1race.Text = "Tau"
            Case Is = 6
                Player1race.Text = "Necrons"
            Case Is = 7
                Player1race.Text = "Dark Eldar"
            Case Is = 8
                Player1race.Text = "Sisters of Battle"
            Case Is = 9
                Player1race.Text = "Tyranids"
            Case Is = 10
                Player1race.Text = "Chaos Daemons"
            Case Is = 11
                Player1race.Text = "The Inquistion"
            Case Is = 12
                Player1race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playertworace
            Case Is = 1
                Player2race.Text = "Orks"
            Case Is = 2
                Player2race.Text = "Eldar"
            Case Is = 4
                Player2race.Text = "Imperial Guard"
            Case Is = 5
                Player2race.Text = "Tau"
            Case Is = 6
                Player2race.Text = "Necrons"
            Case Is = 7
                Player2race.Text = "Dark Eldar"
            Case Is = 8
                Player2race.Text = "Sisters of Battle"
            Case Is = 9
                Player2race.Text = "Tyranids"
            Case Is = 10
                Player2race.Text = "Chaos Daemons"
            Case Is = 11
                Player2race.Text = "The Inquistion"
            Case Is = 12
                Player2race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playerthreerace
            Case Is = 1
                Player3race.Text = "Orks"
            Case Is = 2
                Player3race.Text = "Eldar"
            Case Is = 4
                Player3race.Text = "Imperial Guard"
            Case Is = 5
                Player3race.Text = "Tau"
            Case Is = 6
                Player3race.Text = "Necrons"
            Case Is = 7
                Player3race.Text = "Dark Eldar"
            Case Is = 8
                Player3race.Text = "Sisters of Battle"
            Case Is = 9
                Player3race.Text = "Tyranids"
            Case Is = 10
                Player3race.Text = "Chaos Daemons"
            Case Is = 11
                Player3race.Text = "The Inquistion"
            Case Is = 12
                Player3race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playerfourrace
            Case Is = 1
                Player4race.Text = "Orks"
            Case Is = 2
                Player4race.Text = "Eldar"
            Case Is = 4
                Player4race.Text = "Imperial Guard"
            Case Is = 5
                Player4race.Text = "Tau"
            Case Is = 6
                Player4race.Text = "Necrons"
            Case Is = 7
                Player4race.Text = "Dark Eldar"
            Case Is = 8
                Player4race.Text = "Sisters of Battle"
            Case Is = 9
                Player4race.Text = "Tyranids"
            Case Is = 10
                Player4race.Text = "Chaos Daemons"
            Case Is = 11
                Player4race.Text = "The Inquistion"
            Case Is = 12
                Player4race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playerfiverace
            Case Is = 1
                Player5race.Text = "Orks"
            Case Is = 2
                Player5race.Text = "Eldar"
            Case Is = 4
                Player5race.Text = "Imperial Guard"
            Case Is = 5
                Player5race.Text = "Tau"
            Case Is = 6
                Player5race.Text = "Necrons"
            Case Is = 7
                Player5race.Text = "Dark Eldar"
            Case Is = 8
                Player5race.Text = "Sisters of Battle"
            Case Is = 9
                Player5race.Text = "Tyranids"
            Case Is = 10
                Player5race.Text = "Chaos Daemons"
            Case Is = 11
                Player5race.Text = "The Inquistion"
            Case Is = 12
                Player5race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playersixrace
            Case Is = 1
                Player6race.Text = "Orks"
            Case Is = 2
                Player6race.Text = "Eldar"
            Case Is = 4
                Player6race.Text = "Imperial Guard"
            Case Is = 5
                Player6race.Text = "Tau"
            Case Is = 6
                Player6race.Text = "Necrons"
            Case Is = 7
                Player6race.Text = "Dark Eldar"
            Case Is = 8
                Player6race.Text = "Sisters of Battle"
            Case Is = 9
                Player6race.Text = "Tyranids"
            Case Is = 10
                Player6race.Text = "Chaos Daemons"
            Case Is = 11
                Player6race.Text = "The Inquistion"
            Case Is = 12
                Player6race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playersevenrace
            Case Is = 1
                Player7race.Text = "Orks"
            Case Is = 2
                Player7race.Text = "Eldar"
            Case Is = 4
                Player7race.Text = "Imperial Guard"
            Case Is = 5
                Player7race.Text = "Tau"
            Case Is = 6
                Player7race.Text = "Necrons"
            Case Is = 7
                Player7race.Text = "Dark Eldar"
            Case Is = 8
                Player7race.Text = "Sisters of Battle"
            Case Is = 9
                Player7race.Text = "Tyranids"
            Case Is = 10
                Player7race.Text = "Chaos Daemons"
            Case Is = 11
                Player7race.Text = "The Inquistion"
            Case Is = 12
                Player7race.Text = "Space Marines"
        End Select
        Select Case Race_Selection_Form.playereightrace
            Case Is = 1
                Player8race.Text = "Orks"
            Case Is = 2
                Player8race.Text = "Eldar"
            Case Is = 4
                Player8race.Text = "Imperial Guard"
            Case Is = 5
                Player8race.Text = "Tau"
            Case Is = 6
                Player8race.Text = "Necrons"
            Case Is = 7
                Player8race.Text = "Dark Eldar"
            Case Is = 8
                Player8race.Text = "Sisters of Battle"
            Case Is = 9
                Player8race.Text = "Tyranids"
            Case Is = 10
                Player8race.Text = "Chaos Daemons"
            Case Is = 11
                Player8race.Text = "The Inquistion"
            Case Is = 12
                Player8race.Text = "Space Marines"
        End Select
    End Sub

    

    Private Sub Btn_continue_Click(sender As System.Object, e As System.EventArgs) Handles btn_continue.Click
        Select Case Race_Selection_Form.maxplayers
            Case Is = 2
                If NumericUpDown1.Value = NumericUpDown2.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    TeamSelectiontoArmySelection()

                End If
            Case Is = 3
                If NumericUpDown1.Value = NumericUpDown2.Value = NumericUpDown3.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    playerthreeteam = NumericUpDown3.Value
                    TeamSelectiontoArmySelection()
                End If
            Case Is = 4
                If NumericUpDown1.Value = NumericUpDown2.Value = NumericUpDown3.Value = NumericUpDown4.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    playerthreeteam = NumericUpDown3.Value
                    playerfourteam = NumericUpDown4.Value
                    TeamSelectiontoArmySelection()
                End If
            Case Is = 5
                If NumericUpDown1.Value = NumericUpDown2.Value = NumericUpDown3.Value = NumericUpDown4.Value = NumericUpDown5.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    playerthreeteam = NumericUpDown3.Value
                    playerfourteam = NumericUpDown4.Value
                    playerfiveteam = NumericUpDown5.Value
                    TeamSelectiontoArmySelection()
                End If
            Case Is = 6
                If NumericUpDown1.Value = NumericUpDown2.Value = NumericUpDown3.Value = NumericUpDown4.Value = NumericUpDown5.Value = NumericUpDown6.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    playerthreeteam = NumericUpDown3.Value
                    playerfourteam = NumericUpDown4.Value
                    playerfiveteam = NumericUpDown5.Value
                    playersixteam = NumericUpDown6.Value
                    TeamSelectiontoArmySelection()
                End If
            Case Is = 7
                If NumericUpDown1.Value = NumericUpDown2.Value = NumericUpDown3.Value = NumericUpDown4.Value = NumericUpDown5.Value = NumericUpDown6.Value = NumericUpDown7.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    playerthreeteam = NumericUpDown3.Value
                    playerfourteam = NumericUpDown4.Value
                    playerfiveteam = NumericUpDown5.Value
                    playersixteam = NumericUpDown6.Value
                    playerseventeam = NumericUpDown7.Value
                    TeamSelectiontoArmySelection()
                End If
            Case Is = 8
                If NumericUpDown1.Value = NumericUpDown2.Value = NumericUpDown3.Value = NumericUpDown4.Value = NumericUpDown5.Value = NumericUpDown6.Value = NumericUpDown7.Value = NumericUpDown8.Value Then
                    MsgBox("Team Setup Invalid, you need at least two teams", MsgBoxStyle.OkOnly)
                Else
                    playeroneteam = NumericUpDown1.Value
                    playertwoteam = NumericUpDown2.Value
                    playerthreeteam = NumericUpDown3.Value
                    playerfourteam = NumericUpDown4.Value
                    playerfiveteam = NumericUpDown5.Value
                    playersixteam = NumericUpDown6.Value
                    playerseventeam = NumericUpDown7.Value
                    playereightteam = NumericUpDown8.Value
                    TeamSelectiontoArmySelection()
                End If
        End Select
        
        'Race_Selection_Form.Playerid = 1


    End Sub
#Region "teamids"
    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown1.Value = Race_Selection_Form.maxplayers
        End If
    End Sub
    Private Sub NumericUpDown2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown2.Value = Race_Selection_Form.maxplayers
        End If
    End Sub
    Private Sub NumericUpDown3_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown3.ValueChanged
        If NumericUpDown3.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown3.Value = Race_Selection_Form.maxplayers
        End If
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown4.ValueChanged
        If NumericUpDown4.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown4.Value = Race_Selection_Form.maxplayers
        End If
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown5.ValueChanged
        If NumericUpDown5.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown5.Value = Race_Selection_Form.maxplayers
        End If
    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown6.ValueChanged
        If NumericUpDown6.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown6.Value = Race_Selection_Form.maxplayers
        End If
    End Sub

    Private Sub NumericUpDown7_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown7.ValueChanged
        If NumericUpDown7.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown7.Value = Race_Selection_Form.maxplayers
        End If
    End Sub
    Private Sub NumericUpDown8_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown8.ValueChanged
        If NumericUpDown8.Value > Race_Selection_Form.maxplayers Then
            NumericUpDown8.Value = Race_Selection_Form.maxplayers
        End If
    End Sub
#End Region
End Class

