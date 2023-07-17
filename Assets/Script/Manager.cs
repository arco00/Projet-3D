using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Configuration config ;
   public static Manager instance ;
   public int hP ;
    public GameObject[]life ;
    public GameObject player;
    public int combo;
    public float timeCombo;
    public bool cheat;
    
    void Awake(){
        instance=this;
        hP=config.hP;
    }
}
