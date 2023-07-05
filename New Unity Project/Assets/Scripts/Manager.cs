using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public Text Money;
    public Text pay;
    public Text numberRoom;
    public Text chanceToTruble;
    public Text payToTruble;
    public int payTo=0;
    public int numberRoomTo=0;
    public int chanceTo=0;
    public int payTruble=0;
    public int wallet=0;
    public GameObject window;
    


    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = wallet.ToString();
        pay.text = "Я заплачу тебе " + payTo.ToString() + " $";
        numberRoom.text = "Я хочу снять комнату под номером " + numberRoomTo.ToString() + " - сказал проходимец.";
        chanceToTruble.text = " Вы погружаетесь в мысли и уверены " +
                    "что этот человек разгромит ваш номер с вероятностью " + chanceTo.ToString() + " %";
        payToTruble.text = "И вы примерно знаете сколько придется за это заплатить: " + payTruble.ToString() + " $";
    }
    public void ButtonAccept()
    {
        NewBehaviourScript.Instance.Sensitivity = 3;
        if (chanceTo > Random.Range(0, 100))
        {
            MoneyMan(-payTruble);
        }
        else
        {
            MoneyMan(payTo);
        }
        EnemyControllerdf.instance.win = true;
        window.SetActive(false);
        

    }
    public void ButtonDenay()
    {
        NewBehaviourScript.Instance.Sensitivity = 3;
        EnemyControllerdf.instance.loose = true;
        window.SetActive(false);
        
    }
    public void GenerateNewParametrs() // генерирует параметры
    {
        payTo = Random.Range(0, 2000);
        chanceTo = Random.Range(0, 100);
        payTruble = Random.Range(0, 1000);
        numberRoomTo = Random.Range(0, 20);
    }
    public void MoneyMan(int count)
    {
        wallet += count;
    }
}

