using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    float r, g, b;
    private Color color;
    
    [SerializeField]
    private float alpha;

    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
        color = GetComponent<Image>().color;
        r = color.r;
        g = color.g;
        b = color.b;

        alpha = color.a;
	}

    private void Update()
    {
        if (IsFinishFadeIn())
        {
            isFadeIn = true;
            return;
        }

        if (isFadeIn) { return; }
        alpha -= speed * Time.deltaTime;

        GetComponent<Image>().color = new Color(r, g, b, alpha);
    }

    public void FadeOut()
    {
        GetComponent<Image>().color = new Color(r, g, b,alpha);
        alpha += speed * Time.deltaTime;       
    }

    public bool IsFinishFadeOut()
    {
        return (alpha >= 1);
    }

    public bool isFadeIn = false;
    public bool IsFinishFadeIn()
    {
        return (alpha <= 0);
    }

    public bool IsFadeOutStart()
    {
        return alpha >= 0;
    }

    public float Alpha
    {
        get { return alpha; }
    }
}
