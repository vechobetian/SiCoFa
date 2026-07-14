<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosReceta
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.mtxtFechaPrescripcion = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UcTratamiento = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 94)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 8, 5, 8)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(775, 323)
        Me.FlowLayoutPanel1.TabIndex = 17
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'mtxtFechaPrescripcion
        '
        Me.mtxtFechaPrescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtxtFechaPrescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaPrescripcion.Location = New System.Drawing.Point(262, 17)
        Me.mtxtFechaPrescripcion.Margin = New System.Windows.Forms.Padding(5, 8, 5, 8)
        Me.mtxtFechaPrescripcion.Mask = "00/00/0000"
        Me.mtxtFechaPrescripcion.Name = "mtxtFechaPrescripcion"
        Me.mtxtFechaPrescripcion.Size = New System.Drawing.Size(500, 35)
        Me.mtxtFechaPrescripcion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 30)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Fecha Prescripción:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UcTratamiento
        '
        Me.UcTratamiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcTratamiento.BuscarConTextoVacio = False
        Me.UcTratamiento.Descripcion = ""
        Me.UcTratamiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcTratamiento.HeaderDescripcion = "Descripción"
        Me.UcTratamiento.Id = Nothing
        Me.UcTratamiento.Location = New System.Drawing.Point(262, 58)
        Me.UcTratamiento.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.UcTratamiento.Name = "UcTratamiento"
        Me.UcTratamiento.NombrePropiedadDescripcion = Nothing
        Me.UcTratamiento.NombrePropiedadId = Nothing
        Me.UcTratamiento.Objetos = Nothing
        Me.UcTratamiento.PermitirVacio = True
        Me.UcTratamiento.Size = New System.Drawing.Size(500, 35)
        Me.UcTratamiento.SoloLectura = False
        Me.UcTratamiento.TabIndex = 2
        Me.UcTratamiento.TextoPredeterminado = ""
        Me.UcTratamiento.TituloSelector = "Selección"
        Me.UcTratamiento.ValorPredeterminado = Nothing
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 30)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Tratamiento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmDatosReceta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 418)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.mtxtFechaPrescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.UcTratamiento)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(7)
        Me.Name = "FrmDatosReceta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UcTratamiento As UcSelectorUniversal
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents mtxtFechaPrescripcion As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
