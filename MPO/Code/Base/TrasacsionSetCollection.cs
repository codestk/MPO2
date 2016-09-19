using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stk.DB
{
    public class TransactionSetCollection : IEnumerable
    {
  
            public ArrayList arr = new ArrayList();
            public TransactionSet GetTransactionSetList(int i)
            {
                return (TransactionSet)arr[i]; //แสดงข้อมูลในตำแหน่ง ที่ i
            }
            public void AddTransactionSet(TransactionSet p)
            {
                arr.Add(p); // เพื่ม ข้อมูลชนิด object ของคลาส Person เข้าไปใน ArrayList
            }
            public int CountTransactionSet
            {
                get
                {
                    return arr.Count; // นับจำนวนสมาชิกใน ArrayList
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return arr.GetEnumerator(); //สำหรับการวนลูปโดยใช้ foreach
            }
 

    }
}