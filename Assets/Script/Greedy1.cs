using UnityEngine;
using UnityEngine.AI;

public class Greedy1 : Enemy
{

private bool playerCaC=false;
private float full;
    public override void TriggerStayBehaviour(Collider other)
    {
        NavMeshPath path = new NavMeshPath();
        if (other.gameObject.tag=="Piece" && target==null && NavMesh.CalculatePath(transform.position,other.transform.position,NavMesh.AllAreas,path)){
            target=other.gameObject;
        }
    }
    
public override void CollisionBehaviour(Collision caC){
    if (caC.gameObject.tag=="Piece"){
            playerCaC=true;
            Debug.Log("de la pièce");
            full+=caC.gameObject.GetComponent<Coin>().valeur;
            Object.Destroy(caC.gameObject);
            Utile.LancerSon("GreedyPickUp",Saver.instance.listSon);
        }
        else if (caC.gameObject.tag=="Sol" && !reboot){
            GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled=false;
            GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled=true;
            reboot=true;
        }
}
public override void UpdateBehaviour(){
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
        //si il a manger assez de pièèces
        if (full>=50){
            Utile.Damage();
            Object.Destroy(gameObject);
            Utile.LancerSon("GreedyExplo",Saver.instance.listSon);
        }
        
        timer+=Time.deltaTime;
}


   
}
