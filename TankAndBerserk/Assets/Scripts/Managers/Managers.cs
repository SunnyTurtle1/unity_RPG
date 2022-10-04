using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init();  return s_instance; } }       
           
        

    void Start()
    {
        Init();
    }

    
    void Update()
    {
        
    }


    static void Init()
    {
        if (s_instance == null)
        {
            GameObject FindManagers = GameObject.Find("@Managers");
            if (FindManagers == null)
            {
                FindManagers = new GameObject { name = "@Managers" };
                FindManagers.AddComponent<Managers>();
            }

            DontDestroyOnLoad(FindManagers);
            s_instance = FindManagers.GetComponent<Managers>();
        }                
    }

    
}
