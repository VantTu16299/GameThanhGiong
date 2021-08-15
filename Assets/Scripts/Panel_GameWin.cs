using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Panel_GameWin : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textEnemy;
    public Text textFamor;
    public int intEnemy;
    public int intFamor;
    public CoinsMananger cm;
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<CoinsMananger>();
    }

    // Update is called once per frame
    void Update()
    {

        textFamor.text = (cm.famor + "/"+intFamor);

        textEnemy.text = (cm.Coins + "/"+intEnemy);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit(int sceneANumber)

    {
        sceneANumber =1;
        SceneManager.LoadScene(sceneANumber);
        

    }
}
