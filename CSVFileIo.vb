Imports System.IO
Public Class Form1

    'Matthew Meade
    'Lab 10 Program 2
    '8/12/2016

    'Winners array
    'Array sized to number of years since 1918
    Dim winners(Date.Today.Year - 1918) As String
    'Years with no winners stored as empty string

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Variables
        Dim file As StreamReader
        Dim record As String
        Dim fields() As String
        Dim i As Integer

        'Open file
        file = New StreamReader("winners.txt")

        'Loop through entire file
        Do Until file.EndOfStream

            'read line from file and split it
            record = file.ReadLine()
            fields = Split(record, ",")

            'Calculate index based on year field
            i = fields(1) - 1918
            winners(i) = fields(0)

        Loop

        'Close file
        file.Close()

    End Sub

    Private Sub searchTeamButton_Click(sender As Object, e As EventArgs) Handles searchTeamButton.Click

        'Clear output
        outputListbox.Items.Clear()

        'Get team from user
        Dim team As String = InputBox("Enter team name to search for", "Team name").Trim
        Dim c As Integer = 0 'Number of wins for team

        'Output team name if one is entered
        If team <> "" Then
            outputListbox.Items.Add(team & "Won in:")
        Else 'Search for years with no team entered
            outputListbox.Items.Add("There were no winners in:")
        End If

        'Loop through the years
        For i = 0 To winners.GetUpperBound(0)

            'If there is no winner for current year
            If winners(i) = Nothing Then
                'Continue loop
                Continue For
            End If

            'If current team is the team we are looking for
            If winners(i).ToLower = team.ToLower Then
                'Output the year
                outputListbox.Items.Add(i + 1918)
                c += 1 'Increment counter
            End If
        Next

        'If team was not found
        If c = 0 Then
            'Clear initial team name message and alert user
            outputListbox.Items.Clear()
            MessageBox.Show("Team '" & team & "' Not found")
        End If
    End Sub

    Private Sub yearSearch_Click(sender As Object, e As EventArgs) Handles yearSearch.Click

        'Minimum and maximum values for year
        Dim minYear = 1918
        Dim maxYear = winners.GetUpperBound(0) + minYear

        'Prompt for year from user
        Dim year As Integer = InputBox("Enter Year (" & minYear & " - " & maxYear & ")", "Year", 1918).Trim

        If year < minYear Or year > maxYear Then
            'Warn user if invalid year was entered
            MessageBox.Show("Year out of bounds")
        ElseIf winners(year - minYear) <> "" Then
            'Output winning team if one is found at winners(year - 1918)
            MessageBox.Show("Winner in " & year & " was: " & winners(year - minYear))
        Else
            'Output if there are no winners
            MessageBox.Show("No winners in " & year)
        End If

    End Sub
End Class
