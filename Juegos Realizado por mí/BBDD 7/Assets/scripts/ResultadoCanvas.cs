using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;

public class ResultadoCanvas : MonoBehaviour
{
    string conn = "URI=file:" + Application.dataPath + "/phoneland.db";
    IDbConnection dbconn;

    // Referencia al componente TextMeshPro
    public TextMeshPro textMesh;

    void Start()
    {
        Conectar();

        // Llama al método para mostrar registros en el TextMesh
        MostrarRegistrosEnTextMesh();
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
        }
        catch (Exception e)
        {
            Debug.LogError("Error al conectar a la base de datos: " + e.Message);
        }
    }

    void OnDestroy()
    {
        if (dbconn != null && dbconn.State != ConnectionState.Closed)
        {
            dbconn.Close();
        }
    }

    public void MostrarRegistrosEnTextMesh()
    {
        try
        {
            // Utilizando una conexión de base de datos
            using (IDbCommand dbcmd = dbconn.CreateCommand())
            {
                // Definir la consulta SQL para seleccionar datos de la tabla "juego"
                string sqlQuery = "SELECT id, nombre, password FROM juego";
                dbcmd.CommandText = sqlQuery;

                // Ejecutar la consulta y obtener un lector de datos
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    // Construir una cadena con los resultados de la consulta
                    string registros = "Registros de la tabla juego:\n";

                    // Iterar a través de los resultados y obtener valores de columnas
                    while (reader.Read())
                    {
                        // Obtener valores de las columnas por índice
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string password = reader.GetString(2);

                        // Concatenar los valores en la cadena de registros
                        registros += $"ID: {id}, Nombre: {nombre}, Password: {password}\n";
                    }

                    // Actualizar el componente TextMeshPro con la cadena construida
                    textMesh.text = registros;

                    // Imprimir un mensaje de registro en la consola
                    Debug.Log("Registros de la tabla juego mostrados en TextMeshPro.");
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al mostrar registros en TextMeshPro: " + e.Message);
        }
    }
}
