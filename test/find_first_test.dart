import 'package:clod_2026_programming_base/find_first.dart';
import 'package:test/test.dart';

void main() {
  group('.findFirst', () {
    test('returns the index of the first occurence', () {
      const list = [-1, 99, 2, 98, 4, -5, 2, 0];
      const n = 0;

      final result = findFirst(list, n);

      expect(result, equals(7));
    });
    test('returns `null` for an empty list', () {
      const list = <int>[];
      const n = 6742069;

      final result = findFirst(list, n);

      expect(result, isNull);
    });
    test("returns `-1` if list doesn't have the number", () {
      const list = [9, 4, 11];
      const n = 2;

      final result = findFirst(list, n);

      expect(result, equals(-1));
    });
    test("returns the first occurence if it's duplicated", () {
      const list = [2, 3, 2];
      const n = 2;

      final result = findFirst(list, n);

      expect(result, isZero);
    });
  });
}
