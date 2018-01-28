using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossDeath : MonoBehaviour {

    [SerializeField]
    private GameObject Boss;

    float DeathCount = 0;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {

        //ボスの情報を取得
        Boss = GameObject.FindWithTag("Boss");
        if (Boss == null)
        {
            //時間を足す。
            DeathCount += Time.deltaTime;
            //シーン移動する
            if (DeathCount >= 2)
            {
                SceneManager.LoadScene("Clear");
            }
        }
    }
}
