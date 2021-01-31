using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LinkedInPark : Collectable {
    [SerializeField] private SubWoofTweener[] woofs;
    [SerializeField] private SpriteRenderer dvdRenderer;
    [SerializeField] private Collider2D collider2D;
    
    private void Awake() {
        collider2D.enabled = true;
        dvdRenderer.gameObject.SetActive(true);
        Color rendererColor = dvdRenderer.color;
        rendererColor.a = 1;
        dvdRenderer.color = rendererColor;
    }

    public override void Collect() {
        SoundManager.Instance.PlayMusicWithName("LinkedInPark");  
        collider2D.enabled = false;
        StartCoroutine(CollectRoutine());
    }

    private IEnumerator CollectRoutine() {
        yield return dvdRenderer.DOFade(0, 0.45f).WaitForCompletion();
        dvdRenderer.gameObject.SetActive(false);
        foreach (SubWoofTweener subWoofTweener in woofs) {
            subWoofTweener.BoomTheWoof();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Collect();
        }
    }
}
