Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Popup
Imports System.Collections

Namespace T328505
    <UserRepositoryItem("RegisterMyTokenEdit")> _
    Public Class RepositoryItemMyTokenEdit
        Inherits RepositoryItemTokenEdit

        Shared Sub New()
            RegisterMyTokenEdit()
        End Sub

        Private customFilterHandler As EventHandler(Of MyFilterEventArgs)
        Private _UseCustomFilter As Boolean

        Public Property UseCustomFilter() As Boolean
            Get
                Return _UseCustomFilter
            End Get
            Set(ByVal value As Boolean)
                _UseCustomFilter = value
            End Set
        End Property

        Public Property CustomFilterTokens() As EventHandler(Of MyFilterEventArgs)
            Get
                Return customFilterHandler
            End Get
            Set(ByVal value As EventHandler(Of MyFilterEventArgs))
                customFilterHandler = value
            End Set
        End Property

        Public Const CustomEditName As String = "MyTokenEdit"

        Public Sub New()
        End Sub

        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return CustomEditName
            End Get
        End Property

        Public Shared Sub RegisterMyTokenEdit()
            Dim img As Image = Nothing
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(MyTokenEdit), GetType(RepositoryItemMyTokenEdit), GetType(MyTokenEditViewInfo), New TokenEditPainter(), True, img))
        End Sub

        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            Try
                MyBase.Assign(item)
                Dim source As RepositoryItemMyTokenEdit = TryCast(item, RepositoryItemMyTokenEdit)
                If source Is Nothing Then
                    Return
                End If
                Me.UseCustomFilter = source.UseCustomFilter
                Me.CustomFilterTokens = source.CustomFilterTokens
                '
            Finally
                EndUpdate()
            End Try
        End Sub

        Friend Sub OnCustomFilterText(ByVal args As MyFilterEventArgs)
            If customFilterHandler IsNot Nothing Then
                customFilterHandler(Me, args)
            End If
        End Sub
    End Class

    <ToolboxItem(True)> _
    Public Class MyTokenEdit
        Inherits TokenEdit

        Friend Sub OnCustomFilterText(ByVal args As MyFilterEventArgs)
            Me.Properties.OnCustomFilterText(args)
        End Sub

        Shared Sub New()
            RepositoryItemMyTokenEdit.RegisterMyTokenEdit()
        End Sub

        Public Sub New()
        End Sub

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Shadows ReadOnly Property Properties() As RepositoryItemMyTokenEdit
            Get
                Return TryCast(MyBase.Properties, RepositoryItemMyTokenEdit)
            End Get
        End Property

        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return RepositoryItemMyTokenEdit.CustomEditName
            End Get
        End Property

        Protected Overrides Function CreatePopupForm() As TokenEditPopupForm
            Return New MyTokenEditPopupForm(Me)
        End Function

        Protected Overrides Function CreatePopupController() As BaseTokenEditPopupController
            If Properties.EditMode = TokenEditMode.TokenList OrElse Properties.EditMode = TokenEditMode.Default Then
                Return New MyTokenEditTokenListPopupController(Me)
            End If
            Return New TokenEditManualModePopupController(Me)
        End Function
    End Class
    Public Class MyTokenEditViewInfo
        Inherits TokenEditViewInfo

        Public Sub New(ByVal item As RepositoryItem)
            MyBase.New(item)
        End Sub
    End Class

    Public Class MyTokenEditPopupForm
        Inherits TokenEditPopupForm

        Public Sub New(ByVal edit As TokenEdit)
            MyBase.New(edit)
        End Sub

        Protected Overrides Function CreateDropDownControl() As ITokenEditDropDownControl
            Dim control As New MyDefaultTokenEditDropDownControl()
            Return control
        End Function
    End Class

    Public Class MyDefaultTokenEditDropDownControl
        Inherits DefaultTokenEditDropDownControl

        Public Sub New()
            MyBase.New()
        End Sub

        Private Function GetCustomFilterSourceCore() As IList
            Dim tokCol As TokenEditTokenCollection = Properties.Tokens
            Dim selCol As TokenEditSelectedItemCollection = Properties.SelectedItems
            If selCol.Count = 0 Then
                Return tokCol
            End If
            Dim indices As New HashSet(Of Integer)()
            For i As Integer = 0 To selCol.Count - 1
                Dim tok As TokenEditToken = selCol(i)
                indices.Add(Properties.Tokens.IndexOf(tok))
            Next i
            Dim list As New List(Of TokenEditToken)(tokCol.Count)
            For i As Integer = 0 To tokCol.Count - 1
                If indices.Contains(i) Then
                    Continue For
                End If
                list.Add(tokCol(i))
            Next i
            Return list
        End Function

        Private Function GetCustomFilterSource() As IList
            Dim list As IList = GetCustomFilterSourceCore()
            Dim newList As New List(Of TokenEditToken)()
            Dim edit As MyTokenEdit = TryCast(Me.OwnerEdit, MyTokenEdit)
            For i As Integer = 0 To list.Count - 1
                Dim args As New MyFilterEventArgs(TryCast(list(i), TokenEditToken))
                edit.OnCustomFilterText(args)
                If args.IsValidToken Then
                    newList.Add(TryCast(list(i), TokenEditToken))
                End If
            Next i
            Return newList
        End Function

        Public Overrides Sub SetDataSource(ByVal obj As Object)
            If (TryCast((TryCast(OwnerEdit, MyTokenEdit)).Properties, RepositoryItemMyTokenEdit)).UseCustomFilter Then
                MyBase.SetDataSource(GetCustomFilterSource())
            Else
                MyBase.SetDataSource(obj)
            End If
        End Sub
    End Class

    Public Class MyTokenEditTokenListPopupController
        Inherits TokenEditTokenListPopupController

        Public Sub New(ByVal edit As TokenEdit)
            MyBase.New(edit)
        End Sub
        Public Overrides Sub UpdateFilter(ByVal filter As String)
            If (TryCast((TryCast(OwnerEdit, MyTokenEdit)).Properties, RepositoryItemMyTokenEdit)).UseCustomFilter Then
                filter = String.Empty
            End If
            MyBase.UpdateFilter(filter)
        End Sub
    End Class

    Public Class MyFilterEventArgs
        Inherits EventArgs

        ' Fields...
        Private _IsValidToken As Boolean
        Private _Token As TokenEditToken
        Public Property Token() As TokenEditToken
            Get
                Return _Token
            End Get
            Set(ByVal value As TokenEditToken)
                _Token = value
            End Set
        End Property

        Public Property IsValidToken() As Boolean
            Get
                Return _IsValidToken
            End Get
            Set(ByVal value As Boolean)
                _IsValidToken = value
            End Set
        End Property

        Public Sub New(ByVal token As TokenEditToken)
            Me.Token = token
            IsValidToken = True
        End Sub
    End Class
End Namespace
