using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour {
    [SerializeField] private PostProcessVolume globalPP;
    private ColorGrading _colorGrading;

    private void Awake() {
        _colorGrading = globalPP.profile.GetSetting<ColorGrading>(); 
    }

    

    public void DeSaturateGreen() {
        _colorGrading.hueVsSatCurve = new SplineParameter();
    }

    private void Update() {
        // TODO: Delete
        if (Input.GetKeyDown("q")) {
            DeSaturateGreen();
        }

        if (Input.GetKeyDown("w")) {

        }
    }
}
