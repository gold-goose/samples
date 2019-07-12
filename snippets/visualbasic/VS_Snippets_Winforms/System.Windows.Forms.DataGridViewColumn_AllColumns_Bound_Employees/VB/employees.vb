﻿' Databinding between checkbox state to some table, implement updating.
' Lots of validation work could happen for adding a new row scenario: validate employee id, boss Id.
'

'<snippet0>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Drawing

Public Class Employees
    Inherits System.Windows.Forms.Form

    Private WithEvents DataGridView1 As New DataGridView
    Private WithEvents DataGridView2 As New DataGridView

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Try
            Application.EnableVisualStyles()
            Application.Run(New Employees())
        Catch e As Exception
            MessageBox.Show(e.Message & e.StackTrace)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            SetUpForm()
            SetUpDataGridView1()
            SetUpDataGridView2()
        Catch ex As SqlException
            MessageBox.Show("The connection string <" _
                & connectionString _
                & "> failed to connect.  Modify it to connect to " _
                & "a Northwind database accessible to your system.", _
                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Application.Exit()
        End Try
    End Sub

    Private Sub SetUpForm()
        Size = New Size(800, 600)
        Dim flowLayout As New FlowLayoutPanel()
        flowLayout.FlowDirection = FlowDirection.TopDown
        flowLayout.Dock = DockStyle.Fill
        Controls.Add(flowLayout)
        Text = "DataGridView columns demo"

        flowLayout.Controls.Add(DataGridView1)
        flowLayout.Controls.Add(DataGridView2)
    End Sub

    '<snippet80>
    Private Sub SetUpDataGridView2()
        DataGridView2.Dock = DockStyle.Bottom
        DataGridView2.TopLeftHeaderCell.Value = "Sales Details"
        DataGridView2.RowHeadersWidthSizeMode = _
        DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
    End Sub
    '</snippet80>

    Private Sub SetUpDataGridView1()
        ' Virtual mode is turned on so that the
        ' unbound DataGridViewCheckBoxColumn will
        ' keep its state when the bound columns are
        ' sorted.
        DataGridView1.VirtualMode = True

        DataGridView1.AutoSize = True
        DataGridView1.DataSource = _
            Populate("SELECT * FROM Employees")
        DataGridView1.TopLeftHeaderCell.Value = "Employees"
        DataGridView1.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False

        ' The below autogenerated column is removed so 
        ' a DataGridViewComboboxColumn could be used instead.
        DataGridView1.Columns.Remove( _
            ColumnName.TitleOfCourtesy.ToString())
        DataGridView1.Columns.Remove(ColumnName.ReportsTo.ToString())

        AddLinkColumn()
        AddComboBoxColumns()
        AddButtonColumn()
        AddOutOfOfficeColumn()
    End Sub

    Private Sub AddComboBoxColumns()
        Dim comboboxColumn As DataGridViewComboBoxColumn
        comboboxColumn = CreateComboBoxColumn()
        SetAlternateChoicesUsingDataSource(comboboxColumn)
        comboboxColumn.HeaderText = _
            "TitleOfCourtesy (via DataSource property)"
        DataGridView1.Columns.Insert(0, comboboxColumn)

        comboboxColumn = CreateComboBoxColumn()
        SetAlternateChoicesUsingItems(comboboxColumn)
        comboboxColumn.HeaderText = _
            "TitleOfCourtesy (via Items property)"
        ' Tack this example column onto the end.
        DataGridView1.Columns.Add(comboboxColumn)
    End Sub

    '<snippet70>
    Private Sub AddLinkColumn()

        Dim links As New DataGridViewLinkColumn()
        With links
            .UseColumnTextForLinkValue = True
            .HeaderText = ColumnName.ReportsTo.ToString()
            .DataPropertyName = ColumnName.ReportsTo.ToString()
            .ActiveLinkColor = Color.White
            .LinkBehavior = LinkBehavior.SystemDefault
            .LinkColor = Color.Blue
            .TrackVisitedState = True
            .VisitedLinkColor = Color.YellowGreen
        End With
        DataGridView1.Columns.Add(links)
    End Sub
    '</snippet70>

    '<snippet30>
    Private Shared Sub SetAlternateChoicesUsingItems( _
        ByVal comboboxColumn As DataGridViewComboBoxColumn)

        comboboxColumn.Items.AddRange("Mr.", "Ms.", "Mrs.", "Dr.")

    End Sub

    '<snippet40>
    Private Function CreateComboBoxColumn() _
        As DataGridViewComboBoxColumn
        Dim column As New DataGridViewComboBoxColumn()

        With column
            .DataPropertyName = ColumnName.TitleOfCourtesy.ToString()
            .HeaderText = ColumnName.TitleOfCourtesy.ToString()
            .DropDownWidth = 160
            .Width = 90
            .MaxDropDownItems = 3
            .FlatStyle = FlatStyle.Flat
        End With
        Return column
    End Function
    '</snippet30>

    Private Sub SetAlternateChoicesUsingDataSource( _
        ByVal comboboxColumn As DataGridViewComboBoxColumn)
        With comboboxColumn
            .DataSource = RetrieveAlternativeTitles()
            .ValueMember = ColumnName.TitleOfCourtesy.ToString()
            .DisplayMember = .ValueMember
        End With
    End Sub

    Private Function RetrieveAlternativeTitles() As DataTable
        Return Populate( _
            "SELECT distinct TitleOfCourtesy FROM Employees")
    End Function

    Private connectionString As String = _
            "Integrated Security=SSPI;Persist Security Info=False;" _
            & "Initial Catalog=Northwind;Data Source=localhost"

    Private Function Populate(ByVal sqlCommand As String) As DataTable
        Dim northwindConnection As New SqlConnection(connectionString)
        northwindConnection.Open()

        Dim command As New SqlCommand(sqlCommand, _
            northwindConnection)
        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = command
        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)

        Return table
    End Function

    ' Using an enum provides some abstraction between column index
    ' and column name along with compile time checking, and gives
    ' a handy place to store the column names.
    Enum ColumnName
        EmployeeId
        LastName
        FirstName
        Title
        TitleOfCourtesy
        BirthDate
        HireDate
        Address
        City
        Region
        PostalCode
        Country
        HomePhone
        Extension
        Photo
        Notes
        ReportsTo
        PhotoPath
        OutOfOffice
    End Enum
    '</snippet40>

    '<snippet10>
    Private Sub AddButtonColumn()
        Dim buttons As New DataGridViewButtonColumn()
        With buttons
            .HeaderText = "Sales"
            .Text = "Sales"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate.Style.BackColor = Color.Honeydew
            .DisplayIndex = 0
        End With

        DataGridView1.Columns.Add(buttons)

    End Sub
    '</snippet10>

    '<snippet20>
    Private Sub AddOutOfOfficeColumn()
        Dim column As New DataGridViewCheckBoxColumn()
        With column
            .HeaderText = ColumnName.OutOfOffice.ToString()
            .Name = ColumnName.OutOfOffice.ToString()
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With

        DataGridView1.Columns.Insert(0, column)
    End Sub
    '</snippet20>

    Private Sub PopulateSales( _
        ByVal buttonClick As DataGridViewCellEventArgs)

        Dim employeeId As String = _
            DataGridView1.Rows(buttonClick.RowIndex). _
            Cells(ColumnName.EmployeeId.ToString()).Value().ToString()
        DataGridView2.DataSource = Populate( _
            "SELECT * FROM Orders WHERE EmployeeId = " & employeeId)
    End Sub

