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

        // Llama al método para modificar la contraseña de Alberto a "1111"
        ModificarContraseña("Alberto", "1111");
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

            Debug.Log("Estado de la conexión: " + dbconn.State);

            // Aquí podrías ejecutar consultas adicionales o realizar otras operaciones
        }
        catch (Exception e)
        {
            Debug.LogError("Error al conectar a la base de datos: " + e.Message);
        }
        finally
        {
            // No es necesario cerrar la conexión aquí, se cerrará en OnDestroy
        }
    }

    void OnDestroy()
    {
        if (dbconn != null && dbconn.State != ConnectionState.Closed)
        {
            dbconn.Close();
        }
    }

    // Método para modificar la contraseña de un usuario en la tabla "juego"
    public void ModificarContraseña(string nombreUsuario, string nuevaContraseña)
    {
        try
        {
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                // Consulta de actualización
                string sqlQuery = $"UPDATE juego SET password = '{nuevaContraseña}' WHERE nombre = '{nombreUsuario}'";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteNonQuery();

                Debug.Log($"Contraseña de {nombreUsuario} modificada correctamente.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al modificar contraseña de {nombreUsuario}: " + e.Message);
        }
    }
}
