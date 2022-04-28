using UnityEngine;

[CreateAssetMenu(menuName = "Variablelar/Int Variable")]

///<summary>Scriptable objeler aracılığıyla global bir şekilde int variable okunabilir ve düzenlenebilir. </summary>
public class IntVariable : ScriptableObject
{
    [SerializeField] private int value;
    public int GetValue() => value;
    public void SetValue(int newValue) => value = newValue;
    public int Increase(int byHowMuch) => value = value + byHowMuch;

}
