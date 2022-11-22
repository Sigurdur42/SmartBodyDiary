using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartBodyDiaryDomain.Import;

namespace SmartBodyDomain.Tests
{
    [TestFixture]
    internal class Export2Libra
    {
        [Test, Explicit]
        public void Export2LibraTest()
        {
            var fileName = "FitAndLift.2022-11-22.yaml";
            var inputFile = Path.Combine("TestData", fileName);
            File.Exists(inputFile).Should().BeTrue($"The test file '{fileName}' should exists on hard disc");

            var importer = new FitAndLiftImport();
            var data = importer.Import(new FileInfo(inputFile));

            var cvsData = data.Weights
                .OrderBy(_=>_.Day)
                .Select(_ =>$"{_.Day.ToString("o", CultureInfo.InvariantCulture)}T06:00:00.000Z;{_.Weight.ToString("F1", CultureInfo.InvariantCulture)};;;;")
                .ToArray();

            var result = string.Join("\n", cvsData);

        }
    }
}
