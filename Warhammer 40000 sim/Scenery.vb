'Imports System.ComponentModel
'Imports System.ComponentModel.Design
'Imports System.Windows.Forms
'Imports System.Drawing
'<System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
Public Class Scenery

    Inherits PictureBox

    Dim isLOSBlockingdm As Boolean
    Dim isCoverdm As Boolean
    Dim CoverValuedm As Integer
    Dim isMovementReducingdm As Boolean ''aka difficult terrain
    Dim MovementValuedm As Integer
    Dim zaxisdepthdm As Integer
    Public Sub New()
        MyBase.New()
        Me.Width = 26
        Me.Height = 26

    End Sub
    Property isLOSBlocking As Boolean
        Get
            Return isLOSBlockingdm
        End Get
        Set(value As Boolean)
            isLOSBlockingdm = value
        End Set
    End Property
    Property isCover As Boolean
        Get
            Return isCoverdm
        End Get
        Set(value As Boolean)
            isCoverdm = value
        End Set
    End Property
    Property CoverValue As Integer
        Get
            Return CoverValuedm
        End Get
        Set(value As Integer)
            CoverValuedm = value
        End Set
    End Property
    Property isMovementReducing As Boolean
        Get
            Return isMovementReducingdm
        End Get
        Set(value As Boolean)
            isMovementReducingdm = value
        End Set
    End Property
    Property MovementValue As Integer
        Get
            Return MovementValuedm
        End Get
        Set(value As Integer)
            MovementValuedm = value
        End Set
    End Property
    Property zaxisdepth As Integer
        Get
            Return zaxisdepthdm
        End Get
        Set(value As Integer)
            zaxisdepthdm = value
        End Set
    End Property
End Class
