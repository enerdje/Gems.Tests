﻿using System;
using OpenQA.Selenium;

namespace WebTests
{
    public class Program
    {
        static IWebDriver Browser;
        static readonly string url = @"https://xn--c1aaceme9acfqh.xn--p1ai/";
        static readonly string[] blocks = new string[] { "my-150", "gos-system", "urban-analytics", "other-products" };
 
        static void Main()
        {
            ContentBlocks(blocks);
            IsLinkExists(url, blocks[1]);
            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();
            Browser.Quit();
        }

        public static bool ContentBlocks(string[] blocks)
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Navigate().GoToUrl("https://gemsdev.ru/geometa/");
            try
            {
                foreach (string block in blocks)
                { IWebElement Element = Browser.FindElement(By.ClassName(block)); }
                return true;
            }
            catch (NoSuchElementException) { return false; }
        }

        public static bool IsLinkExists(string url, string block)
        {
            try
            {
                Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
                Browser.Navigate().GoToUrl("https://gemsdev.ru/geometa/");
                IWebElement Element = Browser.FindElement(By.ClassName(block));
                IWebElement Url = Browser.FindElement(By.CssSelector($"[href*='{url}']"));
                return true;
            }
            catch (NoSuchElementException) { return false; }
        }
    }
}