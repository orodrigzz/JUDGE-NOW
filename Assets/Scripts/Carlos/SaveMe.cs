using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    public  GameObject saveObject;
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        
    }
    void Start()
    {
       
    }

}
