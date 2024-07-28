using UnityEngine;
using UnityEngine.UI; //สามารถควบคุม ui ได้
using System.Collections;

public class cooldown : MonoBehaviour
{
public Text t; //สร้างตัวแปร t เป็นตัวแทนกล่องข้อความ
public float n; //สร้างตัวแปร n เป็นตัวเลขแบบมีจุดทศนิยม

//วนทำงานตลอด
void Update()
{

n -= Time.deltaTime; // ให้ n มีค่าค่อยๆลดไปทีละ 1 ภายใน 1 วินาที
// t.text = System.Math.Round(n,2).ToString(); //ทศนิยม 2 ตำแหน่ง
t.text = Mathf.Round(n).ToString(); //จำนวนเต็ม

//ถ้า n มีค่าน้อยกว่า หรือเท่ากับ 0
if (n <= 0)
{
t.text = "Time is over"; //แสดงหมดเวลา
}
}

}
