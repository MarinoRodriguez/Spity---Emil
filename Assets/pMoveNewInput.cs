using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pMoveNewInput : MonoBehaviour
{
    private Vector2 startTouchPosition, currentTouchPosition, swipeDelta;
    private bool isSwiping, isHolding;
    private float holdTimer;

    public float maxSwipeTime = 0.5f; // Tiempo máximo para considerar un gesto como deslizamiento
    public float maxHoldTime = 2f; // Tiempo máximo de carga
    public float swipeThreshold = 50f; // Mínima distancia para considerar un deslizamiento

    private InputAction touchAction;

    private void Awake()
    {
        //var inputActions = new PlayerInputActions(); // Asumiendo que tu archivo se llama así
        //touchAction = inputActions.Player.Touch;
        touchAction.started += OnTouchStarted;
        touchAction.performed += OnTouchMoved;
        touchAction.canceled += OnTouchEnded;
    }

    private void OnEnable()
    {
        touchAction.Enable();
    }

    private void OnDisable()
    {
        touchAction.Disable();
    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        isSwiping = true;
        isHolding = true;
        startTouchPosition = touchAction.ReadValue<Vector2>();
        holdTimer = 0f;
    }

    private void OnTouchMoved(InputAction.CallbackContext context)
    {
        if (!isSwiping) return;

        currentTouchPosition = touchAction.ReadValue<Vector2>();
        swipeDelta = currentTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude > swipeThreshold)
        {
            isHolding = false;
            // Aquí agregas la lógica para manejar el deslizamiento
            isSwiping = false;
        }
    }

    private void OnTouchEnded(InputAction.CallbackContext context)
    {
        if (isHolding && holdTimer < maxHoldTime)
        {
            // Lógica para la acción de mantener presionado
        }
        isSwiping = false;
        isHolding = false;
    }

    void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer > maxHoldTime)
                isHolding = false;
        }
    }
}
