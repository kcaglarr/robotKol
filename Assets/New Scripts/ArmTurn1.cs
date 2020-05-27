using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;

public class ArmTurn1 : MonoBehaviour
{
    public Text displayValues;

    int armEulerAngle = 270;

    int acifarki;

    bool dondurAktif = false;
    bool bittiMi = true;

    float m_TurnSpeed = 30;
    float m_TurnInputValue = 40;

    public int asama = 0;


    private void Update()
    {
        xml();
        if (dondurAktif)
        {
            armEulerAngle = (int)this.transform.localEulerAngles.y; //robot kolun dönme bilgisini integerda saklıyoruz

            if (armEulerAngle != (int)m_TurnInputValue)
                this.transform.Rotate(Vector3.up, m_TurnSpeed * Time.deltaTime);                //döndürme

            displayValues.text = "Anlık Açı:" + armEulerAngle.ToString() + "\nDönme Hızı:" + m_TurnSpeed.ToString() + "\nxml verisi" + m_TurnInputValue.ToString(); //xml'den gelen verileri ekrana yazdırdım.

            if (acifarki < 30) m_TurnSpeed = 10;
            else m_TurnSpeed = 40;

            bittiMi = false;


            if (armEulerAngle == m_TurnInputValue)
            {
                dondurAktif = false;
                bittiMi = true;
            }

            if (bittiMi == true)
            {
                asama++;
                if (asama == 1) dondurAktif = true;
            }
        }
        Debug.Log(asama);
        acifarki = (int)Mathf.Abs(m_TurnInputValue - armEulerAngle);
    }

    public void yap() //animator kontrol işlemi başlatır
    {
        asama = 0;
        dondurAktif = true;
    }


    public void xml()
    {
        XMLRobot robo = XMLOp.Deserialize<XMLRobot>("imported.xml");

        if (asama == 0)
        {
            m_TurnInputValue = robo.rotationGrab1;
        }
        if (asama == 1)
        {
            m_TurnInputValue = robo.rotationDrop1;
        }
    }
}
