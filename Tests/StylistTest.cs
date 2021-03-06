using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hairsalon_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_StylistEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Stylist firstStylist = new Stylist("Dean");
      Stylist secondStylist = new Stylist("Dean");

      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_Save_SavesStylistToDatabase()
    {
      Stylist testStylist = new Stylist("Dean");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToStylistObject()
    {
      Stylist testStylist = new Stylist("Dean");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Dean");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void Test_GetClients_RetrievesAllClientsWithStylist()
    {
      Stylist testStylist = new Stylist("Dean");
      testStylist.Save();

      Client firstClient = new Client("taylor", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("konrad", testStylist.GetId());
      secondClient.Save();

      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }
    [Fact]
    public void Test_Update_StylistName()
    {
      Stylist testStylist = new Stylist("Dean");
      testStylist.Save();
      testStylist.Update("Don");

      Stylist newStylist = new Stylist("Don");

      Assert.Equal(testStylist, newStylist);
    }
    [Fact]
    public void Test_Delete_StylistName()
    {
      Stylist testStylist1 = new Stylist("Dean");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("Don");
      testStylist2.Save();
      testStylist2.Delete();

      List<Stylist> testStylistList = new List<Stylist>{testStylist1};
      List<Stylist> testStylistList2 = Stylist.GetAll();

      Assert.Equal(testStylistList, testStylistList2);
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
