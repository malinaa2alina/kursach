using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NativeWebSocket;

public class Websockets : MonoBehaviour
{
    private WebSocket websocket;

    void Start()
    {
        websocket = new WebSocket("ws://localhost:8080/chat");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open! Second client has connected to the server.");
            websocket.SendText("Привет, это второй клиент!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
            Debug.Log("Second client did not connect to the server.");
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {
            Debug.Log("Second client received: " + System.Text.Encoding.UTF8.GetString(bytes));
        };

        _ = websocket.Connect();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            websocket.SendText("Привет, это второй клиент!");
        }
    }

    void OnDestroy()
    {
        _ = websocket.Close();
    }
}
