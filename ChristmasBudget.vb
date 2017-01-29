Public Class Form1
    'Matthew Meade
    'Lab 9 Program 2
    '1/12/2016

    'Class level arrays and variable
    Dim nom(14) As String
    Dim description(14) As String
    Dim store(14) As String
    Dim cost(14) As Double

    Dim totalCost As Double 'Sum of cost array


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Names
        nom = {
            "Matthew", "Matthew", "Meghan",
            "Meghan", "Kenny", "Kenny",
            "Paula", "Paula", "Paul",
            "Paul", "Marlene", "Marlene",
            "Jon", "Marry", "Joe"
        }

        'Gift names
        description = {
            "GPU", "SSD", "XBox",
            "Money", "iPad", "GPS",
            "Keyboard", "Book", "Tools",
            "Laptop", "Tablet", "Watch",
            "Toaster", "Shoes", "Coal"
        }

        'Store Names
        store = {
            "NCIX", "Newegg", "Best Buy",
            "Bank", "eBay", "Kents",
            "NCIX", "Chapters", "Kents",
            "Newegg", "Best Buy", "Walmart",
            "Amazon", "Sears", "Santa"
        }

        'Gift Costs
        cost = {
            600, 249.95, 450,
            25, 300, 49.9,
            100, 24.99, 30,
            450, 200, 60,
            15, 80, 3
        }

        'Loop through all the gifts
        For i = 0 To cost.GetUpperBound(0)
            'Add cost of gift to total
            totalCost += cost(i)
        Next
    End Sub


    'Display all gifts
    Private Sub allButton_Click(sender As Object, e As EventArgs) Handles allButton.Click

        'Clear output
        outputListBox.Items.Clear()

        'Loop through gifts
        For i = 0 To nom.GetUpperBound(0)
            'Output Gift
            outputListBox.Items.Add(nom(i) & vbTab & description(i) & vbTab & store(i) & vbTab & "$" & cost(i))
        Next
    End Sub


    'Prompt user for budget and output how much they are over or under budget
    Private Sub budgetButton_Click(sender As Object, e As EventArgs) Handles budgetButton.Click

        'Prompt for budget and subtract total cost of gifts
        Dim budget As Double = InputBox("Enter Budget", "Budget", 0)
        Dim remaining As Double = budget - totalCost

        'If the remaining budget is above 0
        If remaining >= 0 Then
            'Tell the user what is left in the budget
            MessageBox.Show("Under budget! $" & Format(remaining, "0.00") & " remaining")
        Else
            'Tell the user how over budget they are
            MessageBox.Show("Over budget by $" & Format(remaining * -1, "0.00"))
        End If
    End Sub


    Private Sub nameButton_Click(sender As Object, e As EventArgs) Handles nameButton.Click

        'Prompt for name to search for
        Dim name As String = InputBox("Enter name", "Name", "John Doe")
        Dim total As Double = 0

        'Clear output
        outputListBox.Items.Clear()

        'Loop through all the names
        For i = 0 To nom.GetUpperBound(0)
            'If the current name is the name being searched for
            If nom(i) = name Then
                'Output it
                outputListBox.Items.Add(nom(i) & vbTab & description(i) & vbTab & "$" & cost(i))
                total += cost(i) 'Add it's cost to total
            End If
        Next

        'If the total is greater than 0 (at least one gift was found for name)
        If total > 0 Then
            'Output Total
            outputListBox.Items.Add(vbTab & "Total: " & vbTab & total)
        Else
            'Tell user name was not found
            MessageBox.Show("No items purchased for " & name)
        End If
    End Sub


    'Calculate average cost of gifts then display all gifts that cost greater
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Calculate average
        Dim avg = totalCost / cost.Length

        'Clear output
        outputListBox.Items.Clear()

        'Output average cost
        outputListBox.Items.Add("Average Cost: $" & Format(avg, "0.00"))
        outputListBox.Items.Add("") 'Blank line for display

        'Loop through all gifts
        For i = 0 To cost.GetUpperBound(0)
            'If cost of gift is greater than average
            If cost(i) > avg Then
                'Output gift info
                outputListBox.Items.Add(nom(i) & vbTab & description(i) & vbTab & "$" & cost(i))
            End If
        Next
    End Sub

End Class