using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    Animator anim;
    public float bounce;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isPlayerSteppedOn", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySoundEffect("BouncePad_SFX");
        }
        if (collision.gameObject.CompareTag("PushableObj"))
        {
            anim.SetBool("isPlayerSteppedOn", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
 
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(StopAnimation());        
    }
    IEnumerator StopAnimation()
    {

        yield return new WaitForSeconds(.25f);
        anim.SetBool("isPlayerSteppedOn", false);
    }
    
}
