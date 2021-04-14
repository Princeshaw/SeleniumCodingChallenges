using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCodingChallenges.Challenges
{
    class WorldPopulationCounts
    {
        protected IWebDriver driver;
        [SetUp]
        public void init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.worldometers.info/world-population/");

        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }

        public string GetPopulationCount(string locator)
        {
            return (driver.FindElement(By.XPath(locator)).Text);
        }

        [Test]
        public void Test()
        {

            string currentCountXpath = "//div[@class='maincounter-number']//span[@class='rts-counter']";

            string todayBirthsCountXpath = "//div[@class='sec-counter']//span[@rel='births_today']";

            string todayDeathsCountXpath = "//div[@class='sec-counter']//span[@rel='dth1s_today']";

            string todayGrowthCountXpath = "//div[@class='sec-counter']//span[@rel='absolute_growth']";

            string thisYearBirthsCountXpath = "//div[@class='sec-counter']//span[@rel='births_this_year']";

            string thisYearDeathsCountXpath = "//div[@class='sec-counter']//span[@rel='dth1s_this_year']";

            string thisYearGrowthCountXpath = "//div[@class='sec-counter']//span[@rel='absolute_growth_year']";


            int time = 1;
            while (true)
            {
                if (time == 21)
                    break;
                string totalCurrentCount = GetPopulationCount(currentCountXpath);

                string todayBirthsCount = GetPopulationCount(todayBirthsCountXpath);

                string todayDeathsCount = GetPopulationCount(todayDeathsCountXpath);

                string todayGrowthCount = GetPopulationCount(todayGrowthCountXpath);

                string thisYearBirthsCount = GetPopulationCount(thisYearBirthsCountXpath);

                string thisYearDeathsCount = GetPopulationCount(thisYearDeathsCountXpath);

                string thisYearGrowthCount = GetPopulationCount(thisYearGrowthCountXpath);



                Console.WriteLine(String.Format("Time {0} sec, \n Current World Population : {1} \n " +
                    "Births today : {2} \t\t Births this year : {5}  \n " +
                    "Deaths today : {3} \t\t Deaths this year : {6} \n " +
                    "Population Growth today : {4} \t\t BPopulation Growth this year : {7} ", time, totalCurrentCount, todayBirthsCount, todayDeathsCount, todayGrowthCount, thisYearBirthsCount, thisYearDeathsCount, thisYearGrowthCount));

                Thread.Sleep(1000);
                time++;

            }

        }
    }
}
