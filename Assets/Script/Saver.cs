using UnityEngine;

public class Saver : MonoBehaviour
{
    public static Saver instance ;
    public int score;
    public GameObject listSon;
   
    void Awake()
    {
        if(Saver.instance==null){
        instance=this;
        DontDestroyOnLoad(gameObject);}
        else{
            Destroy(gameObject);
        }
    }

  
}
