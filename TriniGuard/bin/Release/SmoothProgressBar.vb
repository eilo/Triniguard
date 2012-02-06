' SmoothProgressBar User Control
' by Stumpy842 - sjstover@columbus.rr.com
' 02/19/2005
' Based in part on Microsoft KB article 323088
' "How To Create a Smooth ProgressBar in Visual Basic .NET"
' http://support.microsoft.com/kb/323088/EN-US/

Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<ToolboxBitmap(GetType(SmoothProgressBar), "SmoothProgressBar.ico"), _
DefaultProperty("Value")> _
Public Class SmoothProgressBar
   Inherits System.Windows.Forms.Control

#Region " Component Designer generated code "

   Public Sub New()
      MyBase.New()

      ' This call is required by the Component Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer _
      Or ControlStyles.UserPaint, True)

   End Sub

   'Control overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Control Designer
   Private components As System.ComponentModel.IContainer

   ' NOTE: The following procedure is required by the Component Designer
   ' It can be modified using the Component Designer.  Do not modify it
   ' using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      '
      'SmoothProgresBar
      '
      Me.Name = "SmoothProgresBar"
      Me.Size = New System.Drawing.Size(150, 20)

   End Sub

#End Region

#Region " Private variables "

   Private min As Integer = 0                ' Minimum value for progress range
   Private max As Integer = 100              ' Maximum value for progress range
   Private val As Integer = 0                ' Current progress value
   Private isHorz As Boolean = True          ' Progresses horizontally / vertically
   Private isRevs As Boolean = False         ' Reverses direction of fill progression
   Private mStep As Integer = 1              ' Increment value for Step() method
   Private mwidth As Decimal                 ' Width of control
   Private mheight As Decimal                ' Height of control
   Private mbarcolor1 As Color = SystemColors.Highlight     ' Color of progress meter
   Private mbarcolor2 As Color = SystemColors.HighlightText ' End color for gradient fill
   Private mbackcolor1 As Color = SystemColors.ControlDark
   Private mbackcolor2 As Color = SystemColors.ControlLight
   Private mbarcolorstyle As ColorStyle = ColorStyle.Solid
   Private mbargradientmode As LinearGradientMode = LinearGradientMode.Horizontal
   Private mbackcolorstyle As ColorStyle = ColorStyle.Solid
   Private mbackgradientmode As LinearGradientMode = LinearGradientMode.Horizontal
   Private mbargradientstretch As StretchMode = StretchMode.Normal
   Private mbarsigmafocus As Single = 0.5F   ' Focus value for  foreground SetSigmaBellShape()
   Private mbarsigmascale As Single = 1.0F   ' Scale value for foreground SetSigmaBellShape()
   Private mbacksigmafocus As Single = 0.5F  ' Focus value for  background SetSigmaBellShape()
   Private mbacksigmascale As Single = 1.0F  ' Scale value for background SetSigmaBellShape()
   Private mbarsigmamode As SigmaMode = SigmaMode.None
   Private mbacksigmamode As SigmaMode = SigmaMode.None
   Private mborderstyle As BorderStyle = BorderStyle.Fixed3D

   Enum Orient
      Horizontal
      Vertical
   End Enum

   Enum Direct
      Normal
      Reverse
   End Enum

   Enum ColorStyle
      Solid
      Gradient
   End Enum

   Enum SigmaMode
      None
      SigmaBell
   End Enum

   Enum StretchMode
      Normal
      Stretch
   End Enum

#End Region

