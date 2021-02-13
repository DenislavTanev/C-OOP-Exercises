using NUnit.Framework;
using System;

public class WarriorTests
{
    private Warrior warrior;
    private string name = "Piroman";
    private int damage = 70;
    private int hp = 100;
    [SetUp]
    public void Setup()
    {
        warrior = new Warrior(name, damage, hp);
    }

    [Test]
    public void TryToSetWrongName()
    {
        Assert.Throws<ArgumentException>(() =>
        warrior = new Warrior("", damage, hp));
    }
    [Test]
    public void TestToGetName()
    {
        Assert.AreEqual(warrior.Name, name);
    }
    [Test]
    public void TryToSetWrongZeroDamage()
    {
        Assert.Throws<ArgumentException>(() =>
        warrior = new Warrior(name, 0, hp));
    }
    [Test]
    public void TryToSetWrongNegativeDamage()
    {
        Assert.Throws<ArgumentException>(() =>
        warrior = new Warrior(name, -10, hp));
    }
    [Test]
    public void TestToGetDamage()
    {
        Assert.AreEqual(warrior.Damage, damage);
    }
    [Test]
    public void TryToSetWrongHP()
    {
        Assert.Throws<ArgumentException>(() =>
        warrior = new Warrior(name, damage, -10));
    }
    [Test]
    public void TestToGetHP()
    {
        Assert.AreEqual(warrior.HP, hp);
    }
    [Test]
    public void WarriorCannotAttackIfHisHPAre30()
    {
        var attacker = new Warrior("Gosho", 10, 30);
        var defender = new Warrior("Pesho", 10, 40);
        Assert.Throws<InvalidOperationException>(() =>
        attacker.Attack(defender)
        );
    }
    [Test]
    public void WarriorCannotAttackIfHisHPAreBelow30()
    {
        var attacker = new Warrior("Gosho", 10, 0);
        var defender = new Warrior("Pesho", 10, 40);
        Assert.Throws<InvalidOperationException>(() =>
        attacker.Attack(defender)
        );
    }
    [Test]
    public void WarriorCannotAttackWarriorsWhichHPAre30()
    {
        var attacker = new Warrior("Gosho", 10, 40);
        var defender = new Warrior("Pesho", 10, 30);
        Assert.Throws<InvalidOperationException>(() =>
        attacker.Attack(defender)
        );
    }
    [Test]
    public void WarriorCannotAttackWarriorsWhichHPAreBelow30()
    {
        var attacker = new Warrior("Gosho", 10, 40);
        var defender = new Warrior("Pesho", 10, 0);
        Assert.Throws<InvalidOperationException>(() =>
        attacker.Attack(defender)
        );
    }
    [Test]
    public void TryToAttackTooStrongEnemy()
    {
        var attacker = new Warrior("Gosho", 10, 40);
        var defender = new Warrior("Pesho", 59, 40);
        Assert.Throws<InvalidOperationException>(() =>
        attacker.Attack(defender)
        );
    }
    [Test]
    public void AttackNormal()
    {
        var otherWarrior = new Warrior("Gosho", 60, 500);
        otherWarrior.Attack(warrior);
        var result = 40;

        Assert.AreEqual(warrior.HP, result);
    }
    [Test]
    public void AttackWithMoreDamageToHealth()
    {
        var otherWarrior = new Warrior("Gosho", 120, 40);
        warrior = new Warrior("Pesho", 20, 50);
        otherWarrior.Attack(warrior);
        var result = 0;

        Assert.AreEqual(warrior.HP, result);
    }
}