using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int buildIndex = 0;
    private void Start()
        
    {
       
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void NextLevelManager()
    {
       
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }
        if (buildIndex == 5)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(buildIndex + 1);
           
        }
    }
}
