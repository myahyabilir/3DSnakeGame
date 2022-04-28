using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventler/Vector2 Event")]

///<Summary> Bir eventin Vector2 parametresi alarak raise edilmesi için kullanılabilir 
///Normal şartlarda bir kullanımı söz konusu değil ancak sadece touch olayı için implemente ettim</Summary>
public class Vector2Event : ScriptableObject
{
    public UnityAction<Vector2> OnEventRaised;

    public void Raise(Vector2 vector2)
    {
        OnEventRaised?.Invoke(vector2);
    }

}
