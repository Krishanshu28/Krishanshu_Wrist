using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldClickableButton : MonoBehaviour
{
    public GameObject Knife;
    public float speed = 5.0f;
    [SerializeField] private HoldClickableButton _button;

    private void Awake()
    {
        SetEvents();
    }

    private void SetEvents()
    {
        //_button.OnClicked += OnClicked;
        //_button.OnHoldClicked += OnHoldClicked;
    }

    private void OnClicked()
    {
        // TODO: Implement button's click behaviour
    }

    private void OnHoldClicked()
    {
        if (Knife.transform.rotation.z >= -0.3706644)
        {
            Knife.transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
