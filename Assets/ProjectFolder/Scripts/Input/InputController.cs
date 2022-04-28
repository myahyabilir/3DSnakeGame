using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

///<summary>IPointerDownHandler, IPointerUpHandler, IDragHandler interfaceleri kullanılarak ekstra olarak kurduğum event sistemin de yardımıyla bir input controller oluşturmuş oldum. Touch ve mouse gibi her türlü pointer cihaz çalışacaktır. </summary>
public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private VoidEvent onPointerDown;
    [SerializeField] private VoidEvent onPointerUp;
    [SerializeField] private Vector2Event onPointerDrag;
    [SerializeField] private int dragSensitivity = 5;

    public void OnPointerDown(PointerEventData eventData)
    {      
        onPointerDown.Raise();
    }
    public void OnDrag(PointerEventData eventData)
    {
        onPointerDrag.Raise(eventData.delta / dragSensitivity);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp.Raise();
    }
        

}
