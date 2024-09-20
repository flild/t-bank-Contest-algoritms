//task 1  --> ввод 1-6,8-9,11            1 2 3 4 5 6 8 9 11
//task2 2 --> ввод 5  1 3 -1 10 -1       Yes 1 2 3 4 5
//task 3 --> abacaba abc 4               caba
//task 4 ==> 1 9                         2

using System;
using ConsoleApp1;
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


Tests taskTests = new Tests();
taskTests.TaskTests(new Task1Intervals(), inetrvalsData);
taskTests.TaskTests(new Task2Snow(), SnowData);
taskTests.TaskTests(new Task3Password(), PasswordData);



