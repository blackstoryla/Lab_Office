using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData
{
    /// <summary>
    /// Записать время
    /// </summary>
    /// <param name="time">Время сборки автомата</param>
    public void RecordTime(long id);

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="login">Логин</param>
    /// <param name="password">Пароль</param>
    /// <returns>ID Пользователя, если правильные логин и пароль. Иначе 0.</returns>
    public long Authorization(string login, string password);

    /// <summary>
    /// Создание txt файла со всеми прохождениями экзамена
    /// </summary>
    public void DataImportAll();

    /// <summary>
    /// Создание txt файла с лучшими прохождениями экзамена
    /// </summary>
    public void DataImportBest();


}
