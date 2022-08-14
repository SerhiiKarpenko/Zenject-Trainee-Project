public interface IDamageable
{
    public float CurrentAmountOfHealthPoints { get; set; }
    public void ApplyDamage(float amountOfDamage);
}
