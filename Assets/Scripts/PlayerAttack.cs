using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    // Update is called once per frame
    [SerializeField] private GameObject projectile;
    private float projectileForce = 10;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        }
    }
}
