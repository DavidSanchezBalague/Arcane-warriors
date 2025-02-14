using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public Sprite[] walkSprites; // Sprites de animación (walk_0 a walk_7)
    public float animationSpeed = 0.1f; // Velocidad de animación
    public float moveSpeed = 2f; // Velocidad del enemigo
    public Transform player; // Referencia al jugador

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float animationTimer = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (walkSprites.Length == 0)
        {
            Debug.LogError("¡No se han asignado los sprites en el enemigo!");
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Buscar automáticamente al jugador
        }
    }

    void FixedUpdate()
    {
        MoveEnemy();
    }

    void Update()
    {
        AnimateWalk();
        FlipSprite();
    }

    void MoveEnemy()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }

    void FlipSprite()
    {
        if (player != null)
        {
            // Si el jugador está a la izquierda, voltear el sprite
            spriteRenderer.flipX = player.position.x < transform.position.x;
        }
    }

    void AnimateWalk()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            animationTimer += Time.deltaTime;
            if (animationTimer >= animationSpeed)
            {
                animationTimer = 0f;
                currentFrame = (currentFrame + 1) % walkSprites.Length;
                spriteRenderer.sprite = walkSprites[currentFrame];
            }
        }
        else
        {
            currentFrame = 0;
            spriteRenderer.sprite = walkSprites[currentFrame];
        }
    }
}