#Region " Methods "

   Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

      Dim percent As Decimal = CDec(val - min) / CDec(max - min)
      Dim rectf As RectangleF = RectangleF.op_Implicit(Me.ClientRectangle)
        Dim brush = Nothing

      ' Draw the background of the ProgressBar control.
      If mbackcolorstyle = ColorStyle.Gradient Then

         brush = New LinearGradientBrush(rectf, _
            mbackcolor1, mbackcolor2, mbackgradientmode)

         If mbacksigmamode = SigmaMode.SigmaBell Then _
            brush.SetSigmaBellShape(mbacksigmafocus, mbacksigmascale)

         e.Graphics.FillRectangle(brush, rectf)

      End If

      ' Calculate area for drawing the progress.
      If isHorz Then
         rectf.Width = rectf.Width * percent
         If isRevs Then rectf.X = mwidth - rectf.Width
      Else
         rectf.Height = rectf.Height * percent
         If Not isRevs Then rectf.Y = mheight - rectf.Height
      End If

      ' Draw the progress meter.
      If rectf.Width > 0 AndAlso rectf.Height > 0 Then

         If mbarcolorstyle = ColorStyle.Solid Then
            brush = New SolidBrush(mbarcolor1)
         Else
            If mbargradientstretch = StretchMode.Normal Then
               brush = New LinearGradientBrush(Me.ClientRectangle, _
                           mbarcolor1, mbarcolor2, mbargradientmode)
            Else
               brush = New LinearGradientBrush(rectf, _
                           mbarcolor1, mbarcolor2, mbargradientmode)
            End If
            If mbarsigmamode = SigmaMode.SigmaBell Then _
               brush.SetSigmaBellShape(mbarsigmafocus, mbarsigmascale)
         End If

         e.Graphics.FillRectangle(brush, rectf)

      End If

      If Not brush Is Nothing Then brush.Dispose()

      ' Draw a border around the ProgressBar control.
      If Me.BorderStyle <> BorderStyle.None Then DrawBorder(e.Graphics)

   End Sub

   Protected Overrides Sub OnResize(ByVal e As EventArgs)
      mwidth = Me.ClientRectangle.Width
      mheight = Me.ClientRectangle.Height
      ' Invalidate the control to get a repaint.
      Me.Invalidate()
   End Sub

   Public Sub PerformStep()
      Me.Value += mStep
   End Sub

   Private Sub DrawBorder(ByVal g As Graphics)
      Dim PenLT, PenRB As Pen
      Dim PenWidth As Integer = CInt(Pens.White.Width)

      If Me.BorderStyle = BorderStyle.Fixed3D Then
         PenLT = New Pen(SystemColors.ControlDark, 1.0F)
         PenRB = New Pen(SystemColors.ControlLightLight, 1.0F)
      Else
         PenLT = Pens.Black : PenRB = Pens.Black
      End If

      With Me.ClientRectangle
         g.DrawLine(PenLT, New Point(.Left, .Top), _
                     New Point(.Width - PenWidth, .Top))
         g.DrawLine(PenLT, New Point(.Left, .Top), _
                     New Point(.Left, .Height - PenWidth))
         g.DrawLine(PenRB, New Point(.Left, .Height - PenWidth), _
                     New Point(.Width - PenWidth, .Height - PenWidth))
         g.DrawLine(PenRB, New Point(.Width - PenWidth, .Top), _
                     New Point(.Width - PenWidth, .Height - PenWidth))
      End With
   End Sub

#End Region

#Region " Public Properties "

