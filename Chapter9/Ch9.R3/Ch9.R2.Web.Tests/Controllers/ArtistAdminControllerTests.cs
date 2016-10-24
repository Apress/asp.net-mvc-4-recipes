using Ch7.SharedAPI;
using Ch9.R2.Web.Controllers;
using Ch9.R2.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ch9.R2.Web.Tests.Controllers
{
    [TestClass]
    public class ArtistAdminControllerTests
    {
        #region List Action

        [TestMethod]
        public void List_ReturnsNewArtistList_ToListView()
        {
            //arrange
            IArtistRepository fakeArtistRepository =
                new Ch9.R2.Web.Models.Fakes.StubIArtistRepository
                {
                    GetNewArtistList = () =>
                    {
                        return new List<Artist>{
                            new Artist{ CreateDate= new DateTime(2012,5,1),
                                 UserName="TestUser1",
                                 EmailAddress = "TestUser1@myonlineband.com",
                                 ArtistId = 1,
                                 WebSite = "http://cnn.com"
                            }
                        };
                    }
                };
            ArtistAdminController controller = new ArtistAdminController(fakeArtistRepository);

            //act
            var result = controller.List() as ViewResult;

            //assert
            var model = (List<Artist>)result.ViewData.Model;
            CollectionAssert.AllItemsAreInstancesOfType(model, typeof(Artist));

        }

        [TestMethod]
        public void List_ReturnsListView()
        {
            //arrange
            IArtistRepository fakeArtistRepository =
                new Ch9.R2.Web.Models.Fakes.StubIArtistRepository { };
            string expected = "List";
            ArtistAdminController controller = new ArtistAdminController(fakeArtistRepository);
            //act
            var result = controller.List() as ViewResult;

            //assert
            Assert.AreEqual(expected, result.ViewName);

        }

        

        [TestMethod]
        public void List_ReturnsEmptyNewArtistList_ToListView()
        {
            //arrange
            string expectedViewBagMessage = "No New Artists Found";
            IArtistRepository fakeArtistRepository =
                new Ch9.R2.Web.Models.Fakes.StubIArtistRepository
                {
                    GetNewArtistList = () =>
                    {
                        return new List<Artist>();
                    }
                };
            ArtistAdminController controller = new ArtistAdminController(fakeArtistRepository);

            //act
            var result = controller.List() as ViewResult;

           // assert
            Assert.AreEqual(result.ViewBag.Message, expectedViewBagMessage);

        }

        #endregion
        #region ReviewAction


        #endregion
        #region DeleteConfirm


        #endregion


        #region DeleteCompleted


        #endregion

        #region DeleteFailed

        #endregion
    }
}
