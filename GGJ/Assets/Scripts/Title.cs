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

    [SerializeField]
    private string BGM;

    [SerializeField]
    private string SE;

    void Start()
    {
        BulletInfinite = false;
        BulletUpFlag = false;
        BulletDownFlag = false;
        BulletAFlag = false;
        BulletLFlag = false;

        AudioManager.Instance.ChangeVolume(0.1f,2.0f);


        AudioManager.Instance.PlayBGM(BGM);

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlaySE(SE);
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

        
