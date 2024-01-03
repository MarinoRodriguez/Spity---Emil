using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform minX, maxX;

    bool tryingHold;
    bool isHolding, isSwiping;
    Vector3 p;
    float t;
    float TiempoHolding;
    float tClick;
    public pShooter shooter;
    private void Start()
    {
        if (shooter == null)
        {
            shooter = GetComponent<pShooter>();
        }
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var Touch = Input.GetTouch(0).position;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                tryingHold = true;
                var pos = Camera.main.ScreenToWorldPoint(Touch);
                p = transform.position;
                p.x = pos.x;

                t = 0;
                tClick = Time.time;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                var pos = Camera.main.ScreenToWorldPoint(Touch);
                pos.z = transform.position.z;
                pos.y = transform.position.y;

                if (isSwiping || tryingHold && !isHolding)
                    transform.position = pos;

                if (tryingHold)
                {
                    t += Time.deltaTime;
                    if (Vector3.Distance(p, transform.position) > 0.5f && t < 0.5f)
                    {
                        tryingHold = false;
                        isSwiping = true;
                        isHolding = false;
                    }
                    else if (t > 0.3f)
                    {
                        isSwiping = false;
                        isHolding = true;
                        tryingHold = false;
                    }
                }

                if (isHolding)
                {
                    TiempoHolding += Time.deltaTime;
                    print("Cargando holding");
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (isHolding || Time.time - tClick < 0.3f && !isSwiping)
                {
                    shooter.Shoot();
                    print("TiempoHolding: " + TiempoHolding);
                }

                isHolding = false;
                isSwiping = false;
            }
        }
        else
        {
            var mouse = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                tryingHold = true;
                var pos = Camera.main.ScreenToWorldPoint(mouse);
                p = transform.position;
                p.x = pos.x;

                t = 0;
                tClick = Time.time;
            }
            else if (Input.GetMouseButton(0))
            {
                var pos = Camera.main.ScreenToWorldPoint(mouse);
                pos.z = transform.position.z;
                pos.y = transform.position.y;

                if (isSwiping || tryingHold && !isHolding)
                    transform.position = pos;

                if (tryingHold)
                {
                    t += Time.deltaTime;
                    if (Vector3.Distance(p, transform.position) > 0.5f && t < 0.5f)
                    {
                        tryingHold = false;
                        isSwiping = true;
                        isHolding = false;
                    }
                    else if (t > 0.3f)
                    {
                        isSwiping = false;
                        isHolding = true;
                        tryingHold = false;
                    }
                }

                if (isHolding)
                {
                    TiempoHolding += Time.deltaTime;
                    print("Cargando holding");
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {

                if (isHolding || Time.time - tClick < 0.3f && !isSwiping)
                {
                    shooter.Shoot();
                    print("TiempoHolding: " + TiempoHolding);
                }

                isHolding = false;
                isSwiping = false;
            }

        }


    }

    private void LateUpdate()
    {
        var p = transform.position;

        p.x = Mathf.Clamp(p.x, minX.position.x, maxX.position.x);
        transform.position = p;
    }


    //private Vector2 startTouchPosition, swipeDelta;
    //public bool isSwiping, isHolding;
    //private float holdTimer;

    //public float maxSwipeTime = 0.5f; // Tiempo máximo para considerar un gesto como deslizamiento
    //public float maxHoldTime = 2f; // Tiempo máximo de carga
    //public float swipeThreshold = 50f; // Mínima distancia para considerar un deslizamiento

    //// Métodos para mover al personaje
    //private void Move(float x)
    //{
    //    /* Lógica para mover basado en 'x' (derecha o izquierda) */
    //    print("moviendose a la " + (x < 0 ? "izquierda": x > 0? "derecha": ""));
    //}

    //// Método para ejecutar la acción tras mantener presionado
    //private void ExecuteHoldAction(float holdTime) 
    //{
    //    /* Tu código aquí */
    //    print("Holding");
    //}

    //void Update()
    //{
    //    // Detectar toque en pantalla
    //    if (Input.touches.Length > 0)
    //    {
    //        if (Input.touches[0].phase == TouchPhase.Began)
    //        {
    //            isSwiping = true;
    //            isHolding = true;
    //            startTouchPosition = Input.touches[0].position;
    //            holdTimer = 0f;
    //        }
    //        else if (Input.touches[0].phase == TouchPhase.Moved && isSwiping)
    //        {
    //            swipeDelta = Input.touches[0].position - startTouchPosition;

    //            // Comprobar si se supera el umbral del deslizamiento
    //            if (swipeDelta.magnitude > swipeThreshold)
    //            {
    //                isHolding = false; // El usuario está deslizando, no manteniendo presionado

    //                // Calcular un valor similar a GetAxis
    //                float moveX = swipeDelta.x / swipeThreshold;
    //                Move(moveX);

    //                isSwiping = false;
    //            }
    //        }
    //        else if (Input.touches[0].phase == TouchPhase.Stationary && isHolding)
    //        {
    //            // Acumular tiempo mientras se mantiene presionado
    //            holdTimer += Time.deltaTime;
    //            if (holdTimer > maxHoldTime)
    //                isHolding = false; // Evitar que se acumule más allá del máximo
    //        }
    //        else if (Input.touches[0].phase == TouchPhase.Ended)
    //        {
    //            if (isHolding && holdTimer < maxHoldTime)
    //            {
    //                // Ejecutar acción de mantenimiento
    //                ExecuteHoldAction(holdTimer);
    //            }
    //            isSwiping = false;
    //            isHolding = false;
    //        }
    //    }
    //}

    //////////////////////////////////////////////////

    //public bool useMouse;

    //public Transform minX, MaxX;

    //public float speed = 2.5f;
    //CharacterController controller;

    //float mouseDeltaX;
    //Vector3 lastMousePos;

    //bool holding, swiping;
    //float minHoldTime = 0.5f;
    //float startedTouchTime;
    //float timeDelta;
    //private void Start()
    //{
    //    controller = GetComponent<CharacterController>();
    //}
    //private void Update()
    //{
    //    float xInput;
    //    if (useMouse)
    //        xInput = mouseDeltaX;
    //    else
    //        xInput = Input.GetAxis("Horizontal");


    //    if (Input.touches.Length > 0)
    //    {
    //        Touch t = Input.touches[0];

    //        if (t.phase == TouchPhase.Began)
    //        {
    //            startedTouchTime = Time.time;
    //            holding = true;
    //            timeDelta = 0;

    //        }

    //        if (timeDelta < minHoldTime)
    //        {
    //            timeDelta = Time.time - startedTouchTime;
    //        }

    //        if (t.phase == TouchPhase.Moved)
    //        {
    //            if(startedTouchTime < minHoldTime)
    //            {
    //                holding = false;
    //            }
    //            else
    //            {
    //                swiping = true;
    //            }
    //        }
    //        else if (t.phase == TouchPhase.Moved)
    //        {

    //        }

    //        if (t.phase == TouchPhase.Stationary && timeDelta > minHoldTime && holding)
    //        {

    //        }
    //        else if (t.phase == TouchPhase.Moved && timeDelta < minHoldTime && swiping)
    //        {
    //            xInput = t.deltaPosition.x;
    //        }
    //        if (t.phase == TouchPhase.Ended)
    //        {
    //            swiping = false;
    //            holding = false;
    //        }
    //    }


    //    controller.Move(Vector2.right * xInput * speed * Time.deltaTime);

    //    //transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.right * Input.GetAxis("Horizontal"), speed * Time.deltaTime);

    //}
    //private void FixedUpdate()
    //{
    //    if (useMouse)
    //        CalcularDeltaX();
    //}
    //
    //private void OnApplicationFocus(bool focus)
    //{
    //    lastMousePos = Input.mousePosition;
    //}

    //void CalcularDeltaX()
    //{
    //    if (lastMousePos != Vector3.zero)
    //    {
    //        mouseDeltaX = Input.mousePosition.x - lastMousePos.x;
    //        mouseDeltaX = Mathf.Clamp(mouseDeltaX, -1, 1);
    //    }
    //    lastMousePos = Input.mousePosition;
    //}

}