#Region "SQL Error handling"
    '<snippet50>
    Private Sub DataGridView1_DataError(ByVal sender As Object, _
    ByVal e As DataGridViewDataErrorEventArgs) _
    Handles DataGridView1.DataError

        MessageBox.Show("Error happened " _
            & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = _
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If
    End Sub
    '</snippet50>
#End Region

    '<snippet60>
    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellContentClick

        If IsANonHeaderLinkCell(e) Then
            MoveToLinked(e)
        ElseIf IsANonHeaderButtonCell(e) Then
            PopulateSales(e)
        End If
    End Sub

    Private Sub MoveToLinked(ByVal e As DataGridViewCellEventArgs)
        Dim employeeId As String
        Dim value As Object = DataGridView1.Rows(e.RowIndex). _
            Cells(e.ColumnIndex).Value
        If value.GetType Is GetType(DBNull) Then Return

        employeeId = CType(value, String)
        Dim boss As DataGridViewCell = _
            RetrieveSuperiorsLastNameCell(employeeId)
        If boss IsNot Nothing Then
            DataGridView1.CurrentCell = boss
        End If
    End Sub

    Private Function IsANonHeaderLinkCell(ByVal cellEvent As _
        DataGridViewCellEventArgs) As Boolean

        If TypeOf DataGridView1.Columns(cellEvent.ColumnIndex) _
            Is DataGridViewLinkColumn _
            AndAlso Not cellEvent.RowIndex = -1 Then _
            Return True Else Return False

    End Function

    Private Function IsANonHeaderButtonCell(ByVal cellEvent As _
        DataGridViewCellEventArgs) As Boolean

        If TypeOf DataGridView1.Columns(cellEvent.ColumnIndex) _
            Is DataGridViewButtonColumn _
            AndAlso Not cellEvent.RowIndex = -1 Then _
            Return True Else Return (False)

    End Function

    Private Function RetrieveSuperiorsLastNameCell( _
        ByVal employeeId As String) As DataGridViewCell

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Return Nothing
            If row.Cells(ColumnName.EmployeeId.ToString()). _
                Value.ToString().Equals(employeeId) Then
                Return row.Cells(ColumnName.LastName.ToString())
            End If
        Next
        Return Nothing
    End Function
    '</snippet60>

#Region "checkbox state"
    Dim inOffice As New Dictionary(Of String, Boolean)
    Private Sub DataGridView1_CellValuePushed(ByVal sender As Object, _
     ByVal e As DataGridViewCellValueEventArgs) _
        Handles DataGridView1.CellValuePushed

        If IsCheckBoxColumn(e.ColumnIndex) Then
            Dim employeeId As String = GetKey(e)
            If Not inOffice.ContainsKey(employeeId) Then
                inOffice.Add(employeeId, CType(e.Value, Boolean))
            Else
                inOffice.Item(employeeId) = CType(e.Value, Boolean)
            End If
        End If
    End Sub

    Private Function GetKey(ByVal cell As DataGridViewCellValueEventArgs) As String
        Return DataGridView1.Rows(cell.RowIndex).Cells( _
            ColumnName.EmployeeId.ToString()).Value().ToString()
    End Function

    Private Sub DataGridView1_CellValueNeeded(ByVal sender As Object, _
     ByVal e As DataGridViewCellValueEventArgs) _
        Handles DataGridView1.CellValueNeeded

        If IsCheckBoxColumn(e.ColumnIndex) Then
            Dim employeeId As String = GetKey(e)
            If Not inOffice.ContainsKey(employeeId) Then
                Dim defaultValue As Boolean = False
                inOffice.Add(employeeId, defaultValue)
            End If

            e.Value = inOffice.Item(employeeId)
        End If
    End Sub

    Private Function IsCheckBoxColumn(ByVal columnIndex As Integer) As Boolean

        Dim outOfOfficeColumn As DataGridViewColumn = _
            DataGridView1.Columns(ColumnName.OutOfOffice.ToString())
        Return (DataGridView1.Columns(columnIndex) Is outOfOfficeColumn)

    End Function
#End Region

End Class
'</snippet0>