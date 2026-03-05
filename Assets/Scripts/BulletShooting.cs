using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _objectTarget;
    [SerializeField] private float _shotDelay = 2;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds _delay = new WaitForSeconds(_shotDelay);

        while (enabled)
        {
            Vector3 direction = (_objectTarget.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.transform.rotation = Quaternion.LookRotation(direction);
            
            if (bullet.TryGetComponent(out Rigidbody rb))
            {
                rb.velocity = direction * _speed;
            }

            yield return _delay;
        }
    }
}