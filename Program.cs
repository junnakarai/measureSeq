using System;
using System.Collections.Generic;
using System.Linq;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r1 = new Random();
            var measTemp = new int[100];
            var measHumidity = new int[100];
            var measAir = new int[100];
            for (int i = 0; i < 100; i++)
            {
                measTemp[i] = r1.Next(0,39);             
                measHumidity[i] = r1.Next(50,100);             
                measAir[i] = r1.Next(1000,1100);             
            }

            var meas = new List<Parameter>{
                new Temp(measTemp),
                new Humidity(measHumidity),
                new Air(measAir),
            };

            foreach (Parameter parameter in meas)
            {
                Console.WriteLine("Ave:"+parameter.calAve);
                Console.WriteLine("Max:"+parameter.calMax);
                Console.WriteLine("Min:"+parameter.calMin);
            }
        }
    }

    //測定値 抽象クラス
    public abstract class Parameter
    {
        public int[] x;
        public virtual int calAve => 0;
        public virtual int calMax => 0;
        public virtual int calMin => 0;
    }

    //ラムダ式
    public class Air : Parameter{
        private int[] air;
        public Air(int[] air) => this.air = air;
        public override int calAve => (int)this.air.Average();
        public override int calMax => this.air.Max();
        public override int calMin => this.air.Min();
    }

    public class Temp : Parameter{
        public Temp(int[] temp) => x = temp;
        public override int calMax => x.Max();
        public override int calMin => x.Min();
        public override int calAve => (int)x.Average();
    }

    public class Humidity : Parameter{
        public Humidity(int[] humidity){
            x = humidity;
        }
        public override int calAve => 0;
    }
}
