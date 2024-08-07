using UnityEngine;

public class Swipe3DObject : MonoBehaviour
{
    private float yRotation;
    private float yRotationSpeed = 0.5f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            yRotation += touchDeltaPosition.x * yRotationSpeed;
            transform.eulerAngles = new Vector3(0, yRotation, 0);
        }
    }
}
