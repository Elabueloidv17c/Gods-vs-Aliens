using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Depth
{
    Background_1,
    Background_2,
    Background_3,
    Background_4,
    PlayArea_1,
    PlayArea_2,
    PlayArea_3,
    ForwardGround_1,
    ForwardGround_2,
    ForwardGrond_3,
    ForwardGround_4
}

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;     //Arreglo de los backgrounds para el parallax
    private float[] parallaxScales;     //Proporciones del movimiento de la camara para mover el background
    public float smoothing = 1f;        //Lo suave que sera el parallax

    private Transform cam;              //Referencia de la transformacion camara principal
    private Vector3 previousCamPos;     //Posición de las camaras en el frame anterior

    private void Awake()
    {
        //Acomoda la camara como referencia
        cam = Camera.main.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        //El frame anterior tiene la posicion de la camara del frame actual
        previousCamPos = cam.position;

        //Asignar las escalas de losprallax correspondientes
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
            Debug.Log(parallaxScales[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //para cada background
        for (int i = 0; i < backgrounds.Length; i++)
        {

            //El parallax es el opuesto del movimiento de la camara debido al frame oasado multiplicado por la escala
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            //Acomoda un objetivo posixion x la cual es la posicion actual mas el parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //Create posicion objetivo donde la posicion actual del background con su posicion objetivo en x
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //cambio entre la posicion actual y la posicion del objetivo usando lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        //Acomodar la posicion anterior de la camara al final del frame
        previousCamPos = cam.position;
    }
}
