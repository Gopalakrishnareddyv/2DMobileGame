using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] float rotationspeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0,rotationspeed*Time.deltaTime));
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cat")
        {
            EnemySpawn.Instance.StopSpawn();
        }
        else
        {
            StartCoroutine(nameof(Bulletadd));
        }
    }
    
    IEnumerator Bulletadd()
    {
        yield return new WaitForSeconds(1);
        if (rb.gameObject.name == "Enemy")
        {
            EnemySpawn.Instance.addEnemy(rb.gameObject);
        }
    }
}
