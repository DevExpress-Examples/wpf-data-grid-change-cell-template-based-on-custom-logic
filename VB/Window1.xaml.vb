Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace EditorsDesignTime

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim list As List(Of TestData) = New List(Of TestData)()
            For i As Integer = 0 To 100 - 1
                list.Add(New TestData() With {.Editor = GetEditorType(i), .Value = GetEditValue(i)})
            Next

            Me.grid.ItemsSource = list
        End Sub

        Private Function GetEditorType(ByVal index As Integer) As String
            Select Case index Mod 6
                Case 0
                    Return "booleanEditor"
                Case 1
                    Return "buttonEditor"
                Case 2
                    Return "comboboxEditor"
                Case 3
                    Return "dateEditor"
                Case 4
                    Return "textEditor"
                Case Else
                    Return String.Empty
            End Select
        End Function

        Private Function GetEditValue(ByVal index As Integer) As Object
            Select Case index Mod 6
                Case 0
                    Return index Mod 2 = 0
                Case 1
                    Return "button edit " & index
                Case 2
                    Return If(index Mod 2 = 0, Alignment.Far, Alignment.Near)
                Case 3
                    Return Date.Today.AddDays(index)
                Case 4
                    Return "text " & index
                Case Else
                    Return String.Empty
            End Select
        End Function
    End Class

    Public Class TestData

        Public Property Editor As String

        Public Property Value As Object
    End Class

    Public Class EditorTemplateSelector
        Inherits DataTemplateSelector

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim data As EditGridCellData = CType(item, EditGridCellData)
            Dim dataItem = TryCast(data.RowData.Row, TestData)
            Return If(dataItem Is Nothing OrElse String.IsNullOrEmpty(dataItem.Editor), Nothing, CType(CType(container, FrameworkElement).FindResource(dataItem.Editor), DataTemplate))
        End Function
    End Class
End Namespace
