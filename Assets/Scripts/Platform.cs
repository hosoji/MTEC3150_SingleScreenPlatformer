using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 5;
    private int direction = 1;

    public float moveDuration = 4;

    private float timeSinceDirectionSwitch;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceDirectionSwitch < moveDuration)
        {
            timeSinceDirectionSwitch += Time.deltaTime;
        }
        else
        {
            ChangeDirection();
            timeSinceDirectionSwitch = 0;
        }

        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        
    }

    private void ChangeDirection()
    {
        direction *= -1;
    }
}
