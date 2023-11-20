using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSuspectScript : MonoBehaviour
{
    public string suspect;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonPress);
    }

    public void OnButtonPress()
    {
        GameObject.FindGameObjectWithTag("End").GetComponent<EndScript>().SelectSuspect(suspect);
    }
}
