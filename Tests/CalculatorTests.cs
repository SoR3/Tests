using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace AutoTestCalculate
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Multiplicate()
        {
            var _ = Application.Launch(@"C:\Windows\system32\calc.exe");
            Thread.Sleep(1000);
            Process process = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle.StartsWith("Calculator"));

            Assert.IsNotNull(process);

            Application application = Application.Attach(process.Id);
            var window = application.GetWindow("Calculator");
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("Multiply by").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("Equals").RaiseClickEvent();

            var answer = window.GetElement(SearchCriteria.ByAutomationId("CalculatorResults")).Current.Name;

            application.Close();

            Assert.AreEqual(answer, "Display is 1 234 321");
        }

        [TestMethod]
        public void Minus()
        {
            var _ = Application.Launch(@"C:\Windows\system32\calc.exe");
            Thread.Sleep(1000);
            Process process = Process.GetProcesses().FirstOrDefault(x => x.MainWindowTitle.StartsWith("Calculator"));

            Assert.IsNotNull(process);

            Application application = Application.Attach(process.Id);
            var window = application.GetWindow("Calculator");

            window.Get<Button>("Two").RaiseClickEvent();
            window.Get<Button>("Two").RaiseClickEvent();
            window.Get<Button>("Two").RaiseClickEvent();
            window.Get<Button>("Two").RaiseClickEvent();
            window.Get<Button>("Minus").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("One").RaiseClickEvent();
            window.Get<Button>("Equals").RaiseClickEvent();

            var answer = window.GetElement(SearchCriteria.ByAutomationId("CalculatorResults")).Current.Name;

            application.Close();

            Assert.AreEqual(answer, "Display is 5");
        }
    }
}
