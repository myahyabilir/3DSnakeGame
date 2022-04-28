using UnityEngine;

[CreateAssetMenu(menuName = "Variablelar/Float Variable")]

///<Summary> Scriptable objeler aracılığıyla global bir şekilde float variable okunabilir ve düzenlenebilir</Summary>
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value;
    public float GetValue() => value;
    public void SetValue(float newValue) => value = newValue;

}
