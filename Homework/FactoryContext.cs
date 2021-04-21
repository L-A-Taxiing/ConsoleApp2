using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class FactoryContext
    {
        private static FactoryContext instance;//定义一个静态变量来保存类的实例
        private static readonly object locker = new object();//定义一个标识确保线程同步;
        private FactoryContext() { }//定义私有构造函数，使外界不能创建该类实例;

        public static FactoryContext Getinstance() 
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            if (instance==null)//双重否定加一句判断
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (instance == null)
                    {
                        instance = new FactoryContext();
                    }/*else nothing*/
                }
            }
            return instance;
        }










    }
}
//设计一个类FactoryContext，保证整个程序运行过程中，无论如何，外部只能获得它的唯一的一个实例化对象。（提示：设计模式之单例）
