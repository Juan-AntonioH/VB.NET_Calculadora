Public Class Form1

    'Todo el código actual simplemente son pruebas.

    Dim textBoxResultado As Nullable(Of Double) = Nothing
    'Dim valor1 As Nullable(Of Double) = Nothing
    Dim valor2 As Nullable(Of Double) = Nothing
    Dim operacion As String
    Dim operadorPresionado As Boolean = False
    Private Sub ValorBoton(sender As Object, e As MouseEventArgs) Handles Button9.MouseClick, Button8.MouseClick, Button7.MouseClick, Button6.MouseClick, Button5.MouseClick, Button4.MouseClick, Button3.MouseClick, Button2.MouseClick, Button1.MouseClick, Button0.MouseClick
        ConcatenarOperaciones()
        'TextBox1.Text &= DirectCast(sender, Button).Text
        Valores(DirectCast(sender, Button).Text)

    End Sub
    Private Sub ValorComa(sender As Object, e As MouseEventArgs) Handles ButtonComa.MouseClick
        ConcatenarOperaciones()
        If InStr(TextBox1.Text, ".", CompareMethod.Text) = 0 Then
            TextBox1.Text &= "."
        End If
    End Sub
    Private Sub Operaciones(sender As Object, e As MouseEventArgs) Handles ButtonSumar.MouseClick, ButtonRestar.MouseClick, ButtonMultiplicar.MouseClick, ButtonDividir.MouseClick, Button10.MouseClick, Button11.MouseClick, ButtonElevadoY.Click
        If TextBox1.Text = "0" And DirectCast(sender, Button).Text = "-" Then
            TextBox1.Text = "-"
        Else
            Operaciones()
            operacion = DirectCast(sender, Button).Text
        End If
    End Sub

    Private Sub ButtonResultado_Click(sender As Object, e As EventArgs) Handles ButtonResultado.Click
        Operaciones()
        operacion = ""
    End Sub

    Private Sub ButtonRetroceder_Click(sender As Object, e As EventArgs) Handles ButtonRetroceder.Click
        ' TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - 1)
        If TextBox1.TextLength = 1 Then
            TextBox1.Text = 0
        Else
            TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1)
        End If
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        textBoxResultado = Nothing
        'valor1 = Nothing
        valor2 = Nothing
        operacion = ""
        TextBox1.Text = 0
        operadorPresionado = False
    End Sub

    Private Sub Valores(valor As String)
        If TextBox1.Text = "0" Or TextBox1.Text = "" Then
            TextBox1.Text = valor
        Else
            TextBox1.Text &= valor
        End If
    End Sub
    Private Sub Operaciones()
        valor2 = Val(TextBox1.Text)
        operadorPresionado = True
        If textBoxResultado IsNot Nothing Then
            Select Case operacion
                Case "+"
                    Sumar()
                Case "-"
                    Restar()
                Case "*"
                    Multiplicar()
                Case "/"
                    Dividir()
                Case "%"
                    CalcularPorcentaje()
                Case "\"
                    DividirEntero()
                Case "x^"
                    Elevar()
                Case Else
                    ' En caso de que no sea ninguno de los otros
            End Select
            TextBox1.Text = textBoxResultado
        Else
            textBoxResultado = valor2
        End If
    End Sub
    Private Sub ConcatenarOperaciones()
        If operadorPresionado = True Then
            TextBox1.Text = ""
            operadorPresionado = False
        ElseIf TextBox1.Text = "0" Then
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub Sumar()
        textBoxResultado += valor2
    End Sub

    Private Sub Restar()
        textBoxResultado -= valor2
    End Sub

    Private Sub Multiplicar()
        textBoxResultado *= valor2
    End Sub


    Private Sub Dividir()
        If valor2 = 0 Then
            MessageBox.Show("No puedes dividir un número entre 0")
        Else
            textBoxResultado /= valor2
        End If
    End Sub
    Private Sub CalcularPorcentaje()
        textBoxResultado = textBoxResultado * (valor2 / 100)
    End Sub
    Private Sub DividirEntero()
        If valor2 = 0 Then
            MessageBox.Show("No puedes dividir un número entre 0")
        Else
            textBoxResultado \= valor2
        End If
    End Sub

    Private Sub Elevar()
        textBoxResultado ^= valor2
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 220
        TextBox1.Width = 176
    End Sub

    Private Sub EstándarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstándarToolStripMenuItem.Click
        Me.Width = 220
        TextBox1.Width = 176
        ButtonElevado2.Visible = False
        ButtonElevado3.Visible = False
        ButtonElevadoY.Visible = False
        ButtonFactorial.Visible = False
    End Sub

    Private Sub CientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CientToolStripMenuItem.Click
        Me.Width = 275
        TextBox1.Width = 231
        ButtonElevado2.Visible = True
        ButtonElevado3.Visible = True
        ButtonElevadoY.Visible = True
        ButtonFactorial.Visible = True
    End Sub

    Private Sub ButtonElevado2_Click(sender As Object, e As EventArgs) Handles ButtonElevado2.Click
        TextBox1.Text = Val(TextBox1.Text) ^ 2
    End Sub

    Private Sub ButtonElevado3_Click(sender As Object, e As EventArgs) Handles ButtonElevado3.Click
        TextBox1.Text = Val(TextBox1.Text) ^ 3
    End Sub

    Private Sub ButtonFactorial_Click(sender As Object, e As EventArgs) Handles ButtonFactorial.Click
        Dim factorial As Integer = CalcularFactorial(Val(TextBox1.Text))
        TextBox1.Text = factorial
    End Sub
    Function CalcularFactorial(ByVal numero As Integer) As Integer
        Return If(numero = 0, 1, numero * CalcularFactorial(numero - 1))
    End Function

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        Form2.Show()
    End Sub
End Class
