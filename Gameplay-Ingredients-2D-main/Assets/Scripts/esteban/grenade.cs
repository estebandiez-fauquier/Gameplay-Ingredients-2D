using UnityEngine;

public class grenade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        Invoke("grenadeExplosion", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grenadeExplosion()
    {
        
        GameObject.FindWithTag("Player")
                .GetComponent<PlayerMovement>().grenadeRepulse(this.transform);
        Invoke("destroying", 3.2f);
    }
    

    public void destroying()
    {
        Destroy(gameObject);
    }
}
