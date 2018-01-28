using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour {

    [SerializeField]
    private Image finish;

    private float time = 0.0f;


    // Use this for initialization
    void Start () {
        finish = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {



        time += Time.deltaTime;

        if (time > 1.0f)
        {
            finish.fillAmount = 3.0f;
        }

    }
}
