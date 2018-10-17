using NBitcoin;
using System;
using System.Linq;

namespace NBitcoinWitnessTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var hex = "010000000001010c40d5de5c92e6955ae9d179662861a9135a45be4bdf400cbef940234a3677b80300000000ffffffff012e564c000000000017a914179d70416808151aef57ad01509434888265eac18702473044022071f6626ae91e434736bf0f5758fadc8b0169592ae00123c66ba5028d637d74bc02206b4578cbaff809ba2106c0bea1379c15cfda5b6d4b5cb0eacdcd87b96c5aff0d012102e882f36a623a6554b7dd8847efa2ccfdc5f6ee2b15e54c91e46e9ee986a3c71400000000";
            var tx = Transaction.Parse(hex, Network.Main);

            Console.WriteLine(tx.ToString());
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"tx.HasWitness: {tx.HasWitness}");
            Console.WriteLine($"tx.Outputs.Any(x => x.ScriptPubKey.IsWitness): {tx.Outputs.Any(x => x.ScriptPubKey.IsWitness)}");
            Console.WriteLine($"tx.SpendsOrReceivesWitness(): {tx.SpendsOrReceivesWitness()}");

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static bool SpendsOrReceivesWitness(this Transaction me) => me.HasWitness || me.Outputs.Any(x => x.ScriptPubKey.IsWitness);
    }
}
