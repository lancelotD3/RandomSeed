using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public float duration = 1f;

    public AnimationCurve curve;
    private bool canShake = true;

    private PlayerMovement playerMovement;

    private void Start()
    {
        
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") && canShake)
        {
            StartCoroutine(Shaking());
        }
        if (playerMovement.GetIsFirstDash())
            canShake = false;
    }

    IEnumerator Shaking()
    {
        Vector2 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitCircle * strenght;
            yield return null;
        }

        transform.position = startPosition;

    }
}
