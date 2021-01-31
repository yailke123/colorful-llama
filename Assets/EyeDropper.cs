using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDropper : Collectable
{
    [SerializeField] private PostProcessingManager postProcessingManager;
    [SerializeField] private int profileNumber;

    public override void Collect()
    {
        postProcessingManager.SaturateProfile(profileNumber);
        Destroy(this.gameObject);
    }
}
