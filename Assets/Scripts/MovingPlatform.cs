using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public int startingPoint;   //starting index of the starting pos

    public Transform[] points;      //an array of points
    public Vector3[] pointPos;
    private int i;
    private bool isActivated;
  
    public void InitMoving(Vector3[] movingPoint)
    {
        pointPos = movingPoint;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //setting the position of the platform
        //to the position of the points using index
        transform.position = points[startingPoint].position;    
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!isActivated) return;

        OnPlatformMove();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
    public void OnPlatformMove()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02)
        {
            i++;
            if (i == points.Length) // Check if the platform is on the last point or not
            //If it does then reset the points
            {
                i = 0;
            }
        }
        //Moving the platform
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    public void OnActivePlatform(bool active)
    {
        isActivated = active;
    }
}
