using UnityEngine;

public class KeySystem : MonoBehaviour
{
    public Animator animDoor;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ya recogiste la llave");
            animDoor.Play("DoorOpen");
            Destroy(gameObject);
        }
    }
}
