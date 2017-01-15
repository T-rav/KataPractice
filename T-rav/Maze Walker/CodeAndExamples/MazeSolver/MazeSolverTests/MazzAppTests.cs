using System;
using System.Collections.Generic;
using System.Linq;
using MazeSolver;
using NUnit.Framework;

namespace MazeSolverTests
{
    [TestFixture]
    public class MazzAppTests
    {

        [Test]
        public void Run_WhenMaze1_ShouldSolveMaze()
        {
            //---------------Set up test pack-------------------
            var appendPath = TestContext.CurrentContext.TestDirectory;
            var mazeFile = @"\MazeFiles\maze1.txt";
            var file = $"{appendPath}{mazeFile}";
            var app = new MazeApp();
            var outputLines = new List<string>();
            var output = new Action<string>((s) => { outputLines.Add(s);});
            //---------------Execute Test ----------------------
            app.Run(file, output);
            //---------------Test Result -----------------------
            Assert.AreEqual("Reached end of maze! :)", outputLines.LastOrDefault());
        }

        [Test]
        public void Run_WhenMaze3_ShouldSolveMaze()
        {
            //---------------Set up test pack-------------------
            var appendPath = TestContext.CurrentContext.TestDirectory;
            var mazeFile = @"\MazeFiles\maze3.txt";
            var file = $"{appendPath}{mazeFile}";
            var app = new MazeApp();
            var outputLines = new List<string>();
            var output = new Action<string>((s) => { outputLines.Add(s); });
            //---------------Execute Test ----------------------
            app.Run(file, output);
            //---------------Test Result -----------------------
            Assert.AreEqual("Reached end of maze! :)", outputLines.LastOrDefault());
        }

        [Test]
        public void Run_WhenMaze4_ShouldSolveMaze()
        {
            //---------------Set up test pack-------------------
            var appendPath = TestContext.CurrentContext.TestDirectory;
            var mazeFile = @"\MazeFiles\maze4.txt";
            var file = $"{appendPath}{mazeFile}";
            var app = new MazeApp();
            var outputLines = new List<string>();
            var output = new Action<string>((s) => { outputLines.Add(s); });
            //---------------Execute Test ----------------------
            app.Run(file, output);
            //---------------Test Result -----------------------
            Assert.AreEqual("Reached end of maze! :)", outputLines.LastOrDefault());
        }

    }
}
