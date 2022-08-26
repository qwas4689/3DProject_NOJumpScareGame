using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class TextCsvRecord
{
    public float Pictures { get; set; }
    public float FollowZombie { get; set; }
    public float LayingZombie { get; set; }
}

public class CsvCoolTime : MonoBehaviour
{
    public float pictures;
    public float followZombies;
    public float layingZombies;

    void Awake()
    {
        // Resources ������ �ִ� CSV ������ TextAsset���� �ε���
        TextAsset tempTextAsset = Resources.Load<TextAsset>("csv");

        // CSV ���� ����
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",", // ������ | ��
            NewLine = Environment.NewLine // ���๮�ڴ� �ü���� �´°ɷ� �˾Ƽ�
        };

        // CSV �Ľ�
        // csvString.Dispose(), csv.Dispose()�� �����ϱ� ���� unsing��
        using (StringReader csvString = new StringReader(tempTextAsset.text))
        {
            using (CsvReader csv = new CsvReader(csvString, config))
            {
                // foreach�� �� �� �ִ� �ε���
                IEnumerable<TextCsvRecord> records = csv.GetRecords<TextCsvRecord>();
                foreach (TextCsvRecord record in records)
                { 
                    //Debug.Log($"{record.ID} : {record.Create} : {record.Time}");

                    pictures = record.Pictures;
                    followZombies = record.FollowZombie;
                    layingZombies = record.LayingZombie;
                }
            }
        }
    }
}
