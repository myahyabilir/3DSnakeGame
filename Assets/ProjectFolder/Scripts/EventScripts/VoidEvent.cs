using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventler/Void Event")]

///<Summary> Bir eventin parametresiz olarak raise edilmesi için kullanılabilir </Summary>
public class VoidEvent : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void Raise()
    {
        OnEventRaised?.Invoke();
    }

}
