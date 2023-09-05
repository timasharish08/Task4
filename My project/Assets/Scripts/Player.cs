using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction HeathChanged;

    [SerializeField] private float _maxHealth;

    private float _health;

    public float HealthRatio => _health / _maxHealth;

    private void Start()
    {
        _health = _maxHealth;

        if (HeathChanged != null)
            HeathChanged.Invoke();
    }

    public void Heal(float heal)
    {
        _health = Mathf.Clamp(_health + heal, 0, _maxHealth);

        if (HeathChanged != null)
            HeathChanged.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);

        if (HeathChanged != null)
            HeathChanged.Invoke();
    }
}
