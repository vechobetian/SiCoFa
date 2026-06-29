<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcReceta
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblValidacion = New System.Windows.Forms.Label()
        Me.lblValidacionEtiqueta = New System.Windows.Forms.Label()
        Me.lblPlanOS = New System.Windows.Forms.Label()
        Me.lblIdReceta = New System.Windows.Forms.Label()
        Me.lblIdRecetaEtiqueta = New System.Windows.Forms.Label()
        Me.lblPlanOSEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteAfEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteCSEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteOSEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteAF = New System.Windows.Forms.Label()
        Me.lblImporteCS = New System.Windows.Forms.Label()
        Me.lblImporteOS = New System.Windows.Forms.Label()
        Me.lblTotalRecetaEtiqueta = New System.Windows.Forms.Label()
        Me.lblTotalReceta = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalReceta, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalRecetaEtiqueta, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblValidacion, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblValidacionEtiqueta, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlanOS, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdReceta, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdRecetaEtiqueta, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlanOSEtiqueta, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteAfEtiqueta, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteCSEtiqueta, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteOSEtiqueta, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteAF, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteCS, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteOS, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(307, 148)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'lblValidacion
        '
        Me.lblValidacion.AutoSize = True
        Me.lblValidacion.BackColor = System.Drawing.SystemColors.Window
        Me.lblValidacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblValidacion.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidacion.Location = New System.Drawing.Point(96, 43)
        Me.lblValidacion.Margin = New System.Windows.Forms.Padding(0)
        Me.lblValidacion.Name = "lblValidacion"
        Me.lblValidacion.Size = New System.Drawing.Size(208, 17)
        Me.lblValidacion.TabIndex = 14
        Me.lblValidacion.Text = "        "
        Me.lblValidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidacionEtiqueta
        '
        Me.lblValidacionEtiqueta.AutoSize = True
        Me.lblValidacionEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblValidacionEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblValidacionEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidacionEtiqueta.Location = New System.Drawing.Point(3, 43)
        Me.lblValidacionEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblValidacionEtiqueta.Name = "lblValidacionEtiqueta"
        Me.lblValidacionEtiqueta.Size = New System.Drawing.Size(90, 17)
        Me.lblValidacionEtiqueta.TabIndex = 13
        Me.lblValidacionEtiqueta.Text = "Validacion:"
        '
        'lblPlanOS
        '
        Me.lblPlanOS.AutoSize = True
        Me.lblPlanOS.BackColor = System.Drawing.SystemColors.Window
        Me.lblPlanOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPlanOS.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanOS.Location = New System.Drawing.Point(96, 23)
        Me.lblPlanOS.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPlanOS.Name = "lblPlanOS"
        Me.lblPlanOS.Size = New System.Drawing.Size(208, 17)
        Me.lblPlanOS.TabIndex = 8
        Me.lblPlanOS.Text = "         "
        Me.lblPlanOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdReceta
        '
        Me.lblIdReceta.AutoSize = True
        Me.lblIdReceta.BackColor = System.Drawing.SystemColors.Window
        Me.lblIdReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIdReceta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdReceta.Location = New System.Drawing.Point(96, 3)
        Me.lblIdReceta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdReceta.Name = "lblIdReceta"
        Me.lblIdReceta.Size = New System.Drawing.Size(208, 17)
        Me.lblIdReceta.TabIndex = 7
        Me.lblIdReceta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdRecetaEtiqueta
        '
        Me.lblIdRecetaEtiqueta.AutoSize = True
        Me.lblIdRecetaEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblIdRecetaEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIdRecetaEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRecetaEtiqueta.Location = New System.Drawing.Point(3, 3)
        Me.lblIdRecetaEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdRecetaEtiqueta.Name = "lblIdRecetaEtiqueta"
        Me.lblIdRecetaEtiqueta.Size = New System.Drawing.Size(90, 17)
        Me.lblIdRecetaEtiqueta.TabIndex = 6
        Me.lblIdRecetaEtiqueta.Text = "IdReceta:"
        '
        'lblPlanOSEtiqueta
        '
        Me.lblPlanOSEtiqueta.AutoSize = True
        Me.lblPlanOSEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblPlanOSEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPlanOSEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanOSEtiqueta.Location = New System.Drawing.Point(3, 23)
        Me.lblPlanOSEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPlanOSEtiqueta.Name = "lblPlanOSEtiqueta"
        Me.lblPlanOSEtiqueta.Size = New System.Drawing.Size(90, 17)
        Me.lblPlanOSEtiqueta.TabIndex = 2
        Me.lblPlanOSEtiqueta.Text = "O.S. Plan:"
        '
        'lblImporteAfEtiqueta
        '
        Me.lblImporteAfEtiqueta.AutoSize = True
        Me.lblImporteAfEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteAfEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteAfEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteAfEtiqueta.Location = New System.Drawing.Point(3, 126)
        Me.lblImporteAfEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteAfEtiqueta.Name = "lblImporteAfEtiqueta"
        Me.lblImporteAfEtiqueta.Size = New System.Drawing.Size(90, 19)
        Me.lblImporteAfEtiqueta.TabIndex = 12
        Me.lblImporteAfEtiqueta.Text = "Importe AF:"
        '
        'lblImporteCSEtiqueta
        '
        Me.lblImporteCSEtiqueta.AutoSize = True
        Me.lblImporteCSEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteCSEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCSEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCSEtiqueta.Location = New System.Drawing.Point(3, 106)
        Me.lblImporteCSEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteCSEtiqueta.Name = "lblImporteCSEtiqueta"
        Me.lblImporteCSEtiqueta.Size = New System.Drawing.Size(90, 17)
        Me.lblImporteCSEtiqueta.TabIndex = 4
        Me.lblImporteCSEtiqueta.Text = "Importe CS:"
        '
        'lblImporteOSEtiqueta
        '
        Me.lblImporteOSEtiqueta.AutoSize = True
        Me.lblImporteOSEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteOSEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOSEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOSEtiqueta.Location = New System.Drawing.Point(3, 86)
        Me.lblImporteOSEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteOSEtiqueta.Name = "lblImporteOSEtiqueta"
        Me.lblImporteOSEtiqueta.Size = New System.Drawing.Size(90, 17)
        Me.lblImporteOSEtiqueta.TabIndex = 3
        Me.lblImporteOSEtiqueta.Text = "Importe OS:"
        '
        'lblImporteAF
        '
        Me.lblImporteAF.AutoSize = True
        Me.lblImporteAF.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteAF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteAF.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteAF.Location = New System.Drawing.Point(96, 126)
        Me.lblImporteAF.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteAF.Name = "lblImporteAF"
        Me.lblImporteAF.Size = New System.Drawing.Size(208, 19)
        Me.lblImporteAF.TabIndex = 11
        Me.lblImporteAF.Text = "$ 0,00"
        Me.lblImporteAF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteCS
        '
        Me.lblImporteCS.AutoSize = True
        Me.lblImporteCS.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCS.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCS.Location = New System.Drawing.Point(96, 106)
        Me.lblImporteCS.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteCS.Name = "lblImporteCS"
        Me.lblImporteCS.Size = New System.Drawing.Size(208, 17)
        Me.lblImporteCS.TabIndex = 10
        Me.lblImporteCS.Text = "$ 0,00"
        Me.lblImporteCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteOS
        '
        Me.lblImporteOS.AutoSize = True
        Me.lblImporteOS.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOS.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOS.Location = New System.Drawing.Point(96, 86)
        Me.lblImporteOS.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteOS.Name = "lblImporteOS"
        Me.lblImporteOS.Size = New System.Drawing.Size(208, 17)
        Me.lblImporteOS.TabIndex = 9
        Me.lblImporteOS.Text = "$ 0,00"
        Me.lblImporteOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalRecetaEtiqueta
        '
        Me.lblTotalRecetaEtiqueta.AutoSize = True
        Me.lblTotalRecetaEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblTotalRecetaEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalRecetaEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRecetaEtiqueta.Location = New System.Drawing.Point(3, 63)
        Me.lblTotalRecetaEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalRecetaEtiqueta.Name = "lblTotalRecetaEtiqueta"
        Me.lblTotalRecetaEtiqueta.Size = New System.Drawing.Size(90, 20)
        Me.lblTotalRecetaEtiqueta.TabIndex = 15
        Me.lblTotalRecetaEtiqueta.Text = "Total Receta:"
        '
        'lblTotalReceta
        '
        Me.lblTotalReceta.AutoSize = True
        Me.lblTotalReceta.BackColor = System.Drawing.SystemColors.Window
        Me.lblTotalReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalReceta.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalReceta.Location = New System.Drawing.Point(96, 63)
        Me.lblTotalReceta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTotalReceta.Name = "lblTotalReceta"
        Me.lblTotalReceta.Size = New System.Drawing.Size(208, 20)
        Me.lblTotalReceta.TabIndex = 16
        Me.lblTotalReceta.Text = "$ 0,00"
        Me.lblTotalReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UcReceta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UcReceta"
        Me.Size = New System.Drawing.Size(307, 148)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblImporteAF As Label
    Friend WithEvents lblImporteCS As Label
    Friend WithEvents lblImporteOS As Label
    Friend WithEvents lblPlanOS As Label
    Friend WithEvents lblIdReceta As Label
    Friend WithEvents lblIdRecetaEtiqueta As Label
    Friend WithEvents lblPlanOSEtiqueta As Label
    Friend WithEvents lblImporteOSEtiqueta As Label
    Friend WithEvents lblImporteCSEtiqueta As Label
    Friend WithEvents lblValidacionEtiqueta As Label
    Friend WithEvents lblImporteAfEtiqueta As Label
    Friend WithEvents lblValidacion As Label
    Friend WithEvents lblTotalReceta As Label
    Friend WithEvents lblTotalRecetaEtiqueta As Label
End Class
