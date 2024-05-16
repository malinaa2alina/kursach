using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NativeWebSocket;
using Newtonsoft.Json;

public class Websockets : MonoBehaviour
{
    public WebSocket websocket;

    void Start()
    {
        websocket = new WebSocket("ws://localhost:8080/chat");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open! Second client has connected to the server.");
            Message message = new Message();
            message.type = "newUser";
            message.messageBody = "Привет, это второй клиент!";
            websocket.SendText(JsonConvert.SerializeObject(message));
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
            Message message = JsonConvert.DeserializeObject<Message>(System.Text.Encoding.UTF8.GetString(bytes));
            if(message.type == "table")
            {
                GameObject table = GameObject.Find("btnGameObject");
                sc sc = table.GetComponent<sc>();
                sc.SetTableFromServer(JsonConvert.DeserializeObject<List<List<int>>>(message.messageBody));
            }
            else if (message.type == "step")
            {
                GameObject table = GameObject.Find("btnGameObject");
                sc sc = table.GetComponent<sc>();
                sc.step = JsonConvert.DeserializeObject<int>(message.messageBody);
            }
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
        websocket.DispatchMessageQueue();
    }

    void OnDestroy()
    {
        _ = websocket.Close();
    }
}
