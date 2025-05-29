class NOC
{
    public static void Main1(string[] args)
    {
        string name = "Mrinmoy";
        string uniqueChar = RemoveDup(name);
        Console.WriteLine(uniqueChar);
        string revName = ReverseName(name);
        Console.WriteLine(revName);
        var noOfOcc = noOfOccName(name);
        foreach (var res in noOfOcc)
        {
            if (res.Value > 1)
                Console.WriteLine(res.Key + " has " + res.Value + " counts");
            else
                Console.WriteLine(res.Key + " has " + res.Value + " count");
        }

        List<string> emp = new List<string>()
        {
            "Alice","Bob","Robin"
        };

        var resultEmp = emp.OrderByDescending(x => x).ToList();

        foreach (var res in resultEmp)
        {
            Console.WriteLine(res);
        }

    }

    public static string RemoveDup(string name)
    {
        HashSet<char> seen = new HashSet<char>();
        return new string(name.Where(c => seen.Add(char.ToLower(c))).ToArray());
    }

    public static string ReverseName(string name)
    {
        string rev = string.Empty;
        for (int i = name.Length - 1; i >= 0; i--)
        {
            rev = rev + name[i];

        }
        return rev;
    }

    public static Dictionary<char, int> noOfOccName(string name)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        foreach (char c in name.ToLower())
        {
            if (c != ' ')
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic[c] = 1;
                }
            }
        }
        return dic;

    }


}