#:sdk MSTest.Sdk@4.5.2

using static B_BON;

public static class B_BON
{

}
public static class B_EPIE
{

}
public static class B_MASTRO
{

}
public static class B_PINATO
{

}

[TestClass]
public class TrackBTests
{
    [TestMethod]
    public void Should_ReturnMinusOne_When_GbIsNegative()
    {
        Assert.AreEqual(-1.0, CalculateStorageCost(-1, false), 0.001,
            "Regola: GB negativi non sono ammessi.");
    }

    [TestMethod]
    public void Should_ReturnZero_When_GbIsUpTo10()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(10, false), 0.001,
            "Regola: fino a 10 GB compresi il servizio è gratuito.");
    }

    [TestMethod]
    public void Should_Charge150PerGb_When_GbBetween11And50()
    {
        Assert.AreEqual(1.50, CalculateStorageCost(11, false), 0.001,
            "Regola: 11 GB = 1 GB eccedente a 1.50€.");
    }

    [TestMethod]
    public void Should_ChargeCorrectly_When_GbExceeds50()
    {
        Assert.AreEqual(61.0, CalculateStorageCost(51, false), 0.001,
            "Regola: 51 GB = 60€ (fascia 11-50) + 1.00€ (1 GB oltre 50).");
    }

    [TestMethod]
    public void Should_Apply20PercentDiscount_When_PromotionIsTrue()
    {
        Assert.AreEqual(48.0, CalculateStorageCost(50, true), 0.001,
            "Regola: 60€ con promozione -20% diventa 48€.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_ListHasLessThanTwoElements()
    {
        Assert.IsFalse(HasLatencySpike([100]),
            "Regola: servono almeno 2 misurazioni per calcolare un salto.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_JumpIsExactly50Ms()
    {
        Assert.IsFalse(HasLatencySpike([10, 60]),
            "Regola di confine: incremento di 50 ms non basta, deve essere STRETTAMENTE > 50 ms.");
    }

    [TestMethod]
    public void Should_ReturnTrue_When_JumpExceeds50Ms()
    {
        Assert.IsTrue(HasLatencySpike([10, 61]),
            "Regola: incremento di 51 ms deve far scattare lo spike.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_LatencyDecreases()
    {
        Assert.IsFalse(HasLatencySpike([100, 20]),
            "Regola: un calo improvviso di latenza non è uno spike.");
    }

    [TestMethod]
    public void Should_ReturnEmptyDictionary_When_UserListIsEmpty()
    {
        var result = GroupUsersByRole([]);
        Assert.AreEqual(0, result.Count,
            "Regola: lista vuota produce mappa vuota.");
    }

    [TestMethod]
    public void Should_GroupUsersCorrectly_ByRole()
    {
        var result = GroupUsersByRole([("Luca", "ADMIN"), ("Anna", "USER"), ("Marco", "ADMIN")]);

        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Luca", "Marco" }, result["ADMIN"]);
        CollectionAssert.AreEquivalent(new List<string> { "Anna" }, result["USER"]);
    }


    [TestMethod]
    public void Should_CalculateStorage_When_NegativeWithPromotion()
    {
        Assert.AreEqual(-1.0, CalculateStorageCost(-1, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_Zero()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(0, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_FreeWithPromotion()
    {
        Assert.AreEqual(0.0, CalculateStorageCost(10, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_Exactly50()
    {
        Assert.AreEqual(60.0, CalculateStorageCost(50, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_FarAbove50()
    {
        Assert.AreEqual(90.0, CalculateStorageCost(80, false), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_PromotionInMiddleRange()
    {
        Assert.AreEqual(1.2, CalculateStorageCost(11, true), 0.001);
    }

    [TestMethod]
    public void Should_CalculateStorage_When_PromotionAbove50()
    {
        Assert.AreEqual(48.8, CalculateStorageCost(51, true), 0.001);
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_Empty()
    {
        Assert.AreEqual(false, HasLatencySpike([]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_JumpAtLastPair()
    {
        Assert.AreEqual(true, HasLatencySpike([10, 20, 80]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_JumpAtFirstPair()
    {
        Assert.AreEqual(true, HasLatencySpike([10, 80, 85]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_EqualMeasurements()
    {
        Assert.AreEqual(false, HasLatencySpike([100, 100, 100]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_AllJumpsBelowThreshold()
    {
        Assert.AreEqual(false, HasLatencySpike([10, 20, 30, 40]));
    }

    [TestMethod]
    public void Should_DetectLatencySpike_When_PeakEqualsFirstMeasurement()
    {
        Assert.AreEqual(true, HasLatencySpike([100, 10, 100]));
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_SingleUser()
    {
        var result = GroupUsersByRole([("Luca", "ADMIN")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Luca" }, result["ADMIN"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_OneRole()
    {
        var result = GroupUsersByRole([("Anna", "USER"), ("Marco", "USER"), ("Sara", "USER")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Anna", "Marco", "Sara" }, result["USER"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_AllRolesDiffer()
    {
        var result = GroupUsersByRole([("A", "ADMIN"), ("B", "USER"), ("C", "GUEST")]);
        Assert.AreEqual(3, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "A" }, result["ADMIN"]);
        CollectionAssert.AreEquivalent(new List<string> { "B" }, result["USER"]);
        CollectionAssert.AreEquivalent(new List<string> { "C" }, result["GUEST"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_RolesAreInterleaved()
    {
        var result = GroupUsersByRole([("A", "USER"), ("B", "ADMIN"), ("C", "USER"), ("D", "ADMIN")]);
        Assert.AreEqual(2, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "A", "C" }, result["USER"]);
        CollectionAssert.AreEquivalent(new List<string> { "B", "D" }, result["ADMIN"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_DuplicateUsers()
    {
        var result = GroupUsersByRole([("Luca", "ADMIN"), ("Luca", "ADMIN")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Luca", "Luca" }, result["ADMIN"]);
    }

    [TestMethod]
    public void Should_GroupAllUsers_When_UnknownRole()
    {
        var result = GroupUsersByRole([("Bot", "SERVICE")]);
        Assert.AreEqual(1, result.Count);
        CollectionAssert.AreEquivalent(new List<string> { "Bot" }, result["SERVICE"]);
    }

    [TestMethod]
    public void Should_RejectExactly50MsJump_InsideLongerList()
    {
        Assert.IsFalse(HasLatencySpike([10, 60, 70]));
    }
}
