using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehaviour _DB;

    [SerializeField] bool _isDoorOpenSwitch;
    [SerializeField] bool _isDoorClosedSwitch;

    // References
    float _switchSizeY;
    Vector3 _switchUpPos;
    Vector3 _switchDownPos;
    float _switchSpeed = 1f;
    float _switchDelay = 0.2f;
    bool _isPressingSwitch = false;

    // Keys
    bool _isDoorLocked = true;

    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2; //pressure for the player

        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x, transform.position.y - _switchSizeY, transform.position.z); // how much pressure goes onto the switch
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!_isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }
    void MoveSwitchDown()
    {

        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }
    void MoveSwitchUp()
    {

        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPressingSwitch = !_isPressingSwitch;

            if (!_isDoorLocked)
            {

                if (_isDoorOpenSwitch && !_DB._isDoorOpen)
                {
                    _DB._isDoorOpen = !_DB._isDoorOpen;
                }
                else if (_isDoorClosedSwitch && _DB._isDoorOpen)
                {
                    _DB._isDoorOpen = !_DB._isDoorOpen;
                }

            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }


    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressingSwitch = false;
    }

    public void DoorLockedStatus()
    {
        _isDoorLocked = !_isDoorLocked;
    }
}
