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
    /* Parallax y Scrolling con variables modificables */
    public bool bScrolling, bParallax;

    public float fBackgroundSize = 0;
    public float fParallaxSpeed = 0;

    private Transform cameraTransform;
    private Transform[] layers;
    private float fViewZone = 10;
    private int iLeftIndex;
    private int iRightIndex;
    private float fLastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        fLastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        iLeftIndex = 0;
        iRightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (bParallax)
        {
            float deltaX = cameraTransform.position.x - fLastCameraX;
            transform.position += Vector3.right * (deltaX * fParallaxSpeed);
        }

        fLastCameraX = cameraTransform.position.x;

        if (bScrolling)
        {
            if (cameraTransform.position.x < (layers[iLeftIndex].transform.position.x + fViewZone))
                ScrollLeft();

            if (cameraTransform.position.x > (layers[iRightIndex].transform.position.x - fViewZone))
                ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        layers[iRightIndex].position = (Vector3.right * (layers[iLeftIndex].position.x - fBackgroundSize)) + (Vector3.up * layers[iLeftIndex].position.y) + (Vector3.forward * layers[iLeftIndex].position.z);
        iLeftIndex = iRightIndex;
        iRightIndex--;
        if (iRightIndex < 0)
            iRightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        layers[iLeftIndex].position = Vector3.right * (layers[iRightIndex].position.x + fBackgroundSize) + (Vector3.up * layers[iRightIndex].position.y) + (Vector3.forward * layers[iRightIndex].position.z);
        iRightIndex = iLeftIndex;
        iLeftIndex++;
        if (iLeftIndex == layers.Length)
            iLeftIndex = 0;
    }

    /*
     * Codigo dependiente de un eje en Z
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
    */
}
