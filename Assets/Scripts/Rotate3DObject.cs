using UnityEngine;
public class Rotate3DObject : MonoBehaviour
{
    public float sensitivity = 0.1f;
    private Vector2 startPos;
    private Vector3 initialRotation;
    private float totalRotation;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 currentPos = touch.position;
                Vector2 delta = currentPos - startPos;
                float yAngle = delta.x * sensitivity * -1;
                totalRotation += yAngle;
                transform.rotation = Quaternion.Euler(initialRotation.x, initialRotation.y + totalRotation, initialRotation.z);
            }
        }
    }
}


