import 'package:clod_2026_programming_base/max.dart';
import 'package:test/test.dart';

void main() {
  group('.max', () {
    test('returns the maximum of n integers (n>0)', () {
      const input = [-9, 9, 2, 13, 4, 5, -4];

      final maximum = max(input);

      expect(maximum, equals(13));
    });
    test('returns null if list is empty', () {
      const input = <int>[];

      final maximum = max(input);

      expect(maximum, isNull);
    });
  });
}
