using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour {
    [SerializeField] private PostProcessVolume globalPP;
    [SerializeField] private PostProcessProfile[] profiles;
    
    private PostProcessProfile _globalPostProcessProfile;
    private ColorGrading _globalColorGrading;

    private bool _colorVirginity = true;


    private void Awake() {
        _globalPostProcessProfile = globalPP.profile;
    }

    private void Start()
    {
        _globalPostProcessProfile.TryGetSettings(out _globalColorGrading);
    }

    public void DesaturateEverything()
    {
        Spline initialCurve = _globalColorGrading.hueVsSatCurve;
        initialCurve.curve.AddKey(0.5f, 0);

        _globalColorGrading.hueVsSatCurve.value = initialCurve;
    }
    
    //TODO: Smooth transitions
    public void SaturateProfile(int index) {
        
        ColorGrading addedColorGrading;
        profiles[index].TryGetSettings(out addedColorGrading);
        AnimationCurve addedCurve = addedColorGrading.hueVsSatCurve.value.curve;
        
        if (_colorVirginity)
        {
            _globalColorGrading.hueVsSatCurve.value = addedColorGrading.hueVsSatCurve.value;
            _colorVirginity = false;
        }
        else
        {
            Spline globalInitialCurve = _globalColorGrading.hueVsSatCurve.value;
            foreach (var key in addedCurve.keys)
            {
                globalInitialCurve.curve.AddKey(key);
            }

            _globalColorGrading.hueVsSatCurve.value = globalInitialCurve;
        }
        
    }

    private void Update() {
        // TODO: Delete
        if (Input.GetKeyDown("q")) {
            DesaturateEverything();
        }
    }
}
