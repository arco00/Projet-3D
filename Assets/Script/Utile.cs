using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utile 
{
  public static Vector3 RngPoss(Vector3 spawn,Vector3 size,float y){
        //génération de la coordonné de spawn
        Vector3 vecteur = new Vector3(
            Random.Range(spawn.x-size.x/2,spawn.x+size.x/2),
            y,
            Random.Range(spawn.z-size.z/2,spawn.z+size.z/2));
        return vecteur;
    }

    public static Vector3 RngVector(float power){
        //pour généré un vector 3 aléatoire 
        Vector3 vecteur = new Vector3(
            Random.Range(-10,10)*power,
            Random.Range(-10,10)*power,
            Random.Range(-10,10)*power  );
        return vecteur;
    }

    public static void Damage(){
        Manager.instance.hP--;
        Object.Destroy(Manager.instance.life[Manager.instance.hP]);
        //test de mort
        if (Manager.instance.hP==0){
            SceneManager.LoadScene("Score");
            Cursor.lockState=CursorLockMode.Confined;
            Utile.LancerSon("Fin",Saver.instance.listSon);
        }
    }

     public static void Unpause(){
        Cursor.lockState=CursorLockMode.Locked;
     }

     public static void LancerSon(string name,GameObject son){
        AudioSource[] childComponents = son.GetComponentsInChildren<AudioSource>();
        // Recherche l'enfant spécifique avec le nom "ChildObjectName"
        foreach (AudioSource childComponent in childComponents)
        {
            if (childComponent.gameObject.name == name)
            {
                childComponent.Play();
                break; // Sortir de la boucle après avoir trouvé l'enfant souhaité
            }
        }
     }
}
