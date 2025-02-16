using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidad")]
    public float MoveSpeed;
    private CharacterController characterController;
    public float rotationSensitivity = 210f;
    
    [Header("Camera")]
    public CinemachineCamera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular las direcciones relativas de la cámara
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = playerCamera.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        // Combinar la entrada con las direcciones de la cámara
        Vector3 move = cameraForward * vertical + cameraRight * horizontal;
        move = Vector3.ClampMagnitude(move, 1f);

        // Mover al jugador
        characterController.Move(move * Time.deltaTime * MoveSpeed);

        // Hacer que el jugador rote hacia la dirección del movimiento (basada en la cámara)
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSensitivity * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager.playerHealth.DmgUnit(dmg, GameManager.gameManager.UI, GameManager.gameManager.Scene);
        Debug.Log("Awaaaa soy el personaje principal y me hicieron daño unu");
    }
}