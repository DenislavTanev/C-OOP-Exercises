using NUnit.Framework;
using System;

public class CarTests
{
    private Car car;
    private string make = "Hello";
    private string model = "BMW";
    private double fuelConsumption = 2.33;
    private double fuelCapacity = 75.99;
    private double fuelAmount = 0;

    [SetUp]
    public void Setup()
    {
        car = new Car(make, model, fuelConsumption, fuelCapacity);
    }
    [Test]
    public void TestMakeSetterIsNull()
    {
        Assert.Throws<ArgumentException>(() =>
        car = new Car("", model, fuelConsumption, fuelCapacity));
    }
    [Test]
    public void TestModelSetterIsNull()
    {
        Assert.Throws<ArgumentException>(() =>
        car = new Car(make, "", fuelConsumption, fuelCapacity));
    }
    [Test]
    public void TestFuelConsumptionSetterIsNegative()
    {
        Assert.Throws<ArgumentException>(() =>
        car = new Car(make, model, -10, fuelCapacity));
    }
    [Test]
    public void TestFuelCapacitySetterIsZero()
    {
        Assert.Throws<ArgumentException>(() =>
        car = new Car(make, model, fuelConsumption, 0));
    }
    [Test]
    public void TestFuelCapacitySetterIsNegative()
    {
        Assert.Throws<ArgumentException>(() =>
        car = new Car(make, model, fuelConsumption, -10));
    }
    [Test]
    public void TestMakeGetter()
    {
        Assert.AreEqual(car.Make, make);
    }
    [Test]
    public void TestModelGetter()
    {
        Assert.AreEqual(car.Model, model);
    }
    [Test]
    public void TestFuelConsumptionGetter()
    {
        Assert.AreEqual(car.FuelConsumption, fuelConsumption);
    }
    [Test]
    public void TestFuelCapacityGetter()
    {
        Assert.AreEqual(car.FuelCapacity, fuelCapacity);
    }
    [Test]
    public void TestFuelAmountGetter()
    {
        Assert.AreEqual(car.FuelAmount, fuelAmount);
    }
    [Test]
    public void TestRefuelNegativeFuel()
    {
        Assert.Throws<ArgumentException>(() =>
        car.Refuel(-10));
    }
    [Test]
    public void TestRefuel()
    {
        car.Refuel(10);
        car.Refuel(30);

        var resul = 40;

        Assert.AreEqual(car.FuelAmount, resul);
    }
    [Test]
    public void TestRefuelToMaxCapacity()
    {
        car.Refuel(100);

        var resul = 75.99;

        Assert.AreEqual(car.FuelAmount, resul);
    }
    [Test]
    public void TestTryDriveWihotuNeededFuel()
    {
        Assert.Throws<InvalidOperationException>(() =>
        car.Drive(200));
    }
    [Test]
    public void TestDriveWithNeededFuel()
    {
        car.Refuel(30);
        car.Drive(10);

        var result = 30 - 0.233;

        Assert.AreEqual(car.FuelAmount, result);
    }
    [Test]
    public void TestRefuelWithZero()
    {

        Assert.Throws<ArgumentException>(() =>
        {
            this.car.Refuel(0);
        });
    }
}