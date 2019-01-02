using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    public GameObject fadeObj;
    private FadeScript fade;
    private Color color;
    private ColorBlock colorBlock;
    private Button playButton;
    private GameObject childObj;
    private Text exitText;

    private void Start()
    {
        fade = fadeObj.GetComponent<FadeScript>();
        childObj = transform.GetChild(0).gameObject;
        exitText = childObj.GetComponent<Text>();
        playButton = GetComponent<Button>();
        color = GetComponent<Button>().colors.normalColor;
        colorBlock = playButton.colors;
    }

    private void Update()
    {
        if (fade.IsFadeOutStart())
        {
            colorBlock.normalColor = new Color(color.r, color.g, color.b, 1 - fade.Alpha);
            Color highlightedColor = playButton.colors.highlightedColor;
            colorBlock.highlightedColor = new Color(highlightedColor.r, highlightedColor.g
                , highlightedColor.b, 1 - fade.Alpha);
            playButton.colors = colorBlock;
            Color textColor = exitText.color;
            exitText.color = new Color(textColor.r, textColor.g, textColor.b, 1 - fade.Alpha);
        }

        if (!isClick) return;

        fade.isFadeIn = true;

        fade.FadeOut();

        if (fade.IsFinishFadeOut())
        {
            SceneManager.LoadScene(1);
        }
    }

    bool isClick = false;
    public void OnClick()
    {
        isClick = true;
    }

}
