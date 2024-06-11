using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate_Handle : MonoBehaviour
{
    [SerializeField] private int id;
    private bool hasLevelSelected;
    public void OnLoadLevel()
    {
        if (hasLevelSelected)
            return;
        Debug.Log("Loading Scene");
        SceneManager.LoadSceneAsync("Level_" + id);
        Resources.Load<GameObject>("Level_" + id);
        hasLevelSelected = true;
    }
}
