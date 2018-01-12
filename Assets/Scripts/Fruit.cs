using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //Creamos el objeto prefabricado Melon cortado
    public GameObject fruitSlicedPrefab;
    //Fuerza inicial para los melones 
    public float startForce = 15f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Creamos el impulso para que salgan los melones hacia arriba 
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }


    //Generamos el trigger 
    void OnTriggerEnter2D(Collider2D col)
    {
        //Verificamos el Tageo del Blade
        if (col.tag == "Blade")
        {
            //Obtenemos la rotacion del golpe dado por nuestor Blade
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            //Creamos el objeto prefabricado con la posision del objeto completo 
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);

            //Y que el melon cortado es creado aquí lo destruimos des pues de 3 segundos
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }

}

