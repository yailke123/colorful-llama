using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LinkedInPark : Collectable {
    [SerializeField] private SubWoofTweener leftWoof;
    [SerializeField] private SubWoofTweener rightWoof;
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
        collider2D.enabled = false;
        StartCoroutine(CollectRoutine());
    }

    private IEnumerator CollectRoutine() {
        yield return dvdRenderer.DOFade(0, 0.45f).WaitForCompletion();
        dvdRenderer.gameObject.SetActive(false);
        leftWoof.BoomTheWoof();
        rightWoof.BoomTheWoof();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Collect();
        }
    }
}
