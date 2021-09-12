using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] int vida;

    float minX, maxX;
    float crono = 0;
    float tiempo = 0;
    int contUsos = 3;
    float tiempoLento;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.R) && Time.time > tiempoLento)
        {
            tiempoLento = Time.timeScale + crono;
            contUsos--;

            if (contUsos == 0)
            {
                tiempo = Time.unscaledTime;
                Time.timeScale = 0.5f;
            }
        }

        if (tiempo != 0)
        {

            if (Time.unscaledTime - tiempo >= 3)
            {
                Time.timeScale = 1;
            }

        }


        if (movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        

        if(transform.position.x >= maxX)
        {
            movingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            movingRight = true;
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Disparo") )
        {
            //1. Encontrar el objeto llamado "GameManager"
            //2. Encontrar el componente de ese objeto de tipo "GameManager"
            //3. Llamar la función CaptureAnimal()
            

            vida--;

            if(vida <= 0)
            {
                GameObject gm = GameObject.Find("GameManager");
                GameManager script = gm.GetComponent<GameManager>();
                script.CaptureAnimal();
                Destroy(this.gameObject);
                
                
            }
            
        }
    }

}