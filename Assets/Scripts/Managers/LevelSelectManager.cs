using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelectManager : MonoBehaviour
{
    private Scene scene;
    [SerializeField] public List<GameObject> portals = new List<GameObject>();

    LEVELS levels;
    public enum LEVELS
    {
        //assign the levels to an integer
        LEVELTUT,
        LEVEL1,
        LEVEL2,
        LEVEL3 
    }
    void LevelSelection()
    {
        switch (levels)
        {
            case LEVELS.LEVELTUT:
                SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
                break;
            case LEVELS.LEVEL1:
                SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
                break;
            case LEVELS.LEVEL2:
                SceneManager.LoadScene(1002);
                break;
            case LEVELS.LEVEL3:
                SceneManager.LoadScene(1003);
                break;                
        }
        
    }




}
