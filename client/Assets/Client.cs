using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;


public class Client : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;

    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        client = new TcpClient("127.0.0.1", 11000);
        stream = client.GetStream();
    }

    public new void SendMessage(string message)
    {
        byte[] messageBytes = Encoding.ASCII.GetBytes(message);
        stream.Write(messageBytes, 0, messageBytes.Length);

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Debug.Log("Ответ сервера: " + response);
    }

    void OnDestroy()
    {
        stream.Close();
        client.Close();
    }
}
