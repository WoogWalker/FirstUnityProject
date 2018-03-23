using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour{

    public float minDistance = 6.0f;
    public float maxDistance = 10.0f;
    [Space]

    public float minTime = 1;
    public float maxTime = 2;
    [Space]

    public float floorPos;
    public float ceilingPos;
    [Space]

    public GameObject pipe;

    private float generateTime;

    [Range(0f, 0.5f)]
    public float maxPipeHeightOffset = 0.5f;
    [Space]

    [Range(0.2f, 0.7f)]
    public float minDoublePipeHeightOffset;

    [Range(0.2f, 0.7f)]
    public float maxDoublePipeHeightOffset;
    [Space]
    public float pipeHeight;

    private Queue<GameObject> pipesQue = new Queue<GameObject>();

    public float removingPipesX;

    public void Generate()
    {
        float distance = Random.Range(minDistance, maxDistance);
        GameObject newPipe = GameObject.Instantiate(pipe); // Instantiate - создает экземпляр объекта
        pipesQue.Enqueue(newPipe);

        float yOffset = Random.Range(0, maxPipeHeightOffset);

        int pipePos = Random.Range(0, 3);
        if(pipePos == 0){
            newPipe.transform.position = new Vector3 (distance + transform.position.x, floorPos - pipeHeight * yOffset);
        }else if (pipePos == 1){
            newPipe.transform.position = new Vector3 (distance + transform.position.x, ceilingPos + pipeHeight * yOffset);
            newPipe.transform.Rotate(0, 0, 180);
        }else if(pipePos == 2){

            yOffset = Random.Range(minDoublePipeHeightOffset, maxDoublePipeHeightOffset);

            newPipe.transform.position = new Vector3 (distance + transform.position.x, floorPos - pipeHeight * yOffset);// floorPipe

            GameObject newPipe2 = GameObject.Instantiate(pipe);
            pipesQue.Enqueue(newPipe2);
            newPipe2.transform.position = new Vector3 (distance + transform.position.x, ceilingPos + pipeHeight * yOffset);// ceilingPipe
            newPipe2.transform.Rotate(0, 0, 180);
        }
    }

    void Start()
    {
       generateTime = Random.Range(minTime, maxTime)+Time.time; // Time.time - текущее время
    }

    void Update()
    {
        if (Time.time > generateTime){
            Generate();
            generateTime = Random.Range(minTime, maxTime)+Time.time; 
        }
        float distance2Pipe = transform.position.x - pipesQue.Peek().transform.position.x;
        if (distance2Pipe > removingPipesX){
            GameObject pipe2Remove = pipesQue.Dequeue();
            GameObject.Destroy(pipe2Remove);
        }
    }
}