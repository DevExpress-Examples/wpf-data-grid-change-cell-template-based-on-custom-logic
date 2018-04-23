Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Xml
Imports System.Collections
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Editors.Settings
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Core
Imports System.ComponentModel

Namespace EditorsDesignTime
    ''' <summary> 
    ''' Interaction logic for Window1.xaml 
    ''' </summary> 
    Partial Public Class Window1
        Inherits Window
        Public Sub New()
            InitializeComponent()
            Dim list As New List(Of TestData)()
            For i As Integer = 0 To 99
                list.Add(New TestData() With {.Editor = GetEditorType(i), .Value = GetEditValue(i)})
            Next
            grid.DataSource = list
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
                    Return DateTime.Today.AddDays(index)
                Case 4
                    Return "text " & index
                Case Else
                    Return String.Empty
            End Select
        End Function
    End Class
    Public Class TestData
        Private _Editor As String
        Public Property Editor() As String
            Get
                Return _Editor
            End Get
            Set(ByVal value As String)
                _Editor = value
            End Set
        End Property
        Private _Value As Object
        Public Property Value() As Object
            Get
                Return _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property
    End Class
    Public Class EditorTemplateSelector
        Inherits DataTemplateSelector
        Public Overloads Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim data As GridCellData = DirectCast(item, GridCellData)
            Dim [property] As PropertyDescriptor = TypeDescriptor.GetProperties(data.Data)("Editor")
            If [property] Is Nothing Then
                Return Nothing
            End If
            Dim editorType As String = TryCast(TypeDescriptor.GetProperties(data.Data)("Editor").GetValue(data.Data), String)
            Return If(String.IsNullOrEmpty(editorType), Nothing, DirectCast(DirectCast(container, FrameworkElement).FindResource(editorType), DataTemplate))
        End Function
    End Class
End Namespace