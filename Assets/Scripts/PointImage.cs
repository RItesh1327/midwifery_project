using UnityEngine;
using UnityEngine.EventSystems;
public class PointImage : MonoBehaviour, IPointerClickHandler
{
    public Point point;

    public void OnPointerClick(PointerEventData eventData)
    {
        point.OnMouseDown();
    }
}
