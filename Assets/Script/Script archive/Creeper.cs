using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creeper : MonoBehaviour
{
private GameObject target;
private Vector3 spawn =new Vector3(-50,35,50); private Vector3 size =new Vector3(200,2,200);
public NavMeshAgent navMesh;
private float timer;
private bool reboot = false;
 
    // Start is called before the first frame update
    void OnTriggerStay(Collider other){
        if (other.gameObject.tag=="Player"){
            target=other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.tag=="Player"){
            target=null;
        }
    }
        //quand on touche le joueur
    void OnCollisionEnter(Collision caC){
        if (caC.gameObject.tag=="Player"){
            if(caC.gameObject.transform.position.y>transform.position.y+2){
                //si le joueur est + haut il tu le mob 
                Object.Destroy(gameObject);
                Utile.LancerSon("CreeperDeath",Saver.instance.listSon);
            }
            else{
                //réduction du score et destruction du creeper
                Utile.Damage();
                Object.Destroy(gameObject);
                Debug.Log("touché");
                Utile.LancerSon("CreeperDgm",Saver.instance.listSon);
            }
        }
        else if (caC.gameObject.tag=="Sol" && !reboot){
            GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled=false;
            GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled=true;
            reboot=true;
        }
    }
  

   
    void Update(){ 
        //GetComponent<UnityEngine.AI.NavMeshAgent> ().Warp (transform.position)
        NavMeshPath path = new NavMeshPath();

        if(target != null && reboot){

            navMesh.SetDestination(target.transform.position);
        }

        if (target==null && reboot){
            // mvt aléatoire
            Vector3 vecteur =Utile.RngPoss(spawn,size,transform.position.y);
            
          if (NavMesh.CalculatePath(transform.position,vecteur,NavMesh.AllAreas,path)&& timer>=3)
          {
            navMesh.SetDestination(vecteur);
            timer=0;
          }
          timer+=Time.deltaTime;
            
        }
        
    }

}



