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
        LEVELTUT = 1000, 
        LEVEL1 = 1001, 
        LEVEL2 = 1002, 
        LEVEL3 = 1003
    }
    void LevelSelection()
    {
        switch (levels)
        {
            case LEVELS.LEVELTUT:
                SceneManager.LoadScene(1000);
                break;
            case LEVELS.LEVEL1:
                SceneManager.LoadScene(1001);
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
