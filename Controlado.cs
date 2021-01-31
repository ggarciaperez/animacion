using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

// Use a separate PlayerInput component for setting up input.
public class Controlado : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        //Debug.Log("onMove!");
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                anim.SetBool("corro", false);
                // interaccion realizada
                // ¿Estoy manteniendo la tecla?
                if (context.interaction is SlowTapInteraction)
                {
                    // me pongo a correr cuando la tecla está mantenida
                    Debug.Log("Correr mantenido");
                    Corro();
                }
                else
                {
                    Debug.Log("Correr iniciado y parado");
                    // Paro de correr
                    anim.SetBool("corro", false);              
                }
                break;

            case InputActionPhase.Started:
                // tecla presionada
                Debug.Log("Correr iniciada");
                Corro();
                break;

            case InputActionPhase.Canceled:
                Debug.Log("Correr cancelado");
                // Paro de correr
                anim.SetBool("corro", false);
                break;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("onLook!");
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                anim.SetBool("salto", false);
                // interaccion realizada
                // ¿Estoy manteniendo la tecla?
                if (context.interaction is SlowTapInteraction)
                {
                    // no pongo a false el parametro
                    // el jugador queda saltando
                    Debug.Log("Espacio mantenido");
                }
                else
                {
                    Debug.Log("Salto realizado");
                    // pongo a false el parametro
                    // si no lo hago sigue saltando
                    anim.SetBool("salto", false);               
                }
                break;

            case InputActionPhase.Started:
                // tecla presionada
                Debug.Log("Salto iniciado");
                Salto();
                break;

            case InputActionPhase.Canceled:
                Debug.Log("Salto cancelado");
                break;
        }
    }

    private void Salto()
    {
        Debug.Log("Saltando....");
        // activo el parametro de la transicion en el Animator
        anim.SetBool("salto", true);
    }
    private void Corro()
    {
        Debug.Log("Corriendo....");
        // activo el parametro de la transicion en el Animator
        anim.SetBool("corro", true);
    }
}