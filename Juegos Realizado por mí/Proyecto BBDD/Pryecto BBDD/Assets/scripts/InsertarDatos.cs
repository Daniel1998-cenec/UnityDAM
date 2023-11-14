using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;


public class InsertarDatos : MonoBehaviour
{
    string conn = "URI=file:" + Application.dataPath + "/phoneland.db";
    IDbConnection dbconn;

    void Start()
    {
        Conectar();

        // Llama al método para insertar un nuevo registro
        InsertarNuevoRegistro(3, "Isa", "2225");
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

    // Método para insertar un nuevo registro en la tabla "juego"
    public void InsertarNuevoRegistro(int id, string nombre, string password)
    {
        try
        {
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                // Consulta de inserción
                string sqlQuery = $"INSERT INTO juego (id, nombre, password) VALUES ({id}, '{nombre}', '{password}')";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteNonQuery();

                Debug.Log("Nuevo registro insertado correctamente.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al insertar nuevo registro: " + e.Message);
        }
    }
}