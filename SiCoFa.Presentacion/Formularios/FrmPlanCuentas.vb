Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmPlanCuentas
    Private mobj_AdminPlanCuentas As New N_AdminPlanCuentas
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nodo_raiz As TreeNode
        nodo_raiz = Me.TreeView1.Nodes.Add(0, "Rubros Contables")

        For Each r As RubroContabilidad In mobj_AdminPlanCuentas.Rubros
            Dim nodo_segundo_nivel As TreeNode = Me.TreeView1.Nodes(0).Nodes.Add(r.CodiRub, r.NombreRub)
            Call CargarSubRubros(r.CodiRub, nodo_segundo_nivel)
        Next
        nodo_raiz.Expand()
    End Sub
    Private Sub CargarSubRubros(ByVal argCodiRub As String, ByVal n As TreeNode)
        For Each sr As SubRubroContabilidad In mobj_AdminPlanCuentas.SubRubros(argCodiRub)
            Dim nodo_tercer_nivel As TreeNode = n.Nodes.Add(sr.CodiSubRub, sr.CodiSubRub & " - " & sr.NombreSubRubro)
            Call CargarCuentasColectivas(sr.CodiSubRub, nodo_tercer_nivel)
        Next
    End Sub
    Private Sub CargarCuentasColectivas(ByVal argCodiSubRub As String, ByVal n As TreeNode)
        For Each cc As CuentaColectiva In mobj_AdminPlanCuentas.CuentasColectivas(argCodiSubRub)
            Dim nodo_cuarto_nivel As TreeNode = n.Nodes.Add(cc.CodiCtaCol, cc.CodiCtaCol & " - " & cc.NombreCtaCol)
            Call CargarCuentasImputables(cc.CodiCtaCol, nodo_cuarto_nivel)
        Next
    End Sub
    Private Sub CargarCuentasImputables(ByVal argCodiCtaCol As String, ByVal n As TreeNode)
        For Each ci As CuentaImputable In mobj_AdminPlanCuentas.CuentasImputables(argCodiCtaCol)
            n.Nodes.Add(ci.CodiCta, ci.CodiCta & " - " & ci.NombreCta)
        Next
    End Sub
End Class