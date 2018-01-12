using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour {

    //Creamos el Prefab del Blade para instanciarlo}
    public GameObject bladeTrailPrefab;

    GameObject currentBladeTrail;

    //Este es el circleCollieder para el Blade
    CircleCollider2D circleCollider;

    bool isCutting = false;

    Vector2 previousPosition;
    float minCuttingVelocity = 0.001f;
    
    Rigidbody2D rb;
    Camera cam;


	// Use this for initialization
	void Start () {
        cam = Camera.main;
        //asignamos las propiedades fisicas al Blade
        rb = GetComponent<Rigidbody2D>();
        //asignamos el collider al objeto
        circleCollider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Verificamos el botón del mouse si ha sido presionado y comenzamos el corte del melon
        if (Input.GetMouseButtonDown(0)){
            StartCutting();
        }
        //Verificamos el botón del mouse si ha sido soltado y terminamos el corte del melon
        if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        //Si esta cortando vamos a actualizar el corte
        if (isCutting) {
            UpdateCut();
        }

	}

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
        //Verificamos la velocidad del objeto creado para habilitar el collider 
        //Vamos a verificar la posición actual con la pasada por frame y se multiplica por un deltaTime

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        //Se revisa la velocids con ls velocidd minima para habilitar el collider 
        circleCollider.enabled = (velocity > minCuttingVelocity);

        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //Habilitamos el collider al momento de cortar
        circleCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        //Destruimos el Blade actual
        Destroy(currentBladeTrail, 2f); 
        //Deshabilitamos el collider al terminar el cortado
        circleCollider.enabled = false;

    }
}
