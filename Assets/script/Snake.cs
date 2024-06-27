using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public ui gameUI;
    Vector3 direction;
    [SerializeField] float speed = 0.1f;
    [SerializeField] Transform bodyPrefab;
    public List<Transform> bodies = new List<Transform>();
    private void Start()
    {
        Time.timeScale = speed;
        Reset();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector3.right;
        }

    }

    private void FixedUpdate()
    {
        for (int i = bodies.Count-1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;
        }
        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("food"))
        {
            bodies.Add(Instantiate(bodyPrefab
                , transform.position
                , Quaternion.identity));
            gameUI.AddScore();

        }
        if (collision.CompareTag("obstacle"))
        {
            Reset(); 
        }
    }
    private void Reset()
    {
        transform.position = Vector3.zero;
        direction = Vector3.zero;

        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        bodies.Clear();
        bodies.Add(transform);
        gameUI.ResetScore();
    }
}
