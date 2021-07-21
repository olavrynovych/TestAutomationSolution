
using OpenQA.Selenium;

namespace PageObject
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement LoginTextField => Driver.FindElement(By.Id("user-name"));

        private IWebElement PasswordTextField => Driver.FindElement(By.Id("password"));
        private IWebElement LoginBtn => Driver.FindElement(By.Id("login-button"));


        public void SetLogin(string login) 
        {
            LoginTextField.SendKeys(login);
        }
        public void SetPassword(string pass)
        {
            PasswordTextField.SendKeys(pass);
        }
        public void ClickLogin()
        {
            LoginBtn.Click();
        }
    }
}
