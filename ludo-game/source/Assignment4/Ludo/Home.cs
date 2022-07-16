using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Ludo
{
    public class Home<T> where T : class
    {
        public List<T> Message;
        public List<T> data;
        public Home()
        {
            GetWelcomeText();
            SelectPlayerText();
        }

        public void GetWelcomeText()
        {
            string[] paragraph1 = File.ReadAllLines("message/welcome.txt");
            Message = new List<T>();
            SetMessage(paragraph1);
            ShowMesage();
        }

        public void SelectPlayerText()
        {
            string[] paragraph2 = File.ReadAllLines("message/player.txt");
            Message = new List<T>();
            SetMessage(paragraph2);
            ShowMesage();
        }

        public void SetMessage(string[] lines)
        {
            dynamic _line;
            var i = 0;

            foreach (var line in lines)
            {
                _line = line;
                Message.Add(_line);
            }
        }

        public void ShowMesage()
        {
            data = (from message in Message select message).ToList();

            data.PrintData<T>();
        }
    }

    public static class MyExtention
    {
        public static void PrintData<T>(this List<T> data)
        {
            foreach (var line in data)
                Console.WriteLine(line);
        }
    }
}
