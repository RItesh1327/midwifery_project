using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    private Vector2 touchStartPos;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 swipe = touch.position - touchStartPos;
                transform.Rotate(new Vector3(swipe.x, 0, 0));
            }
        }
    }
}
