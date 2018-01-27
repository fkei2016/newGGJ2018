﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed; //スピード

    [SerializeField]
    private float jumpPower; //ジャンプ力

    [SerializeField]
    private LayerMask groundlayer;　//着地判定

    private bool grounded = false;　//着地判定

    [SerializeField]
    private Camera charaCamera; //キャラ追従カメラ

    [SerializeField]
    private GameObject bulletPrefab; //弾のプレファブ

    [SerializeField]
    private GameObject attackPrefab; //格闘攻撃のプレファブ

    private float shootTime = 0.0f;


    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {

        //キャラの移動
        Move();

        //キャラのジャンプ
        Jump();

        //カメラの移動
        charaCamera.transform.position = new Vector3(transform.position.x, 0.0f, -10.0f);

        //弾のリロード時間
        shootTime += Time.deltaTime;
        if (shootTime > 1.0f)
        {
            Shoot();
        }

        //格闘攻撃
        Attack();

    }

    //キャラの左右移動
    void Move()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (translation < 0)
        {
            //localScale.xを-1にすると画像が反転する
            Vector2 temp = transform.localScale;
            temp.x = -1.0f;
            transform.localScale = temp;
        }
        else if (translation > 0)
        {
            //localScale.xを1にすると画像が反転する
            Vector2 temp = transform.localScale;
            temp.x = 1.0f;
            transform.localScale = temp;
        }
    }

    //ジャンプ
    void Jump()
    {

        if (Input.GetKeyDown("space") && CheckGrounded())
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }
    }

    //地面に面しているか判断する関数
    bool CheckGrounded()
    {
        return Physics2D.Linecast(transform.position,
            transform.position - transform.up * 1.2f,
            groundlayer);
    }

    //弾を発射
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            shootTime = 0.0f;
        }
    }

    //格闘攻撃
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            var pos = transform.position;
            pos.x += transform.localScale.x * 1.25f;
            Instantiate(attackPrefab, pos, Quaternion.identity);
        }
    }


}
