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
        // Resources 폴더에 있는 CSV 파일을 TextAsset으로 로드함
        TextAsset tempTextAsset = Resources.Load<TextAsset>("csv");

        // CSV 파일 설정
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",", // 구분은 | 로
            NewLine = Environment.NewLine // 개행문자는 운영체제에 맞는걸로 알아서
        };

        // CSV 파싱
        // csvString.Dispose(), csv.Dispose()를 생략하기 위한 unsing문
        using (StringReader csvString = new StringReader(tempTextAsset.text))
        {
            using (CsvReader csv = new CsvReader(csvString, config))
            {
                // foreach을 쓸 수 있는 인덱서
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
