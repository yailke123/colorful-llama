using System;
using DG.Tweening;
using UnityEngine;

public class SubWoofTweener : MonoBehaviour {

    [SerializeField] private SpriteRenderer renderer;

    private void Start() {
        Color rendererColor = renderer.color;
        rendererColor.a = 0;
        renderer.color = rendererColor;
    }

    public YieldInstruction BoomTheWoof() {
        Sequence seq = DOTween.Sequence();
        Vector3 localScale = transform.localScale;
        
        return seq.Append(renderer.DOFade(1f, 0.4f))
            .Append(transform.DOPunchScale(new Vector3(localScale.x + 0.1f, localScale.y + 0.1f), 3f, 2, 0.4f))
            .Append(renderer.DOFade(0, 0.4f)).WaitForCompletion();
    }
}
