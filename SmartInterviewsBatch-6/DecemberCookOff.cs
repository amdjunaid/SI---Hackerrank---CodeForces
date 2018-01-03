using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class DecemberCookOff : ISolution
    {
        public override void Solve()
        {
            int t = ReadInt();
            while (t-- > 0) {
                int n = ReadInt();
                List<string> input = new List<string>(n);
                for (int i = 0; i < n; i++) {
                    input.Add(ReadString());
                }
                 output.AppendLine(WhoWonTheMatch(input.ToArray()));
            }
            Console.Write(output);
        }

        private string WhoWonTheMatch(string[] arr)
        {
            Dictionary<string, int> scoreCard = new Dictionary<string, int>();
            foreach (var teamName in arr)
            {
                if (scoreCard.ContainsKey(teamName))
                {
                    scoreCard[teamName]++;
                }
                else {
                    scoreCard.Add(teamName, 1);
                }
            }
            var keys = scoreCard.Keys.ToArray();
            if (scoreCard.Keys.Count == 1)
            {
                return keys[0];
            }
            else {
                var values = scoreCard.Values.ToArray();
                if (values[0] > values[1])
                {
                    return keys[0];
                }
                else if (values[0] < values[1])
                {
                    return keys[1];
                }
                else {
                    return "Draw";
                }
            }
        }
    }
}