#Region " Behavior Properties "
   <Category("Behavior"), _
   DefaultValue(GetType(Orient), "Horizontal"), _
   Description("Orientation of the ProgressBar.")> _
   Public Property Orientation() As Orient
      Get
         If isHorz Then
            Return Orient.Horizontal
         Else
            Return Orient.Vertical
         End If
      End Get
      Set(ByVal Value As Orient)
         If Value <> Orientation Then
            Dim tmp As Integer = Me.Width
            Me.Width = Me.Height
            Me.Height = tmp
            isHorz = (Value = Orient.Horizontal)
         End If
      End Set
   End Property

   <Category("Behavior"), _
   DefaultValue(GetType(Direct), "Normal"), _
   Description("Direction of fill progression.")> _
   Public Property Direction() As Direct
      Get
         If isRevs Then
            Return Direct.Reverse
         Else
            Return Direct.Normal
         End If
      End Get
      Set(ByVal Value As Direct)
         If Value <> Direction Then
            isRevs = (Value = Direct.Reverse)
            Me.Invalidate()
         End If
      End Set
   End Property

   <Category("Behavior"), _
   RefreshProperties(RefreshProperties.All), DefaultValue(0), _
   Description("The lower bound of the range this ProgressBar is working with.")> _
   Public Property Minimum() As Integer
      Get
         Return min
      End Get
      Set(ByVal Value As Integer)
         ' Prevent a negative value.
         If Value < 0 Then Value = 0
         min = Value
         ' Make sure that the minimum value is never set >= the maximum value.
         If min >= max Then max = min + 1
         ' Make sure that the value is still in range.
         If val < min Then val = min
         Me.Invalidate()
      End Set
   End Property

   <Category("Behavior"), _
   RefreshProperties(RefreshProperties.All), DefaultValue(100), _
   Description("The upper bound of the range this ProgressBar is working with.")> _
   Public Property Maximum() As Integer
      Get
         Return max
      End Get
      Set(ByVal Value As Integer)
         ' Make sure that the maximum value is never set <= the minimum value.
         If Value <= min Then
            max = min + 1
         Else
            max = Value
         End If
         ' Make sure that the value is still in range.
         If val > max Then val = max
         Me.Invalidate()
      End Set
   End Property

   <Category("Behavior"), _
   RefreshProperties(RefreshProperties.All), DefaultValue(0), _
   Description("The current value for the ProgressBar, in the range specified by the Minimum and Maximum properties.")> _
   Public Property Value() As Integer
      Get
         Return val
      End Get
      Set(ByVal Value As Integer)
         ' Make sure that the value does not stray outside the valid range.
         If Value < min Then
            val = min
         ElseIf Value > max Then
            val = max
         Else
            val = Value
         End If
         Me.Invalidate()
      End Set
   End Property

   <Category("Behavior"), _
   DefaultValue(1), _
   Description("The amount to increment the current value of the control by when the PerformStep() method is called.")> _
   Public Property [Step]() As Integer
      Get
         Return mStep
      End Get
      Set(ByVal Value As Integer)
         mStep = Value
      End Set
   End Property
#End Region

