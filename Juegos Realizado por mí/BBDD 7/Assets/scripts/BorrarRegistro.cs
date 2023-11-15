using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BorrarRegistro : MonoBehaviour
{
    public int numeroIdEliminar;
    private InsertarDatos insertarDatos;
    string conn = "URI=file:" + Application.dataPath + "/phoneland.db";
    IDbConnection dbconn;

    void Start()
    {
        insertarDatos=GameObject.Find("insertar datos").GetComponent<InsertarDatos>();
        insertarDatos.Conectar();

        // Llama al método para insertar un nuevo registro
        BorrarDatos(numeroIdEliminar);
    }

    void Update()
    {
        // Puedes realizar operaciones adicionales en el update si es necesario
    }

    void OnDestroy()
    {
        if (dbconn != null && dbconn.State != ConnectionState.Closed)
        {
            dbconn.Close();
        }
    }

    // Método para insertar un nuevo registro en la tabla "juego"
    public void BorrarDatos(int id)
    {
        try
        {
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                // Consulta de inserción
                string sqlDelete = "DELETE FROM juego WHERE id = "+id;
                dbcmd.CommandText = sqlDelete;
                dbcmd.ExecuteNonQuery();

                Debug.Log("Registro Eliminado");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al eliminar registro: " + e.Message);
        }
    }
}
