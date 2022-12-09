Partial Public Class SnippingTool
    Inherits Form

    Public Shared Function Snip() As Image
        Dim rc As Rectangle = Screen.PrimaryScreen.Bounds

        Using bmp As Bitmap = New Bitmap(rc.Width, rc.Height, Imaging.PixelFormat.Format32bppPArgb)
            Using gr As Graphics = Graphics.FromImage(bmp)
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size)
            End Using

            Using snipper = New SnippingTool(bmp)
                If snipper.ShowDialog() = DialogResult.OK Then Return snipper.Image
            End Using

            Return Nothing
        End Using
    End Function

    Public Sub New(screenShot As Image)
        BackgroundImage = screenShot
        ShowInTaskbar = False
        FormBorderStyle = FormBorderStyle.None
        WindowState = FormWindowState.Maximized
        DoubleBuffered = True
    End Sub

    Public Property Image As Image
    Private rcSelect As Rectangle = New Rectangle()
    Private pntStart As Point

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Return
        pntStart = e.Location
        rcSelect = New Rectangle(e.Location, New Size(0, 0))
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Return
        Dim x1 As Integer = Math.Min(e.X, pntStart.X)
        Dim y1 As Integer = Math.Min(e.Y, pntStart.Y)
        Dim x2 As Integer = Math.Max(e.X, pntStart.X)
        Dim y2 As Integer = Math.Max(e.Y, pntStart.Y)
        rcSelect = New Rectangle(x1, y1, x2 - x1, y2 - y1)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If rcSelect.Width <= 0 OrElse rcSelect.Height <= 0 Then Return
        Image = New Bitmap(rcSelect.Width, rcSelect.Height)
        Using gr As Graphics = Graphics.FromImage(Image)
            gr.DrawImage(BackgroundImage, New Rectangle(0, 0, Image.Width, Image.Height), rcSelect, GraphicsUnit.Pixel)
        End Using

        DialogResult = DialogResult.OK
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using br As Brush = New SolidBrush(Color.FromArgb(120, Color.White))
            Dim x1 As Integer = rcSelect.X
            Dim x2 As Integer = rcSelect.X + rcSelect.Width
            Dim y1 As Integer = rcSelect.Y
            Dim y2 As Integer = rcSelect.Y + rcSelect.Height
            e.Graphics.FillRectangle(br, New Rectangle(0, 0, x1, Height))
            e.Graphics.FillRectangle(br, New Rectangle(x2, 0, Width - x2, Height))
            e.Graphics.FillRectangle(br, New Rectangle(x1, 0, x2 - x1, y1))
            e.Graphics.FillRectangle(br, New Rectangle(x1, y2, x2 - x1, Height - y2))
        End Using

        Using pen As Pen = New Pen(Color.Red, 3)
            e.Graphics.DrawRectangle(pen, rcSelect)
        End Using
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then DialogResult = DialogResult.Cancel
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class