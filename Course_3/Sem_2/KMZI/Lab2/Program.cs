using Lab2.DocumentReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            const string fileName = "Lab2task1.xlsx";

            List<char> golandishAlphabet = new List<char>()
            {
                'a','b','c','d','e','f','g','h','i','j','k',
                'l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
            };
            List<char> ukraineAlphabet = new List<char>()
            {
                '\u0430','\u0431','\u0432','\u0433',
                '\u0434','\u0435','\u0454','\u0436','\u0437',
                '\u0438','\u0456','\u0457','\u0439','\u043A',
                '\u043B','\u043C','\u043D','\u043E','\u043F',
                '\u0440','\u0441','\u0442','\u0443','\u0444',
                '\u0445','\u0446','\u0447','\u0448','\u0449',
                '\u044C','\u044E','\u044F'
            };
            while (choice != 6)
            {
                Console.Clear();

                Console.WriteLine("Выберите номер задания:\n- 1\n- 2\n- 3\n- 4\n- 5\n- 6-выйти");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            EntropyChecker golandishChecker = new EntropyChecker(golandishAlphabet, 0, "Голландский");
                            EntropyChecker ukraineChecker = new EntropyChecker(ukraineAlphabet, 0, "Украинский");

                            string golandishText = golandishChecker.OpenDocument("golandish.txt").ReadToEnd().ToLower();
                            string ukraineText = ukraineChecker.OpenDocument("ukraine.txt").ReadToEnd().ToLower();

                            Regex regex = new Regex(@"\W");
                            golandishText = regex.Replace(golandishText, "");
                            ukraineText = regex.Replace(ukraineText, "");

                            Dictionary<char, int> golandishDict = golandishChecker.alphabetListToDictionary();
                            Dictionary<char, int> ukraineDict = ukraineChecker.alphabetListToDictionary();

                            golandishChecker.getSymbolsCounts(golandishText, golandishDict);
                            ukraineChecker.getSymbolsCounts(ukraineText, ukraineDict);

                            Dictionary<char, double> chancesgolandish = golandishChecker.getSymbolsChances(golandishText, golandishDict);
                            Dictionary<char, double> chancesukraine = ukraineChecker.getSymbolsChances(ukraineText, ukraineDict);

                            golandishChecker.computeTextEntropy(chancesgolandish);
                            ukraineChecker.computeTextEntropy(chancesukraine);


                            golandishChecker.printAlphabet();
                            golandishChecker.printChances(chancesgolandish);
                            golandishChecker.printAlhabetEntropy();


                            ukraineChecker.printAlphabet();
                            ukraineChecker.printChances(chancesukraine);
                            ukraineChecker.printAlhabetEntropy();

                            double sumgolandish = 0;
                            double sumukraine = 0;
                            foreach (KeyValuePair<char, double> x in chancesgolandish)
                            {
                                sumgolandish += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesukraine)
                            {
                                sumukraine += x.Value;
                            }

                            Console.WriteLine($"Сумма шансов для украинского языка: {sumukraine}");
                            Console.WriteLine($"Сумма шансов для голландского языка: {sumgolandish}");

                            ExcelDocumentCreator<char, double> excel = new ExcelDocumentCreator<char, double>(new System.IO.FileInfo(fileName));
                            excel.createWorksheet("first");
                            excel.addValuesFromDict(chancesgolandish, "first", 0);
                            excel.addValuesFromDict(chancesukraine, "first", 3);
                            excel.pack.Save();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            EntropyChecker golandishChecker = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код");
                            EntropyChecker ukraineChecker = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код");

                            string golandishText = golandishChecker.OpenDocument("golandish.txt").ReadToEnd().ToLower();
                            string ukraineText = ukraineChecker.OpenDocument("ua.txt").ReadToEnd().ToLower();

                            Regex regex = new Regex(@"\W");
                            golandishText = regex.Replace(golandishText, "");
                            ukraineText = regex.Replace(ukraineText, "");

                            string binTextgolandish = "";
                            string binTextukraine = "";

                            var textChr = Encoding.UTF8.GetBytes(golandishText);
                            foreach (int chr in textChr)
                            {
                                binTextgolandish += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            textChr = Encoding.UTF8.GetBytes(ukraineText);
                            foreach (int chr in textChr)
                            {
                                binTextukraine += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            Dictionary<char, int> golandishDict = golandishChecker.alphabetListToDictionary();
                            Dictionary<char, int> ukraineDict = ukraineChecker.alphabetListToDictionary();

                            golandishChecker.getSymbolsCounts(binTextgolandish, golandishDict);
                            ukraineChecker.getSymbolsCounts(binTextukraine, ukraineDict);

                            Dictionary<char, double> chancesgolandish = golandishChecker.getSymbolsChances(binTextgolandish, golandishDict);
                            Dictionary<char, double> chancesukraine = ukraineChecker.getSymbolsChances(binTextukraine, ukraineDict);

                            golandishChecker.computeTextEntropy(chancesgolandish);
                            ukraineChecker.computeTextEntropy(chancesukraine);


                            golandishChecker.printAlphabet();
                            golandishChecker.printChances(chancesgolandish);
                            golandishChecker.printAlhabetEntropy();


                            ukraineChecker.printAlphabet();
                            ukraineChecker.printChances(chancesukraine);
                            ukraineChecker.printAlhabetEntropy();

                            double sumgolandish = 0;
                            double sumukraine = 0;
                            foreach (KeyValuePair<char, double> x in chancesgolandish)
                            {
                                sumgolandish += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesukraine)
                            {
                                sumukraine += x.Value;
                            }

                            Console.WriteLine($"Сумма шансов для украинского языка: {sumukraine}");
                            Console.WriteLine($"Сумма шансов для голландскогоязыка: {sumgolandish}");

                            ExcelDocumentCreator<char, double> excel = new ExcelDocumentCreator<char, double>(new System.IO.FileInfo(fileName));
                            excel.createWorksheet("second");
                            excel.addValuesFromDict(chancesgolandish, "second", 0);
                            excel.addValuesFromDict(chancesukraine, "second", 3);
                            excel.pack.Save();

                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();

                            EntropyChecker golandishChecker = new EntropyChecker(golandishAlphabet, 0, "Голландский");
                            EntropyChecker ukraineChecker = new EntropyChecker(ukraineAlphabet, 0, "украинский");
                            EntropyChecker golandishCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (Голландский)");
                            EntropyChecker ukraineCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (украинский)");

                            string golandishText = "obodovpavelandreevich";
                            string ukraineText = "ободовпавеландреевич";

                            string binTextgolandish = "";
                            string binTextukraine = "";

                            var textChr = Encoding.UTF8.GetBytes(golandishText);
                            foreach (int chr in textChr)
                            {
                                binTextgolandish += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            textChr = Encoding.UTF8.GetBytes(ukraineText);
                            foreach (int chr in textChr)
                            {
                                binTextukraine += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            Dictionary<char, int> golandishDict = golandishChecker.alphabetListToDictionary();
                            Dictionary<char, int> ukraineDict = ukraineChecker.alphabetListToDictionary();
                            Dictionary<char, int> golandishDictBin = golandishCheckerBin.alphabetListToDictionary();
                            Dictionary<char, int> ukraineDictBin = ukraineCheckerBin.alphabetListToDictionary();

                            golandishChecker.getSymbolsCounts(golandishText, golandishDict);
                            ukraineChecker.getSymbolsCounts(ukraineText, ukraineDict);
                            golandishCheckerBin.getSymbolsCounts(binTextgolandish, golandishDictBin);
                            ukraineCheckerBin.getSymbolsCounts(binTextukraine, ukraineDictBin);

                            Dictionary<char, double> chancesgolandish = golandishChecker.getSymbolsChances(golandishText, golandishDict);
                            Dictionary<char, double> chancesukraine = ukraineChecker.getSymbolsChances(ukraineText, ukraineDict);
                            Dictionary<char, double> chancesgolandishBin = golandishCheckerBin.getSymbolsChances(binTextgolandish, golandishDictBin);
                            Dictionary<char, double> chancesukraineBin = ukraineCheckerBin.getSymbolsChances(binTextukraine, ukraineDictBin);

                            golandishChecker.computeTextEntropy(chancesgolandish);
                            ukraineChecker.computeTextEntropy(chancesukraine);
                            golandishCheckerBin.computeTextEntropy(chancesgolandishBin);
                            ukraineCheckerBin.computeTextEntropy(chancesukraineBin);


                            golandishChecker.printAlphabet();
                            golandishChecker.printChances(chancesgolandish);
                            golandishChecker.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {golandishChecker.AlphabetName}: {golandishChecker.AlphabetEntropy * golandishText.Length}");

                            ukraineChecker.printAlphabet();
                            ukraineChecker.printChances(chancesukraine);
                            ukraineChecker.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {ukraineChecker.AlphabetName}: {ukraineChecker.AlphabetEntropy * ukraineText.Length}");

                            golandishCheckerBin.printAlphabet();
                            golandishCheckerBin.printChances(chancesgolandishBin);
                            golandishCheckerBin.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {golandishCheckerBin.AlphabetName}: {golandishCheckerBin.AlphabetEntropy * binTextgolandish.Length}");

                            ukraineCheckerBin.printAlphabet();
                            ukraineCheckerBin.printChances(chancesukraineBin);
                            ukraineCheckerBin.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {ukraineCheckerBin.AlphabetName}: {ukraineCheckerBin.AlphabetEntropy * binTextukraine.Length}");


                            double sumgolandish = 0;
                            double sumukraine = 0;
                            double sumgolandishBin = 0;
                            double sumukraineBin = 0;
                            foreach (KeyValuePair<char, double> x in chancesgolandish)
                            {
                                sumgolandish += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesukraine)
                            {
                                sumukraine += x.Value;
                            }

                            foreach (KeyValuePair<char, double> x in chancesgolandishBin)
                            {
                                sumgolandishBin += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesukraineBin)
                            {
                                sumukraineBin += x.Value;
                            }

                            Console.WriteLine($"Сумма шансов для украинского языка: {sumukraine}");
                            Console.WriteLine($"Сумма шансов для голландского языка: {sumgolandish}");
                            Console.WriteLine($"Сумма шансов для украинского языка (бинарный): {sumukraineBin}");
                            Console.WriteLine($"Сумма шансов для голландского языка (бинарный): {sumgolandishBin}");

                            ExcelDocumentCreator<char, double> excel = new ExcelDocumentCreator<char, double>(new System.IO.FileInfo(fileName));
                            excel.createWorksheet("third");
                            excel.addValuesFromDict(chancesgolandish, "third", 0);
                            excel.addValuesFromDict(chancesukraine, "third", 3);
                            excel.addValuesFromDict(chancesgolandishBin, "third", 5);
                            excel.addValuesFromDict(chancesukraineBin, "third", 7);
                            excel.pack.Save();


                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();

                            EntropyChecker golandishCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (Голландский)");
                            EntropyChecker ukraineCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (украинский)");

                            string golandishText = "obodovpavelandreevich";
                            string ukraineText = "ободовпавеландреевич";

                            string binTextgolandish = "";
                            string binTextukraine = "";

                            var textChr = Encoding.UTF8.GetBytes(golandishText);
                            foreach (int chr in textChr)
                            {
                                binTextgolandish += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            textChr = Encoding.UTF8.GetBytes(ukraineText);
                            foreach (int chr in textChr)
                            {
                                binTextukraine += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            Dictionary<char, int> golandishDictBin = golandishCheckerBin.alphabetListToDictionary();
                            Dictionary<char, int> ukraineDictBin = ukraineCheckerBin.alphabetListToDictionary();

                            golandishCheckerBin.getSymbolsCounts(binTextgolandish, golandishDictBin);
                            ukraineCheckerBin.getSymbolsCounts(binTextukraine, ukraineDictBin);

                            Dictionary<char, double> chancesgolandishBin = golandishCheckerBin.getSymbolsChances(binTextgolandish, golandishDictBin);
                            Dictionary<char, double> chancesukraineBin = ukraineCheckerBin.getSymbolsChances(binTextukraine, ukraineDictBin);

                            golandishCheckerBin.printAlphabet();
                            golandishCheckerBin.printChances(chancesgolandishBin);
                            golandishCheckerBin.computeTextEntropy(chancesgolandishBin);
                            golandishCheckerBin.printAlhabetEntropy();
                            ukraineCheckerBin.printAlphabet();
                            ukraineCheckerBin.printChances(chancesukraineBin);
                            ukraineCheckerBin.computeTextEntropy(chancesukraineBin);
                            ukraineCheckerBin.printAlhabetEntropy();

                            Console.WriteLine($"Ошибка = 0.1. Количество информации сообщения. Язык - {golandishCheckerBin.AlphabetName}: {golandishCheckerBin.computeTextEntropyWithError(chancesgolandishBin, 0.1) * binTextgolandish.Length}");
                            Console.WriteLine($"Ошибка = 0.5. Количество информации сообщения. Язык - {golandishCheckerBin.AlphabetName}: {golandishCheckerBin.computeTextEntropyWithError(chancesgolandishBin, 1) * binTextgolandish.Length}");
                            Console.WriteLine($"Ошибка = 1.0. Количество информации сообщения. Язык - {golandishCheckerBin.AlphabetName}: {golandishCheckerBin.computeTextEntropyWithError(chancesgolandishBin, 0.9999999) * binTextgolandish.Length}");

                            Console.WriteLine($"Ошибка = 0.1. Количество информации сообщения. Язык - {ukraineCheckerBin.AlphabetName}: {ukraineCheckerBin.computeTextEntropyWithError(chancesukraineBin, 0.1) * binTextukraine.Length}");
                            Console.WriteLine($"Ошибка = 0.5. Количество информации сообщения. Язык - {ukraineCheckerBin.AlphabetName}: {ukraineCheckerBin.computeTextEntropyWithError(chancesukraineBin, 1) * binTextukraine.Length}");
                            Console.WriteLine($"Ошибка = 1.0. Количество информации сообщения. Язык - {ukraineCheckerBin.AlphabetName}: {ukraineCheckerBin.computeTextEntropyWithError(chancesukraineBin, 0.9999999) * 0.97 * binTextukraine.Length}");


                            Console.ReadKey();

                            break;
                        }
                    case 5:
                        {
                            string inputText = File.ReadAllText("D:\\Sem_2\\KMZI\\Lab3\\DocumentConverter\\bin\\Debug\\net7.0\\golandish.txt");
                            string outputText = File.ReadAllText("D:\\Sem_2\\KMZI\\Lab3\\DocumentConverter\\bin\\Debug\\net7.0\\base64.txt");

                            EntropyChecker inputChecker = new EntropyChecker(inputText.ToList(), 0, inputText);
                            EntropyChecker outputChecker = new EntropyChecker(outputText.ToList(), 0, outputText);

                            Dictionary<char, int> inputDict = inputChecker.alphabetListToDictionary();
                            Dictionary<char, int> outputDict = outputChecker.alphabetListToDictionary();

                            inputChecker.getSymbolsCounts(inputText, inputDict);
                            outputChecker.getSymbolsCounts(outputText, outputDict);

                            Dictionary<char, double> inputChances = inputChecker.getSymbolsChances(inputText, inputDict);
                            Dictionary<char, double> outputChances = outputChecker.getSymbolsChances(outputText, outputDict);

                            inputChecker.printAlphabet();
                            inputChecker.printChances(inputChances);
                            double inputShannonEntropy = inputChecker.computeShannonEntropy(inputChances);
                            double inputHartleyEntropy = inputChecker.computeHartleyEntropy(inputChances);
                            double inputRedundancy = inputChecker.computeRedundancy(inputShannonEntropy, inputHartleyEntropy);
                            Console.WriteLine($"Энтропия Шеннона: {inputShannonEntropy}");
                            Console.WriteLine($"Энтропия Хартли: {inputHartleyEntropy}");
                            Console.WriteLine($"Избыточность: {inputRedundancy}");

                            outputChecker.printAlphabet();
                            outputChecker.printChances(outputChances);
                            double outputShannonEntropy = outputChecker.computeShannonEntropy(outputChances);
                            double outputHartleyEntropy = outputChecker.computeHartleyEntropy(outputChances);
                            double outputRedundancy = outputChecker.computeRedundancy(outputShannonEntropy, outputHartleyEntropy);
                            Console.WriteLine($"Энтропия Шеннона: {outputShannonEntropy}");
                            Console.WriteLine($"Энтропия Хартли: {outputHartleyEntropy}");
                            Console.WriteLine($"Избыточность: {outputRedundancy}");

                            Console.ReadKey();

                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
