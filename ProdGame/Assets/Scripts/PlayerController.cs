using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 target;

    // The example prefab to pen when a collision occurs
    // TODO we instead want to call and external function to trigger one of many scripts, we dont wnat to store it locally here
    public GameObject inkExamplePrefab;

    // Is movement enabled, we should disabled when a dialog screen is open
    public bool isEnabled = true;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isEnabled && Input.GetMouseButtonDown(0))
        {
            target = new Vector2(mousePos.x, mousePos.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        // TODO need to reeneable when a script is closeds
        isEnabled = false;
        Instantiate(inkExamplePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
