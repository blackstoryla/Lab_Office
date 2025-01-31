using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class S_Database : IData
{
    public void RecordTime(long id)
    {
        IDbConnection connection = ConnectDatabase("database");

        PushCommand(string.Format("INSERT INTO datatime (data,id) VALUES('{0}',{1});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id), connection);

        connection.Close();
    }

    public long Authorization(string login, string password) 
    {
        IDbConnection connection = ConnectDatabase("database");

        IDataReader dataReader = ReadSavedData(login, connection);

        Debug.Log("Authorization 1");

        if (dataReader == null)
        {
            connection.Close();
            return 0;
        }

        Debug.Log("Authorization 2");

        if ((string)dataReader["password"] == password)
        {
            long id = (long)dataReader["id"];
            connection.Close();

            Debug.Log("Authorization 3");

            return id;
        }

        connection.Close();
        return 0;
    }


    public void DataImportAll()
    {

    }

    public void DataImportBest()
    {

    }

    IDbConnection ConnectDatabase(string dbName)
    {
        IDbConnection connection = new SqliteConnection(string.Format("URI=file:Assets/StreamingAssets/{0}.db", dbName));
        connection.Open();

        return connection;
    }

    IDataReader ReadSavedData(string login, IDbConnection connection)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = string.Format("SELECT * FROM Authorization WHERE login = '{0}';", login);
        IDataReader dataReader = command.ExecuteReader();

        return dataReader;
    }

    void PushCommand(string commandString, IDbConnection connection)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = string.Format("{0}", commandString);
        command.ExecuteReader();
    }

}
