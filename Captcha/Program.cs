using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Captcha
{
    public class Program
    {
        static void Main(string[] args)
        {
            //参考一起帮的登录页面，绘制一个验证码图片，存放到当前项目中。验证码应包含：
            //随机字符串
            //混淆用的各色像素点
            //混淆用的直线（或曲线）

            Bitmap image = new Bitmap(1000, 500);//生成一个像素图"画板"
            Graphics g = Graphics.FromImage(image);//在画板的基础上生成一个绘图对象
            Random random = new Random();
            g.Clear(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255), random.Next(255)));//添加随机底色
            g.DrawLine(new Pen(Color.FromArgb(      //画直线
                random.Next(255),
                random.Next(255),
                random.Next(255),
                random.Next(255))),
                new Point(500, 500),
                new Point(1000, 250));
            string character = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(character.Length);
                stringBuilder.Append(character[index]);
            }
            string cartcha = stringBuilder.ToString();   //将StringBuilder对象转换成字符串
            g.DrawString(                  //绘制字符串
                cartcha,
                new Font("楷体", 50),    //指定字体
                new SolidBrush(Color.FromArgb(random.Next(255),random.Next(255), random.Next(255), random.Next(255))),
                //绘制时使用的刷子
                new PointF(10, 10)          //左上角定位
                );
            image.SetPixel(random.Next(1000), random.Next(500), Color.FromArgb
                    (random.Next(255),
                    random.Next(255),
                    random.Next(255), 
                    random.Next(255)));
                   //绘制一个像素的点
            image.SetResolution(72, 92);
            image.Save(@"D:\captcha.jpg", ImageFormat.Jpeg);



            //重构之前的验证码作业：
            //    1.创建一个新的前台线程（Thread），在这个线程上运行生成随机字符串的代码
            //    2.在一个任务（Task）中生成画布
            //    3.使用生成的画布，用两个任务完成：
            //                在画布上添加干扰线条
            //                在画布上添加干扰点
            //    4.将生成的验证码图片异步的存入文件
            //以上作业，需要在控制台输出线程和Task的Id，以演示异步并发的运行。
            Thread current = new Thread(stringbuilder);
            Console.WriteLine(Thread.GetDomain().FriendlyName);
            current.Start();

            Console.WriteLine(current.ManagedThreadId);
            Console.WriteLine(current.Priority);
            Console.WriteLine(current.ThreadState);
            Thread.Sleep(3000);

            Task taskdrawing =Task.Run(getdrawing);


        }

        public static void stringbuilder()
        {
            string character = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int index =new Random().Next(character.Length);
                stringBuilder.Append(character[index]);
            }
            string captcha = stringBuilder.ToString();
            Console.WriteLine(captcha);
        }

        static void getdrawing()
        {
              Bitmap image = new Bitmap(1000, 500);
              Graphics g = Graphics.FromImage(image);
              Random random = new Random();
              g.DrawLine(new Pen(Color.FromArgb(        //画直线
                      random.Next(255),
                      random.Next(255),
                      random.Next(255),
                      random.Next(255))),
                      new Point(500, 500),
                      new Point(1000, 250));
        }











    }
}
