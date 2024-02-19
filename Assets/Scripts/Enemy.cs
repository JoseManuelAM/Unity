using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float Speed = 2f;
    private bool movingRight = true;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            if (transform.position.x < startPosition.x + moveDistance)
            {
                // Mover al enemigo hacia la derecha
                transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                // Cambiar la dirección
                movingRight = false;
            }
        }
        else
        {
            if (transform.position.x > startPosition.x)
            {
                // Mover al enemigo hacia la izquierda
                transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                // Cambiar la dirección
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Esta colisión es para el BoxCollider2D que representa el cuerpo del enemigo
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar al método Die del jugador
            collision.gameObject.GetComponent<PlayerLife>().Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Esta colisión es para el CircleCollider2D que representa la cabeza del enemigo
        if (collision.CompareTag("Player"))
        {
            // Destruir al enemigo porque fue golpeado en la cabeza
            Destroy(gameObject);
        }
    }
}
