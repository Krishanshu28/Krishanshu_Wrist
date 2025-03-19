using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool hasCutThisSwing = false; 
    bool isGoingToCut = true;

    void Update()
    {
   
        if (Input.GetKeyUp(KeyCode.W))
        {
            hasCutThisSwing = false;
        }
        if (Input.GetKeyUp(KeyCode.S)) { isGoingToCut = true; }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasCutThisSwing && other.CompareTag("FruitSlice") && isGoingToCut)
        {
            hasCutThisSwing = true; 
            other.GetComponent<SmoothChop>().Chop(); 
            isGoingToCut = false;
        }
    }
}
