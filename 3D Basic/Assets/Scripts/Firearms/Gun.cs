using System.Collections;
using UnityEngine;

public enum State // <- int 와 내부적으로 같음
{
    Ready,
    Empty,
    Reloading
}


public class Gun : MonoBehaviour
{

    public      State           state { get; private set; }
    public      Transform       firePos;
    public      ParticleSystem  muzzleFlashEffect;
    public      ParticleSystem  shellEjectEffect;
    public      float           bulletLineEffectTime    = 0.03f;

    public      LineRenderer    bulletLineRenderer;
    public      float           damage                  = 25.0f;
    public      float           fireDistance            = 50.0f;
    public      int             magCap                  = 10;
    public      int             magAmmo;                            // 현제 장전된 탄환수
    public      float           timeBetFire             = 0.12f;    // 발사딜레이
    public      float           reloadTIme              = 1.0f;
    private     float           lastfireTime;                       // 마지막 총 발사 시간

    [Header("Audio Clips")]
    public AudioClip reloadSound;
    public AudioClip fireSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        magAmmo = magCap;
        state = State.Ready;
        lastfireTime = 0;
    }

    public void Fire() // 명령 내리는 함수. true 시 Shot()
    {
        if(state == State.Ready && Time.time >= lastfireTime + timeBetFire)
        {
            lastfireTime = Time.time;
            Shot();
        }
    }

    private void Shot()
    {
        audioSource.clip = fireSound; // TODO : 풀링
        audioSource.Play();
        RaycastHit hit; // 수행평가
        Vector3 hitPos = Vector3.zero;
        if (Physics.Raycast(firePos.position, firePos.forward, out hit, fireDistance))
        {
            IDamageable target = hit.transform.GetComponent<IDamageable>();
            if(target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPos = hit.point;
        }
        else
        {
            hitPos = firePos.position + firePos.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPos));
        
        --magAmmo;
        if(magAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    private IEnumerator ShotEffect(Vector3 hitPos)
    {
        muzzleFlashEffect.Play();
        shellEjectEffect.Play();
        bulletLineRenderer.SetPosition(1, bulletLineRenderer.transform.InverseTransformPoint(hitPos));
        bulletLineRenderer.gameObject.SetActive(true);
        yield return new WaitForSeconds(bulletLineEffectTime);
        bulletLineRenderer.gameObject.SetActive(false);
    }

    public bool Reload()
    {
        if(state == State.Reloading || magAmmo >= magCap)
        {
            return false;
        }

        StartCoroutine(ReloadRoutine());
        return true;
    }

    public IEnumerator ReloadRoutine()
    {
        audioSource.clip = reloadSound;
        audioSource.Play();

        state = State.Reloading;
        yield return new WaitForSeconds(reloadTIme);
        magAmmo = magCap;
        state = State.Ready;
    }

}
