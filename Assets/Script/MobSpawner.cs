using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobSpawner : MonoBehaviour
{

    private float timer;
    public float timeSpawn;
    public GameObject creeper; public GameObject greedy;
    private Quaternion rotation=new Quaternion(90,90,0,1);
    private Vector3 spawn =new Vector3(-50,35,50); private Vector3 size =new Vector3(200,2,200);
    public Transform dossier ;
 
    void Update()
    {timer+=Time.deltaTime;
    // faire spawn un mob de chaque tout les "timeSpawn" secondes 
    if (timer>=timeSpawn){
            GameObject newCreeper =Instantiate (creeper,Utile.RngPoss(spawn,size,spawn.y),rotation,dossier);
            GameObject newGreedy =Instantiate (greedy,Utile.RngPoss(spawn,size,spawn.y),rotation,dossier);
            timer=0;

         }
    }

        
    
}
