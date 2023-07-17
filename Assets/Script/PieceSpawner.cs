using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PieceSpawner : MonoBehaviour
{
    int[] ListValeur = new int[]{-2,1,5,10};
    private float timeSpawn;
    private int test;
    public GameObject pièce; 
    private Quaternion rotation=new Quaternion(90,90,0,1);
    private Vector3 spawn =new Vector3(-50,35,50); private Vector3 size =new Vector3(200,2,200);
    public Transform dossier ;
     public Configuration config ;

    void Update()
    {
        if (Manager.instance.cheat){
            if (Input.GetKeyDown(KeyCode.J)){Jackpot();} //pour tester le jackpot
            if (Input.GetKeyDown(KeyCode.L)){Ligne();} //pour tester la ligne
            if (Input.GetKeyDown(KeyCode.Y)) {Utile.Damage();Utile.Damage();Utile.Damage();Utile.Damage();} // pour le suicide de test
        }

        // gestion du spawn 
        timeSpawn=timeSpawn+Time.deltaTime;
        if (timeSpawn>config.spawnRate){
            test=Random.Range(0,99);
            if(test<95){
                Spawn(Utile.RngPoss(spawn,size,spawn.y));
            }
            else{
                Ligne();
            }
        }

        //gestion de la combo
        Manager.instance.timeCombo+=Time.deltaTime;
        if (Manager.instance.timeCombo>config.comboExpire){
            Manager.instance.combo=0;
        }

        if (Manager.instance.combo==config.comboNeeded){
            Jackpot();
            Saver.instance.score=Saver.instance.score+config.comboBonus;
            Manager.instance.combo=0;
        }
    }

    void Spawn(Vector3 position){
        GameObject newPiece=Instantiate (pièce,position,rotation,dossier);
        newPiece.GetComponent<Coin>().valeur=ListValeur[Random.Range(0,ListValeur.Length)];
        newPiece.GetComponent<Coin>().lifeTime=config.timeNormalPiece;
        //new Pieces(ListValeur[Random.Range(0,ListValeur.Length)],5,true);
        timeSpawn=0;
    }
    void Jackpot(){
        //spawn 50 petite pieces
        Debug.Log("Jackpot!");
        Utile.LancerSon("Jackpot",Saver.instance.listSon);
        for (int i = 0; i < config.jackpotSize; i++)
        {
            GameObject newPiece=Instantiate (pièce,spawn,rotation,dossier);
            newPiece.GetComponent<Coin>().lifeTime=config.timeJackpotPiece;
            newPiece.GetComponent<Coin>().valeur=2;
            newPiece.GetComponent<Rigidbody>().AddForce(Utile.RngVector(config.puissanceVectorSpawner),ForceMode.VelocityChange);
            Debug.Log(Utile.RngVector(1));
            //Debug.Log(RngVector(1)); le rng vector fonctionne bien
        }
        //spawn 5 mauvaise piece
        for (int i = 0; i < config.jackpotSize/10; i++)
        {
            GameObject newPiece= Instantiate(pièce,spawn,rotation,dossier);
            newPiece.GetComponent<Coin>().lifeTime=config.timeJackpotPiece;
            newPiece.GetComponent<Coin>().valeur=-2;
            newPiece.GetComponent<Rigidbody>().AddForce(Utile.RngVector(config.puissanceVectorSpawner),ForceMode.VelocityChange);
        }
        timeSpawn=-2;
    }
    void Ligne(){
        //fait spawn une ligne de 10 pièces 
        Debug.Log("une ligne ");
        Vector3 positionLigne=Utile.RngPoss(spawn,size,spawn.y);
        Vector3 directionRng=Utile.RngVector(1);
        Vector3 directionChoisi =new Vector3(directionRng.x,0,directionRng.z); //pour pas changer la hauteru de spawn 
         for (int i = 0; i < config.ligneSize; i++){
            Spawn(positionLigne);
            positionLigne+=directionChoisi;
         }
    }


    private void OnDrawGizmos(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(spawn,size);
        //pour voir la zone de spawn
    }
    
  
}
