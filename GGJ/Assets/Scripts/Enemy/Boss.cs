﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    [SerializeField]
    private float see = 15.0f;

    [SerializeField]
    private int HP = 10;    //  HP
    
    [SerializeField]
    private GameObject attackPrefab; //攻撃用プレファブ（弾）

    private bool attackFlag;　//攻撃フラグ

    [SerializeField]
    private float attackTime = 1.0f;

    private float time = 0.0f;

    private GameObject Player;　//プレイヤー情報

    [SerializeField]
    private GameObject hitparticlePrefab;　//Hitエフェクト

    [SerializeField]
    private GameObject deathparticlePrefab; //死亡時エフェクト

    [SerializeField]
    private string HitSE;

    [SerializeField]
    private string DethSE;

    [SerializeField]
    private string shootSE;

    // Use this for initialization
    void Start () {

        //プレイヤーの情報を取得
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        //プレイヤー生存時
        if (Player != null)
        {
            //範囲内にプレイヤーがいるか判別
            attackFlag = Senser();

            //攻撃するかどうか
            if (attackFlag)
            {
                time += Time.deltaTime;
                if (attackTime < time)
                {
                    var obj = Instantiate(attackPrefab, transform.position, Quaternion.identity);

                    Vector2 dir = Player.transform.position - transform.position;
                    obj.GetComponent<Rigidbody2D>().AddForce(dir * 100.0f);

                    time = 0.0f;

                    AudioManager.Instance.PlaySE(shootSE);
                }
            }
        }

	}

    bool Senser()
    {
        float dis = Player.transform.position.x - transform.position.x;

        if (Mathf.Abs(dis) <= see)
        {
            return true;
        }

        return false;
    }

    void OnParticleCollision(GameObject obj)
    {

        if (obj.tag == "Bullet")
        {
            //ヒットパーティクルの生成
            Instantiate(hitparticlePrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySE(HitSE);

            Destroy(obj);
            HP--;
            if (HP <= 0)
            {
                Destroy(gameObject);
                //死亡パーティクルの生成
                Instantiate(deathparticlePrefab, transform.position, Quaternion.identity);
                AudioManager.Instance.PlaySE(DethSE);


            }
        }
        if (obj.tag == "Attack")
        {
            //ヒットパーティクルの生成
            Instantiate(hitparticlePrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySE(HitSE);

            Destroy(obj);
            HP -= 5;
            if (HP <= 0)
            {
                Destroy(gameObject);
                //死亡パーティクルの生成
                Instantiate(deathparticlePrefab, transform.position, Quaternion.identity);
                AudioManager.Instance.PlaySE(DethSE);

            }
        }
    }
}
