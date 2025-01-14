using System.Collections;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public Sprite[] walkSprites; // Aquí arrastra los sprites (walk_0 a walk_7) desde el editor.
    public float animationSpeed = 0.1f; // Velocidad de la animación (en segundos por frame).
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje.

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float animationTimer = 0f;
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb; // Referencia al Rigidbody2D

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Inicializar el Rigidbody2D
        if (walkSprites.Length == 0)
        {
            Debug.LogError("¡No se han asignado los sprites! Por favor, arrastra tus sprites al array en el inspector.");
        }
    }

    void Update()
    {
        HandleInput();
        AnimateWalk();
    }

    void FixedUpdate() // Cambiar a FixedUpdate para trabajar con la física
    {
        MoveCharacter();
    }

    void HandleInput()
    {
        // Obtener la dirección basada en las teclas presionadas.
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) direction += Vector2.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector2.down;
        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;

        direction = direction.normalized; // Normalizar para evitar que la velocidad sea mayor en diagonales.

        // Cambiar la orientación del sprite al moverse a la izquierda o derecha.
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true; // Mirar a la izquierda.
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false; // Mirar a la derecha.
        }
    }

    void MoveCharacter()
    {
        rb.velocity = direction * moveSpeed; // Usar el Rigidbody2D para mover al personaje
    }

    void AnimateWalk()
    {
        if (direction != Vector2.zero) // Solo animar si el personaje se está moviendo.
        {
            animationTimer += Time.deltaTime;
            if (animationTimer >= animationSpeed)
            {
                animationTimer = 0f;
                currentFrame = (currentFrame + 1) % walkSprites.Length; // Cambiar al siguiente frame.
                spriteRenderer.sprite = walkSprites[currentFrame];
            }
        }
        else
        {
            // Si no se está moviendo, restablecer al frame inicial.
            currentFrame = 0;
            spriteRenderer.sprite = walkSprites[currentFrame];
        }
    }
}
