Imports System.IO

Public Class Form1

    'Matthew Meade
    'Lab 10 Program 1
    '07/12/2016

    'Class level array
    Dim weights() As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim file As StreamReader
        Dim i = 0 'Count of marketable eggs
        Dim record As Double

        'Open file
        file = New StreamReader("eggs.txt")

        'Loop through the file until end of stream
        Do Until file.EndOfStream
            If file.ReadLine() >= 1.5 Then
                'If egg weighs enough count it
                i += 1
            End If
        Loop

        'Close the file
        file.Close()

        'Size the array
        ReDim weights(i - 1)

        'Re open file
        file = New StreamReader("eggs.txt")

        i = 0 'Loop through file until end of steam
        Do Until file.EndOfStream
            'Read in a line of data
            record = file.ReadLine()
            If record >= 1.5 Then
                'If egg weighs enough add it to the array
                weights(i) = record
                i += 1
            End If
        Loop

        'Close the file
        file.Close()

        'Sort the array
        Array.Sort(weights)
    End Sub

    Private Sub gradesButton_Click(sender As Object, e As EventArgs) Handles gradesButton.Click

        'Clear output
        outputListbox.Items.Clear()

        'Arrays for egg grades 
        Dim grades() = {1.75, 2, 2.25, 2.5, Double.MaxValue} 'Max weight of egg grades
        Dim names() = {"Small", "Medium", "Large", "Extra Large", "Jumbo"}

        Dim n = 0 'Number of eggs in grade
        Dim g = 0 'Current grade

        For i = 0 To weights.GetUpperBound(0)

            'If current eggs is heavier than max for current grade
            If weights(i) >= grades(g) Then
                'Output counted eggs for current grade
                outputListbox.Items.Add(names(g) & " eggs: " & n)

                'Move to next grade
                g += 1
                'Reset egg counter
                n = 0
            End If

            'Count egg
            n += 1

        Next

        'Output last grade
        outputListbox.Items.Add(names(g) & " eggs: " & n)


    End Sub

    Private Sub weightButton_Click(sender As Object, e As EventArgs) Handles weightButton.Click

        'Clear output
        outputListbox.Items.Clear()

        'Output lower and upper bound elements in array
        outputListbox.Items.Add("Lightest: " & weights(0))
        outputListbox.Items.Add("Heaviest: " & weights(weights.GetUpperBound(0)))
    End Sub
End Class
