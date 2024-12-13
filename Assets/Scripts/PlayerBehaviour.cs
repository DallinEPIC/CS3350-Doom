using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class PlayerBehaviour : CharacterBehaviour
{
    [HideInInspector] public static PlayerBehaviour instance;
    public AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI _healthText, _armourText, _ammoText;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public override void Die()
    {
        base.Die();
    }
    public void pickupHealth(int hp, bool overHealth) 
    {
        _currentHealth += hp;
        if(_currentHealth > _maxHealth && !overHealth) { _currentHealth = _maxHealth; }
        if (_currentHealth > _maxHealth * 2) { _currentHealth = _maxHealth * 2; }
    }
    public void pickupArmour(int amr, bool overArmour)
    {
        _currentArmour += amr;
        if (_currentArmour > _maxArmour && !overArmour) { _currentArmour = _maxArmour; }
        if (_currentArmour > _maxArmour * 2) { _currentArmour = _maxArmour * 2; }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Door"))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                other.gameObject.GetComponent<DoorBehaviour>().Open();
            }
        }
        if (other.gameObject.CompareTag("Exit"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                other.gameObject.GetComponent<ExitSwitchBehaviour>().Exit();
            }
        }
    }
    void Update()
    {
        int[] healthDigits = GetDigits(_currentHealth);
        int[] armourDigits = GetDigits(_currentArmour);
        int ammo = PlayerWeaponBehaivour.instance.GetAmmo();
        int[] ammoDigits = GetDigits(ammo);
        _healthText.text = "<sprite name=\"" + healthDigits[0] + "\"><sprite name=\"" + healthDigits[1] + "\"><sprite name=\"" + healthDigits[2] + "\"><sprite name=\"%\">";
        _armourText.text = "<sprite name=\"" + armourDigits[0] + "\"><sprite name=\"" + armourDigits[1] + "\"><sprite name=\"" + armourDigits[2] + "\"><sprite name=\"%\">";
        _ammoText.text = "<sprite name=\"" + ammoDigits[0] + "\"><sprite name=\"" + ammoDigits[1] + "\"><sprite name=\"" + ammoDigits[2] + "\">";
    }
    public int[] GetDigits(int number)
    {
        string temp = number.ToString();
        if (temp.Length == 1) temp = "00" + temp;
        if (temp.Length == 2) temp = "0" + temp;
        int[] rtn = new int[3];
        for (int i = 0; i < rtn.Length; i++)
        {
            rtn[i] = temp[i] - '0';
        }
        return rtn;
    }
}
