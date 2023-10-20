using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloons : MonoBehaviour
{
    public GameObject balloon;

    public Material[] balloonColors;

    private float maxX, minX, maxZ, minZ;

    private Coroutine spawnBalloon;
    // Start is called before the first frame update
    void Start()
    {
        maxX = transform.position.x + transform.localScale.x / 2;
        minX = transform.position.x - transform.localScale.x / 2;
        
        maxZ = transform.position.z + transform.localScale.z / 2;
        minZ = transform.position.z - transform.localScale.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnBalloon == null)
            spawnBalloon = StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
        Material spawnMaterial = balloonColors[Random.Range(0,balloonColors.Length)];
        var gameObject = Instantiate(balloon, spawnPosition, Quaternion.identity);
        gameObject.GetComponent<MeshRenderer>().material = spawnMaterial;
        Destroy(gameObject,10f);
        yield return new WaitForSeconds(1f);
        spawnBalloon = null;
    }
}
