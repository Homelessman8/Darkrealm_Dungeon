using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag =="LavaBorder");
        
    }



}
