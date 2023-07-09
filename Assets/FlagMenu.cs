using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlagMenu : MonoBehaviour
{
    public GameObject teamPanel;
    public GameObject buttonPrefab;
    private Team[] teams;

    private void Start()
    {
        teams = TeamManager.instance.teamsList.ToArray();
        for(int i = 0; i < teams.Length; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, teamPanel.transform);
            int teamNum = i;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = teams[teamNum].name;
            newButton.GetComponent<Button>().onClick.AddListener(() => SelectTeam(teamNum));
        }
    }

    private void SelectTeam(int teamNum)
    {
        FoulManager.instance.CompareCall(teams[teamNum]);
    }
}
