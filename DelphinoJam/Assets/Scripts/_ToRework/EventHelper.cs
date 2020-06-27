using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHelper : MonoBehaviour
{
    public MyIntEvent m_MyEvent;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new MyIntEvent();

        m_MyEvent.AddListener(Ping);
    }

    void Update()
    {
        //if (Input.anyKeyDown && m_MyEvent != null)
        //{
        //    m_MyEvent.Invoke(5, 6, 7, 8);
        //}
    }

    public void Ping(int i, int j, int k, int l)
    {
        Debug.Log("Ping" + i + j + k + l);
    }
}

[System.Serializable]
public class MyIntEvent : UnityEvent<int, int, int, int>
{

}