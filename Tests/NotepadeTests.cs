using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowStripControls;

namespace AutoTestNotepad
{
    [TestClass]
    public class NotepadeTests
    {
        [TestMethod]
        public void SavingFileTest()
        {
            var application = Application.Launch("notepad");

            Assert.IsNotNull(application);

            var mainWindow = application.GetWindow(SearchCriteria.ByText("Безымянный – Блокнот"), InitializeOption.NoCache);

            mainWindow.Get<TextBox>(SearchCriteria.ByText("Текстовый редактор")).Enter("..,---->0_-");

            var menu = mainWindow.Get<MenuBar>(SearchCriteria.ByAutomationId("MenuBar"));

            menu.MenuItem("Файл", "Сохранить").Click();

            var windowSaveFileDialog = mainWindow.ModalWindow("Сохранение");

            windowSaveFileDialog.MdiChild(SearchCriteria.ByAutomationId("1001")).Enter(@"D:\test.txt");

            windowSaveFileDialog.Get<Button>(SearchCriteria.ByText("Сохранить")).Click();

            if (File.Exists(@"D:\test.txt"))
            {
                var windowConfirmationDialog = windowSaveFileDialog.ModalWindow("Подтвердить сохранение в виде");

                if (windowConfirmationDialog != null)
                    windowConfirmationDialog.Get<Button>(SearchCriteria.ByText("Да")).Click();
            }

            application.Close();

            Assert.IsTrue(File.Exists(@"D:\test.txt"));
            Assert.AreEqual(File.ReadAllText(@"D:\test.txt"), "..,---->0_-");
        }
    }
}
