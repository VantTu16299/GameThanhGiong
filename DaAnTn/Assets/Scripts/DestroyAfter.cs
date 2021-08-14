using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField]
    float after = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Recycle", after);
    }

    // Update is called once per frame
    void Recycle()
    {
        gameObject.Recycle();
    }
}
