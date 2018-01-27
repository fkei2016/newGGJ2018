using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story1 : MonoBehaviour {

    int storyFrame;
    int storytime;
	// Use this for initialization
	void Start () {
        storyFrame = 0;
        storytime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        storyFrame++;

        if (storyFrame > 60)
        {
            storytime += 1;
            storyFrame = 0;
        }

        if (storytime >= 5)
        {
            SceneManager.LoadScene("Play");
        }
	}
}
