using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;

    float h, v;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(h, v) * speed;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("´ê¾Ò´Ù." + collision.gameObject.name);
    }

}
