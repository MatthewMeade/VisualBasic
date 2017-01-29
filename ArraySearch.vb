Public Class Form1
    'Matthew Meade
    'Lab 9 Program 1
    '01/12/2016
    Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click
        'Variables
        Dim input As String
        Dim lower, upper, i As Integer

        'Herbs array
        Dim herbs() = {
            "sage", "chives",
            "thyme", "spearmint",
            "rosemary", "basil",
            "savory", "cilantro",
            "parsley", "oregano",
            "juniper", "mint",
            "scallions", "tarragon",
            "lemongrass", "peppermint",
            "catnip", "clove",
            "dill", "lavender"
        }

        Array.Sort(herbs)

        'Get input from text box in lower case
        input = inputTextBox.Text.ToLower

        'Index 
        i = 0

        'Start of search area
        lower = 0
        'End of search area
        upper = herbs.GetUpperBound(0)

        'Binary search algorithm
        'Each time through the loop cut the array in half
        Do While upper >= lower And herbs(i) <> input

            'Look in the center of the array
            i = (lower + upper) / 2

            'If the desired value is greater than the current value
            If herbs(i) < input Then
                'Search the right half of the array
                lower = i + 1
            ElseIf herbs(i) > input Then
                'Otherwise search the right half of the array
                upper = i - 1
            End If

        Loop

        'Output if the value was found
        If herbs(i) = input Then
            MessageBox.Show("Found " & input)
        Else
            MessageBox.Show("Did not find " & input)
        End If


    End Sub
End Class
