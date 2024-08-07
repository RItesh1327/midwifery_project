using UnityEngine;
using UnityEngine.EventSystems;

public class Tap3DObject : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Point point = GetComponent<Point>();
            point.OnMouseDown();
        }
    }
}
