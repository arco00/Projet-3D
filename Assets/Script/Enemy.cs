using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
 protected GameObject target;
protected Vector3 spawn =new Vector3(-50,35,50); protected Vector3 size =new Vector3(200,2,200);
[SerializeField]
protected NavMeshAgent navMesh;
protected float timer;
protected bool reboot = false;

    void OnTriggerStay(Collider other){
        TriggerStayBehaviour(other);
    }
     abstract public void TriggerStayBehaviour(Collider other) ;

    void OnCollisionEnter(Collision caC){
        CollisionBehaviour(caC);
    }
    abstract public void CollisionBehaviour(Collision caC);
    void Update()
    {
        UpdateBehaviour();
    }

    abstract public void UpdateBehaviour();
}
