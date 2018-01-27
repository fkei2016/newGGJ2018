using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    bool BulletUpFlag;
    bool BulletDownFlag;
    bool BulletAFlag;
    bool BulletLFlag;
    bool BulletInfinite;

    void Start()
    {
        BulletInfinite = false;
        BulletUpFlag = false;
        BulletDownFlag = false;
        BulletAFlag = false;
        BulletLFlag = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Story1");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            BulletUpFlag = true;
        }
       if (BulletUpFlag == true && Input.GetKeyDown(KeyCode.DownArrow))
       {
           BulletDownFlag = true;
       }
       if (BulletDownFlag == true && Input.GetKeyDown(KeyCode.A))
       {
           BulletAFlag = true;
       }
       if (BulletAFlag == true && Input.GetKeyDown(KeyCode.L))
       {
           BulletLFlag = true;
       }

        if (BulletLFlag == true)
        {
            BulletInfinite = true;
        }

        if (BulletInfinite == true)
        {
            //弾を無限にする処理
            Debug.Log("aaa");
        }
    }
    public bool GetBulletFlag()
    {
        return BulletInfinite;
    }
}

        
