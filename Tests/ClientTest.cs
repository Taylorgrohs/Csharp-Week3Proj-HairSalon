using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hairsalon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_EqualOverrideTrueForSameDescription()
    {
      Client firstClient = new Client("Taylor", 1);
      Client secondClient = new Client("Taylor", 1);

      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_Save()
    {
      Client testClient = new Client("Taylor", 1);
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_SaveAssignsIdtoObject()
    {
      Client testClient = new Client("taylor", 1);
      testClient.Save();

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsClientDatabase()
    {
      Client testClient = new Client("Taylor", 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
