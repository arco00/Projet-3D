using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Config")]
public class Configuration : ScriptableObject
{
    public int hP =4;
    public float comboExpire;
    public int comboNeeded;
    public int comboBonus; 
    public float spawnRate; 
    public int jackpotSize;
    public int ligneSize;
     public float timeJackpotPiece; public float timeNormalPiece ;
     public float puissanceVectorSpawner;
     public float timeSpawnMob;
     public GameObject creeper; public GameObject greedy;
     public float puissanceSaut ;
    public float vitesse ;
}
