<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCliente
    'Inherits System.Windows.Forms.Form
    Inherits FrmEdicionRegistro

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
        Me.IdCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.Domicilio = New System.Windows.Forms.TextBox()
        Me.Localidad = New System.Windows.Forms.TextBox()
        Me.Provincia = New System.Windows.Forms.TextBox()
        Me.Telefono = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.NumDoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TipoDoc = New System.Windows.Forms.ComboBox()
        Me.IVA = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'IdCliente
        '
        Me.IdCliente.Enabled = False
        Me.IdCliente.Location = New System.Drawing.Point(91, 37)
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Size = New System.Drawing.Size(300, 20)
        Me.IdCliente.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre:"
        '
        'Nombre
        '
        Me.Nombre.Location = New System.Drawing.Point(91, 63)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(300, 20)
        Me.Nombre.TabIndex = 1
        '
        'Domicilio
        '
        Me.Domicilio.Location = New System.Drawing.Point(91, 89)
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.Size = New System.Drawing.Size(300, 20)
        Me.Domicilio.TabIndex = 2
        '
        'Localidad
        '
        Me.Localidad.Location = New System.Drawing.Point(91, 115)
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Size = New System.Drawing.Size(300, 20)
        Me.Localidad.TabIndex = 4
        '
        'Provincia
        '
        Me.Provincia.Location = New System.Drawing.Point(91, 141)
        Me.Provincia.Name = "Provincia"
        Me.Provincia.Size = New System.Drawing.Size(300, 20)
        Me.Provincia.TabIndex = 5
        '
        'Telefono
        '
        Me.Telefono.Location = New System.Drawing.Point(91, 167)
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Size = New System.Drawing.Size(300, 20)
        Me.Telefono.TabIndex = 6
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(91, 193)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(300, 20)
        Me.Email.TabIndex = 8
        '
        'NumDoc
        '
        Me.NumDoc.Location = New System.Drawing.Point(91, 245)
        Me.NumDoc.Name = "NumDoc"
        Me.NumDoc.Size = New System.Drawing.Size(300, 20)
        Me.NumDoc.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "IdCliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Domicilio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Localidad:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Provincia:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Teléfono:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Email:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 222)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Tipo Doc:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Num.Doc:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 274)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "IVA:"
        '
        'TipoDoc
        '
        Me.TipoDoc.FormattingEnabled = True
        Me.TipoDoc.ItemHeight = 13
        Me.TipoDoc.Location = New System.Drawing.Point(91, 219)
        Me.TipoDoc.Name = "TipoDoc"
        Me.TipoDoc.Size = New System.Drawing.Size(300, 21)
        Me.TipoDoc.TabIndex = 9
        '
        'IVA
        '
        Me.IVA.FormattingEnabled = True
        Me.IVA.ItemHeight = 13
        Me.IVA.Location = New System.Drawing.Point(91, 271)
        Me.IVA.Name = "IVA"
        Me.IVA.Size = New System.Drawing.Size(300, 21)
        Me.IVA.TabIndex = 11
        '
        'FrmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 304)
        Me.Controls.Add(Me.IVA)
        Me.Controls.Add(Me.TipoDoc)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumDoc)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.Telefono)
        Me.Controls.Add(Me.Provincia)
        Me.Controls.Add(Me.Localidad)
        Me.Controls.Add(Me.Domicilio)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IdCliente)
        Me.KeyPreview = True
        Me.Name = "FrmCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
        Me.Controls.SetChildIndex(Me.IdCliente, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Nombre, 0)
        Me.Controls.SetChildIndex(Me.Domicilio, 0)
        Me.Controls.SetChildIndex(Me.Localidad, 0)
        Me.Controls.SetChildIndex(Me.Provincia, 0)
        Me.Controls.SetChildIndex(Me.Telefono, 0)
        Me.Controls.SetChildIndex(Me.Email, 0)
        Me.Controls.SetChildIndex(Me.NumDoc, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.TipoDoc, 0)
        Me.Controls.SetChildIndex(Me.IVA, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents IdCliente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Nombre As TextBox
    Friend WithEvents Domicilio As TextBox
    Friend WithEvents Localidad As TextBox
    Friend WithEvents Provincia As TextBox
    Friend WithEvents Telefono As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents NumDoc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TipoDoc As ComboBox
    Friend WithEvents IVA As ComboBox
End Class
