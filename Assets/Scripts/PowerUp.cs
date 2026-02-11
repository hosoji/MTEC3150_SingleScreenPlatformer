using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected SpriteRenderer sr;
    public Color powerUpColor;
    protected PlayerController player;
    private bool effectsApplied = false;
    public float effectDuration;
    private float timeElapsedSinceEffect;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = powerUpColor;
        
    }

    public virtual void ApplyEffect()
    {
        //Destroy(gameObject);
        sr.enabled = false;
        effectsApplied = true;
    }

    private void Update()
    {
        if (effectsApplied)
        {
            if(timeElapsedSinceEffect < effectDuration)
            {
                timeElapsedSinceEffect += Time.deltaTime;
            }
            else
            {
                timeElapsedSinceEffect = 0;
                NegateEffect();
                effectsApplied = false;
                Destroy(gameObject);

            }
        }
    }


    protected virtual void NegateEffect()
    {

    }
}

