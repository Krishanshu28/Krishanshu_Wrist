using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class SmoothChop : MonoBehaviour
{
    private bool isChopped = false;
    public Transform cutDestination; 
    public GameObject parentFruit;
    public float moveSpeed = 5f;
    public float shiftDistance = 0.2f; 
    public float shiftDuration = 0.2f; 
    public bool hasReached = false;
    MoveToCutPosition moveToCutPosition;

    private void Start()
    {
        moveToCutPosition = parentFruit.GetComponent<MoveToCutPosition>();
    }
    public void Chop()
    {
        if (isChopped) return;
        isChopped = true;

        GetComponent<Collider>().enabled = false;

        StartCoroutine(MoveToChopPosition());
        moveToCutPosition.RegisterSliceChop();

        
    }


    IEnumerator MoveToChopPosition()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = cutDestination.position;
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        Rigidbody rb = GetComponent<Rigidbody>();
        //rb.isKinematic = false;
        rb.useGravity = true;
        StartCoroutine(ShiftRemainingSlices());
    }


    IEnumerator ShiftRemainingSlices()
    {
        List<Transform> remainingSlices = new List<Transform>();

        foreach (Transform slice in parentFruit.transform)
        {
            if (slice != this.transform && !slice.GetComponent<SmoothChop>().isChopped)
            {
                remainingSlices.Add(slice);
            }
        }

        Vector3 startPos, targetPos;
        float elapsedTime;

        foreach (Transform slice in remainingSlices)
        {
            startPos = slice.position;
            targetPos = startPos + new Vector3(shiftDistance, 0, 0);
            elapsedTime = 0f;

            while (elapsedTime < shiftDuration)
            {
                slice.position = Vector3.Lerp(startPos, targetPos, elapsedTime / shiftDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            slice.position = targetPos;
        }
    }
}
