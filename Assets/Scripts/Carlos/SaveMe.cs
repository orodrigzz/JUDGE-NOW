using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    public static GameObject saveObject;
    private void Awake()
    {
        if(this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
       
    }

}
