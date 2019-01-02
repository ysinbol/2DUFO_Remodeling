using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour {

    Timer timer;
    Text text;
    Color textColor;
    float alpha;
    float fadeSpeed;

	// Use this for initialization
	void Start () {
        timer = new Timer(1.1f);
        text = gameObject.GetComponent<Text>();
        textColor = text.color;
        fadeSpeed = 0.5f;
        alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
        timer.TimerUpdate();
        if(timer.IsTime())
        {
            text.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            alpha -= fadeSpeed * Time.deltaTime;            
        }

        if(alpha <= 0)
        {
            Destroy(this);
        }
    }
}
