using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData
{
    /// <summary>
    /// �������� �����
    /// </summary>
    /// <param name="time">����� ������ ��������</param>
    public void RecordTime(long id);

    /// <summary>
    /// ����������� ������������
    /// </summary>
    /// <param name="login">�����</param>
    /// <param name="password">������</param>
    /// <returns>ID ������������, ���� ���������� ����� � ������. ����� 0.</returns>
    public long Authorization(string login, string password);

    /// <summary>
    /// �������� txt ����� �� ����� ������������� ��������
    /// </summary>
    public void DataImportAll();

    /// <summary>
    /// �������� txt ����� � ������� ������������� ��������
    /// </summary>
    public void DataImportBest();


}
