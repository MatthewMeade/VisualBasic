Public Class Form1
    'Matthew Meade
    'Lab 8 Program 2
    '17/11/2016
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        'Variables
        Dim total, highest, revenue As Double
        Dim sold, highestIndex As Integer
        Dim output As String

        'Arrays
        Dim description() As String = {
            "Easy Button",
            "Money Tree",
            "Booster Juice",
            "More Memory",
            "Worry Dolls"
        }
        Dim remaining() As Integer = {10, 30, 9, 42, 17}
        Dim price() As Double = {3, 12.25, 8.45, 7.5, 4}

        'Initialize highest revenue
        highest = 0

        'Loop through all bins
        For i = 0 To description.GetUpperBound(0)
            'Start output string with bin number
            output = i + 1 & vbTab

            'Calculate amount sold and revenue
            sold = 50 - remaining(i)
            revenue = sold * price(i)

            'Append sold and revenue to string
            output += vbTab & sold & vbTab
            output += vbTab & revenue

            'Output string
            outputListBox.Items.Add(output)

            'add revenue to total
            total += revenue

            'If current revenue is greater than the previous 
            If (revenue > highest) Then
                'Set current revenue to highest and remember index
                highest = revenue
                highestIndex = i
            End If

        Next

        'Output total revenue and highest revenue item
        totalTextBox.Text = total
        highestTextBox.Text = description(highestIndex)

    End Sub
End Class