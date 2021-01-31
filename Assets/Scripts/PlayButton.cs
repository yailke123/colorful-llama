using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {

    [SerializeField] private Image playButtonImage;
    [SerializeField] private Image backGround;
    
    private void Awake() {
        playButtonImage.rectTransform.DOScale(new Vector3(1, 1, 1), 0);
        playButtonImage.DOFade(1, 0);
        backGround.DOFade(0.6f, 0);
        Time.timeScale = 0;
    }

    public void AllowGameControls() {
        Time.timeScale = 1;
        playButtonImage.DOFade(0, 0.6f);
        playButtonImage.rectTransform.DOScale(new Vector3(0f,0f,0f), 0.6f);
        backGround.DOFade(0, 0.6f);
    }
}
