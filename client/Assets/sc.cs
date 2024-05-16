using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Purchasing.MiniJSON;
using Newtonsoft.Json;
using UnityEngine.UIElements;

public class sc : MonoBehaviour
{
    bool checker = true; // чтобы первый ход был крестиком
    public int step = 0;
    int plusone;
    public List<List<int>> table = new List<List<int>>();

    Dictionary<int, string> dict = new Dictionary<int, string>()
    {
    { 0, ""},
    { 1, "X"},
    { 2, "O"}
    };

    public Text btnText1 = null;
    public Text btnText2 = null;
    public Text btnText3 = null;
    public Text btnText4 = null;
    public Text btnText5 = null;
    public Text btnText6 = null;
    public Text btnText7 = null;
    public Text btnText8 = null;
    public Text btnText9 = null;
    public Canvas canvas = null;
    public Websockets websockets = null;

    public Text btnResetGame = null;
    public Text btnNewGame = null;
    public Text msgFeedback = null;

    public Text txtPlayerX;
    public Text txtPlayerO;

    public class Message
    {
        public string type;
        public string messageBody;
    }

    public void score()
    {
        if (btnText1.text == "X" && btnText2.text == "X" && btnText3.text == "X")
        {
            btnText1.color = Color.red;
            btnText2.color = Color.red;
            btnText3.color = Color.red;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText1.text == "X" && btnText4.text == "X" && btnText7.text == "X")
        {
            btnText1.color = Color.blue;
            btnText4.color = Color.blue;
            btnText7.color = Color.blue;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText1.text == "X" && btnText5.text == "X" && btnText9.text == "X")
        {
            btnText1.color = Color.green;
            btnText5.color = Color.green;
            btnText9.color = Color.green;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText3.text == "X" && btnText5.text == "X" && btnText7.text == "X")
        {
            btnText3.color = Color.grey;
            btnText5.color = Color.grey;
            btnText7.color = Color.grey;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText2.text == "X" && btnText5.text == "X" && btnText8.text == "X")
        {
            btnText2.color = Color.yellow;
            btnText5.color = Color.yellow;
            btnText8.color = Color.yellow;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText3.text == "X" && btnText6.text == "X" && btnText9.text == "X")
        {
            btnText3.color = Color.cyan;
            btnText6.color = Color.cyan;
            btnText9.color = Color.cyan;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText4.text == "X" && btnText5.text == "X" && btnText6.text == "X")
        {
            btnText4.color = Color.green;
            btnText5.color = Color.green;
            btnText6.color = Color.green;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        if (btnText7.text == "X" && btnText8.text == "X" && btnText9.text == "X")
        {
            btnText7.color = Color.blue;
            btnText8.color = Color.blue;
            btnText9.color = Color.blue;
            msgFeedback.text = "The Winner is Player X"; plusone = int.Parse(txtPlayerX.text);
            txtPlayerX.text = Convert.ToString(plusone + 1);
        }
        //------------------------------------------------------------------------------------

        if (btnText1.text == "O" && btnText2.text == "O" && btnText3.text == "O")
        {
            btnText1.color = Color.red;
            btnText2.color = Color.red;
            btnText3.color = Color.red;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText1.text == "O" && btnText4.text == "O" && btnText7.text == "O")
        {
            btnText1.color = Color.blue;
            btnText4.color = Color.blue;
            btnText7.color = Color.blue;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText1.text == "O" && btnText5.text == "O" && btnText9.text == "O")
        {
            btnText1.color = Color.green;
            btnText5.color = Color.green;
            btnText9.color = Color.green;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText3.text == "O" && btnText5.text == "O" && btnText7.text == "O")
        {
            btnText3.color = Color.grey;
            btnText5.color = Color.grey;
            btnText7.color = Color.grey;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText2.text == "O" && btnText5.text == "O" && btnText8.text == "O")
        {
            btnText2.color = Color.yellow;
            btnText5.color = Color.yellow;
            btnText8.color = Color.yellow;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText3.text == "O" && btnText6.text == "O" && btnText9.text == "O")
        {
            btnText3.color = Color.cyan;
            btnText6.color = Color.cyan;
            btnText9.color = Color.cyan;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText4.text == "O" && btnText5.text == "O" && btnText6.text == "O")
        {
            btnText4.color = Color.green;
            btnText5.color = Color.green;
            btnText6.color = Color.green;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
        if (btnText7.text == "O" && btnText8.text == "O" && btnText9.text == "O")
        {
            btnText7.color = Color.blue;
            btnText8.color = Color.blue;
            btnText9.color = Color.blue;
            msgFeedback.text = "The Winner is Player O"; plusone = int.Parse(txtPlayerO.text);
            txtPlayerO.text = Convert.ToString(plusone + 1);
        }
    }
    public void SendStepToServer()
    {
        Message message = new Message();
        message.type = "step";
        message.messageBody = JsonConvert.SerializeObject(step);
        var json = JsonConvert.SerializeObject(message);
        websockets.websocket.SendText(json);
    }

    public void SendTableToServer()
    {
        Message message = new Message();
        message.type = "table";
        message.messageBody = JsonConvert.SerializeObject(table);
        var json = JsonConvert.SerializeObject(message);
        websockets.websocket.SendText(json);

    }

    public void SetTableFromServer(List<List<int>> tableFromServer)
    {
        GameObject panel = GameObject.Find("Panel_2");
        table = tableFromServer;
        for(int i = 0; i < panel.transform.childCount; i++)
        {
            Text cell = panel.transform.GetChild(i).GetChild(0).GetComponent<Text>();
            cell.text = $"{dict[table[i/3][i%3]]}";
        }
        score();
    }

    public void PrintTable()
    {
        for(int i = 0; i < table.Count; i++)
        {
            for(int j = 0; j < table[i].Count; j++)
            {
                Debug.Log(table[i][j].ToString());
            }
            Debug.Log("\n");    
        }
    }

    public void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            List<int> temp = new List<int>();
            for(int j = 0; j < 3; j++)
            {
                temp.Add(0);
            }
            table.Add(temp);
        }
        websockets = canvas.GetComponent<Websockets>();
    }

