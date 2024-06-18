using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
        public Transform pointA; 
       public Transform pointB; 
       public float speed = 2f; 
       public float chaseSpeed = 4f; 
       public Transform player; 
       public float detectionRange = 5f; 
       public GameObject indicatorDetected, indicatorPatrol;
        
       public Transform groundCheck;
       public float groundCheckDistance = 0.5f, wanderingTimer = 3f, hideCountdown = 10f; 
       public LayerMask groundLayer; 
       private Vector3 nextPoint;
       private bool isChasing = false;
       private bool movingRight = true;
        
       private Animator anim;
       
       void Start()
       {    
           nextPoint = pointA.position;
           indicatorDetected.SetActive(false);
           indicatorPatrol.SetActive(true);
           anim = GetComponent<Animator>();
           
          
       }
       void Update()
       {
           if (isChasing)
           {
               ChasePlayer();
               indicatorDetected.SetActive(true);
               indicatorPatrol.SetActive(false);
           }
           else
           {
               Patrol();
               CheckForPlayer();
               indicatorDetected.SetActive(false);
               indicatorPatrol.SetActive(true);
           }
       }
       #region Enemy Behaviours
        //TODO: When the player is not within the aggro radius, the enemy will slowly patrol around the points
     
        void Patrol()
        {
            if (Vector3.Distance(transform.position, nextPoint) < 0.1f || !IsGroundAhead())
            {
                Flip();
                nextPoint = movingRight ? pointB.position : pointA.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        }
       //TODO: Checking the distance of the player by calculating from the enemy's position
       void CheckForPlayer()
       {
           float distanceToPlayer = Vector3.Distance(transform.position, player.position);
           if (distanceToPlayer < detectionRange)
           {
               isChasing = true;
           }
       }
        //TODO: Chase player state and logic
       void ChasePlayer()
       {
           transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
           hideCountdown = 10f;
           float distanceToPlayer = Vector3.Distance(transform.position, player.position);
           if (distanceToPlayer > detectionRange)
           {
               isChasing = false;
               nextPoint = transform.position;
           }
       }
       #endregion
       
       private bool IsGroundAhead()
       {
           return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
       }
        
       private void Flip()
       {
           movingRight = !movingRight;
           Vector3 localScale = transform.localScale;
           localScale.x *= -1;
           transform.localScale = localScale;
       }
       
   
       private void OnDrawGizmosSelected()
       {
           Gizmos.color = Color.red;
           Gizmos.DrawWireSphere(transform.position, detectionRange);
       }
      
}


    
  
