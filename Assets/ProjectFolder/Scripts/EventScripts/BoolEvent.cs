using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventler/Bool Event")]

///<Summary> Bir eventin bool parametresi alarak raise edilmesi için kullanılabilir</Summary>
public class BoolEvent : ScriptableObject
{
    public UnityAction<bool> OnEventRaised;

    public void Raise(bool boolValue)
    {
        OnEventRaised?.Invoke(boolValue);
    }

}