    public void MakeTable(Text cell, int x, int y)
    {
        if(cell.text == "")
        {
            table[x][y] = 0;
        }
        if(cell.text == "X")
        {
            table[x][y] = 1;
        }
        if(cell.text == "O")
        {
            table[x][y] = 2;
        }
    }
    public void btnText1_Click()
    {
        if (step % 2 == 0)
        {
            btnText1.text = "X";
        }
        else
        {
            btnText1.text = "O";
        }
        score();
        MakeTable(btnText1, 0, 0);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker; // Переключаем значение checker после обработки хода
    }

    public void btnText2_Click()
    {
        if (step % 2 == 0)
        {
            btnText2.text = "X";
        }
        else
        {
            btnText2.text = "O";
        }
        score();
        MakeTable(btnText2, 0, 1);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText3_Click()
    {
        if (step % 2 == 0)
        {
            btnText3.text = "X";
        }
        else
        {
            btnText3.text = "O";
        }
        score();
        MakeTable(btnText3, 0, 2);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText4_Click()
    {
        if (step % 2 == 0)
        {
            btnText4.text = "X";
        }
        else
        {
            btnText4.text = "O";
        }
        score();
        MakeTable(btnText4, 1, 0);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText5_Click()
    {
        if (step % 2 == 0)
        {
            btnText5.text = "X";
        }
        else
        {
            btnText5.text = "O";
        }
        score();
        MakeTable(btnText5, 1, 1);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText6_Click()
    {
        if (step % 2 == 0)
        {
            btnText6.text = "X";
        }
        else
        {
            btnText6.text = "O";
        }
        score();
        MakeTable(btnText6, 1, 2);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText7_Click()
    {
        if (step % 2 == 0)
        {
            btnText7.text = "X";
        }
        else
        {
            btnText7.text = "O";
        }
        score();
        MakeTable(btnText7, 2, 0);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText8_Click()
    {
        if (step % 2 == 0)
        {
            btnText8.text = "X";
        }
        else
        {
            btnText8.text = "O";
        }
        score();
        MakeTable(btnText8, 2, 1);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }

    public void btnText9_Click()
    {
        if (step % 2 == 0)
        {
            btnText9.text = "X";
        }
        else
        {
            btnText9.text = "O";
        }
        score();
        MakeTable(btnText9, 2, 2);
        SendTableToServer();
        step++;
        SendStepToServer();
        checker = !checker;
    }
    
    public void btnResetGame_Click()
    {
        btnText1.text = "";
        btnText2.text = "";
        btnText3.text = "";
        btnText4.text = "";
        btnText5.text = "";
        btnText6.text = "";
        btnText7.text = "";
        btnText8.text = "";
        btnText9.text = "";

        btnText1.color = Color.black;
        btnText2.color = Color.black;
        btnText3.color = Color.black;
        btnText4.color = Color.black;
        btnText5.color = Color.black;
        btnText6.color = Color.black;
        btnText7.color = Color.black;
        btnText8.color = Color.black;
        btnText9.color = Color.black;

        table = new List<List<int>>();
        for (int i = 0; i < 3; i++)
        {
            List<int> temp = new List<int>();
            for (int j = 0; j < 3; j++)
            {
                temp.Add(0);
            }
            table.Add(temp);
        }

        SendTableToServer();
        
        step = 0;

        SendStepToServer();

        checker = true; // Установите checker обратно в true, чтобы первый ход после сброса будет крестиком
    }

    public void btnNewGame_Click()
    {
        btnResetGame_Click();
        txtPlayerX.text = "";
        txtPlayerO.text = "";

        checker = true; // Установите checker обратно в true, чтобы первый ход новой игры будет крестиком
    }
}
