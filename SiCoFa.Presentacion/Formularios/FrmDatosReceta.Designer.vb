<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosReceta
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
        Me.mtxtFechaPrescripcion = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.UcTratamiento = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.SuspendLayout()
        '
        'mtxtFechaPrescripcion
        '
        Me.mtxtFechaPrescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaPrescripcion.Location = New System.Drawing.Point(271, 79)
        Me.mtxtFechaPrescripcion.Margin = New System.Windows.Forms.Padding(5, 8, 5, 8)
        Me.mtxtFechaPrescripcion.Mask = "00/00/0000"
        Me.mtxtFechaPrescripcion.Name = "mtxtFechaPrescripcion"
        Me.mtxtFechaPrescripcion.Size = New System.Drawing.Size(513, 35)
        Me.mtxtFechaPrescripcion.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 79)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 29)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Fecha Prescripción:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(42, 182)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 8, 5, 8)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(742, 605)
        Me.FlowLayoutPanel1.TabIndex = 17
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'UcTratamiento
        '
        Me.UcTratamiento.BuscarConTextoVacio = False
        Me.UcTratamiento.Descripcion = ""
        Me.UcTratamiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcTratamiento.HeaderDescripcion = "Descripción"
        Me.UcTratamiento.Id = Nothing
        Me.UcTratamiento.Location = New System.Drawing.Point(271, 128)
        Me.UcTratamiento.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.UcTratamiento.Name = "UcTratamiento"
        Me.UcTratamiento.NombrePropiedadDescripcion = Nothing
        Me.UcTratamiento.NombrePropiedadId = Nothing
        Me.UcTratamiento.Objetos = Nothing
        Me.UcTratamiento.PermitirVacio = True
        Me.UcTratamiento.Size = New System.Drawing.Size(513, 33)
        Me.UcTratamiento.SoloLectura = False
        Me.UcTratamiento.TabIndex = 16
        Me.UcTratamiento.TextoPredeterminado = ""
        Me.UcTratamiento.TituloSelector = "Selección"
        Me.UcTratamiento.ValorPredeterminado = Nothing
        '
        'FrmDatosReceta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 1061)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.UcTratamiento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mtxtFechaPrescripcion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(7)
        Me.Name = "FrmDatosReceta"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mtxtFechaPrescripcion As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents UcTratamiento As UcSelectorUniversal
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
