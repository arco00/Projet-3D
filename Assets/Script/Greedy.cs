using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Greedy : MonoBehaviour
{
private GameObject target;
private bool playerCaC=false;
public NavMeshAgent navMesh;
private bool reboot=false;
 private Vector3 spawn =new Vector3(-50,35,50); private Vector3 size =new Vector3(200,2,200);
 private float timer;
 private float full;
    void OnTriggerStay(Collider other){
        NavMeshPath path = new NavMeshPath();
        if (other.gameObject.tag=="Piece" && target==null && NavMesh.CalculatePath(transform.position,other.transform.position,NavMesh.AllAreas,path)){
            target=other.gameObject;
        }
    }
        //quand on touche la piece
    void OnCollisionEnter(Collision caC){
        if (caC.gameObject.tag=="Piece"){
            playerCaC=true;
            Debug.Log("de la pièce");
            full+=caC.gameObject.GetComponent<Coin>().valeur;
            Object.Destroy(caC.gameObject);
        }
        else if (caC.gameObject.tag=="Sol" && !reboot){
            GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled=false;
            GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled=true;
            reboot=true;
        }
    }

    void Update(){ 
        NavMeshPath path = new NavMeshPath();

        if (Vector3.Distance(transform.position,Manager.instance.player.transform.position)>=100){
            navMesh.enabled=false;
            return;       
        }
        else{
            navMesh.enabled=true;
        }
        
        if (target==null && reboot){
            // mvt aléatoire
            Vector3 vecteur =Utile.RngPoss(spawn,size,transform.position.y);
          if (NavMesh.CalculatePath(transform.position,vecteur,NavMesh.AllAreas,path )&& timer>=3)
          { 
            
            navMesh.SetDestination(vecteur);
            timer=0;
          }
        }

        else if (reboot){
            //vers la pièce
            navMesh.SetDestination(target.transform.position);
        }

        if (full>=50){
            Utile.Damage();
            Object.Destroy(gameObject);
        }
        
        timer+=Time.deltaTime;

        
    }

   
}
