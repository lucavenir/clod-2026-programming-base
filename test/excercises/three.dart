import 'package:test/test.dart';

void main() {
  group('countSmallNames', () {
    test('counts names smaller or equals than 4', () {
      const list = ["Pippo", "Franco", "Piero", "Gigi"];
      expect(countSmallNames(list), equals(1));
    });
    test('zero on empty lists', () {
      expect(countSmallNames([]), isZero);
    });
    test('zero if no names are smaller than that', () {
      const list = ["Pippo", "Franco", "Piero", "Pluto"];
      expect(countSmallNames(list), isZero);
    });
  });
}

int countSmallNames(List<String> names) {
  var count = 0;

  for (final name in names) {
    if (name.length <= 4) {
      count = count + 1;
    }
  }

  return count;
}
