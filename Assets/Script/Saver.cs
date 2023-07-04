using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public static Saver instance ;
    public int score;
    public int combo;
    public float timeCombo;
    public int hP =4;
    public GameObject[]life ;
   
    void Awake()
    {
        instance=this;
        DontDestroyOnLoad(gameObject);
    }

  
}
