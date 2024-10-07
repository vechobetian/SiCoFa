<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmIngConceptos

    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Cliente = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Finalizar = New System.Windows.Forms.Button()
        Me.ImpPago = New System.Windows.Forms.TextBox()
        Me.lblImpPago = New System.Windows.Forms.Label()
        Me.ImpAnticipos = New System.Windows.Forms.TextBox()
        Me.ImpTotalCancelado = New System.Windows.Forms.TextBox()
        Me.lblImpAnticipos = New System.Windows.Forms.Label()
        Me.lblImpTotal = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cliente
        '
        Me.Cliente.Location = New System.Drawing.Point(91, 12)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(378, 20)
        Me.Cliente.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DataGridView1.Location = New System.Drawing.Point(12, 75)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(457, 215)
        Me.DataGridView1.TabIndex = 4
        Me.DataGridView1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Cliente:"
        '
        'Finalizar
        '
        Me.Finalizar.Location = New System.Drawing.Point(393, 376)
        Me.Finalizar.Name = "Finalizar"
        Me.Finalizar.Size = New System.Drawing.Size(75, 23)
        Me.Finalizar.TabIndex = 35
        Me.Finalizar.TabStop = False
        Me.Finalizar.Text = "&Finalizar"
        Me.Finalizar.UseVisualStyleBackColor = True
        '
        'ImpPago
        '
        Me.ImpPago.Location = New System.Drawing.Point(91, 38)
        Me.ImpPago.Name = "ImpPago"
        Me.ImpPago.Size = New System.Drawing.Size(378, 20)
        Me.ImpPago.TabIndex = 3
        Me.ImpPago.TabStop = False
        '
        'lblImpPago
        '
        Me.lblImpPago.AutoSize = True
        Me.lblImpPago.Location = New System.Drawing.Point(17, 41)
        Me.lblImpPago.Name = "lblImpPago"
        Me.lblImpPago.Size = New System.Drawing.Size(70, 13)
        Me.lblImpPago.TabIndex = 39
        Me.lblImpPago.Text = "Imp. Pagado:"
        '
        'ImpAnticipos
        '
        Me.ImpAnticipos.Location = New System.Drawing.Point(358, 324)
        Me.ImpAnticipos.Name = "ImpAnticipos"
        Me.ImpAnticipos.Size = New System.Drawing.Size(111, 20)
        Me.ImpAnticipos.TabIndex = 40
        Me.ImpAnticipos.TabStop = False
        Me.ImpAnticipos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpTotalCancelado
        '
        Me.ImpTotalCancelado.Location = New System.Drawing.Point(357, 350)
        Me.ImpTotalCancelado.Name = "ImpTotalCancelado"
        Me.ImpTotalCancelado.Size = New System.Drawing.Size(111, 20)
        Me.ImpTotalCancelado.TabIndex = 42
        Me.ImpTotalCancelado.TabStop = False
        Me.ImpTotalCancelado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImpAnticipos
        '
        Me.lblImpAnticipos.AutoSize = True
        Me.lblImpAnticipos.Location = New System.Drawing.Point(243, 327)
        Me.lblImpAnticipos.Name = "lblImpAnticipos"
        Me.lblImpAnticipos.Size = New System.Drawing.Size(73, 13)
        Me.lblImpAnticipos.TabIndex = 43
        Me.lblImpAnticipos.Text = "Imp.Anticipos:"
        '
        'lblImpTotal
        '
        Me.lblImpTotal.AutoSize = True
        Me.lblImpTotal.Location = New System.Drawing.Point(243, 353)
        Me.lblImpTotal.Name = "lblImpTotal"
        Me.lblImpTotal.Size = New System.Drawing.Size(108, 13)
        Me.lblImpTotal.TabIndex = 45
        Me.lblImpTotal.Text = "Imp.Total Cencelado:"
        '
        'FrmIngPagoClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 405)
        Me.Controls.Add(Me.lblImpTotal)
        Me.Controls.Add(Me.lblImpAnticipos)
        Me.Controls.Add(Me.ImpTotalCancelado)
        Me.Controls.Add(Me.ImpAnticipos)
        Me.Controls.Add(Me.lblImpPago)
        Me.Controls.Add(Me.ImpPago)
        Me.Controls.Add(Me.Finalizar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Cliente)
        Me.KeyPreview = True
        Me.Name = "FrmIngPagoClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de Clientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cliente As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Finalizar As Button
    Friend WithEvents ImpPago As TextBox
    Friend WithEvents lblImpPago As Label
    Friend WithEvents ImpAnticipos As TextBox
    Friend WithEvents ImpTotalCancelado As TextBox
    Friend WithEvents lblImpAnticipos As Label
    Friend WithEvents lblImpTotal As Label
End Class
