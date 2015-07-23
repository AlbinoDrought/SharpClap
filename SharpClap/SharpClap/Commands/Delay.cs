using System;
using System.Threading.Tasks;

namespace SharpClap.Commands
{

    public class Delay : Command
    {
        public double Value = 0.00;

        private static Random random = new Random();

        public double ValueModifier = 0.00;

        private bool UseRandomRange
        {
            get
            {
                return ValueModifier != 0.00;
            }
        }

        // blank constructor necessary for serialization
        public Delay()
        {
            
        }

        public Delay(double value, double modifier = 0.00)
        {
            this.Value = value;
            this.ValueModifier = modifier;
        }

        public override string ToString()
        {
            string delay = Value.ToString("##.00") + "s";

            if (UseRandomRange)
            {
                string randomMaxAsSeconds = this.GetRandomMax().ToString("##.00") + "s";
                delay+= "-" + randomMaxAsSeconds;
            }
            return delay + " delay";
        }

        private double GetRandomMax()
        {
            return Value + ValueModifier;
        }

        public async override Task<string> Execute()
        {
            double waitValue = Value;

            if (UseRandomRange)
            {
                waitValue = random.NextDouble(Value, this.GetRandomMax());
            }

            await Task.Delay((int)(waitValue * 1000.00));
            return "Finished waiting " + waitValue.ToString("##.00") + "s";
        }
    }
}
