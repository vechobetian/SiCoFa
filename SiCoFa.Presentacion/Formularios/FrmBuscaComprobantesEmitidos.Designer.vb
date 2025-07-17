<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaComprobantesEmitidos
    'Inherits System.Windows.Forms.Form
    Inherits clsFrmBase

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
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtTipoComprobante = New System.Windows.Forms.TextBox()
        Me.mtxtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMostrarComprobantes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtxtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(256, 12)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(519, 35)
        Me.txtCliente.TabIndex = 1
        '
        'txtTipoComprobante
        '
        Me.txtTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoComprobante.Location = New System.Drawing.Point(256, 53)
        Me.txtTipoComprobante.Name = "txtTipoComprobante"
        Me.txtTipoComprobante.Size = New System.Drawing.Size(519, 35)
        Me.txtTipoComprobante.TabIndex = 2
        '
        'mtxtFechaDesde
        '
        Me.mtxtFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaDesde.Location = New System.Drawing.Point(256, 94)
        Me.mtxtFechaDesde.Mask = "00/00/0000"
        Me.mtxtFechaDesde.Name = "mtxtFechaDesde"
        Me.mtxtFechaDesde.Size = New System.Drawing.Size(519, 35)
        Me.mtxtFechaDesde.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 29)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cliente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 29)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Comprobante:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 29)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Fecha Desde:"
        '
        'btnMostrarComprobantes
        '
        Me.btnMostrarComprobantes.Location = New System.Drawing.Point(644, 176)
        Me.btnMostrarComprobantes.Name = "btnMostrarComprobantes"
        Me.btnMostrarComprobantes.Size = New System.Drawing.Size(131, 23)
        Me.btnMostrarComprobantes.TabIndex = 5
        Me.btnMostrarComprobantes.Text = "&Mostrar Comprobantes"
        Me.btnMostrarComprobantes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 29)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Fecha Hasta:"
        '
        'mtxtFechaHasta
        '
        Me.mtxtFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaHasta.Location = New System.Drawing.Point(256, 135)
        Me.mtxtFechaHasta.Mask = "00/00/0000"
        Me.mtxtFechaHasta.Name = "mtxtFechaHasta"
        Me.mtxtFechaHasta.Size = New System.Drawing.Size(519, 35)
        Me.mtxtFechaHasta.TabIndex = 4
        '
        'FrmBuscaComprobantesEmitidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 209)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mtxtFechaHasta)
        Me.Controls.Add(Me.btnMostrarComprobantes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mtxtFechaDesde)
        Me.Controls.Add(Me.txtTipoComprobante)
        Me.Controls.Add(Me.txtCliente)
        Me.Name = "FrmBuscaComprobantesEmitidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobantes Emitidos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtTipoComprobante As TextBox
    Friend WithEvents mtxtFechaDesde As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnMostrarComprobantes As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxtFechaHasta As MaskedTextBox
End Class
