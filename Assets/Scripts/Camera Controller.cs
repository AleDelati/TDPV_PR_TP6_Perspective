using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private bool camera3DMode = true;
    [SerializeField] private Vector3 offset3D;
    [SerializeField] private Vector3 offset2D;

    private GameObject target;

    private void Start() {
        target = GameObject.Find("Player");
    }

    private void Update() {
        UpdateCameraPos();
    }

    private void UpdateCameraPos() {
        if (camera3DMode) {
            transform.position = target.transform.position + offset3D;
        } else {
            transform.position = target.transform.position + offset2D;
        }
    }
}
