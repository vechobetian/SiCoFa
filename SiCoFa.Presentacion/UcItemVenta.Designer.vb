<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcItemVenta
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtImporteConDescuento = New System.Windows.Forms.TextBox()
        Me.txtImporteDescuento = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeDescuento = New System.Windows.Forms.TextBox()
        Me.txtImporteSinDescuento = New System.Windows.Forms.TextBox()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.txtAlicIVA = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodBarra = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtImporteConDescuento, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtImporteDescuento, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPorcentajeDescuento, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtImporteSinDescuento, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPrecioUnitario, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAlicIVA, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCantidad, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDescripcion, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodBarra, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1178, 25)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtImporteConDescuento
        '
        Me.txtImporteConDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImporteConDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtImporteConDescuento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteConDescuento.Location = New System.Drawing.Point(1081, 3)
        Me.txtImporteConDescuento.Name = "txtImporteConDescuento"
        Me.txtImporteConDescuento.Size = New System.Drawing.Size(94, 18)
        Me.txtImporteConDescuento.TabIndex = 8
        Me.txtImporteConDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteDescuento
        '
        Me.txtImporteDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImporteDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtImporteDescuento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteDescuento.Location = New System.Drawing.Point(981, 3)
        Me.txtImporteDescuento.Name = "txtImporteDescuento"
        Me.txtImporteDescuento.Size = New System.Drawing.Size(94, 18)
        Me.txtImporteDescuento.TabIndex = 7
        Me.txtImporteDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcentajeDescuento
        '
        Me.txtPorcentajeDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPorcentajeDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPorcentajeDescuento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentajeDescuento.Location = New System.Drawing.Point(931, 3)
        Me.txtPorcentajeDescuento.Name = "txtPorcentajeDescuento"
        Me.txtPorcentajeDescuento.Size = New System.Drawing.Size(44, 18)
        Me.txtPorcentajeDescuento.TabIndex = 6
        Me.txtPorcentajeDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtImporteSinDescuento
        '
        Me.txtImporteSinDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtImporteSinDescuento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtImporteSinDescuento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteSinDescuento.Location = New System.Drawing.Point(831, 3)
        Me.txtImporteSinDescuento.Name = "txtImporteSinDescuento"
        Me.txtImporteSinDescuento.Size = New System.Drawing.Size(94, 18)
        Me.txtImporteSinDescuento.TabIndex = 5
        Me.txtImporteSinDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPrecioUnitario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPrecioUnitario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(731, 3)
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(94, 18)
        Me.txtPrecioUnitario.TabIndex = 4
        Me.txtPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAlicIVA
        '
        Me.txtAlicIVA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAlicIVA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAlicIVA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlicIVA.Location = New System.Drawing.Point(681, 3)
        Me.txtAlicIVA.Name = "txtAlicIVA"
        Me.txtAlicIVA.Size = New System.Drawing.Size(44, 18)
        Me.txtAlicIVA.TabIndex = 3
        Me.txtAlicIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidad
        '
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCantidad.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(641, 3)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(34, 18)
        Me.txtCantidad.TabIndex = 2
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(103, 3)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(532, 18)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtCodBarra
        '
        Me.txtCodBarra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCodBarra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodBarra.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarra.Location = New System.Drawing.Point(3, 3)
        Me.txtCodBarra.Name = "txtCodBarra"
        Me.txtCodBarra.Size = New System.Drawing.Size(94, 18)
        Me.txtCodBarra.TabIndex = 0
        '
        'UcItemVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UcItemVenta"
        Me.Size = New System.Drawing.Size(1178, 25)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtCodBarra As TextBox
    Friend WithEvents txtImporteConDescuento As TextBox
    Friend WithEvents txtImporteDescuento As TextBox
    Friend WithEvents txtPorcentajeDescuento As TextBox
    Friend WithEvents txtImporteSinDescuento As TextBox
    Friend WithEvents txtPrecioUnitario As TextBox
    Friend WithEvents txtAlicIVA As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtDescripcion As TextBox
End Class
