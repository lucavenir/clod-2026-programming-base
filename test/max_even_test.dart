import 'package:clod_2026_programming_base/max_even.dart';
import 'package:test/test.dart';

void main() {
  group('.maxEven', () {
    test('returns the maximum even number of a list', () {
      final list = <int>[0, 1, 2, 6, 7, 67, 69, 420, -999];

      final result = maxEven(list);

      expect(result, equals(420));
    });
    test('null if list is empty', () {
      final list = <int>[];

      final result = maxEven(list);

      expect(result, isNull);
    });
    test('null if list has only odd numbers', () {
      final list = <int>[1, 3, 5, 7, 9, 11];

      final result = maxEven(list);

      expect(result, isNull);
    });
    test('edge case: small even number after big odd number', () {
      final list = <int>[69, 42];

      final result = maxEven(list);

      expect(result, equals(42));
    });
    test('edge case: big odd number after smal even number', () {
      final list = <int>[42, 69];

      final result = maxEven(list);

      expect(result, equals(42));
    });
    test('edge case: works with negative numbers', () {
      final list = <int>[-42, -69];

      final result = maxEven(list);

      expect(result, equals(-42));
    });
  });
}
