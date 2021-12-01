using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    private int speed;

    private void Update()
    {
        Vector3 rotation = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        transform.Rotate(rotation * Time.deltaTime * speed);
    }
}
