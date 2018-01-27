using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonfu : MonoBehaviour {

    [SerializeField]
    private float speed;

    private bool moveflag = false;

    [SerializeField]
    private GameObject Player;

    private int hp = 2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
            Destroy(obj);
            hp--;
            if (hp == 0)
                Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
            Player.GetComponent<Player>().hp -= 2;

    }
}
