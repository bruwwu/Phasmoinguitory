using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        /*if(collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Disparaste a un amogus");
            GameManager.gameManager.baseEnemyHealth.DmgUnit(20);
            Debug.Log(GameManager.gameManager.baseEnemyHealth.Health);
            if(GameManager.gameManager.baseEnemyHealth.Health == 0)
            {
                Debug.Log("Heavy Muerto");
                Vector3 newPosition = new Vector3(collider.gameObject.transform.position.x, 60f, collider.gameObject.transform.position.z);
                collider.gameObject.transform.position = newPosition;
                Destroy(collider.gameObject, 0.5f);
            }
            Destroy(gameObject);
        }*/

        if(collider.gameObject.tag == "WallDestruible")
        {
            Debug.Log("Wall hit");
            GameManager.gameManager.WallHealth.DmgUnit(20);
            Debug.Log(GameManager.gameManager.WallHealth.Health);
            if(GameManager.gameManager.WallHealth.Health == 0)
            {
                Debug.Log("se petateo la pared gg");
                Destroy(collider.gameObject);
            }
            
            Destroy(gameObject, 1);
        }

        else if (collider.gameObject.tag == "Floor")
        {
            Debug.Log("Floor hit");
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Wall")
        {
            Debug.Log("Wall hit");
            Destroy(gameObject);
        }
    }
}