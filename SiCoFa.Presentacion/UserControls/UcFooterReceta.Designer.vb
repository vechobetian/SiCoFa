<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcFooterReceta
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTotalReceta = New System.Windows.Forms.Label()
        Me.lblImporteTotalReceta = New System.Windows.Forms.Label()
        Me.lblAcargoOS = New System.Windows.Forms.Label()
        Me.lblImporteObraSocial = New System.Windows.Forms.Label()
        Me.lblAcargoCS = New System.Windows.Forms.Label()
        Me.lblImporteCoseguro = New System.Windows.Forms.Label()
        Me.lblAcargoAfiliado = New System.Windows.Forms.Label()
        Me.lblImporteBeneficiario = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(625, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteBeneficiario, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcargoAfiliado, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteCoseguro, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcargoCS, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteObraSocial, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAcargoOS, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteTotalReceta, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalReceta, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1178, 25)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblTotalReceta
        '
        Me.lblTotalReceta.AutoSize = True
        Me.lblTotalReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalReceta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalReceta.Location = New System.Drawing.Point(3, 0)
        Me.lblTotalReceta.Name = "lblTotalReceta"
        Me.lblTotalReceta.Size = New System.Drawing.Size(89, 25)
        Me.lblTotalReceta.TabIndex = 0
        Me.lblTotalReceta.Text = "Total Receta:"
        Me.lblTotalReceta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteTotalReceta
        '
        Me.lblImporteTotalReceta.AutoSize = True
        Me.lblImporteTotalReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteTotalReceta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteTotalReceta.Location = New System.Drawing.Point(98, 0)
        Me.lblImporteTotalReceta.Name = "lblImporteTotalReceta"
        Me.lblImporteTotalReceta.Size = New System.Drawing.Size(162, 25)
        Me.lblImporteTotalReceta.TabIndex = 1
        Me.lblImporteTotalReceta.Text = "$ 0,00"
        Me.lblImporteTotalReceta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAcargoOS
        '
        Me.lblAcargoOS.AutoSize = True
        Me.lblAcargoOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAcargoOS.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcargoOS.Location = New System.Drawing.Point(266, 0)
        Me.lblAcargoOS.Name = "lblAcargoOS"
        Me.lblAcargoOS.Size = New System.Drawing.Size(134, 25)
        Me.lblAcargoOS.TabIndex = 2
        Me.lblAcargoOS.Text = "Acargo Obra Social:"
        Me.lblAcargoOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteObraSocial
        '
        Me.lblImporteObraSocial.AutoSize = True
        Me.lblImporteObraSocial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteObraSocial.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteObraSocial.Location = New System.Drawing.Point(406, 0)
        Me.lblImporteObraSocial.Name = "lblImporteObraSocial"
        Me.lblImporteObraSocial.Size = New System.Drawing.Size(162, 25)
        Me.lblImporteObraSocial.TabIndex = 3
        Me.lblImporteObraSocial.Text = "$ 0,00"
        Me.lblImporteObraSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAcargoCS
        '
        Me.lblAcargoCS.AutoSize = True
        Me.lblAcargoCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAcargoCS.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcargoCS.Location = New System.Drawing.Point(574, 0)
        Me.lblAcargoCS.Name = "lblAcargoCS"
        Me.lblAcargoCS.Size = New System.Drawing.Size(124, 25)
        Me.lblAcargoCS.TabIndex = 4
        Me.lblAcargoCS.Text = "Acargo Coseguro:"
        Me.lblAcargoCS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteCoseguro
        '
        Me.lblImporteCoseguro.AutoSize = True
        Me.lblImporteCoseguro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCoseguro.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCoseguro.Location = New System.Drawing.Point(704, 0)
        Me.lblImporteCoseguro.Name = "lblImporteCoseguro"
        Me.lblImporteCoseguro.Size = New System.Drawing.Size(162, 25)
        Me.lblImporteCoseguro.TabIndex = 5
        Me.lblImporteCoseguro.Text = "$ 0,00"
        Me.lblImporteCoseguro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAcargoAfiliado
        '
        Me.lblAcargoAfiliado.AutoSize = True
        Me.lblAcargoAfiliado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAcargoAfiliado.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcargoAfiliado.Location = New System.Drawing.Point(872, 0)
        Me.lblAcargoAfiliado.Name = "lblAcargoAfiliado"
        Me.lblAcargoAfiliado.Size = New System.Drawing.Size(134, 25)
        Me.lblAcargoAfiliado.TabIndex = 6
        Me.lblAcargoAfiliado.Text = "Acargo Beneficiario:"
        Me.lblAcargoAfiliado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteBeneficiario
        '
        Me.lblImporteBeneficiario.AutoSize = True
        Me.lblImporteBeneficiario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteBeneficiario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteBeneficiario.Location = New System.Drawing.Point(1012, 0)
        Me.lblImporteBeneficiario.Name = "lblImporteBeneficiario"
        Me.lblImporteBeneficiario.Size = New System.Drawing.Size(163, 25)
        Me.lblImporteBeneficiario.TabIndex = 7
        Me.lblImporteBeneficiario.Text = "$ 0,00"
        Me.lblImporteBeneficiario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UcFooterReceta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UcFooterReceta"
        Me.Size = New System.Drawing.Size(1178, 25)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblTotalReceta As Label
    Friend WithEvents lblImporteBeneficiario As Label
    Friend WithEvents lblAcargoAfiliado As Label
    Friend WithEvents lblImporteCoseguro As Label
    Friend WithEvents lblAcargoCS As Label
    Friend WithEvents lblImporteObraSocial As Label
    Friend WithEvents lblAcargoOS As Label
    Friend WithEvents lblImporteTotalReceta As Label
End Class
