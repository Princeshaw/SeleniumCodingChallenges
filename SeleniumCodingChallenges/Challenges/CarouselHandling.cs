using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SeleniumCodingChallenges.Challenges
{
    class CarouselHandling
    {
        protected IWebDriver driver;
        [SetUp]
        public void init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.noon.com/uae-en/");

        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }


        public void click(By locator)
        {
            try
            {
                driver.FindElement(locator).Click();
            }
            catch
            {
                try {
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

                    jse.ExecuteScript("arguments[0].scrollIntoView()", driver.FindElement(locator));
                }
                catch(Exception e){
                    throw (e);
                }
            }
        }


        [Test]
        public void test() {

           int elementsCount = driver.FindElements(By.XPath("(//div[@class='sc-GTWni GkeGT'])[1]//div[@data-qa='product-name']//div")).Count;

            for(int i=1;i<=elementsCount;i++)
            {
                IWebElement e = driver.FindElement(By.XPath("((//div[@class='sc-GTWni GkeGT'])[1]//div[@data-qa='product-name']//div)["+i+"]"));
                bool isDisplayed = e.Displayed;
                if (!isDisplayed) {
                    click(By.XPath("(//div[@class='sc-GTWni GkeGT'])[1]//div[contains(@class,'swiper-button-next custom-navigation')]"));
                    e = driver.FindElement(By.XPath("((//div[@class='sc-GTWni GkeGT'])[1]//div[@data-qa='product-name']//div)[" + i + "]"));

                }
                Console.WriteLine(i+ " : "+ e.Text);
            }

        
        }
    }
}
