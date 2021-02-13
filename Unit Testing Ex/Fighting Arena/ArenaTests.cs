using NUnit.Framework;
using System;
using System.Collections.Generic;

public class ArenaTests
{
    private Arena arena;
    private Warrior attacker = new Warrior("Pesho", 100, 200);
    private Warrior defender = new Warrior("Gosho", 100, 200);

    [SetUp]
    public void Setup()
    {
        arena = new Arena();
    }

    [Test]
    public void TestCountOfWarriors()
    {
        arena.Enroll(new Warrior("Dimitar", 60, 300));

        Assert.AreEqual(arena.Count, 1);
    }
    [Test]
    public void TestEnrollError()
    {
        arena.Enroll(new Warrior("Dimitar", 60, 300));

        Assert.Throws<InvalidOperationException>(() =>
        arena.Enroll(new Warrior("Dimitar", 60, 300))
        );
    }
    [Test]
    public void TestCollectionCount()
    {
        arena.Enroll(new Warrior("Dimitar", 60, 100));
        List<Warrior> warior = new List<Warrior>();
        warior.Add(new Warrior("Dimitar", 60, 100));
        Assert.AreEqual(arena.Warriors.Count, warior.Count);
    }
    [Test]
    public void TestCollection()
    {
        Arena arena = new Arena();
        arena.Enroll(attacker);
        arena.Enroll(defender);

        var expected = new List<Warrior> { attacker, defender };

        CollectionAssert.AreEqual(expected, arena.Warriors);
    }
    [Test]
    public void Attack()
    {
        var attackerWarrior = new Warrior("Pesho", 60, 100);
        var deffenderWarrior = new Warrior("Gosho", 40, 200);
        arena.Enroll(attackerWarrior);
        arena.Enroll(deffenderWarrior);

        arena.Fight("Pesho", "Gosho");
        
        Assert.AreEqual(deffenderWarrior.HP, 140);
    }
    [Test]
    public void AttackWithMissingAttacker()
    {
        arena.Enroll(defender);

        Assert.Throws<InvalidOperationException>(() =>
        arena.Fight("Pesho", "Gosho"));
    }
    [Test]
    public void AttackWithMissingAttackerName()
    {
        arena.Enroll(defender);

        Assert.Throws<InvalidOperationException>(() =>
        arena.Fight(null, "Gosho"));
    }
    [Test]
    public void AttackWithMissingDefenderName()
    {
        arena.Enroll(attacker);

        Assert.Throws<InvalidOperationException>(() =>
        arena.Fight("Pesho", "Gosho"));
    }
    [Test]
    public void AttackWithMissingDefender()
    {
        arena.Enroll(attacker);

        Assert.Throws<InvalidOperationException>(() =>
        arena.Fight("Pesho", null));
    }
}
