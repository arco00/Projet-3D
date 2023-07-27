using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int valeur;
    public float lifeTime;
    private float timer;
    public TMP_Text face1 ; public TMP_Text face2 ;

    void Start(){

        //réglagé de l'affichage des valeurs des pièces
        face1.text=valeur.ToString();
        face2.text=valeur.ToString();
        //changement de couleur des pièces 
        if (valeur<0){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        } 
        else{
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
    }

    //code de ce qu'il se passe quand la piece est touché 
    private void OnTriggerEnter(Collider other){
        //Debug.Log("piece touché");
        if(other.tag=="Player"){
            Object.Destroy(gameObject);
            Utile.LancerSon("Pieces",Saver.instance.listSon);
            Saver.instance.score=Saver.instance.score+valeur+Manager.instance.combo;
            if(valeur!=2 && valeur!=-2){
                //pour pas déclancher un jackpot avec une pièce de jackpot ou une pièce de valeur négative
                //Debug.Log(Save.Score);
                Manager.instance.timeCombo=0;
                Manager.instance.combo+=1;
                Debug.Log("combo:"+Manager.instance.combo);
            }
        }
        else if (other.tag!="Piece"){
           gameObject.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0); // arrété le mouvement 
        }
    }

    void Update(){
        
        timer+=Time.deltaTime;
        if(timer>lifeTime){
            Object.Destroy(gameObject);
        }
        
    
    }
}
