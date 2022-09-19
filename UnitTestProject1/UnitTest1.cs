using System;
using Dominio.Model;
using Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Dominio.Enum;
using System.Collections.Generic;
using Dominio.Services;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    private IEndpointService endpointService;
    private List<Endpoint> _endpoints;
    private Endpoint obj1;
    private Endpoint obj2;

    public UnitTest1()
    {
      endpointService = new EndpointService();
      _endpoints = new List<Endpoint>();
      obj1 = new Endpoint()
      {
        MeterModel = MeterModel.NSX1P2W,
        MeterModelId = (int)MeterModel.NSX1P2W,
        SerialNumber = "1000",
        FirmwareVersion = "1.2",
        MeterNumber = 1,
        SwitchState = 0,
      };

      Endpoint obj2 = new Endpoint()
      {
        MeterModel = MeterModel.NSX1P3W,
        MeterModelId = (int)MeterModel.NSX1P3W,
        SerialNumber = "1001",
        FirmwareVersion = "1.2",
        MeterNumber = 1,
        SwitchState = 2,
      };
      _endpoints.Add(obj1);
      _endpoints.Add(obj2);


    }

    [TestMethod]
    public void TestMethod1()
    {
      Mock<IEndpointService> mock = new Mock<IEndpointService>();
      mock.Setup(e => e.Insert(obj1, _endpoints)).Returns(new List<Endpoint> { obj1 });
      var result = mock.Object.Insert(obj1, _endpoints);
      Assert.IsInstanceOfType(result, typeof(List<Endpoint>));
    }

    [TestMethod]
    public void TestMethod2()
    {
      Mock<IEndpointService> mock = new Mock<IEndpointService>();
      mock.Setup(e => e.GetBySerialNumber("1001", _endpoints)).Returns(obj2);
      var result = mock.Object.GetBySerialNumber("1001", _endpoints);
      Assert.AreEqual(obj2, result);
    }

    [TestMethod]
    public void TestMethod3()
    {
      Mock<IEndpointService> mock = new Mock<IEndpointService>();
      mock.Setup(e => e.Edit(_endpoints[1],_endpoints)).Returns(new List<Endpoint>() { obj1, obj2 });
      var result = mock.Object.GetBySerialNumber("1001", _endpoints);
      //Console.WriteLine("endpoints", _endpoints[0].FirmwareVersion);
      Assert.AreEqual(obj2, result);
    }

    [TestMethod]
    public void TestMethod4()
    {
      List<Endpoint> newList = new List<Endpoint>() { obj1, obj2 };

      Mock<IEndpointService> mock = new Mock<IEndpointService>();
      mock.Setup(e => e.Delete("1000",_endpoints)).Returns(newList.GetRange(0,1));
      var result = mock.Object.Delete("1000", _endpoints);
      Assert.AreEqual(newList.GetRange(0,1)[0].SerialNumber, result[0].SerialNumber);
    }

    //    [TestMethod]
    //    public void TestMethod2()
    //    {
    //      EndpointService endpointService = new EndpointService();
    //
    //      Mock<IEndpointService> mock = new Mock<IEndpointService>();
    //      mock.Setup(e => e.Delete("1001", _endpoints)).Returns(new List<Endpoint>() { obj1 });
    //      IEndpointService expectedResult = mock.Object;
    //      Endpoint result = obj1;
    //      Assert.IsInstanceOfType(result, typeof(Endpoint));
    //    }
  }
}
