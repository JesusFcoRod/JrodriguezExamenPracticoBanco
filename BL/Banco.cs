using Microsoft.SqlServer.Server;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Banco
    {
        public static ML.Result Add(ML.Banco banco)
        {
            ML.Result resultAdd = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "[BancoAdd]";

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = banco.Nombre;

                        collection[1] = new SqlParameter("NoEmpleado", System.Data.SqlDbType.Int);
                        collection[1].Value = banco.NoEmpleados;

                        collection[2] = new SqlParameter("NoSucursales", System.Data.SqlDbType.Int);
                        collection[2].Value = banco.NoSucursales;

                        collection[3] = new SqlParameter("idPais", System.Data.SqlDbType.Int);
                        collection[3].Value = banco.Pais.idPais;

                        collection[4] = new SqlParameter("Capital", System.Data.SqlDbType.Int);
                        collection[4].Value = banco.Capital;

                        collection[5] = new SqlParameter("idRazonSocial", System.Data.SqlDbType.Int);
                        collection[5].Value = banco.RazonSocial.idRazonSocial;

                        collection[6] = new SqlParameter("NoClientes", System.Data.SqlDbType.Int);
                        collection[6].Value = banco.NoClientes;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            resultAdd.Correct = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                resultAdd.Exception = ex;
                resultAdd.Correct = false;
                resultAdd.ErrorMessage = ex.Message;
            }
            return resultAdd;

        }

        public static ML.Result Update(ML.Banco banco)
        {
            ML.Result resultUpdate = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "BancoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("idBanco", System.Data.SqlDbType.Int);
                        collection[0].Value = banco.idBanco;

                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = banco.Nombre;

                        collection[2] = new SqlParameter("NoEmpleado", System.Data.SqlDbType.Int);
                        collection[2].Value = banco.NoEmpleados;

                        collection[3] = new SqlParameter("NoSucursales", System.Data.SqlDbType.Int);
                        collection[3].Value = banco.NoSucursales;

                        collection[4] = new SqlParameter("idPais", System.Data.SqlDbType.Int);
                        collection[4].Value = banco.Pais.idPais;

                        collection[5] = new SqlParameter("Capital", System.Data.SqlDbType.Int);
                        collection[5].Value = banco.Capital;

                        collection[6] = new SqlParameter("idRazonSocial", System.Data.SqlDbType.Int);
                        collection[6].Value = banco.RazonSocial.idRazonSocial;

                        collection[7] = new SqlParameter("NoClientes", System.Data.SqlDbType.Int);
                        collection[7].Value = banco.NoClientes;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            resultUpdate.Correct = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                resultUpdate.Exception = ex;
                resultUpdate.Correct = false;
                resultUpdate.ErrorMessage = ex.Message;
            }
            return resultUpdate;
        }

        public static ML.Result Delete(int idBanco)
        {
            ML.Result resultDelete = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "BancoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("idBanco", System.Data.SqlDbType.Int);
                        collection[0].Value = idBanco;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            resultDelete.Correct = true;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                resultDelete.Exception = ex;
                resultDelete.Correct = false;
                resultDelete.ErrorMessage = ex.Message;
            }
            return resultDelete;

        }

        public static ML.Result GetAll()
        {
            ML.Result resultAll = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "BancoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        DataTable TablaBanco = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(TablaBanco);

                        if (TablaBanco.Rows.Count > 0)
                        {
                            resultAll.Objects = new List<object>();

                            foreach (DataRow row in TablaBanco.Rows)
                            {
                                ML.Banco banco = new ML.Banco();

                                banco.Nombre = row[0].ToString();
                                banco.NoEmpleados = int.Parse(row[1].ToString());
                                banco.NoSucursales = int.Parse(row[2].ToString());

                                banco.Pais = new ML.Pais();
                                banco.Pais.Nombre = row[3].ToString();
                                banco.Capital = int.Parse(row[4].ToString());

                                banco.RazonSocial = new ML.RazonSocial();
                                banco.RazonSocial.Nombre =row[5].ToString();
                                banco.NoClientes = int.Parse(row[6].ToString());

                                resultAll.Objects.Add(banco);

                            }
                            resultAll.Correct = true;
                        }
                        else
                        {
                            resultAll.Correct = false;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                resultAll.Exception = ex;
                resultAll.Correct = false;
                resultAll.ErrorMessage = ex.Message;
            }
            return resultAll;
        }
    }
}
