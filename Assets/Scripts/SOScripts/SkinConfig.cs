using Throwing;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinConfig", menuName = "Config/SkinConfig", order = 0)]
public class SkinConfig : ScriptableObject {
    [SerializeField] private BaseThrowable throwingItemPrefab;

    public BaseThrowable ThrowingItem => throwingItemPrefab;
}