using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uni : MonoBehaviour {

    [SerializeField]
    private float speed;

    private bool moveflag = false;

    [SerializeField]
    private GameObject Player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();

	}

    void Move()
    {

        //物理計算をカット
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        moveflag = Senser();

        if (moveflag)
        {
            float dis_x = Player.transform.position.x - transform.position.x;
            float dis_y = Player.transform.position.y - transform.position.y;

            Vector2 direction = new Vector2(dis_x, dis_y);

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

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            //プレイヤーにダメージを与える
            Player.GetComponent<Player>().hp -= 1;

            //ノックバック
            Vector2 direction = Player.transform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(direction * -3000.0f);

            

        }
    }

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(obj);
        }
    }
}
