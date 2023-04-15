using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool m_Hold;
    public bool Hold => m_Hold;
    
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        m_Hold = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        m_Hold = false;
    }
}
