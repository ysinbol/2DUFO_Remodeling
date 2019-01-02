using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour {

    public GameObject fadeObj;
    public GameObject playButtonObj;

    private PlayButton playButton;
    private FadeScript fade;

    private void Start()
    {
        fade = fadeObj.GetComponent<FadeScript>();
        playButton = playButtonObj.GetComponent<PlayButton>();
    }

    private void Update()
    {
        //if (!playButton.isClick) return;

        //fade.FadeOut();
        //if (fade.IsFadeOuted())
        //{
        //    SceneManager.LoadScene(1);
        //}
    }

}
