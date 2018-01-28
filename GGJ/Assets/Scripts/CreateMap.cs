using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateMap : MonoBehaviour
{

    [SerializeField]
    private TextAsset _mapchip;

    [SerializeField]
    private GameObject[] mapdatePrefab;

    [HideInInspector]
    public float scaling = 1F;
    


    private void Start()
    {
        Make();
    }

    public void Make()
    {

        Vector3 sub = Vector3.zero;

        // テキストからマップデータを読み込み
        StringReader reader = new StringReader(_mapchip.text);
        while (reader.Peek() > -1)
        {
            // カンマ区切りで読み込んで行ごとにマップを作成
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            foreach (string value in values)
            {
                // 読み込んだからマップを作成
                int integer = int.Parse(value);
                if (integer >= 0 && integer < mapdatePrefab.Length)
                {
                    //オブジェクトを一個ずつ
                    GameObject obj = new GameObject();
                    switch (integer)
                    {   
                        //地面
                        case 0:
                            int num = Random.Range(0, 2);
                            obj = Instantiate(mapdatePrefab[num], transform);
                            break;

                        //ウニ（緑）
                        case 2:
                            obj = Instantiate(mapdatePrefab[integer], transform);
                            break;

                        //ウニ（赤）
                        case 3:
                            obj = Instantiate(mapdatePrefab[integer], transform);
                            break;

                        //トンフィー
                        case 4:
                            obj = Instantiate(mapdatePrefab[integer], transform);
                            break;

                        //中ボス
                        case 5:
                            obj = Instantiate(mapdatePrefab[integer], transform);
                            break;

                        //ラスボス
                        case 6:
                            obj = Instantiate(mapdatePrefab[integer], transform);
                            break;

                        //空白
                        default:
                            break;
                    }
                     
                    obj.transform.position = transform.position + sub;
                    obj.transform.localScale *= scaling;
                }
               
                sub.x += scaling * 1.25F;
            }
            sub.x = 0; sub.y -= scaling * 1.25F;
        }
    }

    public void Remove()
    {
        for (var num = 0; num < transform.childCount; num++)
        {
            Destroy(transform.GetChild(num).gameObject);
        }
    }
}
