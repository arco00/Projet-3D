using UnityEngine;


public class MobSpawner : MonoBehaviour
{

    private float timer;
    
    
    private Quaternion rotation=new Quaternion(90,90,0,1);
    private Vector3 spawn =new Vector3(-50,35,50); private Vector3 size =new Vector3(200,2,200);
    public Transform dossier ;
    public Configuration config ;
 
    void Update()
    {timer+=Time.deltaTime;
    // faire spawn un mob de chaque tout les "timeSpawn" secondes 
    if (timer>=config.timeSpawnMob){
            GameObject newCreeper =Instantiate (config.creeper,Utile.RngPoss(spawn,size,spawn.y),rotation,dossier);
            GameObject newGreedy =Instantiate (config.greedy,Utile.RngPoss(spawn,size,spawn.y),rotation,dossier);
            timer=0;

         }
    }

        
    
}
