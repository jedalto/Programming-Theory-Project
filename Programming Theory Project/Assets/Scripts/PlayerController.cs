using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(Mathf.Cos(75 * Mathf.PI / 180), 0, 1) * Time.deltaTime * horizontalInput * speed);
    }

    public void GameOver()
    {
        speed = 0;
    }
}
