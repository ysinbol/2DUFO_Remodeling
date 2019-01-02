using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

    public GameObject fadeObj;
    private FadeScript fade;
    private Button exitButton;
    private ColorBlock colorBlock;
    private GameObject childObj;
    private Text exitText;
    private Color color;

    private void Start()
    {
        childObj = transform.GetChild(0).gameObject;
        exitText = childObj.GetComponent<Text>();
        fade = fadeObj.GetComponent<FadeScript>();
        exitButton = GetComponent<Button>();
        color = exitButton.colors.normalColor;
        colorBlock = exitButton.colors;
    }

    private void Update()
    {
        if(fade.IsFadeOutStart())
        {
            colorBlock.normalColor = new Color(color.r, color.g, color.b,1 - fade.Alpha);
            exitButton.colors = colorBlock;
            exitText.color = new Color(exitText.color.r, exitText.color.g, exitText.color.b, 1 - fade.Alpha);
        }
    }

    public void OnClick()
    {
        Application.Quit();
    }

}
