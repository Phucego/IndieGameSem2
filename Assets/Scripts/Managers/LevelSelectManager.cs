using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager instance;


    private void Awake()
    {
        //If there is an instance and it is not the player, then delete
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }



    private Scene scene;
    [SerializeField] public List<GameObject> gates = new List<GameObject>();

    public void OnGateSelected(GameObject go)
    {
        //Getting the level id
        int levelIndex = gates.IndexOf(go);
        Resources.Load<GameObject>("Level_" + levelIndex);
    }
}

