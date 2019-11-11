using System.Text;

namespace TheTankGame.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using Entities.Miscellaneous;
    using Entities.Parts;
    using Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {

        [Test]
        public void ValidateVehicleModel()
        {
            try
            {
                var vehicleModel = new Revenger("Stavri", 10, 10, 10, 10, 10, new VehicleAssembler());
            }
            catch (Exception ex)
            {
                var expectedResult = "Model cannot be null or white space!";

                Assert.AreEqual(expectedResult, ex.Message);
            }
        }

        [Test]
        public void ValidateAddedPartsCount()
        {
            var vehicleModel = new Revenger("Stavri", 10, 10, 10, 10, 10, new VehicleAssembler());

            vehicleModel.AddArsenalPart(new ArsenalPart("Uragan", 10, 10, 10));
            vehicleModel.AddEndurancePart(new EndurancePart("Tochki", 11, 11, 11));
            vehicleModel.AddShellPart(new ShellPart("Shtit", 11, 11, 11));

            var acuallCount = vehicleModel.Parts.Count();
            var expectedCount = 3;

            
            Assert.AreEqual(expectedCount, acuallCount);
        }

        [Test]
        public void validateToStringMethod()
        {
            StringBuilder sb = new StringBuilder();

            var vehicleModel = new Revenger("Stavri", 10, 10, 10, 10, 10, new VehicleAssembler());

            vehicleModel.AddArsenalPart(new ArsenalPart("Uragan", 10, 10, 10));
            vehicleModel.AddShellPart(new ShellPart("Shtit", 3, 4 ,5));
            vehicleModel.AddEndurancePart(new EndurancePart("Tochki", 11, 11, 3));

            sb.AppendLine("Revenger - Stavri");
            sb.AppendLine($"Total Weight: 34.000");
            sb.AppendLine($"Total Price: 35.000");
            sb.AppendLine($"Attack: 20");
            sb.AppendLine($"Defense: 15");
            sb.AppendLine($"HitPoints: 13");
            sb.Append("Parts: Uragan, Shtit, Tochki");

            var expectedResult = sb.ToString().TrimEnd();
            var actualResult = vehicleModel.ToString();

            Assert.AreEqual(expectedResult,actualResult);


        }


    }
}