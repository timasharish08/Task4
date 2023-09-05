using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;

    private Coroutine _changerHealthBarValue;
    private WaitForEndOfFrame _wait;

    private void Awake()
    {
        _wait = new WaitForEndOfFrame();
    }

    public void OnHealthChanged()
    {
        if (_changerHealthBarValue != null)
            StopCoroutine(_changerHealthBarValue);

        _changerHealthBarValue = StartCoroutine(ChangeHealthBarValue(_wait));
    }

    private void OnEnable()
    {
        _player.HeathChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HeathChanged -= OnHealthChanged;
    }

    private IEnumerator ChangeHealthBarValue(WaitForEndOfFrame wait)
    {
        while (_healthBar.value != _player.HealthRatio)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.HealthRatio, Time.deltaTime);
            yield return wait;
        }
    }
}
