Public Class Form1
    Dim graphic As Graphics
    Dim hog_x As Integer = 85
    Dim hog_y As Integer = 335
    Dim hog_h As Integer = 280

    Dim hog_body_x1 As Integer = 10
    Dim hog_body_x2 As Integer = 100
    Dim hog_face_x1 As Integer = 70
    Dim hog_face_x2 As Integer = 100
    Dim hog_eye As Integer = 90
    Dim hog_nose As Integer = 113

    Dim hog_points1() As Point
    Dim hog_points2() As Point
    Dim hog_points3() As Point
    Dim hog_points4() As Point
    Dim hog_points5() As Point
    Dim hog_spike As Integer

    Dim hog_speed As Integer = 2

    Dim sun_x As Integer = 750
    Dim sun_y As Integer = 30
    Dim sun_size As Integer = 50
    Dim sun_flag As Boolean = True

    Dim button_flag As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i, x, y As Integer
        graphic = Me.CreateGraphics
        drawBackground()
        drawSun()
        drawForest()
        drawSpikes()
        drawHog()
    End Sub

    Private Sub drawBackground()
        graphic.FillRectangle(Brushes.Aqua, 0, 0, Me.ClientSize.Width, Me.ClientSize.Height)
        graphic.FillRectangle(Brushes.Green, 0, Me.ClientSize.Height \ 2, Me.ClientSize.Width, Me.ClientSize.Height \ 2)
    End Sub

    Private Sub drawSun()
        Dim pen As New Pen(Color.White)
        Dim brush As New SolidBrush(Color.Yellow)
        graphic.DrawEllipse(pen, sun_x, sun_y, sun_size, sun_size)
        graphic.FillEllipse(brush, sun_x, sun_y, sun_size, sun_size)
    End Sub

    Private Sub drawForest()
        Dim i, x, y As Integer
        Dim stvol() As Point
        x = 10 : y = Me.ClientSize.Height \ 2 - 20

        Dim p As New Pen(Color.Brown)
        Dim k As New SolidBrush(Color.Red)
        Dim e As New SolidBrush(Color.GreenYellow)
        k.Color = Color.Brown

        For i = 1 To 10
            stvol = {New Point(x, 250), New Point(x + 10, 100), New Point(x + 20, 250)}
            graphic.FillEllipse(e, x - 25, 90, 70, 120)
            graphic.FillPolygon(k, stvol)
            graphic.DrawPolygon(p, stvol)
            x = x + 90
        Next
    End Sub

    Private Sub drawHog()
        Dim i As Integer
        Dim p As New Pen(Color.Black)
        Dim k As New SolidBrush(Color.Gray)
        Dim e As New SolidBrush(Color.White)
        Dim h As New SolidBrush(Color.Black)

        graphic.FillPie(k, hog_body_x1, 300, hog_body_x2, 70, 0, -180)
        k.Color = Color.Gray
        graphic.FillPie(e, hog_face_x1, 300, hog_face_x2, 70, 180, 55)
        e.Color = Color.Gray
        graphic.FillEllipse(h, hog_eye, 315, 8, 8)
        h.Color = Color.Black
        graphic.FillPie(h, hog_nose, 300, 20, 70, 180, 45)
    End Sub

    Private Sub drawSpikes()
        Dim i As Integer
        Dim p As New Pen(Color.Black)
        Dim h As New SolidBrush(Color.Black)

        hog_points1 = {(New Point(hog_x, hog_h)), (New Point(hog_x + 15, hog_y)), (New Point(hog_x - 15, hog_y))}
        hog_spike = hog_x - 15
        hog_h = hog_h + 2
        hog_points2 = {(New Point(hog_spike, hog_h)), (New Point(hog_spike + 15, hog_y)), (New Point(hog_spike - 15, hog_y))}
        hog_spike = hog_spike - 15
        hog_h = hog_h + 2
        hog_points3 = {(New Point(hog_spike, hog_h)), (New Point(hog_spike + 15, hog_y)), (New Point(hog_spike - 15, hog_y))}
        hog_spike = hog_spike - 15
        hog_h = hog_h + 2
        hog_points4 = {(New Point(hog_spike, hog_h)), (New Point(hog_spike + 15, hog_y)), (New Point(hog_spike - 15, hog_y))}
        hog_spike = hog_spike - 15
        hog_h = hog_h + 2
        hog_points5 = {(New Point(hog_spike, hog_h)), (New Point(hog_spike + 15, hog_y)), (New Point(hog_spike - 15, hog_y))}

        graphic.FillPolygon(h, hog_points1)
        graphic.DrawPolygon(p, hog_points1)
        graphic.FillPolygon(h, hog_points2)
        graphic.DrawPolygon(p, hog_points2)
        graphic.FillPolygon(h, hog_points3)
        graphic.DrawPolygon(p, hog_points3)
        graphic.FillPolygon(h, hog_points4)
        graphic.DrawPolygon(p, hog_points4)
        graphic.FillPolygon(h, hog_points5)
        graphic.DrawPolygon(p, hog_points5)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        drawBackground()

        If (sun_flag = True) Then
            sun_x = sun_x - 1
            sun_y = sun_y - 1
            sun_size = sun_size + hog_speed
        Else
            sun_x = sun_x + 1
            sun_y = sun_y + 1
            sun_size = sun_size - hog_speed
        End If

        If (sun_y = 10) Then
            sun_flag = False
        ElseIf (sun_y = 40) Then
            sun_flag = True
        End If

        drawSun()

        drawForest()

        hog_h = 280
        hog_x = hog_x + hog_speed
        drawSpikes()

        hog_body_x1 = hog_body_x1 + hog_speed
        hog_face_x1 = hog_face_x1 + hog_speed
        hog_eye = hog_eye + hog_speed
        hog_nose = hog_nose + hog_speed
        drawHog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If button_flag = False Then
            Timer1.Start()
            Button2.Text = "Stop"
            button_flag = True
        Else
            button_flag = True
            Timer1.Stop()
            Button2.Text = "Animate"
            button_flag = False
        End If
    End Sub
End Class
