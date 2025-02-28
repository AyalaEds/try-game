using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;

    private List<Key.KeyType> keylist;

    private void Awake()
    {
        keylist = new List<Key.KeyType>();
    }

    public List<Key.KeyType> Getkeylist()
    {
        return keylist;
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key " + keyType);
        keylist.Add(keyType);

        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        Debug.Log("Remove Key " + keyType);
        keylist.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keylist.Contains(keyType);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                keyDoor.OpenDoor();
                RemoveKey(keyDoor.GetKeyType());
            }
        }
    }
}
