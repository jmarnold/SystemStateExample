using System;

namespace SystemStateExample
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new SystemStateExampleApplication()
                .BuildApplication()
                .Bootstrap();
        }
    }
}