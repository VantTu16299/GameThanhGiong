using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicPlay : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.PlayMusic("loop1");

    }
    
}


