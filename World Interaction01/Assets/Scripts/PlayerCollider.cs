
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)//because items are set to istrigger
    {
       
        //checks for 
        if (collision.gameObject.CompareTag("LavaBorder"))//if we are colliding with a coin
        {
            Debug.Log("floor is Lava");
        }

        if (collision.gameObject.CompareTag("EndGame"))//if we are colliding with a coin
        {
            Debug.Log("Level 1 Complete");
        }
    }


    
}
