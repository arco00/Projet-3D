using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    public TMP_Text scoreAff;
    void Start() { 
    scoreAff.text="Combo:"+Manager.instance.combo;  
    }
    void Update() {
        //maj du score
        scoreAff.text="Combo:"+Manager.instance.combo; 
    }
}
