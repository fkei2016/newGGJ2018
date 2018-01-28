using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour {

   [SerializeField] private GameObject Player;

    float DeathCount=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //  プレイヤーが死んでいるか判定処理
        if (Player.active == false)
        {
            //時間を足す。
            DeathCount += Time.deltaTime;
        }
        //シーン移動する
        if (DeathCount >= 2)
        {
            SceneManager.LoadScene("Death");
        }




	}
}
