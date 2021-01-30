using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour {
    [SerializeField] private PostProcessVolume globalPP;
    private PostProcessProfile _postProcessProfile;

    private void Awake() {
        _postProcessProfile = globalPP.profile;
    }

    public void DeSaturateGreen() {
        ColorGrading colorGrading;
        _postProcessProfile.TryGetSettings(out colorGrading);

        Spline x = new Spline(new AnimationCurve(), 2, false, new Vector2(0.2f, 0.2f) );

        colorGrading.hueVsSatCurve.value = x;
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
