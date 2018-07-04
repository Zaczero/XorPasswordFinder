using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XORdecryptor.Properties;

namespace XORdecryptor
{
    public partial class mainForm : Form
    {
        private const int Limit = 999999;

        public mainForm()
        {
            InitializeComponent();
            this.Icon = Resources.xor;

#if DEBUG
            var pass = "Password";
            var inputs = new []
            {
                "Zaczero",
                "GitHub",
                "Microsoft",
                "Visual",
                "Studio",
                "Google",
                "Android",
                "XOR",
                "Encryptio",
                "Secure",
                "Messages",
                "Facebook",
                "Premium",
                "Paid",
                "Free",
                "Brand New",
                "Awesome",
                "random1",
                "123123123",
                "321321321",
                "888666444",
                "BBQ sauce",
                "coding",
                "hacking",
                "skillz",
                "zacZacz",
                "proSkill",
                "dontHackM",
                "good bad",
                "pretty",
                "ugly",
                "big bad w",
                "olfff",
                "ImAWESOME",
                "HIREmePLZ",
                "cry exe",
                "laugh exe",
                "spamming",
                "awwwwwww",
                "animeeee",
            };

            foreach (var input in inputs)
            {
                var tmp = input.ToCharArray();

                for (var i = 0; i < tmp.Length; i++)
                {
                    tmp[i] ^= pass[i % pass.Length];
                }

                this.outputBox.AppendText(StringConverter.ToHex(tmp) + "\n");
            }
#endif
        }

        private async void processBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            var inputChars = CharGenerator.FromRegex(this.inputRegex.Text);
            var passwordChars = CharGenerator.FromRegex(this.passwordRegex.Text);

            var outputs = this.outputBox.Text
                .Split(new [] {"\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(StringConverter.FromHex)
                .ToArray();

            if (outputs.Length < 1)
            {
                MessageBox.Show("Please input XORed strings (hex)");
                return;
            }

            btn.Enabled = false;
            this.progressBar.Visible = true;
            await Task.Run(() => Start(inputChars, passwordChars, outputs));
            this.progressBar.Visible = false;
            btn.Enabled = true;
        }

        private void Start(HashSet<char> inputChars, HashSet<char> passwordChars, string[] outputs) 
        {
            var sw = new Stopwatch();
            sw.Start();

            var possibleCombinations = FindPossibleCombinations(outputs, inputChars, passwordChars);
            ReducePossibleCombinations(possibleCombinations);
            var simple = SimplifyPossibleCombinations(possibleCombinations);
            var pretty = PrettyPossibleCombinations(simple);

            sw.Stop();

            var tmp = Path.GetTempFileName();
            var name = Path.GetFileNameWithoutExtension(tmp) + ".txt";

            if (pretty.Count > Limit)
            {
                File.WriteAllText(name, $"Count: +{pretty.Count} (too many results, task canceled); Time: {sw.ElapsedMilliseconds}ms{Environment.NewLine}");
            }
            else
            {
                File.WriteAllText(name, $"Count: {pretty.Count}; Time: {sw.ElapsedMilliseconds}ms{Environment.NewLine}");
            }

            File.AppendAllLines(name, pretty);
            Process.Start(name);

            GC.Collect();
        }

        private List<List<HashSet<char>>> FindPossibleCombinations(string[] outputs, HashSet<char> inputChars, HashSet<char> passwordChars)
        {
            var results = new List<List<HashSet<char>>>();

            foreach (var output in outputs)
            {
                var strReults = new List<HashSet<char>>();

                foreach (var outputChar in output)
                {
                    var charResults = new HashSet<char>();

                    foreach (var passwordChar in passwordChars)
                    {
                        var possibleInputChar = XOR.EncryptDecrypt(outputChar, passwordChar);
                        if (inputChars.Contains(possibleInputChar))
                        {
                            charResults.Add(passwordChar);
                        }
                    }

                    strReults.Add(charResults);
                }

                results.Add(strReults);
            }

            return results;
        }

        private void ReducePossibleCombinations(List<List<HashSet<char>>> possibleCombinations)
        {
            foreach (var possibleCombination in possibleCombinations)
            {
                for (var i = 0; i < possibleCombination.Count; i++)
                {
                    var toRemove = new List<char>();

                    foreach (var c in possibleCombination[i])
                    {
                        if (!DoesCharAppearInAll(possibleCombinations, i, c))
                        {
                            toRemove.Add(c);
                            // iteration modified exception
                        }
                    }

                    foreach (var tr in toRemove)
                    {
                        possibleCombination[i].Remove(tr);
                    }
                }
            }
        }

        private bool DoesCharAppearInAll(List<List<HashSet<char>>> possibleCombinations, int index, char c)
        {
            foreach (var possibleCombination in possibleCombinations)
            {
                if (index < possibleCombination.Count && !possibleCombination[index].Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        private List<HashSet<char>> SimplifyPossibleCombinations(List<List<HashSet<char>>> possibleCombinations)
        {
            var maxLen = possibleCombinations.Max(s => s.Count);
            var result = new List<HashSet<char>>(maxLen);

            for (var i = 0; i < maxLen; i++)
            {
                result.Add(new HashSet<char>());

                foreach (var possibleCombination in possibleCombinations)
                {
                    if (possibleCombination.Count <= i)
                    {
                        continue;
                    }

                    foreach (var c in possibleCombination[i])
                    {
                        result[i].Add(c);
                    }
                }
            }

            return result;
        }

        private List<string> PrettyPossibleCombinations(List<HashSet<char>> possibleCombinations)
        {
            var result = new List<string>();
            var conv = possibleCombinations.Select(hs => hs.ToArray()).ToArray();

            Recursive(result, conv, new Stack());

            return result;
        }

        private void Recursive(List<string> list, char[][] comb, Stack stack, int i = 0)
        {
            foreach (var c in comb[i])
            {
                if (list.Count > Limit)
                {
                    break;
                }

                stack.Push(c);

                if (i + 1 < comb.Length)
                {
                    Recursive(list, comb, stack, i + 1);
                }
                else
                {
                    var sb = new StringBuilder();

                    foreach (var s in stack)
                    {
                        sb.Append(s);
                    }

                    var str = sb.ToString();
                    list.Add(Reverse(str));
                }

                stack.Pop();
            }

            if (i == 0)
            {
                this.progressBar.Invoke((MethodInvoker) delegate
                {
                    this.progressBar.Value += (int) (100f / comb.Length);
                });
            }
        }

        private string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
