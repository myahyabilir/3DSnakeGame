using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventler/Vector3 Event")]

///<Summary> Bir eventin Vector3 parametresi alarak raise edilmesi için kullanılabilir 
///</Summary>
public class Vector3Event : ScriptableObject
{
    public UnityAction<Vector3> OnEventRaised;

    public void Raise(Vector3 vector3)
    {
        OnEventRaised?.Invoke(vector3);
    }

}
