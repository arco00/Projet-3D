using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces 
{

    //inutile pour l'instant
    public int Valeur;
    public int LifeTime;
    public bool triggerCombo;
    public Pieces (int Valeur,int LifeTime,bool triggerCombo){

        //mettre le trigger combo sur faux si la pieces est néagative 
        if (Valeur<=0&&triggerCombo){
            triggerCombo=false;
        }

    }
        
    
}
