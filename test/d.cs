#:sdk MSTest.Sdk@4.5.2

using static D_CECHET;

public static class D_CECHET
{

}
public static class D_GRATTONI
{

}
public static class D_NARDER
{

}
public static class D_SOLONYSHYN
{

}

[TestClass]
public class TrackDTests
{
    [TestMethod]
    public void Should_ReturnInvalid_When_CodeIsZeroOrNegative()
    {
        Assert.AreEqual("INVALID", CategorizeEventCode(0),
            "Regola: codice <= 0 non è valido.");
    }

    [TestMethod]
    public void Should_ReturnCritical_When_DivisibleBy4And6()
    {
        Assert.AreEqual("CRITICAL_SYS_APP", CategorizeEventCode(12),
            "Regola: 12 è divisibile sia per 4 che per 6.");
    }

    [TestMethod]
    public void Should_ReturnSys_When_DivisibleOnlyBy4()
    {
        Assert.AreEqual("SYS", CategorizeEventCode(8),
            "Regola: 8 è divisibile per 4 ma non per 6.");
    }

    [TestMethod]
    public void Should_ReturnApp_When_DivisibleOnlyBy6()
    {
        Assert.AreEqual("APP", CategorizeEventCode(18),
            "Regola: 18 è divisibile per 6 ma non per 4.");
    }

    [TestMethod]
    public void Should_ReturnNumberAsString_When_NotDivisibleBy4Or6()
    {
        Assert.AreEqual("7", CategorizeEventCode(7),
            "Regola fallback: 7 non è divisibile né per 4 né per 6.");
    }

    [TestMethod]
    public void Should_SumOnlyOddIndices()
    {
        Assert.AreEqual(60, SumOddIndexElements([10, 20, 30, 40, 50]),
            "Regola: deve sommare gli elementi agli indici 1 (20) e 3 (40).");
    }

    [TestMethod]
    public void Should_ReturnZero_When_NoOddIndicesExist()
    {
        Assert.AreEqual(0, SumOddIndexElements([100]),
            "Regola: lista con 1 solo elemento ha solo l'indice 0 (pari).");
    }

    [TestMethod]
    public void Should_ReturnZero_When_ListIsEmpty()
    {
        Assert.AreEqual(0, SumOddIndexElements([]),
            "Regola: lista vuota ha somma 0.");
    }

    [TestMethod]
    public void Should_ReturnTrue_When_KeyAndRoleMatch()
    {
        var db = new Dictionary<string, string> { { "key123", "ADMIN" } };
        Assert.IsTrue(ValidateApiKeyAccess(db, "key123", "ADMIN"),
            "Regola: chiave presente e ruolo corrispondente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_RoleDoesNotMatch()
    {
        var db = new Dictionary<string, string> { { "key123", "ADMIN" } };
        Assert.IsFalse(ValidateApiKeyAccess(db, "key123", "USER"),
            "Regola: chiave presente ma ruolo differente.");
    }

    [TestMethod]
    public void Should_ReturnFalse_When_KeyDoesNotExist()
    {
        Assert.IsFalse(ValidateApiKeyAccess([], "key999", "ADMIN"),
            "Regola: chiave non presente in mappa.");
    }


    [TestMethod]
    public void Should_CategorizeEvent_When_NegativeMultiple()
    {
        Assert.AreEqual("INVALID", CategorizeEventCode(-12));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_AnotherCommonMultiple()
    {
        Assert.AreEqual("CRITICAL_SYS_APP", CategorizeEventCode(24));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_OnlyFour()
    {
        Assert.AreEqual("SYS", CategorizeEventCode(4));
    }

    [TestMethod]
    public void Should_CategorizeEvent_When_OnlySix()
    {
        Assert.AreEqual("APP", CategorizeEventCode(6));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_TwoElements()
    {
        Assert.AreEqual(20, SumOddIndexElements([10, 20]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_EvenLength()
    {
        Assert.AreEqual(60, SumOddIndexElements([10, 20, 30, 40]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_OddValuesAtEvenIndices()
    {
        Assert.AreEqual(6, SumOddIndexElements([1, 2, 3, 4, 5]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_NegativeElements()
    {
        Assert.AreEqual(-60, SumOddIndexElements([10, -20, 30, -40]));
    }

    [TestMethod]
    public void Should_SumOddPositions_When_Zeros()
    {
        Assert.AreEqual(0, SumOddIndexElements([0, 0, 0, 0]));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MatchingKeyIsNotFirst()
    {
        var db = new Dictionary<string, string> { { "other", "USER" }, { "target", "ADMIN" } };
        Assert.AreEqual(true, ValidateApiKeyAccess(db, "target", "ADMIN"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_WrongKeyHasRequiredRole()
    {
        var db = new Dictionary<string, string> { { "other", "ADMIN" }, { "target", "USER" } };
        Assert.AreEqual(false, ValidateApiKeyAccess(db, "target", "ADMIN"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MissingKeyInNonEmptyMap()
    {
        var db = new Dictionary<string, string> { { "other", "ADMIN" } };
        Assert.AreEqual(false, ValidateApiKeyAccess(db, "missing", "ADMIN"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MatchingNonAdminRole()
    {
        var db = new Dictionary<string, string> { { "target", "EDITOR" } };
        Assert.AreEqual(true, ValidateApiKeyAccess(db, "target", "EDITOR"));
    }

    [TestMethod]
    public void Should_CheckExactAccess_When_MatchingKeyIsFirstAmongSeveral()
    {
        var db = new Dictionary<string, string> { { "target", "ADMIN" }, { "other", "USER" } };
        Assert.AreEqual(true, ValidateApiKeyAccess(db, "target", "ADMIN"));
    }
}