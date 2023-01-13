using Grobund.WPF.Core;

namespace Grobund.Tests
{
    [TestClass]
    public class RelayCommandTest
    {
        [TestMethod]
        public void CanExecuteTest()
        {
            // Arrange
            bool shouldMatchCanExecuteInput = false;

            bool CanExecute(object input)
            {
                shouldMatchCanExecuteInput = (bool) input;
                return true;
            }

            void Execute(object input)
            {

            }

            var command = new RelayCommand(Execute, CanExecute);

            // Act
            command.CanExecute(true);
            Assert.IsTrue(shouldMatchCanExecuteInput); // Assert

            command.CanExecute(false); // Act
            Assert.IsFalse(shouldMatchCanExecuteInput); // Assert
        }

        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            bool shouldMatchExecuteInput = false;

            void Execute(object input)
            {
                shouldMatchExecuteInput = (bool)input;
            }

            bool CanExecuteTrue(object input)
            {
                return true;
            }

            var command = new RelayCommand(Execute, CanExecuteTrue);

            // Act
            command.Execute(true);
            Assert.IsTrue(shouldMatchExecuteInput); // Assert

            // Act
            command.Execute(false);
            Assert.IsFalse(shouldMatchExecuteInput); // Assert
        }

    }
}