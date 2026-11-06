import 'package:test/test.dart';

void main() {
  const names = ["Antonio Cristiano"];
  const query = "aN";

  test('aN occurs into Antonio Cristiano', () {
    final results = search(names, query);
    expect(results, equals(["Antonio Cristiano"]));
  });
  test('our class', () {
    const names = [
      "Antonio Cristiano",
      "Aki Komi Sylvain",
      "Bon Daniel",
      "Calò Camilla",
      "Cechet Devis",
      "Chakich Mohamad",
      "Tegon Moira",
    ];
    const query = "aN";

    final results = search(names, query);

    expect(
      results,
      equals([
        "Antonio Cristiano",
        "Bon Daniel",
        "Grizzo Rossana",
        "Manias Luca",
        "Santoni Chiara",
      ]),
    );
  });
}

List<String> search(List<String> names, String query) {
  var results = <String>[];

  for (final name in names) {
    // "antonio cristiano".contains("an") ?
    if (name.toLowerCase().contains(query.toLowerCase())) {
      // ho trovato un risultato di ricerca!
      results.add(name);
    }
  }

  return results;
}
