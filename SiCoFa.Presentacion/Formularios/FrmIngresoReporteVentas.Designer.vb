<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoReporteVentas
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
        Me.mtxtFechaDesde = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMostrarVentas = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mtxtFechaHasta = New System.Windows.Forms.MaskedTextBox()
        Me.SuspendLayout()
        '
        'mtxtFechaDesde
        '
        Me.mtxtFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaDesde.Location = New System.Drawing.Point(181, 12)
        Me.mtxtFechaDesde.Mask = "00/00/0000"
        Me.mtxtFechaDesde.Name = "mtxtFechaDesde"
        Me.mtxtFechaDesde.Size = New System.Drawing.Size(128, 35)
        Me.mtxtFechaDesde.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 29)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Fecha Desde:"
        '
        'btnMostrarVentas
        '
        Me.btnMostrarVentas.Location = New System.Drawing.Point(181, 94)
        Me.btnMostrarVentas.Name = "btnMostrarVentas"
        Me.btnMostrarVentas.Size = New System.Drawing.Size(128, 23)
        Me.btnMostrarVentas.TabIndex = 5
        Me.btnMostrarVentas.Text = "&Mostrar Ventas"
        Me.btnMostrarVentas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 29)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Fecha Hasta:"
        '
        'mtxtFechaHasta
        '
        Me.mtxtFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaHasta.Location = New System.Drawing.Point(181, 53)
        Me.mtxtFechaHasta.Mask = "00/00/0000"
        Me.mtxtFechaHasta.Name = "mtxtFechaHasta"
        Me.mtxtFechaHasta.Size = New System.Drawing.Size(128, 35)
        Me.mtxtFechaHasta.TabIndex = 4
        '
        'FrmIngresoReporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 130)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mtxtFechaHasta)
        Me.Controls.Add(Me.btnMostrarVentas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mtxtFechaDesde)
        Me.Name = "FrmIngresoReporteVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Reporte de Ventas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mtxtFechaDesde As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnMostrarVentas As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxtFechaHasta As MaskedTextBox
End Class
