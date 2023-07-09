using UnityEngine;

public class TeamColor : MonoBehaviour
{
    [SerializeField]
    private GameObject avatar;

    [SerializeField]
    private Team team;

    private void Awake()
    {
        avatar.GetComponent<Renderer>().sharedMaterial.SetColor("_UniformColor", team.color);
    }

    public Team GetTeam()
    {
        return team;
    }
}
