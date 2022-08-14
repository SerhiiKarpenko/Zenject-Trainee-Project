using UnityEngine;

class EnemyHealth : MonoBehaviour, IDamageable
{
    public float CurrentAmountOfHealthPoints { get; set; } = 1;

    public void ApplyDamage(float amountOfDamage)
    {
        Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}

