using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaplayer : MonoBehaviour
{
    CharacterController characterController;

    Vector3 groundPos; //posicion actual
    Vector3 lastGroundPos; //ultima posicion
    Vector3 currentPos; //posicion recalculada

    string groundName; //para dectectar la plataforma
    string lastGroundName; //movimiento del lugar base

    bool isJump; //para que el personaje salte en la plataforma

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag =="platform")
        {
            if (!isJump)
            {
                RaycastHit hit;//recuper informacion de una emision de rayos
                if (Physics.SphereCast(transform.position, characterController.radius, -transform.up, out hit))
                {
                    GameObject inGround = hit.collider.gameObject; //alamcena el objeto con el que esta colisionando el raycast
                    groundName = inGround.name;
                    groundPos = inGround.transform.position; //posicion del objeto en el que esta el jugador

                    if (groundPos != lastGroundPos && groundName ==lastGroundName)
                    {
                        currentPos = Vector3.zero; //resetea la posicion que avanzara el personaje
                        currentPos += groundPos - lastGroundPos; // calcula la posicion que debera moverse nuestro personaje
                        characterController.Move(currentPos);// Agrega el movimiento calculado a nuestro personaje
                    }
                    lastGroundName = groundName;
                    lastGroundPos = groundPos;
                }
            }
            if (Input.GetKey(KeyCode.Space))//si el jugador salta
            {
                if (!characterController.isGrounded)//si el jugador no esta en el suelo
                {
                    currentPos = Vector3.zero;
                    lastGroundPos = Vector3.zero;
                    lastGroundName = null;
                    isJump = true;
                }
            }
            if (characterController.isGrounded)//si el jugador esta tocando el suelo
            {
                isJump = false;
            }
        }
    }
}
