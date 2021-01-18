

using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Button : MonoBehaviour/*, IEnumerable*/
{
    public static int count = 0;
    int position;
   
    public GameObject GameObjectButton { get; set; }
    public string buttonName { get; set; }
    public bool buttonActive { get; set; }



   
    //public Button(GameObject button, string name, bool active)
    //{
    //    Interlocked.Increment(ref count);
    //    GameObjectButton = button;
    //    buttonName = name;
    //    buttonActive = active;
      
    //}
    //~Button()
    //{
    //    Interlocked.Decrement(ref count);
    //}


   
    void changeGravity()
    {
        GameObjectButton.GetComponent<Rigidbody>().useGravity = buttonActive;
    }
   public void setActive(bool active) {
        buttonActive = active;
        changeGravity();
        
    }

    public static void loadLevel(string name) {
        Destroy(GameObject.FindWithTag("Finish").GetComponent<Char_colour>());
        Application.LoadLevel(name);
        Strileni.setDefaultValues();
        health.setDefaultValues();
        score.setDefaultValues();
        spawn_enemy.setDefaultValues();
        hpBar.hpBarSize();
    }





    //public IEnumerator GetEnumerator()
    //{
    //    return new ButtonEnumerator(this);
    //}


}
// class ButtonEnumerator : IEnumerator
//{
//    private int position = -1;
//    private Button b;

//    public ButtonEnumerator(Button b)
//    {
//        this.b = b;
//    }

//    // The IEnumerator interface requires a MoveNext method.
//    public bool MoveNext()
//    {
//        if (position < Button.count - 1)
//        {
//            position++;
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    // The IEnumerator interface requires a Reset method.
//    public void Reset()
//    {
//        position = -1;
//    }

//    // The IEnumerator interface requires a Current method.
//    public object Current
//    {
//        get
//        {
//            return b.(position);
//        }
//    }
//}

