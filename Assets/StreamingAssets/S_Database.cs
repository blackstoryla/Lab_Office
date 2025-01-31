using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class S_Database : MonoBehaviour, IData
{
    public void RecordTime( int id)
    {
        IDbConnection connection = ConnectDatabase("database");

        PushCommand(string.Format("INSERT INTO datatime (data,id) VALUES('{0}',{1});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id), connection);

        connection.Close();
    }

    public int Authorization(string login, string password) 
    {
        IDbConnection connection = ConnectDatabase("database");

        IDataReader dataReader = ReadSavedData();

        connection.Close();

        if (dataReader == null) 
            return 0;

        if (dataReader[password] == password) 
            return dataReader[id];

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

    IDataReader ReadSavedData(string login)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = string.Format("SELECT * FROM Coordinates WHERE login = '{0}';", login);
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
