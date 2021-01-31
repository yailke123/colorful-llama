using UnityEngine;

public class ParallaxEffect : MonoBehaviour {
    private float _startPos;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float parallaxEffect;
    
    void Start() {
        _startPos = transform.position.x;
    }

    private void Update() {
        float dist = _camera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(_startPos + dist + 7.5f, transform.position.y, transform.position.z);

    }
}
