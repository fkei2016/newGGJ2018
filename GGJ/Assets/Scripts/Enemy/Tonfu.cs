using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonfu : MonoBehaviour {

    [SerializeField]
    private float speed;

    private bool moveflag = false;
    
    private GameObject Player;

    private int hp = 2;

    [SerializeField]
    private GameObject hitparticlePrefab;

    [SerializeField]
    private GameObject deathparticlePrefab;


    // Use this for initialization
    void Start () {
        
        //プレイヤーの情報を取得
        Player = GameObject.FindWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        if(Player != null)
            Move();
	}

    void Move()
    {
        moveflag = Senser();

        if (moveflag)
        {

            float dis_x = Player.transform.position.x - transform.position.x;
            
            Vector2 direction = new Vector2(dis_x, 0.0f);

            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    bool Senser()
    {
        float dis = Player.transform.position.x - transform.position.x;

        if (Mathf.Abs(dis) <= 5)
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

            Destroy(obj);
            hp--;
            if (hp == 0)
            {
                Destroy(gameObject);
                //死亡パーティクルの生成
                Instantiate(deathparticlePrefab, transform.position, Quaternion.identity);

            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            //プレイヤーにダメージを与える
            Player.GetComponent<Player>().hp -= 2;

            //ヒットパーティクルの生成
            Instantiate(hitparticlePrefab, transform.position, Quaternion.identity);

            //ノックバック
            Vector2 direction = Player.transform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(direction * -200.0f);
        }
    }
}
