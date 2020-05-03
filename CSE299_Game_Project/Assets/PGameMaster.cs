using UnityEngine;

public class PGameMaster : MonoBehaviour
{
  
    public static void KillPlayer(PPlayerHealth player)
    {
        Destroy(player.gameObject);
    }

   

    
}