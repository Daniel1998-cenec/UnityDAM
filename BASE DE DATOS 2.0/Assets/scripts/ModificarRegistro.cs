using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class ModificarRegistro: MonoBehaviour
{
    string conn = "URI=file:" + Application.dataPath + "/phoneland.db";
    IDbConnection dbconn;

    void Start()
    {
        Conectar();

        // Llama al m�todo para modificar la contrase�a de Alberto a "1111"
        ModificarContrase�a("Alberto", "1111");
    }

    void Update()
    {
        // Puedes realizar operaciones adicionales en el update si es necesario
    }

    public void Conectar()
    {
        try
        {
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open();

            Debug.Log("Estado de la conexi�n: " + dbconn.State);

            // Aqu� podr�as ejecutar consultas adicionales o realizar otras operaciones
        }
        catch (Exception e)
        {
            Debug.LogError("Error al conectar a la base de datos: " + e.Message);
        }
        finally
        {
            // No es necesario cerrar la conexi�n aqu�, se cerrar� en OnDestroy
        }
    }

    void OnDestroy()
    {
        if (dbconn != null && dbconn.State != ConnectionState.Closed)
        {
            dbconn.Close();
        }
    }

    // M�todo para modificar la contrase�a de un usuario en la tabla "juego"
    public void ModificarContrase�a(string nombreUsuario, string nuevaContrase�a)
    {
        try
        {
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                // Consulta de actualizaci�n
                string sqlQuery = $"UPDATE juego SET password = '{nuevaContrase�a}' WHERE nombre = '{nombreUsuario}'";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteNonQuery();

                Debug.Log($"Contrase�a de {nombreUsuario} modificada correctamente.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al modificar contrase�a de {nombreUsuario}: " + e.Message);
        }
    }
}
