import 'package:clod_2026_programming_base/min.dart';
import 'package:test/test.dart';

void main() {
  group('.min', () {
    test('returns the minimum of n integers (n>0)', () {
      const input = [-9, 9, 2, 13, 4, 5, -4];

      final minimum = min(input);

      expect(minimum, equals(-9));
    });
    test('returns null if list is empty', () {
      const input = <int>[];

      final minimum = min(input);

      expect(minimum, isNull);
    });
  });
}
