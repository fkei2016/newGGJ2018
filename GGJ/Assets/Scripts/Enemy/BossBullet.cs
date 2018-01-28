using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

    [SerializeField]
    private int attack = 10;

    private GameObject Player;

    [SerializeField]
    private GameObject hitparticlePrefab; //Hitエフェクト
    
    [SerializeField]
    private string HitSE;

    // Use this for initialization
    void Start () {

        //プレイヤーの情報を取得
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            //プレイヤーにダメージを与える
            Player.GetComponent<Player>().hp -= attack;
        }

        //ヒットパーティクルの生成
        Instantiate(hitparticlePrefab, transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySE(HitSE);

        Destroy(gameObject);
    }

}
