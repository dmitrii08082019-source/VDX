<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VdxForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonBack = New System.Windows.Forms.Button()
        Me.ButtonForward = New System.Windows.Forms.Button()
        Me.ButtonNew = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.ButtonNewVdx = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Is Active: False"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Path: "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 57)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 19)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Check Path"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(98, 56)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(493, 19)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Value = 100
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(9, 80)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(583, 225)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 127
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 77
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.Width = 81
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Active"
        Me.ColumnHeader4.Width = 76
        '
        'ButtonBack
        '
        Me.ButtonBack.Location = New System.Drawing.Point(548, 6)
        Me.ButtonBack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonBack.Name = "ButtonBack"
        Me.ButtonBack.Size = New System.Drawing.Size(20, 19)
        Me.ButtonBack.TabIndex = 5
        Me.ButtonBack.Text = "<"
        Me.ButtonBack.UseVisualStyleBackColor = True
        '
        'ButtonForward
        '
        Me.ButtonForward.Location = New System.Drawing.Point(572, 6)
        Me.ButtonForward.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonForward.Name = "ButtonForward"
        Me.ButtonForward.Size = New System.Drawing.Size(19, 19)
        Me.ButtonForward.TabIndex = 6
        Me.ButtonForward.Text = ">"
        Me.ButtonForward.UseVisualStyleBackColor = True
        '
        'ButtonNew
        '
        Me.ButtonNew.Location = New System.Drawing.Point(535, 286)
        Me.ButtonNew.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonNew.Name = "ButtonNew"
        Me.ButtonNew.Size = New System.Drawing.Size(56, 19)
        Me.ButtonNew.TabIndex = 7
        Me.ButtonNew.Text = "New"
        Me.ButtonNew.UseVisualStyleBackColor = True
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Location = New System.Drawing.Point(482, 286)
        Me.ButtonDelete.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(56, 19)
        Me.ButtonDelete.TabIndex = 8
        Me.ButtonDelete.Text = "Delete"
        Me.ButtonDelete.UseVisualStyleBackColor = True
        '
        'ButtonNewVdx
        '
        Me.ButtonNewVdx.Location = New System.Drawing.Point(9, 309)
        Me.ButtonNewVdx.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ButtonNewVdx.Name = "ButtonNewVdx"
        Me.ButtonNewVdx.Size = New System.Drawing.Size(84, 19)
        Me.ButtonNewVdx.TabIndex = 9
        Me.ButtonNewVdx.Text = "New VDX"
        Me.ButtonNewVdx.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(517, 331)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 10
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'VdxForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 366)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonNewVdx)
        Me.Controls.Add(Me.ButtonDelete)
        Me.Controls.Add(Me.ButtonNew)
        Me.Controls.Add(Me.ButtonForward)
        Me.Controls.Add(Me.ButtonBack)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "VdxForm"
        Me.ShowIcon = False
        Me.Text = "VDX"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label1 As Windows.Forms.Label
    Public WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents ListView1 As Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As Windows.Forms.ColumnHeader
    Friend WithEvents ButtonBack As Windows.Forms.Button
    Friend WithEvents ButtonForward As Windows.Forms.Button
    Friend WithEvents ButtonNew As Windows.Forms.Button
    Friend WithEvents ButtonDelete As Windows.Forms.Button
    Friend WithEvents ButtonNewVdx As Windows.Forms.Button
    Friend WithEvents ButtonClose As Windows.Forms.Button
End Class
