using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class myAagendaService : myAagendaIService
{

    string cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;



    public int BuscarContacto(int IdContacto)
    {
        myAgenda newAgenda = new myAgenda();
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SolicitudBase", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "S");
            cmd.Parameters.AddWithValue("@dId", IdContacto);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    newAgenda.id = rd.GetInt32(0);
                    newAgenda.estadoId = rd.GetInt32(1);
                    newAgenda.idSolicitud = rd.GetInt32(2);
                    newAgenda.productoId = rd.GetInt32(3);
                }
               
            }
            else
            {
                throw new Exception("no hay registro");
            }
            
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("error al eliminar", ex);
        }
        return newAgenda.id;
    }

    public int EditarContacto(myAgenda agenda)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SolicitudBase", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "A");
            cmd.Parameters.AddWithValue("@dId", agenda.id);
            cmd.Parameters.AddWithValue("destadoId", agenda.estadoId);
            cmd.Parameters.AddWithValue("didSolicitud", agenda.idSolicitud);
            cmd.Parameters.AddWithValue("dproductoId", agenda.productoId);


            res = cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("error al editar", ex);
        }
        return res;
    }

    public int EliminarContacto(int IdContacto)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SolicitudBase", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "E");
            cmd.Parameters.AddWithValue("@dId",IdContacto);
           


            res = cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("error al eliminar", ex);
        }
        return res;
    }

    public List<myAgenda> mostrarContactos()
    {
        List<myAgenda> lista = new List<myAgenda>();
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SolicitudBase", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "");
            cmd.Parameters.AddWithValue("@dId", "");

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lista.Add(new myAgenda{
                     id = rd.GetInt32(0),
                     estadoId = rd.GetInt32(1),
                     idSolicitud = rd.GetInt32(2),
                     productoId = rd.GetInt32(3)
                    });
          
                }

            }
            else
            {
                throw new Exception("no hay registro");
            }

            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("error al eliminar", ex);
        }
        return lista;
    }

    public int NuevoContacto(myAgenda agenda)
    {
        int res = 0;
        try
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SolicitudBase", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@operacion", "I");
            cmd.Parameters.AddWithValue("@dId", agenda.id);
            cmd.Parameters.AddWithValue("destadoId", agenda.estadoId);
            cmd.Parameters.AddWithValue("didSolicitud", agenda.idSolicitud);
            cmd.Parameters.AddWithValue("dproductoId", agenda.productoId);


            res = cmd.ExecuteNonQuery();
            cnn.Close();
        }
        catch (Exception ex)
        {

            throw new Exception("error al insertar", ex);
        }
        return res;
    }
}
