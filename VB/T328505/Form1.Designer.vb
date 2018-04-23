Namespace T328505
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.tokenEdit1 = New T328505.MyTokenEdit()
            Me.checkEdit1 = New DevExpress.XtraEditors.CheckEdit()
            DirectCast(Me.tokenEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' tokenEdit1
            '             
            Me.tokenEdit1.Location = New System.Drawing.Point(12, 12)
            Me.tokenEdit1.Name = "tokenEdit1"
            Me.tokenEdit1.Properties.UseCustomFilter = False
            Me.tokenEdit1.Properties.PopupFilterMode = DevExpress.XtraEditors.TokenEditPopupFilterMode.Contains
            Me.tokenEdit1.Properties.Separators.AddRange(New String() { ","})
            Me.tokenEdit1.Properties.Tokens.Add(New DevExpress.XtraEditors.TokenEditToken("Harlen Morais Naves", "Harlen Morais Naves"))
            Me.tokenEdit1.Properties.Tokens.Add(New DevExpress.XtraEditors.TokenEditToken("Alex Bob Smith", "Alex Bob Smith"))
            Me.tokenEdit1.Properties.Tokens.Add(New DevExpress.XtraEditors.TokenEditToken("John Morais Davis", "John Morais Davis"))
            Me.tokenEdit1.Size = New System.Drawing.Size(292, 20)
            Me.tokenEdit1.TabIndex = 0
            ' 
            ' checkEdit1
            ' 
            Me.checkEdit1.Location = New System.Drawing.Point(331, 13)
            Me.checkEdit1.Name = "checkEdit1"
            Me.checkEdit1.Properties.Caption = "Enable custom filtering"
            Me.checkEdit1.Size = New System.Drawing.Size(133, 19)
            Me.checkEdit1.TabIndex = 1
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(472, 60)
            Me.Controls.Add(Me.checkEdit1)
            Me.Controls.Add(Me.tokenEdit1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.tokenEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.checkEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private tokenEdit1 As MyTokenEdit
        Private checkEdit1 As DevExpress.XtraEditors.CheckEdit
    End Class
End Namespace

