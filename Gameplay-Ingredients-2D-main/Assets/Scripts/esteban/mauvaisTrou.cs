using UnityEngine;

public class mauvaisTrou : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindWithTag("Player")
               .GetComponent<PlayerLife>().Hurt(1);
    
        GameObject.FindWithTag("Player")
               .GetComponent<PlayerMovement>().Respawn();
    
}
}