#Region " Appearance Properties "
   <Category("Appearance"), DefaultValue(GetType(Color), "Highlight"), _
   Description("The foreground color used to display the current progress value of the ProgressBar.")> _
   Public Property BarColor1() As Color
      Get
         Return mbarcolor1
      End Get
      Set(ByVal Value As Color)
         mbarcolor1 = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(Color), "HighlightText"), _
   Description("The foreground end color used to display the current progress value of the ProgressBar in Gradient mode.")> _
   Public Property BarColor2() As Color
      Get
         Return mbarcolor2
      End Get
      Set(ByVal Value As Color)
         mbarcolor2 = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(Color), "ControlDark"), _
   Description("The background color of the ProgressBar.")> _
   Public Property BackColor1() As Color
      Get
         Return mbackcolor1
      End Get
      Set(ByVal Value As Color)
         mbackcolor1 = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(Color), "ControlLight"), _
   Description("The background end color of the ProgressBar in Gradient mode.")> _
   Public Property BackColor2() As Color
      Get
         Return mbackcolor2
      End Get
      Set(ByVal Value As Color)
         mbackcolor2 = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(BorderStyle), "Fixed3D"), _
   Description("Indicates whether or not the ProgressBar should have a border.")> _
   Public Property BorderStyle() As BorderStyle
      Get
         Return mborderstyle
      End Get
      Set(ByVal Value As BorderStyle)
         mborderstyle = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(ColorStyle), "Solid"), _
   Description("The foreground color style of the ProgressBar.")> _
   Public Property BarColorStyle() As ColorStyle
      Get
         Return mbarcolorstyle
      End Get
      Set(ByVal Value As ColorStyle)
         mbarcolorstyle = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(ColorStyle), "Solid"), _
   Description("The background color style of the ProgressBar.")> _
   Public Property BackColorStyle() As ColorStyle
      Get
         Return mbackcolorstyle
      End Get
      Set(ByVal Value As ColorStyle)
         mbackcolorstyle = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(LinearGradientMode), "Horizontal"), _
   Description("The direction of the foreground gradient fill in Gradient mode.")> _
   Public Property BarGradientMode() As LinearGradientMode
      Get
         Return mbargradientmode
      End Get
      Set(ByVal Value As LinearGradientMode)
         mbargradientmode = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(LinearGradientMode), "Horizontal"), _
   Description("The direction of the background gradient fill in Gradient mode.")> _
   Public Property BackGradientMode() As LinearGradientMode
      Get
         Return mbackgradientmode
      End Get
      Set(ByVal Value As LinearGradientMode)
         mbackgradientmode = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(50), _
   Description("A value from 0 through 100 that specifies the center of the foreground gradient in SigmaBell mode.")> _
   Public Property BarSigmaFocus() As Integer
      Get
         Return CInt(mbarsigmafocus * 100.0F)
      End Get
      Set(ByVal Value As Integer)
         If Value < 0 Then : mbarsigmafocus = 0.0F
         ElseIf Value > 100 Then : mbarsigmafocus = 1.0F
         Else : mbarsigmafocus = CSng(Value / 100.0F) : End If
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(100), _
   Description("A value from 0 through 100 that specifies how fast the foreground color falls off from the focus in SigmaBell mode.")> _
   Public Property BarSigmaScale() As Integer
      Get
         Return CInt(mbarsigmascale * 100.0F)
      End Get
      Set(ByVal Value As Integer)
         If Value < 0 Then : mbarsigmascale = 0.0F
         ElseIf Value > 100 Then : mbarsigmascale = 1.0F
         Else : mbarsigmascale = CSng(Value / 100.0F) : End If
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(50), _
   Description("A value from 0 through 100 that specifies the center of the background gradient in SigmaBell mode.")> _
   Public Property BackSigmaFocus() As Integer
      Get
         Return CInt(mbacksigmafocus * 100.0F)
      End Get
      Set(ByVal Value As Integer)
         If Value < 0 Then : mbacksigmafocus = 0.0F
         ElseIf Value > 100 Then : mbacksigmafocus = 1.0F
         Else : mbacksigmafocus = CSng(Value / 100.0F) : End If
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(100), _
   Description("A value from 0 through 100 that specifies how fast the background color falls off from the focus in SigmaBell mode.")> _
   Public Property BackSigmaScale() As Integer
      Get
         Return CInt(mbacksigmascale * 100.0F)
      End Get
      Set(ByVal Value As Integer)
         If Value < 0 Then : mbacksigmascale = 0.0F
         ElseIf Value > 100 Then : mbacksigmascale = 1.0F
         Else : mbacksigmascale = CSng(Value / 100.0F) : End If
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(SigmaMode), "None"), _
   Description("When set to SigmaBell, creates a foreground gradient falloff based on a bell-shaped curve using the BarSigmaFocus and BarSigmaScale values.")> _
   Public Property BarSigmaMode() As SigmaMode
      Get
         Return mbarsigmamode
      End Get
      Set(ByVal Value As SigmaMode)
         mbarsigmamode = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(SigmaMode), "None"), _
   Description("When set to SigmaBell, creates a background gradient falloff based on a bell-shaped curve using the BackSigmaFocus and BackSigmaScale values.")> _
   Public Property BackSigmaMode() As SigmaMode
      Get
         Return mbacksigmamode
      End Get
      Set(ByVal Value As SigmaMode)
         mbacksigmamode = Value
         Me.Invalidate()
      End Set
   End Property

   <Category("Appearance"), DefaultValue(GetType(StretchMode), "Normal"), _
   Description("Determines if the bar gradient stretches as the bar progresses.")> _
   Public Property BarGradientStretch() As StretchMode
      Get
         Return mbargradientstretch
      End Get
      Set(ByVal Value As StretchMode)
         mbargradientstretch = Value
         Me.Invalidate()
      End Set
   End Property
#End Region

#Region " Shadows Properties "
   <Browsable(False)> _
   Shadows ReadOnly Property ForeColor() As Color
      Get
         Return MyBase.ForeColor
      End Get
   End Property

   <Browsable(False)> _
   Shadows ReadOnly Property Font() As Font
      Get
         Return MyBase.Font
      End Get
   End Property

   <Browsable(False)> _
   Shadows ReadOnly Property Text() As String
      Get
         Return MyBase.Text
      End Get
   End Property

   <Browsable(False)> _
   Shadows ReadOnly Property BackColor() As Color
      Get
         Return MyBase.BackColor
      End Get
   End Property
#End Region

#End Region

End Class
