using UnityEngine;
using System;
using TMPro;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	public float CurrentAmountOfHealthPoints { get; set; }
	public float Damage = 1f;
	public event Action OnPlayerDeath = null;
	public event Action<float> OnPlayerAttacked = null;
	[SerializeField] private TextMeshProUGUI _playerHealthPointsText;
	private float _maxAmountOfHealthPoints = 3;
	
	private void Start()
	{
		CurrentAmountOfHealthPoints = _maxAmountOfHealthPoints;
		_playerHealthPointsText.text = _maxAmountOfHealthPoints.ToString();
		OnPlayerAttacked += ChangePlayerHpText;
		OnPlayerDeath += Death;
	}
	private void OnDestroy()
	{
		OnPlayerAttacked -= ChangePlayerHpText;
		OnPlayerDeath -= Death;
	}

	public void ApplyDamage(float amountOfDamage)
	{
		CurrentAmountOfHealthPoints -= amountOfDamage;
		OnPlayerAttacked?.Invoke(CurrentAmountOfHealthPoints);
		if (CurrentAmountOfHealthPoints <= 0) OnPlayerDeath?.Invoke();
	}

	private void Death()
	{
		Destroy(gameObject);
	}

	private void ChangePlayerHpText(float amountOfHp)
    {
		_playerHealthPointsText.text = "Player Health: " + amountOfHp.ToString();
    }

}

