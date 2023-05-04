using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBasic : MonoBehaviour
{
    
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    [Range(0f, 5f)]
    public float speed = 2f; // Velocidad del enemigo
    private float _waitTime; //Punto de espera
    [Range(0f,5f)]
    public float startWaitTime = 3f; //Tiempo que pasa en cada punto de espera

    //Gestiona donde esta y a donde tiene que ir el enemigo
    private int _i = 0;
    private Vector2 _actualPos;

    public Transform[] movement; 


    // Start is called before the first frame update
    void Start()
    {
        //Cuanto tiempo hay que parar en cada punto
        _waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(CheckEnemyMovement());

        EnemyMovement();
    }

    public void EnemyMovement()
    {
        StartCoroutine(CheckEnemyMovement());
        //Movimiento del enemigo en los patrones establecidos
        transform.position = Vector2.MoveTowards(transform.position, movement[_i].transform.position, speed * Time.deltaTime);

        //Calcula la distancia en la que estas de un punto para volver al otro punto
        if (Vector2.Distance(transform.position, movement[_i].transform.position) < 0.1f)
        {
            if (_waitTime <= 0)
            {
                if (movement[_i] != movement[movement.Length - 1])
                {
                    _i++; // Si hay puntos a donde ir va al siguiente
                }
                else
                {
                    _i = 0; //Si no hay mas puntos donde ir vuelve al primero
                }

                _waitTime = startWaitTime; //Tiempo de espera y se repite la accion
            }
            else
            {
                _waitTime -= Time.deltaTime; //Resta el tiempo al punto de espera 
            }
        }
    }

    //Corrutina con la que en vez de ejecutar la accion cada frame lo haga por un tiempo
    //Evita que cada frame el codigo este preguntando la posicion del enemigo
    //Buscamos saber cuando flipear el sprite del enemigo
    IEnumerator CheckEnemyMovement()
    {
        _actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        
        if (transform.position.x > _actualPos.x)
        {
            spriteRenderer.flipX = true;
            
        }
        else if (transform.position.x < _actualPos.x)
        {
            spriteRenderer.flipX = false;
            
        }

    }
}
