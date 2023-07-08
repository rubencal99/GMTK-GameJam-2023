using UnityEngine;

public class PlayerTeam : MonoBehaviour
{
    [SerializeField]
    private GameObject avatar;

    [SerializeField]
    private Team team;
    //public Team playerTeam
    //{
    //    get
    //    {
    //        return team;
    //    }
    //    set
    //    {
    //        team = value;
    //        avatar.GetComponent<Renderer>().sharedMaterial.SetColor("_UniformColor", team.color);
    //    }
    //}

    private void Awake()
    {
        avatar.GetComponent<Renderer>().sharedMaterial.SetColor("_UniformColor", team.color);
    }
}
