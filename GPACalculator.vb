Public Class Form1
    'Matthew Meade
    'Lab 6
    '08/11/2016
    Private Sub submitButton_Click(sender As Object, e As EventArgs) Handles submitButton.Click
        ' Variables
        Dim totalGrade, totalValue, grade, value As Double

        'Input box arguments: prompt, title, defaultValue
        'Loop until user enters XX9999 into prompt without storing the input
        Do Until InputBox("Enter Course Number or XX9999 to exit", "Course Number").ToUpper() = "XX9999"

            'Prompt for number grade and convert it to GPA
            grade = InputBox("Enter Percent Grade in course", "Enter Grade", "0")
            grade = ConvertToGPA(grade)

            'Prompt for course Value
            value = InputBox("Enter course credit value", "Enter Value", "0")

            'Add current values to totals
            totalGrade += value * grade
            totalValue += value
        Loop

        'If the user entered non zero marks and values output GPA
        If totalGrade > 0 And totalValue > 0 Then
            outputTextbox.Text = "Your GPA is: " & Format(totalGrade / totalValue, "0.00")
        Else
            'Otherwise output 0
            outputTextbox.Text = "Your GPA is: 0"
        End If

    End Sub


    'ConvertToGPA
    'Return whole number GPA 0-4 based on range of input m
    Private Function ConvertToGPA(m As Double) As Double
        Select Case m
            Case Is >= 80
                Return 4
            Case Is >= 70
                Return 3
            Case Is >= 60
                Return 2
            Case Is >= 50
                Return 1
            Case Else
                Return 0
        End Select

    End Function
End Class