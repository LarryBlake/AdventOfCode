﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            Application.DoEvents();

            this.textBox1.Text = Joltage().ToString();
        }

        string[] GetInput(int dy)
        {
            string url = @"https://adventofcode.com/2020/day/" + dy.ToString() + "/input";
            string[] lines;
            System.Net.WebClient wc = new System.Net.WebClient();
            string s = wc.DownloadString(url);
            lines = s.Split('\n');
            return lines;
        }


        // Day 1
        long Expenses()
        {
            long[] ar = new long[] {1834, 1546, 1119, 1870, 1193, 1198, 1542, 1944, 1817, 1249, 1361, 1856, 1258, 1425, 1835, 1520, 1792, 1130, 2004, 1366, 1549, 1347, 1507, 1699, 1491, 1557,
                1865, 1948, 1199, 1229, 1598, 1756, 1643, 1306, 1838, 1157, 1745, 1603, 1972, 1123, 1963, 1759, 1118, 1526, 1695, 1661, 1262, 1117, 1844, 1922, 1997, 1630, 1337, 1721, 1147, 1848,
                 1476, 1975, 1942, 1569, 1126, 1313, 1449, 1206, 1722, 1534, 1706, 1596, 1700, 1811, 906, 1666, 1945, 1271, 1629, 1456, 1316, 1636, 1884, 1556, 1317, 1393, 1953, 1658, 2005, 1252,
                 1878, 1691, 60, 1872, 386, 1369, 1739, 1460, 1267, 1935, 1992, 1310, 1818, 1320, 1437, 1486, 1205, 1286, 1670, 1577, 1237, 1558, 1937, 1938, 1656, 1220, 1732, 1647, 1857, 1446,
                 1516, 1450, 1860, 1625, 1377, 1312, 1588, 1895, 1967, 1567, 1582, 1428, 1415, 1731, 1919, 1651, 1597, 1982, 1576, 1172, 1568, 1867, 1660,  1754, 1227, 1121, 1733, 537, 1809, 1322,
                 1876, 1665, 1124, 1461, 1888, 1368, 1235, 1479, 1529, 1148, 1996, 1939, 1340, 1531, 1438, 1897, 1152, 1321, 1770, 897, 1750, 1111, 1772, 1615, 1798, 1359, 1470, 1610,  1362, 1973,
                 1892, 1830, 599, 1341, 1681, 1572, 1873, 42, 1246, 1447, 1800, 1524, 1214, 1784, 1664, 1882, 1989, 1797, 1211, 1170, 1854, 1287, 1641, 1760};

            int m = ar.Length;

            for (int i = 0; i + 2 < m; i++)
            {
                for (int j = i + 1; j + 1 < m; j++)
                {
                    for (int k = j + 1; k < m; k++)
                    {
                        if (ar[i] + ar[j] + ar[k] == 2020) return (ar[i] * ar[j] * ar[k]);
                    }
                }
            }

            return -1;

        }

        // Day 2
        int Passwords()
        {
            int ans = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\passwords.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                int dsh = line.IndexOf('-');
                int spa = line.IndexOf(' ');
                int colo = line.IndexOf(':');

                int mn = int.Parse(line.Substring(0, dsh));
                int mx = int.Parse(line.Substring(dsh + 1, spa - dsh - 1));
                string ch = line.Substring(colo - 1, 1);
                string pw = line.Substring(colo + 2);

                int c = 0;
                //int ln = pw.Length;
                //for (int i = 0; i < ln; i++)
                //{
                //    if (pw.Substring(i, 1) == ch) c++;
                //}
                //if (c >= mn && c <= mx) ans++;
                if (pw.Substring(mn - 1, 1) == ch) c++;
                if (pw.Substring(mx - 1, 1) == ch) c++;
                if (c == 1) ans++;
            }
            return ans;
        }

        // Day 3
        long Toboggan()
        {
            long ans = 0;

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\toboggan.txt");
            long t11 = Tobo2(1, 1, lines);
            long t31 = Tobo2(3, 1, lines);
            long t51 = Tobo2(5, 1, lines);
            long t71 = Tobo2(7, 1, lines);
            long t12 = Tobo2(1, 2, lines);

            ans = t11 * t31 * t51 * t71 * t12;
            return ans;
        }
        long Tobo2(int acr, int dwn, string[] lines)
        {
            long ans = 0;
            int wd = lines[0].Length;
            int p = 0;

            for (int i = 0; i < lines.Length; i += dwn)
            {
                if (lines[i].Substring((p % wd), 1) == "#") ans++;
                p += acr;
            }

            return ans;
        }

        // Day 4
        int Passports()
        {
            int ans = 0;

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\passports.txt");
            int ln = lines.Length;
            List<int> blanks = new List<int>();
            for (int i = 0; i < ln; i++)
            {
                if (lines[i] == "") blanks.Add(i);
            }
            blanks.Add(ln);

            int wk = 0;
            foreach (int b in blanks)
            {
                string s = lines[wk];
                for (int i = wk + 1; i < b; i++) s += " " + lines[i];
                wk = b + 1;

                string[] pwk = s.Split(' ');
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string p in pwk)
                {
                    string[] k = p.Split(':');
                    dict.Add(k[0], k[1]);
                }

                bool ok = (dict.ContainsKey("byr") && dict.ContainsKey("iyr") && dict.ContainsKey("eyr") && dict.ContainsKey("hgt")
                    && dict.ContainsKey("hcl") && dict.ContainsKey("ecl") && dict.ContainsKey("pid"));

                if (ok)
                {
                    int byr = int.Parse(dict["byr"]);
                    ok = (byr >= 1920 && byr <= 2002);
                }
                if (ok)
                {
                    int iyr = int.Parse(dict["iyr"]);
                    ok = (iyr >= 2010 && iyr <= 2020);
                }
                if (ok)
                {
                    int eyr = int.Parse(dict["eyr"]);
                    ok = (eyr >= 2020 && eyr <= 2030);
                }
                if (ok)
                {
                    string v = dict["hgt"];
                    int vln = v.Length;
                    string meas = v.Substring(vln - 2);
                    if (meas == "cm")
                    {
                        int hgt = int.Parse(v.Substring(0, vln - 2));
                        ok = (hgt >= 150 && hgt <= 193);
                    }
                    else if (meas == "in")
                    {
                        int hgt = int.Parse(v.Substring(0, vln - 2));
                        ok = (hgt >= 59 && hgt <= 76);
                    }
                    else ok = false;
                }
                if (ok)
                {
                    string hcl = dict["hcl"];
                    ok = (hcl.Length == 7 && hcl.Substring(0, 1) == "#");
                    if (ok)
                    {
                        for (int i = 1; i < 7; i++)
                        {
                            ok = ("0123456789abcdef".IndexOf(hcl.Substring(i, 1)) >= 0);
                            if (!ok) break;
                        }
                    }
                }
                if (ok) ok = (dict["ecl"] == "amb" || dict["ecl"] == "blu" || dict["ecl"] == "brn" || dict["ecl"] == "gry" || dict["ecl"] == "grn"
                        || dict["ecl"] == "hzl" || dict["ecl"] == "oth");

                if (ok) ok = (dict["pid"].Length == 9);

                if (ok) ans++;
            }


            return ans;
        }

        // Day 5
        int Boarding()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\seats.txt");
            bool[] seats = new bool[1000];

            foreach (string s in lines)
            {
                int row = Binar(s.Substring(0, 7), "F", "B");
                int col = Binar(s.Substring(7), "L", "R");
                int seat = 8 * row + col;
                seats[seat] = true;
            }

            for (int i = 2; i < 1000; i++)
            {
                if (seats[i - 1] && !seats[i] && seats[i + 1]) return i;
            }

            return -1;
        }
        int Binar(string s, string zer, string one)
        {
            int ans = 0;
            int ln = s.Length;
            for (int i = 0; i < ln; i++)
            {
                if (s.Substring(i, 1) == one) ans += (int)Math.Pow(2, ln - i - 1);
            }
            return ans;
        }

        // Day 6
        int Customs()
        {
            int ans = 0;

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\customs.txt");
            int ln = lines.Length;
            List<int> blanks = new List<int>();
            for (int i = 0; i < ln; i++)
            {
                if (lines[i] == "") blanks.Add(i);
            }
            blanks.Add(ln);

            int wk = 0;
            foreach (int b in blanks)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                for (int i = wk; i < b; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        string s = lines[i].Substring(j, 1);
                        if (dict.ContainsKey(s)) dict[s]++;
                        else dict.Add(s, 1);
                    }
                }

                foreach (int v in dict.Values)
                {
                    if (v == b - wk) ans++;
                }

                wk = b + 1;
            }

            return ans;
        }

        // Day 7
        int Luggage()
        {
            int ans = 0;
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\luggage.txt");

            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            foreach (string s in lines)
            {
                int p = s.IndexOf(" bags");
                string colr = s.Substring(0, p);

                Dictionary<string, int> contents = new Dictionary<string, int>();
                string wk = s.Substring(p + 14);

                if (wk != "no other bags.")
                {
                    string[] conts = wk.Split(',');
                    int cln = conts.Length;
                    for (int i = 1; i < cln; i++) conts[i] = conts[i].Substring(1);

                    for (int i = 0; i < cln; i++)
                    {
                        int v = int.Parse(conts[i].Substring(0, 1));
                        p = conts[i].IndexOf(" bag");
                        string cwk = conts[i].Substring(2, p - 2);
                        contents.Add(cwk, v);
                    }
                }

                dict.Add(colr, contents);
            }

            //Dictionary<string, bool> goodColors = new Dictionary<string, bool>();
            //goodColors.Add("shiny gold", true);
            //while (ans != goodColors.Count)
            //{
            //    ans = goodColors.Count;
            //    List<string> moreColors = new List<string>();
            //    foreach (string wk in goodColors.Keys)
            //    {
            //        foreach (string k in dict.Keys)
            //        {
            //            if (dict[k].ContainsKey(wk))
            //            {
            //                if (!moreColors.Contains(k)) moreColors.Add(k);
            //            }
            //        }
            //    }
            //    foreach (string wk in moreColors)
            //    {
            //        if (!goodColors.ContainsKey(wk)) goodColors.Add(wk, true);
            //    }
            //}
            //ans--;

            ans += LuggageContents(dict, "shiny gold");

            return ans;
        }
        int LuggageContents(Dictionary<string, Dictionary<string, int>> dict, string k)
        {
            int ans = 0;
            foreach (string colr in dict[k].Keys)
            {
                ans += dict[k][colr] + (dict[k][colr] * LuggageContents(dict, colr));
            }
            return ans;
        }

        // Day 8
        int Endless()
        {
            int ans = 0;
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\bootcode.txt");
            int ln = lines.Length;

            for (int i = 0; i < ln; i++)
            {
                string opcode = lines[i].Substring(0, 3);
                if (opcode == "nop" || opcode == "jmp")
                {
                    string[] trylines = new string[ln];
                    for (int j = 0; j < ln; j++)
                    {
                        if (j == i)
                        {
                            trylines[j] = (opcode == "nop" ? "jmp" : "nop") + lines[j].Substring(3);
                        }
                        else trylines[j] = lines[j];
                    }

                    string errc = "";
                    ans = TryEndless(trylines, out errc);
                    if (errc == "") return ans;
                }
            }

            return -1;
        }
        int TryEndless(string[] lines, out string errc)
        {
            int ans = 0;
            errc = "";
            int ln = lines.Length;
            bool[] beenTo = new bool[ln];
            int pos = 0;

            while (true)
            {
                beenTo[pos] = true;

                string opcode = lines[pos].Substring(0, 3);
                string sign = lines[pos].Substring(4, 1);
                int count = int.Parse(lines[pos].Substring(5));
                int scount = (sign == "-" ? count * -1 : count);

                if (opcode == "nop")
                {
                    pos++;
                }
                else if (opcode == "acc")
                {
                    ans += scount;
                    pos++;
                }
                else if (opcode == "jmp")
                {
                    pos += scount;
                }

                if (pos == ln) break;
                if (beenTo[pos])
                {
                    errc = "repeats";
                    break;
                }
            }

            return ans;
        }

        // Day 9
        long Encoding()
        {
            long ans = 0;
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\encoding.txt");
            int ln = lines.Length;

            for (int i = 25; i < ln; i++)
            {
                long wk = long.Parse(lines[i]);
                bool ok = false;
                for (int j = i - 25; j < i; j++)
                {
                    long wk1 = long.Parse(lines[j]);
                    for (int k = j + 1; k < i; k++)
                    {
                        long wk2 = long.Parse(lines[k]);
                        ok = (wk1 + wk2 == wk);
                        if (ok) break;
                    }
                    if (ok) break;
                }
                if (!ok)
                {
                    ans = wk;
                    break;
                }
            }
            return ans;
        }
        long Encoding2()
        {
            long tgt = Encoding();
            long ans = 0;
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\encoding.txt");
            int ln = lines.Length;

            for (int i = 0; i < ln; i++)
            {
                long trySum = long.Parse(lines[i]);
                if (trySum < tgt)
                {
                    long mn = trySum;
                    long mx = trySum;
                    for (int j = i + 1; j < ln; j++)
                    {
                        long wk = long.Parse(lines[j]);
                        trySum += wk;
                        if (trySum >= tgt) break;

                        if (wk < mn) mn = wk;
                        if (wk > mx) mx = wk;
                        if (trySum == tgt) break;
                    }
                    if (trySum == tgt)
                    {
                        ans = mn + mx;
                        break;
                    }
                }
            }

            return ans;
        }

        // Day 10
        long Joltage()
        {
            long ans = 0;
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\joltage.txt");
            int ln = lines.Length;
            int mx = 0;
            bool[] js = new bool[200];
            js[0] = true;
            foreach (string s in lines)
            {
                int wk = int.Parse(s);
                js[wk] = true;
                if (wk > mx) mx = wk;
            }

            long[] ways = new long[mx + 1];
            ways[0] = 1;
            for (int i = 1; i <= mx; i++)
            {
                if (js[i])
                {
                    if (js[i - 1]) ways[i] += ways[i - 1];
                    if (i - 2 > -1 && js[i - 2]) ways[i] += ways[i - 2];
                    if (i - 3 > -1 && js[i - 3]) ways[i] += ways[i - 3];
                }
            }

            ans = ways[mx];
            return ans;
        }

        // Day 11
        int Ferry()
        {
            int ans = 0;
            int round = 0;

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\ferry.txt");
            int ln = lines.Length;
            int lln = lines[0].Length;
            string[,] board = new string[ln, lln];

            for (int i = 0; i < ln; i++)
            {
                for (int j = 0; j < lln; j++)
                {
                    board[i, j] = lines[i].Substring(j, 1);
                }
            }

            bool chgs = true;
            while (chgs)
            {
                round++;
                label1.Text = round.ToString();
                Application.DoEvents();
                chgs = false;
                string[,] nwboard = new string[ln, lln];
                for (int i = 0; i < ln; i++)
                {
                    for (int j = 0; j < lln; j++)
                    {
                        nwboard[i, j] = board[i, j];
                    }
                }

                for (int i = 0; i < ln; i++)
                {
                    for (int j = 0; j < lln; j++)
                    {
                        if (board[i, j] == "L")
                        {
                            int neighbors = 0;
                            neighbors += FerryLook(board, i, j, -1, -1);
                            neighbors += FerryLook(board, i, j, -1, 0);
                            neighbors += FerryLook(board, i, j, -1, 1);

                            neighbors += FerryLook(board, i, j, 0, -1);
                            neighbors += FerryLook(board, i, j, 0, 1);

                            neighbors += FerryLook(board, i, j, 1, -1);
                            neighbors += FerryLook(board, i, j, 1, 0);
                            neighbors += FerryLook(board, i, j, 1, 1);

                            if (neighbors == 0)
                            {
                                nwboard[i, j] = "#";
                                chgs = true;
                            }
                        }
                        else if (board[i, j] == "#")
                        {
                            int neighbors = 0;
                            neighbors += FerryLook(board, i, j, -1, -1);
                            neighbors += FerryLook(board, i, j, -1, 0);
                            neighbors += FerryLook(board, i, j, -1, 1);

                            neighbors += FerryLook(board, i, j, 0, -1);
                            neighbors += FerryLook(board, i, j, 0, 1);

                            neighbors += FerryLook(board, i, j, 1, -1);
                            neighbors += FerryLook(board, i, j, 1, 0);
                            neighbors += FerryLook(board, i, j, 1, 1);

                            if (neighbors > 4)
                            {
                                nwboard[i, j] = "L";
                                chgs = true;
                            }
                        }
                    }
                }
                if (chgs) board = nwboard;
            }

            for (int i = 0; i < ln; i++)
            {
                for (int j = 0; j < lln; j++)
                {
                    if (board[i, j] == "#") ans++;
                }
            }
            return ans;
        }
        int FerryLook(string[,] board, int i, int j, int vert, int hor)
        {
            int newi = i + vert;
            int newj = j + hor;

            while (newi > -1 && newi <= board.GetUpperBound(0) && newj > -1 && newj <= board.GetUpperBound(1))
            {
                if (board[newi, newj] == "L") return 0;
                if (board[newi, newj] == "#") return 1;

                newi += vert;
                newj += hor;
            }
            return 0;
        }

        // Day 12
        int Evade()
        {
            Point ship = new Point(0, 0);
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\evade.txt");
            string[] dirs = { "E", "S", "W", "N" };
            int[] dirX = { 1, 0, -1, 0 };
            int[] dirY = { 0, 1, 0, -1 };
            int facing = 0;

            foreach (string s in lines)
            {
                string mv = s.Substring(0, 1);
                int mvln = int.Parse(s.Substring(1));
                if (mv == "L")
                {
                    int spokes = mvln / 90;
                    facing -= spokes;
                    if (facing < 0) facing += 4;
                }
                else if (mv == "R")
                {
                    int spokes = mvln / 90;
                    facing = (facing + spokes) % 4;
                }
                else if (mv == "F")
                {
                    ship.X += (dirX[facing] * mvln);
                    ship.Y += (dirY[facing] * mvln);
                }
                else
                {
                    int i = "ESWN".IndexOf(mv);
                    ship.X += (dirX[i] * mvln);
                    ship.Y += (dirY[i] * mvln);
                }
            }
            return Math.Abs(ship.X) + Math.Abs(ship.Y);
        }
        int Evade2()
        {
            Point ship = new Point(0, 0);
            Point waypoint = new Point(10, -1);

            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\evade.txt");

            foreach (string s in lines)
            {
                string mv = s.Substring(0, 1);
                int mvln = int.Parse(s.Substring(1));
                if (mv == "L")
                {
                    int spokes = mvln / 90;
                    for (int i = 0; i < spokes; i++)
                    {
                        waypoint = new Point(waypoint.Y, waypoint.X * -1);
                    }
                }
                else if (mv == "R")
                {
                    int spokes = mvln / 90;
                    for (int i = 0; i < spokes; i++)
                    {
                        waypoint = new Point(waypoint.Y * -1, waypoint.X);
                    }
                }
                else if (mv == "F")
                {
                    ship.X += (waypoint.X * mvln);
                    ship.Y += (waypoint.Y * mvln);
                }
                else if (mv == "E") waypoint.X += mvln;
                else if (mv == "S") waypoint.Y += mvln;
                else if (mv == "W") waypoint.X -= mvln;
                else if (mv == "N") waypoint.Y -= mvln;
            }
            return Math.Abs(ship.X) + Math.Abs(ship.Y);
        }
    }
}