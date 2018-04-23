Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Namespace T328505
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Me.tokenEdit1.Properties.UseCustomFilter = True
            Me.tokenEdit1.Properties.CustomFilterTokens = New EventHandler(Of MyFilterEventArgs)(AddressOf TokenEdit_CustomFilterText)
        End Sub
        Private Sub TokenEdit_CustomFilterText(ByVal sender As Object, ByVal e As MyFilterEventArgs)
            If Me.checkEdit1.Checked Then
                e.IsValidToken = e.Token.Description.Contains("Morais")
            End If
        End Sub
    End Class
End Namespace
