using IS.DZ03.Api.Controllers;
using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Model.Entities;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IS.DZ03.UnitTest
{
    public class ZadatakTest
    {
        public Mock<IZadatakService> mock = new Mock<IZadatakService>();

        private readonly IList<ZadatakInfoResult> _zadaci = new List<ZadatakInfoResult>
        {
            new ZadatakInfoResult(
                new Zadatak {Zadatakid = 1, Opis = "Test 1", Zaposlenikid = 2, Korisnickasluzbaid = 1, Statuszadatkaid = 1, Uslugaid = 1}, "Ivan Horvat"),
            new ZadatakInfoResult(
                new Zadatak {Zadatakid = 2, Opis = "Test 2", Zaposlenikid = 1, Korisnickasluzbaid = 2, Statuszadatkaid = 1, Uslugaid = 3}, "Ivana Horvat")
        };

        [Fact]
        public void GetTasks()
        {
        }
    }
}
