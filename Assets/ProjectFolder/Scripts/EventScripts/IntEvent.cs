using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventler/Int Event")]

///<Summary> Bir eventin int parametresi alarak raise edilmesi için kullanılabilir</Summary>
public class IntEvent : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void Raise(int integer)
    {
        OnEventRaised?.Invoke(integer);
    }

}
