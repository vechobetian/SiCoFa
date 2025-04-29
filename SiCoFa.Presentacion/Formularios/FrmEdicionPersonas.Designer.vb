<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEdicionPersonas
    'Inherits System.Windows.Forms.Form
    Inherits clsFrmBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEdicionPersonas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.TipoDoc = New System.Windows.Forms.ComboBox()
        Me.NumDoc = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Telefono = New System.Windows.Forms.TextBox()
        Me.Provincia = New System.Windows.Forms.TextBox()
        Me.Localidad = New System.Windows.Forms.TextBox()
        Me.Domicilio = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.Id = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.FechaAlta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Estado = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Nuevo, Me.Buscar, Me.Limpiar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(394, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Guardar
        '
        Me.Guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Guardar.Image = CType(resources.GetObject("Guardar.Image"), System.Drawing.Image)
        Me.Guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(23, 22)
        Me.Guardar.Text = "Guardar Cambios"
        '
        'Nuevo
        '
        Me.Nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Nuevo.Image = CType(resources.GetObject("Nuevo.Image"), System.Drawing.Image)
        Me.Nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(23, 22)
        Me.Nuevo.Text = "Nuevo"
        '
        'Buscar
        '
        Me.Buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Buscar.Image = CType(resources.GetObject("Buscar.Image"), System.Drawing.Image)
        Me.Buscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(23, 22)
        Me.Buscar.Text = "Buscar"
        '
        'Limpiar
        '
        Me.Limpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Limpiar.Image = CType(resources.GetObject("Limpiar.Image"), System.Drawing.Image)
        Me.Limpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(23, 22)
        Me.Limpiar.Text = "Limpiar"
        '
        'TipoDoc
        '
        Me.TipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoDoc.FormattingEnabled = True
        Me.TipoDoc.ItemHeight = 13
        Me.TipoDoc.Location = New System.Drawing.Point(79, 220)
        Me.TipoDoc.Name = "TipoDoc"
        Me.TipoDoc.Size = New System.Drawing.Size(300, 21)
        Me.TipoDoc.TabIndex = 8
        '
        'NumDoc
        '
        Me.NumDoc.Location = New System.Drawing.Point(79, 246)
        Me.NumDoc.Name = "NumDoc"
        Me.NumDoc.Size = New System.Drawing.Size(300, 20)
        Me.NumDoc.TabIndex = 9
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(79, 194)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(300, 20)
        Me.Email.TabIndex = 7
        '
        'Telefono
        '
        Me.Telefono.Location = New System.Drawing.Point(79, 168)
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Size = New System.Drawing.Size(300, 20)
        Me.Telefono.TabIndex = 6
        '
        'Provincia
        '
        Me.Provincia.Location = New System.Drawing.Point(79, 142)
        Me.Provincia.Name = "Provincia"
        Me.Provincia.Size = New System.Drawing.Size(300, 20)
        Me.Provincia.TabIndex = 5
        '
        'Localidad
        '
        Me.Localidad.Location = New System.Drawing.Point(79, 116)
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Size = New System.Drawing.Size(300, 20)
        Me.Localidad.TabIndex = 4
        '
        'Domicilio
        '
        Me.Domicilio.Location = New System.Drawing.Point(79, 90)
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.Size = New System.Drawing.Size(300, 20)
        Me.Domicilio.TabIndex = 3
        '
        'Nombre
        '
        Me.Nombre.Location = New System.Drawing.Point(79, 64)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(300, 20)
        Me.Nombre.TabIndex = 2
        '
        'Id
        '
        Me.Id.Enabled = False
        Me.Id.Location = New System.Drawing.Point(79, 38)
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Size = New System.Drawing.Size(300, 20)
        Me.Id.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 249)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Num.Doc:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Tipo Doc:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Email:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Teléfono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Provincia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Localidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Domicilio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Id:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 275)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Fecha Alta:"
        '
        'FechaAlta
        '
        Me.FechaAlta.Location = New System.Drawing.Point(79, 272)
        Me.FechaAlta.Name = "FechaAlta"
        Me.FechaAlta.Size = New System.Drawing.Size(300, 20)
        Me.FechaAlta.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 301)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Estado:"
        '
        'Estado
        '
        Me.Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Estado.FormattingEnabled = True
        Me.Estado.ItemHeight = 13
        Me.Estado.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.Estado.Location = New System.Drawing.Point(79, 298)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(300, 21)
        Me.Estado.TabIndex = 11
        '
        'FrmEdicionPersonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 331)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.FechaAlta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TipoDoc)
        Me.Controls.Add(Me.NumDoc)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.Telefono)
        Me.Controls.Add(Me.Provincia)
        Me.Controls.Add(Me.Localidad)
        Me.Controls.Add(Me.Domicilio)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.Id)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmEdicionPersonas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents TipoDoc As ComboBox
    Friend WithEvents NumDoc As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Telefono As TextBox
    Friend WithEvents Provincia As TextBox
    Friend WithEvents Localidad As TextBox
    Friend WithEvents Domicilio As TextBox
    Friend WithEvents Nombre As TextBox
    Friend WithEvents Id As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents FechaAlta As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Estado As ComboBox
End Class
