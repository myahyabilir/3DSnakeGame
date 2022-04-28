using UnityEngine;

[CreateAssetMenu(menuName = "Variablelar/Bool Variable")]

///<Summary> Scriptable objeler aracılığıyla global bir şekilde bool variable okunabilir ve düzenlenebilir</Summary>
public class BoolVariable : ScriptableObject
{
    [SerializeField] private bool value;
    public bool GetValue() => value;
    public void SetValue(bool newValue) => value = newValue;

}
