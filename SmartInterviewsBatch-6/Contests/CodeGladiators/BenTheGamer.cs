using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6.Contests.CodeGladiators
{
    public class BenTheGamer : ISolution
    {
        class Weapon
        {
            public bool IsUsed { get; set; }
            public int weaponsRequired { get; set; }
            public int maximumWeaponsReach { get; set; }
            public string weapons { get; set; }
        }

        public override void Solve()
        {
            var NandM = ReadArrString().Select(sbyte.Parse).ToArray();
            Weapon[] weapons = new Weapon[NandM[0]];
            int index = 0;
            int[] weaponRequiredMatrix = new int[NandM[1]];
            var isWeaponOf1TypeAvailable = false;
            var noOflevels = NandM[0];
            while (noOflevels-- > 0)
            {
                var weapon = ReadString();
                int count = 0;
                if (NandM[1] == 1)
                {
                    if (weapon[0] == '1')
                    {
                        isWeaponOf1TypeAvailable = true;
                    }
                }
                for (int i = 0; i < weapon.Length; i++)
                {
                    if (weapon[i] == '1')
                    {
                        count++;
                        weaponRequiredMatrix[i]++;
                    }
                }
                weapons[index++] = new Weapon
                {
                    weaponsRequired = count,
                    weapons = weapon
                };
            }
            if (NandM[1] == 1)
            {
                Console.Write(isWeaponOf1TypeAvailable ? "1" : "0");
                return;
            }
            for (int i = 0; i < weapons.Length; i++)
            {
                for (int j = 0; j < NandM[1]; j++)
                {
                    if (weapons[i].weapons[j] == '1')
                    {
                        weapons[i].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
                    }
                }
            }
            Array.Sort(weapons, delegate (Weapon x, Weapon y)
            {
                if (x.weaponsRequired.CompareTo(y.weaponsRequired) == 0)
                {
                    return y.maximumWeaponsReach.CompareTo(x.maximumWeaponsReach);
                }
                return x.weaponsRequired.CompareTo(y.weaponsRequired);
            });

            var pathArr = new int[NandM[0]];
            bool[] weaponsInStock = new bool[NandM[1]];
            weapons[0].IsUsed = true;
            pathArr[0] = 0;
            for (int i = 0; i < NandM[1]; i++)
            {
                if (weapons[0].weapons[i] == '1')
                {
                    weaponRequiredMatrix[i]--;
                    weaponsInStock[i] = true;
                }
            }
            FindPath(weapons, weaponRequiredMatrix, weaponsInStock, pathArr, 1);

            bool[] availableWeapons = new bool[NandM[1]];
            long answer = weapons[0].weaponsRequired * weapons[0].weaponsRequired;
            for (int i = 0; i < weapons[0].weapons.Length; i++)
            {
                if (weapons[0].weapons[i] == '1')
                {
                    availableWeapons[i] = true;
                }
            }
            for (int i = 1; i <pathArr.Length; i++)
            {
                int weaponsRequiredPerLevel = weapons[pathArr[i]].weaponsRequired;
                for (int j = 0; j < NandM[1]; j++)
                {
                    if (weapons[pathArr[i]].weapons[j] == '1' && availableWeapons[j])
                    {
                        weaponsRequiredPerLevel--;
                    }
                    else if (weapons[pathArr[i]].weapons[j] == '1' && !availableWeapons[j])
                    {
                        availableWeapons[j] = true;
                    }
                }
                answer += weaponsRequiredPerLevel * weaponsRequiredPerLevel;
            }
            Console.Write(answer);
        }

        void FindPath(Weapon[] weapons, int[] weaponRequiredMatrix, bool[] weaponsInStock, int[] pathArr, int index)
        {
            int min = int.MaxValue, indexMin = int.MinValue;
            if (index == weapons.Length)
                return;
            for (int i = 0; i < weapons.Length; i++)
            {
                if (!weapons[i].IsUsed)
                {
                    int cost = CostAssociated(weapons[i].weapons, weaponsInStock);
                    if (cost < min)
                    {
                        min = cost;
                        indexMin = i;
                    }
                    else if (cost == min)
                    {
                        //updating the maximum reach
                        for (int j = 0; j < weapons[0].weapons.Length; j++)
                        {
                            if (weapons[indexMin].weapons[j] == '1')
                            {
                                weapons[indexMin].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
                            }
                            if (weapons[i].weapons[j] == '1')
                            {
                                weapons[i].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
                            }
                        }
                        if (weapons[i].maximumWeaponsReach > weapons[indexMin].maximumWeaponsReach)
                        {
                            min = cost;
                            indexMin = i;
                        }
                    }
                }
            }
            pathArr[index++] = indexMin;
            weapons[indexMin].IsUsed = true;
            for (int i = 0; i < weapons[indexMin].weapons.Length; i++)
            {
                if (weapons[indexMin].weapons[i] == '1')
                {
                    weaponRequiredMatrix[i]--;
                    weaponsInStock[i] = true;
                }
            }
            FindPath(weapons, weaponRequiredMatrix, weaponsInStock, pathArr, index);
        }

        int CostAssociated(string src, bool[] weaponsInStock)
        {
            int cost = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == '1' && !weaponsInStock[i])
                {
                    cost++;
                }
            }
            return cost;
        }

        //public override void Solve()
        //{
        //    var NandM = ReadArrString().Select(byte.Parse).ToArray();
        //    Weapon[] weapons = new Weapon[NandM[0]];
        //    int index = 0;
        //    int[] weaponRequiredMatrix = new int[NandM[1]];
        //    while (NandM[0]-- > 0) {
        //        var weapon = ReadString();
        //        int count = 0;
        //        for (int i = 0; i < weapon.Length; i++) {
        //            if (weapon[i] == '1') {
        //                count++;
        //                weaponRequiredMatrix[i]++;
        //            }
        //        }
        //        weapons[index++] = new Weapon {
        //            weaponsRequired = count,
        //            weapons = weapon
        //        };
        //    }
        //    for (int i = 0; i < weapons.Length; i++) {
        //        for (int j = 0; j < NandM[1]; j++) {
        //            if (weapons[i].weapons[j] == '1') {
        //                weapons[i].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
        //            }
        //        }
        //    }
        //    Array.Sort(weapons, delegate (Weapon x, Weapon y) {
        //        return x.maximumWeaponsReach.CompareTo(y.maximumWeaponsReach);
        //    });
        //    bool[] availableWeapons = new bool[NandM[1]];
        //    long answer = weapons[0].weaponsRequired * weapons[0].weaponsRequired;
        //    for (int i = 0; i < weapons[0].weapons.Length; i++) {
        //        if (weapons[0].weapons[i] == '1') {
        //            availableWeapons[i] = true;
        //        }
        //    }
        //    for (int i = 1; i < weapons.Length; i++) {
        //        int weaponsRequiredPerLevel = weapons[i].weaponsRequired;
        //        for (int j = 0; j < NandM[1]; j++) {
        //            if (weapons[i].weapons[j] == '1' && availableWeapons[j])
        //            {
        //                weaponsRequiredPerLevel--;
        //            }
        //            else if(weapons[i].weapons[j] == '1' && !availableWeapons[j]) {
        //                availableWeapons[j] = true;
        //            }
        //        }
        //        answer += weaponsRequiredPerLevel * weaponsRequiredPerLevel;
        //    }
        //    Console.Write(answer);
        //}

        //public override void Solve()
        //{
        //    var NandM = ReadArrString().Select(byte.Parse).ToArray();
        //    Weapon[] weapons = new Weapon[NandM[0]];
        //    int index = 0;
        //    int[] weaponRequiredMatrix = new int[NandM[1]];
        //    var isWeaponOf1TypeAvailable = false;
        //    while (NandM[0]-- > 0)
        //    {
        //        var weapon = ReadString();
        //        int count = 0;
        //        if (NandM[1] == 1)
        //        {
        //            if (weapon[0] == '1')
        //            {
        //                isWeaponOf1TypeAvailable = true;
        //            }
        //        }
        //        for (int i = 0; i < weapon.Length; i++)
        //        {
        //            if (weapon[i] == '1')
        //            {
        //                count++;
        //                weaponRequiredMatrix[i]++;
        //            }
        //        }
        //        weapons[index++] = new Weapon
        //        {
        //            weaponsRequired = count,
        //            weapons = weapon
        //        };
        //    }
        //    if (NandM[1] == 1)
        //    {
        //        Console.Write(isWeaponOf1TypeAvailable?"1":"0");
        //        return;
        //    }
        //    for (int i = 0; i < weapons.Length; i++)
        //    {
        //        for (int j = 0; j < NandM[1]; j++)
        //        {
        //            if (weapons[i].weapons[j] == '1')
        //            {
        //                weapons[i].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
        //            }
        //        }
        //    }
        //    Array.Sort(weapons, delegate (Weapon x, Weapon y)
        //    {
        //        if (x.weaponsRequired.CompareTo(y.weaponsRequired) == 0)
        //        {
        //            return x.maximumWeaponsReach.CompareTo(y.maximumWeaponsReach);
        //        }
        //        return x.weaponsRequired.CompareTo(y.weaponsRequired);
        //    });

        //    var pathArr = new int[NandM[0]];
        //    //bool[] weaponsInStock = new bool[NandM[1]];
        //    weapons[weapons.Length - 1].IsUsed = true;
        //    pathArr[0] = weapons.Length - 1;
        //    for (int i = 0; i < NandM[1]; i++)
        //    {
        //        if (weapons[weapons.Length - 1].weapons[i] == '1')
        //        {
        //            weaponRequiredMatrix[i]--;
        //            //weaponsInStock[i] = true;
        //        }
        //    }
        //    FindPath(weapons.Length - 1, weapons, weaponRequiredMatrix, pathArr, 1);

        //    bool[] availableWeapons = new bool[NandM[1]];
        //    long answer = weapons[pathArr[pathArr.Length - 1]].weaponsRequired * weapons[pathArr[pathArr.Length - 1]].weaponsRequired;
        //    for (int i = 0; i < weapons[0].weapons.Length; i++)
        //    {
        //        if (weapons[pathArr[pathArr.Length - 1]].weapons[i] == '1')
        //        {
        //            availableWeapons[i] = true;
        //        }
        //    }
        //    for (int i = pathArr.Length - 2; i >= 0; i--)
        //    {
        //        int weaponsRequiredPerLevel = weapons[pathArr[i]].weaponsRequired;
        //        for (int j = 0; j < NandM[1]; j++)
        //        {
        //            if (weapons[pathArr[i]].weapons[j] == '1' && availableWeapons[j])
        //            {
        //                weaponsRequiredPerLevel--;
        //            }
        //            else if (weapons[pathArr[i]].weapons[j] == '1' && !availableWeapons[j])
        //            {
        //                availableWeapons[j] = true;
        //            }
        //        }
        //        answer += weaponsRequiredPerLevel * weaponsRequiredPerLevel;
        //    }
        //    Console.Write(answer);
        //}

        //void FindPath(int indexDst, Weapon[] weapons, int[] weaponRequiredMatrix, int[] pathArr, int index)
        //{
        //    int min = int.MaxValue, indexMin = int.MinValue;
        //    if (index == weapons.Length)
        //        return;
        //    for (int i = 0; i < weapons.Length; i++)
        //    {
        //        if (!weapons[i].IsUsed)
        //        {
        //            int cost = CostAssociated(weapons[i].weapons, weapons[indexDst].weapons);
        //            if (cost < min)
        //            {
        //                min = cost;
        //                indexMin = i;
        //            }
        //            else if (cost == min)
        //            {
        //                //updating the maximum reach
        //                for (int j = 0; j < weapons[0].weapons.Length; j++)
        //                {
        //                    if (weapons[indexMin].weapons[j] == '1')
        //                    {
        //                        weapons[indexMin].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
        //                    }
        //                    if (weapons[i].weapons[j] == '1')
        //                    {
        //                        weapons[i].maximumWeaponsReach += weaponRequiredMatrix[j] - 1;
        //                    }
        //                }
        //                if (weapons[i].maximumWeaponsReach > weapons[indexMin].maximumWeaponsReach)
        //                {
        //                    min = cost;
        //                    indexMin = i;
        //                }
        //            }
        //        }
        //    }
        //    pathArr[index++] = indexMin;
        //    weapons[indexMin].IsUsed = true;
        //    for (int i = 0; i < weapons[indexMin].weapons.Length; i++)
        //    {
        //        if (weapons[indexMin].weapons[i] == '1')
        //        {
        //            weaponRequiredMatrix[i]--;
        //            //weaponsInStock[i] = true;
        //        }
        //    }
        //    FindPath(indexMin, weapons, weaponRequiredMatrix, pathArr, index);
        //}

        //int CostAssociated(string src, string target)
        //{
        //    int cost = 0;
        //    for (int i = 0; i < src.Length; i++)
        //    {
        //        if (src[i] == '0' && target[i] == '1')
        //        {
        //            cost++;
        //        }
        //    }
        //    return cost;
        //}
    }
}
