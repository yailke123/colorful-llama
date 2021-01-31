using System;
using System.Collections;
using DigitalRuby.RainMaker;
using UnityEngine;

public class SessionManager : MonoBehaviour {
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private PostProcessingManager postProcessingManager;
    [SerializeField] private GameObject rainObj;

    private void Start()
    {
        StartCoroutine("RainRoutine");
    }

    private IEnumerator RainRoutine()
    {
        yield return new WaitForSeconds(1);
        postProcessingManager.DesaturateEverything();
        yield return new WaitForSeconds(1);
        rainObj.SetActive(false);
    }
}
