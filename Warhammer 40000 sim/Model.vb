'Imports System.ComponentModel
'Imports System.ComponentModel.Design
'Imports System.Windows.Forms
'Imports System.Drawing
'<Serializable()>
Public Class Model
    Inherits PictureBox
    'Implements System.ComponentModel.IExtenderProvider
    Dim off As Point
    Dim radius As Integer = 2
    Dim nameofmodeldm As String
    Dim abletomove As Boolean = False
    Dim abletoshoot As Boolean = False
    Dim ispsyker As Boolean = False
    Dim ballisticskilldm As Integer ' = 3
    Dim weaponskilldm As Integer ' = 1
    Dim strengthdm As Integer ' = 1
    Dim toughnessdm As Integer ' = 1
    Dim currentwoundsdm As Integer ' = 1
    Dim mortalwoundsdm As Integer ' = 1
    Dim maxwoundsdm As Integer ' = 1
    Dim attacksdm As Integer ' = 1
    Dim leadershipdm As Integer ' = 3
    Dim savedm As Integer ' = 3
    Dim invulnerablesavedm As Integer ' = 0
    Dim identifierdm As Integer ' = 0
    'Dim groupidentifierdm As Integer
    'Dim playeridentifierdm As Integer

    Dim weaponsdm As String()
    Dim listofallweaponsdm As String
    Dim hasmoveddm As Boolean = False
    Dim hasadvanceddm As Boolean = False
    Dim istargetdm As Boolean = False
    Dim isshootingdm As Boolean = False
    Dim isselectedtobeshootingdm As Boolean = False
    Dim isselectedtobetargetdm As Boolean = False
    Dim abilitiesdm As String()
    Dim psykerpowersdm As String()
    Dim factiontagsdm As String()
    Dim numberofpsykerpowersdm As Integer
    Dim numberofdenythewitchdm As Integer
    Dim explodeddm As Boolean = False
    Dim Teamiddm As Integer
    Public Sub New()
        MyBase.New()
        Me.Width = 20
        Me.Height = 20

    End Sub
    'Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
    '    If TypeOf target Is Control Then
    '        Return True
    '    End If
    '    Return False
    'End Function
    Property NameofModel As String
        Get
            Return nameofmodeldm
        End Get
        Set(value As String)
            nameofmodeldm = value
        End Set
    End Property
    Property MoveDistance As Integer
        Get
            Return radius
        End Get
        Set(value As Integer)
            radius = value
        End Set
    End Property
    Property Identifier As Integer
        Get
            Return identifierdm
        End Get
        Set(value As Integer)
            identifierdm = value
        End Set
    End Property
    Property CanMove As Boolean
        Get
            Return abletomove
        End Get
        Set(value As Boolean)
            abletomove = value
        End Set
    End Property
    Property Canshoot As Boolean
        Get
            Return abletoshoot
        End Get
        Set(value As Boolean)
            abletoshoot = value
        End Set
    End Property
    Property WeaponSkill As Integer
        Get
            Return weaponskilldm
        End Get
        Set(value As Integer)
            weaponskilldm = value
        End Set
    End Property
    Property BallisticSkill As Integer
        Get
            Return ballisticskilldm
        End Get
        Set(value As Integer)
            ballisticskilldm = value
        End Set
    End Property
    Property Strength As Integer
        Get
            Return strengthdm
        End Get
        Set(value As Integer)
            strengthdm = value
        End Set
    End Property
    Property Toughness As Integer
        Get
            Return toughnessdm
        End Get
        Set(value As Integer)
            toughnessdm = value
        End Set
    End Property
    Property CurrentWounds As Integer
        Get
            Return currentwoundsdm
        End Get
        Set(value As Integer)
            currentwoundsdm = value
        End Set
    End Property
    Property MaxWounds As Integer
        Get
            Return maxwoundsdm
        End Get
        Set(value As Integer)
            maxwoundsdm = value
        End Set
    End Property
    Property MortalWounds As Integer
        Get
            Return mortalwoundsdm
        End Get
        Set(value As Integer)
            mortalwoundsdm = value
        End Set
    End Property
    Property Attacks As Integer
        Get
            Return attacksdm
        End Get
        Set(value As Integer)
            attacksdm = value
        End Set
    End Property
    Property Leadership As Integer
        Get
            Return leadershipdm
        End Get
        Set(value As Integer)
            leadershipdm = value
        End Set
    End Property
    Property Save As Integer
        Get
            Return savedm
        End Get
        Set(value As Integer)
            savedm = value
        End Set
    End Property
    Property invulnerablesave As Integer
        Get
            Return invulnerablesavedm
        End Get
        Set(value As Integer)
            invulnerablesavedm = value
        End Set
    End Property
    Property Psyker As Boolean
        Get
            Return ispsyker
        End Get
        Set(value As Boolean)
            ispsyker = value
        End Set
    End Property
    Property Weapons As String()
        Get
            Return weaponsdm
        End Get
        Set(value() As String)
            weaponsdm = value
        End Set
    End Property
    Property hasadvanced As Boolean
        Get
            Return hasadvanceddm
        End Get
        Set(value As Boolean)
            hasadvanceddm = value
        End Set
    End Property
    Property hasmoved As Boolean
        Get
            Return hasmoveddm
        End Get
        Set(value As Boolean)
            hasmoveddm = value
        End Set
    End Property
    Property isshooting As Boolean
        Get
            Return isshootingdm
        End Get
        Set(value As Boolean)
            isshootingdm = value
        End Set
    End Property
    Property istarget As Boolean
        Get
            Return istargetdm
        End Get
        Set(value As Boolean)
            istargetdm = value
        End Set
    End Property
    Property isselectedtobeshooting As Boolean
        Get
            Return isselectedtobeshootingdm
        End Get
        Set(value As Boolean)
            isselectedtobeshootingdm = value
        End Set
    End Property
    Property isselectedtobetarget As Boolean
        Get
            Return isselectedtobetargetdm
        End Get
        Set(value As Boolean)
            isselectedtobetargetdm = value
        End Set
    End Property
    Property abilities As String()
        Get
            Return abilitiesdm
        End Get
        Set(value() As String)
            abilitiesdm = value
        End Set
    End Property
    Property psykerpowers As String()
        Get
            Return psykerpowersdm
        End Get
        Set(value() As String)
            psykerpowersdm = value
        End Set

    End Property
    Property factiontags As String()
        Get
            Return factiontagsdm
        End Get
        Set(value() As String)
            factiontagsdm = value
        End Set

    End Property
    Property numberofpsykerpowers As Integer
        Get
            Return numberofpsykerpowersdm
        End Get
        Set(value As Integer)
            numberofpsykerpowersdm = value
        End Set

    End Property
    Property numberofdenythewitch As Integer
        Get
            Return numberofdenythewitchdm
        End Get
        Set(value As Integer)
            numberofdenythewitchdm = value
        End Set
    End Property
    Property exploded As Boolean
        Get
            Return explodeddm
        End Get
        Set(value As Boolean)
            explodeddm = value
        End Set
    End Property
    Property TeamId As Integer
        Get
            Return Teamiddm
        End Get
        Set(value As Integer)
            Teamiddm = value
        End Set
    End Property
    Private Sub Unit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left And abletomove Then
            sender.Left = MousePosition.X - off.X
            sender.Top = MousePosition.Y - off.Y
        End If
    End Sub
    Private Sub Unit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        off.X = MousePosition.X - sender.Left
        off.Y = MousePosition.Y - sender.Top
    End Sub


End Class
