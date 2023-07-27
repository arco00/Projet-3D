using UnityEngine;

public class RulesAff : MonoBehaviour
{    
    
     public static void Aff(GameObject affich){
            affich.SetActive(!affich.activeSelf);
     }
}
