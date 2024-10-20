<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAperComprobantes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Cliente = New System.Windows.Forms.TextBox()
        Me.Hasta = New System.Windows.Forms.MaskedTextBox()
        Me.Desde = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.TipoComprobante = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Cliente
        '
        Me.Cliente.Location = New System.Drawing.Point(91, 12)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(300, 20)
        Me.Cliente.TabIndex = 0
        '
        'Hasta
        '
        Me.Hasta.Location = New System.Drawing.Point(91, 92)
        Me.Hasta.Mask = "00/00/0000"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(300, 20)
        Me.Hasta.TabIndex = 3
        Me.Hasta.ValidatingType = GetType(Date)
        '
        'Desde
        '
        Me.Desde.Location = New System.Drawing.Point(91, 66)
        Me.Desde.Mask = "00/00/0000"
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(300, 20)
        Me.Desde.TabIndex = 2
        Me.Desde.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Tipo Comp:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Desde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Hasta:"
        '
        'Aceptar
        '
        Me.Aceptar.Location = New System.Drawing.Point(316, 118)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Aceptar.TabIndex = 4
        Me.Aceptar.Text = "&Aceptar"
        Me.Aceptar.UseVisualStyleBackColor = True
        '
        'TipoComprobante
        '
        Me.TipoComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TipoComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TipoComprobante.FormattingEnabled = True
        Me.TipoComprobante.ItemHeight = 13
        Me.TipoComprobante.Location = New System.Drawing.Point(91, 38)
        Me.TipoComprobante.Name = "TipoComprobante"
        Me.TipoComprobante.Size = New System.Drawing.Size(300, 21)
        Me.TipoComprobante.TabIndex = 1
        '
        'FrmAperComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 147)
        Me.Controls.Add(Me.TipoComprobante)
        Me.Controls.Add(Me.Aceptar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Hasta)
        Me.Controls.Add(Me.Desde)
        Me.Controls.Add(Me.Cliente)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAperComprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobantes Emitidos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cliente As TextBox
    Friend WithEvents Hasta As MaskedTextBox
    Friend WithEvents Desde As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Aceptar As Button
    Friend WithEvents TipoComprobante As ComboBox
End Class
