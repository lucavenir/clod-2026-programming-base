import 'package:test/test.dart';

void main() {
  // dalla consegna dell'esercizio
  const input = {
    "Luca Venir": 5,
    "Antonio Cristiano": 5,
    "Andrea Alongi": 9,
  };
  print(input["Luca Venir"]);

  // group('groupByGrade', () {
  //   test('counts and groups by grade', () {
  //     final result = groupByGrade(input);

  //     expect(
  //       result,
  //       equals([
  //         (grade: 5, names: ["Luca Venir", "Antonio Cristiano"]),
  //         (grade: 9, names: ["Andrea Alongi"]),
  //       ]),
  //     );
  //   });
  // });
}

Map<int, List<String>> groupByGrade(
  Map<String, int> students,
) {
  var results = <int, List<String>>{};
  for (final element in students.entries) {
    final name = element.key;
    final grade = element.value;
    if (results.containsKey(grade)) {
      results[grade]?.add(name);
    } else {
      results[grade] = [name];
    }
  }

  return results;
}
