using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SieciClient
{
    class Program
    {
       

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl = new Client("test1");
                cl.run();
            }).Start();
            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl2 = new Client("test2");

                cl2.run();
            }).Start();
            //DEBUG
            
            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl00 = new Client("test3");

                cl00.run();
            }).Start();
            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl0 = new Client("test4");

                cl0.run();
            }).Start();
           /* new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl9 = new Client("test5");

                cl9.run();
            }).Start();
            /*new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl3 = new Client("test6");

                cl3.run();
            }).Start();
            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl5 = new Client("test7");

                cl5.run();
            }).Start();
           /* new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl6 = new Client("test8");

                cl6.run();
                
            }).Start();/*
            /*new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl7 = new Client("test2");

                cl7.run();
            }).Start();
            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;

                Client cl9 = new Client("test2");

                cl9.run();
            }).Start();
            */
        }
        


    }
}
