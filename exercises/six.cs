var query = "aN";
List<String> names = [
    "Antonio Cristiano",
    "Aki Komi Sylvain",
    "Bon Daniel",
    "Calò Camilla",
    "Cechet Devis",
    "Chakich Mohamad",
    "Tegon Moira",
];

List<String> searchStudents(List<String> names, String query)
{
    List<String> results = [];
    foreach (var element in names)
    {
        if (element.ToLower().Contains(query.ToLower()))
        {
            results.Add(element);
        }
    }

    return results;
}