using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public List<Button> LevelButton;
    public bool delete;
    public Text textMap;
    public int textmap;
    private void Update()
    {
        textMap.text = (textmap+"/5");
    }
    private void Start()
    {
        if (delete)
            PlayerPrefs.DeleteAll();
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        for (int i = 1; i < LevelButton.Count; i++)
        {
            if (i <= saveIndex)
            {
                LevelButton[i].interactable = true;
                textmap += 1;

            }
            else
            {
                LevelButton[i].interactable = false;
            }
        }
    }

    public void LevelSelect()
    {
        int level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(level);
    }


}
