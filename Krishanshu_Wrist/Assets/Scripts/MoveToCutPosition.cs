using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCutPosition : MonoBehaviour
{
    public Transform cutPosition; 
     

    private bool moveToCut = false;

    public Transform boxDestination; 
    public float moveSpeed = 5f;
    public Vector3 boxOffsetRange = new Vector3(0.2f, 0.1f, 0.2f); 
    public float rotationRandomness = 15f; 

    private List<Transform> fruitSlices = new List<Transform>();
    private int choppedCount = 0;

    private void Start()
    {
       
        foreach (Transform child in transform)
        {
            fruitSlices.Add(child);
        }

        if (fruitSlices.Count == 0)
        {
            Debug.LogError("No fruit slices" + gameObject.name);
        }
    }

    public void RegisterSliceChop()
    {
        choppedCount++;
        if (choppedCount >= fruitSlices.Count)
        {
            Debug.Log("All slices chopped");
            StartCoroutine(MoveSlicesToBox());
        }
    }

    private IEnumerator MoveSlicesToBox()
    {
        for (int i = 0; i < fruitSlices.Count; i++)
        {
            Transform slice = fruitSlices[i];
            Vector3 randomOffset = new Vector3(
                Random.Range(-boxOffsetRange.x, boxOffsetRange.x),
                Random.Range(0, boxOffsetRange.y),
                Random.Range(-boxOffsetRange.z, boxOffsetRange.z)
            );

            Vector3 targetPosition = boxDestination.position + randomOffset;

            Quaternion randomRotation = Quaternion.Euler(
                Random.Range(-rotationRandomness, rotationRandomness),
                Random.Range(-rotationRandomness, rotationRandomness),
                Random.Range(-rotationRandomness, rotationRandomness)
            );

            float elapsedTime = 0f;
            float duration = 0.5f; 

            Vector3 startPos = slice.position;
            Quaternion startRot = slice.rotation;

            while (elapsedTime < duration)
            {
                slice.position = Vector3.Lerp(startPos, targetPosition, elapsedTime / duration);
                slice.rotation = Quaternion.Slerp(startRot, randomRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            slice.position = targetPosition;
            slice.rotation = randomRotation;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            moveToCut = true; 
        }

        if (moveToCut)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, cutPosition.position, moveSpeed * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, cutPosition.position) < 0.01f)
            {
                moveToCut = false;
            }
        }
    }
}
