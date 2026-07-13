<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelectorPlanesOS
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
        Me.UcSelectorPlanes = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'UcSelectorPlanes
        '
        Me.UcSelectorPlanes.BuscarConTextoVacio = False
        Me.UcSelectorPlanes.Descripcion = ""
        Me.UcSelectorPlanes.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UcSelectorPlanes.HeaderDescripcion = "Descripción"
        Me.UcSelectorPlanes.Id = Nothing
        Me.UcSelectorPlanes.Location = New System.Drawing.Point(9, 32)
        Me.UcSelectorPlanes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcSelectorPlanes.Name = "UcSelectorPlanes"
        Me.UcSelectorPlanes.NombrePropiedadDescripcion = Nothing
        Me.UcSelectorPlanes.NombrePropiedadId = Nothing
        Me.UcSelectorPlanes.Objetos = Nothing
        Me.UcSelectorPlanes.PermitirVacio = True
        Me.UcSelectorPlanes.Size = New System.Drawing.Size(500, 49)
        Me.UcSelectorPlanes.SoloLectura = False
        Me.UcSelectorPlanes.TabIndex = 0
        Me.UcSelectorPlanes.TextoPredeterminado = ""
        Me.UcSelectorPlanes.TituloSelector = "Selección"
        Me.UcSelectorPlanes.ValorPredeterminado = Nothing
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Location = New System.Drawing.Point(12, 9)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(235, 16)
        Me.lblMensaje.TabIndex = 1
        Me.lblMensaje.Text = "Seleccione un plan con Texto o IdPlan"
        '
        'FrmSelectorPlanesOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(519, 92)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.UcSelectorPlanes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelectorPlanesOS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UcSelectorPlanes As UcSelectorUniversal
    Friend WithEvents lblMensaje As Label
End Class
