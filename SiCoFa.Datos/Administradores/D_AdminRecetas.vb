Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminRecetas

    Public Function ObtenerIdMensajeValidador(ByVal argValidador As String) As Long

        Try

            Using cn As MySqlConnection = (New D_Conexion).ObtenerConexion

                Using cmd As New MySqlCommand("sp_numero_mensaje_validador", cn)

                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.Add("p_Validador", MySqlDbType.VarChar).Value = argValidador

                    Dim pOut = cmd.Parameters.Add("p_NumeroMensaje", MySqlDbType.Int64)
                    pOut.Direction = ParameterDirection.Output

                    cmd.ExecuteNonQuery()

                    Return CLng(pOut.Value)

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerIdMensajeValidador), ex.Message))

        End Try

    End Function

    Friend Function InsertarReceta(ByRef argReceta As Receta, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("sp_insertar_receta", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argReceta.IdOperacion
                    .Add("p_IdOS", MySqlDbType.Int32).Value = argReceta.Plan.OS.IdOS
                    .Add("p_IdPlan", MySqlDbType.Int32).Value = argReceta.Plan.IdPlan
                    .Add("p_FechaPrescripcion", MySqlDbType.Date).Value = If(argReceta.FechaPrescripcion = Date.MinValue, DBNull.Value, argReceta.FechaPrescripcion)
                    .Add("p_NumReceta", MySqlDbType.VarChar).Value = If(String.IsNullOrEmpty(argReceta.NumReceta), DBNull.Value, argReceta.NumReceta)
                    .Add("p_CodiTDoc", MySqlDbType.VarChar).Value = If(argReceta.Documento Is Nothing, DBNull.Value, argReceta.Documento.TipoDoc.CodiTDoc)
                    .Add("p_NumDoc", MySqlDbType.VarChar).Value = If(argReceta.Documento Is Nothing, DBNull.Value, argReceta.Documento.Numero)
                    .Add("p_Credencial", MySqlDbType.VarChar).Value = If(argReceta.Credencial Is Nothing, DBNull.Value, argReceta.Credencial.Numero)
                    .Add("p_Nombre", MySqlDbType.VarChar).Value = If(argReceta.Credencial Is Nothing, DBNull.Value, argReceta.Credencial.Nombre)
                    .Add("p_CodiTMat", MySqlDbType.VarChar).Value = If(argReceta.Prescriptor Is Nothing, DBNull.Value, argReceta.Prescriptor.Matricula.CodiTMat)
                    .Add("p_CodiProv", MySqlDbType.VarChar).Value = If(argReceta.Prescriptor Is Nothing, DBNull.Value, argReceta.Prescriptor.Provincia.CodigoProvincia)
                    .Add("p_CodiTPres", MySqlDbType.VarChar).Value = If(argReceta.Prescriptor Is Nothing, DBNull.Value, argReceta.Prescriptor.TipoPrescriptor.CodiTPres)
                    .Add("p_NumMatricula", MySqlDbType.VarChar).Value = If(argReceta.Prescriptor Is Nothing, DBNull.Value, argReceta.Prescriptor.Matricula.Numero)
                    .Add("p_ImporteTotal", MySqlDbType.Decimal).Value = argReceta.ImporteTotal
                    .Add("p_ImporteOS", MySqlDbType.Decimal).Value = argReceta.ImporteOS
                    .Add("p_ImporteAf", MySqlDbType.Decimal).Value = argReceta.ImporteAf
                    .Add("p_NumAutorizacion", MySqlDbType.VarChar).Value = If(String.IsNullOrEmpty(argReceta.NumAutorizacion), DBNull.Value, argReceta.NumAutorizacion)
                    .Add("p_IdReceta", MySqlDbType.Int64)
                End With

                cmd.Parameters("p_IdReceta").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                Dim IdReceta As Long = CLng(cmd.Parameters("p_IdReceta").Value)

                If IdReceta > 0 Then
                    argReceta.IdReceta = IdReceta
                End If

            End Using

            Return True

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertReceta", Ex.Message))

        End Try

    End Function

End Class
