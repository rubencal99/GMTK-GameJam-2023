using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Teams/Team Data", order = 1)]
public class Team : ScriptableObject
{
    public string name;
    public Color color;
}