using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

    [SerializeField]
    private float speed;

    private float direction;

	// Use this for initialization
	void Start ()
    {

        //プレイヤーオブジェクトを取得
        var player = GameObject.FindWithTag("Player");

        direction = player.transform.localScale.x;
        
        //5秒後に消滅
        Destroy(gameObject, 5.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        //左に飛んでいく
        if (direction < 0)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        //右に飛んでいく
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

    }
}
