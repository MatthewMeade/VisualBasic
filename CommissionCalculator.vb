Public Class Form1
    'Matthew Meade
    'Lab 7
    '15/11/2016
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        'Variables
        Dim sales, commission, totalSales, totalCommission, amount As Double
        Dim name As String

        'Initialize totals
        totalSales = 0 : totalCommission = 0

        'Prompt for name
        name = InputBox("Enter salesperson's name or 'XXX' to exit", "Enter Name")
        Do Until name.ToUpper() = "XXX" 'Loop until user enters XXX
            'Reset sales for new person
            sales = 0

            'Prompt for sale amount and add it to sales until user enters 0
            amount = InputBox("Enter sale amount or 0 to move to next salesperson", "Enter sale amount", "0")
            Do Until amount = 0
                sales += amount
                amount = InputBox("Enter sale amount or 0 to move to next salesperson", "Enter sale amount", "0")
            Loop

            'Calculate commission (5% of sales)
            commission = sales * 0.05

            'Add sales and commission to total
            totalSales += sales
            totalCommission += commission

            'Output current person's sales and commissions
            outputListBox.Items.Add(name & "'s sales: $" & sales)
            outputListBox.Items.Add(name & "'s commission: $" & Format(commission, "0.00"))

            'Add blank line to output 
            outputListBox.Items.Add("")

            'Prompt for new person
            name = InputBox("Enter salesperson's name or 'XXX' to exit", "Enter Name")
        Loop

        'Output Totals
        outputListBox.Items.Add("Total sales: $" & totalSales)
        outputListBox.Items.Add("Total commission: $" & Format(totalCommission, "0.00"))
    End Sub
End Class