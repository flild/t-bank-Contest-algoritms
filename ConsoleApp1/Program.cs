//task 1  --> ввод 1-6,8-9,11            1 2 3 4 5 6 8 9 11
//task2 2 --> ввод 5  1 3 -1 10 -1       Yes 1 2 3 4 5
//task 3 --> abacaba abc 4               caba
//task 4 ==> 1 9                         2

using System;
using ConsoleApp1;
using ConsoleApp1.Alice;
using ConsoleApp1.Sber;
using ConsoleApp1.Tests;
Dictionary<string, string> inetrvalsData = new Dictionary<string, string>();
inetrvalsData.Add("1-6,8-9,11", "1 2 3 4 5 6 8 9 11 ");
inetrvalsData.Add("3-5,11-13", "3 4 5 11 12 13 ");
inetrvalsData.Add("1,7", "1 7 ");

Dictionary<string, string> SnowData = new Dictionary<string, string>();
SnowData.Add("5_1 3 -1 10 -1", "YES 1 2 3 4 5 ");
SnowData.Add("3_10 -1 4", "NO");
SnowData.Add("5_5 -1 6 -1 3", "NO");

Dictionary<string, string> PasswordData = new Dictionary<string, string>();
PasswordData.Add("abacaba_abc_4", "caba");
PasswordData.Add("abacaba_abc_3", "cab");
PasswordData.Add("rererer_avd_3", "-1");
PasswordData.Add("qwertyu_qwer_3", "-1");
PasswordData.Add("qwertyu_qwe_3", "qwe");

Dictionary<string, string> PrimeData = new Dictionary<string, string>();
PrimeData.Add("1 9", "2");
PrimeData.Add("3 6", "1");
PrimeData.Add("6 9", "1");
PrimeData.Add("75 125", "2");
PrimeData.Add("101101 101125", "0");
PrimeData.Add("1010100 1024000", "1");

Dictionary<string, string> HackersData = new Dictionary<string, string>();
HackersData.Add("00:00:00_5_" +
    //запросы к серверу
    "\"VK\" 00:10:21 A FORBIDEN_" +
    "\"T\" 00:00:21 A DENIED_" +
    "\"T\" 00:20:21 A ACCESSED_" +
    "\"VK\" 00:30:21 A ACCESSED_" +
    "\"YA\" 00:40:21 B ACCESSED",
    //результат
    "1 \"T\" 1 40 " +
    "1 \"YA\" 1 40 " +
    "3 \"VK\" 1 50 " );

HackersData.Add("01:00:00_3_" +
    //запросы к серверу
    "\"Team1\" 01:10:00 A FORBIDEN_" +
    "\"Team1\" 01:20:00 A ACCESSED_" +
    "\"Team2\" 01:40:00 B ACCESSED",
    //результат
    "1 \"Team1\" 1 40 " +
    "1 \"Team2\" 1 40 ");

HackersData.Add("23:00:00_2_" +
    //запросы к серверу
    "\"Team1\" 23:59:59 A PONG_" +
    "\"Team1\" 00:00:00 A ACCESSED",
    //результат
    "1 \"Team1\" 1 60 ");

Dictionary<string, string> GraphData = new Dictionary<string, string>();
GraphData.Add("5_" +
    "10 2 3 5_" +
    "5 4_" +
    "0_" +
    "4_" +
    "15 3",
    
    "25");
GraphData.Add("6_" +
    "2 2_" +
    "2 3_" +
    "15 4_" +
    "1 5_" +
    "2 6_" +
    "0",

    "22");





Tests taskTests = new Tests();
//my scripts
taskTests.TaskTests(new Task1Intervals(), inetrvalsData);
taskTests.TaskTests(new Task2Snow(), SnowData);
taskTests.TaskTests(new Task3Password(), PasswordData);
taskTests.TaskTests(new Task4PrimeList(), PrimeData);
taskTests.TaskTests(new Task5Hakers(), HackersData);
taskTests.TaskTests(new task6Graph(), GraphData);
//alice
Console.WriteLine("===============ALICE===============");
taskTests.TaskTests(new AliceTask1Interval(), inetrvalsData);
taskTests.TaskTests(new AliceTask4Prime(), PrimeData);
taskTests.TaskTests(new AliceTask6Graph(), GraphData);
//sber
Console.WriteLine("===============SBER===============");
taskTests.TaskTests(new SberTask1Intervals(), inetrvalsData);
taskTests.TaskTests(new SberTask3Password(), PasswordData);
taskTests.TaskTests(new SberTask4Prime(), PrimeData);
taskTests.TaskTests(new SberTask5Hackers(), HackersData); 
//taskTests.TaskTests(new SberTask6Graph(), GraphData);





