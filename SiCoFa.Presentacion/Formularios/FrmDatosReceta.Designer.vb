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
        Me.UcSelectorPlanes = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.SuspendLayout()
        '
        'mtxtFechaPrescripcion
        '
        Me.mtxtFechaPrescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaPrescripcion.Location = New System.Drawing.Point(253, 36)
        Me.mtxtFechaPrescripcion.Mask = "00/00/0000"
        Me.mtxtFechaPrescripcion.Name = "mtxtFechaPrescripcion"
        Me.mtxtFechaPrescripcion.Size = New System.Drawing.Size(500, 35)
        Me.mtxtFechaPrescripcion.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 29)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Fecha Prescripción:"
        '
        'UcSelectorPlanes
        '
        Me.UcSelectorPlanes.BuscarConTextoVacio = False
        Me.UcSelectorPlanes.Descripcion = ""
        Me.UcSelectorPlanes.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSelectorPlanes.HeaderDescripcion = "Descripción"
        Me.UcSelectorPlanes.Id = Nothing
        Me.UcSelectorPlanes.Location = New System.Drawing.Point(253, 79)
        Me.UcSelectorPlanes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcSelectorPlanes.Name = "UcSelectorPlanes"
        Me.UcSelectorPlanes.NombrePropiedadDescripcion = Nothing
        Me.UcSelectorPlanes.NombrePropiedadId = Nothing
        Me.UcSelectorPlanes.Objetos = Nothing
        Me.UcSelectorPlanes.PermitirVacio = True
        Me.UcSelectorPlanes.Size = New System.Drawing.Size(500, 49)
        Me.UcSelectorPlanes.SoloLectura = False
        Me.UcSelectorPlanes.TabIndex = 16
        Me.UcSelectorPlanes.TextoPredeterminado = ""
        Me.UcSelectorPlanes.TituloSelector = "Selección"
        Me.UcSelectorPlanes.ValorPredeterminado = Nothing
        '
        'FrmDatosReceta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 480)
        Me.Controls.Add(Me.UcSelectorPlanes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mtxtFechaPrescripcion)
        Me.Name = "FrmDatosReceta"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mtxtFechaPrescripcion As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents UcSelectorPlanes As UcSelectorUniversal
End Class
