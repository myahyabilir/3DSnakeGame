using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventler/Float Event")]

///<Summary> Bir eventin float parametresi alarak raise edilmesi için kullanılabilir</Summary>
public class FloatEvent : ScriptableObject
{
    public UnityAction<float> OnEventRaised;

    public void Raise(float floatValue)
    {
        OnEventRaised?.Invoke(floatValue);
    }

}
