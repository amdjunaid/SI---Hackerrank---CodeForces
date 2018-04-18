using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators
{
        public class Rubies
        {
            public string color;
            public List<string> successor;
            public int count;
            public bool hasTail;
            public Rubies() { }
            public Rubies(string c, List<string> list, int n)
            {
                this.color = c;
                this.count = n;
                this.successor = list.ToList();
                hasTail = false;
            }
        }
        class RubyNecklace
        {
            public static void Titanic()
            {
                Dictionary<string, Rubies> rubies = new Dictionary<string, Rubies> { };
                string red = "red", blue = "blue", green = "green", yellow = "yellow";
                rubies.Add(blue, new Rubies(blue, new List<string> { blue, red }, int.Parse(Console.ReadLine().Trim())));
                rubies.Add(red, new Rubies(blue, new List<string> { green, yellow }, int.Parse(Console.ReadLine().Trim())));
                rubies.Add(yellow, new Rubies(blue, new List<string> { blue, red }, int.Parse(Console.ReadLine().Trim())));
                rubies.Add(green, new Rubies(blue, new List<string> { green, yellow }, int.Parse(Console.ReadLine().Trim())));
                rubies = updateBoolsInDictionary(rubies);
                int length = 0;
                List<string> tempList = new List<string> { };
                StringBuilder necklace = new StringBuilder();
                string LastAppended = "";
                if ((rubies[red].count != 0 && rubies[blue].count != 0) || (rubies[red].count == 0 && rubies[blue].count != 0))
                {
                    necklace.Append(blue);
                    LastAppended = blue;
                    length++;
                    rubies[blue].count--;
                    rubies = updateBoolsInDictionary(rubies);
                }
                else if (rubies[red].count == 0 && rubies[blue].count == 0)
                {
                    if ((rubies[green].count != 0 && rubies[yellow].count == 0) || (rubies[green].count != 0 && rubies[yellow].count != 0))
                    {
                        necklace.Append(green);
                        LastAppended = green;
                        length++;
                        rubies[green].count--;
                        rubies = updateBoolsInDictionary(rubies);
                    }
                    else if (rubies[green].count == 0 && rubies[yellow].count != 0)
                    {
                        necklace.Append(yellow);
                        LastAppended = yellow;
                        length++;
                        rubies[yellow].count--;
                        rubies = updateBoolsInDictionary(rubies);
                    }
                }
                else if (rubies[red].count != 0 && rubies[blue].count == 0)
                {
                    necklace.Append(red);
                    LastAppended = red;
                    length++;
                    rubies[red].count--;
                    rubies = updateBoolsInDictionary(rubies);
                }
                while (isConcatable(rubies))
                {
                    string temp = LastAppended;

                    if (rubies[rubies[LastAppended].successor[0]].hasTail && rubies[rubies[LastAppended].successor[1]].hasTail)
                    {
                        if (rubies[rubies[LastAppended].successor[0]].count >= rubies[rubies[LastAppended].successor[1]].count)
                        {
                            temp = rubies[LastAppended].successor[0].ToString();
                            necklace.Append(temp);
                            LastAppended = temp;
                            length++;
                            rubies[LastAppended].count--;
                            rubies = updateBoolsInDictionary(rubies);
                        }
                        else
                        {
                            temp = rubies[LastAppended].successor[1].ToString();
                            necklace.Append(temp);
                            LastAppended = temp;
                            length++;
                            rubies[LastAppended].count--;
                            rubies = updateBoolsInDictionary(rubies);
                        }
                    }
                    else if (rubies[rubies[LastAppended].successor[0]].hasTail)
                    {
                        temp = rubies[LastAppended].successor[0].ToString();
                        necklace.Append(temp);
                        LastAppended = temp;
                        length++;
                        rubies[LastAppended].count--;
                        rubies = updateBoolsInDictionary(rubies);
                    }
                    else if (rubies[rubies[LastAppended].successor[1]].hasTail)
                    {
                        temp = rubies[LastAppended].successor[1].ToString();
                        necklace.Append(temp);
                        LastAppended = temp;
                        length++;
                        rubies[LastAppended].count--;
                        rubies = updateBoolsInDictionary(rubies);
                    }
                }
                //if any not null ruby is there link that tooooooooo
                foreach (var pair in rubies)
                {
                    if (rubies[pair.Key].count > 0)
                    {
                        if (rubies[LastAppended].successor.Contains(pair.Key))
                        {
                            necklace.Append(pair.Key);
                            LastAppended = pair.Key;
                            length++;
                        }
                    }
                }
                Console.WriteLine(necklace.ToString());
            }


            public static bool isConcatable(Dictionary<string, Rubies> rubies)
            {
                bool hasTail = false;
                foreach (var pair in rubies)
                {
                    if (rubies[pair.Key].hasTail) { hasTail = true; break; }
                }
                return hasTail;
            }

            public static Dictionary<string, Rubies> updateBoolsInDictionary(Dictionary<string, Rubies> rubies)
            {
                foreach (var pair in rubies)
                {
                    rubies[pair.Key].hasTail = (rubies[pair.Value.successor[0]].count > 0 || rubies[pair.Value.successor[1]].count > 0)
                        && rubies[pair.Key].count > 0;
                }

                return rubies;
            }


        }
}
